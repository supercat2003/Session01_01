using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Session01_01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-3CDDHCO8\\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=Session1_01");
        public MainWindow()
        {
            InitializeComponent();
            connection.Open();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable("users");
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM [dbo].[users] WHERE [LastName] = '" + login.Text+ "' AND [Password] = '"+ pass.Text +"'";
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dt);

                if (dt.Rows.Count > 0) {
                    if (dt.Rows[0][1].ToString() == "1") {
                        MessageBox.Show("admin");
                    }
                }
            }
            catch { 
            }
        }
    }
}
