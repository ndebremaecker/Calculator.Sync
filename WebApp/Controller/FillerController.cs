using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using WebApp.Models;

namespace WebApp.Controller
{
    public class FillerController
    {
        //string connectionString = "Data Source=MSI\\SQLExpress;Initial Catalog=DNN_CT_2;Integrated Security=True";
        string connectionString = "Server=tcp:zoho-ssql.database.windows.net,1433;Initial Catalog=Zoho-DB;Persist Security Info=False;User ID=dnnsa;Password=Zoho!01$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";



        public string AddContacts(List<Contact> contacts)
        {
            string msg = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (Contact c in contacts)
                {
                    using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateContact", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Owner", SqlDbType.BigInt).Value = c.Owner.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = c.Email ?? Convert.DBNull;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = c.Description ?? Convert.DBNull;
                        cmd.Parameters.Add("@currency_symbol", SqlDbType.NVarChar).Value = c.currency_symbol ?? Convert.DBNull;
                        cmd.Parameters.Add("@Vendor_Name", SqlDbType.BigInt).Value = isObjectNull(c.Vendor_Name);
                        cmd.Parameters.Add("@Mailing_Zip", SqlDbType.NVarChar).Value = c.Mailing_Zip ?? Convert.DBNull;
                        cmd.Parameters.Add("@Other_Phone", SqlDbType.NVarChar).Value = c.Other_Phone ?? Convert.DBNull;
                        cmd.Parameters.Add("@Mailing_State", SqlDbType.NVarChar).Value = c.Mailing_State ?? Convert.DBNull;
                        cmd.Parameters.Add("@Twitter", SqlDbType.NVarChar).Value = c.Twitter ?? Convert.DBNull;
                        cmd.Parameters.Add("@Other_Zip", SqlDbType.NVarChar).Value = c.Other_Zip ?? Convert.DBNull;
                        cmd.Parameters.Add("@Mailing_Street", SqlDbType.NVarChar).Value = c.Mailing_Street ?? Convert.DBNull;
                        cmd.Parameters.Add("@Other_State", SqlDbType.NVarChar).Value = c.Other_State ?? Convert.DBNull;
                        cmd.Parameters.Add("@Salutation", SqlDbType.NVarChar).Value = c.Salutation ?? Convert.DBNull;
                        cmd.Parameters.Add("@Other_Country", SqlDbType.NVarChar).Value = c.Other_Country ?? Convert.DBNull;
                        cmd.Parameters.Add("@Last_Activity_Time", SqlDbType.DateTime).Value = c.Last_Activity_Time ?? Convert.DBNull;
                        cmd.Parameters.Add("@First_Name", SqlDbType.NVarChar).Value = c.First_Name ?? Convert.DBNull;
                        cmd.Parameters.Add("@Full_Name", SqlDbType.NVarChar).Value = c.Full_Name ?? Convert.DBNull;
                        cmd.Parameters.Add("@Asst_Phone", SqlDbType.NVarChar).Value = c.Asst_Phone ?? Convert.DBNull;
                        cmd.Parameters.Add("@Record_Image", SqlDbType.NVarChar).Value = c.Record_Image ?? Convert.DBNull;
                        cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = c.Department ?? Convert.DBNull;
                        cmd.Parameters.Add("@Modified_By", SqlDbType.BigInt).Value = c.Modified_By.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Skype_ID", SqlDbType.NVarChar).Value = c.Skype_ID ?? Convert.DBNull;
                        cmd.Parameters.Add("@process_flow", SqlDbType.Bit).Value = c.process_flow;
                        cmd.Parameters.Add("@Assistant", SqlDbType.NVarChar).Value = c.Assistant ?? Convert.DBNull;
                        cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = c.Phone ?? Convert.DBNull;
                        cmd.Parameters.Add("@Mailing_Country", SqlDbType.NVarChar).Value = c.Mailing_Country ?? Convert.DBNull;
                        cmd.Parameters.Add("@Account_Name", SqlDbType.BigInt).Value = isObjectNull(c.Account_Name);
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = c.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Email_Opt_Out", SqlDbType.Bit).Value = c.Email_Opt_Out;
                        cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = c.approved;
                        cmd.Parameters.Add("@Reporting_To", SqlDbType.BigInt).Value = isObjectNull(c.Reporting_To);
                        if (c.approval != null)
                            cmd.Parameters.Add("@approval", SqlDbType.BigInt).Value = c.id;
                        else
                            cmd.Parameters.Add("@approval", SqlDbType.BigInt).Value = Convert.DBNull;
                        cmd.Parameters.Add("@Modified_Time", SqlDbType.DateTime).Value = c.Modified_Time;
                        cmd.Parameters.Add("@Date_of_Birth", SqlDbType.NVarChar).Value = c.Date_of_Birth ?? Convert.DBNull;
                        cmd.Parameters.Add("@Mailing_City", SqlDbType.NVarChar).Value = c.Mailing_City ?? Convert.DBNull;
                        cmd.Parameters.Add("@Other_City", SqlDbType.NVarChar).Value = c.Other_City ?? Convert.DBNull;
                        cmd.Parameters.Add("@Created_Time", SqlDbType.DateTime).Value = c.Created_Time;
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = c.Title ?? Convert.DBNull;
                        cmd.Parameters.Add("@editable", SqlDbType.Bit).Value = c.editable;
                        cmd.Parameters.Add("@Other_Street", SqlDbType.NVarChar).Value = c.Other_Street ?? Convert.DBNull;
                        cmd.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = c.Mobile ?? Convert.DBNull;
                        cmd.Parameters.Add("@Home_Phone", SqlDbType.NVarChar).Value = c.Home_Phone ?? Convert.DBNull;
                        cmd.Parameters.Add("@Last_Name", SqlDbType.NVarChar).Value = c.Last_Name ?? Convert.DBNull;
                        cmd.Parameters.Add("@Lead_Source", SqlDbType.NVarChar).Value = c.Lead_Source ?? Convert.DBNull;
                        cmd.Parameters.Add("@Created_By", SqlDbType.BigInt).Value = c.Created_By.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = c.Fax ?? Convert.DBNull;
                        cmd.Parameters.Add("@Secondary_Email", SqlDbType.NVarChar).Value = c.Secondary_Email ?? Convert.DBNull;


                        try
                        {
                            cmd.ExecuteNonQuery();
                            msg = "success";
                        }
                        catch (SqlException e)
                        {
                            msg += e.ToString() + "</br>";
                        }


                    }

