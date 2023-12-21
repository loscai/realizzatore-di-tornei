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

            this.nCaselleTotali = (nSquadre*2) - 1;

            caselle = new Button[nCaselleTotali];

            for(int i = 0; i < caselle.Length; i++)
            {
                if(i < nSquadre)
                {
                    caselle[i] = new Button();
                    caselle[i].Content = squadraList[i].Nome;
                }
                else
                {
                    caselle[i] = new Button();
                    caselle[i].Content = string.Empty;
                }
                
            }
        }
    }
}