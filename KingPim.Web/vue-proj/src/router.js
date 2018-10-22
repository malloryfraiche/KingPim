import Vue from 'vue'
import Router from 'vue-router'
import Skills from './components/Skills.vue'
import About from './components/About.vue'
import Home from './components/Home.vue'

Vue.use(Router);

export default new Router({
    routes: [

        {
            path: '/',
            name: 'home',
            component: Home,
        },
        {
            path: '/skills',
            name: 'skills',
            component: Skills
        },
        {
            path: '/about',
            name: 'about',
            component: About
        }
        
    ]
})