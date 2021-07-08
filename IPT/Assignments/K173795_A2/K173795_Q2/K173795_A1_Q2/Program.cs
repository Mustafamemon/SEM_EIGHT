using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Configuration;

namespace K173795_A1_Q2
{

    public class Scripts
    {
        public string Script;
        public double Price;

        public Scripts(string script, double price)
        {
            this.Script = script;
            this.Price = price;
        }

        public Scripts()
        {
            //
        }
    }
    public class ScrapeDownloadPage
    {
        private HtmlDocument _htmlDocument;
        private string _basePath;
        private List<string> _category;
        private List<List<Scripts>> _categoryData;

        public ScrapeDownloadPage(string webPagePath)
        {
            this._htmlDocument = new HtmlDocument();
            this._category = new List<string>();

            this._categoryData = new List<List<Scripts>>();
            this._basePath = webPagePath;

        }
        public void CreateDirectoryAndStoreXmlFile()
        {
            string outputDirPath = this._basePath + @"Output\";

            if (!Directory.Exists(outputDirPath))
            {
                Console.WriteLine("Creating Output Directory...");
                Directory.CreateDirectory(outputDirPath);
            }

            XmlRootAttribute root = new XmlRootAttribute("xml");
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer xs = new XmlSerializer(typeof(List<Scripts>), root);


            XmlSerializer xsa = new XmlSerializer(typeof(List<List<Scripts>>), root);

            for (int i = 0; i < this._category.Count; i++)
            {
                string cleanCategory = this._category[i].Replace('/', '-').Replace(' ', '_');

                string categoryDirPath = outputDirPath + cleanCategory + @"\";

                if (!Directory.Exists(categoryDirPath))
                {
                    Directory.CreateDirectory(categoryDirPath);
                }


                string xmlFilePath = categoryDirPath + cleanCategory + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss") + ".xml";
                TextWriter txtWriter = new StreamWriter(xmlFilePath);

                if (i != this._category.Count - 1)
                {
                    xs.Serialize(txtWriter, this._categoryData[i], ns);
                    txtWriter.Close();
                }
                else
                {
                    List<Scripts> result = new List<Scripts>();
                    foreach (var outerElement in this._categoryData)
                    {
                        foreach (var innerElement in outerElement)
                        {
                            result.Add(innerElement);
                        }
                    }
                    xs.Serialize(txtWriter, result, ns);
                    txtWriter.Close();
                }
            }

            Console.WriteLine("All XML Files Save @ " + outputDirPath + " Directory...");


            File.WriteAllLines(outputDirPath + "CategoryName.txt", this._category);

        }
        public void ReadHtmlFileAndExtractTableData(string fileName)
        {
            if (File.Exists(this._basePath + fileName))
            {
                Console.WriteLine("Scrapping Start...");

                this._htmlDocument.Load(this._basePath + fileName);
                HtmlNode[] table = this._htmlDocument.DocumentNode.SelectNodes("//div[@class='table-responsive']").ToArray();


                for (int i = 0; i < table.Length; i++)
                {
                    string category = table[i].SelectNodes(".//h4").ToArray()[0].InnerHtml.Trim();
                    this._category.Add(category);


                    var scrip = table[i].SelectNodes(".//td[1]").ToArray();
                    var currentPrice = table[i].SelectNodes(".//td[6]").ToArray();
                    this._categoryData.Add(new List<Scripts>());
                    for (int j = 1; j < scrip.Length; j++)
                    {
                        this._categoryData[i].Add(new Scripts(scrip[j].InnerHtml, Convert.ToDouble(currentPrice[j].InnerHtml)));
                    }
                }

                this._category.Add("ALL");

                Console.WriteLine("Scrapping Complete...");
            }
            else
            {
                Console.WriteLine(fileName + " File not exist");
                throw new Exception(fileName + " File not exist"); 
            }

        }
        static void Main(string[] args)
        {
            string basePath = ConfigurationManager.AppSettings["basePath"];
            string htmlFileName;
            if (args.Length > 0)
            {
                htmlFileName = args[0];
            }
            else
            {

                htmlFileName = @"\Summary" + DateTime.Now.ToString("ddMMMMyy") + ".html";
            }
            
            ScrapeDownloadPage scrapeDownloadPage = new ScrapeDownloadPage(basePath);

            scrapeDownloadPage.ReadHtmlFileAndExtractTableData(htmlFileName);
            scrapeDownloadPage.CreateDirectoryAndStoreXmlFile();


            Console.WriteLine("Enter any key to exit...");
            Console.ReadLine();

        }
    }
}
