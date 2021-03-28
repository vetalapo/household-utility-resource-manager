import { IEntity } from "ayax-common-types";

export class Switcher implements IEntity {
    id: number;
    divisionId: number;
    endDateTime: Date;
    startDateTime: Date;

    constructor(init?: Partial<Switcher>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}