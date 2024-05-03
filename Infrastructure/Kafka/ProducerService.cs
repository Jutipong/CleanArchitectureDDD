using Confluent.Kafka;
using Domain.Abstractions;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Kafka;

public class ProducerService : IProducerService
{
    private readonly ILogger<ProducerService> _logger;
    private readonly IProducer<Null, string> _producer;

    public ProducerService(ILogger<ProducerService> logger, AppSettings appSetting)
    {
        _logger = logger;

        var producerConfig = new ProducerConfig { BootstrapServers = appSetting.Kafka.BootstrapServers, MessageTimeoutMs = 30 };
        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var funcName = MethodBase.GetCurrentMethod()?.FuncName();

        _logger.LogInformation("Start Function:{FuncName}, Topic:{Topic}, Message:{Message}", funcName, topic, message);

        try
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

            _logger.LogInformation("Finish Function:{Function}, Topic:{Topic}, Message:{Message}", funcName, topic, message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error Function:{Function}, Topic:{Topic}, Message:{Message}, {Exception}", funcName, topic, message, ex);

            throw;
        }
    }
}
