import Vue from 'vue'
import Vuetify from 'vuetify'
import App from './App.vue'
import router from './router'
import store from './store'

Vue.config.productionTip = false

Vue.use(Vuetify, {
  iconfont: "mdi",
});

new Vue({
  router,
  store,
  vuetify : new Vuetify(),
  render: h => h(App)
}).$mount('#app')
