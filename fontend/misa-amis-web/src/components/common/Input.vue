<template>
    <div class="input-cp" >
        <input 
            :value="clone_value"
            :type="typeInput" 
            :placeholder="placeholder" 
            :fieldname="fieldname"
            :maxlen="maxlen"
            :required="required"
            :class="custom_class"
            v-model="clone_value"
            v-on:blur="blurEvent" >

        <div v-show="type == 'search'" class="icon-search"></div>
    </div>
</template>
<script>
/* eslint-disable no-debugger */

export default {
    props:{
        type: {
            type: String,
            default: 'input'
        },
        value:{
            type: String,
            default: ''
        },
        placeholder:{
            type: String,
            default: ""
        },

        typeInput: {
            type: String,
            default: 'text'
        },
        fieldname:{
            type: String,
            default: ''
        },
        required:{
            type:String,
            default:'',
        },
        maxlen:{
            type:String,
            default:'',
        },
        custom_class:{
            type:String,
            default:'',
        }
    },

    data(){
        return{
            clone_value:'',
        }
    },

    watch:{
        value:{
            immediate:true,
            deep:true,
            handler(val){
                this.clone_value = JSON.parse(JSON.stringify(val));

            }
        },

        clone_value:{
            deep:true,
            handler(val){
                this.$emit('valueInputChange', val, this.fieldname, this.required, this.maxlen);
            }
        },

        // custom_class:{
        //     deep:true,
        //     handler(val){
        //         console.log(val);
        //     }
        // }
    },

    methods: {
        blurEvent(){
            this.$emit('blurEvent');
        }

    },
}
</script>

<style scoped>
.input-cp {
    height: 32px;
    padding: 0;
    align-items: center;
    position: relative;
         
}
.icon-search {
    position: absolute;
    right: 4px;
    top: 8px;
} 
input:focus {
    border: 1px solid #2CA01C !important;
}
input {
    width: calc(100% - 0px);
    height: 100%;
    margin: 0;
    background-color: unset !important;
    outline: none !important;
    border: 1px solid #BABEC5;
    border-radius: 2px;
    padding: 0 8px 0px 8px;
    
}
input::placeholder{
    font-family: notosans-italic;
    font-size: 12px;
    margin-left: 8px;
}
input:hover {
    border: 1px solid #2CA01C;
}
.red_border{
    border: 1px solid #FF4747 !important;
}
</style>