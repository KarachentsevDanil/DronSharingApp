import * as httpService from '../../../../../api/http-service'

const apiTaxiModel = "/api/airtaximodel/";
const apiTaxiCompany = "/api/airtaxicompany/";
const apiTaxiType = "/api/airtaxitype/";
const apiTaxi = "/api/airtaxi/";

export const getAirTaxiById = id => {
    let params = {
        url: apiTaxi + `getTaxiById/${id}`
    }

    return httpService.getData(params);
}

export const getAirTaxiModels = data => {
    let params = {
        url: apiTaxiModel + "getAirTaxiModels",
        data: data
    }

    return httpService.getData(params);
}

export const getAirTaxiCompanies = data => {
    let params = {
        url: apiTaxiCompany + "getAirTaxiCompanies",
        data: data
    }

    return httpService.getData(params);
}

export const getAirTaxiTypes = data => {
    let params = {
        url: apiTaxiType + "getAirTaxiTypes",
        data: data
    }

    return httpService.getData(params);
}

export const getTaxiesByParams = data => {
    let params = {
        url: apiTaxi + "getAirTaxiesByParams",
        data: data
    }

    return httpService.postData(params);
}

export const addAirTaxi = data => {
    let params = {
        url: apiTaxi + "addAirTaxi",
        data: data
    }

    return httpService.postData(params);
}