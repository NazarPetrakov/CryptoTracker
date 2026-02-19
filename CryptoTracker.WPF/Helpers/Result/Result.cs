using CryptoTracker.WPF.Helpers.Errors;

namespace CryptoTracker.WPF.Helpers.ResultT
{
    internal class Result
    {
        protected Result()
        {
            IsSuccess = true;
            Error = default;
        }
        protected Result(Error error)
        {
            IsSuccess = false;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error? Error { get; }

        public static implicit operator Result(Error error) => new(error);

        public static Result Success() => new();
        public static Result Failure(Error error) => new(error);
    }

    internal sealed class ResultT<TValue> : Result
    {
        private readonly TValue? _value;

        private ResultT(TValue value) : base()
        {
            _value = value;
        }
        private ResultT(Error error) : base(error)
        {
            _value = default;
        }

        public TValue Value =>
            IsSuccess ? _value! :
                throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

        public static implicit operator ResultT<TValue>(TValue value) =>
            new(value);
        public static implicit operator ResultT<TValue>(Error error) =>
            new(error);

        public static ResultT<TValue> Success(TValue value) =>
            new(value);
        public static new ResultT<TValue> Failure(Error error) =>
            new(error);
    }
}
