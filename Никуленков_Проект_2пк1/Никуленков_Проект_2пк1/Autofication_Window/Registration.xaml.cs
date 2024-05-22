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

namespace Никуленков_Проект_2пк1.Autofication_Window
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private List<NikulenkovLibrary.Users> _users; //список пользователей
        private const string _jsonFilePath = "users.json"; //путь к файлу сохранения
        public Registration()
        {
            InitializeComponent();
            _users = new List<NikulenkovLibrary.Users>(); //инициализация списка пользователей
        }


        /// <summary>
        /// Логика входа после регистрации, сохранение пользователя в лист
        /// </summary>
        private void Button_Account(object sender, RoutedEventArgs e)
        {
            _users.Add(new NikulenkovLibrary.Users(Name.Text, Surname.Text, Login.Text, Password.Password));
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        #region события окна: открытие/закрытие окна, нажатие кнопок

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
                    var users = JsonConvert.DeserializeObject<List<NikulenkovLibrary.Users>>(serializationData); //десериализация содержимого файла и запись в список задач
                    foreach (var user in users)
                    {
                        _users.Add(user);
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
            string serializationData = JsonConvert.SerializeObject(_users);
            File.WriteAllText(_jsonFilePath, serializationData);
        }
        #endregion


        /// <summary>
        /// Логика возращения на страницу входа, кнопка "у меня есть аккаунт"
        /// </summary>
        private void Button_HasAccount(object sender, RoutedEventArgs e)
        {
            AuthorizationUsers authorizationUsers = new AuthorizationUsers();
            authorizationUsers.Show();
            this.Close();
        }
    }
}

