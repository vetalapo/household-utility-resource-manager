export class AdvertDuplicateContact {
    personName: string;
    phones: string;
    comment: string;
    status: string;

    constructor(init?: Partial<AdvertDuplicateContact>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
