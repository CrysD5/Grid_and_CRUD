using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Grid_and_CRUD.Models
{
    public class FullSummary
    {
        public partial class AdvisoryNotesViewModel
        {
            [ScaffoldColumn(false)]
            public int nid { get; set; }
            public string emaddr { get; set; }
            [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
            public DateTime edate { get; set; }
            public string adlogin { get; set; }
            public string etitle { get; set; }
            public string enotes { get; set; }
            public string notefile { get; set; }
            public string caseID
            {
                get
                {
                    string emaddr = HttpContext.Current.Session["selectedValue"] == null ? caseID : HttpContext.Current.Session["selectedValue"].ToString();
                    return emaddr;
                }
                set
                {
                    HttpContext.Current.Session["selectedValue"] = value;
                }
            }

            public string deanID
            {
                get
                {
                    string adlogin = HttpContext.Current.Session["username"] == null ? deanID : HttpContext.Current.Session["username"].ToString();
                    return adlogin;
                }
                set
                {
                    HttpContext.Current.Session["selectedValue"] = value;
                }
            }

            //[UIHint("deanID")]
            //    public static string deanID
            //    {
            //        get
            //        {
            //            string userid = (SimpleSSOHelper.username ?? "").Trim();
            //            HttpContext.Current.Session["sesuserid"] = userid;
            //            return (string)userid;
            //        }
            //        set { HttpContext.Current.Session["sesuserid"] = value; }
            //    }
            //}



        }

        public partial class StudentDetails
        {
            public int? Id { get; set; }
            public string caseID { get; set; }
            public string StudentName { get; set; }
            public byte[] SmallStream { get; set; }
            public Guid? BigStream { get; set; }
            public string SmallPicture { get; set; }
            public string BigPicture { get; set; }
            public string StudentPicture { get; set; }
            public string sPic { get; set; }
            public string lPic { get; set; }
            /*public string SocietyDean { get; set; }

            public string Notes { get; set; }*/
            public string Society { get; set; }
            public int? blk1 { get; set; }
            public int? blk2 { get; set; }
            public int? blk3 { get; set; }
            public int? blk4 { get; set; }
            public int? blk5 { get; set; }
            public int? blk6 { get; set; }
            public string CAT { get; set; }
            public string MEDC { get; set; }
            public string NSCI { get; set; }
            public string OBGC { get; set; }
            public string PEDC { get; set; }
            public string PSYC { get; set; }
            public string SURC { get; set; }
            public string AGEC { get; set; }
            public string EMGC { get; set; }
            public string Step1 { get; set; }
            public string Step2Cs { get; set; }
            public string Step2Ck { get; set; }
            public int gradecode { get; set; }
        }
   
        public  partial class DropDownLists
        {
            public int? gyr { get; set; }
            public string campuscode { get; set; }
            public string Prog_status { get; set; }
            public string selectedgyr { get; set; }
            
            public List<SelectListItem> society { get; set; }
            public string SelectedSociety { get; set; }
            public string SocietyName { get; set; }
        }
        
        public partial class RosterReports
        {
            public string RostReport { get; set; }
            public int? rostRepId { get; set; }
            public int? parentId { get; set; }
            public bool hasChildren { get; set; }

        }
    }
}