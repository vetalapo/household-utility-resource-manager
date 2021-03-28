import { Guid } from "ayax-common-types/dist/Types/Guid/Guid";

export class AdvertAddressModel {
    regionGuid: Guid;
    areaGuid: Guid;
    cityGuid: Guid;
    placeGuid: Guid;
    streetGuid: Guid;
    house: string;
    building: string;
    liter: string;
    fullAddress: string;
    constructor(init?: Partial<AdvertAddressModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
