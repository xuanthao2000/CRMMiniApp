using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMMiniAppFE.Models
{
    public class classifyModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public classifyModel()
        {
            this.customers = new HashSet<customerModel>();
        }

        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên loại khách hàng")]
        public string TenLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customerModel> customers { get; set; }
    }
}