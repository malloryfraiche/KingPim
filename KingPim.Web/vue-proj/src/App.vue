<template>
    <div id="app">

        <Navbar />

        <!--<SidebarMenu />-->

        <TreeMenu />

        <router-view />

    </div>
</template>


<script>
    //import Skills from './components/Skills.vue'
    import Navbar from './components/Navbar.vue'
    import SidebarMenu from './components/SidebarMenu.vue'
    import TreeMenu from './components/TreeMenu.vue'

    export default {
        name: 'app',
        components: {
            //Skills,
            Navbar,
            SidebarMenu,
            TreeMenu
        }
    }
</script>


<style>
    body {
        background-color: #eeeeee;
    }
</style>
