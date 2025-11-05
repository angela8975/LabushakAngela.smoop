using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame.Models
{
    public abstract class Animals
    {
        public string Name { get; set; }                  // Имя животного (например, "Курица", "Корова")
        public string FeedType { get; set; }              // Тип корма, который нужно использовать
        public TimeSpan ProductTime { get; set; }         // Время, необходимое для создания продукта
        public int ExpPerProduct { get; set; }            // Опыт за 1 единицу продукта
        public string ProductName { get; set; }           // Имя производимого продукта (например, "Яйцо", "Молоко")
        public int ProductAmount { get; set; }            // Количество производимого продукта за один цикл
        public int Price { get; set; }                    // Цена покупки животного
        public Building BuildingHome { get; set; }

        public DateTime LastProductTime { get; private set; } // Когда в последний раз был создан продукт
        public bool IsReadyToCollect => DateTime.Now - LastProductTime >= ProductTime; // Проверка готовности

        protected Animals(string name, string feedType, TimeSpan productTime, int expPerProduct,
                     string productName, int productAmount, int price, Building buildingHome)
        {
            Name = name;
            FeedType = feedType;
            ProductTime = productTime;
            ExpPerProduct = expPerProduct;
            ProductName = productName;
            ProductAmount = productAmount;
            Price = price;
            BuildingHome = buildingHome;

            LastProductTime = DateTime.Now;
        }
        
       
        public virtual void Feed()  // Метод "кормления" животного, который запускает цикл производства
        {
            LastProductTime = DateTime.Now;
        }
        public virtual Product CollectProduct()
        {
            if (IsReadyToCollect)
            {
                LastProductTime = DateTime.Now;
                return new Product(ProductName, ProductAmount, ExpPerProduct);
            }
            return null;
        }
    }
}
