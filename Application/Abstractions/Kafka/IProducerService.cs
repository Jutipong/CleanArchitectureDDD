namespace Application.Abstractions.Kafka;

public interface IProducerService
{
    Task ProduceAsync(string topic, string message);
}