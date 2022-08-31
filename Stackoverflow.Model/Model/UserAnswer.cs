using Stackoverflow.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stackoverflow.Model.Model
{
    [Table("UserAnswer")]
    public class UserAnswer:BaseEntity
    {
       
        public int UserID { get; set; }
        public int AnswerID { get; set; }
        [ForeignKey("UserID")]
        public virtual User user { get; set; }
        [ForeignKey("AnswerID")]
        public virtual Answer answer { get; set; }
    }
}
