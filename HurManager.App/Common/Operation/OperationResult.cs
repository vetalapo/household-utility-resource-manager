using System;
using System.Text;

using HurManager.App.Common.Exceptions;

namespace HurManager.App.Common.Operation
{
    public class OperationResult
    {
        public static OperationResult Success => new OperationResult { Status = OperationResultStatus.Success };

        public string Message { get; set; }

        public OperationResultStatus Status { get; set; }

        public string SystemMessage { get; set; }

        protected Exception InnerException { get; set; }

        public static OperationResult Fail(Exception e)
        {
            var result = new OperationResult
            {
                Status = OperationResultStatus.Failure,
                InnerException = e
            };

            result.SetMessagesByException(e);

            return result;
        }

        public static OperationResult Fail(string errorMessage)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Failure,
                Message = errorMessage
            };
        }

        public static OperationResult Fail(string errorMessage, string systemMessage)
        {
            return new OperationResult
            {
                Status = OperationResultStatus.Failure,
                Message = errorMessage,
                SystemMessage = systemMessage
            };
        }

        public Exception GetInnerException() => this.InnerException;

        protected void SetMessagesByException(Exception exception)
        {
            var messageBuilder = new StringBuilder();
            var systemMessageBuilder = new StringBuilder();

            var exp = exception;
            while (exp != null)
            {
                if (exp is UserFriendlyException)
                {
                    messageBuilder.AppendLine(exp.Message);
                }

                systemMessageBuilder.AppendLine(exp.Message);

                exp = exp.InnerException;
            }

            var message = messageBuilder.ToString();
            this.Message = string.IsNullOrWhiteSpace(message)
                ? exception?.Message
                : message;

            this.SystemMessage = systemMessageBuilder.ToString();
        }
    }
}
