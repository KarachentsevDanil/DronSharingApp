import * as httpService from '../../../../../api/http-service'

const apiCompany = "/api/airtaxicompany/";

export const getCompaniesByParams = data => {
    let params = {
        url: apiCompany + "getAirTaxiCompaniesByParams",
        data: data
    }

    return httpService.postData(params);
}

export const addCompany = data => {
    let params = {
        url: apiCompany + "addAirTaxiCompany",
        data: data
    }

    return httpService.postData(params);
}