using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [DisplayName("과목명")]
        public String SubjectName { get; set; }

        [DisplayName("학기")]
        public String Semester { get; set; }

        [DisplayName("과목 코드")]
        public String SubjectCode { get; set; }

        [DisplayName("분반")]
        public String ClassNumber { get; set; }

        [DisplayName("대표이수구분")]
        public String SubjectType { get; set; }

        [DisplayName("대상학부(과)")]
        public String Target { get; set; }

        [DisplayName("강의시간")]
        public String ClassTime { get; set; }

        [DisplayName("학점")]
        public int Credit { get; set; }
    }
}
