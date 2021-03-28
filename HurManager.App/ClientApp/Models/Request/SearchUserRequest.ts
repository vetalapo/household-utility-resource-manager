import { ISearchUserRequest } from "ayax-common-auth";
import { Guid } from "ayax-common-types";

export class SearchUserRequest implements ISearchUserRequest {
    isActive?: boolean;
    isSelectAll?: boolean;
    name?: string;
    showChildren?: boolean;
    subdivisionsIds?: number[];
    groupGuids?: Guid[];
    notInGroupGuids?: Guid[];
    page?: number;
    perPage?: number;
    IncludeUIDs?: Guid[];

    constructor(init?: Partial<SearchUserRequest>) {
        if (init) {
            Object.assign(this, init);
        }
    }
}

