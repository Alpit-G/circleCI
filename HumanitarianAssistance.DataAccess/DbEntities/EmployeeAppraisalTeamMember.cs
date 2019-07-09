using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanitarianAssistance.DataAccess.DbEntities
{
    public class EmployeeAppraisalTeamMember: BaseEntityWithoutId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public int EmployeeAppraisalTeamMemberId { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeAppraisalDetailsId { get; set; }
    }
}
