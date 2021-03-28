import {
    ClientSettings,
    IAppSettings,
    IClientSettings,
    INotificationSettings,
    IServerSettings,
    NotificationSettings,
    ServerSettings,
} from "ayax-common-types";
import { EventTypeSettings } from "./Settings/EventTypeSettings";

export class AppSettings implements IAppSettings {
    Custom(): { [name: string]: any } {
        return {
            EventTypes: EventTypeSettings.EventTypes(),
        };
    }

    Notification(): INotificationSettings {
        return new NotificationSettings({ successDismiss: 3000 });
    }

    Server(): IServerSettings {
        return new ServerSettings({
            apiPrefix: "/api",
            authenticateUrl: "/authenticate",
            baseUrl: "",
            tokenCheckMethod: "/infosource/list",
        });
    }

    Client(): IClientSettings {
        return new ClientSettings({
            clientCacheExpiresAfter: 20,
            listRowsPerpage: 20,
            systemCode: "as",
        });
    }
}
