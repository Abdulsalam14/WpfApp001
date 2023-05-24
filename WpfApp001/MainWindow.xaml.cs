using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Data.SqlClient;

namespace WpfApp001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        Authorss authors = new Authorss();
        public Authorss AuthorsList { get { return authors; } }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            authors.GetAuthors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(name.Text) && !string.IsNullOrEmpty(surname.Text))
            {
                int a = authors.Count+1;
                Author newAuthor = new Author(a, name.Text, surname.Text);

                AuthorsList.AddAuthor(newAuthor);

                name.Text = string.Empty;
                surname.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("---");
            }

        }
    } 
}




