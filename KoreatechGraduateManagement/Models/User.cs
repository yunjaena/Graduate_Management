using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("아이디")]
        public string UserID { get; set; }
        [DisplayName("비밀번호")]
        public string UserPassword { get; set; }
        [DisplayName("이름")]
        public string Name { get; set; }
        [DisplayName("학번")]
        public string SchoolD { get; set; }
        [DisplayName("학년")]
        public int Grade { get; set; }
        public bool IsAdmin { get; set; }
    }
}
