using System;
using System.ComponentModel;

namespace KoreatechGraduateManagement.Models
{
    public class GraduateCredit
    {
        public int Id { get; set; }

        [DisplayName("입학년도")]
        public String EntranceYear { get; set; }

        [DisplayName("졸업학점")]
        public int TotalGraduateCredit { get; set; }

        [DisplayName("교양이수학점")]
        public int ElectivesNormalCredit { get; set; }

        [DisplayName("교양필수이수학점")]
        public int ElectivesNecessaryCredit { get; set; }

        [DisplayName("전공이수학점")]
        public int CoreClassNormalCredit { get; set; }

        [DisplayName("전공필수이수학점")]
        public int CoreClassNecessaryCredit { get; set; }

        [DisplayName("HRD이수학점")]
        public int HRDNormalCredit { get; set; }

        [DisplayName("HRD필수이수학점")]
        public int HRDClassNecessaryCredit { get; set; }

        [DisplayName("MSC이수학점")]
        public int MSCNormalCredit { get; set; }

        [DisplayName("MSC필수이수학점")]
        public int MSCNecessaryCredit { get; set; }

        [DisplayName("자유이수학점")]
        public int FreeCredit { get; set; }

    }
}
