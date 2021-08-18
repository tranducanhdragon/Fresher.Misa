<template>

    <div class="dx-field-value">
        <DxAutocomplete
        v-model="item_model"
        :show-clear-button="true"
        placeholder="Tìm theo chức vụ..."
        />
    </div>

</template>
<script>
import { DxAutocomplete } from 'devextreme-vue/autocomplete';

export default {
    components: {
        DxAutocomplete,
    },
    props:{
        data_selected:{},
    },
    data() {
        return {
            clone_data_selected:{},
            item_model:'',
        };
    },
    watch:{

        data_selected:{
            deep:true,
            handler(val){
                debugger;// eslint-disable-line no-debugger
                console.log(val);
                this.clone_data_selected = JSON.parse(JSON.stringify(val));
            },
        },
        item_model:{
            deep:true,
            handler(val){
                debugger;// eslint-disable-line no-debugger
                console.log(val);
            },
        },
    },
    methods: {

    }
}
</script>
<style>
.dx-field-value{
    width:auto !important;
    height:40px !important;
    position:fixed !important;
}
.dx-field-value.dx-widget, .dx-field-value:not(.dx-widget) > .dx-widget {
    margin: 0;
    height: 40px !important;
}

.dx-placeholder{
    font-family: notosans-regular;
    font-size: 12px !important;
}
</style>