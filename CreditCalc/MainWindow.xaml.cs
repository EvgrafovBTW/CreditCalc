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

namespace CreditCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double aut_rez;
        private double crdt;
        private double prc;
        private double ms;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ras_Click(object sender, RoutedEventArgs e)
        {
            if (credit.Text != "" && proc.Text != "" && mts.Text != "")
            {
                month.Visibility = Visibility.Visible;
                month_res.Visibility = Visibility.Visible;

                crdt = Convert.ToDouble(credit.Text);
                prc = Convert.ToDouble(proc.Text)/100;
                ms = Convert.ToDouble(mts.Text);

                aut_rez = crdt * ((prc*Math.Pow(1+prc, ms))/(Math.Pow(1+prc, ms)-1));

                n.Text = "";
                sp.Text = "";
                p.Text = "";
                od.Text = "";

                for (int i = 0; i < ms; i++) {


                    //chk = Convert.ToString(i + 1) + " ";
                    //chk = chk + Convert.ToString(aut_rez) + " ";
                    //chk = chk + Convert.ToString(crdt * prc) + " ";
                    //crdt = crdt + (crdt * prc) - aut_rez;
                    //chk = chk + Convert.ToString(crdt);
                    //check.Text = check.Text + chk;

                    n.Text = n.Text + Convert.ToString(i + 1) + System.Environment.NewLine;
                    sp.Text = sp.Text + Convert.ToString(aut_rez) + System.Environment.NewLine;
                    p.Text = p.Text + Convert.ToString(crdt * prc) + System.Environment.NewLine;
                    crdt = crdt + (crdt * prc) - aut_rez;
                    if (crdt < 1)
                    {
                        od.Text = od.Text + Convert.ToString(0) + System.Environment.NewLine;
                    }
                    else { 
                        od.Text = od.Text + Convert.ToString(crdt) + System.Environment.NewLine;
                    }

                }
                

                month_res.Text = Convert.ToString(aut_rez);
            }
            else {
                MessageBox.Show("Остались пустые поля", "Беда!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
