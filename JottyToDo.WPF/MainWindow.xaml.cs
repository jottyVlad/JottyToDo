using JottyToDo.WPF.windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static JottyToDo.WPF.windows.ActionWindow;

namespace JottyToDo.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Создание окна MainWindow
        /// <summary>
        /// Создание окна MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Что нужно сделать ( Кнопка ) 
        /// <summary>
        /// Что нужно сделать
        /// </summary>
        private void NeedToDo_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ActionWindow action = new ActionWindow(ActionName.NeedToDo);
            action.MainWind = this;
            action.ShowDialog();
        }
        #endregion


        private void Doing_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ActionWindow action = new ActionWindow(ActionName.Doing);
            action.MainWind = this;
            action.ShowDialog();
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ActionWindow action = new ActionWindow(ActionName.Done);
            action.MainWind = this;
            action.ShowDialog();
        }
    }
}
