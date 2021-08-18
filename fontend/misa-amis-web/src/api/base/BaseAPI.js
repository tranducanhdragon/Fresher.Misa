import BaseAPIConfig from "./BaseAPIConfig";

export default class BaseAPI {
    constructor() {
        this.controller = null;
    }

    /**
     * Hàm lấy tất cả dữ liệu
     * tdanh 07.21
     */
    getAll() {
        return BaseAPIConfig.get(`${this.controller}`);
    }

    /**
     * Hàm lấy bản ghi theo Id
     * tdanh 05.07.21
     */
    getById(id) {
        return BaseAPIConfig.get(`${this.controller}/${id}`)
    }

    /**
     * Hàm thêm mới dữ liệu
     * tdanh 05.07.21
     *  
     */
    insert(data) {
        return BaseAPIConfig.post(`${this.controller}`, data);
    }

    /**
     * Hàm sửa dữ liệu
     * tdanh 05.07.21
     *  
     */
    update(id, data) {
        return BaseAPIConfig.put(`${this.controller}/${id}`, data);
    }

    /**
     * Hàm xóa dữ liệu
     * tdanh 05.07.21
     *  
     */
    delete(id) {
        return BaseAPIConfig.delete(`${this.controller}/${id}`);
    }
    
}