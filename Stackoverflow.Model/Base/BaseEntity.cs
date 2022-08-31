﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stackoverflow.Model
{
    public abstract class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
