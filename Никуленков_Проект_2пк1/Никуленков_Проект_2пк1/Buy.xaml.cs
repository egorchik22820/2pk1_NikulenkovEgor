using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Buy.xaml
    /// </summary>
    public partial class Buy : Window
    {
        internal event EventHandler<NikulenkovLibrary.Product> ProductAddEvent; //событие добавления объекта
        internal void OnProductAddEvent(NikulenkovLibrary.Product product) // OnProductAddEvent
        {
            ProductAddEvent?.Invoke(this, product);
        }

        public Buy(Window owner)
        {
            InitializeComponent();
            this.Owner = owner;
        }


        int count = 0; // количество товаров в корзине

        /// <summary>
        /// Выбор напитков 
        /// </summary>
        private void Button_List_1(object sender, RoutedEventArgs e)
        {
            if(List1.SelectedItem != null)
            {
                string a = (List1.SelectedItem as ListBoxItem).Content.ToString();
                ListToVar.Items.Add(a);
                count++;
                string b = Convert.ToString(count);
                Tovars.Text = b; // Tovars - счетчик корзины
            }
            

        }

        /// <summary>
        /// Выбор еды 
        /// </summary>
        private void Button_List_2(object sender, RoutedEventArgs e)
        {
            if (List2.SelectedItem != null)
            {
                string a = (List2.SelectedItem as ListBoxItem).Content.ToString();
                ListToVar.Items.Add(a);
                count++;
                string b = Convert.ToString(count);
                Tovars.Text = b;
            }
            

        }

        /// <summary>
        /// Удаление обьектов из ListBox
        /// </summary>
        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if(ListToVar.SelectedItem != null)
            {
                var a = ListToVar.SelectedItem.ToString();
                ListToVar.Items.Remove(a);
                count--;
                string b = Convert.ToString(count);
                Tovars.Text = b;
            }
            
        }


        /// <summary>
        /// Добавление товаров в список покупок
        /// </summary>
        private void Click_Add(object sender, RoutedEventArgs e)
        {
            if (Nmber.Text != "")
            {
                string cur = string.Empty; // пустое значение
                                           // проходим все итемы циклом и преобразуем в строчку
                foreach (var item in ListToVar.Items)
                {
                    string itemData = item.ToString();

                    cur = cur + " -" + itemData;
                }

                OnProductAddEvent(new NikulenkovLibrary.Product(Nmber.Text, cur)); ;
                MessageBox.Show("Заказ принят!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Поле данных осталось пустым!");
            }
        }

        /// <summary>
        /// Закрытие окна в случае перехода на старое - так как старое просто находится снизу этого
        /// </summary>
        private void Window_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
