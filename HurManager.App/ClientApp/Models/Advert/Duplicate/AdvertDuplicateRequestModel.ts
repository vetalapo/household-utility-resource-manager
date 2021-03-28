import { Guid } from "ayax-common-types";

export class AdvertDuplicateRequestModel {
    address: {
        regionGuid: Guid;
        areaGuid: Guid;
        cityGuid: Guid;
        placeGuid: Guid;
        streetGuid: Guid;
        house: string;
        building: string;
        liter: string;
    } = { areaGuid: null, building: null, cityGuid: null, house: null, liter: null, placeGuid: null, regionGuid: null, streetGuid: null, };
    contactPhones: string[];
    estateTypeId: number;

    constructor(init?: Partial<AdvertDuplicateRequestModel>) {
        if (init) {
            Object.assign(this, init);
            this.address = init.address;
        }
    }
}
