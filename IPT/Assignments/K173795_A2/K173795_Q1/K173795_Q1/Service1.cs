using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using System;
using System.IO;
using System.Configuration;

namespace K173795_Q1
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

            ExecuteQ1();

            timmer.Elapsed += new ElapsedEventHandler(TimmerWrapper); // adding Event
            timmer.Interval = 300000; // Set your time here 
            timmer.Enabled = true;
            timmer.Start();
        }
        private void TimmerWrapper(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);

            ExecuteQ1();
        }
        private void ExecuteQ1()
        {
            try
            {
                string solutionPath = ConfigurationManager.AppSettings.Get("solutionPath");

                WriteToFile("Q1 start " + DateTime.Now);

                Process.Start(solutionPath);

                WriteToFile("Q1 end " + DateTime.Now);
            }
            catch (Exception ex)
            {
                WriteToFile(ex.Message + " " + DateTime.Now);
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
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
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
