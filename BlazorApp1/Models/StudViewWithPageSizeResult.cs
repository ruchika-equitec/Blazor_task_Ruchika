﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public partial class StudViewWithPageSizeResult
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string EmailID { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Skills { get; set; }
        public int Fees { get; set; }
    }
}
