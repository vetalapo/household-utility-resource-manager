using System;

using HurManager.App.Common.Monads;

namespace HurManager.App.Common.Operation
{
    public class OperationResultT
    {
        public class OperationResult<TResult> : OperationResult
        {
            public static new OperationResult<TResult> Success => new OperationResult<TResult> { Status = OperationResultStatus.Success };

            public TResult Result { get; set; }

            public static new OperationResult<TResult> Fail(Exception e)
            {
                return new OperationResult<TResult>
                {
                    Status = OperationResultStatus.Failure,
                    Message = e.Message
                };
            }

            public static new OperationResult<TResult> Fail(string errorMessage)
            {
                return new OperationResult<TResult>
                {
                    Status = OperationResultStatus.Failure,
                    Message = errorMessage
                };
            }

            public static OperationResult<TResult> FromResult(TResult result, string successMessage = null)
                => Success.Do(x =>
                {
                    x.Result = result;
                    x.Message = successMessage;
                });

            public static implicit operator TResult(OperationResult<TResult> result) => result.Let(x => x.Result, default(TResult));

            public static implicit operator OperationResult<TResult>(TResult value) => Success.Do(x => x.Result = value);
        }
    }
}
