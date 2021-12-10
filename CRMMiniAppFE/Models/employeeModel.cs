using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMMiniAppFE.Models
{
    public class employeeModel
    {
        public int MaNV { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên nhân viên")]
        public string HoTenNV { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string DienThoai { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Bạn chưa nhập tên Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên mật khẩu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập quyền nhân viên")]
        public string  Role { get; set; }
    }
}