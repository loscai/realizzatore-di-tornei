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

        Button[] caselle;

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

            caselle = new Button[nCaselleTotali];

            for (int i = 0; i < caselle.Length; i++)
            {
                if (i < nSquadre)
                {
                    caselle[i] = new Button();
                    caselle[i].Content = squadraList[i].Nome;
                    caselle[i].Width = 50;
                    caselle[i].Height = 25;
                    caselle[i].VerticalAlignment = VerticalAlignment.Top;
                    caselle[i].HorizontalAlignment = HorizontalAlignment.Left;
                }
                else
                {
                    caselle[i] = new Button();
                    caselle[i].Content = string.Empty;
                    caselle[i].Width = 50;
                    caselle[i].Height = 25;
                    caselle[i].VerticalAlignment = VerticalAlignment.Top;
                    caselle[i].HorizontalAlignment = HorizontalAlignment.Left;
                }
            }

            disegnaColonna(nSquadre);
        }

        public void disegnaColonna(int nSquadre)
        {
            for (int i = 0; i < Math.Sqrt(nSquadre); i++)
            {
                Grid1.Children.Add(caselle[i]);

                for (global::System.Int32 j = 0; j < nSquadre; j++)
                {

                    if (nSquadre == 32)
                    {
                        Grid.SetColumn(caselle[j], 0);
                        Grid.SetRow(caselle[j], j);
                    }
                    else if (nSquadre == 16)
                    {
                        Grid.SetColumn(caselle[j], 1);
                        Grid.SetRow(caselle[j], i);
                    }
                    else if (nSquadre == 8)
                    {
                        Grid.SetColumn(caselle[j],2);
                        Grid.SetRow(caselle[j], j);
                    }
                    else if (nSquadre == 4)
                    {
                        Grid.SetColumn(caselle[j], 3);
                        Grid.SetRow(caselle[j], j);
                    }
                    else if (nSquadre == 2)
                    {
                        Grid.SetColumn(caselle[j], 3);
                        Grid.SetRow(caselle[j], j);
                    }
                }
            }
        }
    }
}