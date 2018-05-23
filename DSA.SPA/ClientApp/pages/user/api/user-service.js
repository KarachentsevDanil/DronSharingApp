import * as httpService from '../../../api/http-service';

const apiFacility = "/api/facility/";

export const getFacilities = data => {
    let params = {
        url: apiFacility + "getFacilities",
        data: data
    }

    return httpService.postData(params);
}

export const addFacility = data => {
    let params = {
        url: apiFacility + "addFacility",
        data: data
    }

    return httpService.postData(params);
}