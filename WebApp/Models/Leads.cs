using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Leads
    {
        public List<Lead> leadsList { get; set; }
    }

    public class Lead
    {
        public Lambda Owner { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public object Description { get; set; }
        public string currency_symbol { get; set; }
        public object Rating { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }
        public string Salutation { get; set; }
        public object Last_Activity_Time { get; set; }
        public string First_Name { get; set; }
        public string Full_Name { get; set; }
        public string Lead_Status { get; set; }
        public string Industry { get; set; }
        public object Record_Image { get; set; }
        public Lambda Modified_By { get; set; }
        public string Skype_ID { get; set; }
        public bool converted { get; set; }
        public bool process_flow { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Zip_Code { get; set; }
        public string id { get; set; }
        public bool Email_Opt_Out { get; set; }
        public bool approved { get; set; }
        public string Designation { get; set; }
        public Approval approval { get; set; }
        public DateTime Modified_Time { get; set; }
        public DateTime Created_Time { get; set; }
        public ConvertedDetail converted_detail { get; set; }
        public bool editable { get; set; }
        public string City { get; set; }
        public int No_of_Employees { get; set; }
        public string Mobile { get; set; }
        public object Prediction_Score { get; set; }
        public string Last_Name { get; set; }
        public string State { get; set; }
        public string Lead_Source { get; set; }
        public string Country { get; set; }
        public IList<object> Tag { get; set; }
        public Lambda Created_By { get; set; }
        public object Fax { get; set; }
        public int Annual_Revenue { get; set; }
        public object Secondary_Email { get; set; }
    }

    public class ConvertedDetail
    {
    }

}