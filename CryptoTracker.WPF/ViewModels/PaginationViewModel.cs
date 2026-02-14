using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CryptoTracker.WPF.ViewModels
{
    internal partial class PaginationViewModel : ObservableObject
    {
        public PaginationViewModel(int defaultSize = 10)
        {
            PageSizes = new ObservableCollection<int> { 5, 10, 25, 50, 100, 200, 500 };
            _selectedPageSize = defaultSize;
        }

        [ObservableProperty]
        private int _selectedPageSize;

        [ObservableProperty]
        private ObservableCollection<int> _pageSizes;

        partial void OnSelectedPageSizeChanged(int value)
        {
            SelectedPageSizeChanged?.Invoke(this, value);
        }

        public event EventHandler<int>? SelectedPageSizeChanged;
    }
}
