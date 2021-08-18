<template>
    <v-select
        :items="data_dropdown.items"
        :placeholder="data_dropdown.title"
        :value="selected_value"
        label=""
        color="#bbbbbb"
        v-on:change="selectedValue($event)"
        class="v-select-custom" >

    </v-select>
</template>

<script>
export default {
    props:{
        data_dropdown:{},
        selected_value:{},
    },
    data() {
        return {
            items:{},
            value:{},
        };
    },
    /**
     * trả ra giá trị được chọn trong dropdown
     * tdanh 6.2021
     */
    methods:{
        selectedValue(value){
            this.$emit('getSelectedValue', value);
        }
    },
};
</script>
<style>
.v-select-custom .v-input .v-input__control .v-input__slot{
    min-height: 0px !important;
    padding: 0px !important;
}
.v-select-custom .v-input .v-input__control .v-input__slot .v-input__append-inner{
    margin-top: 10px;
}
.v-select-custom .v-input .v-input__control .v-input__slot > fieldset{
    padding: 0px;
}
.v-select-custom .v-icon{
    margin-top: 3px;
}
.v-select-custom .v-select__slot{
    height: 40px;
    border: 1px solid #bbbbbb;
    border-radius: 4px;
}

.v-menu__content{
    overflow: unset;
}
.v-select-custom .v-select__selections {
    max-width: 90%;
    font-size: 12px;
    margin-left: 10px;
}

.v-list{
    padding: 0px;
    position: relative;
    top:40px !important;
    height:fit-content;
}
.v-select-custom .v-list .v-list-item{
    padding: 0px;
}
.v-list-item__title{
    text-align: center;
    font-size: 12px;
    font-family: notosans-regular;
}
.v-select-custom .v-list .v-list-item:hover{
    background-color: #E9EBEE;
}
.v-select-custom .v-list-item .v-list-item__subtitle, .v-list-item .v-list-item__title:hover{
    color: #000000;
}
.v-application .primary--text, .v-list-item--active{
    color: #ffffff !important;
    caret-color: #2fbe8e !important;
    background-color: #2fbe8e !important;
}
.v-text-field--outlined.v-input--has-state fieldset, .v-text-field--outlined.v-input--is-focused fieldset{
    border: none !important;
}

.v-text-field {
    padding-top: 0px !important;
    margin-top: 0px !important;
}
.theme--light.v-text-field>.v-input__control>.v-input__slot:before {
    border: none !important;
}
.theme--light.v-text-field>.v-input__control>.v-input__slot:after {
    border: none !important;
}
</style>