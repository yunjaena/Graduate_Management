using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class EtcStatus
    {
        public int Id { get; set; }

        [DisplayName("사용자 ID")]
        public String UserID { get; set; }

        [DisplayName("IPP 이수여부")]
        public bool IsIPPFinish { get; set; }

        [DisplayName("기술 자격증 취득 여부")]
        public bool IsEngineerCertificationFinish { get; set; }

        [DisplayName("영어 자격증 취득 여부")]
        public bool IsEnglishCertificationFinish { get; set; }
    }
}
