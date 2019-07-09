using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HumanitarianAssistance.DataAccess.DbEntities.Project
{
    public class ProjectIndicators : BaseEntityWithoutId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public long ProjectIndicatorId { get; set; }
        public string IndicatorName { get; set; }
        public string IndicatorCode { get; set; }
        public List<ProjectIndicatorQuestions> ProjectIndicatorQuestions { get; set; }
    }
}
