using Azure.Storage.Queues;

namespace AzureStorageCRUD.Services
{
    public class QueueStorageService
    {
        private string queueName = "sample-queue";

        public void Run(string connectionString)
        {
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            queueClient.CreateIfNotExists();

            // Create/Enqueue
            queueClient.SendMessage("Hello Queue Storage");
            Console.WriteLine("Message sent to queue.");

            // Read/Dequeue
            var message = queueClient.ReceiveMessage();
            if (message != null)
            {
                Console.WriteLine("Received message: " + message.Value.MessageText);

                // Delete
                queueClient.DeleteMessage(message.Value.MessageId, message.Value.PopReceipt);
                Console.WriteLine("Message deleted.");
            }
        }
    }
}
