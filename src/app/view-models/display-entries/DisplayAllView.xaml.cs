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

namespace RecipeApp
{
    /// <summary>
    /// Interaction logic for ViewAllPage.xaml
    /// </summary>
    public partial class DisplayAllView : Page
    {
        public DisplayAllView()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var context = (DisplayAllViewModel)DataContext;
            var senderContext = ((Control)sender).DataContext;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this entry?\nThis action cannot be undone.", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                context.DeleteCommand.Execute((RecipeData)senderContext);
            }
        }
    }
}
