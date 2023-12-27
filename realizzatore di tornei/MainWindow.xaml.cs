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
        const int maxNumeSquadre = 16;
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
            if (listbox_squadre.Items.Count > 0 && listbox_squadre.SelectedItem != null)
            {
                elimina_btn.IsEnabled = true;
                nome_squadra_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].Nome;
                n_squadre_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].NMembri.ToString();
            }
            else
            {
                listbox_squadre.SelectedIndex = 0;
            }
        }

        private void avvia_btn_Click(object sender, RoutedEventArgs e)
        {
            //controllo che il campo del testo del torneo non sia vuoto e che nella lista ci siano almeno 4 teams
            
            if(nome_torneo_txtbox.Text == string.Empty)
            {
                MessageBox.Show("Inserire il nome alla competizione");
            }
            else if(listbox_squadre.Items.Count  != 2 && listbox_squadre.Items.Count != 4 && listbox_squadre.Items.Count != 8 && listbox_squadre.Items.Count != 16)
            {
                MessageBox.Show("Il numero di squadre deve essere pari e uno di questi valori: 2,4,8,16");
            }
            else
            {
                SchermataFinale sf;
                if (radio_btn_gironi.IsChecked == true)
                {
                    sf = new SchermataFinale(nome_torneo_txtbox.Text, listbox_squadre.Items.Count, squadraList, false);
                }
                else
                {
                    sf = new SchermataFinale(nome_torneo_txtbox.Text, listbox_squadre.Items.Count, squadraList, true);
                }
                this.Hide();

                sf.ShowDialog();

                this.Close();
            }
        }

        private void elimina_btn_Click(object sender, RoutedEventArgs e)
        {
            if(listbox_squadre.Items.Count == 1)
            {
                MessageBox.Show("Non puoi eliminare l'ultima squadra rimasta, creane prima un'altra");
            }
            else
            {
                listbox_squadre.Items.RemoveAt(listbox_squadre.SelectedIndex);
                squadraList.Remove(squadraList[listbox_squadre.SelectedIndex]);
                listbox_squadre.SelectedIndex = 0;
            }

        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            listbox_squadre.Items.Clear();
            squadraList.Clear();

            elimina_btn.IsEnabled = false;
            nome_squadra_txtbox.Text = string.Empty;
            n_squadre_txtbox.Text = string.Empty;
        }
    }
}