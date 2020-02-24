using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Borderlands_DPS_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool CanCalc = false; //set to false we need to check values are valid integers!
            string txtMagSize = string.Empty, txtFirerate = string.Empty, txtReloadSpeed = string.Empty, txtDamage = string.Empty;
            double intMagSize = 0; double intFirerate = 0; double intReloadSpeed = 0; double intDamage = 0;
            txtDamage = textBox1.Text; txtFirerate = textBox3.Text; txtReloadSpeed = textBox2.Text; txtMagSize = textBox4.Text;
            double secMF = 0; double secMFR = 0; double TotalMagDamage = 0; double FinalDPS = 0;

            if (double.TryParse(txtDamage, out intDamage))
            {
                CanCalc = true;
            }
            else
            {
                CanCalc = false;
                MessageBox.Show("Error invalid value in Damage");
            }
            if (double.TryParse(txtMagSize, out intMagSize))
            {
                CanCalc = true;
            }
            else
            {
                CanCalc = false;
                MessageBox.Show("Error invalid value in Magazine Size");
            }
            if (double.TryParse(txtReloadSpeed, out intReloadSpeed))
            {
                CanCalc = true;
            }
            else
            {
                CanCalc = false;
                MessageBox.Show("Error invalid value in Reload Speed");
            }
            if (double.TryParse(txtFirerate, out intFirerate))
            {
                CanCalc = true;
            }
            else
            {
                CanCalc = false;
                MessageBox.Show("Error invalid value in Firerate");
            }
            if (CanCalc) // checks if CanCalc = true -- than we can calculate the integers ;)
            {
                secMF = intMagSize / intFirerate; // Magazine Fire Rate Per Second(s)
                //intRSBonus = intReloadSpeed * intRSBonus / 100.0; //converts percentage to decimal.
                secMFR = secMF + intReloadSpeed;//+ intReloadSpeed; // Magazine Fire Rate Reload Per Second(s)
                TotalMagDamage = intMagSize * intDamage; // total damage per magazine
                FinalDPS = TotalMagDamage / secMFR; // our actual calculate dps!
                label6.Text = "DPS: " + Convert.ToString(Math.Round(FinalDPS, 2)); //set our dps label to calculated dps!
            }
            /*
(Based on this formula)
(M) mag size / (F) fire rate = (MF) seconds to empty ur clip
(MF) + (R) reload speed = (MFR) seconds to empty ur clip and reload
(M) x (D) damage = (MD) total damage per mag
(MD) / (MFR) = dps
*/

        }
    }
}
