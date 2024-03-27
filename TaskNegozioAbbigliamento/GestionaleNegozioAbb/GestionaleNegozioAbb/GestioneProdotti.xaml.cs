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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace GestionaleNegozioAbb
{
    /// <summary>
    /// Logica di interazione per GestioneProdotti.xaml
    /// </summary>
    public partial class GestioneProdotti : Window
    {
        public GestioneProdotti()
        {
            InitializeComponent();
            //dgContatti.ItemsSource = PartecipanteDAL.getIstanza().GetAll();
            dgProdotti.ItemsSource = ProdottoDal.getInstance().GetAll();
        }

        private void btnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            string? nomeInput=this.tbNome.Text;
            string? descrizioneInput=this.tbDescrizione.Text;
            string? UrlInput=this.tbURL.Text;

            Prodotti temp = new Prodotti() 
            {
                Nome=nomeInput,
                Descrizione=descrizioneInput,
                ImmagineUrl=UrlInput,
            
            };
            if(ProdottoDal.getInstance().Insert(temp))
            {
                MessageBox.Show("Prodotto Inserito","Fantastico!",MessageBoxButton.OK,MessageBoxImage.Information);
                dgProdotti.ItemsSource = ProdottoDal.getInstance().GetAll();
            }
            else
            {
                MessageBox.Show("Prodotto non inserito", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            tbNome.Clear();
            tbDescrizione.Clear();
            tbURL.Clear();

        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            int idInput=Convert.ToInt32(this.tbInputElim.Text);
            if (ProdottoDal.getInstance().Delete(idInput))
            {
                MessageBox.Show("Prodotto Eliminato", "Fantastico!", MessageBoxButton.OK, MessageBoxImage.Information);
                dgProdotti.ItemsSource = ProdottoDal.getInstance().GetAll();
            }
            else
            {
                MessageBox.Show("Prodotto non eliminato", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            tbInputElim.Clear();
            
        }
    }
}
