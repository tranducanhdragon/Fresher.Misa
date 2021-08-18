import Enumeration from "./enumeration";
import Resource from "./resource";

// Các hàm dùng chung toàn chương trình
var CommonFn = CommonFn || {};

//Hàm format fullname
CommonFn.formatFullName = fullname =>{
    let regex = /[0-9][,.;'!@#$%&-=]/;
    return regex.test(fullname);
}

//Hàm format email
CommonFn.formatEmail = email => {
    let regexEmail = /[a-zA-Z0-9]+@[a-zA-Z0-9-]+.com/;
    return regexEmail.test(email);
}
//Hàm format phone
CommonFn.formatPhoneNumber = phone => {
    let regexEmail = new RegExp("([0-9])+([0-9]{9})");
    return regexEmail.test(phone);
}

// Hàm format số tiền
CommonFn.formatMoney = money => {
    if(money && !isNaN(money)){
        return money.toString().replace(/(\d)(?=(\d{3})+(?:\.\d+)?$)/g, "$1.");
    }else{
        return money;
    }
}

// Format ngày tháng
CommonFn.formatDate = dateSrc => {
    let date = new Date(dateSrc),
        year = date.getFullYear().toString(),
        month = (date.getMonth() + 1).toString().padStart(2, '0'),
        day = date.getDate().toString().padStart(2, '0');

    return `${day}/${month}/${year}`;
}

// Kiểm tra xem có phải dạng date không
CommonFn.isDateFormat = (date) => {
    let regex = new RegExp("([0-9]{4}[-](0[1-9]|1[0-2])[-]([0-2]{1}[0-9]{1}|3[0-1]{1})|([0-2]{1}[0-9]{1}|3[0-1]{1})[-](0[1-9]|1[0-2])[-][0-9]{4})");
    
    return regex.test(date);
}

// Format ngày tháng
CommonFn.convertDate = dateSrc => {
    let date = new Date(dateSrc),
        year = date.getFullYear().toString(),
        month = (date.getMonth() + 1).toString().padStart(2, '0'),
        day = date.getDate().toString().padStart(2, '0');

    return `${year}-${month}-${day}`;
}

// Lấy giá trị của một enum
CommonFn.getValueEnum = (data, enumName) => {
   let enumeration = Enumeration[enumName],
       resource = Resource[enumName];

    for(let propName in enumeration){
        if(enumeration[propName] == data){
            data = resource[propName];
        }
    }

    return data;
}
/* 
Hàm căn lề
*/
CommonFn.getClassFormat = (dataType) => {
    let className = "";

    switch (dataType) {
        case "Number":
            className = "align-right";
            break;
        case "Date":
            className = "align-center";
            break;
        case "Money":
            className = "align-right";
            break;
        default:
            className = "align-center";
            break;
    }

    return className;
}
/**
 * hàm format dữ liệu
 */
CommonFn.getDataFormatted = (data, dataType, enumName) => {
    switch(dataType){
        case "Enum":
            data = CommonFn.getValueEnum(data, enumName);
            break
        case "Number":
            data = parseInt(data);
            break;
        case "Date":
            data = CommonFn.formatDate(data);
            break;
        case "Money":
            data = CommonFn.formatMoney(data);
            break;  
    }
    return data;
}


export default CommonFn;