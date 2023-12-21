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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List <Squadra> squadraList = new List<Squadra>();
        public MainWindow()
        {
            InitializeComponent();

            radio_btn_tabellone.IsChecked = true;
        }

        private void add_sq_button_Click(object sender, RoutedEventArgs e)
        {
            addSquadra a = new addSquadra();

            this.Hide();

            a.ShowDialog();

            listbox_squadre.Items.Add(a.sq);
            squadraList.Add(a.sq);
            this.Show();
        }

        private void listbox_squadre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nome_squadra_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].Nome;
            n_squadre_txtbox.Text = squadraList[listbox_squadre.SelectedIndex].NMembri.ToString();
        }
    }
}

