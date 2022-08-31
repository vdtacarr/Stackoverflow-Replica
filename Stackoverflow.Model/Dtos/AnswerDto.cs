using System;
using System.Collections.Generic;
using System.Text;

namespace Stackoverflow.Model.Dtos
{
    public class AnswerDto
    {
        public string TextField { get; set; }
        public int QuestionID { get; set; }
        public int ID { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
