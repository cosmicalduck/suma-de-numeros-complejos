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

using clbComplejo;

namespace WpfSumaComplejos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtValorA1.Text = string.Empty;
            txtValorA2.Text = string.Empty;
            txtValorB1.Text = string.Empty;
            txtValorB2.Text = string.Empty;
            lblResultado.Content = string.Empty;
            cnvGrafico.Children.Clear();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            double a1 = double.Parse(txtValorA1.Text);
            double b1 = double.Parse(txtValorB1.Text);
            double a2 = double.Parse(txtValorA2.Text);
            double b2 = double.Parse(txtValorB2.Text);

            Complejo C1 = new Complejo(a1, b1);
            Complejo C2 = new Complejo(a2, b2);
            C1.Sumar(C2);

            lblResultado.Content = C1;
        }

        private void btnGraficar_Click(object sender, RoutedEventArgs e)
        {
            double a1 = double.Parse(txtValorA1.Text);
            double b1 = double.Parse(txtValorB1.Text);
            double a2 = double.Parse(txtValorA2.Text);
            double b2 = double.Parse(txtValorB2.Text);

            Complejo complejo1 = new Complejo(a1, b1);
            Complejo complejo2 = new Complejo(a2, b2);

            complejo1.Graficar(cnvGrafico, complejo1, complejo2);
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
