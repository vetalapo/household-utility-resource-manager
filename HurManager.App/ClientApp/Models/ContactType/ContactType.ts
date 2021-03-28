import { IEntity } from "ayax-common-types";

export class ContactTypeModel implements IEntity {
    id: number;
    title: string;
    mask: string;
    constructor(init?: Partial<ContactTypeModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}