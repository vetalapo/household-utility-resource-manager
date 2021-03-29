import Vue from "vue";
import { Provide } from "vue-property-decorator";
import { EVENTBUS } from "./EventBus";
import { HttpService } from "./Services/Http/HttpService";
import { IHttpService } from "./Services/Http/IHttpService";

export abstract class ServiceProvider extends Vue {
    @Provide()
    httpService: IHttpService = new HttpService();
    @Provide()
    eventBus: Vue = EVENTBUS;
}
