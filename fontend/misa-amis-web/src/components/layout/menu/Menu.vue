<template>
  <div class="menu">
    <div class="head-menu">
      <div class="menu-icon" ></div>
      <div class="menutext"></div>
    </div>
    <div class="content-menu">
      <div class="textmenu" 
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
            <div class="tongquan-icon"></div>
        </div>

        <div class="menutext">Tổng quan</div>
      </div>
      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="tienmat-icon"></div>
        </div>
        <div class="menutext">Tiền mặt</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="tiengui-icon"></div>
        </div>
        <div class="menutext">Tiền gửi</div>
        <div class="menuDd"></div>
      </div>
      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="muahang-icon"></div>
        </div>
        <div class="menutext">Mua hàng</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu" 
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="banhang-icon"></div>
        </div>
        <div class="menutext">Bán hàng</div>
        <div class="menuDd"></div>
      </div>
      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="quanlyhoadon-icon"></div>
        </div>
        <div class="menutext">Quản lý hóa đơn</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="kho-icon"></div>
        </div>
        <div class="menutext">Kho</div>
        <div class="menuDd"></div>
      </div>
      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >
        <div class="menu-icon">
          <div class="congcudungcu-icon"></div>
        </div>
        <div class="menutext">Công cụ dụng cụ</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="taisancodinh-icon"></div>
        </div>
        <div class="menutext">Tài sản cố định</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="thue-icon"></div>
        </div>
        <div class="menutext">Thuế</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu" 
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="giathanh-icon"></div>
        </div>
        <div class="menutext">Giá thành</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="tonghop-icon"></div>
        </div>
        <div class="menutext">Tổng hợp</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu"
        v-on:click="changeWhenFocus($event)">

        <div class="menu-icon">
          <div class="ngansach-icon"></div>
        </div>
        <div class="menutext">Ngân sách</div>
        <div class="menuDd"></div>
      </div>
      <!-- <div class="textmenu" >
        <div class="menu-icon baocao-icon"></div>
        <div class="menutext">Báo cáo</div>
        <div class="menuDd"></div>
      </div>

      <div class="textmenu">
        <div class="menu-icon phantichtaichinh-icon"></div>
        <div class="menutext">Phân tích tài chính</div>
        <div class="menuDd"></div>
      </div> -->
      
      <router-link to="/employeeList" class="textmenu" 
        v-on:click.native="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="nhanvien-icon"></div>
        </div>
        <div class="menutext">Nhân viên</div>
      </router-link>
      <div class="textmenu" 
        v-on:click="changeWhenFocus($event)" >

        <div class="menu-icon">
          <div class="thietlap-icon"></div>
        </div>
        <div class="menutext">Thiết lập</div>
      </div>
    </div>
  </div>
</template>
<script>
/* eslint-disable no-debugger */

export default {
    name: "Menu",

    methods: {
      changeWhenFocus($event){
        if(document.getElementsByClassName('textmenu-active').length > 0){
          document.getElementsByClassName('textmenu-active')[0].classList.remove('textmenu-active');
        }

        $event.currentTarget.classList.add('textmenu-active');
      },

      // changeWhenBlur($event){

      //   $event.currentTarget.classList.remove('textmenu-active');
      // },

  },
};
</script>

<style scoped>


.menu {
  float: left;
  width: 190px;
  height: 100vh;
}
.menu_small{
  transition: 0s;
  width:60px;
}

.menu .head-menu .menu-icon:hover {
  background-color: #bbbbbb;
}
.right-menu-expand {
  width: 200px;
  height: 300px;
  background-color: #ffffff;
  position: absolute;
  top: 52px;
  left: 0px;
  border: 1px solid #000000;
  z-index: 1;
  display: flex;
  flex-direction: column;
}
.right-menu-expand .right-menu-title {
  text-align: center;
  margin-bottom: 10px;
  border: 1px solid #000000;
}
.right-menu-expand .right-menu-text {
  text-align: center;
  margin-bottom: 20px;
  display: flex;
}
.right-menu-expand .right-menu-text .right-menu-icon {
  width: 10px;
  height: 100%;
  margin-left: 10px;
  margin-right: 40px;
  background-image: url("../../../assets/Icon/Sprites.64af8f61.svg");
  background-repeat: no-repeat;
  background-position: -118px -330px;
}

