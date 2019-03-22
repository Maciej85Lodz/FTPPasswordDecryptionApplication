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
            if (TextBox2.SelectedText != null)
            {
                TextBox3.Text = DecryptEngine.DecryptFtpPassword(TextBox2.Text);
            }
            else
                MessageBox.Show("This field cannot be empty!");
        }
    

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            if ()
            {
                TextBox2.Text = DecryptEngine.EncryptFtpPassword(TextBox1.Text);
            }
            else
                MessageBox.Show("This field cannot be empty!");
        }
    }
}
