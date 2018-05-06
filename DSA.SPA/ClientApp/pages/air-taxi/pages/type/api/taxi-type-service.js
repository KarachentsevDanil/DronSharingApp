import * as httpService from '../../../../../api/http-service'

const apiTaxiType = "/api/airtaxitype/";

export const getTaxiTypesByParams = data => {
    let params = {
        url: apiTaxiType + "getAirTaxiTypesByParams",
        data: data
    }

    return httpService.postData(params);
}

export const addTaxiType = data => {
    let params = {
        url: apiTaxiType + "addAirTaxiType",
        data: data
    }

    return httpService.postData(params);
}