import Vue from 'vue'
import Router from 'vue-router'
//import HelloWorld from '@/components/HelloWorld'
import Home from '@/components/Home'
import ProductList from '@/components/ProductList'
import ProductDetail from '@/components/ProductDetail'
import Register from '@/components/Register'
import Login from '@/components/Login'
import Shoppingcarts from '@/components/Shoppingcarts'
Vue.use(Router)



export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/ProductDetail',
      name: 'ProductDetail',
      component: ProductDetail
    },
    
    {
      path: '/Register',
      name: 'Register',
      component: Register
    },
    {
      path: '/ProductList',
      name: 'ProductList',
      component: ProductList
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login
    },
    {
      path: '/Shoppingcarts',
      name: 'Shoppingcarts',
      component: Shoppingcarts,
      meta:{
        needLogin:true//需要加校检判断的路由
      }
    },
   
  ]
})
