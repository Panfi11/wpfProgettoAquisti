
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

namespace loginAcquisti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtNome.Focus();
            txtSoldo.IsEnabled = false;
            txtNumero.IsEnabled = false;
            cmbProdotto.IsEnabled = false;
            btnPulisci.IsEnabled = false;
            btnStampa.IsEnabled = false;
            ltbProdottofinale.IsEnabled = false;
            btnRimuoviSelezione.IsEnabled = false;
        }

        private const string PASSWORD = "ciao";
        private string[] prodotti = new string[] { "Felpa", "T-Shirt", "Polo", "Pantalone", "Calzini", "Mutande" };
        private string utente;

        private void btnAccedi_Click(object sender, RoutedEventArgs e)
        {
            utente = txtNome.Text;
            string pass = txtPass.Text;

            if (utente != "" && utente != null && pass == PASSWORD)
            {
                txtNome.IsEnabled = false;
                txtPass.IsEnabled = false;
                btnAcc.IsEnabled = false;

                txtSoldo.IsEnabled = true;
                txtNumero.IsEnabled = true;
                cmbProdotto.IsEnabled = true;
                btnPulisci.IsEnabled = true;
                btnStampa.IsEnabled = true;
            }
            else if (utente == "" || utente == null)
            {
                MessageBox.Show("Utente o Password errati", "Riprova", MessageBoxButton.OK, MessageBoxImage.Error);
                txtNumero.Text = "";
                txtPass.Text = "";
                txtNome.Focus();
            }
            else if (pass != PASSWORD)
            {
                MessageBox.Show("Password o Utente errati", "Riprova", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                txtPass.Text = "";
                txtPass.Focus();
            }
        }

        private void cmbProdotto_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string p in prodotti)
            {
                cmbProdotto.Items.Add(p);
            }
        }

        private void btnStampa_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumero.Text != "" && txtSoldo.Text != "" && cmbProdotto.SelectedIndex >= 0)
            {
                try
                {
                    int quantità = int.Parse(txtNumero.Text);
                    double prezzo = double.Parse(txtSoldo.Text);

                    double totale = quantità * prezzo;

                    ltbProdottofinale.Items.Add($" {txtNome.Text} hai acquistato il prodotto {cmbProdotto.SelectedItem} con un costo finale di {totale}€");

                    txtNumero.Text = "";
                    txtSoldo.Text = "";
                    cmbProdotto.SelectedIndex = -1;

                    ltbProdottofinale.IsEnabled = true;
                    btnRimuoviSelezione.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Attento zi", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    txtNumero.Text = "";
                    txtSoldo.Text = "";
                    cmbProdotto.SelectedIndex = -1;
                }
            }
            else
            {
                MessageBox.Show("Immetti tutti i valori!", "Attento", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                txtNumero.Text = "";
                txtSoldo.Text = "";
                cmbProdotto.SelectedIndex = -1;
            }
        }

        private void btnPulisci_Click(object sender, RoutedEventArgs e)
        {
            txtNumero.Text = "";
            txtSoldo.Text = "";
            cmbProdotto.SelectedIndex = -1;
        }

        private void btnRimuoviSelezione_Click(object sender, RoutedEventArgs e)
        {
            int selezione = ltbProdottofinale.SelectedIndex;
            if (selezione >= 0)
            {
                ltbProdottofinale.Items.RemoveAt(selezione);
            }
            else
            {
                MessageBox.Show("Selezionea un'oggetto <", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ltbProdottofinale.Items.Count == 0)
            {
                ltbProdottofinale.IsEnabled = false;
                btnRimuoviSelezione.IsEnabled = false;
            }
        }
    }
}
