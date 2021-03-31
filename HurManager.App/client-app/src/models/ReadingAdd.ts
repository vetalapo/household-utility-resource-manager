export class ReadingAdd {
    identifier: string = "";
    reading: number = 0;

    constructor(init?: Partial<ReadingAdd>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
