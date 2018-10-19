<template>
    <header>
        <b-navbar toggleable="md" type="light" variant="light">
            <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
            <b-navbar-brand to="/">KingPim</b-navbar-brand>
            <b-collapse is-nav id="nav-collapse">
                <b-navbar-nav>
                    <b-nav-item to="/about">About</b-nav-item>
                    <b-nav-item href="#">Login</b-nav-item>
                    <b-nav-item href="#">Logout</b-nav-item>
                </b-navbar-nav>
            </b-collapse>
        </b-navbar>
    </header>
</template>