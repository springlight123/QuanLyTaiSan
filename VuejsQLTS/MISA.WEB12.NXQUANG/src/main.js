import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueRouter from 'vue-router'
import Employee from './components/view/Employee.vue'
import Asset from './components/view/Asset.vue'
import Resources from './js/Resources.js'
Vue.use(VueRouter, VueAxios, axios, Resources)
const routes = [{ path: '/employee', component: Employee },
    { path: '/asset', component: Asset }
]
const router = new VueRouter({
    mode: 'history',
    routes
})

Vue.config.productionTip = false
new Vue({
    router,
    render: h => h(App),
}).$mount('#app')