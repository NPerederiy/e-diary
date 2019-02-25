using eDiary.API.Services.Security.Interfaces;
using System;

namespace eDiary.API.Services.Security
{
    public class OperationResult : IOperationResult
    {
        public ResultCode Code { get; private set; }
        public string Message { get; private set; }
        public string Content { get; private set; }

        public OperationResult(ResultCode code) 
            : this(code, "")
        {
        }

        public OperationResult(ResultCode code, string message)
        {
            Code = code;
            Message = message ?? throw new Exception("Message can not be NULL");
        }

        public OperationResult(ResultCode code, string message, string content)
            : this(code, message)
        {
            Content = content;
        }
    }
}
