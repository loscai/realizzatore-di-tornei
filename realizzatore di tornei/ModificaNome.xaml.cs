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
    /// Logica di interazione per ModificaNome.xaml
    /// </summary>
    public partial class ModificaNome : Window
    {
        public Squadra sq;
        public ModificaNome(Squadra squadraVecchia)
        {
            InitializeComponent();

            this.sq = squadraVecchia;
        }


        private void invia_btn_Click(object sender, RoutedEventArgs e)
        {
            if(nuovoNome_txtbox.Text != string.Empty)
            {
                Squadra s = new Squadra(nuovoNome_txtbox.Text);
                this.sq = s;
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserire un nome!");
            }
        }
    }
}
