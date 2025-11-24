using System.Collections.ObjectModel;

namespace MauiAppHomework
{
    public class Item
    {
        public decimal Price { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public DateTime PackDate { get; set; }
        public string Description { get; set; }

        public virtual string DisplayInfo => $"{Name} ({Country}) - {Price} грн";
    }

    public class Product : Item
    {
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public override string DisplayInfo => 
            $"[Продукт] {base.DisplayInfo}, Придатний до: {ExpirationDate.ToShortDateString()}";
    }

    public class Book : Item
    {
        public int PageCount { get; set; }
        public string Publisher { get; set; }
        public string Authors { get; set; }

        public override string DisplayInfo => 
            $"[Книга] {base.DisplayInfo}, Видавництво: {Publisher}";
    }

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> ItemsList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            
            ItemsList = new ObservableCollection<Item>
            {
                new Product 
                { 
                    Name = "Молоко", Price = 40, Country = "Україна", 
                    PackDate = DateTime.Now, Description = "Свіже", 
                    ExpirationDate = DateTime.Now.AddDays(7), Quantity = 1, Unit = "літр" 
                },
                new Book 
                { 
                    Name = "Кобзар", Price = 350, Country = "Україна", 
                    PackDate = DateTime.Now, Description = "Класика", 
                    PageCount = 700, Publisher = "А-Ба-Ба-Га-Ла-Ма-Га", Authors = "Т. Шевченко" 
                }
            };

            myCollectionView.ItemsSource = ItemsList;
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            var newProduct = new Product
            {
                Name = $"Яблука {DateTime.Now.Second}",
                Price = 25,
                Country = "Польща",
                PackDate = DateTime.Now,
                Description = "Сорт Голден",
                ExpirationDate = DateTime.Now.AddDays(30),
                Quantity = 10,
                Unit = "кг"
            };

            ItemsList.Add(newProduct);
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (ItemsList.Count > 0)
            {
                ItemsList.RemoveAt(ItemsList.Count - 1);
            }
            else
            {
                DisplayAlert("Помилка", "Список порожній!", "OK");
            }
        }
    }
}
