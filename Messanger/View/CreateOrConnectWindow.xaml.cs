using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Messanger.View
{

    public partial class CreateOrConnectWindow : Window, INotifyPropertyChanged
    {
        private string _ipAddress;
        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                _ipAddress = value;
                OnPropertyChanged(nameof(IpAddress));
            }
        }

        public CreateOrConnectWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var colorAnimation = (Storyboard)FindResource("ColorAnimation");
            colorAnimation.Begin();
        }

        private void OpenServer_Click(object sender, RoutedEventArgs e)
        {
            string textBoxText = NameOfUserTextBox.Text;

            if (string.IsNullOrWhiteSpace(textBoxText))
            {
                MessageBox.Show("Поле не должно быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (textBoxText.Length <= 2)
            {
                MessageBox.Show("Длина должна быть больше 2 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Regex.IsMatch(textBoxText, @"^\d+$"))
            {
                MessageBox.Show("Поле не должно содержать только цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.IsMatch(textBoxText, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Поле не должно содержать специальные символы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void ConnectToServer_Click(object sender, RoutedEventArgs e)
        {
            string WriteIP = IpAddress;
            string textBoxText = NameOfUserTextBox.Text;

            if (string.IsNullOrWhiteSpace(textBoxText))
            {
                MessageBox.Show("Поле не должно быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (textBoxText.Length <= 2)
            {
                MessageBox.Show("Длина должна быть больше 2 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Regex.IsMatch(textBoxText, @"^\d+$"))
            {
                MessageBox.Show("Поле не должно содержать только цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Regex.IsMatch(textBoxText, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Поле не должно содержать специальные символы.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(WriteIP))
            {
                MessageBox.Show("Вы не ввели IP-адрес.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
