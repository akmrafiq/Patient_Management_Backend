using System.Text.Json;

namespace Patient_Management_System.Core.Shared;

public class CommonApiResponse
{
    public CommonApiResponse() { }

    public CommonApiResponse(bool isSuccess, int statusCode, string statusDetails, string message, dynamic data)
    {
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        StatusDetails = statusDetails;
        Message = message;
        Data = data;
    }

    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string StatusDetails { get; set; }
    public string Message { get; set; }
    public dynamic Data { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}