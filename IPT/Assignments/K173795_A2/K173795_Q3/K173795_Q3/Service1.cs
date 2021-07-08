using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace K173795_Q3
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

            ExecuteQ3();

            timmer.Elapsed += new ElapsedEventHandler(TimmerWrapper); // adding Event
            timmer.Interval = 900000; // Set your time here 
            timmer.Enabled = true;
            timmer.Start();

        }
        private void TimmerWrapper(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);

            ExecuteQ3();
        }
        public void ExecuteQ3()
        {
            try
            {
                string basePath = ConfigurationManager.AppSettings.Get("basePath");
                string sourcePath = basePath + "Output";
                string destPath = basePath + "OldOutput";

                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                if (Directory.Exists(sourcePath))
                {

                    WriteToFile("Start Moving files " + DateTime.Now);

                    string[] subdirectoryEntries = Directory.GetDirectories(sourcePath);
                    foreach (string subdirectory in subdirectoryEntries)
                    {
                        string dirName = Path.GetFileName(subdirectory);
                        string desDirPath = destPath + @"\" + dirName;
                        if (!Directory.Exists(desDirPath))
                        {
                            Directory.CreateDirectory(desDirPath);
                        }
                        List<String> files = new List<string>(Directory.GetFiles(subdirectory));
                        string date_time = "";
                        string fileName = "";
                        foreach (string s in files)
                        {
                            fileName = Path.GetFileName(s);
                            string[] baseFileName = fileName.Split('_');
                            string time = baseFileName[baseFileName.Length - 1].Split('.')[0];
                            string date = baseFileName[baseFileName.Length - 2];
                            if (String.Compare(date_time, date + '_' + time) < 0)
                            {
                                date_time = date + '_' + time;
                            }
                        }
                        files.RemoveAll(item => item.Contains(date_time));
                        foreach (string s in files)
                        {
                            fileName = Path.GetFileName(s);
                            string destFilePath = Path.Combine(desDirPath, fileName);
                            File.Move(s, destFilePath);
                        }
                    }
                    WriteToFile("All files moved " + DateTime.Now);

                }
                else
                {
                    WriteToFile(sourcePath + " folder not found " + DateTime.Now);
                }
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
