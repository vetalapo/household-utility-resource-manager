import { IAppSettings } from "./IAppSettings";
import { IServerSettings } from "./IServerSettings";
import { ServerSettings } from "./ServerSettings";

export class AppSettings implements IAppSettings {
    Server(): IServerSettings {
        return new ServerSettings({
            apiPrefix: "/api",
            baseUrl: ""
        });
    }
}
