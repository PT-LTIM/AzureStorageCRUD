using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System;
using System.IO;

namespace AzureStorageCRUD.Services
{
    public class FileShareStorageService
    {
        private string shareName = "sampleshare";

        public void Run(string connectionString)
        {
            ShareClient shareClient = new ShareClient(connectionString, shareName);
            shareClient.CreateIfNotExists();

            ShareDirectoryClient rootDir = shareClient.GetRootDirectoryClient();
            ShareFileClient fileClient = rootDir.GetFileClient("sample.txt");

            // Create/Upload
            byte[] content = System.Text.Encoding.UTF8.GetBytes("Hello File Share");
            using (var stream = new MemoryStream(content))
            {
                fileClient.Create(content.Length);
                fileClient.Upload(stream);
            }

            // Read/Download
            ShareFileDownloadInfo download = fileClient.Download();
            using (var memoryStream = new MemoryStream())
            {
                download.Content.CopyTo(memoryStream);
                string fileContent = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                Console.WriteLine("Downloaded file content: " + fileContent);
            }

            // Delete
            fileClient.DeleteIfExists();
            Console.WriteLine("File deleted from file share.");
        }
    }
}
