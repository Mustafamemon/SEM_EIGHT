using System;
using System.IO;
using System.Net;
using System.Configuration;

namespace K173795_A1_Q1
{
    class DownloadWebPage
    {

        static void Main(string[] args)
        {
            string pageUrl = ConfigurationManager.AppSettings.Get("Url");

            string Filename = @"\Summary" + DateTime.Now.ToString("ddMMMMyy") + ".html";
            string savePath = ConfigurationManager.AppSettings.Get("OutputPath") + Filename;

            try
            {
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }

                FileStream fs = File.Create(savePath);
                fs.Close();
                WebClient client = new WebClient();
                client.DownloadFile(pageUrl, savePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            };

            Console.WriteLine(pageUrl + "-> Download Successfully");
            Console.WriteLine("Saved Successfully @ " + savePath);
            Console.Write("Enter any key to exit...");
           // Console.Read();
        }
    }
}
