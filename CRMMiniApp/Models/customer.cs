//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRMMiniApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public int MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> MaLoai { get; set; }
        public string info1 { get; set; }
        public string info2 { get; set; }
        public string info3 { get; set; }
        public string info4 { get; set; }
        public string info5 { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
    
        public virtual classify classify { get; set; }
    }
}
