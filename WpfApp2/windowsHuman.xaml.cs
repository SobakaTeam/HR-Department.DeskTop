using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для windowsHuman.xaml
    /// </summary>
    public partial class windowsHuman : Window
    {
        private List<string> _suggestions;
        public windowsHuman()
        {
            InitializeComponent();
            _suggestions = new List<string> { "Руководитель", "Бугалтер", "Аналитик", "Бизекс Информатик", "Уборщик,Johny Sins" };
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void toСhange_Click(object sender, RoutedEventArgs e)
        {
            toСhange.Visibility = Visibility.Collapsed;
            toСhange1.Visibility = Visibility.Visible;

            //Фамилия
            textBlockLastName.Visibility = Visibility.Collapsed;
            textBoxLastName.Visibility = Visibility.Visible;
            textBoxLastName.Text = textBlockLastName.Text;

            //Имя
            textBlockName.Visibility = Visibility.Collapsed;
            textBoxName.Visibility = Visibility.Visible;
            textBoxName.Text = textBlockName.Text;

            //Отчество
            textBlockpatronymic.Visibility = Visibility.Collapsed;
            textBoxpatronymic.Visibility = Visibility.Visible;
            textBoxpatronymic.Text = textBlockpatronymic.Text;

            //Дата рождения
            textBlockDateOfBirth.Visibility = Visibility.Collapsed;
            textBoxDateOfBirth.Visibility = Visibility.Visible;
            textBoxDateOfBirth.Text = textBlockDateOfBirth.Text;

            //Должность
            textBlockpost.Visibility = Visibility.Collapsed;
            textBoxkpost.Visibility = Visibility.Visible;
            textBoxkpost.Text = textBlockpost.Text;

            //Дата регестрации
            textBlockDataRegistor.Visibility = Visibility.Collapsed;
            textBoxDataRegistor.Visibility = Visibility.Visible;
            textBoxDataRegistor.Text = textBlockDataRegistor.Text;

            //Отпуск
            textBlockVacation.Visibility = Visibility.Collapsed;
            textBoxVacation.Visibility = Visibility.Visible;
            textBoxVacation.Text = textBlockVacation.Text;

        }

        private void toСhange1_Click(object sender, RoutedEventArgs e)
        {
            toСhange.Visibility = Visibility.Visible;
            toСhange1.Visibility = Visibility.Collapsed;
            //Фамилия
                if (textBoxLastName.Text != "" && textBoxLastName.Text != "ФАМИЛИЯ")
                {
                if (!Regex.IsMatch(textBoxLastName.Text, @"^[а-яА-Яa-zA-Z]+$"))
                {
                    MessageBox.Show("В строке фамилия могут быть только буквы", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                    textBoxLastName.Text = textBlockLastName.Text;

                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                }
                else
                {
                    textBlockLastName.Visibility = Visibility.Visible;
                    textBoxLastName.Visibility = Visibility.Collapsed;
                    textBlockLastName.Text = textBoxLastName.Text;     
                }
                }
                else
                {
                    MessageBox.Show("Поле Фамилия не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxLastName.Text = textBlockLastName.Text;
                }
            

            //Имя
                if (textBoxName.Text != "" && textBoxName.Text != "ИМЯ")
                {
                    if (!Regex.IsMatch(textBoxName.Text, @"^[а-яА-Яa-zA-Z]+$"))
                    {
                        MessageBox.Show("В строке Имя могут быть только буквы", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBoxName.Text = textBlockName.Text;

                        toСhange.Visibility = Visibility.Collapsed;
                        toСhange1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        textBlockName.Visibility = Visibility.Visible;
                        textBoxName.Visibility = Visibility.Collapsed;

                        textBlockName.Text = textBoxName.Text;   
                    }
                }
                else
                {
                    MessageBox.Show("Поле Имя не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxName.Text = textBlockName.Text;
                }
            

            //Отчество
                if (textBoxpatronymic.Text != "" && textBoxpatronymic.Text != "ОТЧЕСТВО")
                {
                    if (!Regex.IsMatch(textBoxpatronymic.Text, @"^[а-яА-Яa-zA-Z]+$"))
                    {
                        MessageBox.Show("В строке Отчество могут быть только буквы", "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBoxpatronymic.Text = textBlockpatronymic.Text;

                        toСhange.Visibility = Visibility.Collapsed;
                        toСhange1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        textBlockpatronymic.Visibility = Visibility.Visible;
                        textBoxpatronymic.Visibility = Visibility.Collapsed;

                        textBlockpatronymic.Text = textBoxpatronymic.Text;
                    }
                }
                else
                {
                    MessageBox.Show("Поле Отчество не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxpatronymic.Text = textBlockpatronymic.Text;
                }
            
            //Дата рождения
            if (textBoxDateOfBirth.Text == "ДАТА.РОЖДЕНИЯ: " + (DataBAnk.dateonly.ToString("dd-MM-yyyy")))
            {
                textBoxDateOfBirth.Text = DataBAnk.dateonly.ToString("dd-MM-yyyy");
            }
            if (textBoxDateOfBirth.Text != "" && textBoxDateOfBirth.Text != "ДАТА.РОЖДЕНИЯ")
            {
                try
                {
                    DataBAnk.datatime = Convert.ToDateTime(textBoxDateOfBirth.Text);
                    DataBAnk.dateonly = DataBAnk.datatime.Date;
                    textBlockDateOfBirth.Text = "ДАТА.РОЖДЕНИЯ: " + (DataBAnk.dateonly.ToString("dd-MM-yyyy"));
                    textBlockDateOfBirth.Visibility = Visibility.Visible;
                    textBoxDateOfBirth.Visibility = Visibility.Collapsed;

                }
                catch (FormatException)
                {
                    MessageBox.Show("Ошибка формата в дате рождения", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxDateOfBirth.Text = textBlockDateOfBirth.Text;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Поле даты рождения не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                toСhange.Visibility = Visibility.Collapsed;
                toСhange1.Visibility = Visibility.Visible;
                textBoxDateOfBirth.Text = textBlockDateOfBirth.Text;
            }

            //Должность
            if (textBoxkpost.Text != "" && textBoxkpost.Text != "ДОЛЖНОСТЬ")
            {
                textBlockpost.Visibility = Visibility.Visible;
                textBoxkpost.Visibility = Visibility.Collapsed; 
                if(textBoxkpost.Text == DataBAnk.post + textBoxkpost.Text)
                {
                    textBoxkpost.Text = textBoxkpost.Text;
                }
                textBlockpost.Text = DataBAnk.post + textBoxkpost.Text;
            }
            else
            {
                MessageBox.Show("Поле Должность не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                toСhange.Visibility = Visibility.Collapsed;
                toСhange1.Visibility = Visibility.Visible;
                textBoxkpost.Text = textBlockpost.Text;
            }


            //Дата регестрации
            if (textBoxDataRegistor.Text == "ДАТА.РЕГИСТРАЦИИ: " + (DataBAnk.dateonlyregistor.ToString("dd-MM-yyyy")))
            {
                textBoxDataRegistor.Text = DataBAnk.dateonlyregistor.ToString("dd-MM-yyyy");
            }
            if (textBoxDataRegistor.Text != "" && textBoxDataRegistor.Text != "ДАТА.РЕГИСТРАЦИИ")
            {
                try
                {
                    if(DataBAnk.dateonlyregistor > DataBAnk.dateonly)
                    {
                        MessageBox.Show("Дата регестрации не может быть раньше чем дата рождения","Предупреждение!",MessageBoxButton.OK,MessageBoxImage.Information);
                    }
                    else
                    {
                        DataBAnk.datatimeregistor = Convert.ToDateTime(textBoxDataRegistor.Text);
                        DataBAnk.dateonlyregistor = DataBAnk.datatimeregistor.Date;
                        textBlockDataRegistor.Text = "ДАТА.РЕГИСТРАЦИИ: " + (DataBAnk.dateonlyregistor.ToString("dd-MM-yyyy"));
                        textBlockDataRegistor.Visibility = Visibility.Visible;
                        textBoxDataRegistor.Visibility = Visibility.Collapsed;
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ошибка формата в дате регестрации", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxDataRegistor.Text = textBlockDataRegistor.Text;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Поле даты регестрации не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                toСhange.Visibility = Visibility.Collapsed;
                toСhange1.Visibility = Visibility.Visible;
                textBoxDataRegistor.Text = textBlockDataRegistor.Text;
            }

            //Отпуск
            if (textBoxVacation.Text == "Отпуск " + $"От: {DataBAnk.Datenow} " + "До: " + (DataBAnk.dateonlyregistorVacation.ToString("dd-MM-yyyy")))
            {
                textBoxVacation.Text = DataBAnk.dateonlyregistorVacation.ToString("dd-MM-yyyy");
            }
            if (textBoxVacation.Text != "" && textBoxVacation.Text != "ОТПУСК")
            {
                try
                {
                    DataBAnk.datatimeVacation = Convert.ToDateTime(textBoxVacation.Text);
                    DataBAnk.dateonlyregistorVacation = DataBAnk.datatimeVacation.Date;
                    DataBAnk.Datenow = DateTime.Now.Date.ToString("dd-MM-yyyy");

                    if(Convert.ToDateTime(DataBAnk.Datenow) < Convert.ToDateTime(DataBAnk.dateonlyregistorVacation))
                    {
                        textBlockVacation.Text = "Отпуск " + $"От: {DataBAnk.Datenow} " + "До: " + (DataBAnk.dateonlyregistorVacation.ToString("dd-MM-yyyy"));
                        textBlockVacation.Visibility = Visibility.Visible;
                        textBoxVacation.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        MessageBox.Show("Отпуск не может быть меньше 1 дня","Предупреждение!", MessageBoxButton.OK,MessageBoxImage.Information);
                        textBoxVacation.Text = textBlockVacation.Text;

                        toСhange.Visibility = Visibility.Collapsed;
                        toСhange1.Visibility = Visibility.Visible;
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ошибка формата в поле отпуска", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    toСhange.Visibility = Visibility.Collapsed;
                    toСhange1.Visibility = Visibility.Visible;
                    textBoxVacation.Text = textBlockVacation.Text;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {
                MessageBox.Show("Поле даты регестрации не может быть пустым", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                textBoxVacation.Text = textBlockVacation.Text;
                toСhange.Visibility = Visibility.Collapsed;
                toСhange1.Visibility = Visibility.Visible;

            }
        }




        private void textBoxkpost_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = textBoxkpost.Text;
            if (string.IsNullOrEmpty(text))
            {
                suggestionsListBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                var filteredSuggestions = _suggestions.Where(s => s.StartsWith(text, System.StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (filteredSuggestions.Count > 0)
                {
                    suggestionsListBox.ItemsSource = filteredSuggestions;
                    suggestionsListBox.Visibility = Visibility.Visible;
                }
                else
                {
                    suggestionsListBox.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void suggestionsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (suggestionsListBox.SelectedItem != null)
            {
                textBoxkpost.Text = suggestionsListBox.SelectedItem.ToString();
                suggestionsListBox.Visibility = Visibility.Collapsed;
                textBoxkpost.Focus();
                textBoxkpost.CaretIndex = textBoxkpost.Text.Length; // Устанавливаем курсор в конец текста
            }
        }
        //Фамилия
        private void textBoxLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        

        }
        //Имя
        private void textBoxName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }
        //Отчество
        private void textBoxpatronymic_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-ЯёЁ]+$");
            e.Handled = !regex.IsMatch(e.Text);
        }





        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(education.Content) == "ОБРАЗОВАНИЕ")
            {
                education.Content = "Изменить Образование";
                education.FontSize = 9;
            }
            else
            {
                if (Convert.ToString (education.Content) == "Изменить Образование")
                {
                    education.Content = "ОБРАЗОВАНИЕ";
                    education.FontSize = 13;
                }
            }
           
            if(Convert.ToString(pasport.Content) == "ПАСПОРТ")
            {
                pasport.Content = "Изменить Паспорт";
            }
            else
            {
                if (Convert.ToString(pasport.Content) == "Изменить Паспорт")
                {
                    pasport.Content = "ПАСПОРТ";
                }
            }
            

            
           
        }

        private void pasport_Click(object sender, RoutedEventArgs e)
        {
            if(Convert.ToString(pasport.Content) == "ПАСПОРТ" )
            {
                if(DataBAnk.filePath == null)
                {
                    MessageBox.Show("У этого человека ещё нету пасорта!","Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    pas.Source = new BitmapImage(new Uri(DataBAnk.filePath));

                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;",
                    Title = "Выберите фото"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    // Получаем путь к выбранному файлу
                    DataBAnk.filePath = openFileDialog.FileName;
                    if(openFileDialog.FileName != null)
                    {
                        MessageBox.Show("Паспорт успешно добавлен","Успех!",MessageBoxButton.OK);
                    }
                }
            }
           
        }

        private void education_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancellation_Click(object sender, RoutedEventArgs e)
        {
            toСhange.Visibility = Visibility.Visible;
            toСhange1.Visibility = Visibility.Collapsed;

            //фамилия
            textBlockLastName.Text = "ФАМИЛИЯ";
            textBlockLastName.Visibility = Visibility.Visible;
            textBoxLastName.Visibility = Visibility.Collapsed;

            //Имя
            textBlockName.Text = "ИМЯ";
            textBlockName.Visibility = Visibility.Visible;
            textBoxName.Visibility = Visibility.Collapsed;

            //Отчество
            textBlockpatronymic.Text = "ОТЧЕСТВО";
            textBlockpatronymic.Visibility = Visibility.Visible;
            textBoxpatronymic.Visibility = Visibility.Collapsed;

            //Дата рождения
            textBlockDateOfBirth.Text = "ДАТА.РОЖДЕНИЯ";
            textBlockDateOfBirth.Visibility = Visibility.Visible;
            textBoxDateOfBirth.Visibility = Visibility.Collapsed;
            //Должность
            textBlockpost.Text = "ДОЛЖНОСТЬ";
            textBlockpost.Visibility = Visibility.Visible;
            textBoxkpost.Visibility = Visibility.Collapsed;

            //Дата регестрации
            textBlockDataRegistor.Text = "ДАТА РЕГЕСТРАЦИИ";
            textBlockDataRegistor.Visibility = Visibility.Visible;
            textBoxDataRegistor.Visibility = Visibility.Collapsed;
            //Отпуск
            textBlockVacation.Text = "ОТПУСК";
            textBlockVacation.Visibility = Visibility.Visible;
            textBoxVacation.Visibility = Visibility.Collapsed;
        }
    }
}




  


