using System;
using System.Threading.Tasks;

using static HurManager.App.Common.Operation.OperationResultT;

namespace HurManager.App.Common.Operation
{
    public static class OperationHelper
    {
        public static async Task<OperationResult> AsOperationAsync(this Task task)
        {
            if (task == null)
            {
                return OperationResult.Success;
            }

            try
            {
                await task;

                return OperationResult.Success;
            }
            catch (Exception e)
            {
                return OperationResult.Fail(e);
            }
        }

        public static async Task<OperationResult<T>> AsOperationAsync<T>(this Task<T> task)
        {
            if (task == null)
            {
                return OperationResult<T>.Success;
            }

            try
            {
                var result = await task;

                return result;
            }
            catch (Exception e)
            {
                return OperationResult<T>.Fail(e);
            }
        }
    }
}
