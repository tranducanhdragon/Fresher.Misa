<template>

    <div class="dialog" id="FormDetailEmployee" Url="v1/employees" >
        <div class="dialog-head">
            <div class="left-head-dialog">Thông tin nhân viên</div>
            <div class="right-head-dialog">
                <div class="role-area">
                    <input type="checkbox"> Là khách hàng
                    <input type="checkbox"> Là nhà cung cấp
                </div>
                <div class="icon-question"></div>
                <div class="icon-close" v-on:click="closeForm()"></div>    
            </div>        
        </div>
        <div class="dialog-body">
            
            <div class="dialog-body-conten scrollbar">
                <div class="inforA">

                    <div class="inforA1">
                        <div class="row-item d-flex">
                            <div class="control-item w-2/5">
                                <label for="" >Mã nhân viên <span style="color: #FF4747;" v-tooltip.top="options">*</span></label>
                                <!-- <input type="text" v-model="employee.EmployeeCode" FieldName="EmployeeCode" Require="true"> -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"
                                    v-on:blurEvent="changeBorder"                                     
                                    :value="employee.EmployeeCode"
                                    fieldname="EmployeeCode"
                                    required="true"
                                    maxlen="true"
                                    :custom_class="custom_class.EmployeeCode" />
                            </div>
                            <div class="control-item control-right w-3/5" >
                                <label for="">Họ và tên <span style="color: #FF4747;" v-tooltip.top="options">*</span></label>
                                <!-- <input type="text" 
                                    v-model="employee.EmployeeName" 
                                    FieldName="FullName" 
                                    Require="true" > -->

                                <Input 
                                    v-on:valueInputChange="valueInputChange"
                                    v-on:blurEvent="changeBorder"                                    
                                    :value="employee.EmployeeName"
                                    fieldname="EmployeeName"
                                    required="true"
                                    maxlen="true"
                                    :custom_class="custom_class.EmployeeName" />
                            </div>
                        </div>

                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">Đơn vị <span style="color: #FF4747;" v-tooltip.top="options">*</span></label>

                                <ComboBox
                                    v-bind:customDataDropDown="department_dropdown"
                                    v-bind:currentDataInput="employee.DepartmentName"
                                    v-bind:currentIdInput="employee.DepartmentId"
                                    :custom_class="custom_class_dropdown"
                                    v-on:setSelectValue="setSelectedDepartment"
                                    v-on:blurEvent="changeBorder"
                                    FieldName="Department" >
                                </ComboBox>
                            </div>
                            
                        </div>

                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">Chức danh <span style="color: #FF4747;" v-tooltip.top="options"></span></label>

                                <!-- <input type="text" v-model="employee.EmployeePosition" FieldName="PositionCode" Require="true"> -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.EmployeePosition"
                                    fieldname="EmployeePosition"
                                    maxlen="true" />
                            </div>
                            
                        </div>
                    </div>

                    <div class="inforA2">
                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">Ngày sinh 
                                    <!-- <span style="color: #FF4747;" v-tooltip.top="options" >(*)</span> -->
                                </label>

                                <Datebox
                                    :date_value="employee.DateOfBirth"
                                    v-on:updateDateValue="updateDate"
                                    fieldname="DateOfBirth" >
                                </Datebox>
                            </div>
                            <div class="control-item control-right flex-1">
                                <label for="">Giới tính</label>

                                <div class="Gender-area">
                                    <div class="radio-button-area">
                                        <input type="radio" v-model="employee.Gender" value="1" >
                                        Nam
                                    </div>

                                    <div class="radio-button-area">
                                        <input type="radio" v-model="employee.Gender" value="0" >
                                        Nữ
                                    </div>

                                    <div class="radio-button-area">
                                        <input type="radio" v-model="employee.Gender" value="2" >
                                        Khác
                                    </div>

                                </div>
                                
                            </div>
                        </div>

                        <div class="row-item d-flex">
                            <div class="control-item w-3/5">
                                <label for="">Số CMND <span style="color: #FF4747;" v-tooltip.top="options"></span></label>

                                <!-- <input type="text" v-model="employee.IdentityNumber" FieldName="IdentityNumber" Require="true" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.IdentityNumber"
                                    fieldname="IdentityNumber"
                                    maxlen="true" />
                            </div>
                            <div class="control-item control-right w-2/5">
                                <label for="">Ngày cấp 
                                    <!-- <span style="color: #FF4747;" v-tooltip.top="options" >(*)</span> -->
                                </label>

                                <Datebox
                                    :date_value="employee.IdentityDate"
                                    v-on:updateDateValue="updateDate"
                                    fieldname="IdentityDate" >
                                </Datebox>
                            </div>
                        </div>

                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">Nơi cấp
                                    <!-- <span style="color: #FF4747;" v-tooltip.top="options">(*)</span> -->
                                </label>

                                <!-- <input type="text" v-model="employee.IdentityPlace" FieldName="IdentityPlace" Require="true" > -->

                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.IdentityPlace"
                                    fieldname="IdentityPlace"
                                    maxlen="true" />
                            </div>

                        </div>
                    </div>

                </div>
                <div class="inforB">

                    <div class="row-item d-flex">
                        
                        <div class="control-item flex-1">
                            <label for="">Địa chỉ </label>

                            <!-- <input type="text" v-model="employee.Address" FieldName="Address"> -->

                            <Input 
                                v-on:valueInputChange="valueInputChange"                                     
                                :value="employee.Address"
                                fieldname="Address"
                                maxlen="true" />
                        </div>
                    </div>

                    <div class="inforB1">
                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">ĐT di động
                                    <span style="color: #FF4747;" v-tooltip.top="options" ></span>
                                </label>

                                <!-- <input type="text" v-model="employee.PhoneNumber" FieldName="PhoneNumber" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.PhoneNumber"
                                    fieldname="PhoneNumber"
                                    maxlen="true" />
                            </div>
                            <div class="control-item control-right flex-1">
                                <label for="">ĐT cố định 
                                    <span style="color: #FF4747;" v-tooltip.top="options" ></span>
                                </label>

                                <!-- <input type="text" v-model="employee.TelePhoneNumber" FieldName="TelePhoneNumber" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.TelePhoneNumber"
                                    fieldname="TelePhoneNumber"
                                    maxlen="true" />
                            </div>
                            <div class="control-item control-right flex-1">
                                <label for="">Email
                                    <span style="color: #FF4747;" v-tooltip.top="options" ></span>    
                                </label>

                                <!-- <input type="text" v-model="employee.Email" FieldName="Email" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.Email"
                                    fieldname="Email"
                                    maxlen="true" />
                            </div>
                        </div>
                        <div class="row-item d-flex">
                            <div class="control-item flex-1">
                                <label for="">Tài khoản ngân hàng</label>

                                <!-- <input type="text" v-model="employee.BankBranchName" FieldName="BankAccountNumber" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.BankAccountNumber"
                                    fieldname="BankAccountNumber"
                                    maxlen="true" />
                            </div>
                            <div class="control-item control-right flex-1">
                                <label for="">Tên ngân hàng</label>

                                <!-- <input type="text" v-model="employee.BankName" FieldName="BankName" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.BankName"
                                    fieldname="BankName"
                                    maxlen="true" />
                            </div>
                            <div class="control-item control-right flex-1">
                                <label for="">Chi nhánh </label>

                                <!-- <input type="text" v-model="employee.BankBranchName" FieldName="BankBranchName" > -->
                                <Input 
                                    v-on:valueInputChange="valueInputChange"                                     
                                    :value="employee.BankBranchName"
                                    fieldname="BankBranchName"
                                    maxlen="true" />
                            </div>
                        </div>
                    </div>

                    
                </div>
                
        
            </div>
        </div>
        <div class="dialog-congcu">
            <div class="btn-cancel" Command="Cancel" v-on:click="closeForm">
                Hủy
            </div>
            <div class="btn" Command="Save" v-on:click="saveEvent">
                <div class="icon_save"></div>
                <div class="btn_content">Cất</div>
            </div>
            <div class="btn-save-add" v-on:click="saveAndAdd">
                Cất và thêm
            </div>
        </div>

        <Alert
            v-if="isAlert"
            :title="confirmTitle"
            :content="confirmContent"
            :state="confirmState"
            v-on:closeForm="closeAlert"
            v-on:confirm="closeFormAndAlertSave"
            v-on:confirmNo="closeFormAndAlert" >             
        </Alert>


    </div>
