using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class SubjectViewModel
    {
        public List<Subject> Subjects { get; set; }
        public SelectList Semesters { get; set; }
        public string SubjectName { get; set; }
        public string SubjectSemester { get; set; }
    }
}
