using System;
using System.Collections.Generic;
using System.Text;

namespace Stackoverflow.Model.Dtos
{
    public class UserAnswerDto
    {
        public int UserId { get; set; }
        public Answer answer { get; set; }
    }
}
