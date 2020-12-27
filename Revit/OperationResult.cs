namespace Revit
{
    public class OperationResult
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }

        public OperationResult(string message, bool isSucceeded)
        {
            Message = message;
            IsSucceeded = isSucceeded;
        }
    }
}