using Confluent.Kafka;
using Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Kafka;

public class ConsumerService
{
    private readonly IConsumer<Ignore, string> _consumer;
    private readonly ILogger<ConsumerService> _logger;

    public ConsumerService(AppSettings appSetting, ILogger<ConsumerService> logger)
    {
        _logger = logger;

        var consumerConfig = new ConsumerConfig
        {
            BootstrapServers = appSetting.Kafka.BootstrapServers,
            GroupId = "InventoryConsumerGroup",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
    }

    protected Task Execute(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("InventoryUpdates");

        while (!stoppingToken.IsCancellationRequested)
        {
            ProcessKafkaMessage(stoppingToken);
            Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }

        _consumer.Close();

        return Task.CompletedTask;
    }

    private void ProcessKafkaMessage(CancellationToken stoppingToken)
    {
        var funcName = MethodBase.GetCurrentMethod()?.FuncName();

        try
        {
            var consumeResult = _consumer.Consume(stoppingToken);
            var message = consumeResult.Message.Value;

            _logger.LogInformation(
                "Function:{Function}, ConsumeResult:{@ConsumeResult}, Message:{Message}",
                funcName,
                consumeResult,
                message
            );
        }
        catch (Exception ex)
        {
            _logger.LogError("Error Function:{Function}, {ExMessage}", funcName, ex.Message);

            throw;
        }
    }
}
