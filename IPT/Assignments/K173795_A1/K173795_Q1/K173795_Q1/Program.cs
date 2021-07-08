using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace K173795_Q1
{
    class DownloadWebPage
    {
        
        static void Main(string[] args)
        {
            if (args.Length >= 2) {
                string pageUrl = args[1];

                string Filename = @"\Summary" + DateTime.Now.ToString("ddMMMMyy") +".html";

                string savePath  = args[2] + Filename;

                try
                {
                    if (File.Exists(savePath)){
                        File.Delete(savePath);
                    }

                    FileStream fs = File.Create(savePath);
                    fs.Close();
                    WebClient client = new WebClient();
                    client.DownloadFile(pageUrl, savePath);
                }
                catch(Exception e){
                    Console.WriteLine(e.ToString());
                };
                
                Console.WriteLine(pageUrl + "-> Download Successfully");
                Console.WriteLine("Saved Successfully @ " + savePath);

            }
            else{
                Console.WriteLine("Please give atleast two argument");
            }

            Console.Write("Enter any key to exit...");
            Console.Read();
        }
    }
}
