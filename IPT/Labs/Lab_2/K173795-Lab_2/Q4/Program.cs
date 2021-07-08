using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Q4
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            DownloadPage().GetAwaiter().GetResult();   
        }

        public static async Task DownloadPage()
        {
            string pageUrl = "http://www.bing.com";

            string Filename = @"\bing.html";
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory.Split("\\bin")[0];
            string savePath = projectDirectory + Filename;
            try
            {
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }

                FileStream fs = File.Create(savePath);
                fs.Close();

                Console.WriteLine("Downloading...");

                string response = await client.GetStringAsync(pageUrl);
                File.WriteAllText(savePath, response);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }


            Console.WriteLine(pageUrl + "-> Download Successfully");
            Console.WriteLine("Saved Successfully @ " + savePath);


            Console.Write("Enter any key to exit...");
            Console.Read();
        }
    }
}
