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
using System.Windows.Shapes;

namespace realizzatore_di_tornei
{
    /// <summary>
    /// Logica di interazione per addTotSquadre.xaml
    /// </summary>
    public partial class addTotSquadre : Window
    {
        public addTotSquadre()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            bool isValido = true;
            for (int i = 0; i < txt_num.MaxLength; i++)
            {
                if (txt_num.Text[i] < '0' || txt_num.Text[i] > '9')
                {
                    MessageBox.Show("Numero non valido");
                    break;
                    isValido = false;
                }
            }
            if (isValido)
            {
                this.Close();
            }

        }
    }
}
