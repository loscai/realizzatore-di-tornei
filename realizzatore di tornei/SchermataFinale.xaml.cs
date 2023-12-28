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

            switch(n)
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
                        if(i < 8)
                        {
                            quarti[i].Content = "/";
                            if (i < 4)
                            {
                                semifinali[i].Content = "/";
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
                        if (i < 8)
                        {
                            quarti[i].Content = "/";
                        }
                    }
                    break;
                case 8:
                    for (int i = 0; i < 16; i++)
                    {
                        ottavi[i].Content = "/";

                        if(i < 8)
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


    }
}