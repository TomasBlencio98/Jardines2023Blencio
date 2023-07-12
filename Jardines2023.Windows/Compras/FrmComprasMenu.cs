using Jardines2023.Entidades.Entidades;
using Jardines2023.Servicios.Interfaces;
using Jardines2023.Servicios.Servicios;
using Jardines2023.Windows.Helpers;
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
    public partial class FrmComprasMenu : Form
    {
        public FrmComprasMenu()
        {
            InitializeComponent();
            servicioCompras = new ServiciosCompras();
        }
        private readonly IServiciosCompras servicioCompras;
        private List<Compra> lista;

        private void FrmComprasMenu_Load(object sender, EventArgs e)
        {
            lista = servicioCompras.GetCompras();
            txtIngresos.Text = servicioCompras.GetCantidad().ToString();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var compra in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r,compra);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            var frm = new FrmComprasAE();
            frm.Text = "Agregar nueva compra";
            DialogResult dr = frm.ShowDialog(this);
            Compra compra = frm.GetCompras();
            if (!servicioCompras.Existe(compra))
            {
                servicioCompras.Guardar(compra);
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, compra);
                GridHelper.AgregarFila(dgvDatos, r);
                ActualizarMenu();
                MessageBox.Show("Registro agregado correctamente!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El registro que desea agregar existe", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActualizarMenu()
        {
            lista = servicioCompras.GetCompras();
            txtIngresos.Text = servicioCompras.GetCantidad().ToString();
            MostrarDatosEnGrilla();
        }
    }
}
