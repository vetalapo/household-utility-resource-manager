export class AdvertDuplicateEstate {
    code: string;
    objectSummary: string;
    address: string;
    statusName: string;
    agentInfo: string;
    constructor(init?: Partial<AdvertDuplicateEstate>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
