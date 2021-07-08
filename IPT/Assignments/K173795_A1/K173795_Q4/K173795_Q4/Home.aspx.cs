using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Xml.Serialization;

namespace K173795_Q4
{
    public partial class Home : Page
    {
        string outputDirPath = ConfigurationManager.AppSettings["outputDirPath"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Directory.Exists(outputDirPath))
                {
                    var categoryName = new List<string>(File.ReadAllLines(outputDirPath + "CategoryName.txt"));
                    categoryName.Sort();
                    string[] subdirectoryEntries = Directory.GetDirectories(outputDirPath);

                    Dictionary<string, string> list = new Dictionary<string, string>();


                    for (int i = 0; i < categoryName.Count; i++)
                    {
                        list.Add(new DirectoryInfo(subdirectoryEntries[i]).Name, categoryName[i]);
                    }

                    DropDownList1.DataSource = list;
                    DropDownList1.DataTextField = "Value";
                    DropDownList1.DataValueField = "Key";
                    DropDownList1.DataBind();
                    DropDownList1.SelectedIndex = 0;
                    onSelect(sender, e);
                }
                else
                {
                    string message = "Output Directory Not Found...";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                }
            }

        }
        protected void onSelect(object sender, EventArgs e)
        {
            string value = DropDownList1.SelectedValue;

            DirectoryInfo dir = new DirectoryInfo(outputDirPath + value);
            var filePath = dir.GetFiles().OrderByDescending(f => f.LastWriteTime).First().Name;
            filePath = outputDirPath + value + "\\" + filePath;
            XmlRootAttribute root = new XmlRootAttribute("xml");
            XmlSerializer ser = new XmlSerializer(typeof(List<Scripts>), root);

            using (StreamReader sr = new StreamReader(filePath))
            {
                List<Scripts> sp = (List<Scripts>)ser.Deserialize(sr);
                GridView2.DataSource = sp;
                GridView2.DataBind();


            }
        }
        protected void onRefresh(object sender, EventArgs e)
        {



        }

        public class Scripts
        {
            public string Script { get; set; }
            public string Price { get; set; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            onSelect(sender, e);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}