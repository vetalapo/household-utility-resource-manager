import { IEntity } from "ayax-common-types";

export class DictionaryModelBase implements IEntity {
    id: number;
    isActive: boolean;
    order: number;
    title: string;
    
    constructor(init?: Partial<DictionaryModelBase>) {
        if (init) {
            Object.assign(this, init);
        }
    }

    static Create() {
        return new DictionaryModelBase({
            id: 0,
            title: null,
            order: 0,
            isActive: true
        });
    }
}