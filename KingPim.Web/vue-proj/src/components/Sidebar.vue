<template>

    <div class="sidebar">

        <div class="sidebar-header">
            <h3>Bootstrap Sidebar</h3>
        </div>

        <ul class="list-unstyled components">
            <p>Dummy Heading</p>
            <li class="active">
                <a href="#homeSubmenu" data-toggle="collapse" aria-expanded="true" class="dropdown-toggle">Home</a>
                <ul class="collapse list-unstyled" id="homeSubmenu">
                    <li>
                        <a href="#">Home 1</a>
                    </li>
                    <li>
                        <a href="#">Home 2</a>
                    </li>
                    <li>
                        <a href="#">Home 3</a>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">About</a>
            </li>
            <li>
                <a href="#pageSubmenu" data-toggle="collapse" aria-expanded="false" class="dropdown-toggle">Pages</a>
                <ul class="collapse list-unstyled" id="pageSubmenu">
                    <li>
                        <a href="#">Page 1</a>
                    </li>
                    <li>
                        <a href="#">Page 2</a>
                    </li>
                    <li>
                        <a href="#">Page 3</a>
                    </li>
                </ul>
            </li>
            <li>
                <a href="#">Portfolio</a>
            </li>
            <li>
                <a href="#">Contact</a>
            </li>
        </ul>

    </div>

</template>

<script>



</script>

<style scoped>
    #sidebar {
        min-width: 250px;
        max-width: 250px;
        min-height: 100vh;
    }

        #sidebar.active {
            margin-left: -250px;
        }
    a[data-toggle="collapse"] {
        position: relative;
    }

    .dropdown-toggle::after {
        display: block;
        position: absolute;
        top: 50%;
        right: 20px;
        transform: translateY(-50%);
    }
    @media (max-width: 768px) {
        #sidebar {
            margin-left: -250px;
        }

            #sidebar.active {
                margin-left: 0;
            }
    }

    /*.sidebar {
        background-color: #fee;
        height: 100%;
        width: 150px;
        max-width: 1024px;
        opacity: 0.5;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
        overflow-x: hidden;
        box-sizing: border-box;
    }*/

    /*h1 {
        display: inline;
        height: 29px;
        width: 156px;
    }

    ul,
    #sublist {
        list-style: none;
        margin: 0;
        padding: 0;
    }

    a {
        height: 20px;
        width: 200px;
        text-decoration: none;
        display: block;
    }*/

</style>