using AzureStorageCRUD.Services;

class Program
{
    private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=ptstorage;AccountKey=1iypMo55ilcYLrJkjfaI73nyxuoBTRZ9PZ4bDtwXPFBI5X+RryWo7QJJKVI8QiNiynctMT5DD/CH+ASteRAB2w==;EndpointSuffix=core.windows.net";
    
    static void Main(string[] args)
    {
        Console.WriteLine("Azure Storage CRUD Operations");

        BlobStorageService blobService = new BlobStorageService();
        blobService.Run(connectionString);

        QueueStorageService queueService = new QueueStorageService();
        queueService.Run(connectionString);

        TableStorageService tableService = new TableStorageService();
        tableService.Run(connectionString);

        FileShareStorageService fileShareService = new FileShareStorageService();
        fileShareService.Run(connectionString);
    }
}
