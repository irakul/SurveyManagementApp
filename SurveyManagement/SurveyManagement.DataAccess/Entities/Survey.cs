using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.DataAccess.Entities
{
    public class Survey
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Creator { get; set; }

        public List<Question> Questions { get; set; }

    }
}
