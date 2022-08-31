using System;
using System.Collections.Generic;
using System.Text;

namespace Stackoverflow.Model.Dtos
{
    public class QuestionDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<AnswerDto> answers { get; set; }
    }

}
