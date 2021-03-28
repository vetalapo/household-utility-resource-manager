import { IEntity } from "ayax-common-types";

export class PropertySubCategory implements IEntity {
    propertyCategoryId: number;
    id: number;
    title: string;
    order: number;
    constructor(init?: Partial<PropertySubCategory>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}