﻿namespace RestaurantManagementApp.Utils;

public class Result<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public EnumStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }

    public static Result<T> Success(
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    ) =>
        new()
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccess = true
        };

    public static Result<T> Success(
        T data,
        string message = "Success.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    ) =>
        new()
        {
            Data = data,
            Message = message,
            StatusCode = statusCode,
            IsSuccess = true
        };

    public static Result<T> SaveSuccess(
        T data,
        string message = "Saving Successful.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    ) => Result<T>.Success(data, message, statusCode);

    public static Result<T> UpdateSuccess(
        T data,
        string message = "Updating Successful.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    ) => Result<T>.Success(data, message, statusCode);

    public static Result<T> DeleteSuccess(
        T data,
        string message = "Deleting Successful.",
        EnumStatusCode statusCode = EnumStatusCode.Success
    ) => Result<T>.Success(data, message, statusCode);

    public static Result<T> Failure(
        string message = "Fail.",
        EnumStatusCode statusCode = EnumStatusCode.BadRequest
    ) =>
        new()
        {
            Message = message,
            StatusCode = statusCode,
            IsSuccess = false
        };

    public static Result<T> Failure(Exception ex) =>
        new()
        {
            Message = ex.ToString(),
            StatusCode = EnumStatusCode.InternalServerError,
            IsSuccess = false
        };

    public static Result<T> NotFound(string message = "No Data Found.") =>
        Result<T>.Failure(message, EnumStatusCode.NotFound);

    public static Result<T> Duplicate(string message = "Duplicate Data.") =>
        Result<T>.Failure(message, EnumStatusCode.Conflict);
}
