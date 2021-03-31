export class HouseSummary {
    id: number = 0;
    address: string = "";
    waterMeterId: number = 0;
    waterMeterReading: number = 0;
    waterMeterFactoryNumber: string = "";

    constructor(init?: Partial<HouseSummary>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