</template>
<script>
//import library
import 'devextreme/dist/css/dx.light.css';

//import common function
import Enum from '../../../common/enumeration.js'
import CommonFunc from '../../../common/common.js'

//import component
// import Select from '../common/Select.vue';
// import Resource from '../../common/Resource.js';
import Datebox from '../../common/Datebox.vue';
import Alert from '../../common/Alert.vue';
import ComboBox from '../../common/ComboBox.vue';
import Input from '../../common/Input.vue';

//import thư viện chung
import Enumeration from '../../../common/enumeration.js';
import Resource from '../../../common/resource.js';
// import Contant from '../../../common/contant.js';


//import baseApi
import EmployeesAPI from '../../../api/components/employees/EmployeesAPI.js';

//import thư viện
// import Swal from 'sweetalert2/src/sweetalert2.js'

/* eslint-disable no-debugger */

export default{
    
    name: "EmployeeDetail",
    // các biến từ component cha
    props:{
        employeeId:String,
        employeeBeforeEdit:Object,
        formMode:Number,

        //dữ liệu combobox lấy từ cha
        department_dropdown_title:String,
        department_dropdown:[],
    },
    //các component
    components:{
        // Select,
        Datebox,
        Alert,
        ComboBox,
        Input,
    },

    

    /**
     * data của component này
     * tdanh 6.2021
     */
    data(){
        return{
            employee:{},
            //option để cấu hình v-tooltip
            options: {
                content: 'Thông tin đang để trống',
                autoHide: 'false',
            },
            //data cho form alert
            isAlert:false,
            confirmTitle:'',
            confirmContent:'',
            confirmState:'',
            // custom_class_employeeName:'',
            // custom_class_employeeCode:'',
            custom_class:[],
            custom_class_dropdown:'',

            //validate từ backend
            valid_backend:false,
            //validate trùng mã từ frontend
            valid_frontend:false,

            //data cho v-select
            // Gender_dropdown:{
            //     title:"Giới tính",
            //     items:[
            //         {
            //             text:"Nam",
            //         },
            //         {
            //             text:"Nữ",
            //         },
            //         {
            //             text:"Không xác định",
            //         },
            //         {
            //             text:"default",
            //         },
            //     ],
            // },


        }
    },
    /**
     * bắt đầu chạy khi khởi tạo component EmployeeDetail
     * tdanh 7.2021
     */
    created(){

        this.getEmployeeFromList();
        
    },
    /**
     * xử lý sự kiện focus vào ô input khi mở form
     * tdanh 7.21
     */
    mounted(){
        //nếu ô EmployeeCode có giá trị thì focus vào ô EmployeeName
        if(this.employee.EmployeeCode){
            document.querySelector('[fieldname="EmployeeName"]').focus();
        }
        else{
            document.querySelector('[fieldname="EmployeeCode"]').focus();
        }

    },


    /**
     * theo dõi sự thay đổi của biến employee để validate định dạng
     * tdanh 6.2021
     */
    // watch:{
    //     employee:{
    //         deep:true,
    //         //kiểm tra nếu data employee có các trường để trống thì border đỏ
    //         handler:function(val){
    //             if(!val.EmployeeCode){
    //                 this.custom_class_employeeName = 'red_border';
    //             }
    //             else{
    //                 this.custom_class_employeeName = '';
    //             }
    //             if(!val.EmployeeName ){
    //                 this.custom_class_employeeName = 'red_border';
    //             }
    //             else{
    //                 this.custom_class_employeeName = '';
    //             }
    //             if(!val.DepartmentId){
    //                 document.querySelector('[fieldname="Department"]').classList.add('red_border');
    //             }
    //             else{
    //                 document.querySelector('[fieldname="Department"]').classList.remove('red_border');
    //             }
    //         }
            
    //     },
    // },

    methods: {
        /**
         * Nhận emit từ component input
         * tdanh 7.21
         */
        valueInputChange(val, fieldname, required, maxlen){
            //vì được gọi từ emit trong watch nên chỉ validate được max len và rỗng( required)
            if(required && required == "true"){
                if(this.validateInputEmpty(val) ){
                    this.employee[fieldname] = val;

                    // this.custom_class[fieldname] = '';
                    this.changeBorder()
                    
                }
                else{
                    this.employee[fieldname] = '';
                    
                    // this.custom_class[fieldname] = 'red_border';

                    this.changeBorder();

                }

            }
            if(maxlen && maxlen == "true"){
                if(this.validateInputMaxLen(val)){
                    this.employee[fieldname] = val;
                }
                else{
                    this.employee[fieldname] = '';
                    
                    //xóa bỏ value trên giao diện
                    // document.querySelector('[fieldname="'+fieldname +'"]').value = '';

                    //Hiện thông báo
                    this.isAlert = true;
                    this.confirmState = Enumeration.StateAlert.Validate;
                    // this.confirmContent = "Trường đang dài quá "+Enum.MaxLen.text+" ký tự";
                    this.confirmContent = Resource.AlertMessage.MaxLen;
                    this.confirmTitle = "";
                }
            }

        },
        /**
         * hàm thêm hiệu ứng border đỏ khi để trống input
         * tdanh 7.21
         */
        changeBorder(){

            if(this.employee.EmployeeCode ){
                //Bỏ border đỏ nếu ko giá trị
                this.custom_class['EmployeeCode'] = '';
                if(document.querySelector('[fieldname="EmployeeCode"]')){
                    document.querySelector('[fieldname="EmployeeCode"]').classList.remove('red_border');
                }

            }
            else{
                //Thêm border đỏ nếu có giá trị
                this.custom_class['EmployeeCode'] = 'red_border';
                if(document.querySelector('[fieldname="EmployeeCode"]')){
                    document.querySelector('[fieldname="EmployeeCode"]').classList.add('red_border');
                }

            }
            if(this.employee.EmployeeName){
                //Bỏ border đỏ nếu ko giá trị
                this.custom_class['EmployeeName'] = '';
                if(document.querySelector('[fieldname="EmployeeName"]')){
                    document.querySelector('[fieldname="EmployeeName"]').classList.remove('red_border');
                }

            }
            else{
                //Thêm border đỏ nếu có giá trị
                this.custom_class['EmployeeName'] = 'red_border';
                if(document.querySelector('[fieldname="EmployeeName"]')){
                    document.querySelector('[fieldname="EmployeeName"]').classList.add('red_border');
                }

            }
            if(this.employee.DepartmentId){
                this.custom_class_dropdown = '';
                //Bỏ border đỏ nếu ko giá trị
                if(document.querySelector('[Fieldname="Department"]')){
                    document.querySelector('[Fieldname="Department"]').classList.remove('red_border');
                }

            }
            else{
                //gán border đỏ
                this.custom_class_dropdown = 'red_border';
                //Thêm border đỏ nếu có giá trị
                if(document.querySelector('[Fieldname="Department"]')){
                    document.querySelector('[Fieldname="Department"]').classList.add('red_border');
                }

            }
            
        },

        /**
         * lấy giá trị id trong department_dropdown gán cho model employee lên giao diện
         * tdanh 7.21
         */
        setSelectedDepartment(selectedVal){
            if(selectedVal){
                this.custom_class_dropdown = '';

                let selected_item = this.department_dropdown.filter((item) =>{
                    return item.id == selectedVal;
                })

                if(selected_item && selected_item.length > 0){
                    //gán lại dữ liệu được cập nhật cho employee
                    this.employee.DepartmentId = selected_item[0].id;
                    this.employee.DepartmentName = selected_item[0].data_text;

                    //chuyển lại border thường
                    this.changeBorder();

                }
            }
            else{

                //refresh lại employee.Department
                this.employee.DepartmentId = '';
                this.employee.DepartmentName = '';

                //gán border đỏ
                this.changeBorder();
            }
            
            
        },

        
        /**
         * lấy dữ liệu employee bằng id qua axios, gọi ngay trong created
         * tdanh 6.2021
         */
        async getEmployeeFromList(){
            let employee_code = "";//biến để lưu EmployeeCode trong TH tự sinh ra EmployeeCode

            //nếu là formMode sửa
            if(this.formMode == Enum.FormMode.Edit){

                this.employee = JSON.parse(JSON.stringify(this.employeeBeforeEdit));


            }
            else if(this.formMode == Enum.FormMode.Add || this.formMode == Enum.FormMode.Copy){//nếu formMode là thêm hoặc nhân bản
                //sinh mã EmployeeCode khi thực hiện thêm mới
                await EmployeesAPI.getNewEmployeeCode().then((response) => {
                    
                    if(response.data){
                        this.employee = {};

                        employee_code = response.data.Data;


                    }
                }).catch(e => {
                    console.log(e);
                    this.$emit('showToastMessage', Resource.ToastMessage.Fail, Enum.StateToast.Error);
                })

                
                //gán EmployeeCode vào input
                this.employee.EmployeeCode = employee_code;
                document.querySelector('[fieldname="EmployeeCode"]').value = employee_code;

                if(this.formMode == Enum.FormMode.Copy){
                    this.employee = JSON.parse(JSON.stringify(this.employeeBeforeEdit));
                    this.employee.EmployeeCode = employee_code;
                }

            }
      
        },
        /**
         * update trường có type là date từ emit trong component Datebox
         * tdanh 6.21
         */
        updateDate(val, fieldname){
            if(typeof(val) != 'string' && val != null){
                this.employee[fieldname] = val.toISOString();
            }
            else{
                this.employee[fieldname] = val;
            }

        },
        /**
         * hành động savee
         *
         */
        async saveEvent(){
            /**validate data */
            if(await this.validateDataCustom(this.employee)){
                await this.save();

                if(this.valid_backend){
                    //Close form
                    this.$emit('closeForm');
                    //reload data
                    this.$emit('reloadData');
                }

            }

        },


        /**
         * sự kiện lưu trong form EmployeeDetail
         * tdanh 6.2021
         */
        async save(){


            //nếu action là thêm mới
            if(this.formMode == Enum.FormMode.Add || this.formMode == Enum.FormMode.Copy){

                //post dữ liệu employee trong form thêm mới
                await EmployeesAPI.insert(this.employee).then((response) => {
                    console.log(response);
                    if(response.data.MISACode == 200){
                        this.valid_backend = true;
                        this.$emit('showToastMessage', Resource.ToastMessage.Success, Enum.StateToast.Success);
                    }
                    else{
                        this.valid_backend = false;
                        // this.$emit('showToastMessage', response.data.Data[0], Enum.StateToast.Success);
                        this.confirmTitle = "";
                        // this.confirmContent = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại";
                        this.confirmContent = Resource.AlertMessage.InValid;
                        this.confirmState = Enum.StateAlert.Validate;
                        this.isAlert = true;
                    }
                    
                }).catch(e => {
                    console.log(e);
                    this.$emit('showToastMessage', Resource.ToastMessage.Fail, Enum.StateToast.Error);
                })

            }

            //nếu action là sửa
            if(this.formMode == Enum.FormMode.Edit){

                await EmployeesAPI.update(this.employeeId, this.employee).then((response) => {
                    console.log(response);

                    if(response.data.MISACode == 200){
                        this.valid_backend = true;
                        this.$emit('showToastMessage', Resource.ToastMessage.Success, Enum.StateToast.Success);
                    }
                    else{
                        this.valid_backend = false;

                        this.$emit('showToastMessage', response.data.Data[0], Enum.StateToast.Success);
                        this.confirmTitle = "";
                        // this.confirmContent = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại";
                        this.confirmContent = Resource.AlertMessage.InValid;
                        this.confirmState = Enum.StateAlert.Validate;
                        this.isAlert = true;

                    }
                }).catch(e => {
                    console.log(e);
                    this.$emit('showToastMessage', Resource.ToastMessage.Fail, Enum.StateToast.Error);
                })
            }


            
        },

        /**
         * Hàm cất và tiếp tục thêm
         * tdanh 7.21
         * 
         */
        async saveAndAdd(){
            // this.save();

            if( await this.validateDataCustom(this.employee)){
                await this.save();

                //reload data
                // this.$emit('reloadData');

            }

        },
        
        closeForm(){

            if( ( JSON.stringify(this.employee) != JSON.stringify(this.employeeBeforeEdit) )){
                //mở form xác nhận khi dữ liệu có thay đổi
                this.confirmTitle = "Cất dữ liệu";
                this.confirmContent = "Dữ liệu đã bị thay đổi, bạn có muốn cất không?";
                this.confirmState = Enum.StateAlert.Warning;
                this.isAlert = true;
            }
            else{
                this.$emit('closeForm');
            }

        },
        closeAlert(){
            this.isAlert = false;
        },
        /**
         * Đóng form EmployeeDetail
         * tdanh 7.21
         */
        closeFormAndAlertSave(state){

            //Nếu là form cảnh báo và chọn có thì lưu lại
            if(state == Enum.StateAlert.Warning){
                //Đóng form alert
                this.isAlert = false;

                this.saveEvent();

                // //Đóng form thông tin chung
                // this.$emit('closeForm');
                
            }
            else{
                //Đóng form alert
                this.isAlert = false;

                //Đóng form thông tin chung
                this.$emit('closeForm');
            }

            
        },
        /**
         * nếu chọn không thì đóng cả 2 form Detail và Alert
         * tdanh 7.21
         */
        closeFormAndAlert(){
            //Đóng form alert
            this.isAlert = false;

            //Đóng form thông tin chung
            this.$emit('closeForm');
        },
        
        /**
         * validate data
         * tdanh 6.2021
         */
        async validateDataCustom(employee){

            if(employee){
                if(!employee.EmployeeCode || !(await this.validateEmployeeCode(employee.EmployeeCode, employee.EmployeeId)) ){
                    this.isAlert = true;
                    this.confirmState = Enumeration.StateAlert.Validate;
                    this.confirmContent = "Mã nhân viên " + Resource.AlertMessage.Empty + " hoặc " + Resource.AlertMessage.InValid;
                    this.confirmTitle = "";

                    return false;
                }

                if(!employee.EmployeeName || !this.validateFullName(employee.EmployeeName) ){

                    this.isAlert = true;
                    this.confirmState = Enumeration.StateAlert.Validate;
                    this.confirmContent = "Họ và tên " + Resource.AlertMessage.Empty + " hoặc " + Resource.AlertMessage.MaxLen;
                    this.confirmTitle = "";


                    return false;
                }

                if(!employee.DepartmentId || !this.validateDepartment(employee.DepartmentId) ){
                    
                    this.isAlert = true;
                    this.confirmState = Enumeration.StateAlert.Validate;
                    this.confirmContent = "Đơn vị " + Resource.AlertMessage.Empty;
                    this.confirmTitle = "";


                    return false;

                }
                // if(!this.validatePhoneNumber(employee.PhoneNumber) ){
                    
                //     this.isAlert = true;
                //     this.confirmState = Enumeration.StateAlert.Validate;
                //     this.confirmContent = "Số điện thoại di động sai định dạng";
                //     this.confirmTitle = "";


                //     return false;

                // }
                // if(!this.validateTelePhoneNumber(employee.TelePhoneNumber) ){
                    
                //     this.isAlert = true;
                //     this.confirmState = Enumeration.StateAlert.Validate;
                //     this.confirmContent = "Số điện thoại cố định sai định dạng";
                //     this.confirmTitle = "";


                //     return false;

                // }
                if(!this.validateEmail(employee.Email) ){
                    
                    this.isAlert = true;
                    this.confirmState = Enumeration.StateAlert.Validate;
                    this.confirmContent = "Email sai định dạng";
                    this.confirmTitle = "";


                    return false;

                }
                // if(!this.validateBankAccountNumber(employee.BankAccountNumber) ){
                    
                //     this.isAlert = true;
                //     this.confirmState = Enumeration.StateAlert.Validate;
                //     this.confirmContent = "Tài khoản ngân hàng sai định dạng";
                //     this.confirmTitle = "";


                //     return false;

                // }

                
                return true;
            }


            return false;
        },
        /**
         * validate EmployeeCode
         */
        async validateEmployeeCode(EmployeeCode, EmployeeId){
            if(this.validateInputEmpty(EmployeeCode, 'EmployeeCode')){
                //validate trùng mã
                let isDup = await this.validateDuplicateCode(EmployeeCode, EmployeeId);
                if( isDup ){
                    return false;
                }
                else{

                    return true;
                }
            }
            else{
                return false;
            }
        },
        async validateDuplicateCode(EmployeeCode, EmployeeId){
            let isDup = false,
                employeeDup;


            //nếu là form thêm mới
            if(typeof(EmployeeId) == 'undefined'){
                //chỉ cần kiểm tra có tồn tại EmployeeCode đó ko
                await EmployeesAPI.checkExist(EmployeeCode).then((response) =>{
                    if(response){
                        isDup = response.data.Data;
                    }
                }).catch(e => {
                    console.log(e);
                    // this.$emit('showToastMessage', Resource.ToastMessage.Fail, Enum.StateToast.Error);
                });
            }
            //nếu là form sửa thì lấy EmployeeById đó ra và so sánh
            else{
                //get Employee by EmployeeId
                await EmployeesAPI.getById(this.employeeId).then((response) => {
                    if(response){
                        employeeDup = response.data;

                        //so sánh với employee hiện tại đang thao tác
                        //nếu 2 mã code giống nhau thì ko phải là trùng
                        if(EmployeeCode === employeeDup.EmployeeCode){
                            isDup = false;
                        }

                    }

                }).catch(e => {
                    console.log(e);
                });

                //nếu 2 mã code khác nhau thì so sánh như form thêm mới
                if(EmployeeCode != employeeDup.EmployeeCode){
                    await EmployeesAPI.checkExist(EmployeeCode).then((response) =>{
                        if(response){
                            isDup = response.data.Data;
                        }
                    }).catch(e => {
                        console.log(e);
                        // this.$emit('showToastMessage', Resource.ToastMessage.Fail, Enum.StateToast.Error);
                    });
                }
            }
            

            return isDup;
        },
        /**
         * validate FullName
         */
        validateFullName(fullName){
            if(this.validateInputEmpty(fullName,'FullName')){
                //validate định dạng
                if(CommonFunc.formatFullName(fullName) ){
                    return false;
                }
                else{
                    return true;
                }
            }
            else{
                return false;
            }
            
        },
        validateDepartment(DepartmentId){
            console.log(DepartmentId);
            return true;
        },
        /**
         * validate date of birth
         */
        validateDateOfBirth(DateOfBirth){

            if(this.validateDateBoxEmpty(DateOfBirth)){
                this.getElementByFieldName('DateOfBirth').parentElement.getElementsByTagName('span')[0].innerHTML = "";
                //validate định dạng
                if(CommonFunc.formatDate(DateOfBirth)){
                    return true;
                }
                else{
                    this.getElementByFieldName('DateOfBirth').parentElement.getElementsByTagName('span')[0].innerHTML = "Sai định dạng";
                    return false;
                }
            }
            else{
                return false;
            }
        },
        validateIdentityNumber(){
            return true;
        },

        /**
         * validate identity date
         */
        validateIdentityDate(IdentityDate){

            if(this.validateDateBoxEmpty(IdentityDate)){
                this.getElementByFieldName('DateOfBirth').parentElement.getElementsByTagName('span')[0].innerHTML = "";
                //validate định dạng
                if(CommonFunc.formatDate(IdentityDate)){
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return false;
            }
            
        },

        /**
         * validate Email
         */
        validateEmail(Email){
            //vì trường email ko bắt buộc nhập
            if(typeof(Email) == 'undefined' || Email == null){
                return true;
            }
            if(this.validateInputMaxLen(Email, 'Email')){
                //validate định dạng
                if(CommonFunc.formatEmail(Email)){
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return false;
            }

        },
        /**
         * validate phone number
         */
        validatePhoneNumber(phone){
            //vì trường phone ko bắt buộc nhập
            if(typeof(phone) == 'undefined' || phone == null){
                return true;
            }
            if(phone && this.validateInputMaxLen(phone, 'PhoneNumber')){
                //validate định dạng
                if(CommonFunc.formatPhoneNumber(phone)){
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return false;
            }

        },
        validateTelePhoneNumber(){

            return true;
        },
        validateBankAccountNumber(){
            return true;
        },
        /**
         * validate để trống input
         * tdanh 6.2021
         */
        validateInputEmpty(data){
            if(data && data != null && data != ''){

                return true;
            }
            else{

                return false;
            }
        },
        validateInputMaxLen(data){
            if(data && data.length > Enum.MaxLen.value){
                return false;
            }
            else{
                return true;
            }
        },
        /**
         * validate để trống datebox
         */
        validateDateBoxEmpty(data){
            if(data){
                return true;
            }
            return false;
        },

        formatData(employee){
            if(employee && employee != null){
                if(employee.DateOfBirth && employee.DateOfBirth != null){
                    employee.DateOfBirth = employee.DateOfBirth.substring(0, 10);
                }
                if(employee.IdentityDate && employee.IdentityDate != null){
                    employee.IdentityDate = employee.IdentityDate.substring(0, 10);
                }
                // if(employee.JoinDate && employee.JoinDate != null){
                //     employee.JoinDate = employee.JoinDate.substring(0, 10);
                // }
                // if(employee.WorkStatus && employee.WorkStatus != null){
                //     this.getSelectedWorkStatus(employee.WorkStatus);
                // }
            }
            else{
                return null;
            }
            return employee;
        },
        /**
         * lấy nội dung input bằng FieldName
         */        
        getElementByFieldName(fieldname){
            return document.querySelectorAll('[FieldName='+fieldname+']')[0];
        },

    }
};
</script>
<style scoped>

/* css cho form thêm mới */
.dialog-modal{
    width:100%;
    height:100%;
    background-color: rgba(0,0,0,0.3);
    position:absolute;
    left:0px;
    top:0px;
    z-index: 4;
    /* opacity:50%; */
}
.dialog-modal .dialog-loading{
    width:200px;
    height:200px;
    background-image:url('../../../assets/Icon/Sprites.64af8f61.svg');
    background-repeat:no-repeat;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
}
.dialog{
    width:900px;
    height:625px;
    background-color:#ffffff;
    color:#000000;
    position:absolute;
    left:50%;
    top:50%;
    transform: translate(-50%, -50%);
    border-radius:4px;
    font-family: notosans-regular;
    z-index: 4;
}
.dialog-head{
    width:100%;
    height:10%;
    line-height:60px;
    display:flex;
}
.dialog-head .left-head-dialog{
    width: auto;
    height: 100%;
    margin-left: 30px;
    text-align: left;
    font-size:24px;
    color:#000000;
    /* text-transform: uppercase; */
    font-family: notosans-semibold;
}
.dialog-head .right-head-dialog{
    width:70%;
    height:100%;
    display: flex;
}
    .dialog-head .right-head-dialog .role-area{
        display: flex;
        align-items: center;
        font-size:13px;
    }
    .dialog-head .right-head-dialog .role-area input[type="checkbox"]{
        height: 18px;
        width: 18px;
        margin:10px 20px;
        margin-right: 5px;
    }
    .dialog-head .right-head-dialog .icon-question{
        width:24px;
        height:24px;
        margin-top:10px;
        background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -89px -145px;
        background-size: auto;
        position: absolute;
        right: 44px;
    }
    .dialog-head .right-head-dialog .icon-close{
        width:24px;
        height:24px;
        margin-top:10px;
        background: url('../../../assets/Icon/Sprites.64af8f61.svg') no-repeat -144px -145px;
        background-size: auto;
        position: absolute;
        right: 10px;
    }
    .dialog-head .right-head-dialog .icon-close:hover{
        cursor: pointer;
    }
.dialog-body{
    width:100%;
    height:calc(100% - 150px);
    background-color:#ffffff;
    font-size:13px;
    display:flex;
    padding: 0 32px 3px;
}

.dialog-body .dialog-body-conten{
    width:100%;
    height:100%;
    /* overflow: auto; */
    overflow-y: hidden;
    border-bottom: 1px solid #bbbbbb;
}
label{
    font-family: notosans-semibold;
    font-size: 12px;
    display:block;
    font-weight:bold;
    margin-bottom: 4px;
}
.inforA{
    width:100%;
    height: 220px;
    margin-bottom: 10px;
    display:flex;
}
    .inforA .inforA1{
        flex: 1;
        height: 192px;
        padding-right: 26px;
    }
    .inforA .inforA2{
        flex: 1;
        height: 192px;
    }

.inforB{
    width:100%;
    height:250px;
}
    .inforB .inforB1{
        width: 70%;
    }
.dialog-body .dialog-body-conten .inforA .row-item{
    width: 100%;
    height: 52px;
    margin-bottom: 12px;
}
.dialog-body .dialog-body-conten .inforB .row-item{
    width: 100%;
    height: 52px;
    margin-bottom: 12px;
}
.d-flex{
    display:flex;
}
.flex-1{
    flex: 1;
}
.dialog-body .row-item .control-item{
    height:100%;
    width:100%;
    background-color:#ffffff;
    margin-left:0px;
}
.dialog-body .row-item .control-item input{
    border-radius: 2px;
    border: 1px solid #babec5;
    box-sizing: border-box;
    height:32px;
    width:100%;
    padding:6px 10px;
    font-size: 12px;
}
.dialog-body .row-item .control-item input:focus{
    outline: none !important;
    border: 1px solid #2ca01c; 
}

/* custom lại radio button */
.dialog-body .row-item .control-item input[type="radio"]:checked {
    background-color: #2CA01C;
}
.dialog-body .row-item .control-item input[type="radio"]{
    width: 18px;
    height: 18px;
    margin-right: 10px;
    margin-left: 0px;

    -webkit-appearance: none;
    -moz-appearance: none;
    appearance: none;
    display: inline-block;
    padding: 2px;
    background-clip: content-box;
    border: 1px solid #BBBBBB;
    background-color: #ffffff;
    border-radius: 50%;
}




.dialog-body .row-item .control-item .css_date{
    border-radius:3px;
    border: 1px solid #BBBBBB; 
    height:32px;
    width:101%;
}

.dialog-body .row-item .control-item select{
    border-radius:3px;
    border: 1px solid #BBBBBB; 
    height:60%;
    width:102%;
}
.dialog-body .row-item .control-item select .css_option{
    border-radius:3px;
    border: 1px solid #BBBBBB; 
    height:60%;
    width:102%;
}

.dialog-body .row-item .control-right{
    margin-left: 6px;
    margin-right:0px;
}
    .dialog-body .row-item .control-right .Gender-area{
        display: flex;
        align-items: center;
        width: 100%;
        height: 32px;
    }
    .dialog-body .row-item .control-right .Gender-area .radio-button-area{
        display: flex;
        align-items: center;
        width: 100%;
        height: 32px;
        margin-right: 20px;
    }
.dialog .dialog-congcu{
    width:100%;
    height:90px;
    background-color:#ffffff;
    text-align:right;
    border-radius:3px;
    position: absolute;
    bottom: 0px;
    display: flex;
    justify-content: flex-end;
    align-items: center;
}
.dialog .dialog-congcu .btn{
    font-family:notosans-regular;
    width:auto;
    height:40px;
    line-height: 40px;
    margin:10px 10px 10px 0px;
    color:#000000;
    background-color: #ffffff;
    border: 1px solid #8d9096;;
    border-radius:2px;
    font-size:13px;
    padding-left:16px;
    padding-right:16px;
    display: flex;
    font-weight: 600;
}
    
    .dialog .dialog-congcu .btn .btn_content{
        height:100%;
    }
.dialog .dialog-congcu .btn-save-add{
    font-family:notosans-regular;
    width:auto;
    height:40px;
    line-height: 40px;
    margin:10px 30px 10px 0px;
    color:#ffffff;
    background-color: #2ca01c;
    border: 1px solid #8d9096;
    border-radius:2px;
    font-size:13px;
    padding-left:24px;
    padding-right:24px;
    font-weight: 600;
}
.dialog .dialog-congcu .btn-save-add:hover{
    background-color: #33b322;
    cursor: pointer;
}

.dialog .dialog-congcu .btn-cancel{
    font-family:notosans-regular;
    width:auto;
    height:40px;
    line-height: 40px;
    margin:10px 10px 10px 0px;
    color:#000000;
    background-color: #ffffff;
    border: 1px solid #8d9096;
    border-radius:2px;
    font-size:13px;
    padding-left:24px;
    padding-right:24px;
    position: absolute;
    left:30px;
    font-weight: 600;
}
.dialog .dialog-congcu .btn-cancel:hover{
    background-color: #e5e5e5;
    cursor: pointer;
}

.dialog-congcu .btn:hover{
    background-color:#e5e5e5;
    cursor: pointer;
}
.red_border{
    border: 1px solid #FF4747 !important;
}
.green_border{
    border: 1px solid #2ca01c !important;
}

.w-3\/5{
    width: 60%!important;
}
.w-2\/5{
    width: 40%!important;
}

@media screen 
  and (min-device-width: 1200px) 
  and (max-device-width: 1600px) 
  and (-webkit-min-device-pixel-ratio: 1) { 
      
      
    .dialog{
        width:900px;
        height:625px;
    }
}

</style>