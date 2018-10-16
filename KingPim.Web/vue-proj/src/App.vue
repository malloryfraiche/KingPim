<template>
  <div id="app">

      <nav>
          <router-link to="/">Home</router-link>
          <router-link to="/about">About</router-link>
      </nav>

      <router-view />

  </div>
</template>




<script>
import Skills from './components/Skills.vue'

export default {
  name: 'app',
  components: {
    Skills
  }
}
</script>




<style>
body{
    background-color: #eeeeee;
}
</style>
