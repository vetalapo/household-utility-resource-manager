import { IEntity } from "ayax-common-types";

export class PropertyCategory implements IEntity {
    propertySubCategories: number[];
    id: number;
    title: string;
    order: number;
    constructor(init?: Partial<PropertyCategory>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}