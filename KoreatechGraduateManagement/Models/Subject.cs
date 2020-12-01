using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public int Semester { get; set; }

        public String SubjectCode { get; set; }

        public String ClassNumber { get; set; }

        public String SubjectType { get; set; }

        public String Target { get; set; }

        public String ClassTime { get; set; }

        public int Credit { get; set; }
    }
}
