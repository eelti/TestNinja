using System.Net;

namespace TestNinja
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        public void DownloadFile(string url, string path)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(url,path);
        }
    }
}