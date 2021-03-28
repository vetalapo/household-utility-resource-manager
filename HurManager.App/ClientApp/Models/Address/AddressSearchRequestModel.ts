import { Guid } from "ayax-common-types";

export class AddressSearchRequestModel {

    region: Guid;
    area: Guid;
    city: Guid;
    place: Guid;
    term:string;
    level: number;

    constructor(init?: Partial<AddressSearchRequestModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
