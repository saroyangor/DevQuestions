﻿using System.Text.Json.Serialization;

namespace Shared;

public record Error
{
    public static Error None = new Error(string.Empty, string.Empty, ErrorType.NONE, null);
    public string Code { get; }
    public string Message { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }

    public string? InvalidField { get; }

    [JsonConstructor]
    private Error(string code, string message, ErrorType type, string? invalidField = null)
    {
        Code = code;
        Message = message;
        Type = type;
        InvalidField = invalidField;
    }

    public static Error NotFound(string? code, string message, Guid? id)
        => new(code ?? "record.not.found", message, ErrorType.NOT_FOUND);

    public static Error Validation(string? code, string message, string? invalidField = null)
        => new(code ?? "value.is.invalid", message, ErrorType.VALIDATION, invalidField);

    public static Error Conflict(string? code, string message)
        => new(code ?? "value.is.conflict", message, ErrorType.CONFLICT);

    public static Error Failure(string? code, string message)
        => new(code ?? "failure", message, ErrorType.FAILURE);

    public Failure ToFailure() => this;
}

public enum ErrorType
{
    /// <summary>
    /// Undefined Error.
    /// </summary>
    NONE,

    /// <summary>
    /// Validation Error.
    /// </summary>
    VALIDATION,

    /// <summary>
    /// Not Found Error.
    /// </summary>
    NOT_FOUND,

    /// <summary>
    /// Server Error.
    /// </summary>
    FAILURE,

    /// <summary>
    /// Conflict Error.
    /// </summary>
    CONFLICT,
}
