import { AdvertDuplicateContact } from "./AdvertDuplicateContact";
import { AdvertDuplicateEstate } from "./AdvertDuplicateEstate";
import { AdvertDuplicateBlackListEstate } from "./AdvertDuplicateBlackListEstate";

export class AdvertDuplicateResponseModel {
    blackListEstates:AdvertDuplicateBlackListEstate[];
    estates: AdvertDuplicateEstate[];
    contacts: AdvertDuplicateContact[];
    constructor(init?: Partial<AdvertDuplicateResponseModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
