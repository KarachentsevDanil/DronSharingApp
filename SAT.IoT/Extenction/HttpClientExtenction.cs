﻿using Newtonsoft.Json;
using SAT.IoT.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SAT.IoT.Extenction
{
    public static class HttpClientExtenction
    {
        private static HttpClient _client;

        public static CurrentUserViewModel User;

        public static HttpClient Client
        {
            get
            {
                if (_client != null)
                {
                    if (User != null)
                    {
                        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.Token);
                    }

                    return _client;
                }

                _client = new HttpClient();

                try
                {
                    _client.BaseAddress = new Uri($"{Constants.BaseUrl}");
                }
                catch (Exception)
                {
                    // Error will be thrown on first attempt to connect
                }

                if (User != null)
                {
                    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", User.Token);
                }

                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return _client;
            }
        }

        public static void PostData<T>(T data, string address)
        {
            var response = PostDataAndGetHttpResponse(data, address);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }
        }

        public static TR PostDataAndGetResult<TI, TR>(TI data, string address) where TR : class, new()
        {
            var response = PostDataAndGetHttpResponse(data, address);

            if (response.IsSuccessStatusCode)
            {
                // Get reponse and parse result
                var responseText = response.Content.ReadAsStringAsync().Result;
                var result = responseText.TryParseJson<TR>();
                return result;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        public static T GetResult<T>(string address) where T : class, new()
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync(address).Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetBaseException().Message);
            }

            if (response.IsSuccessStatusCode)
            {
                // Get reponse and parse result
                var responseText = response.Content.ReadAsStringAsync().Result;
                var result = responseText.TryParseJson<T>();
                return result;
            }

            throw new Exception(response.Content.ReadAsStringAsync().Result);
        }

        private static HttpResponseMessage PostDataAndGetHttpResponse<T>(T data, string address)
        {
            HttpResponseMessage response;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                response = Client.PostAsync(address, content).Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.GetBaseException().Message);
            }

            return response;
        }

        public static T TryParseJson<T>(this string json) where T : new()
        {
            try
            {
                var deserializedObject = JsonConvert.DeserializeObject<T>(json);
                return deserializedObject;
            }
            catch (JsonException)
            {
                return default(T);
            }
        }
    }
}
