import { IEntity } from "ayax-common-types";
import { ContactTypeModel } from "../ContactType/ContactType";

export class ContactModel implements IEntity {
    id: number;
    contactTypeId: number;
    contactType: ContactTypeModel;
    mask: string;
    notes: string;
    value: string;
    order: number;
    customerId?: number;
    name?: string;
    isHidden: boolean;

    constructor(init?: Partial<ContactModel>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
