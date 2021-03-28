import { Guid } from "ayax-common-types";

export class AddressSelectResponseModel {

    aoLevel: number;
    aoGuid: Guid;
    offName:string;
    shortName: string;
    fullName: string = "";
    constructor(init?: Partial<AddressSelectResponseModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
