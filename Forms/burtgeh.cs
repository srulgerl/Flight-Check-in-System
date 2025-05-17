using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class burtgeh : Form
    {
        public burtgeh()
        {
            InitializeComponent();
        }

        private void useg1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsipr_TextChanged(object sender, EventArgs e)
        {

        }

        private void burtgeh_Load(object sender, EventArgs e)
        {
            var suudalSongoh = new suudal_songoh();
            suudalSongoh.Show();
        }
    }
}
