namespace TodoApi.Dto;

public class ApiResponse <T>
{
    public bool Success { get; set; } = true;
    public T? Data { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Error { get; set; } = null;
}