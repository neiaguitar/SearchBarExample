using SearchBarExample.ViewModels;

namespace SearchBarExample
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel => (MainViewModel)BindingContext;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.FilterProducts(e.NewTextValue ?? string.Empty);
        }
    }
}
