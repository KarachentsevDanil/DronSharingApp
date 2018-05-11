import * as httpService from '../../../api/http-service'

const apiRent = "/api/rent/";

export const getRentsByParams = data => {
    let params = {
        url: apiRent + "getRentsByParams",
        data: data
    }

    return httpService.postData(params);
}