export class WaterMeterReadingFactoryNbrAdd {
    houseId = 0;
    factoryNumber = "";
    reading = 0;

    constructor(init?: Partial<WaterMeterReadingFactoryNbrAdd>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
