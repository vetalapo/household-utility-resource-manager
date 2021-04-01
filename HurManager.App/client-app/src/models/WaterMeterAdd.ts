export class WaterMeterAdd {
    houseId = 0;
    factoryNumber = "";
    reading = 0;

    constructor(init?: Partial<WaterMeterAdd>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
