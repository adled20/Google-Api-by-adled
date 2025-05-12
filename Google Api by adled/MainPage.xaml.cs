using System.Collections;

namespace Google_Api_by_adled
{
    public partial class MainPage : ContentPage
    {
        private List<string> items;
        private IEnumerable filteredItems;

        public MainPage()
        {
            InitializeComponent(); 

            items = new List<string> { "Manzana", "Banana", "Piña", "Melón" };
            filteredItems = new List<string>(items);
            ItemsCollectionView.ItemsSource = filteredItems;
        }
        void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = e.NewTextValue?.ToLower() ?? "";
            filteredItems = items
                .Where(i => i.ToLower().Contains(keyword))
                .ToList();
            ItemsCollectionView.ItemsSource = filteredItems;
        }

    }

}
