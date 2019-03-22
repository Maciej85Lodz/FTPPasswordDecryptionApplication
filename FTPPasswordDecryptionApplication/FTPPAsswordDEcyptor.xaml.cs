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

namespace FTPPasswordDecryptionApplication
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
                MessageBox.Show("This field cannot be empty!");
            }
            else
                TextBox3.Text = CryptographyEngine.DecryptionFtpPassword(TextBox2.Text);
        }
    

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                MessageBox.Show("This field cannot be empty!");
            }
            else
                TextBox2.Text = CryptographyEngine.EncryptionFtpPassword(TextBox1.Text);
        }
    }
}
