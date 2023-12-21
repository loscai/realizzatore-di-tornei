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

namespace realizzatore_di_tornei
{
    //https://github.com/loscai/realizzatore-di-tornei

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        const int maxNumeSquadre = 32;
        List <Squadra> squadraList = new List<Squadra>();
        public MainWindow()
        {
            InitializeComponent();

            radio_btn_tabellone.IsChecked = true;
        }

        private void add_sq_button_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_squadre.Items.Count < maxNumeSquadre)
            {
                addSquadra a = new addSquadra();

                this.Hide();

                a.ShowDialog();

                listbox_squadre.Items.Add(a.sq);
                squadraList.Add(a.sq);
                this.Show();
            }
            else
            {
                MessageBox.Show("Numero Massimo di squadre raggiunto");
            }
        }

        private void listbox_squadre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            elimina_btn.IsEnabled = true;
            nome_squadra_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].Nome;
            n_squadre_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].NMembri.ToString();
        }

        private void avvia_btn_Click(object sender, RoutedEventArgs e)
        {
            //controllo che il campo del testo del torneo non sia vuoto e che nella lista ci siano almeno 4 teams
            if(nome_torneo_txtbox.Text != string.Empty && listbox_squadre.Items.Count > 3 && listbox_squadre.Items.Count % 4 == 0)
            {
                SchermataFinale sf;
                if (radio_btn_gironi.IsChecked == true)
                {
                    sf = new SchermataFinale(nome_torneo_txtbox.Text, listbox_squadre.Items.Count, squadraList,false);
                }
                else
                {
                    sf = new SchermataFinale(nome_torneo_txtbox.Text, listbox_squadre.Items.Count, squadraList, true);
                }
                this.Hide();

                sf.ShowDialog();

                this.Show();
            }
            else if(nome_torneo_txtbox.Text == string.Empty && listbox_squadre.Items.Count < 4)
            {
                MessageBox.Show("Inserire il nome alla competizione || Bisogna inserire almeno 4 squadre");
            }
            else if(nome_torneo_txtbox.Text == string.Empty)
            {
                MessageBox.Show("Inserire il nome alla competizione");
            }
            else if(listbox_squadre.Items.Count < 4)
            {
                MessageBox.Show("Bisogna inserire almeno 4 squadre");
            }
            else if(listbox_squadre.Items.Count % 4 != 0)
            {
                MessageBox.Show("Il numero di squadre deve essere pari e divisibili per 4");
            }
        }

        private void elimina_btn_Click(object sender, RoutedEventArgs e)
        {
            listbox_squadre.SelectedItem = null;
            squadraList[listbox_squadre.SelectedIndex] = null;
        }
    }
}