using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Opak4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("cisla.txt");

                List<int> cisla = new List<int>();
                while (!sr.EndOfStream)
                {
                    /*try
                    {*/
                        int c = int.Parse(sr.ReadLine());
                        cisla.Add(c);
                    /*}
                    catch
                    { }*/
                }

                int n = int.Parse(textBox1.Text);
                double mocnina = cisla[4];
                if (n == 0) mocnina = 1;
                for (int i = 1; i < n; i++)
                {
                    mocnina *= cisla[4];
                }
                if (n < 0) {
                    for (int i = -1; i > n; i--)
                    {
                        mocnina *= cisla[4];
                    }
                    mocnina = 1 / mocnina; 
                }

                MessageBox.Show("Mocnina: " + mocnina);

                MessageBox.Show("Realný: " + ((double)cisla[4] / n) + "\nCeločíselný: " + (int)((double)cisla[4] / n));

                MessageBox.Show("Součet všech čísel: " + cisla.Sum());

            } catch(FileNotFoundException)
            {
                MessageBox.Show("Nenalezen soubor cisla.txt");
            }
            catch (FormatException)
            {
                MessageBox.Show("V souboru byl nalezen řádek s neplatným znakem!");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Neexistuje páté číslo!!");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Příliš velká čísla!");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Dělení 0!!");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                if(sr!=null) sr.Close();
            }

        }
    }
}
