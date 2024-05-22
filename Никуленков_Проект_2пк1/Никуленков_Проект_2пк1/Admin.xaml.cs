using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Никуленков_Проект_2пк1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private List<NikulenkovLibrary.Product> _products; //список заказов
        private const string _jsonFilePath = "order.json"; //путь к файлу сохранения
        public Admin()
        {
            InitializeComponent();
            _products = new List<NikulenkovLibrary.Product>(); //инициализация списка заказов
            ProductsAdmin.ItemsSource = _products; //к списку главного окна привязывается источник данных - коллекция заказов
            
        }
        
        /// <summary>
        /// кнопка "Внести новый заказ"  (вызывается экземпляр модального окна и подписывается на его событие добавления заказа)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Add(object sender, RoutedEventArgs e)
        {
            Buy BuyWindow = new Buy(this); //создание окна для добавления заметки
            BuyWindow.Show(); //отображение окна

            //подписка на событие добавления заказов в дочернем окне
            BuyWindow.ProductAddEvent += delegate (object senser, NikulenkovLibrary.Product product)
            {
                _products.Add(product);
                ProductsAdmin.Items.Refresh(); //обновления списка в окне 
            };
        }
        /// <summary>
        /// кнопка "Заказ выполнен"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Click_Delete(object sender, RoutedEventArgs e)
        {

            // Получаем выделенные элементы из ListBox
            var selectedItems = ProductsAdmin.SelectedItems.Cast<NikulenkovLibrary.Product>().ToList();

            // Удаляем выделенные элементы из списка заказов
            foreach (var item in selectedItems)
            {
                _products.Remove(item);
            }

            // Обновляем отображение ListBox
            ProductsAdmin.ItemsSource = null;
            ProductsAdmin.ItemsSource = _products;
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
            ProductsAdmin.Items.Refresh();
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

        #region работа с файлом
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


        /// <summary>
        /// Кнопка закончить работу
        /// </summary>
        private void Click_Stop(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
