using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Controller;
using WebApp.Models;

namespace WebApp
{
    public partial class Page : System.Web.UI.Page
    {
        static Uri path = new Uri("https://crm.zoho.com/crm/v2/functions/all/actions/execute?auth_type=apikey&zapikey=1003.3ca2b46a90779d4887e7bad33caf5e87.baafb83386598840fa6627ae3ece8de9");
        static HttpClient client = new HttpClient();
        Output output;
        Data data;

        public class Details
        {
            public string output { get; set; }
            public string output_type { get; set; }
            public string id { get; set; }
        }

        public class Output
        {
            public string code { get; set; }
            public Details details { get; set; }
            public string message { get; set; }
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                output = await GetResult(path);
                CallSelectFunction(selectFunction.Value.ToString(), selectObject.Value.ToString());
            }
        }

        private void CallSelectFunction(string functionTarget, string objectTarget)
        {
            switch(functionTarget)
            {
                case ("name"):
                    PrintName(objectTarget);
                    break;

                case ("SQL"):
                    PrintSQL(objectTarget);
                    break;

                case ("SQLnames"):
                    PrintSQLnames(objectTarget);
                    break;

                case ("PrintSQLnamesWithType"):
                    PrintSQLnamesWithType(objectTarget);
                    break;

                case ("PrintSQLProc"):
                    PrintSQLProc(objectTarget);
                    break;

                case ("PrintASPColumn"):
                    PrintASPColumn(objectTarget);
                    break;

                case ("PrintSQLUpdate"):
                    PrintSQLUpdate(objectTarget);
                    break;

                case ("PrintASPEdit"):
                    PrintASPEdit(objectTarget);
                    break;

                case ("PrintEditCsharp"):
                    PrintEditCsharp(objectTarget);
                    break;

                case ("PrintCreate"):
                    PrintCreate(objectTarget);
                    break;

                case ("PrintSQLReader"):
                    PrintSQLReader(objectTarget);
                    break;

                default:
                    apiMessage.InnerHtml = "Error";
                    break;

            }
        }


        protected void Con_UpdateData_Click(object sender, EventArgs e)
        {
            AddItem("Contact");
        }

        protected void Prod_UpdateData_Click(object sender, EventArgs e)
        {
            AddItem("Product");
        }

        protected void All_Update_Click(object sender, EventArgs e)
        {
            AddItem("Product");
            AddItem("Contact");
        }

        protected void All_Click(object sender, EventArgs e)
        { 
            PrintResult();
        }

        protected void Push_Contact_Click(object sender, EventArgs e)
        {
            PushData("Contact");
        }




        void PrintObjects()
        {
            data = JsonConvert.DeserializeObject<Data>(output.details.output);
            apiMessage.InnerHtml += " <br/>";
            foreach (Contact c in data.Contacts)
            {
                apiMessage.InnerHtml += c.Email + " " + c.First_Name;
            }
        }

        void PrintObject(string name)
        {
            data = JsonConvert.DeserializeObject<Data>(output.details.output);
            switch (name) {
                case "Contact":
                    foreach (Contact c in data.Contacts)
                    {
                        apiMessage.InnerHtml += c.Email + " " + c.First_Name + " * ";
                    }
                    break;


                case "Product":
                    foreach (Product p in data.Products)
                    {
                        apiMessage.InnerHtml += " / " + p.Product_Code;
                    }
                    break;

                default:
                    apiMessage.InnerHtml = "not found";
                    break;
            }
        }

        void PrintResult()
        {
            apiMessage.InnerHtml = output.details.output;
        }