.content {
  border: 0px solid #000000;
  width: calc(100% - 253px);
  height: 100%;
  margin-left: 250px;
}

.head-menu {
  width: auto;
  height: 48px;
  border: 0px solid #bbbbbb;
  border-right: 1px;
  background-color: rgb(57, 58, 61);
  margin-top: 0px;
  color: #ffffff;
  display: flex;
}
.head-menu .menu-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -424px -88px;
  margin: auto;
  margin-left: 35px;
}
.head-menu .menu-icon:hover {
  background-color: #2fbe8e;
}
.head-menu .menutext {
  width:calc(100% - 59px);
  height: 30px;
  background-image: url('https://actappg2.misacdn.net/img/Logo_Module_TiengViet_White.66947422.svg');
  background-repeat: no-repeat;
  background-size: contain;
  margin: auto;
  margin-left: 16px;
}
.content-menu {
  width: auto;
  height: calc(100% - 48px);
  border: 0px solid #bbbbbb;
  border-right: 0px;
  background-color: rgb(57, 58, 61);
  padding-top: 14px;
}
.content-menu .textmenu .menu-icon {
    width: 24px;
    height: 44px;
    margin-left: 8px;
    margin-right: 8px;
    display: flex;
    justify-items: center;
    align-items: center;
}
.menu .content-menu .textmenu {
  width: 190px;
  height: 44px;
  background-color: rgb(57, 58, 61);
  color: #ffffff;
  border-left: 20px solid rgb(57, 58, 61);
  border-radius: 0px;
  text-align: center;
  line-height: 44px;
  display: flex;
  text-decoration: none;
}
.menu .content-menu .textmenu:hover {
  background-color: #505050;
  border-color: #505050;
  color: #ffffff;
}
.menu .content-menu .textmenu .menutext {
  width: 110px;
  height: 100%;
  text-align: left;
  line-height: 44px;
  font-size: 13px;
}
.tongquan-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -30px -1629px;
  background-size: auto;
}
.tienmat-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -73px -1628px;
  background-size: auto;
}
.tiengui-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -117px -1630px;
  background-size: auto;
}

.muahang-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -161px -1629px;
  background-size: auto;
}
.banhang-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -205px -1629px;
  background-size: auto;
}

.quanlyhoadon-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -249px -1629px;
  background-size: auto;
}
.kho-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -291px -1629px;
  background-size: auto;
}
.congcudungcu-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -336px -1630px;
  background-size: auto;
}
.taisancodinh-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -379px -1630px;
  background-size: auto;
}
.thue-icon {
  width: 24px;
  height: 24px;
	background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -423px -1631px;
  background-size: auto;
}
.giathanh-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -468px -1630px;
  background-size: auto;
}
.tonghop-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -511px -1629px;
  background-size: auto;
}
.ngansach-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -548px -1631px;
  background-size: auto;
}
.nhanvien-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -590px -1629px;
  background-size: auto;
}
.thietlap-icon {
  width: 24px;
  height: 24px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -633px -1629px;
  background-size: auto;
}

.menutext {
  width: 80%;
  height: 40px;
  line-height: 30px;
  border-radius: 5px;
  font-size: 15px;
  font-style: normal;
}

.menu .content-menu .textmenu-active {
    width: 190px;
    height: 44px;
    background-color: rgb(83, 85, 90);
    color: #ffffff;
    text-align: center;
    display: flex;
    text-decoration: none;
    border-left:20px solid #2ca01c !important;
}
</style>