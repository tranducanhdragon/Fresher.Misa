<template>

  <DxSelectBox
    :searchEnabled="searchEnabled"
    :placeholder="placeholder_expr"
    noDataText="Không có dữ liệu hợp lệ"
    :dataSource="clone_custom_dropdown"
    :showClearButton="false"
    :searchTimeout="0"
    :search-expr="search_expr"
    display-expr="data_text"
    value-expr="id"
    class="dxCombobox"
    :class="custom_class"
    v-model="clone_current_id"
    v-on:blur="blurEvent" >
    
  </DxSelectBox>
</template>

<script>
import DxSelectBox from "devextreme-vue/select-box";
/* eslint-disable no-debugger */

export default {
    components: {
        DxSelectBox,
    },

    props: {
        customDataDropDown: [],
        currentDataInput:String,
        currentIdInput:String,
        placeholder_expr:String,
        custom_class:String,
        searchEnabled:{
            type: Boolean,
            default: true
        },
    },

    data(){
        return{
            clone_custom_dropdown:[],
            clone_current_input:'',
            clone_current_id:'',
            search_expr: 'data_text',
        }
    },
    /**
     * gán những dữ liệu tĩnh từ bên ngoài
     */
    //gán props customData vào clone_custom ngay khi khởi tạo
    created(){
        if(typeof(this.customDataDropDown) != 'undefined'){
            this.clone_custom_dropdown = JSON.parse(JSON.stringify(this.customDataDropDown));

        }

    },

    mounted(){

    },

    watch:{

        currentDataInput:{
            immediate:true,
            deep:true,
            handler:function(val){
                //khi thêm mới thì val = undefined
                if(val){
                    this.clone_current_input = JSON.parse(JSON.stringify(val));
                    //gán dữ liệu trong combobox vào employee dưới dạng thô
                    this.$emit('setSelectValue', this.clone_current_input);
                }

            }
        },
        currentIdInput:{
            immediate:true,
            deep:true,
            handler:function(val){
                //vì khi thêm mới thì val = undefined
                if(val){
                    this.clone_current_id = JSON.parse(JSON.stringify(val));
                    //gán dữ liệu trong combobox vào employee dưới dạng thô
                    this.$emit('setSelectValue', this.clone_current_id);
                }

            }
        },

        clone_current_id:{
            deep:true,
            handler:function(val){
                // if(val){
                    this.$emit('setSelectValue', val);
                // }
            }
        },


    },
    methods: {
        blurEvent(){
            this.$emit('blurEvent');
        },
    }
};
</script>

<style>
.dxCombobox {
    height: 32px !important;
    border:1px solid #BABEC5;
    border-radius: 2px;
}

/* chỉnh nút mũi tên */
.dxCombobox .dx-button-content {
    border-left: 0px solid #bbb;
}
.dxCombobox .dx-button-content:hover {
    background-color: #e9ebee !important;
    border-radius: 0 4px 0 0;
}
.dxCombobox .dx-dropdowneditor-icon {
    border: none ;
    width: 100%;
    font-size: 0;
    background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -1741px -304px;
    background-size: auto;
    border-radius: 0 4px 0 0;
    transition: .2s;
}
.dxCombobox .dx-button-normal.dx-button-mode-contained.dx-widget.dx-dropdowneditor-button {
    padding: 0 !important;
    width: 40px;
}
/* trạng thái hover của nút mũi tên*/
.dxCombobox.dx-dropdowneditor-button.dx-state-active .dx-button-content, .dxCombobox.dx-dropdowneditor.dx-dropdowneditor-active .dx-button-content {
    background-color: #e9ebee;
}
.dxCombobox.dx-dropdowneditor.dx-state-active .dx-button-content, .dxCombobox.dx-dropdowneditor.dx-state-hover:not(.dx-custom-button-hovered) .dx-button-content {
    background-color: #e9ebee;
}
.dxCombobox.dx-dropdowneditor.dx-state-active .dx-dropdowneditor-icon, .dxCombobox.dx-dropdowneditor.dx-state-hover:not(.dx-custom-button-hovered) .dx-dropdowneditor-icon {
    background-color: unset;
}
.dxCombobox.dx-dropdowneditor-button.dx-state-active .dx-dropdowneditor-icon, .dxCombobox.dx-dropdowneditor.dx-dropdowneditor-active .dx-dropdowneditor-icon {
    background-color: unset;
    transform: rotate(180deg);
}
/* input */
.dxCombobox input.dx-texteditor-input {
    height: 34px;
    font-family: notosans-regular;
    font-size: 13px;
}
/* unselect button */
span.dx-clear-button-area {
    width: 30px;
    height: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
}
.dxCombobox span.dx-icon.dx-icon-clear {
    background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -80px -312px;
    background-size: auto;
    background-color: rgba(0, 0, 0, 0.1);
    border-radius: 50%;
    padding: 0;
    width: 16px;
    height: 16px;
    position: relative;
    top: 0;
    margin-top: 0;
    opacity: 0.3;
}
.dxCombobox span.dx-icon.dx-icon-clear:hover {
    opacity: 0.7;
}
.dxCombobox .dx-icon-clear::before  {
    content: "";
}
/* dropdown list */
.dx-selectbox-popup-wrapper .dx-overlay-content.dx-popup-normal.dx-resizable {
    border: none;
    transition: 0s !important;
    padding: 3px 0;
}
.dx-selectbox-popup-wrapper div#dx-0197ce52-6971-19a9-7268-0c8e9a7dad7b {
    padding: 0;
}
.dx-selectbox-popup-wrapper div#dx-59836626-75a5-d123-be24-66a9356cf2d1 {
    padding: 0;
}
.dx-selectbox-popup-wrapper .dx-scrollable-content {
    font-family: notosans-regular !important;
    font-size: 13px !important;
    max-height: 200px !important;
}
.dx-selectbox-popup-wrapper .dx-item.dx-list-item {
    height: 34px;
    transition: 0s !important;
}
.dx-selectbox-popup-wrapper .dx-item.dx-list-item:hover {
    background-color: #e9ebee ;
}
.dx-selectbox-popup-wrapper .dx-item-content.dx-list-item-content {
    line-height: 34px;
    padding: 0 !important;
}
.dx-selectbox-popup-wrapper  .dx-list-item-selected {
    background-color: #2ca01c !important;
    color: #fff !important;
}
.dx-selectbox-popup-wrapper .dx-state-active {
    background-color: #2ca01c !important;
    color: #fff !important;
    height: 34px !important;
    width: 100% !important;
}
.dx-selectbox-popup-wrapper .dx-state-focused {
    background-color: #e9ebee !important;
    color: #000 !important;
    border: none !important;
}
.dx-selectbox-popup-wrapper .dx-item.dx-list-item {
    padding-left: 36px;
    height: 34px !important;
}
.dx-selectbox-popup-wrapper .dx-item.dx-list-item.dx-list-item-selected {
    background-size: 12px !important;
}
.dx-placeholder{
    font-family: notosans-regular;
    font-size: 12px !important;
}
.dx-texteditor.dx-editor-outlined {
    background: #fff;
    border: 1px solid #babec5;
    border-radius: 2px;
}

.red_border{
    border: 1px solid #FF4747 !important;
}
</style>