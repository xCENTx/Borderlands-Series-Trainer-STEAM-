using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace MultipleGameTrainerSource.Forms
{
    public partial class Borderlands2 : Form
    {
        Mem m = new Mem();
        private const string BORDERLANDS2PROCESS = "Borderlands2.exe";

        public static class Offsets
        {
            //Player Info
            public const string Money = "0x015AB02C,0x0,0xC0,0xE0,0x36C,0x1C4,0x4,0x2A0";
        }

        public Borderlands2()
        {
            InitializeComponent();
        }

        private void Borderlands2_Load(object sender, EventArgs e)
        {
            int PID = m.GetProcIdFromName(BORDERLANDS2PROCESS);
            if (PID > 0)
            {
                m.OpenProcess(PID);
                MessageBox.Show("Connected to Game");
            }
        }

        private void MoneyButton_Click(object sender, EventArgs e)
        {
            if (MoneyTextBox.Text != "")
            {
                m.WriteMemory($"Borderlands2.exe+{Offsets.Money}", "int", MoneyTextBox.Text);
            }
        }

        private void FreezeMoney_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            var oldMoneyValue = m.ReadInt($"Borderlands2.exe+{Offsets.Money}");
            var newMoneyValue = oldMoneyValue;
            if (FreezeMoney_checkBox.Checked)
            {
                m.FreezeValue($"Borderlands2.exe+{Offsets.Money}", "int", newMoneyValue.ToString());
            }
            else
            {
                m.UnfreezeValue($"Borderlands2.exe+{Offsets.Money}");
            }
        }
    }
}
