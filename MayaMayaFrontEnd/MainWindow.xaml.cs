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
using MayaMayaCore.Services;
using MayaMayaFrontEnd.Helpers;

namespace MayaMayaFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            UserService us = new UserService();
            InitializeComponent();
            int id;
            if (us.CheckCredentials("ikkedus", "Voc@l0id", out id))
            {
                CurrentUser.SetCurrentUser(id);
                lblName.Content = CurrentUser.Firstname;
            }
        }
    }
}
