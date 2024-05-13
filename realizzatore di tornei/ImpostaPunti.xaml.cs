﻿using System;
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
        Squadra sq1;
        Squadra sq2;

        public Squadra Sq1 { get => sq1; set => sq1 = value; }
        public Squadra Sq2 { get => sq2; set => sq2 = value; }
        public ImpostaPunti(Squadra sq1, Squadra sq2)
        {
            InitializeComponent();
            Sq1 = sq1;
            Sq2 = sq2;
        }


        private void btn_invia_Click(object sender, RoutedEventArgs e)
        {
            //variabile a caso che uso nel TryParse anche se non so bene a cosa serva :)
            int numero;

            //controllo sulle textbox
            if (!Int32.TryParse(txtbox_punti_sq1.Text, out numero) || !Int32.TryParse(txtbox_punti_sq2.Text, out numero))
            {
                MessageBox.Show("Risultato non valido");
            }
            else
            {
                int ris1 = Int32.Parse(txtbox_punti_sq1.Text);
                int ris2 = Int32.Parse(txtbox_punti_sq2.Text);
                if (ris1 != ris2)
                {
                    Sq1.PuntiFatti = ris1;
                    Sq2.PuntiFatti = ris2;
                }
                else
                {
                    MessageBox.Show("Le partite non possonon finire con un pareggio");
                    txtbox_punti_sq1.Text = string.Empty;
                    txtbox_punti_sq2.Text = string.Empty;
                    this.Close();
                }
            }
        }
    }
}
