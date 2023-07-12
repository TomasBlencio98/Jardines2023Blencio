using Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jardines2023.Windows.Compras
{
    public partial class FrmComprasAE : Form
    {
        public FrmComprasAE()
        {
            InitializeComponent();
        }
        private Compra compra;
        public Compra GetCompras()
        {
            return compra;
        }


    }
}
