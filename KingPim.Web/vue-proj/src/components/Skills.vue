<template>
    <div class="hello">
        <div class="holder">

            <form @submit.prevent="addSkill">
                <input type="text" placeholder="Enter a skill that you have..." v-model="skill" v-validate="'min:5'" name="skill" />
                
                <!-- To apply animations... -->
                <transition name="alert-in">
                    <p class="alert" v-if="errors.has('skill')">{{ errors.first('skill') }}</p>
                </transition>

                
                <input type="checkbox" id="checkbox" v-model="checked" />
            </form>


            <ul>
                <li v-for="(s, index) in skills" :key='index'>
                {{s.skill}}
                <button v-on:click="remove(index)">Remove</button>
                </li>
            </ul>

            <p>These are the skills that you possess.</p>
        </div>
    </div>
</template>




<script>
    export default {
        name: 'Skills',
        data() {
            return {
                checked: false,
                skill: '',
                skills: [
                    { "skill": "skill1" },
                    { "skill": "skill2" }
                ],
                showAlertDiv: true
            }
        },
        methods: {
            addSkill() {

                this.$validator.validateAll().then((result) => {
                    if (result) {
                        this.skills.push({ skill: this.skill });
                        this.skill = '';
                        console.log('This checkbox value is: ' + this.checked);
                    }
                    else {
                        console.log('Not valid.');
                    }
                });

            },
            remove(id) {
                this.skills.splice(id, 1);
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

    .alert-in-enter-active{
        animation: bounce-in .5s;
    }
    .alert-in-leave-active {
        animation: bounce-in .5s reverse;
    }
    @keyframes bounce-in {
        0%{
            transform:scale(0);
        }
        50%{
            transform:scale(1.5);
        }
        100%{
            transform:scale(1);
        }
    }

</style>
