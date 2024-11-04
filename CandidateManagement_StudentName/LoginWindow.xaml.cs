using CandidateManagement.BussinessObject;
using CandidateManagement.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CandidateManagement_StudentName
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IHRAccountServices hracountServices;
        public LoginWindow()
        {
            InitializeComponent();
            hracountServices = new HRAccountServices();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Hraccount hraccount = hracountServices.GetHraccountByEmail(txtEmail.Text);
            if (hraccount != null && hraccount.Password.Equals(txtPassword.Text) && hraccount.MemberRole == 1)
            {
                int? RoleID = hraccount.MemberRole;
                this.Hide();
                CandidateProfileWindow profileWindow = new CandidateProfileWindow();
                profileWindow.Show();
            }
            else 
            {
                MessageBox.Show("Invalid email or password");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}