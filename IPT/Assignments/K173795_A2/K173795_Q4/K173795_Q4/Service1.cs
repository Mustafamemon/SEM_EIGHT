using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.ServiceProcess;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Timers;
using System.Xml.Serialization;
namespace K173795_Q4
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

            ExecuteQ4();

            timmer.Elapsed += new ElapsedEventHandler(TimmerWrapper); // adding Event
            timmer.Interval = 1200000; // Set your time here 
            timmer.Enabled = true;
            timmer.Start();
        }
        private void TimmerWrapper(object sender, ElapsedEventArgs e)
        {
            WriteToFile("Service is recall at " + DateTime.Now);

            ExecuteQ4();
        }
        private void ExecuteQ4()
        {
            try
            {
                string basePath = ConfigurationManager.AppSettings.Get("basePath");
                string sourcePath = basePath + "OldOutput";
                string destPath = basePath + "OutputJson";

                if (Directory.Exists(sourcePath))
                {
                    WriteToFile("Converting XML to JSON " + DateTime.Now);

                    if (!Directory.Exists(destPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }
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
                        XmlRootAttribute root = new XmlRootAttribute("xml");
                        XmlSerializer ser = new XmlSerializer(typeof(List<Scripts>), root);

                        foreach (string file in files)
                        {
                            string file_name = Path.GetFileName(file);
                            string[] baseFileName = file_name.Split('_');
                            string time = baseFileName[baseFileName.Length - 1].Split('.')[0];
                            string date = baseFileName[baseFileName.Length - 2];
                            string date_time = date + "_" + time;
                            CultureInfo provider = CultureInfo.InvariantCulture;

                            using (StreamReader sr = new StreamReader(file))
                            {
                                List<Scripts> sp = (List<Scripts>)ser.Deserialize(sr);
                                foreach (Scripts s in sp)
                                {
                                    string jsonFilePath = desDirPath + @"\" + s.Script.Replace(" ", "") + ".json";
                                    if (!File.Exists(jsonFilePath))
                                    {
                                        ScriptData scriptData = new ScriptData();
                                        scriptData.scriptData = new Script();
                                        scriptData.scriptData.lastUpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss"));
                                        scriptData.scriptData.scriptsDate = new List<ScriptsDate>();
                                        ScriptsDate scriptsDate = new ScriptsDate();

                                        scriptsDate.Date = DateTime.ParseExact(date_time, "yyyy-MM-dd_HH-mm-ss", provider);
                                        scriptsDate.Price = s.Price;
                                        scriptData.scriptData.scriptsDate.Add(scriptsDate);
                                        string jsonString = JsonSerializer.Serialize(scriptData);
                                        File.WriteAllText(jsonFilePath, jsonString);
                                    }
                                    else
                                    {
                                        string jsonString = File.ReadAllText(jsonFilePath);
                                        ScriptData scriptData = JsonSerializer.Deserialize<ScriptData>(jsonString);
                                        scriptData.scriptData.lastUpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy/MM/ddTHH:mm:ss"));
                                        ScriptsDate scriptsDate = new ScriptsDate();
                                        scriptsDate.Date = DateTime.ParseExact(date_time, "yyyy-MM-dd_HH-mm-ss", provider);
                                        scriptsDate.Price = s.Price;
                                        scriptData.scriptData.scriptsDate.Add(scriptsDate);
                                        jsonString = JsonSerializer.Serialize(scriptData);
                                        File.WriteAllText(jsonFilePath, jsonString);
                                    }
                                }
                            }
                            File.Delete(file);
                        }
                    }
                    WriteToFile("Converting End " + DateTime.Now);

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
    public class Scripts
    {
        public string Script { get; set; }
        public string Price { get; set; }
    }
    public class ScriptsDate
    {
        public DateTime Date { get; set; }
        public string Price { get; set; }
    }
    public class Script
    {
        public DateTime lastUpdatedOn { get; set; }
        [JsonPropertyName("")]
        public List<ScriptsDate> scriptsDate { get; set; }

    }
    public class ScriptData
    {
        public Script scriptData { get; set; }
    }

}
