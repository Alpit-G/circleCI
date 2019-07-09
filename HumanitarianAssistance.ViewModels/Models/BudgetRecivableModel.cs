using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HumanitarianAssistance.ViewModels.Models
{
    public class BudgetReceivableModel : BaseModel
    {

        public long BudgetReceivalbeId { get; set; }
        [Required]
        public long? ProjectId { get; set; }
        [Required]
        public long BudgetLineId { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime ExpectedDate { get; set; }

        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string BudgetLineTypeName { get; set; }
        public int? BudgetLineTypeId { get; set; }

    }
}
