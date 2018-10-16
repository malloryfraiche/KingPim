<template>
    <div class="hello">
        <div class="holder">
            <ul>
                <li v-for="(s, index) in skills" :key='index'>{{index}}. {{s.skill}}</li>
            </ul>
            <div v-bind:class="{ alert: showAlertDiv }"></div>
        </div>
    </div>
</template>




<script>
    export default {
        name: 'Skills',
        data() {
            return {
                skills: [
                    { "skill": "skill1" },
                    { "skill": "skill2" }
                ],
                showAlertDiv: true
            }
        }
    }
</script>





<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .alert{
        background-color: red;
        width: 100%;
        height: 30px;
    }

</style>