                    if (c.approval != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateApproval", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = c.id ?? Convert.DBNull;
                            cmd.Parameters.Add("@delegate", SqlDbType.Bit).Value = c.approval._delegate;
                            cmd.Parameters.Add("@approve", SqlDbType.Bit).Value = c.approval.approve;
                            cmd.Parameters.Add("@reject", SqlDbType.Bit).Value = c.approval.reject;
                            cmd.Parameters.Add("@resubmit", SqlDbType.Bit).Value = c.approval.resubmit;

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException e)
                            {
                                return e.ToString() + "</br>";
                            }
                        }
                    }


                    foreach (PropertyInfo propertyInfo in c.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(Lambda))
                        {
                            Lambda la = (Lambda)propertyInfo.GetValue(c);

                            if (la != null)
                            {
                                using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateLambda", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = la.id ?? Convert.DBNull;
                                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = la.name ?? Convert.DBNull;

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException e)
                                    {
                                        return e.ToString() + "</br>";
                                    }
                                }
                            }
                        }
                    }
                }


                con.Close();
            }

            return msg;

        }

        public string AddProducts(List<Product> products)
        {
            string msg = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (Product p in products)
                {
                    using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateProduct", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Product_Category", SqlDbType.NVarChar).Value = p.Product_Category ?? Convert.DBNull;
                        cmd.Parameters.Add("@Qty_in_Demand", SqlDbType.Int).Value = p.Qty_in_Demand;
                        cmd.Parameters.Add("@Owner", SqlDbType.BigInt).Value = p.Owner.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = p.Description ?? Convert.DBNull;
                        cmd.Parameters.Add("@currency_symbol", SqlDbType.NVarChar).Value = p.currency_symbol ?? Convert.DBNull;
                        cmd.Parameters.Add("@Vendor_Name", SqlDbType.BigInt).Value = isObjectNull(p.Vendor_Name);
                        cmd.Parameters.Add("@Sales_Start_Date", SqlDbType.NVarChar).Value = p.Sales_Start_Date ?? Convert.DBNull;
                        cmd.Parameters.Add("@Product_Active", SqlDbType.Bit).Value = p.Product_Active;
                        cmd.Parameters.Add("@Record_Image", SqlDbType.NVarChar).Value = p.Record_Image ?? Convert.DBNull;
                        cmd.Parameters.Add("@Modified_By", SqlDbType.BigInt).Value = isObjectNull(p.Modified_By);
                        cmd.Parameters.Add("@Product_Code", SqlDbType.NVarChar).Value = p.Product_Code ?? Convert.DBNull;
                        cmd.Parameters.Add("@process_flow", SqlDbType.Bit).Value = p.process_flow;
                        cmd.Parameters.Add("@Manufacturer", SqlDbType.NVarChar).Value = p.Manufacturer ?? Convert.DBNull;
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = p.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Support_Expiry_Date", SqlDbType.NVarChar).Value = p.Support_Expiry_Date ?? Convert.DBNull;
                        cmd.Parameters.Add("@approved", SqlDbType.Bit).Value = p.approved;
                        if (p.approval != null)
                            cmd.Parameters.Add("@approval", SqlDbType.BigInt).Value = p.id;
                        else
                            cmd.Parameters.Add("@approval", SqlDbType.BigInt).Value = Convert.DBNull;
                        cmd.Parameters.Add("@Modified_Time", SqlDbType.DateTime).Value = p.Modified_Time ?? Convert.DBNull;
                        cmd.Parameters.Add("@Created_Time", SqlDbType.DateTime).Value = p.Created_Time;
                        cmd.Parameters.Add("@Commission_Rate", SqlDbType.Int).Value = p.Commission_Rate;
                        cmd.Parameters.Add("@Product_Name", SqlDbType.NVarChar).Value = p.Product_Name ?? Convert.DBNull;
                        cmd.Parameters.Add("@Handler", SqlDbType.BigInt).Value = isObjectNull(p.Handler);
                        cmd.Parameters.Add("@taxable", SqlDbType.Bit).Value = p.taxable;
                        cmd.Parameters.Add("@editable", SqlDbType.Bit).Value = p.editable;
                        cmd.Parameters.Add("@Support_Start_Date", SqlDbType.NVarChar).Value = p.Support_Start_Date ?? Convert.DBNull;
                        cmd.Parameters.Add("@Usage_Unit", SqlDbType.NVarChar).Value = p.Usage_Unit ?? Convert.DBNull;
                        cmd.Parameters.Add("@Qty_Ordered", SqlDbType.Int).Value = p.Qty_Ordered;
                        cmd.Parameters.Add("@Qty_in_Stock", SqlDbType.Int).Value = p.Qty_in_Stock;
                        cmd.Parameters.Add("@Created_By", SqlDbType.BigInt).Value = p.Created_By.id ?? Convert.DBNull;
                        cmd.Parameters.Add("@Sales_End_Date", SqlDbType.NVarChar).Value = p.Sales_End_Date ?? Convert.DBNull;
                        cmd.Parameters.Add("@Unit_Price", SqlDbType.Int).Value = p.Unit_Price;
                        cmd.Parameters.Add("@Taxable2", SqlDbType.Bit).Value = p.Taxable;
                        cmd.Parameters.Add("@Reorder_Level", SqlDbType.Int).Value = p.Reorder_Level;

                        try
                        {
                            cmd.ExecuteNonQuery();
                            msg = "success";
                        }
                        catch (SqlException e)
                        {
                            msg += e.ToString() + "</br>";
                        }


                    }

                    if (p.approval != null)
                    {
                        using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateApproval", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = p.id ?? Convert.DBNull;
                            cmd.Parameters.Add("@delegate", SqlDbType.Bit).Value = p.approval._delegate;
                            cmd.Parameters.Add("@approve", SqlDbType.Bit).Value = p.approval.approve;
                            cmd.Parameters.Add("@reject", SqlDbType.Bit).Value = p.approval.reject;
                            cmd.Parameters.Add("@resubmit", SqlDbType.Bit).Value = p.approval.resubmit;

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException e)
                            {
                                return e.ToString() + "</br>";
                            }
                        }
                    }


                    foreach (PropertyInfo propertyInfo in p.GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType == typeof(Lambda))
                        {
                            Lambda la = (Lambda)propertyInfo.GetValue(p);

                            if (la != null)
                            {
                                using (SqlCommand cmd = new SqlCommand("dnn_Calculator_CreateLambda", con))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = la.id ?? Convert.DBNull;
                                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = la.name ?? Convert.DBNull;

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                    catch (SqlException e)
                                    {
                                        return e.ToString() + "</br>";
                                    }
                                }
                            }
                        }
                    }
                }


                con.Close();
            }

            return msg;

        }

        private Object isObjectNull(Lambda ob)
        {
            if (ob != null)
                return ob.id;
            else
                return Convert.DBNull;
        }


        public string PushContacts()
        {
            string msg = "";
            List<Contact> contacts = GetContacts(GetLambdas());

            msg = JsonConvert.SerializeObject(contacts);

            return msg;
        }


        private List<Contact> GetContacts(List<Lambda> lambdas)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dnn_Calculator_GetContacts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Contact c = new Contact();
                                c.Owner = lambdas.Find(x => x.id == reader["Owner"].ToString());
                                c.Email = reader["Email"].ToString();
                                c.Description = reader["Description"].ToString();
                                c.currency_symbol = reader["currency_symbol"].ToString();
                                c.Vendor_Name = lambdas.Find(x => x.id == reader["Vendor_Name"].ToString());
                                c.Mailing_Zip = reader["Mailing_Zip"].ToString();
                                c.Other_Phone = reader["Other_Phone"].ToString();
                                c.Mailing_State = reader["Mailing_State"].ToString();
                                c.Twitter = reader["Twitter"].ToString();
                                c.Other_Zip = reader["Other_Zip"].ToString();
                                c.Mailing_Street = reader["Mailing_Street"].ToString();
                                c.Other_State = reader["Other_State"].ToString();
                                c.Salutation = reader["Salutation"].ToString();
                                c.Other_Country = reader["Other_Country"].ToString();
                                //c.Last_Activity_Time = DateTime.Parse(reader["Last_Activity_Time"].ToString());
                                c.First_Name = reader["First_Name"].ToString();
                                c.Full_Name = reader["Full_Name"].ToString();
                                c.Asst_Phone = reader["Asst_Phone"].ToString();
                                c.Record_Image = reader["Record_Image"].ToString();
                                c.Department = reader["Department"].ToString();
                                c.Modified_By = lambdas.Find(x => x.id == reader["Modified_By"].ToString());
                                c.Skype_ID = reader["Skype_ID"].ToString();
                                c.process_flow = bool.Parse(reader["process_flow"].ToString());
                                c.Assistant = reader["Assistant"].ToString();
                                c.Phone = reader["Phone"].ToString();
                                c.Mailing_Country = reader["Mailing_Country"].ToString();
                                c.Account_Name = lambdas.Find(x => x.id == reader["Account_Name"].ToString());
                                c.id = reader["id"].ToString();
                                c.Email_Opt_Out = bool.Parse(reader["Email_Opt_Out"].ToString());
                                c.approved = bool.Parse(reader["approved"].ToString());
                                c.Reporting_To = lambdas.Find(x => x.id == reader["Reporting_To"].ToString());
                                c.Modified_Time = DateTime.Parse(reader["Modified_Time"].ToString());
                                c.Date_of_Birth = reader["Date_of_Birth"].ToString();
                                c.Mailing_City = reader["Mailing_City"].ToString();
                                c.Other_City = reader["Other_City"].ToString();
                                c.Created_Time = DateTime.Parse(reader["Created_Time"].ToString());
                                c.Title = reader["Title"].ToString();
                                c.editable = bool.Parse(reader["editable"].ToString());
                                c.Other_Street = reader["Other_Street"].ToString();
                                c.Mobile = reader["Mobile"].ToString();
                                c.Home_Phone = reader["Home_Phone"].ToString();
                                c.Last_Name = reader["Last_Name"].ToString();
                                c.Lead_Source = reader["Lead_Source"].ToString();
                                c.Created_By = lambdas.Find(x => x.id == reader["Created_By"].ToString());
                                c.Fax = reader["Fax"].ToString();
                                c.Secondary_Email = reader["Secondary_Email"].ToString();
                                contacts.Add(c);
                            }
                        }
                    }
                    catch (SqlException e)
                    {
                        
                    }

                }
                con.Close();
            }

            return contacts;
        }

        private List<Lambda> GetLambdas()
        {
            List<Lambda> list = new List<Lambda>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("dnn_Calculator_GetLambdas", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Lambda l = new Lambda();
                                l.name = reader["name"].ToString();
                                l.id = reader["id"].ToString();
                                list.Add(l);
                            }
                        }
                    }
                    catch (SqlException e)
                    {

                    }
                    con.Close();
                }
                return list;
            }
        }
    }
}