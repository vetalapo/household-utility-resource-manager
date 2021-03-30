import { IServerSettings } from "./IServerSettings";

export declare class ServerSettings implements IServerSettings {
    baseUrl: string;
    apiPrefix: string;
    
    constructor(init?: Partial<ServerSettings>);
}