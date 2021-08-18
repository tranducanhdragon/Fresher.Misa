import BaseAPI from "../../base/BaseAPI";
import BaseAPIConfig from "../../base/BaseAPIConfig";

class EmployeesAPI extends BaseAPI {
    constructor() {
        super();

        this.controller = "v1/employees";
    }

    /**
     * api lấy về dữ liệu phân trang
     * tdanh 07.21
     */
    paging(pageNum, pageSize){
        let url = `${this.controller}/paging?pageIndex=${pageNum}&pageSize=${pageSize}`;

        return BaseAPIConfig.get(`${url}`);
    }

    /**
     * api lấy về dữ liệu theo phân trang có filter tìm kiếm theo tên hoặc mã
     * tdanh 07.21 
     */
    filter(filterValue, pageSize, pageNum) {
        let url = `${this.controller}/filter?filter_val=${filterValue}&pageSize=${pageSize}&pageNumber=${pageNum}`;

        return BaseAPIConfig.get(`${url}`);
    }

    /**
     * Hàm lấy mã nhân viên mới
     * tdanh 07.21 
     */
    getNewEmployeeCode() {
        return BaseAPIConfig.get(`${this.controller}/max_code`);
    }

    /**
     * Gọi api check trùng mã code
     * tdanh 07.21
     */
    checkExist(entityCode){
        let url = `${this.controller}/check_exist?EntityCode=${entityCode}`;

        return BaseAPIConfig.get(`${url}`);
    }

    /**
     * Hàm export dữ liệu
     * tdanh 07.21
     */
    exportData() {
        let url = `${this.controller}/export`;

        return BaseAPIConfig.get(`${url}`, { responseType: 'blob' });
    }
}

export default new EmployeesAPI();