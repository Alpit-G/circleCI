﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HumanitarianAssistance.ViewModels.Models
{
    public class PensionModel
    {
        public int OfficeId { get; set; }
        public int EmployeeId { get; set; }
        public List<int> FinancialYearId { get; set; }
        public int CurrencyId { get; set; }
    }
}
