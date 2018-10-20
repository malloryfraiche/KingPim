<template>
    <header>
        <b-navbar class="fixed-top" toggleable="md" type="dark" variant="dark">
            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <b-navbar-brand to="/">{{title}}</b-navbar-brand>
            <b-collapse is-nav id="nav-collapse">
                <b-navbar-nav>
                    <b-nav-item to="/about">About</b-nav-item>
                    <b-nav-item to="/skills">Skills</b-nav-item>
                    <b-nav-item href="#">Login</b-nav-item>
                    <b-nav-item href="#">Logout</b-nav-item>
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>
    </header>
</template>


<script>
    export default {
        name: 'Navbar',
        props: {
            title: String
        }
    }
</script>