        static async Task<Output> GetResult(Uri path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Output>();
            }
            return null;
        }

        void PrintSQL(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += propertyInfo.Name + "  " + propertyInfo.PropertyType.ToString() + " NULL, </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += propertyInfo.Name + "  " + propertyInfo.PropertyType.ToString() + " NULL, </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            result = CsharpToSQL(result);


            apiMessage.InnerHtml = result;
        }

        void PrintASPColumn(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "&lt;asp:BoundColumn DataField=\"" + propertyInfo.Name + "\" </br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HeaderText=\"" + propertyInfo.Name + "\" &gt;&lt;/asp:BoundColumn&gt; </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "&lt;asp:BoundColumn DataField=\"" + propertyInfo.Name + "\" </br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HeaderText=\"" + propertyInfo.Name + "\" &gt;&lt;/asp:BoundColumn&gt; </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            apiMessage.InnerHtml = result;
        }

        void PrintSQLUpdate(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "[" + propertyInfo.Name + "] = @" + propertyInfo.Name + ", <br />";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "[" + propertyInfo.Name + "] = @" + propertyInfo.Name + ", <br />";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            apiMessage.InnerHtml = result;
        }

        void PrintEditCsharp(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += propertyInfo.Name + "TextBox.Text = contact." + propertyInfo.Name + "; <br />";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += propertyInfo.Name + "TextBox.Text = product." + propertyInfo.Name + "; <br />";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            apiMessage.InnerHtml = result;
        }

        void PrintCreate(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        if(propertyInfo.PropertyType != typeof(string))
                            result += propertyInfo.Name + " = " + propertyInfo.PropertyType.ToString() + ".Parse(" + propertyInfo.Name + "TextBox.Text), <br />";
                        else
                            result += propertyInfo.Name + " = " + propertyInfo.Name + "TextBox.Text, <br />";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        if (propertyInfo.PropertyType != typeof(string))
                            result += propertyInfo.Name + " = " + propertyInfo.PropertyType.ToString() + ".Parse(" + propertyInfo.Name + "TextBox.Text), <br />";
                        else
                            result += propertyInfo.Name + " = " + propertyInfo.Name + "TextBox.Text, <br />";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            result = result.Replace("System.", "");
            result = result.Replace("WebApp.Models.Lambda", "Int64");

            apiMessage.InnerHtml = result;
        }

        void PrintASPEdit(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "&lt;div class=\"dnnFormItem\"&gt; </br> &nbsp;&nbsp;&nbsp; &lt;div class=\"dnnLabel\"&gt; </br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label ID=\"" + propertyInfo.Name + "Label\" runat=\"server\" Text=\"" + propertyInfo.Name + ": \"&gt; &lt;/asp:Label&gt; </br> &nbsp;&nbsp;&nbsp; &lt;/div&gt; </br> &nbsp;&nbsp;&nbsp; &lt;asp:TextBox ID=\"" + propertyInfo.Name + "TextBox\" runat=\"server\" MaxLength=\"200\"&gt; </br> &nbsp;&nbsp;&nbsp; &lt;/asp:TextBox&gt;</br>&lt;/div&gt;</br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "&lt;div class=\"dnnFormItem\"&gt; </br> &nbsp;&nbsp;&nbsp; &lt;div class=\"dnnLabel\"&gt; </br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label ID=\"" + propertyInfo.Name + "Label\" runat=\"server\" Text=\"" + propertyInfo.Name + ": \"&gt; &lt;/asp:Label&gt; </br> &nbsp;&nbsp;&nbsp; &lt;/div&gt; </br> &nbsp;&nbsp;&nbsp; &lt;asp:TextBox ID=\"" + propertyInfo.Name + "TextBox\" runat=\"server\" MaxLength=\"200\"&gt; </br> &nbsp;&nbsp;&nbsp; &lt;/asp:TextBox&gt;</br>&lt;/div&gt;</br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            apiMessage.InnerHtml = result;
        }

        void PrintName(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "c." + propertyInfo.Name + ", </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "p." + propertyInfo.Name + ", </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }


            apiMessage.InnerHtml = result;
        }

        void PrintSQLnames(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "@" + propertyInfo.Name + ", </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "@" + propertyInfo.Name + ", </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }


            apiMessage.InnerHtml = result;
        }

        void PrintSQLnamesWithType(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "@" + propertyInfo.Name + "  " + propertyInfo.PropertyType.ToString() + ", </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "@" + propertyInfo.Name + "  " + propertyInfo.PropertyType.ToString() + ", </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }


            result = CsharpToSQL(result);

            apiMessage.InnerHtml = result;
        }

        void PrintSQLProc(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "cmd.Parameters.Add(\"@" + propertyInfo.Name + "\",  SqlDbType." + propertyInfo.PropertyType.ToString() + ").Value = c." + propertyInfo.Name + " ?? Convert.DBNull; </br>";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "cmd.Parameters.Add(\"@" + propertyInfo.Name + "\",  SqlDbType." + propertyInfo.PropertyType.ToString() + ").Value = c." + propertyInfo.Name + " ?? Convert.DBNull; </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            result = CsharpToSQLProc(result);

            apiMessage.InnerHtml = result;
        }


        string CsharpToSQL(string result)
        {
            result = result.Replace("System.String", "nvarchar(MAX)");
            result = result.Replace("System.Object", "nvarchar(MAX)");
            result = result.Replace("System.Int32", "int");
            result = result.Replace("System.Boolean", "bit");
            result = result.Replace(" System.DateTime", "DateTime");
            result = result.Replace(" System.Nullable`1[System.DateTime] ", " DateTime ");
            result = result.Replace("System.Nullable`1[System.DateTime]", " DateTime");
            result = result.Replace("WebApp.Models.Approval", "bigint");
            result = result.Replace("WebApp.Models.Lambda", "bigint");

            return result;
        }

        string CsharpToSQLProc(string result)
        {
            result = result.Replace("System.String", "NVarChar");
            result = result.Replace("System.Object", "NVarChar");
            result = result.Replace("System.Int32", "Int");
            result = result.Replace("System.Boolean", "Bit");
            result = result.Replace("System.DateTime", "DateTime");
            result = result.Replace(" System.Nullable`1[System.DateTime] ", " DateTime ");
            result = result.Replace("System.Nullable`1[System.DateTime]", " DateTime");
            result = result.Replace("WebApp.Models.Approval", "BigInt");
            result = result.Replace("WebApp.Models.Lambda", "BigInt");

            return result;
        }

        void AddItem(string name)
        {
            FillerController _controller = new FillerController();
            data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    apiMessage.InnerHtml = _controller.AddContacts(data.Contacts);
                    break;

                case "Product":
                    apiMessage.InnerHtml = _controller.AddProducts(data.Products);
                    break;

                default:
                    apiMessage.InnerHtml = "not found";
                    break;
            }
        }

        async void PushData(string name)
        {
            FillerController _controller = new FillerController();

            string JSON = "";

            switch (name)
            {
                case "Contact":
                    JSON = _controller.PushContacts();
                    break;

                //case "Product":
                //    apiMessage.InnerHtml = _controller.PushProducts(data.Products);
                //    break;

                default:
                    apiMessage.InnerHtml = "error";
                    break;
            }

            if(JSON == "")
            {
                apiMessage.InnerHtml = "error in getting datas";
            }
            else
            {
                //output = await callPushApi(JSON);
                apiMessage.InnerHtml = callPushApi(JSON);
            }
        }

        private string callPushApi(string JSON)
        {
            string value = "les";
            var client = new RestClient("https://crm.zoho.com/crm/v2/functions/upsert_contact/actions/execute?auth_type=apikey&zapikey=1003.3ca2b46a90779d4887e7bad33caf5e87.baafb83386598840fa6627ae3ece8de9");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "2fcc1aa8-669f-4b21-b1f5-19f954ffa2eb");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("content-type", "multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW");
            request.AddParameter("multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW", "------WebKitFormBoundary7MA4YWxkTrZu0gW\r\nContent-Disposition: form-data; name=\"JSON\"\r\n\r\n" + value + "\r\n------WebKitFormBoundary7MA4YWxkTrZu0gW--", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            return null;

        }

        void PrintSQLReader(string name)
        {
            string result = "";
            Data data = JsonConvert.DeserializeObject<Data>(output.details.output);

            switch (name)
            {
                case "Contact":
                    foreach (PropertyInfo propertyInfo in data.Contacts.First().GetType().GetProperties())
                    {
                        result += "c." + propertyInfo.Name + " = reader[\"" + propertyInfo.Name + "\"].ToString(); <br />";
                    }
                    break;

                case "Product":
                    foreach (PropertyInfo propertyInfo in data.Products.First().GetType().GetProperties())
                    {
                        result += "cmd.Parameters.Add(\"@" + propertyInfo.Name + "\",  SqlDbType." + propertyInfo.PropertyType.ToString() + ").Value = c." + propertyInfo.Name + " ?? Convert.DBNull; </br>";
                    }
                    break;

                default:
                    result = "nothing";
                    break;
            }

            apiMessage.InnerHtml = result;
        }

    }
}