using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.DataAccess.Entities
{
    public class AnswerVariant
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
                
        public Question Question { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

    }
}
