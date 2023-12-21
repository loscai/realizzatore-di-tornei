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
    /// Logica di interazione per addSquadra.xaml
    /// </summary>
    public partial class addSquadra : Window
    {
        public Squadra sq;
        public addSquadra()
        {
            InitializeComponent();
        }
        private void creaSquadra_btn_Click(object sender, RoutedEventArgs e)
        {
            bool isValido = false;
            if (nomeSq_txtbox.Text != string.Empty)
            {
                if (nMembri_txtbox.Text != string.Empty)
                {
                    for (int i = 0; i < nMembri_txtbox.Text.Length; i++)
                    {
                        if (nMembri_txtbox.Text[i] < '0' || nMembri_txtbox.Text[i] > '9')
                        {
                            MessageBox.Show("Numero non valido");
                            isValido = false;
                            break;
                        }
                        else
                            isValido = true;
                    }
                    if (isValido)
                    {
                        Squadra s = new Squadra(nomeSq_txtbox.Text, Int32.Parse(nMembri_txtbox.Text));
                        this.sq = s;
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Inserire il numero");

            }
            else
                MessageBox.Show("Inserire il nome alla Squadra");
        }
    }
}
