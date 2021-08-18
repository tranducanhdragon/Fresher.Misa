import Vue from 'vue'
import App from './App.vue'
import vuetify from '@/plugins/vuetify'
import axios from 'axios'
import VueAxios from 'vue-axios'
import router from './router'
import VTooltip from 'v-tooltip'


Vue.config.productionTip = false

//Sử dụng v-tooltip
Vue.use(VTooltip)

//khai báo VueAxios
Vue.use(VueAxios, axios)



//mount vào app
new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
