using Stackoverflow.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackoverflow.Model
{
    [Table("Question")]
    public class Question : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Slug { get; set; }
        public int UserID { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
