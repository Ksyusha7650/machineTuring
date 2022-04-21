using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace machineTuring
{
    public partial class MessageBoxCar : Form
    {
        public MessageBoxCar(string msg, int index)
        {
            InitializeComponent();
            textMessage.Text = msg;
            panelPictures.BackgroundImage = imageListCars.Images[index];
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
