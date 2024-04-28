namespace Domain.Abstractions;

public record AppSettings(
        string SystemId,
        string ProjectName,
        string AppVersion,
        Endpoint Endpoint,
        Kafka Kafka);

public record Endpoint(string LinkAS400, string LinkUserManagement);

public record Kafka(Producer Producer, Topics Topics);

public record Producer(
        string BootstrapServers,
        string SecurityProtocol,
        string SslCertificatePem,
        string SslKeyPem,
        string SslCaLocation);

public record Topics(string RequestLoggerTopic);