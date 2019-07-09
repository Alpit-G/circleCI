using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HumanitarianAssistance.ViewModels.Models
{
    public class BudgetPayableModel: BaseModel
    {
        public long BudgetPayableId { get; set; }
        public long ProjectId { get; set; }
        public long BudgetLineId { get; set; }
        public double Amount { get; set; }
        public DateTime ExpectedDate { get; set; }
        public string ProjectName { get; set; }
        public string BudgetLineTypeName { get; set; }

    }
}
