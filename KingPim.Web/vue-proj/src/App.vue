<template>
    <div id="app">

        <Navbar />

        <TreeMenu />

        <router-view />

    </div>
</template>


<script>
    //import Skills from './components/Skills.vue'
    import Navbar from './components/Navbar.vue'
    import TreeMenu from './components/TreeMenu.vue'

    export default {
        name: 'app',
        components: {
            //Skills,
            Navbar,
            TreeMenu
        }
    }
</script>


<style>
    body {
        background-color: #eeeeee;
    }
</style>
