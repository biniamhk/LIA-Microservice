using Microsoft.Extensions.Configuration;
using PlanService.DTOS;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace PlanService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbotMQPort"])
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShudown;
                Console.WriteLine("---->CONNECTED TO MESSAGEBUS");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"----->>> Could Not Connect to Message Bus: {ex.Message}");
                throw;
            }
        }
        private void RabbitMQ_ConnectionShudown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("----> RABBITMQ CONNECTION SHUTDOWN");
        }



        public void PublishNewPlan(PublishPlanReadDto publishedPlanDto)
        {
            var message = JsonSerializer.Serialize(publishedPlanDto);
            if (_connection.IsOpen)
            {
                Console.WriteLine("---> RabbitMq Connection is open, sending message");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("---> RabbitMq Connection is not open");
            }
        }
        public void Dispose()
        {
            Console.WriteLine("MessageBus Disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }
        }
        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger",
                    routingKey: "",
                    basicProperties: null,
                    body: body);
            Console.WriteLine($"---> Message Sent {message}");
        }
    }
}
