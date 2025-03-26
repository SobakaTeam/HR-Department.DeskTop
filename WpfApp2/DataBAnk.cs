using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    static class DataBAnk
    {
        public static string name;
        public static string Department;
        public static List<string> names = new List<string>();
        public static List<string> Departments = new List<string>();
        //Дата рождения
        public static DateTime datatime;
        public static DateTime dateonly;
        //Дата регестрации
        public static DateTime datatimeregistor;
        public static DateTime dateonlyregistor;
        //Отпуск
        public static String Datenow;
        public static DateTime datatimeVacation;
        public static DateTime dateonlyregistorVacation;
        //паспорт
        public static string filePath;
        //Образование
        public static string filepath1;
        //ОТМЕНА
        public static string Name;
        public static string LastName;
        public static string patronymic;
        public static string DateOfBirth;
        public static string post;
        public static string DataRegistor;
        public static string Vacation;
        public static string Phone;

    }
   
}
