<template>
    <div class="confirm-confirm">
        <div class="form-confirm">
            <div class="form-header" >
                <div class="form-header-icon" @click="closeForm"></div>
            </div>
            <div class="form-content">
                <div class="content-content">
                    <!-- <div class="content-header"><span>{{clone_title}}</span></div> -->
                    <div class="content-body">
                        <div class="icon-area">
                            <div :class="icon_class_name" ></div>
                        </div>

                        <div class="text-confirm">
                            {{clone_content}}
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-footer">
                <div :class="btn_cancel_class" @click="closeForm">Hủy</div>
                <div :class="btn_no_class" @click="confirmNo" >Không</div>
                <div :class="confirm_class" @click="confirm">Có</div>
                <div :class="btn_dong_class" @click="closeForm">Đóng</div>
            </div>
        </div>
    </div>
</template>

<script>
import Enumeration from '../../common/enumeration';
/* eslint-disable no-debugger */
export default {
    props:{
        title:String,
        content:String,
        state:String,
    },
    data(){
        return{
            clone_title:'',
            clone_content:'',
            clone_state:'',
            icon_class_name:'',
            confirm_class:'',
            btn_no_class:'',
            btn_cancel_class:'',
            btn_dong_class:'',
        }
    },
    created(){
        //trạng thái của alert
        this.clone_state = JSON.parse(JSON.stringify(this.state));

        this.clone_title = JSON.parse(JSON.stringify(this.title));
        this.clone_content = JSON.parse(JSON.stringify(this.content));
        this.clone_state = JSON.parse(JSON.stringify(this.state));

        if(this.clone_state === Enumeration.StateAlert.Error){        //trạng thái cảnh báo xóa bản ghi
            this.icon_class_name = 'icon-error';
            this.confirm_class = 'btn-delete-confirm';
            this.btn_no_class = 'display-none';
            this.btn_cancel_class = 'btn-cancel';
            this.btn_dong_class = 'display-none';
        }
        else if(this.clone_state === Enumeration.StateAlert.Validate){        //trạng thái hiển thị khi validate
            this.icon_class_name = 'icon-validate';
            this.confirm_class = 'display-none';
            this.btn_no_class = 'display-none';
            this.btn_cancel_class = 'display-none';
            this.btn_dong_class = 'btn-dong';
        }
        else if(this.clone_state === Enumeration.StateAlert.Warning){        //trạng thái cảnh báo khi đóng form
            this.icon_class_name = 'icon-warning';
            this.confirm_class = 'btn-warning-confirm';
            this.btn_no_class = 'btn-no';
            this.btn_cancel_class = 'btn-cancel';
            this.btn_dong_class = 'display-none';
        }
    },
    methods: {
        closeForm() {
            this.$emit("closeForm", this.clone_state);
        },
        confirm() {
            this.$emit("confirm", this.clone_state);
        },
        confirmNo(){
            this.$emit('confirmNo', this.clone_state);
        },
    }
}
</script>

<style scoped>
.confirm-confirm {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  z-index: 5;
  /* display: none; */
}
.form-confirm {
    position: absolute;
    width: 500px;
    height: 200px;
    background-color: #fff;
    box-shadow: #ccc 1px 0px 6px 3px;
    border-radius: 4px;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    margin: auto;
}
    .form-confirm .form-header {
        width: 100%;
        height: 24px;
    }
        .form-confirm .form-header .form-header-icon{
            width: 24px;
            height: 24px;
            background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -147px -147px;
            background-size: auto;
            position: absolute;
            right:0px;
            margin-top: 10px;
        }
        .form-confirm .form-header .form-header-icon:hover{
            cursor: pointer;
        }

    .form-confirm .content-body {
        position: absolute;
        width: 100%;
        top: 20px;
        bottom: 24px;
        display: flex;
    }
    .form-confirm .form-content {
        width: 100%;
        height: calc(100% - 84px);
        position: relative;
    }
    .form-confirm .form-footer {
        width: 100%;
        height: 60px;
        background-color: #ffffff;
        display: flex;
        align-items: center;
    }
