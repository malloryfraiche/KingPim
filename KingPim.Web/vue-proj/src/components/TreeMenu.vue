<template>
    <div class="tree-menu">
        <div>{{ }}</div>
        <div>Hello from the TreeMenu</div>
        <tree-menu
                   v-for="node in nodes"
                   :nodes="node.nodes"
                   :label="node.label">

        </tree-menu>
    </div>
</template>

<script>
    export default {
        name: 'tree-menu',
        props: [
            'label',
            'nodes'
        ]
    }
</script>