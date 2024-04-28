using Application.Abstractions.Kafka;
using Confluent.Kafka;
using Domain.Abstractions;
using Domain.Helper;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Kafka;

public class ProducerService : IProducerService
{
    private readonly ILogger<ProducerService> _logger;
    private readonly IProducer<Null, string> _producer;

    public ProducerService(ILogger<ProducerService> logger, AppSettings appSetting)
    {
        _logger = logger;

        var producerConfig = new ProducerConfig { BootstrapServers = appSetting.Kafka.Producer.BootstrapServers };
        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var funcName = MethodBaseExtension.GetName;

        _logger.LogInformation("Start Function:{FuncName}, Topic:{Topic}, Message:{Message}", funcName, topic, message);

        try
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

            _logger.LogInformation("Finish Function:{Function}, Topic:{Topic}, Message:{Message}", funcName, topic, message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Function:{Function}, Topic:{Topic}, Message:{Message}", funcName, topic, message);
        }
    }
}
