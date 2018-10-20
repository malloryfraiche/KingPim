<template>
    <div id="app">

        <Navbar title="KingPim" />
        <router-view />


    </div>
</template>


<script>
    import Navbar from './components/Navbar.vue'

    export default {
        name: 'app',
        components: {
            Navbar
        }
    }
</script>


<style>
    #app {
        background-color: #f5f5f5;
        /*display: table;*/
        width: 100%;
        height: 100vh;
        padding: 70px 25px;
    }
</style>
