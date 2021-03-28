import { IEntity } from "ayax-common-types";

export class EntityEvent implements IEntity {
    id: number;
    entityType: string;
    entityEventTypeAlt: string;
    isEditable: boolean;
    period: Date;
    registratorId: number;
    userName: string;
    title: string;
    content: string;
    userProfileUrl: string;

    constructor(init?: Partial<EntityEvent>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}
