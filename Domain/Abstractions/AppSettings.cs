namespace Domain.Abstractions;

public record AppSettings(string SystemId, string ProjectName, string AppVersion, Endpoint Endpoint, Kafka Kafka);

public record Endpoint(string LinkAS400, string LinkUserManagement);

public record Kafka(
    string BootstrapServers,
    string SecurityProtocol,
    string SslCertificatePem,
    string SslKeyPem,
    string SslCaLocation,
    Topics Topics
);

public record Topics(string RequestLoggerTopic);
