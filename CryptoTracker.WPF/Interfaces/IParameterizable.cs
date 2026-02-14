namespace CryptoTracker.WPF.Interfaces
{
    internal interface IParameterizable<TParameters> where TParameters : IViewModelParameters
    {
        TParameters ViewModelParameters { get; }
        void InitializeParameters(TParameters viewModelParameters);
    }
}
