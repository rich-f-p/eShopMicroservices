using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqHelper
{
    public class MessageQueue
    {
        private readonly ConnectionFactory factory;
        public MessageQueue(string url, string providerName)
        {
            factory = new ConnectionFactory();
            factory.Uri = new Uri(url);
            factory.ClientProvidedName = providerName;
        }

        public async Task AddMessageToQueueAsync(string message, string exchangeName, string queueName, string routingKey)
        {
            IConnection con = await factory.CreateConnectionAsync();
            var channel = await con.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.QueueBindAsync(queueName, exchangeName, routingKey);
            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);
            await channel.BasicPublishAsync(exchangeName, routingKey, messageBodyBytes);
            await channel.CloseAsync();
            await con.CloseAsync();
            channel.Dispose();
            con.Dispose();
        }

        public async Task<string> ReadMessageFromQueueAsync(string exchangeName, string queueName, string routingKey)
        {
            IConnection con = await factory.CreateConnectionAsync();
            var channel = await con.CreateChannelAsync();
            await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
            await channel.QueueDeclareAsync(queueName, false, false, false);
            await channel.QueueBindAsync(queueName, exchangeName, routingKey);
            var result = await channel.BasicGetAsync(queueName, false);
            await channel.CloseAsync();
            await con.CloseAsync();
            channel.Dispose();
            con.Dispose();
            if (result != null)
            {
                return Encoding.UTF8.GetString(result.Body.ToArray());
            }
            return "no Message";
        }
    }
}
