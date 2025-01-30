using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp2;
namespace WpfApp2
{
    internal class AddDepartamentAdminWindows
    {
           adminWindows adminWindows;
            
            private int _textBoxCount = 0;
            public void AddTextBoxes(Grid grid)
            {
              

            // Создание двух TextBox
            Label textBox1 = new Label
            {
                Content = "asdhahdahdhajkdhajkdhjkadhjkasdhakdhak",
                Margin = new Thickness(227,138,0,0) // Расположение
                
            };

                // Создаем второй TextBox
                TextBox textBox2 = new TextBox
                {
                    Width = 200,
                    Height = 30,
                    Margin = new Thickness(10, _textBoxCount * 40 + 50, 0, 0) // Расположение
                };

                // Добавляем TextBox в Grid
                adminWindows.adminGridHost.Children.Add(textBox1);
                adminWindows.adminGridHost.Children.Add(textBox2);

                _textBoxCount += 1; // Увеличиваем счетчик для следующей пары
                
            }
                
        }
    }

