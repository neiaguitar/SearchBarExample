using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SearchBarExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> FilteredProducts { get; set; }

        private bool _isListVisible;
        public bool IsListVisible
        {
            get => _isListVisible;
            set
            {
                _isListVisible = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Arroz" },
                new Product { Name = "Feijão" },
                new Product { Name = "Macarrão" },
                new Product { Name = "Azeite" },
                new Product { Name = "Açúcar" },
                new Product { Name = "Café" }
            };

            FilteredProducts = new ObservableCollection<Product>(Products);
            IsListVisible = false; // Lista escondida inicialmente
        }

        public void FilterProducts(string searchText)
        {
            var filtered = Products
                .Where(product => product.Name.ToLower().Contains(searchText.ToLower()))
                .ToList();

            FilteredProducts.Clear();
            foreach (var product in filtered)
            {
                FilteredProducts.Add(product);
            }

            IsListVisible = FilteredProducts.Any(); // Mostrar lista apenas se houver resultados
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}
