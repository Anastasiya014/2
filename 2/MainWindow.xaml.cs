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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_1;
using LibMas;
using Масивы;

namespace _2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Вывод информации о программе
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Васинкина Анастасия. Практическая работа №2 \n\n" +
               "Ввести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран.","О программе");
        }

        //Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int[] Array;
        
        //Редактирование ячеек
        private void ArrayDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Очищаем textbox с результатом 
            rez1.Clear();

            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;

            //Заносим  отредактированное значение в соответствующую ячейку массива
            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out Array[columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }

        //Заполнение массива
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            
            //Проверка поля на корректность введенных данных
            if (Int32.TryParse(KolKolonok.Text, out int count) && count > 0)
            {
                Class1.FillWithout_0(count, out Array);
                
                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(Array).DefaultView;

                //очищаем результат
                rez1.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        //Расчет задания для массива
        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            rez1.Clear();
            
            if (Array == null || Array.Length == 0)
            {
                MessageBox.Show("Вы не создали массив, укажите количество колонок, диапазон чисел и нажмите кнопку ЗАПОЛНИТЬ", "Ошибка");
            }
            else
            {
                int proiz = Class2.calculate(Array);
                rez1.Text = Convert.ToString(proiz);
            }
        }
        //Очищение массива
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Class1.Clear(Array);

            //Очищаем результат массива
            rez1.Clear();
           
            //Выводим массив на форму
            masData.ItemsSource = VisualArray.ToDataTable(Array).DefaultView;
        }
        //Сохранение массива
        private void Savemas_Click(object sender, RoutedEventArgs e)
        {
            Class1.Savemas(Array);
        }

        //Открытие массива
        private void Openmas_Click(object sender, RoutedEventArgs e)
        {
            
            Class1.Openmas( out Array);
            for (int i = 0; i < Array.Length; i++)
            {
                //Выводим массив на форму
                masData.ItemsSource = VisualArray.ToDataTable(Array).DefaultView;
            }
        }

    }
}
