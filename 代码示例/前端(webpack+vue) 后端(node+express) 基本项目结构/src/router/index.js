import Vue from 'vue'
import Router from 'vue-router'
import HelloWorld from '@/components/HelloWorld'
import device from '@/components/device'
import toiletinfo from '@/components/toiletinfo'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'device',
      component: device
    },
    {
      path: '/toiletinfo',
      name: 'toiletinfo',
      component: toiletinfo
    }
  ]
})
