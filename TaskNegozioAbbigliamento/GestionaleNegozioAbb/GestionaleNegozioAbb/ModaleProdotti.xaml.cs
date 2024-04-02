using GestionaleNegozioAbb.DAL;
using GestionaleNegozioAbb.Models;
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

namespace GestionaleNegozioAbb
{
    /// <summary>
    /// Logica di interazione per ModaleProdotti.xaml
    /// </summary>
    public partial class ModaleProdotti : Window
    {
        public Prodotti prodottoDaModificare { get; private set; }
        public ModaleProdotti(Prodotti prodottoDaModificare)
        {
            InitializeComponent();
            tbNome.Text = prodottoDaModificare.Nome;
            tbDescrizione.Text = prodottoDaModificare.Descrizione;
            tbURL.Text = prodottoDaModificare.ImmagineUrl;


        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            string? nomeInput = this.tbNome.Text;
            string? descrizioneInput = this.tbDescrizione.Text;
            string? UrlInput = this.tbURL.Text;

            Prodotti temp = new Prodotti()
            {
                Nome = nomeInput,
                Descrizione = descrizioneInput,
                ImmagineUrl = UrlInput,

            };
            if (ProdottoDal.getInstance().Update(temp))
            {
                MessageBox.Show("Prodotto Modificato", "Fantastico!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Prodotto non modificato", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            tbNome.Clear();
            tbDescrizione.Clear();
            tbURL.Clear();

        }
    }
}
