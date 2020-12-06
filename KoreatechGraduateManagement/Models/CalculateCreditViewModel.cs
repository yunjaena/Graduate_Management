using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class CalculateCreditViewModel
    {
       public GraduateCredit GraduateCredit { get; set; }

       public EtcStatus EtcStatus { get; set; }

        /*
         * 사용자 이수학점
         */

        public int UserTotalGraduateCredit { get; set; }

        public int UserElectivesNormalCredit { get; set; }

        public int UserElectivesNecessaryCredit { get; set; }

        public int UserCoreClassNormalCredit { get; set; }

        public int UserCoreClassNecessaryCredit { get; set; }

        public int UserHRDNormalCredit { get; set; }

        public int UserHRDClassNecessaryCredit { get; set; }

        public int UserMSCNormalCredit { get; set; }

        public int UserMSCNecessaryCredit { get; set; }

        public int UserFreeCredit { get; set; }

        public string GraduateValidString { get; set; }

    }
}
