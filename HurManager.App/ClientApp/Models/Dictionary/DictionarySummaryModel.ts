import { IEntity } from "ayax-common-types";

export class DictionarySummaryModel implements IEntity {
    id: number;
    title: string;
    order: number;
    description: string;
    constructor(init?: Partial<DictionarySummaryModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}