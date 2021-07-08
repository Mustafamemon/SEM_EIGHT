using System;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace K173795_Q2
{
    public partial class Service1 : ServiceBase
    {
        Timer timmer = new Timer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service is started at " + DateTime.Now);

            ExecuteQ2();

            timmer.Elapsed += new ElapsedEventHandler(TimmerWrapper); // adding Event
            timmer.Interval = 600000; // Set your time here 
            timmer.Enabled = true;
            timmer.Start();
            
        }
        private void TimmerWrapper(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);

            ExecuteQ2();
        }

        private void ExecuteQ2()
        {
            try
            {
                string basePath = ConfigurationManager.AppSettings.Get("basePath");
                string htmlFileName = ConfigurationManager.AppSettings.Get("htmlFileName");
                if (string.IsNullOrEmpty(htmlFileName))
                {
                    htmlFileName = @"\Summary" + DateTime.Now.ToString("ddMMMMyy") + ".html";
                }
                
                WriteToFile("Scrapping started " + DateTime.Now);

                K173795_A1_Q2.ScrapeDownloadPage scrapeDownloadPage = new K173795_A1_Q2.ScrapeDownloadPage(basePath);
                scrapeDownloadPage.ReadHtmlFileAndExtractTableData(htmlFileName);
                scrapeDownloadPage.CreateDirectoryAndStoreXmlFile();

                WriteToFile("Scrapping end " + DateTime.Now);
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + " " +  DateTime.Now);
            }
        }

        protected override void OnStop()
        {
            WriteToFile("Service is stopped at " + DateTime.Now);
            timmer.Enabled = false;
        }
        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\Logs\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}
