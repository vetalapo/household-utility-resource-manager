import "../node_modules/vuetify/dist/vuetify.min.css";
import "./style.css";

import Vue from "vue";
import VueRouter, { RouterOptions } from "vue-router";
import App from "./App/App.vue";
import { routes } from "./Routes";
import store from "./Store";

Vue.use(VueRouter);

const routerOptions = <RouterOptions>{ mode: "history", routes };

Vue.config.devtools = !(process.env.NODE_ENV === "production");

new Vue({
    el: "#app",
    store,
    router: new VueRouter(routerOptions),
    render: h => h(App),
});
