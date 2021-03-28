import { AccessProxyBase, IAccessProxy } from "ayax-common-auth";
import { IEntity } from "ayax-common-types";

export abstract class BussinessEntityModelBase extends AccessProxyBase implements IAccessProxy, IEntity {
    id: number;
    code: string;
}