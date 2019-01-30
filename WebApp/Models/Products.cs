using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Product
    {
        public string Product_Category { get; set; }
        public int Qty_in_Demand { get; set; }
        public Lambda Owner { get; set; }
        public string Description { get; set; }
        public string currency_symbol { get; set; }
        public Lambda Vendor_Name { get; set; }
        public string Sales_Start_Date { get; set; }
        public List<string> Tax { get; set; }
        public bool Product_Active { get; set; }
        public string Record_Image { get; set; }
        public Lambda Modified_By { get; set; }
        public string Product_Code { get; set; }
        public bool process_flow { get; set; }
        public string Manufacturer { get; set; }
        public string id { get; set; }
        public string Support_Expiry_Date { get; set; }
        public bool approved { get; set; }
        public Approval approval { get; set; }
        public DateTime? Modified_Time { get; set; }
        public DateTime Created_Time { get; set; }
        public int Commission_Rate { get; set; }
        public string Product_Name { get; set; }
        public Lambda Handler { get; set; }
        public bool taxable { get; set; }
        public bool editable { get; set; }
        public string Support_Start_Date { get; set; }
        public string Usage_Unit { get; set; }
        public int Qty_Ordered { get; set; }
        public int Qty_in_Stock { get; set; }
        public Lambda Created_By { get; set; }
        public List<Lambda> Tag { get; set; }
        public string Sales_End_Date { get; set; }
        public int Unit_Price { get; set; }
        public bool Taxable { get; set; }
        public int Reorder_Level { get; set; }
    }
}