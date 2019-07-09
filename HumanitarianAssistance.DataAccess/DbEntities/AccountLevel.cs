﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanitarianAssistance.DataAccess.DbEntities
{
    public partial class AccountLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public int AccountLevelId { get; set; }
        [StringLength(50)]
        public string AccountLevelName { get; set; }
    }
}
