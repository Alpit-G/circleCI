//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using HumanitarianAssistance.DataAccess.DbEntities.Project;

//namespace HumanitarianAssistance.DataAccess
//{
//	public partial class ProjectBudget : BaseEntityWithoutId
//	{
//		[Key]
//		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//		[Column(Order = 1)]
//		public long BudgetId { get; set; }
//		public long ProjectId { get; set; }
//		public ProjectDetails ProjectDetails { get; set; }		
//		public double ReceivableAmount { get; set; }
//		public double PayableAmount { get; set; }
//		public double CurrentBalance { get; set; }
//		public DateTime StartDate { get; set; }
//		public DateTime EndDate { get; set; }
//	}
//}
