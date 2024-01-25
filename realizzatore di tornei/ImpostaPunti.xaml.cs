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
    /// Logica di interazione per ImpostaPunti.xaml
    /// </summary>
    public partial class ImpostaPunti : Window
    {
        int indiceVettore;
        List<Squadra> v;

        public ImpostaPunti(int indiceVettore, List<Squadra> v)
        {
            InitializeComponent();
            this.indiceVettore = indiceVettore;
            this.v = v;
        }

        private void btn_invia_Click(object sender, RoutedEventArgs e)
        {
            int numero;

            //controllo sulle textbox
            if (!Int32.TryParse(txtbox_punti_sq1.Text, out numero) || !Int32.TryParse(txtbox_punti_sq2.Text, out numero))
            {
                MessageBox.Show("Numero non valido");
            }
            else
            {
                if(indiceVettore %2  == 0)
                {
                    v[indiceVettore - 1].PuntiFatti = Int32.Parse(txtbox_punti_sq1.Text);
                    v[indiceVettore].PuntiFatti = Int32.Parse(txtbox_punti_sq2.Text);
                }
                else
                {
                    v[indiceVettore].PuntiFatti = Int32.Parse(txtbox_punti_sq1.Text);
                    v[indiceVettore + 1].PuntiFatti = Int32.Parse(txtbox_punti_sq2.Text);
                }
                this.Close();
            }
        }
    }
}
