using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoreatechGraduateManagement.Data;
using KoreatechGraduateManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/**
 * 졸업에 필요한 학점 및 기타 조건들을 조회하는 Controller 
 */
namespace KoreatechGraduateManagement.Controllers
{
    public class CalculateCreditController : Controller
    {

        private readonly MvcGraduateManagmentContext _context;

        public CalculateCreditController(MvcGraduateManagmentContext context)
        {
            _context = context;
        }

        /**
         * 로그인이 되어있는 경우 가입자의 학번을보고 이수학점을 계산해서 보여주는 View를 반환한다.
         */
        public IActionResult Index()
        {
            int userTotalGraduateCredit = 0;
            int userElectivesNormalCredit = 0;
            int userElectivesNecessaryCredit = 0;
            int userCoreClassNormalCredit = 0;
            int userCoreClassNecessaryCredit = 0;
            int userHRDNormalCredit = 0;
            int userHRDClassNecessaryCredit = 0;
            int userMSCNormalCredit = 0;
            int userMSCNecessaryCredit = 0;
            int userFreeCredit = 0;
            string graduateValidString = "";

            var userID = HttpContext.Session.GetInt32("Id");
            var user = _context.User.Where(s => s.Id.Equals(userID)).FirstOrDefault();
            if (user == null || HttpContext.Session.GetString("Authorize") == null)
            {
                return NoContent();
            }

            var enteranceYear = user.SchoolD.Substring(0, 4);
            var status = _context.Status.Where(s => s.UserID.Equals(userID)).ToList();
            var etcStatus = _context.EtcStatus.Where(s => s.UserID.Equals(userID)).FirstOrDefault();
            var graduateCredit = _context.GraduateCredit.Where(s => s.EntranceYear.Equals(enteranceYear)).FirstOrDefault();

            foreach (var s in status)
            {
                Subject selectSubject = _context.Subject.Where(t => t.Id.Equals(s.SubjectID)).FirstOrDefault();
                string selectSubjectType = selectSubject.SubjectType;
                userTotalGraduateCredit += selectSubject.Credit;
                switch (selectSubjectType)
                {
                    case "핵심교양필수":
                        userElectivesNecessaryCredit += selectSubject.Credit;
                        break;
                    case "일반교양선택":
                        userElectivesNormalCredit += selectSubject.Credit;
                        break;
                    case "학과(전공)필수":
                        userCoreClassNecessaryCredit += selectSubject.Credit;
                        break;
                    case "학과(전공)선택":
                        userCoreClassNormalCredit += selectSubject.Credit;
                        break;
                    case "HRD필수":
                        userHRDClassNecessaryCredit += selectSubject.Credit;
                        break;
                    case "HRD선택":
                        userHRDNormalCredit += selectSubject.Credit;
                        break;
                    case "MSC필수":
                        userMSCNecessaryCredit += selectSubject.Credit;
                        break;
                    case "MSC선택":
                        userMSCNormalCredit += selectSubject.Credit;
                        break;
                    default:
                        userFreeCredit += selectSubject.Credit;
                        break;
                }
            }

            if(IsGraudatePossible(graduateCredit, etcStatus, status))
            {
                graduateValidString = "졸업 가능합니다.";
            }
            else
            {
                graduateValidString = "이수학점 또는 기타 졸업 조건을 충족하지 못했습니다.";
            }

            var calculateViewModel = new CalculateCreditViewModel
            {
                GraduateCredit = graduateCredit,
                EtcStatus = etcStatus,
                GraduateValidString = graduateValidString,
                UserTotalGraduateCredit = userTotalGraduateCredit,
                UserElectivesNormalCredit  = userElectivesNormalCredit,
                UserElectivesNecessaryCredit = userElectivesNecessaryCredit,
                UserCoreClassNormalCredit = userCoreClassNormalCredit,
                UserCoreClassNecessaryCredit = userCoreClassNecessaryCredit,
                UserHRDNormalCredit = userHRDNormalCredit,
                UserHRDClassNecessaryCredit = userHRDClassNecessaryCredit,
                UserMSCNormalCredit= userMSCNormalCredit,
                UserMSCNecessaryCredit = userMSCNecessaryCredit,
                UserFreeCredit = userFreeCredit
            };

            return View(calculateViewModel);
        }

        public bool IsGraudatePossible(GraduateCredit graduateCredit, EtcStatus etcStatus, List<Status> statusList)
        {
            int userTotalGraduateCredit = 0;
            int userElectivesNormalCredit = 0;
            int userElectivesNecessaryCredit = 0;
            int userCoreClassNormalCredit = 0;
            int userCoreClassNecessaryCredit = 0;
            int userHRDNormalCredit = 0;
            int userHRDClassNecessaryCredit = 0;
            int userMSCNormalCredit = 0;
            int userMSCNecessaryCredit = 0;
            int userFreeCredit = 0;

            foreach (var s in statusList)
            {
                Subject selectSubject = _context.Subject.Where(t => t.Id.Equals(s.SubjectID)).FirstOrDefault();
                string selectSubjectType = selectSubject.SubjectType;
                userTotalGraduateCredit += selectSubject.Credit;
                switch (selectSubjectType)
                {
                    case "핵심교양필수":
                        userElectivesNecessaryCredit += selectSubject.Credit;
                        break;
                    case "일반교양선택":
                        userElectivesNormalCredit += selectSubject.Credit;
                        break;
                    case "학과(전공)필수":
                        userCoreClassNecessaryCredit += selectSubject.Credit;
                        break;
                    case "학과(전공)선택":
                        userCoreClassNormalCredit += selectSubject.Credit;
                        break;
                    case "HRD필수":
                        userHRDClassNecessaryCredit += selectSubject.Credit;
                        break;
                    case "HRD선택":
                        userHRDNormalCredit += selectSubject.Credit;
                        break;
                    case "MSC필수":
                        userMSCNecessaryCredit += selectSubject.Credit;
                        break;
                    case "MSC선택":
                        userMSCNormalCredit += selectSubject.Credit;
                        break;
                    default:
                        userFreeCredit += selectSubject.Credit;
                        break;
                }
            }

            if(userElectivesNecessaryCredit >= graduateCredit.ElectivesNecessaryCredit &&
                userElectivesNormalCredit >= graduateCredit.ElectivesNormalCredit &&
                userCoreClassNecessaryCredit >= graduateCredit.CoreClassNecessaryCredit &&
                userCoreClassNormalCredit >= graduateCredit.CoreClassNormalCredit &&
                userHRDClassNecessaryCredit >= graduateCredit.HRDClassNecessaryCredit &&
                userHRDNormalCredit >= graduateCredit.HRDNormalCredit &&
                userMSCNecessaryCredit >= graduateCredit.MSCNecessaryCredit &&
                userMSCNormalCredit >= graduateCredit.MSCNormalCredit &&
                userFreeCredit >= graduateCredit.FreeCredit &&
                etcStatus.IsEngineerCertificationFinish &&
                etcStatus.IsEnglishCertificationFinish &&
                etcStatus.IsIPPFinish
                )
            {
                return true;
            }

            return false;
        }
    }
}