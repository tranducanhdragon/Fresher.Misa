import BaseAPI from "../../base/BaseAPI";

class DepartmentsAPI extends BaseAPI {
    constructor() {
        super();

        this.controller = "v1/departments";
    }

}

export default new DepartmentsAPI();