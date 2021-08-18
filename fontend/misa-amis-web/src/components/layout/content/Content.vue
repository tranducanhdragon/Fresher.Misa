<template>
    <div class="content">
    <!-- Menu con bên phải khi đã thu nhỏ -->
    <!-- <div class="RightMenuExpand" id="RightMenuTaiSanExpandId">
        <span class="RightMenuTitle">Tài sản</span>
        <a href="" class="Rightmenu-text">
            <div class="Rightmenu-icon">
            </div>
            <span>Tài sản 1</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class="Rightmenu-icon">
            </div>
            <span>Tài sản 2</span>
        </a>
    </div>

    <div class="RightMenuExpand" id="RightMenuTaiSanHTExpandId">
        <span class="RightMenuTitle">Tài sản HT-ĐB</span>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Ghi tăng</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Thay đổi thông tin</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Đánh giá lại</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Tính hao mòn</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Kiểm kê</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class='Rightmenu-icon'>
            </div>
            <span>Ghi giảm</span>
        </a>
    </div>
    <div class="RightMenuExpand" id="RightMenuCongCuDungCuExpandId">
        <span class="RightMenuTitle">Công cụ dụng cụ</span>
        <a href="" class="Rightmenu-text">
            <div class="Rightmenu-icon">
            </div>
            <span>Công cụ</span>
        </a>
        <a href="" class="Rightmenu-text">
            <div class="Rightmenu-icon">
            </div>
            <span>Dụng cụ</span>
        </a>
    </div> -->

        <div class="head-content">
            <div class="left-head-content">
                <div class="text-menu">
                <div class="menu-icon" v-on:click="thuNhomenu"></div>
                <div class="menu-text">Công ty sản xuất</div>
                <div class="menu-dd"></div>
                </div>
            </div>
            <div class="right-head-content">
                <div class="text-menu">
                  <div class="alert-icon" title="thông báo"></div>
                  <div class="menu-icon"></div>
                  <div class="menu-text">User name</div>
                  <div class="menu-dd"></div>
                </div>
            </div>
        </div>

        <router-view></router-view>
        
    </div>

</template>
<script>
/* eslint-disable no-debugger */

export default {
    name: "Content",

    methods: {
      /**
       * co dãn menu
       * tdanh 6.2021
       */
      thuNhomenu(){

        //mở menu ra
        if(document.getElementsByClassName('menu')[0].classList.contains('menu_small')){
          document.getElementsByClassName('menu')[0].classList.remove('menu_small');

          document.getElementsByClassName('content')[0].classList.remove('content_big');
          document.getElementsByClassName('left-head-content')[0].children[0].children[0].classList.remove('transform-icon');
        }
        //thu menu lại
        else{
          document.getElementsByClassName('menu')[0].classList.add('menu_small');
          document.getElementsByClassName('content')[0].classList.add('content_big');
          document.getElementsByClassName('left-head-content')[0].children[0].children[0].classList.add('transform-icon');

        }

      },
    },
    
};

</script>
<style scoped>
.content {
  border: 1px solid #bbbbbb;
  width: calc(100% - 191px);
  height: 100vh;
}
.content_big{
  transition: 0s;
  width:calc(100% - 60px);
}

.transform-icon{
  transform: translateX(-50px);
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -312px -32px !important;
  background-size: auto !important;
  background-color: rgb(57, 58, 61) !important;
}

.head-content {
  width: 100%;
  height: 50px;
  border: 1px solid #bbbbbb;
  border-top:0px;
  border-left:0px;
  background-color: #ffffff;
  display: flex;
  position: relative;
}
.left-head-content {
  width: 200px;
  height: 100%;
  background-color: #ffffff;
  line-height: 50px;
  font-weight: bold;
}
  .left-head-content .text-menu {
    width: 100%;
    height: 100%;
    display: flex;
  }
    .left-head-content .text-menu .menu-icon{
      width: 24px;
      height: 24px;
      background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -842px -31px;
      background-size: auto;
      margin:auto;
      margin-left:10px;
    }
    .left-head-content .text-menu .menu-text {
      width: auto;
      height: 100%;
      line-height: 48px;
      font-size: 15px;
      text-align: right;
    }
    .left-head-content .text-menu .menu-dd {
      width: 24px;
      height: 24px;
      background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -460px -404px;
      background-size: auto;
      margin:auto;
      margin-left:10px;
    }
.right-head-content {
  width: 300px;
  height: 100%;
  background-color: #ffffff;
  display: flex;
  position: absolute;
  right:30px;
}
.right-head-content .text-menu {
  width: 300px;
  height: 100%;
  display: flex;
  justify-content: flex-end;
}
  .right-head-content .text-menu .alert-icon {
    width: 30px;
    height: 30px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -253px -28px;
    background-size: auto;
    border-radius: 50%;
    margin: auto;
    margin-right: 0px;
  }
  .right-head-content .text-menu .menu-icon {
    width: 30px;
    height: 30px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -353px -894px;
    background-size: auto;
    border-radius: 50%;
    margin: auto;
    margin-right: 0px;
    margin-left: 16px;
  }
  .right-head-content .text-menu .menu-text {
    width: auto;
    height: 100%;
    line-height: 50px;
    text-align: center;
    font-size: 15px;
    margin:auto;
    margin-right: 8px;
    margin-left: 8px;
  }
  .right-head-content .text-menu .menu-dd {
    width: 24px;
    height: 24px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -460px -404px;
    background-size: auto;
    margin: auto;
    margin-right: 0px;
    margin-left: 0px;
  }
.btnhead-content {
  width: 10%;
  height: 50%;
  background-color: #c6e0eb;
}

</style>