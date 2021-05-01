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
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace GetStartedWPF_DatabaseLink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ProductContext _context =
            new ProductContext();

        private CollectionViewSource categoryViewSource;

        public MainWindow()
        {
            var db = new ProductContext();
            db.Add(new Product { ProductId = 2, Name = "Banan", CategoryId = 1 });
            db.SaveChanges();

            InitializeComponent();


            categoryViewSource =
                (CollectionViewSource)FindResource(nameof(categoryViewSource));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            _context.Database.EnsureCreated();

            // load the entities into EF Core
            _context.Categories.Load();

            // bind to the source
            categoryViewSource.Source =
                _context.Categories.Local.ToObservableCollection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // all changes are automatically tracked, including
            // deletes!
            _context.SaveChanges();

            // this forces the grid to refresh to latest values
            categoryDataGrid.Items.Refresh();
            productsDataGrid.Items.Refresh();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            _context.Dispose();
            base.OnClosing(e);
        }

        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
