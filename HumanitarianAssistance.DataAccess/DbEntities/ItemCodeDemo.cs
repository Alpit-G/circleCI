using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HumanitarianAssistance.DataAccess.DbEntities
{
    public partial class ItemCodeDemo : BaseEntity
    {
        [StringLength(255)]
        public string StoreItemCode { get; set; }
        [StringLength(255)]
        public string Area { get; set; }
    }
}
