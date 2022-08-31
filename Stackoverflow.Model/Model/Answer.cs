using Stackoverflow.Model.Base;
using Stackoverflow.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Stackoverflow.Model
{
    [Table("Answer")]
    public class Answer : BaseEntity
    {
        public string TextField { get; set;}
        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
