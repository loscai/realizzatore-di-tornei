﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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
        #region Vars And Consts
        /// <summary>
        /// Costante che indica il massimo numero di squadre
        /// </summary>
        const int maxNumSquadre = 16;
        /// <summary>
        /// Lista che contiene tutte le squadre
        /// </summary>
        List <Squadra> squadraList = new List<Squadra>();

        #endregion Vars And Consts

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Methods
        private void add_sq_button_Click(object sender, RoutedEventArgs e)
        {
            if (listbox_squadre.Items.Count < maxNumSquadre)
            {
                addSquadra a = new addSquadra();

                this.Hide();

                a.ShowDialog();

                listbox_squadre.Items.Add(a.Sq);
                squadraList.Add(a.Sq);
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
                modifica_nome_btn.IsEnabled = true;            
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
                MessageBox.Show("Il numero di squadre deve essere uno di questi valori: 2,4,8,16");
            }
            else
            {
                SchermataFinale sf;

                sf = new SchermataFinale(nome_torneo_txtbox.Text, listbox_squadre.Items.Count, squadraList, false);
                
                this.Hide();

                sf.ShowDialog();

                this.Show();
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
        }


        private void modifica_nome_btn_Click(object sender, RoutedEventArgs e)
        {
            ModificaNome m_n = new ModificaNome(squadraList[listbox_squadre.SelectedIndex]);

            this.Hide();
            m_n.ShowDialog();
            this.Show();

            squadraList[listbox_squadre.SelectedIndex] = m_n.sq;
            listbox_squadre.Items.Clear();

            for (int i = 0; i < squadraList.Count; i++)
            {
                listbox_squadre.Items.Add(squadraList[i]);
            }
            this.Show();
        }

        private void carica_btn_Click(object sender, RoutedEventArgs e)
        {
            string content;

            OpenFileDialog ofd = new OpenFileDialog();


            if (ofd.ShowDialog() == true)
                content = File.ReadAllText(ofd.FileName);
            else
                return;

            StreamReader sr = new StreamReader(ofd.SafeFileName);

            if (!File.Exists(ofd.SafeFileName))
            {
                sr.Close();

                return;
            }

            while (!sr.EndOfStream)
            {
                String rigaAttuale = sr.ReadLine();

                String nomeSquadra = rigaAttuale.Replace(';',' ');

                if (squadraList.Count < 16)
                {
                    if (checkNomi(nomeSquadra))
                    {
                        squadraList.Add(new Squadra(nomeSquadra));
                        listbox_squadre.Items.Add(squadraList[squadraList.Count - 1]);
                    }
                    else
                    {
                        MessageBox.Show("Non si possono inserire nomi di squadre uguali,\r\n il doppione è: " + nomeSquadra);
                    }
                }
                else
                {
                    sr.Close();
                    return;
                }
            }
            sr.Close ();
        }

        public bool checkNomi(String nomeSquadra)
        {
            for (int i = 0; i < squadraList.Count; i++)
                if(nomeSquadra == squadraList[i].Nome)
                    return false;
            return true;
        }

        #endregion Methods
    }
}