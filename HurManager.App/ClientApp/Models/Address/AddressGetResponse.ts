import { Guid } from "ayax-common-types/dist/Types/Guid/Guid";

export class AddressGetResponse {
    ayaxGuid: Guid;
    offName: string;
    shortName: string;
    fullName: string;
    constructor(init?: Partial<AddressGetResponse>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
