import * as httpService from '../../../api/http-service';

const apiResident = "/api/resident/";

export const getResidentById = id => {
    let params = {
        url: apiResident + `GetResidentById?id=${id}`
    }

    return httpService.getData(params);
}

export const getResidents = data => {
    let params = {
        url: apiResident + "getResidents",
        data: data
    }

    return httpService.postData(params);
}

export const addResident = data => {
    let params = {
        url: apiResident + "addResident",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentDoctor = data => {
    let params = {
        url: apiResident + "addResidentDoctor",
        data: data
    }

    return httpService.postData(params);
}

export const addResidentContact = data => {
    let params = {
        url: apiResident + "addResidentContact",
        data: data
    }

    return httpService.postData(params);
}