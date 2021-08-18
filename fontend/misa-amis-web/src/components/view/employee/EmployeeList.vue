<template>
    <div class="body-content">
            
        <div class="title-body">
            <div class="left-title-body">
                <div class="DanhSach_area">
                    Nhân viên
                </div>              
            </div>
            <div class="right-title-body">
                <div class="them-area">
                    
                    <div class="text-menu" v-on:click="callEmployeeDetail()">
                        <!-- <div class="menu-icon"></div> -->
                        <div class="menu-text">Thêm nhân viên</div>
                    </div>
                </div>           
            </div>
        </div>
        <div class="inner-content">
            <div class="congcu">
                <div class="timkiem_area">
                    

                </div>   
                <div class="refresh_area">
                    <div class="timkiem">
                      
                      <div class="timkiem-input">
                          <input type="text" class="timkiem-input_content" placeholder="Tìm kiếm theo tên, mã" v-on:keyup="searchEmployee">
                      </div>
                      <div class="congcutimkiemIcon" v-on:click="searchEmployee">
                      </div>
                    </div>

                    <div class="refresh">
                        <div class="refresh_Icon" v-on:click="reloadDataEmployee" title="tải lại"></div>
                    </div>

                    <div class="export">
                        <div class="export_Icon" v-on:click="exportDataEmployee" title="xuất excel"></div>
                    </div>
                </div>            
                
            </div>
            <div class="grid scrollbar">
            <!-- Danh sách nhân viên -->
                <div id="gridEmployee" Url="v1/employees" toolBar="ToolBarEmployee" ItemId="EmployeeId" >
                    <table>
                      <thead>
                          <tr>
                              <th class="align-center first-col thead-first-col">
                                <input type="checkbox" >
                              </th>
                              <th class="align-left">MÃ NHÂN VIÊN</th>
                              <th class="align-left">HỌ TÊN</th>
                              <th class="align-left">GIỚI TÍNH</th>
                              <th class="align-left">SỐ CMND</th>
                              <th class="align-center">NGÀY SINH</th>
                              <th class="align-left">CHỨC VỤ</th>
                              <th class="align-left">TÊN ĐƠN VỊ</th>
                              <th class="align-left">SỐ TÀI KHOẢN</th>
                              <th class="align-left">TÊN NGÂN HÀNG</th>
                              <th class="align-left">CHI NHÁNH TK NGÂN HÀNG</th>
                              <th class="align-center last-col thead-last-col">Chức năng</th>
                          </tr>
                        </thead>
                        <tbody v-if="employeeData && employeeData.length > 0">
                          <tr v-for="(item, index) in employeeData" 
                            :key="index" 
                            v-on:click="selectedRowOneClick($event, item)">

                              <td class="align-center first-col" >
                                <input type="checkbox" >
                              </td>
                              <td class="align-left">{{item.EmployeeCode}}</td>
                              <td class="align-left">{{item.EmployeeName}}</td>
                              <td class="align-left">{{ formatGender(item.Gender)}}</td>
                              <td class="align-left">{{item.IdentityNumber}}</td>
                              <td class="align-center">{{ formatDate(item.DateOfBirth) }}</td>
                              <td class="align-left">{{item.EmployeePosition}}</td>
                              <td class="align-left">{{item.DepartmentName}}</td>
                              <td class="align-left">{{item.BankAccountNumber}}</td>
                              <td class="align-left">{{item.BankName}}</td>
                              <td class="align-left">{{item.BankBranchName}}</td>
                              <td class="align-center last-col" >
                                <div class="function-area">
                                    <button class="icon-edit"
                                      v-on:click="editEmployee(item)" >                                          
                                      Sửa
                                    </button>
                                    <button class="icon-function" 
                                      v-on:click="openFunction($event, item)"
                                      v-on:blur="closeFunction($event)" >
                                    </button>
                                    <!-- dropdown cột chức năng -->
                                    <div class="dropdown-function hide-item" >
                                      <button class="btn-function"
                                        v-on:click="copyEmployee(item)" >
                                        Nhân bản
                                      </button>
                                      <button class="btn-function" 
                                        v-on:click="callAlertDelete()" >
                                        Xóa
                                      </button>
                                      <button class="btn-function" >
                                        Ngừng sử dụng
                                      </button>
                                    </div>
                                </div>
                              </td>
                          </tr>
                        </tbody>
                        <div v-else class="nodata">
                          <img src="https://actappg2.misacdn.net/img/bg_report_nodata.76e50bd8.svg" class="nodata-img">
                          <div class="nodata-text">Không có dữ liệu</div>
                        </div>
                    </table>

                </div>
                <div class="force-overflow"></div>

            </div>

            <Page
                :employee_prop="employeeData" 
                ref="page"
                v-on:loadDataPaging="loadDataPaging"
                v-on:sendPageNum="getPageNum"
                :total="total"
                :filter_val="filter_val" >
            </Page>
            
            <Loading 
                v-show="isLoading" 
                ref="loading">
            </Loading>
            <EmployeeDetail 
                v-if="isGenComponent" 
                ref="employeeDetail" 
                v-on:closeForm="closeFormDetail" 
                v-on:reloadData="reloadDataEmployee"
                v-on:showToastMessage="showToastMessage"
                v-on:openForm="callEmployeeDetail"
                :employeeId="employeeId"
                :employeeBeforeEdit="employeeEdit"
                :formMode="formMode"
                :department_dropdown="department_dropdown">
            </EmployeeDetail>
            <Alert
                v-if="isAlert"
                :title="alertTitle"
                :content="alertContent"
                :state="alertState"
                :employeeId="employeeId"
                v-on:closeForm="closeAlert"
                v-on:confirm="deleteEmployee">             
            </Alert>

            <ToastMessage
              :option="option_toast"
              v-if="isToast" >

            </ToastMessage>
        </div>
    </div>
