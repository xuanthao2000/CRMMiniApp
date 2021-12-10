using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRMMiniAppFE.Models
{
    public class CRMContext: DbContext
    {

        public virtual DbSet<classifyModel> classifyModels { get; set; }
        public virtual DbSet<customerModel> customerModels { get; set; }
    }
}