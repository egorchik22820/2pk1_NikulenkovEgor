using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Никуленков_Проект_2пк1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<NikulenkovLibrary.Product> _products; //список заказов
        private const string _jsonFilePath = "order.json"; //путь к файлу сохранения

        public MainWindow()
        {
            InitializeComponent();
            _products = new List<NikulenkovLibrary.Product>(); //инициализация списка заказов

        }

        /// <summary>
        /// Закрытие окна в случае перехода на старое - так как старое просто находится снизу этого
        /// </summary>
        private void Button_Out(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Order(object sender, RoutedEventArgs e)
        {
            NikulenkovLibrary.Users users = new NikulenkovLibrary.Users();
            Buy BuyWindow = new Buy(this); //создание окна для добавления заметки
            BuyWindow.Show(); //отображение окна

            //подписка на событие добавления заказов в дочернем окне
            BuyWindow.ProductAddEvent += delegate (object senser, NikulenkovLibrary.Product product)
            {
                _products.Add(product);
            };
        }

        #region закрытие/загрузка окна
        /// <summary>
        /// событие загрузки окна - загружаются данные из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromJson();
        }

        /// <summary>
        /// события закрытия окна - сохраняются данные в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToJson();
        }

        #endregion

        #region работа с json
        /// <summary>
        /// загрузка из файла и десериализация данных
        /// </summary>
        internal void LoadDataFromJson()
        {
            if (File.Exists(_jsonFilePath))
            {
                string serializationData = File.ReadAllText(_jsonFilePath); //считывание содержимого файла
                if (serializationData != null)
                {
                    var items = JsonConvert.DeserializeObject<List<NikulenkovLibrary.Product>>(serializationData); //десериализация содержимого файла и запись в список задач
                    foreach (var item in items)
                    {
                        _products.Add(item);
                    }
                }

            }
        }
        /// <summary>
        /// сериализация и сохранение данных в файл
        /// </summary>
        internal void SaveDataToJson()
        {
            if (!File.Exists(_jsonFilePath))
            {
                File.Create(_jsonFilePath).Close();
            }
            string serializationData = JsonConvert.SerializeObject(_products);
            File.WriteAllText(_jsonFilePath, serializationData);
        }
        #endregion
    }
}
