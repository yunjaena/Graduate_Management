﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class Status
    {
        public int Id { get; set; }

        [DisplayName("회원 ID")]
        public int UserID { get; set; }

        [DisplayName("과목 ID")]
        public int SubjectID { get; set; }
    }
}
