import { Guid } from "ayax-common-types";

export class AddressSelectRequestModel {

    parentAOGuid: Guid;
    requestedAOLevel: number;

    constructor(init?: Partial<AddressSelectRequestModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
