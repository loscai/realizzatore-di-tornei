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
    /// Logica di interazione per SchermataFinale.xaml
    /// </summary>
    public partial class SchermataFinale : Window
    {
        const int salto = 5; //spazio tra un tasto e l'altro

        int nCaselleTotali;

        public Button[] ottavi = new Button[16];

        public Button[] quarti = new Button[8];

        public Button[] semifinali = new Button[4];

        public Button[] finale = new Button[2];




        int nSquadre;
        List<Squadra> squadraList;
        bool isTabellone;
        public SchermataFinale(String titolo, int nSquadre, List<Squadra> squadraList, bool isTabellone)
        {
            InitializeComponent();

            this.Title = titolo;
            this.squadraList = squadraList;
            this.nSquadre = nSquadre;
            this.isTabellone = isTabellone;

            this.nCaselleTotali = (nSquadre * 2) - 1;

            ottavi[0] = btn_ottavi_1;
            ottavi[1] = btn_ottavi_2;
            ottavi[2] = btn_ottavi_3;
            ottavi[3] = btn_ottavi_4;
            ottavi[4] = btn_ottavi_5;
            ottavi[5] = btn_ottavi_6;
            ottavi[6] = btn_ottavi_7;
            ottavi[7] = btn_ottavi_8;
            ottavi[8] = btn_ottavi_9;
            ottavi[9] = btn_ottavi_10;
            ottavi[10] = btn_ottavi_11;
            ottavi[11] = btn_ottavi_12;
            ottavi[12] = btn_ottavi_13;
            ottavi[13] = btn_ottavi_14;
            ottavi[14] = btn_ottavi_15;
            ottavi[15] = btn_ottavi_16;

            quarti[0] = btn_quarti_1;
            quarti[1] = btn_quarti_2;
            quarti[2] = btn_quarti_3;
            quarti[3] = btn_quarti_4;
            quarti[4] = btn_quarti_5;
            quarti[5] = btn_quarti_6;
            quarti[6] = btn_quarti_7;
            quarti[7] = btn_quarti_8;

            semifinali[0] = btn_semi_1;
            semifinali[1] = btn_semi_2;
            semifinali[2] = btn_semi_3;
            semifinali[3] = btn_semi_4;

            finale[0] = btn_finale_1;
            finale[1] = btn_finale_2;

            inizializzaTabellone();
        }

        public void inizializzaTabellone()
        {
            int n = this.nSquadre;

            switch (n)
            {
                case 2:
                    for (int i = 0; i < n; i++)
                    {
                        finale[i].Content = squadraList[i].ToString();
                    }
                    //setto a '/' tutte le caselle precedenti
                    for (int i = 0; i < 16; i++)
                    {
                        ottavi[i].Content = "/";
                        ottavi[i].IsEnabled = false;
                        if (i < 8)
                        {
                            quarti[i].Content = "/";
                            quarti[i].IsEnabled = false;
                            if (i < 4)
                            {
                                semifinali[i].Content = "/";
                                semifinali[i].IsEnabled = false;
                            }
                        }
                    }
                    break;

                case 4:

                    for (int i = 0; i < n; i++)
                    {
                        semifinali[i].Content = squadraList[i].Nome;
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        ottavi[i].Content = "/";
                        ottavi[i].IsEnabled = false;

                        if (i < 8)
                        {
                            quarti[i].Content = "/";
                            quarti[i].IsEnabled = false;
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < 16; i++)
                    {
                        ottavi[i].Content = "/";
                        ottavi[i].IsEnabled = false;
                        if (i < 8)
                            quarti[i].Content = squadraList[i].Nome;

                    }
                    break;
                case 16:
                    for (int i = 0; i < n; i++)
                    {
                        ottavi[i].Content = squadraList[i].Nome;
                    }
                    break;
            }
        }
        private void btn_ottavi_1_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_1.Content = btn_ottavi_1.Content;
            btn_ottavi_1.IsEnabled = false;
            btn_ottavi_2.IsEnabled = false;
        }

        private void btn_ottavi_2_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_1.Content = btn_ottavi_2.Content;
            btn_ottavi_1.IsEnabled = false;
            btn_ottavi_2.IsEnabled = false;
        }

        private void btn_ottavi_3_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_2.Content = btn_ottavi_3.Content;
            btn_ottavi_3.IsEnabled = false;
            btn_ottavi_4.IsEnabled = false;
        }

        private void btn_ottavi_4_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_2.Content = btn_ottavi_4.Content;
            btn_ottavi_3.IsEnabled = false;
            btn_ottavi_4.IsEnabled = false;
        }

        private void btn_ottavi_5_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_3.Content = btn_ottavi_5.Content;
            btn_ottavi_5.IsEnabled = false;
            btn_ottavi_6.IsEnabled = false;
        }

        private void btn_ottavi_6_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_3.Content = btn_ottavi_6.Content;
            btn_ottavi_5.IsEnabled = false;
            btn_ottavi_6.IsEnabled = false;
        }

        private void btn_ottavi_7_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_4.Content = btn_ottavi_7.Content;
            btn_ottavi_7.IsEnabled = false;
            btn_ottavi_8.IsEnabled = false;
        }

        private void btn_ottavi_8_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_4.Content = btn_ottavi_8.Content;
            btn_ottavi_7.IsEnabled = false;
            btn_ottavi_8.IsEnabled = false;
        }

        private void btn_ottavi_9_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_5.Content = btn_ottavi_9.Content;
            btn_ottavi_9.IsEnabled = false;
            btn_ottavi_10.IsEnabled = false;
        }

        private void btn_ottavi_10_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_5.Content = btn_ottavi_10.Content;
            btn_ottavi_9.IsEnabled = false;
            btn_ottavi_10.IsEnabled = false;
        }

        private void btn_ottavi_11_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_6.Content = btn_ottavi_11.Content;
            btn_ottavi_11.IsEnabled = false;
            btn_ottavi_12.IsEnabled = false;
        }

        private void btn_ottavi_12_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_6.Content = btn_ottavi_12.Content;
            btn_ottavi_11.IsEnabled = false;
            btn_ottavi_12.IsEnabled = false;
        }

        private void btn_ottavi_13_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_7.Content = btn_ottavi_13.Content;
            btn_ottavi_13.IsEnabled = false;
            btn_ottavi_14.IsEnabled = false;
        }

        private void btn_ottavi_14_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_7.Content = btn_ottavi_14.Content;
            btn_ottavi_13.IsEnabled = false;
            btn_ottavi_14.IsEnabled = false;
        }

        private void btn_ottavi_15_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_8.Content = btn_ottavi_15.Content;
            btn_ottavi_15.IsEnabled = false;
            btn_ottavi_16.IsEnabled = false;
        }

        private void btn_ottavi_16_Click(object sender, RoutedEventArgs e)
        {
            btn_quarti_8.Content = btn_ottavi_16.Content;
            btn_ottavi_15.IsEnabled = false;
            btn_ottavi_16.IsEnabled = false;
        }

        private void btn_quarti_1_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_1.Content = btn_quarti_1.Content;
            btn_quarti_1.IsEnabled = false;
            btn_quarti_2.IsEnabled = false;
        }

        private void btn_quarti_2_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_1.Content = btn_quarti_2.Content;
            btn_quarti_1.IsEnabled = false;
            btn_quarti_2.IsEnabled = false;
        }

        private void btn_quarti_3_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_2.Content = btn_quarti_3.Content;
            btn_quarti_3.IsEnabled = false;
            btn_quarti_4.IsEnabled = false;
        }

        private void btn_quarti_4_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_2.Content = btn_quarti_4.Content;
            btn_quarti_3.IsEnabled = false;
            btn_quarti_4.IsEnabled = false;
        }

        private void btn_quarti_5_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_3.Content = btn_quarti_5.Content;
            btn_quarti_5.IsEnabled = false;
            btn_quarti_6.IsEnabled = false;
        }

        private void btn_quarti_6_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_3.Content = btn_quarti_6.Content;
            btn_quarti_5.IsEnabled = false;
            btn_quarti_6.IsEnabled = false;
        }

        private void btn_quarti_7_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_4.Content = btn_quarti_7.Content;
            btn_quarti_7.IsEnabled = false;
            btn_quarti_8.IsEnabled = false;
        }

        private void btn_quarti_8_Click(object sender, RoutedEventArgs e)
        {
            btn_semi_4.Content = btn_quarti_8.Content;
            btn_quarti_7.IsEnabled = false;
            btn_quarti_8.IsEnabled = false;
        }

        private void btn_semi_1_Click(object sender, RoutedEventArgs e)
        {
            btn_finale_1.Content = btn_semi_1.Content;
            btn_semi_1.IsEnabled = false;
            btn_semi_2.IsEnabled = false;
        }

        private void btn_semi_2_Click(object sender, RoutedEventArgs e)
        {
            btn_finale_1.Content = btn_semi_2.Content;
            btn_semi_1.IsEnabled = false;
            btn_semi_2.IsEnabled = false;
        }

        private void btn_semi_3_Click(object sender, RoutedEventArgs e)
        {
            btn_finale_2.Content = btn_semi_3.Content;
            btn_semi_3.IsEnabled = false;
            btn_semi_4.IsEnabled = false;
        }

        private void btn_semi_4_Click(object sender, RoutedEventArgs e)
        {
            btn_finale_2.Content = btn_semi_4.Content;
            btn_semi_3.IsEnabled = false;
            btn_semi_4.IsEnabled = false;
        }

        private void btn_finale_1_Click(object sender, RoutedEventArgs e)
        {
            btn_vincitore.Content = btn_finale_1.Content;
            btn_finale_1.IsEnabled = false;
            btn_finale_2.IsEnabled = false;
            MessageBox.Show("Vince la Squadra [ " + btn_vincitore.Content + " ]");
        }

        private void btn_finale_2_Click(object sender, RoutedEventArgs e)
        {
            btn_vincitore.Content = btn_finale_2.Content;
            btn_finale_1.IsEnabled = false;
            btn_finale_2.IsEnabled = false;
            MessageBox.Show("Vince la Squadra [ " + btn_vincitore.Content + " ]");
        }
    }
}