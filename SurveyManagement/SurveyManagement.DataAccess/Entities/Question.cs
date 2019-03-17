using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.DataAccess.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerVariant> AnswerVariants { get; set; }
        public string Comment { get; set; }

        public Survey Survey { get; set; }

        [ForeignKey("Survey")]
        public int? SurveyId { get; set; }
    }
}
