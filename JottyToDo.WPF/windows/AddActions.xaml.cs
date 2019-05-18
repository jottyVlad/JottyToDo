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
using static JottyToDo.WPF.windows.ActionWindow;
using JottyToDo.BL;

namespace JottyToDo.WPF.windows
{
    /// <summary>
    /// Логика взаимодействия для AddActions.xaml
    /// </summary>
    public partial class AddActions : Window
    {
        private ActionName ActionId { get; set; }
        private string FileName { get; set; }

        public AddActions(ActionName actId)
        {
            InitializeComponent();

            ActionId = actId;

            if(actId == ActionName.Doing)
            {
                FileName = "doing.dat";
            }
            else if (actId == ActionName.NeedToDo)
            {
                FileName = "needtodo.dat";
            }
            else
            {
                FileName = "done.dat";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var formatter = new BinaryFormatter();
            switch (ActionId)
            {
                case ActionName.Doing:
                    var DoingClass = new Doing(Time.SelectedDate.Value, ActionNameText.Text);

                    using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, DoingClass);
                    }
                    break;
                case ActionName.NeedToDo:
                    var NeedToDoClass = new NeedToDo(Time.SelectedDate.Value, ActionNameText.Text);

                    using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, NeedToDoClass);
                    }
                    break;
                case ActionName.Done:
                    var DoneClass = new Done(Time.SelectedDate.Value, ActionNameText.Text);

                    using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, DoneClass);
                    }
                    break;
            }
        }
    }
}
