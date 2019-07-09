using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanitarianAssistance.DataAccess.DbEntities
{
    public class DistrictDetail :BaseEntityWithoutId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public long DistrictID {get;set;}
        [StringLength(50)]
        public string District { get; set; }
        public Nullable<int> ProvinceID { get; set; }

    }
}
