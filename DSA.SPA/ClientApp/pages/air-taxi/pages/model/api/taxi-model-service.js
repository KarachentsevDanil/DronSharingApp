import * as httpService from '../../../../../api/http-service'

const apiTaxiModel = "/api/airtaximodel/";
const apiTaxiCompany = "/api/airtaxicompany/";
const apiTaxiType = "/api/airtaxitype/";

export const getTaxiModelsByParams = data => {
    let params = {
        url: apiTaxiModel + "getAirTaxiModelsByParams",
        data: data
    }

    return httpService.postData(params);
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

export const addTaxiModel = data => {
    let params = {
        url: apiTaxiModel + "addAirTaxiModel",
        data: data
    }

    return httpService.postData(params);
}