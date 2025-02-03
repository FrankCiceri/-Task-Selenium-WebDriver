using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_WebDriver.Core.Utils
{
    public class DownloadUtils
    {
        private readonly string downloadDirectory;

        public DownloadUtils(string downloadDirectory = "C:\\Downloads")
        {
            if (string.IsNullOrEmpty(downloadDirectory))
            {
                throw new ArgumentException("Download directory cannot be null or empty.", nameof(downloadDirectory));
            }

            if (!Directory.Exists(downloadDirectory))
            {
                Directory.CreateDirectory(downloadDirectory);
            }

            this.downloadDirectory = downloadDirectory;
        }

        public bool WaitForFileDownload(string fileName)
        {
            string filePath = Path.Combine(this.downloadDirectory, fileName + ".pdf");

            int timeout = 60;
            bool fileDownloaded = false;
            for (int i = 0; i < timeout; i++)
            {
                if (File.Exists(filePath))
                {
                    fileDownloaded = true;
                    break;
                }

                Thread.Sleep(1000);
            }

            return fileDownloaded;
        }

        public void EmptyDownloadsFolder()
        {
            if (Directory.Exists(downloadDirectory))
            {
                foreach (var file in Directory.GetFiles(downloadDirectory))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
