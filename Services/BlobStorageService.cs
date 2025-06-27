using Azure.Storage.Blobs;

namespace AzureStorageCRUD.Services
{
    public class BlobStorageService
    {
        //storageName=ptstorage
        private string containerName = "sample-container";

        public void Run(string connectionString)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            containerClient.CreateIfNotExists();

            string blobName = "sample.txt";
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Create/Upload
            using (var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes("Hello Blob Storage")))
            {
                blobClient.Upload(stream, overwrite: true);
            }

            // Read/Download
            var downloadStream = new MemoryStream();
            blobClient.DownloadTo(downloadStream);
            Console.WriteLine("Downloaded blob content: " + System.Text.Encoding.UTF8.GetString(downloadStream.ToArray()));

            // Delete
            blobClient.DeleteIfExists();
            Console.WriteLine("Blob deleted.");

            containerClient.DeleteIfExists();
        }
    }
}
