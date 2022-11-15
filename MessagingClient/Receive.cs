using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingClient
{
    public class Receive
    {
        public static string ReceiveMessage()
        {
            string targetMessage = string.Empty;
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "ItemChangeNotification",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    targetMessage = Encoding.UTF8.GetString(body);
                };
                channel.BasicConsume(queue: "ItemChangeNotification",
                                     autoAck: true,
                                     consumer: consumer);

                return targetMessage;
            }
        }
    }
}
