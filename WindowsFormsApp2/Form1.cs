using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WindowsFormsApp2.models;
using System.IO;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
            {
                var player = new player {

                    Name=txtLastname.Text,
                    LastName=txtLastname.Text,
                    Team=txtTeam.Text,
                    Position=txtPosition.Text

                };
                var json = JsonConvert.SerializeObject(player);
                File.WriteAllText(sfdSave.FileName, json);
                MessageBox.Show("futbolcu kaydedildi");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdLoad.ShowDialog()==DialogResult.OK)
            {
                var json = File.ReadAllText(ofdLoad.FileName);
                var player = JsonConvert.DeserializeObject<player>(json);
                txtName.Text = player.Name;
                txtLastname.Text = player.LastName;
                txtTeam.Text = player.Team;
                txtPosition.Text = player.Position;
                MessageBox.Show("futbolcu yüklendi");
            }
        }
    }
}