</template>

<script>

//import common function
import Enum from '../../../common/enumeration.js'
import Resource from '../../../common/resource.js'
import CommonFunc from '../../../common/common.js'
// import Contant from '../../../common/contant.js'

//import component
import EmployeeDetail from '../employee/EmployeeDetail.vue';
import Loading from '../../common/Loading.vue';
import Alert from '../../common/Alert.vue';
import Page from '../../common/Page.vue';
import ToastMessage from '../../common/ToastMessage.vue';

//import baseApi
import EmployeesAPI from '../../../api/components/employees/EmployeesAPI.js';
import DepartmentsAPI from '../../../api/components/departments/DepartmentsAPI.js'

//import fake data employee
// import employeeFakeData from '../../model/Data.js';

//import thư viện

/* eslint-disable no-debugger */

export default {
    
    components:{
      EmployeeDetail,
      Loading,
      Alert,
      Page,
      ToastMessage,
    },
    created(){

      this.reloadDataEmployee();

      //lấy dữ liệu cho combobox Đơn vị
      this.getDepartmentDataToCombobox();
    },
    mounted(){
      this.$refs.page.pagingData(document.getElementsByClassName('page-item')[0]);

    },

    data() {
      return {
                    
        isGenComponent:false,  //Biến isGenComponent dùng cho v-if( vì v-if khởi tạo lại component EmployeeDetail)
        isLoading:false,
        isAlert:false,
        isEditOrDelete:false,
        employeeData:{},
        employeeId:null,
        formMode:0,
        employeeEdit:{},
        employeeDelete:{},
        pageSize:10,
        pageNum:'',
        total:0,
        filter_val:'',


        //dữ liệu cho alert
        alertTitle:'',
        alertContent:'',
        alertState:'',

        //option cho toast message
        isToast:false,
        option_toast:{
          Content:'',
          state:'',
        },

        //dữ liệu cho combobox
        department_dropdown_title:'Đơn vị',
        department_dropdown:[],


      }
    },
    methods:{
      /**
       * sự kiện mở form EmployeeDetail
       * tdanh 6.2021
       */
        callEmployeeDetail() {
            this.isGenComponent = true;
            this.isLoading = true;
            this.formMode = Enum.FormMode.Add;
        },
        /**
         * mở form thông báo xác nhận, gọi api để lấy employeeCode
         * tdanh 6.2021
         */
        async callAlertDelete(){
            //Gọi api để lấy thông tin employee cần xóa
            await EmployeesAPI.getById(this.employeeId).then((response) => {
                if(response.data){
                    this.employeeDelete = response.data;

                }

            }).catch(e => {
                console.log(e);
                this.showToastMessage( Resource.ToastMessage.Fail, Enum.StateToast.Error);
            });

            this.alertTitle = "Xóa bản ghi"
            this.alertContent = 'Bạn có thực sự muốn xóa Nhân viên<'+this.employeeDelete.EmployeeCode+'> không?';
            this.alertState = Enum.StateAlert.Error;

            this.isAlert = true;
            this.isLoading = true;
        },

        /**
         * đóng form detail
         * tdanh 6.2021
         */
        closeFormDetail() {
            this.isGenComponent = false;
            this.isLoading = false;

        },
        /**
         * đóng form loading
         * tdanh 6.2021
         */
        closeLoading(){
            this.isLoading = false;
        },
        /**
         * đóng form xác nhận
         * tdanh 6.2021
         */
        closeAlert(){
              this.isAlert = false;
              this.isLoading = false;
        },
        /**
         * reload lại danh sách nhân viên trong table
         * tdanh 6.2021
         */
        reloadDataEmployee(){
            
            
            this.getDataFirstPage();

            //arrow function ko bind this từ global( window) mà lấy this hiện tại, như vậy this.isLoading mới được gán bằng false
            this.isLoading = true;
            setTimeout(() => {
              this.isLoading = false;
            }, 1500);

            

            //bỏ class selectedRow cho tất cả row trước đó
            document.querySelectorAll('tr').forEach(e => e.classList.remove('selectedRow'));

            
        },
        /**
         * Nhận pageNum từ dưới component Page emit lên
         * tdanh 7.21
         */
        getPageNum(val){
          this.pageNum = val;
        },
        /**
         * Xuất dữ liệu ra file excel
         * tdanh 7.21
         */
        exportDataEmployee(){
          // if(!this.pageNum){
          //   this.pageNum = '1';
          // }
          // this.filter_val = document.getElementsByClassName('timkiem-input_content')[0].value;

          EmployeesAPI.exportData().then((response) => {
            if(response){
              const blob = new Blob([response.data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
              const link = document.createElement('a');
              link.href = URL.createObjectURL(blob);
              link.download = 'Danh sách nhân viên';
              link.click();
              URL.revokeObjectURL(link.href);
            }
          }).catch(e => {
            console.log(e);
            this.showToastMessage(Resource.ToastMessage.Fail, Enum.StateToast.Error)
          })
        },

        /**
         * load lại data trả về từ component con page
         */
        loadDataPaging(data){
          if(data){
              //Lấy data từ component paging
              this.employeeData = data;

              //Lấy data fake cứng
              // this.employeeData = employeeFakeData;
          }

        },


        /**
         * Hàm get dữ liệu phòng ban vào dropdown của combobox
         * tdanh 7.21
         */
        getDepartmentDataToCombobox() {
            DepartmentsAPI.getAll().then((response) => {
                
                this.department_dropdown = [...response.data].map(item =>{
                    return {
                        data_text : item.DepartmentName,
                        id : item.DepartmentId
                    }
                });


            })

        },


        /**
         * tìm kiếm employee theo tên
         * tdanh 6.2021
         */
        async searchEmployee(e){

            this.filter_val = document.getElementsByClassName('timkiem-input_content')[0].value;

            //khi bấm enter thì gọi api filter tìm kiếm theo tên
            if(e.keyCode === 13 || e.type === 'click'){
                await EmployeesAPI.filter(this.filter_val, this.pageSize, 1).then((response) => {
                
                  if(response){
                    this.employeeData = response.data.Data.data;
                    this.total = response.data.Data.totalRecord;

                    this.showToastMessage(Resource.ToastMessage.Success, Enum.StateToast.Success);
                  }                
                }).catch((error) => {
                    console.log(error);
                    this.showToastMessage(Resource.ToastMessage.Fail, Enum.StateToast.Error)
                });
            }
            
        },
        /**
         * lấy toàn bộ dữ liệu employee lên table
         * tdanh 6.2021
         */
        async getDataFirstPage(){
            //get data from api
            await EmployeesAPI.paging(1, this.pageSize).then((response) => {
              this.employeeData = response.data.Data.data;

              this.total = response.data.Data.totalRecord;
              // this.showToastMessage('Xác nhận hành động thành công', Enum.StateToast.Success);

            }).catch(e => {
                console.log(e);
                this.showToastMessage(Resource.ToastMessage.Fail, Enum.StateToast.Error)
            });

        },


        /**
         * mở form sửa employee
         * tdanh 7.2021
         */
        editEmployee(employee){
            //Lấy employeeId
            this.employeeId = employee.EmployeeId;

            //truyền giá trị cho employeeEdit xuống formDetail
            this.employeeEdit = JSON.parse(JSON.stringify(employee));

            this.formMode = Enum.FormMode.Edit;
            this.isGenComponent = true;
            this.isLoading = true;
        },

        /**
         * mở form sửa employee
         * tdanh 7.2021
         */
        copyEmployee(employee){
            //Lấy employeeId
            this.employeeId = employee.EmployeeId;

            //truyền giá trị cho employeeEdit xuống formDetail
            this.employeeEdit = JSON.parse(JSON.stringify(employee));

            this.formMode = Enum.FormMode.Copy;
            this.isGenComponent = true;
            this.isLoading = true;
        },
        /**
         * mở rộng function
         * tdanh 7.21
         */
        openFunction($event, item){
            this.employeeId = item.EmployeeId;

            $event.target.parentElement.getElementsByClassName('dropdown-function')[0].classList.remove('hide-item');

            //tăng z-index của td này lên
            $event.target.parentElement.parentElement.parentElement.getElementsByTagName('td')[11].classList.add('z-index-2');

        },
        /**
         * đóng dropdown function
         * tdanh 7.21
         */
        closeFunction($event){
          //set timeout để blur chạy sau các sự kiện click trong dropdown function
            setTimeout(function(){
              $event.target.parentElement.getElementsByClassName('dropdown-function')[0].classList.add('hide-item');
              $event.target.parentElement.parentElement.parentElement.getElementsByTagName('td')[11].classList.remove('z-index-2');
            }, 100);

        },

        /**
         * xóa nhân viên theo id
         * tdanh 6.2021
         */
        async deleteEmployee(){

            await EmployeesAPI.delete(this.employeeId).then((response) => {
                console.log(response);
                this.showToastMessage(Resource.ToastMessage.Success, Enum.StateToast.Success);
            }).catch(e => {
              console.log(e);
              this.showToastMessage(Resource.ToastMessage.Fail, Enum.StateToast.Error)
            })
            //reload data
            this.reloadDataEmployee();

            //Close form
            this.closeAlert();
        },

        /**
         * sự kiện thêm class để hiển thị chọn một hàng trong table
         * tdanh 6.2021
         */
        selectedRowOneClick($event, item){
          //bỏ class selectedRow cho tất cả row trước đó
          document.querySelectorAll('tr').forEach(e => e.classList.remove('selectedRow'));

          //thêm class selectedRow cho row hiện tại
          $event.currentTarget.classList.add('selectedRow');


          this.employeeId = item.EmployeeId;
          
            
        },

        /**
         * format data gender in db
         * tdanh 7.21 
         */
        formatGender(gender){
          return CommonFunc.getDataFormatted(gender, 'Enum', 'Gender');
        },
        formatDate(date){
          return CommonFunc.getDataFormatted(date, 'Date', '');
        },

        /**
         * hiển thị toastMessage thông báo lỗi
         * tdanh 6.21
         */
        showToastMessage(content, state){
            this.isToast = true;
            this.option_toast.Content = content;
            this.option_toast.state = state;
            setTimeout(() =>{
              this.isToast = false;
            }, 3000);
        },

        
    }
}
</script>

<style scoped>

.inner-content {
  width: calc(100% - 0px);
  height: calc(100% - 50px);
  background-color: #ffffff;
  margin-top: 0px;
  margin-left: 0px;
  padding: 0 30px 0 16px;
}
.body-content {
  width: 100%;
  height: calc(100% - 52px);
  border: 0px solid #bbbbbb;
  background-color: #f4f5f6;
  padding:16px 30px 0 16px;
}

.content .body-content .congcu {
  background-color: #ffffff;
  height: 60px;
  width:100%;
}
    .content .body-content .congcu button {
      background-color: #bdd7e3;
    }
.content .body-content .grid {
  width: calc(100% - 0px);
  height: calc(100% - 110px);
  background-color: #ffffff;
  border: 0px solid #bbbbbb;
  margin-top: 0px;
  margin-left: 0px;
  overflow: auto;
}


table {
  width: 100%;
  border: 0px solid #bbbbbb;
  border-spacing: 0px;
  font-size: 13px;
}
  table td {
    height: 40px;
    margin: 0px;
    text-align: center;
    border-bottom: 1px solid #c7c7c7;
    border-right: 1px dotted #c7c7c7;
    padding: 5px 10px;
  }
thead td,th {
  background-color: #eeecec;
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px solid #c7c7c7;
  position: sticky;
  top: 0px;
  height:34px;
  padding-right:10px;
  padding-left: 8px;
}
table tbody tr {
  height: 48px !important;
}
table th, td{
  white-space: nowrap;
}
table .nodata{
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    margin: auto;
    width: 130px;
    height: 80px;
}
  table .nodata .nodata-text{
      text-align: center;
  }

.thead-first-col{
  z-index: 3 !important;
  background-color: #eeecec !important;
}
.thead-last-col{
  z-index: 3 !important;
  background-color: #eeecec !important;
}

.first-col {
  left: 0;
  position: sticky;
  z-index: 1;
  background-color: #fff;
}
.last-col {
  right: 0;
  position: sticky;
  z-index: 1;
  background-color: #fff;
}

.function-area{
  display: flex;
  position: relative;
  justify-content: center;
}
  .function-area .icon-function{
    width: 24px;
    height: 24px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -893px -356px;
    background-size: auto;
    margin: 8px 10px 8px 10px;
  }
  .function-area .icon-function:focus{
    border: 1px solid #0075c0;
  }
  .function-area .icon-edit{
    margin: 8px 0px 8px 10px;
    color: #0075c0;
  }
  .function-area .dropdown-function{
    width: 120px;
    height: 92px;
    background-color: #ffffff;
    border:1px solid #000000;
    text-align: left;
    position: absolute;
    top: 35px;
    right:10px;
  }
    .function-area .dropdown-function .btn-function{
      width:100%;
      height:30px;
      margin: 0;
      padding: 5px 10px 5px 10px;
      display: block;
      text-align: left;
    }
    .function-area .dropdown-function .btn-function:hover{
      background-color: #dadada;
      color: #2ca01c;
    }

.congcu {
  width: calc(100% - 10px);
  height: 65px;
  display: flex;
}

.timkiem_area{
  flex:1;
  display: flex;
}
.refresh_area{
  flex:1;
  position: relative;
  display: flex;
  padding:10px;
}
.timkiem {
  width: 240px;
  height: 32px;
  line-height: 32px;
  border: 1px solid #bbbbbb;
  border-radius: 2px;
  display: flex;
  position:absolute;
  right:113px;
}

.input_dropdown{
  width: 25%;
  height: 100%;
  line-height: 50px;
  border: 0px;
  margin-left:10px;
  margin-top: 5px;
}
.timkiem .congcutimkiemIcon {
  width: 20px;
  height: 20px;
  background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -425px -33px;
  background-size: auto;
  margin: auto;
}

.timkiem .timkiem-input {
  width: calc(100% - 40px);
  height: 100%;
  line-height: 30px;
  opacity: 50%;
  padding-left: 10px;
  font-size:12px;
}
.timkiem .timkiem-input > input {
  border: none;
  width: 100%;
  height: 100%;
}
.timkiem .timkiem-input > input:focus {
  outline: none;
}

input::placeholder{
    font-size: 11px !important;
    color: #bbbbbb;
}
.title-body {
  width:100%;
  height: 50px;
  line-height: 50px;
  display: flex;
}
.left-title-body {
  width: 200px;
  height: 50px;
  font-size: 20px;
  font-weight: bold;
  flex:1;
}
  .left-title-body .DanhSach_area{
    font-size: 22px;
    margin-left: 0px;
  }
  .left-title-body .btn {
    width: 100%;
    height: 40px;
    border-radius: 4px;
    color: #ffffff;
    background-color: #2ca01c;
    line-height: 5%;
    font-size: 15px;
    font-weight: normal;
    padding-left: 24px;
    padding-right: 24px;
    margin-right: 5px;
    font-family: notosans-regular;
  }
  .left-title-body .btn:hover {
    background-color: #33b322;
  }
  .left-title-body .btn:focus {
    background-color: #2cb61a;
  }

.right-title-body {
  margin-left: 0%;
  width: 200px;
  flex: 1;
}
  .right-title-body .them-area{
      width: 100%;
      height: 100%;
      display: flex;
      position: relative;
  }
  .right-title-body .text-menu {
    height: 40px;
    background-color: #2ca01c;
    border: 0px solid #bbbbbb;
    border-radius: 5px;
    display: flex;
    position: absolute;
    right: 0;
    font-size: 13px;
    padding-left: 16px;
    padding-right: 16px;
  }
  .right-title-body .text-menu:hover{
    background-color: #33b322;
    cursor: pointer;
  }
  .right-title-body .text-menu:focus{
    background-color: #01b075;
    cursor: pointer;
  }
    .right-title-body .text-menu .menu-icon {
      width: 16px;
      height: 100%;
      background-image: url("../../../assets/Icon/Sprites.64af8f61.svg");
      background-repeat: no-repeat;
      background-position: center;
      margin-right:8px;
    }
.right-title-body .text-menu .menu-text {
  width: auto;
  height: 100%;
  line-height: 40px;
  color: #ffffff;
  font-family: notosans-regular;
}
.right-title-body .text-menuXoa{
  height: 40px;
  background-color: #FF4747 ;
  border: 0px solid #bbbbbb;
  border-radius: 5px;
  display: flex;
  position: absolute;
  right:150px;
  font-size: 13px;
  padding-left: 24px;
  padding-right: 24px;
}
.right-title-body .text-menuXoa .menu-text{
  width: auto;
  height: 100%;
  line-height: 40px;
  color: #ffffff;
  font-family: notosans-regular;
}
.right-title-body .text-menuXoa:hover{
  background-color: #ff5f5f;
  cursor: pointer;
}
.right-title-body .text-menuSua{
  height: 40px;
  background-color: #FF6900;
  border: 0px solid #bbbbbb;
  border-radius: 5px;
  display: flex;
  position: absolute;
  right:283px;
  font-size: 13px;
  padding-left: 24px;
  padding-right: 24px;
}
.right-title-body .text-menuSua .menu-text{
  width: auto;
  height: 100%;
  line-height: 40px;
  color: #ffffff;
  font-family: notosans-regular;
}
.right-title-body .text-menuSua:hover{
  background-color: #f38338;
  cursor: pointer;
}
.inner-content .congcu .timkiemIcon {
  width: 40%;
  height: 100%;
  margin-left: 50%;
  display: flex;
}
.congcu .timkiemIcon .main-content__menu-icon {
  width: 100%;
  height: 100%;
  text-align: center;
  line-height: 50px;
}
.congcu .refresh{
  width:50px;
  height:32px;
  position: absolute;
  right:50px;
  display: flex;
}
  .refresh .refresh_Icon{
    width: 24px;
    height: 24px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -425px -201px;
    background-size: auto;
    border: 0px solid #bbbbbb;
    border-radius: 4px;
    margin: auto;
  }
  .refresh .refresh_Icon:hover{
    background-color: #E9EBEE;
  }

.congcu .export{
  width:50px;
  height:32px;
  position: absolute;
  right:0px;
  display: flex;
}
  .export .export_Icon{
    width: 24px;
    height: 24px;
    background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -1265px -90px;
    background-size: auto;
    border: 0px solid #bbbbbb;
    border-radius: 4px;
    margin: auto;
  }
  .export .export_Icon:hover{
    background-color: #E9EBEE;
  }

.align-right {
  text-align: right;
}
.align-left {
  text-align: left;
}
.align-center {
  text-align: center;
}
.hide-item {
  display: none;
}
.selectedRow {
  background: #f8f8f8;
}
.z-index-2{
  z-index: 2;
}

::placeholder {
  color: #bbbbbb;
  font-size: 12px;
  font-family: notosans-regular;
  opacity: 1; /* Firefox */
}
</style>