using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<string> AnswerVariants { get; set; }
        public string Comment { get; set; }
        public int? SurveyId { get; set; }

    }
}
