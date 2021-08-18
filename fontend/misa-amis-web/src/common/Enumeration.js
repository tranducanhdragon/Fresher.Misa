// Các enum dùng chung toàn chương trình
var Enumeration = Enumeration || {};

// Các mode của form detail
Enumeration.FormMode = {
    Add: 1,    // Thêm mới
    Edit: 2,   // Sửa
    Delete: 3,  // Xóa
    Copy:4      //Nhân bản
}

// Giới tính
Enumeration.Gender = {
    Female: 0, // Nữ
    Male: 1,   // Nam
    Other: 2   // Khác
}
//Tình trạng công việc
Enumeration.WorkStatus = {
    UnActive: 0, //Đã nghỉ
    Active: 1 //Đang làm
}
//Chức vụ
Enumeration.PositionCode = {
    Director: 0, //Xếp
    Staff: 1 //Nhân viên
}

//Trạng thái cho nguời dùng trong ToastMessage
Enumeration.StateToast = {
    Success: '1',
    Error: '0',
}

//Trạng thái thông báo trong Alert
Enumeration.StateAlert = {
    Warning: '2',
    Validate: '1',
    Error: '0',
}
//Validate trạng thái max lenght của input là 50
Enumeration.MaxLen = {
    value: 50,
    text: "50",
}

export default Enumeration;