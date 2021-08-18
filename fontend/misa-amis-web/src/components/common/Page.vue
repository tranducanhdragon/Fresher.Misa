<template>
    <div class="page">
        <div class="number_employee">
          Tổng số: 
          <div class="total-records">
            {{totalRecord}}
          </div> 
          bản ghi</div>
        <div class="page_content">
            <ComboBox 
                v-bind:customDataDropDown="pageSize_dropdown"
                :searchEnabled="false"
                :currentDataInput="current_input_pageSize"
                :currentIdInput="pageSize"
                v-on:setSelectValue="setSelectedPageSize"
                FieldName="PageSize" >

            </ComboBox>

            <div class="first_page" v-on:click="firstPage">
                <a class="page-link" href="#" ></a>
            </div>
            <div class="previous_page" v-on:click="prevPage">
                <a class="page-link" href="#" ></a>
            </div>
            <div class="page_number">
                <div class="pagination page_content_inner">
                    <div class="page-item" v-for="item in page_items" :key="item" v-on:click="pagingData">
                        {{item}}
                    </div>
                </div>
            </div>                   
            <div class="next_page" v-on:click="nextPage">
                <a class="page-link" href="#" ></a>
            </div>
            <div class="last_page" v-on:click="lastPage">
                <a class="page-link" href="#" ></a>
            </div>
        </div>
    </div>
</template>

<script>

//import common function
// import Contant from '../../common/contant.js'
// import CommonFunc from '../../common/common.js'
//import thư viện
// import Swal from 'sweetalert2/src/sweetalert2.js'

//import component
import ComboBox from '../common/ComboBox.vue'

//import baseApi
import EmployeesAPI from '../../api/components/employees/EmployeesAPI.js';

/* eslint-disable no-debugger */

