using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LayerMap; 

namespace TestApp {
    public partial class Form1 : Form {
        LayerMap.LayerMap _map;

        public Form1() {
            InitializeComponent();
        }

        private void nudLevel_ValueChanged(object sender, EventArgs e) {

        }

        private void updateRender() {
            Bitmap bmp = new Bitmap(_map.Width, _map.Height);



            pbRender.Image = bmp;
        }
    }
}
