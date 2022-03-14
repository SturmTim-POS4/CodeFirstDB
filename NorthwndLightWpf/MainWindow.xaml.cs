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
using CodeFirstDB;

namespace NorthwndLightWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthwndLightViewModel _viewModel;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new NorthwndLightDbContext();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                _viewModel = new NorthwndLightViewModel().Init(db);
                DataContext = _viewModel;
                int nr = db.Customers.Count();
                Title = $"{nr} Customers";
            }
            catch (Exception exc)
            {
                Title = exc.Message;
            }
        }

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {

            _viewModel.SelectedOrder = (Order) e.NewValue;
        }
    }
}