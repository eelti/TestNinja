using System;
using System.Linq.Expressions;
using System.Net;
using TestNinja;

namespace ConsoleApps
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myUrl = "https://raw.githubusercontent.com/datasets/covid-19/master/data/worldwide-aggregated.csv";
            var myUrls = myUrl.Split('/');
            var myFileName = myUrls[myUrls.Length - 1];
            try
            {
                var fileDownloader = new FileDownloader();
                fileDownloader.DownloadFile(myUrl,$"c:\\temp\\{myFileName}");
            }
            catch ( Exception e)
            {
                if (e is WebException)
                {
                    Console.WriteLine(e);
                }
                //Console.WriteLine(e);
            }

            Console.WriteLine("Hello World");
        }
    }
}