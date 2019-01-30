using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
        public class ContactName
        {
            public string name { get; set; }
            public string id { get; set; }
        }

        public class Deal
        {
            public Lambda Owner { get; set; }
            public object Description { get; set; }
            public string currency_symbol { get; set; }
            public object Campaign_Source { get; set; }
            public object followers { get; set; }
            public string Closing_Date { get; set; }
            public object Last_Activity_Time { get; set; }
            public Lambda Modified_By { get; set; }
            public object Lead_Conversion_Time { get; set; }
            public bool process_flow { get; set; }
            public string Deal_Name { get; set; }
            public int Expected_Revenue { get; set; }
            public object Overall_Sales_Duration { get; set; }
            public string Stage { get; set; }
            public Lambda Account_Name { get; set; }
            public string id { get; set; }
            public bool approved { get; set; }
            public Approval approval { get; set; }
            public DateTime Modified_Time { get; set; }
            public DateTime Created_Time { get; set; }
            public int Amount { get; set; }
            public bool followed { get; set; }
            public int Probability { get; set; }
            public object Next_Step { get; set; }
            public bool editable { get; set; }
            public object Prediction_Score { get; set; }
            public ContactName Contact_Name { get; set; }
            public object Sales_Cycle_Duration { get; set; }
            public string Type { get; set; }
            public object Lead_Source { get; set; }
            public Lambda Created_By { get; set; }
            public IList<object> Tag { get; set; }
    }
}