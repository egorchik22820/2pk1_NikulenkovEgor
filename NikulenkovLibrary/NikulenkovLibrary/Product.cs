
namespace NikulenkovLibrary
{
    public class Product
    {
        public string _id;
        public string _products;
        public DateTime CreationTime { get; private set; } = DateTime.Now;
        public string Text
        {
            get => _id;
            set => _id = value;
        }
        public string Title
        {
            get => _products;
            set => _products = value;
        }

        /// <summary>
        /// для корректной десиреализации обязательно
        /// должен присутствовать конструктор без параметров
        /// </summary>
        public Product() { }
        public Product(string id, string products)
        {
            CreationTime = DateTime.Now;
            _id = id;
            _products = products;
        }

        public override string ToString()
        {
            return $"{CreationTime} : {_id} : {_products}";
        }
    }
}