using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{



    public class Accounts
    {
        public List<Account> AccountsList { get; set; }
    }

    public class Account
    {
        public Lambda Owner { get; set; }
        public string Ownership { get; set; }
        public object Description { get; set; }
        public string currency_symbol { get; set; }
        public string Account_Type { get; set; }
        public object Rating { get; set; }
        public int SIC_Code { get; set; }
        public object Shipping_State { get; set; }
        public object Website { get; set; }
        public int Employees { get; set; }
        public DateTime Last_Activity_Time { get; set; }
        public string Industry { get; set; }
        public object Record_Image { get; set; }
        public Lambda Modified_By { get; set; }
        public object Account_Site { get; set; }
        public bool process_flow { get; set; }
        public string Phone { get; set; }
        public object Billing_Country { get; set; }
        public string Account_Name { get; set; }
        public string id { get; set; }
        public string Account_Number { get; set; }
        public bool approved { get; set; }
        public object Ticker_Symbol { get; set; }
        public Approval approval { get; set; }
        public DateTime Modified_Time { get; set; }
        public string Billing_Street { get; set; }
        public DateTime Created_Time { get; set; }
        public bool editable { get; set; }
        public object Billing_Code { get; set; }
        public object Parent_Account { get; set; }
        public object Shipping_City { get; set; }
        public object Shipping_Country { get; set; }
        public object Shipping_Code { get; set; }
        public string Billing_City { get; set; }
        public string Billing_State { get; set; }
        public IList<object> Tag { get; set; }
        public Lambda Created_By { get; set; }
        public object Fax { get; set; }
        public int Annual_Revenue { get; set; }
        public object Shipping_Street { get; set; }
    }
}