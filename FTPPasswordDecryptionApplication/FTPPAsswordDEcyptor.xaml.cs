using System.Windows;
using System.Windows.Controls;

namespace FTPPasswordCryptographyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FTPPasswordDecyptor : Window
    {
        public FTPPasswordDecyptor()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox2.Text))
            {
                TextBox2.Text = "This field cannot be empty!";
            }
            else
                TextBox3.Text = CryptographyEngine.DecryptionFtpPassword(TextBox2.Text);
        }
    

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                TextBox1.Text = "This field cannot be empty!";
            }
            else
                TextBox2.Text = CryptographyEngine.EncryptionFtpPassword(TextBox1.Text);
        }
    }
}