export default {
    components:{
      ComboBox,
    },

    props:{
        employee_prop:{},
        total:Number,
        filter_val:String,
    },

    data(){
        return{
            page_items:[1, 2, 3, 4, 5],
            const_len:5,
            employeeData:{},
            pageSize: '10',
            pageNumber: '1',
            totalRecord:0,
            totalPage:0,
            current_page:1,
            pageSize_dropdown:[
              {data_text: "10 bản ghi trên 1 trang", id:'10'},
              {data_text: "20 bản ghi trên 1 trang", id:'20'},
              {data_text: "30 bản ghi trên 1 trang", id:'30'},
              {data_text: "50 bản ghi trên 1 trang", id:'50'},
            ],
            current_input_pageSize:'10 bản ghi trên 1 trang',
            
        }

    },
    //cập nhật page_items theo totalPage
    created(){
      this.totalRecord = this.total;

      //gọi api lần đầu để lấy totalPage
      this.pagingDataFirst();

    },
    watch:{
        totalPage:{
          deep:true,
          handler(val){
              //nếu total hiện tại lớn hơn const_len
              if(val > this.const_len){
                  this.page_items = [];
                  for(let i = 1; i <= this.const_len; ++i){
                    this.page_items.push(i);
                  }
              }
              else{
                  this.page_items = [];
                  for(let i = 1; i <= val; ++i){
                    this.page_items.push(i);
                  }
              }
                
          },
        },

        total:{
          handler(val){
            this.totalRecord = JSON.parse(JSON.stringify(val));
          }
        },
        filter_val:{
          handler(val){
            this.filter_val = JSON.parse(JSON.stringify(val));
          }
        },

        pageNumber:{
          handler(val){
            this.$emit('sendPageNum', val);
          }
        },


    },

    mounted(){
        //active page-item 1 khi vừa khởi tạo
        document.getElementsByClassName('page-item')[0].classList.add('active');
    },

    //cập nhật active class nếu mảng this.page_items bị thay đổi
    updated(){

        //bỏ class active của tất cả các page-item trước đó
        document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));
        //thêm class active cho page-item hiện tại
        document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page)].classList.add('active');

        this.pagingData(document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page)]);
    },

    methods:{
      /**
       * Gọi ra từ emmit trong component Combobox
       * tdanh 7.21
       */
        getSelectedPageSize(selectedVal){
          let selected_item = this.pageSize_dropdown.filter((item) =>{
                return item.data_text == selectedVal;
          });
          if(selected_item && selected_item.length > 0){
            this.pageSize = selected_item[0].id;

            document.querySelectorAll('[FieldName="PageSize"]')[0].querySelectorAll('input')[1].value = selected_item[0].data_text;
          }

        },
        setSelectedPageSize(selectedVal){
          let selected_item = this.pageSize_dropdown.filter((item) =>{
                return item.id == selectedVal;
          });
          if(selected_item && selected_item.length > 0){
            this.pageSize = selected_item[0].id;

          }

        },


        /**
         * get data paging
         * tdanh 6.21
         */
        async pagingData(e) {
            // this.employeeData = JSON.parse(JSON.stringify(this.employee_prop));

            //xử lý sự kiện giao diện cho các nút page item và gán pageNumber
            if(e.target){

                //nếu chọn số trang
                if(!isNaN(e.target.innerHTML) ){
                    //bỏ class active cho tất cả page-item trước đó
                    document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                    //thêm class active cho page-item hiện tại
                    e.target.classList.add('active');
                    this.pageNumber = e.target.innerHTML;
                }

            }
            else if(e.innerText){
                this.pageNumber = e.innerText;
            }


            await EmployeesAPI.paging(this.pageNumber, this.pageSize).then((response) => {
                if(response){

                  //gán data paging vào employeeData
                  this.employeeData = response.data.Data.data;

                  this.totalPage = response.data.Data.totalPage;
                  this.totalRecord = response.data.Data.totalRecord;

                }
            }).catch(e => {
                console.log(e);
            });

            //truyền dữ liệu lên component EmployeeList nếu filter_val ko có giá trị
            if(this.filter_val.length <= 0){
              this.$emit('loadDataPaging', this.employeeData);
            }
            else{
              this.totalRecord = this.total;
              
            }

        },


        /**
         * gọi lần đầu để lấy totalPage
         */
        async pagingDataFirst() {

            await EmployeesAPI.paging(this.pageNumber, this.pageSize).then((response) => {
                if(response){
                  this.employeeData = response.data.Data.data;


                  this.totalPage = response.data.Data.totalPage;
                  this.totalRecord = response.data.Data.totalRecord;

                }
            }).catch(e => {
                console.log(e);
            });

        },


        firstPage(e){

            if(e.target.className === 'first_page'){

                //bỏ class active cho tất cả page-item trước đó
                document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                //cập nhật lại page-items về đầu
                this.page_items = [];
                if(this.totalPage > this.const_len){
                  for(let i = 1; i <= this.const_len; ++i){
                    this.page_items.push(i);
                  }
                }
                else{
                  for(let i = 1; i <= this.totalPage; ++i){
                    this.page_items.push(i);
                  }
                }
                

                //cập nhật lại current-page
                this.current_page = 1;

            }

        },
        prevPage(e){
              let current_page = document.getElementsByClassName('page-item active')[0].innerHTML;
              this.current_page = parseInt(current_page);

              if(e.target.className === 'previous_page'
               && this.page_items.indexOf(this.current_page) != 0 
               && this.page_items.indexOf(this.current_page) != (this.const_len - 1) ){

                  //bỏ class active cho tất cả page-item trước đó
                  document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                  //thêm class active cho page-item hiện tại
                  document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page) - 1].classList.add('active');
                  this.pageNumber = (this.current_page - 1).toString();

                  this.pagingData(e);
              }
              //trường hợp page-item đang ở đầu hoặc ở cuối và bấm prev tiếp và số trang trả về lớn hơn const_len
              if(e.target.className === 'previous_page' 
                && (this.page_items.indexOf(this.current_page) == 0
                || this.page_items.indexOf(this.current_page) == (this.const_len - 1))){

                  //TH đang ở đầu
                  if(this.page_items.indexOf(this.current_page) == 0 && this.page_items[0] > 1){
                      //thêm một page-item bên phải và bỏ một ở bên trái
                      this.page_items.pop();
                      this.page_items.unshift(this.page_items[0] - 1);
                  }

                  //TH đang ở cuối thì ko thay đổi mảng this.page_items
                  

                  if(this.current_page > 1){
                      //cập nhật lại current-page
                      this.current_page = this.current_page - 1;
                  }


                  // //bỏ class active cho tất cả page-item trước đó
                  document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                  //thêm class active cho page-item hiện tại nếu mảng this.page_items ko đổi
                  document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page)].classList.add('active');

              }
        },
        nextPage(e){
            let current_page = document.getElementsByClassName('page-item active')[0].innerHTML;
            this.current_page = parseInt(current_page);
            if(e.target.className === 'next_page' 
              && this.page_items.indexOf(this.current_page) != 0 
              && this.page_items.indexOf(this.current_page) != (this.const_len - 1)){


                //bỏ class active cho tất cả page-item trước đó
                document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                //thêm class active cho page-item hiện tại
                
                if(this.totalPage > this.current_page){
                    document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page) + 1].classList.add('active');
                    this.pageNumber = (this.current_page + 1).toString();
                }
                //Nếu tổng số trang nhỏ hơn hoặc bằng số trang hiện tại
                else{
                    document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page)].classList.add('active');
                    this.pageNumber = (this.current_page).toString();
                }


                this.pagingData(e);
            }
            //trường hợp page-item đang ở đầu hoặc cuối và bấm next tiếp và số trang trả về lớn hơn const_len
            if(e.target.className === 'next_page' 
              && (this.page_items.indexOf(this.current_page) == 0
              || this.page_items.indexOf(this.current_page) == (this.const_len - 1))){

                //TH đang ở cuối
                if(this.page_items.indexOf(this.current_page) == (this.const_len - 1)
                    && this.current_page < this.totalPage){
                    //thêm một page-item bên phải và bỏ một ở bên trái
                    this.page_items.push(this.current_page + 1);
                    this.page_items.shift();
                }
               

                //cập nhật lại current-page
                if(this.current_page < this.totalPage){
                    this.current_page = this.current_page + 1;
                }


                // //bỏ class active cho tất cả page-item trước đó
                document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                //thêm class active cho page-item hiện tại nếu mảng this.page_items ko đổi
                document.getElementsByClassName('page-item')[this.page_items.indexOf(this.current_page)].classList.add('active');

            }

        },
        lastPage(e){

            if(e.target.className === 'last_page'){

                //bỏ class active cho tất cả page-item trước đó
                document.getElementsByClassName('page-item').forEach(e => e.classList.remove('active'));

                this.pageNumber = (this.totalPage).toString();

                //cập nhật lại page-item
                this.page_items = [];
                let start_index = this.totalPage - this.const_len + 1;
                if(this.totalPage < this.const_len){
                    start_index = 1;
                }
                for(let i = start_index; i <= this.totalPage; ++i){
                    this.page_items.push(i);
                }

                //cập nhật lại current-page
                this.current_page = this.totalPage;
            }

        },


    }
}
</script>
<style scoped>
.page {
  width: 100%;
  height: 50px;
  background-color: #ffffff;
  border-top: 1px solid #bbbbbb;
  display: flex;
  justify-content: flex-end;
  position: relative;
}

  .page .page_content {
    width: 700px;
    height: 100%;
    text-align: center;
    display: flex;
    justify-content: flex-end;
    align-items: center;
  }
    .page .page_content .first_page {
      height: 24px;
      width: 24px;
      background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -28px -355px;
      background-size: auto;
    }
    .page .page_content .first_page:hover{
      cursor: pointer;
    }
    .page .page_content .previous_page {
      height: 24px;
      width: 35px;
      /* background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -28px -354px; */
      background-size: auto;
    }
    .page .page_content .previous_page:after, before{
      content: 'Trước';
      font-size: 13px;
    }
    .page .page_content .previous_page:hover{
      cursor: pointer;
    }
    .page .page_content .next_page {
      height: 24px;
      width: 24px;
      /* background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -76px -355px; */
      background-size: auto;
    }
    .page .page_content .next_page:after,before{
      content: 'Sau';
      font-size: 13px;
    }
    .page .page_content .next_page:hover{
      cursor: pointer;
    }
    .page .page_content .last_page {
      height: 24px;
      width: 24px;
      background: url('../../assets/Icon/Sprites.64af8f61.svg') no-repeat -75px -355px;
      background-size: auto;
    }
    .page .page_content .last_page:hover{
      cursor: pointer;
    }
    .page .page_content .page_number {
      height: 100%;
      width: auto;
    }
    .page .page_content .page_content_inner {
      height: 100%;
      width: 100%;
      display: flex;
      align-content: center;
      justify-content: center;
    }
      .page .page_content .page_content_inner .page-item{
        width:20px;
        height:20px;
        margin:10px;        
        background-color: #ffffff;
        line-height: 20px;
        margin: auto;
        margin-left: 5px;
        margin-right: 5px;
      }
      .page .page_content .page_content_inner .page-item:hover{
        color: #ffffff !important;
        cursor: pointer;
        background-color: #bbbbbb;
      }
        .page .page_content .page_content_inner .page-item .page-link{
          margin:5px; 
        }      
    .page_content .page_number .page_content_inner .active {
      cursor: pointer;             
      border: 1px solid #bbbbbb;
      border-radius: 2px;
      font-weight: bold;
    }

.page .number_employee {
  width: 300px;
  height: 100%;
  padding:16px 10px;
  font-size: 13px;
  position: absolute;
  left:0px;
  display: flex;
}
  .page .number_employee .total-records{
    margin: 0 5px;
    font-weight: bold;
  }

</style>
