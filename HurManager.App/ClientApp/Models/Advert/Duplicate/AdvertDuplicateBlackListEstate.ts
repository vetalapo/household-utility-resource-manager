import { Guid } from "ayax-common-types";

export class AdvertDuplicateBlackListEstate {
    uid: Guid;
    estateDescription: string;
    fullAddress: string;
    reason: string;
    cadastralNumber: string;
    startDate: Date;
    endDate: Date;
    constructor(init?: Partial<AdvertDuplicateBlackListEstate>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
