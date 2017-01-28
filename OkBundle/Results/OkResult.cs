using OkBundle.Interfaces;

namespace OkBundle.Results
{
    public class OkResult<T> where T : Result
    {
        public T Result { get; private set; }

        public OkResult(T result)
        {
            Result = result;
        }

    }

    public static class ResultFactory
    {
        public static OkResult<T> Create<T>(T result) where T : Result
        {
            return new OkResult<T>(result);
        }
    }
}