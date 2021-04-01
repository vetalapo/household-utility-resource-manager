export class ReadingAdd {
    identifier = "";
    reading = 0;

    constructor(init?: Partial<ReadingAdd>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
