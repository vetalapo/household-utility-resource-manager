import { Component } from "vue-property-decorator";
import HomeLayout from "../Layout/Secured/SecuredLayout.vue";
import { ServiceProvider } from "../ServiceProvider";

@Component({
    components: {
        secured: HomeLayout,
    },
})
export default class App extends ServiceProvider {
    loading = false;
    currentView = "home";

    async created() {
    }
}
