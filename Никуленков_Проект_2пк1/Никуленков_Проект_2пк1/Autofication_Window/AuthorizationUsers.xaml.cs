using Newtonsoft.Json;
using NikulenkovLibrary;
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
    /// Логика взаимодействия для AuthorizationUsers.xaml
    /// </summary>
    public partial class AuthorizationUsers : Window
    {
        private List<NikulenkovLibrary.Users> _users; //список пользователей
        private const string _jsonFilePath = "users.json"; //путь к файлу сохранения
        public AuthorizationUsers()
        {
            InitializeComponent();
            _users = new List<NikulenkovLibrary.Users>(); //инициализация списка пользователей
                                    
        }
        

        /// <summary>
        /// Кнопка регистрации направляет нас в соотвествующее окно
        /// </summary>
        private void Button_Regstration(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }


        #region работа с файлами json
        /// <summary>
        /// Загрузка из json и добавление обьектов в лист
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
        /// Загрузка в json и извлечение туда обьектов из листа
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
        /// Логика авторизации при нажатии на клавишу вход
        /// </summary>
        private void Autorization(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;


            if (_users != null)
            {
                NikulenkovLibrary.Users user = _users.FirstOrDefault(u => u.Email == login && u.Password == password); // использование лямбда выражений,
                                                                                                                       // проверка присутствия такого пользователя в листе
                if (user != null)
                {
                    if (user.Email == "admin" && user.Password == "root") // вход для админа
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();
                    }
                    else // вход для пользователя
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                }
                else // разные ошибки
                {
                    MessageBox.Show("Пароль или логин введен неверно!");
                }
            }
            else
            {
                MessageBox.Show("Список пользователей не инициализирован");
            }
        }


        #region закрытие/загрузка окна
        /// <summary>
        /// Открытие и закрытие окна с логикой сохранения изменений и загрузки содержимого файлов json
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromJson();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDataToJson();
        }
        #endregion

    }
}
