using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMMiniAppFE.Models
{
    public class customerModel
    {
        public int MaKH { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên khách hàng")]
        public string HoTenKH { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string DienThoai { get; set; }
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Required(ErrorMessage = "Bạn chưa nhập tên Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn mã loại khách hàng")]
        public Nullable<int> MaLoai { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thông tin 1")]
        public string info1 { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thông tin 2")]
        public string info2 { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thông tin 3")]
        public string info3 { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thông tin 4")]
        public string info4 { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập thông tin 5")]
        public string info5 { get; set; }
        
        public DateTime NgayTao { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> fromDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> toDate { get; set; }
        
        public virtual classifyModel classify { get; set; }
    }
}