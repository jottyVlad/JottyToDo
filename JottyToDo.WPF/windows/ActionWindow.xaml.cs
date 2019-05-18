using JottyToDo.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace JottyToDo.WPF.windows
{
    /// <summary>
    /// Логика взаимодействия для ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        #region Поля ActionWindow
        public MainWindow MainWind { get; set; }
        public enum ActionName
        {
            NeedToDo,
            Doing, 
            Done
        }
        private ActionName ActionId { get; set; }
        private List<string> items = new List<string>();
        private ActionsForm ActionsClass;
        #endregion
        public ActionWindow(ActionName actId)
        {
            InitializeComponent();
            ActionId = actId;

            var formatter = new BinaryFormatter();

            try
            {
                switch (ActionId)
                {
                    case ActionName.Doing:
                        using (var fs = new FileStream("doing.dat", FileMode.OpenOrCreate))
                        {
                            ActionsClass = formatter.Deserialize(fs) as Doing;
                            items.Add(ActionsClass.action);
                        }
                        break;
                    case ActionName.NeedToDo:
                        using (var fs = new FileStream("needtodo.dat", FileMode.OpenOrCreate))
                        {
                            ActionsClass = formatter.Deserialize(fs) as NeedToDo;
                            items.Add(ActionsClass.action);
                        }
                        break;
                    case ActionName.Done:
                        using (var fs = new FileStream("done.dat", FileMode.OpenOrCreate))
                        {
                            ActionsClass = formatter.Deserialize(fs) as Done;
                            items.Add(ActionsClass.action);
                        }
                        break;
                }
            }
            catch
            {
                return;
            }

            comboBox.ItemsSource = items;

            this.Closing += ActionWindow_Closing;
        }
        #region При закрытии окна
        private void ActionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWind.Show();
        }
        #endregion
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            button_edit.Visibility = Visibility.Visible;
        }

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            var add_actions = new AddActions(ActionId);
            add_actions.ShowDialog();
        }
    }
}