.content-content {
    position: absolute;
    top: 0px;
    left: 24px;
    right: 24px;
    bottom: 0px;
    border-bottom: 1px solid #bbbbbb;
}
    .content-content .content-header {
        width: 100%;
        height: 24px;
    }
    .content-content .content-header span {
        font-size: 15px;
        font-weight: bold;
    }
.icon-area{
    display: flex;
    align-items: center;
}

    .icon-area .icon-warning {
        width: 48px;
        height: 48px;
        border-radius: 50%;
        background-color: rgb(235, 235, 235);
        background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -826px -456px;
        background-size: auto;
    }
    .icon-area .icon-error {
        width: 48px;
        height: 48px;
        border-radius: 50%;
        background-color: rgb(235, 235, 235);
        background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -592px -458px;
        background-size: auto;
    }
    .icon-area .icon-validate {
        width: 48px;
        height: 48px;
        border-radius: 50%;
        background-color: rgb(235, 235, 235);
        background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -746px -456px;
        background-size: auto;
    }
.text-confirm {
    position: absolute;
    left: 65px;
    right: 0px;
    height: 100%;
    font-family: notosans-regular;
    font-size: 13px;
    display: flex;
    align-items: center;
}
.btn-delete-confirm {
    height: 40px;
    background-color: #2ca01c;
    border: 1px solid #8d9096;
    border-radius: 2px;
    color: #fff;
    text-align: center;
    line-height: 40px;
    padding-left: 24px;
    padding-right: 24px;
    font-family: notosans-regular;
    font-size: 13px;
    position: absolute;
    right:30px;
    font-weight: 600;
}
.btn-delete-confirm:hover {
    background-color: #33b322;
    cursor: pointer;
}
.btn-warning-confirm {
    height: 40px;
    background-color: #2ca01c;
    border:1px solid #8d9096;
    border-radius: 2px;
    color: #fff;
    text-align: center;
    line-height: 40px;
    padding-left: 24px;
    padding-right: 24px;
    font-family: notosans-regular;
    font-size: 13px;
    position: absolute;
    right:30px;
    font-weight: 600;
}
.btn-warning-confirm:hover {
    background-color: #33b322;
    cursor: pointer;
}
.btn-cancel {
    height: 40px;
    width: 80px;
    background-color: #f4f4f4;
    border: 1px solid #8d9096;
    border-radius: 2px;
    color: #000;
    text-align: center;
    line-height: 40px;
    margin-right: 10px;
    padding-right:0px 24px 0px 24px;
    font-family: notosans-regular;
    font-size: 13px;
    position: absolute;
    left: 30px;
    font-weight: 600;
}
.btn-cancel:hover {
    background-color: #e5e5e5;
    cursor: pointer;
}
.btn-no{
    height: 40px;
    width: 80px;
    background-color: #f4f4f4;
    border: 1px solid #8d9096;
    border-radius: 2px;
    color: #000;
    text-align: center;
    line-height: 40px;
    margin-right: 10px;
    padding-right:0px 24px 0px 24px;
    font-family: notosans-regular;
    font-size: 13px;
    position: absolute;
    right: 100px;
    font-weight: 600;
}
.btn-no:hover{
    background-color: #e5e5e5;
    cursor: pointer;
}
.btn-dong{
    height: 40px;
    width: 80px;
    background-color: #2ca01c;
    border: 1px solid #8d9096;
    border-radius: 2px;
    color: #ffff;
    text-align: center;
    line-height: 40px;
    margin-right: 10px;
    padding-right: 0px 24px 0px 24px;
    font-family: notosans-regular;
    font-size: 13px;
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    font-weight: 600;
}
.btn-dong:hover {
    background-color: #33b322;
    cursor: pointer;
}

.display-none{
    display: none;
}
</style>