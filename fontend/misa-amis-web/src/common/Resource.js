// Resource dùng chung toàn chương trình
var Resource = Resource || {};

// Các kiểu dữ liệu của column trong grid
Resource.DataTypeColumn = {
    Number: "Number",
    Date: "Date",
    Enum: "Enum",
    FullName: "FullName"
};

// Các method khi gọi ajax
Resource.Method = {
    Get: "Get",
    Post: "Post",
    Put: "Put",
    Delete: "Delete"
}

// giới tính
Resource.Gender = {
    Female: "Nữ",
    Male: "Nam",
    Other: "Không xác định"
}
// chức vụ
Resource.PositionCode = {
    Director: "Xếp",
    Staff: "Nhân viên"
}
// tình trạng công việc
Resource.WorkStatus = {
    UnActive: "Đã nghỉ",
    Active: "Đang làm"
}
// Các commandType của toolbar
Resource.CommandType = {
    Add: "Add",
    Edit: "Edit",
    Delete: "Delete",
    Refresh: "Refresh",
    Import: "Import",
    Export: "Export"
}

// Các commandType của toolbar
Resource.CommandForm = {
    Save: "Save",
    Cancel: "Cancel"
}
//thông báo của toastMessage
Resource.ToastMessage = {
    Success: "Cập nhật thành công",
    Fail: "Có lỗi xảy ra, vui lòng liên hệ MISA"
}
//Thông báo Alert form Validate
Resource.AlertMessage = {
    Empty: "Đang để trống",
    MaxLen: "Trường đang dài quá 50 ký tự",
    InValid: "Dữ liệu không hợp lệ ( mã bị trùng)",
}

export default Resource;