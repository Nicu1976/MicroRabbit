using RabbitMQ.Client;
using System;
using System.Text;

namespace Producer
{
    internal class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            using (var chanel = connection.CreateModel())
            {
                chanel.QueueDeclare("BasicTest", false, false, false, null);
                string message = "Getting started with .Net Core RabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);

                chanel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine($"Sent message {message}");
            }

            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}
