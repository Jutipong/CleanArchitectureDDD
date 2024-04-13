namespace Domain.Abstractions;

public record AppSettings(string SystemId, string ProjectName, string AppVersion, Endpoints Endpoints);

public record Endpoints(string LinkAS400, string LinkUserManagement);
