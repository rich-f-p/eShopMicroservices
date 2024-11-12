using Azure.Messaging.ServiceBus;
using Azure.Storage.Queues;
using System.Text;
using System.Text.Json;

namespace PromotionsMicroservice.API.MessageService
{
    public class QueueService
    {
        private readonly IConfiguration _configuration;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageAsync<T>(T message, string queueName)
        {
            var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
            var sender = queueClient.CreateSender(queueName);
            string messageBody = JsonSerializer.Serialize(message);
            var messageData =  new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
            await sender.SendMessageAsync(messageData);
        }
        //schedule message
        public async Task ScheduledMessage<T>(T message,string queueName, DateTime time)
        {
            var queueClient = new ServiceBusClient(_configuration.GetConnectionString("AzureServiceBus"));
            var sender = queueClient.CreateSender(queueName);
            string messageBody = JsonSerializer.Serialize(message);
            var messageData = new ServiceBusMessage(Encoding.UTF8.GetBytes(messageBody));
            await sender.ScheduleMessageAsync(messageData, time);
        }

        
    }
}
