using Azure;
using Azure.Data.Tables;
using System;

namespace AzureStorageCRUD.Services
{
    public class TableStorageService
    {
        private string tableName = "SampleTable";

        public void Run(string connectionString)
        {
            TableServiceClient serviceClient = new TableServiceClient(connectionString);
            TableClient tableClient = serviceClient.GetTableClient(tableName);
            tableClient.CreateIfNotExists();

            var entity = new TableEntity("PartitionKey", "RowKey")
            {
                { "Name", "Azure Table" },
                { "Description", "Sample entity" }
            };

            // Create
            tableClient.AddEntity(entity);
            Console.WriteLine("Entity added to table.");

            // Read
            var retrievedEntity = tableClient.GetEntity<TableEntity>("PartitionKey", "RowKey");
            Console.WriteLine("Retrieved entity: " + retrievedEntity.Value["Name"]);

            // Update
            entity["Description"] = "Updated entity";
            tableClient.UpdateEntity(entity, ETag.All, TableUpdateMode.Replace);
            Console.WriteLine("Entity updated.");

            // Delete
            tableClient.DeleteEntity("PartitionKey", "RowKey");
            Console.WriteLine("Entity deleted.");

            tableClient.Delete();
            serviceClient.DeleteTable("Azure Table");
        }
    }
}
