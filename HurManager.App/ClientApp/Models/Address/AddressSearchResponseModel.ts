import { Guid } from "ayax-common-types";

export class AddressSearchResponseModel {

    parentGuid:Guid;
    parentLevel: number = 0;
    parentName: string;
    parentShortName: string;
    aoGuid: Guid;
    offName: string;
    shortName: string;
    fullName:string;
    constructor(init?: Partial<AddressSearchResponseModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
