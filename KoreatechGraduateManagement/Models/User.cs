using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class User
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "올바른 아이디가 아닙니다.")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "4자리 이상 입력해주세요")]
        [DisplayName("아이디")]
        [Required(ErrorMessage = "아이디를 입력해주세요.")]
        public string UserID { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9?=.*!@#$%^&+=]*$", ErrorMessage = "올바른 비밀번호가 아닙니다.")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "8자리 이상 입력해주세요")]
        [DisplayName("비밀번호")]
        [Required(ErrorMessage = "비밀번호를 입력해주세요.")]
        public string UserPassword { get; set; }

        [RegularExpression(@"^[a-zA-Z가-힣]*$", ErrorMessage = "올바른 이름이 아닙니다.")]
        [DisplayName("이름")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "2자리 이상 입력해주세요")]
        [Required(ErrorMessage = "이름을 입력해주세요.")]
        public string Name { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "숫자만 입력 가능합니다.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "10자리를 입력해주세요")]
        [DisplayName("학번")]
        [Required(ErrorMessage = "학번을 입력해주세요.")]
        public string SchoolD { get; set; }

        [DisplayName("학년")]
        [Required]
        public int Grade { get; set; }
        public bool IsAdmin { get; set; }
    }
}
