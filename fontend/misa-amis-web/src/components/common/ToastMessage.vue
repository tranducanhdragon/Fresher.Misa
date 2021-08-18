<template>
    <div class="toast">
        <div :class="class_name" ></div>
        <div class="content-toast"> {{ clone_option.Content }}</div>
        <div class="clear-toast" ></div>
    </div>
</template>

<script>
import Enumeration from '../../common/enumeration';
/* eslint-disable no-debugger */

export default {
    props: {
        option: {
            Content:String,
            icon_url:String,
            state:String,
        },
    },
    data(){
        return {
            clone_option:{},
            class_name:'',
        } 
    },
    created(){
        this.clone_option = JSON.parse(JSON.stringify(this.option));
        if(this.clone_option.state === Enumeration.StateToast.Success){
            this.class_name = 'icon-success-toast';
        }
        else if(this.clone_option.state === Enumeration.StateToast.Error){
            this.class_name = 'icon-error-toast';
        }
    },
    watch:{
        option:{
            deep:true,
            handler(val){
                debugger;
                console.log(val);
                this.clone_option = JSON.parse(JSON.stringify(val));

            }
        },
        
    },
}
</script>

<style scoped>
.toast {
    position: absolute;
    bottom: 60px;
    right: 3px;
    height: 48px;
    width: auto;
    border-radius: 4px;
    box-shadow: 0px 3px 6px #000000;
    opacity: 1;
    display: flex;
    align-items: center;
    padding-left: 16px;
    padding-right: 16px;
    background-color: #ffffff;
    z-index: 4;
}
.icon-success-toast {
    width: 24px;
    height: 24px;
    margin-right: 8px;
    border-radius: 50px;
    background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -482px -146px;
    background-size: auto;
}
.icon-error-toast {
    width: 24px;
    height: 24px;
    margin-right: 8px;
    border-radius: 50px;
    background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -538px -146px;
    background-size: auto;
}
.content-toast {
    height: 100%;
    width: auto;
    line-height: 48px;
    color: black;
    font-size: 13px;
}
.clear-toast {
    width: 24px;
    height: 24px;
    margin-left: 8px;
    background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -144px -145px;
    background-size: auto;
}

</style>