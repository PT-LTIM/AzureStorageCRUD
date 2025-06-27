using AzureStorageCRUD.Services;

class Program
{
    private static string connectionString = "DefaultEndpointsProtocol=https;AccountName=ptstorage;AccountKey=1iypMo55ilcYLrJkjfaI73nyxuoBTRZ9PZ4bDtwXPFBI5X+RryWo7QJJKVI8QiNiynctMT5DD/CH+ASteRAB2w==;EndpointSuffix=core.windows.net";

    static void Main(string[] args)
    {
        Console.WriteLine("\n");
        Console.WriteLine("\t\t\t\t\t\t ********** Azure Storage CRUD Operations ********** ");
        Console.WriteLine("\n");

        Console.WriteLine(" >>>>>> 1. Blob Storage CRUDs  ");
        BlobStorageService blobService = new BlobStorageService();
        blobService.Run(connectionString);
        Console.WriteLine("\n");

        Console.WriteLine(" >>>>>> 2. Queue CRUDs  ");
        QueueStorageService queueService = new QueueStorageService();
        queueService.Run(connectionString);
        Console.WriteLine("\n");

        Console.WriteLine(" >>>>>> 3. Table CRUDs  ");
        TableStorageService tableService = new TableStorageService();
        tableService.Run(connectionString);
        Console.WriteLine("\n");

        Console.WriteLine(" >>>>>> 4.File Share CRUDs  ");
        FileShareStorageService fileShareService = new FileShareStorageService();
        fileShareService.Run(connectionString);
        Console.WriteLine("\n");
    }
}
