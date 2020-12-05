using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KoreatechGraduateManagement.Models
{
    public class EtcStatusViewModel
    {
        public List<EtcStatusInfo> EtcStatusInfos { get; set; }
    }

    public class EtcStatusInfo : EtcStatus
    {
        [DisplayName("사용자 아이디")]
        public String UserName {get; set; }
    }
}
