using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaCtes
{
    public partial class FormMenuPrincipal : Form
    {
        private string rolUsuario; // Variable para almacenar el rol recibido
        private int idUsuarioActual; // Variable para almacenar el ID del cajero logueado

        private Form formularioActivo = null;

        // Actualizamos el constructor para que reciba también el id_usuario
        public FormMenuPrincipal(string rol, int idUsuario)
        {
            InitializeComponent();
            rolUsuario = rol;
            idUsuarioActual = idUsuario;
            this.MinimumSize = new Size(900, 500);

        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            if (rolUsuario == "1") // Administrador
            {
                AbrirFormularioHijo(new FormInicio());

            }
            else if (rolUsuario == "2") // Supervisor
            {
                AbrirFormularioHijo(new FormInicio2());

            }
            else // Vendedor
            {
                AbrirFormularioHijo(new FormInicio3(idUsuarioActual));
            }
            ConfigurarPermisosMenu();
        }

        private void ConfigurarPermisosMenu()
        {
            if (rolUsuario == "3") // Vendedor (Solo ve 2 botones)
            {
                BInicio2.Visible = false;
                BClientes.Visible = false;
                BVentas.Visible = false;
                BInicio.Visible = false;
                BUsuarios.Visible = false;
                BFunciones.Visible = false;
                BBeneficios.Visible = false;
                BSala.Visible = false;
                BPeliculas.Visible = false;
            }
            else if (rolUsuario == "2") // Supervisor (Ve 3 botones)
            {
                BInicio.Visible = false;
                BUsuarios.Visible = false;
                BFunciones.Visible = false;
                BBeneficios.Visible = false;
                BSala.Visible = false;
                BPeliculas.Visible = false;
                BInicio3.Visible = false;
                BRegistrarVenta.Visible = false;
            }
            else if (rolUsuario == "1") // Administrador (6 botones)
            {
                BClientes.Visible = false;
                BVentas.Visible = false;
                BInicio2.Visible = false;
                BInicio3.Visible = false;
                BRegistrarVenta.Visible = false;
            }
        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formHijo;

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            PContenido.Controls.Add(formHijo);
            PContenido.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void FormMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Botones del menú lateral para el Administrador
        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormUsuarios());
        }
        private void BFunciones_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormFunciones());
        }
        private void BBeneficios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormBeneficios());
        }
        private void BSala_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormSalas());
        }
        private void BPeliculas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormPeliculas());
        }
        private void BInicio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio());
        }

        // Botones del menú lateral para el Supervisor
        private void BInicio2_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio2());
        }
        private void BVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVentas());
        }
        private void BClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormClientes());
        }

        // Botones del menú lateral para el Vendedor
        private void BInicio3_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormInicio3(idUsuarioActual));
        }

        // AQUÍ PASAMOS EL idUsuarioActual AL FORMULARIO DE VENTAS
        private void BRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormRegistrarVenta(idUsuarioActual));
        }

        private Button botonActivo = null;

        private void ActivarBoton(Button btn)
        {
            if (btn == null) return;

            if (botonActivo != null)
            {
                botonActivo.BackColor = Color.Transparent;
                botonActivo.ForeColor = Color.FromArgb(200, 200, 200);
            }

            botonActivo = btn;
            botonActivo.BackColor = Color.FromArgb(42, 22, 59);
            botonActivo.ForeColor = Color.White;
        }

        private void btnBoletos_Click(object sender, EventArgs e)
        {
            ActivarBoton((Button)sender);
        }

        private void RedondearBoton(Button btn, PaintEventArgs e, int radio, Color colorFondo)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, btn.Width - 1, btn.Height - 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Width - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Width - radio, rect.Height - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Height - radio, radio, radio, 90, 90);
                path.CloseAllFigures();

                using (SolidBrush brush = new SolidBrush(colorFondo))
                {
                    g.FillPath(brush, path);
                }
            }
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Color fondo = (btn == botonActivo) ? Color.FromArgb(42, 22, 59) : Color.Transparent;

            RedondearBoton(btn, e, 15, fondo);
        }

        private void BCerrar_sesion_Click(object sender, EventArgs e)
        {
            DialogResult ask = MessageBox.Show(
                "¿Está seguro que desea cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (ask == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }
    }
}