namespace eDiary.API.Services.Security.Interfaces
{
    public interface IOperationResult
    {   
        ResultCode Code { get; }
        string Message { get; }
        string Content { get; }
    }
}
