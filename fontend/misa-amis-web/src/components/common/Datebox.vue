<template>
    <DxDateBox type="date" 
        :show-clear-button="false" 
        displayFormat="dd-MM-yyyy"
        :useMaskBehavior="true" 
        v-model="clone_data"
        :fieldname="fieldname" /> 
</template>
<script>
//import library
import 'devextreme/dist/css/dx.light.css';
import { DxDateBox } from 'devextreme-vue/date-box';

/* eslint-disable no-debugger */

export default({

    components:{
        DxDateBox,
    },
    props:{
        date_value:{
            type:String,
        },
        fieldname:String,
    },
    data() {
        return {
            value:{},
            clone_data:"",
        }
    },

    created(){
        if(this.date_value){
            this.clone_data = JSON.parse(JSON.stringify(this.date_value));
        }
    },

    watch:{
        date_value:{
            deep:true,
            handler(val){
                if(val){
                    this.clone_data = JSON.parse(JSON.stringify(val));
                }

            }     
            
        },
        
        clone_data: function(val) {
            if(val){
                this.$emit('updateDateValue', val, this.fieldname);
            }

        },
    }
})
</script>
<style scoped>

</style>