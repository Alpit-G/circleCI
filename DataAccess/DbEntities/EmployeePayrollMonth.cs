﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.DbEntities
{
    public partial class EmployeePayrollMonth : BaseEntityWithoutId
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column(Order = 1, TypeName = "serial")]
		public long MonthlyPayrollId { get; set; }
		public int EmployeeID { get; set; }
		public EmployeeDetail EmployeeDetails { get; set; }
		public int SalaryHeadId { get; set; }
		public SalaryHeadDetails SalaryHeadDetails { get; set; }
		public double MonthlyAmount { get; set; }
		public int CurrencyId { get; set; }
        public int? PaymentType { get; set; }
        public int? HeadTypeId { get; set; }
        public CurrencyDetails CurrencyDetails { get; set; }
		public DateTime Date { get; set; }
        public long? AccountNo { get; set; }
        public int? TransactionTypeId { get; set; }
    }
}
