public class OperationResult
{
    public bool IsSucceeded { get; init; }
    public string Message { get; init; }

    public OperationResult(string message, bool isSucceeded)
    {
        Message = message;
        IsSucceeded = isSucceeded;
    }
}