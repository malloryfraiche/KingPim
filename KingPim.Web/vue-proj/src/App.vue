<template>
    <div id="app" class="container-fluid">

        <!--<div class="row">
            <div class="col-sm-3">
                <Menu />
            </div>
            <div class="col-sm-9">
                <router-view></router-view>
            </div>
        </div>-->

        <Navbar title="KingPim" />
        <div class="wrapper">
            <Sidebar></Sidebar>
            <div id="content">
                <b-nav class="navbar navbar-expand-lg navbar-light bg-light">
                    <div class="container-fluid">

                        <button type="button" id="sidebarCollapse" class="btn btn-sm btn-info">
                            <i class="fas fa-align-left"></i>
                            <span>Toggle Sidebar</span>
                        </button>

                    </div>
                </b-nav>
            </div>
        </div>

        <router-view />


    </div>
</template>


<script>
    import Navbar from './components/Navbar.vue'
    import Sidebar from './components/Sidebar.vue'
    import Menu from './components/Menu.vue'

    export default {
        name: 'app',
        components: {
            Menu,
            Navbar,
            Sidebar
        }
    }
</script>


<style>
    #app {
        background-color: #f5f5f5;
        display: table;
        width: 100%;
        height: 100vh;
        padding: 70px 25px;
    }
    .wrapper {
        display: flex;
        width: 100%;
        align-items: stretch;
    }



    .container-grid {
        background-color: #f5f5f5;
        margin-left: 10px;
    }
</style>
