using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tienda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConexion_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DIOUSEK\\DIOUSEKSQL;database=siga;Integrated Security=true;");
            conexion.Open();
            int id = Convert.ToInt32(txtID.Text);//Llamamos los compos. Convertimos el id para que lo tome como cadena txt
            string nombre = txtNombre.Text;
            string precio = txtPrecio.Text;
            string producto = txtProducto.Text;
            string cantidad = txtCantidad.Text;
            string cadena = "insert into Inventarioo(Id,NombreP,Precio,Producto,Cantidad) values(" + id + ",'" + nombre + "','" + precio + "','" + producto + "','" + cantidad + "')";//Insertar valores
            SqlCommand com = new SqlCommand(cadena, conexion);//Toma la cadena, ejecuta el comando e inserta en la bases de datos
            com.ExecuteNonQuery();

            MessageBox.Show("Se han guardado los datos del producto!:D");
            txtID.Text = "";//Me muestra en el form como se guardaron los datos
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtProducto.Text = "";
            txtCantidad.Text = "";

            conexion.Close();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server = DIOUSEK\\DIOUSEKSQL; database = siga; Integrated Security = true; ");
            conexion.Open();
            int idCons = Convert.ToInt32(txtCons.Text);
            string cadena = "select NombreP,Precio,Producto,Cantidad from Inventarioo where Id=" + idCons;//Hacer la consulta teniendo en cuenta el ID
            SqlCommand com = new SqlCommand(cadena, conexion);
            SqlDataReader registro = com.ExecuteReader();
            if (registro.Read())
            {
                lblNom.Text = registro["NombreP"].ToString();
                lblPre.Text = registro["Precio"].ToString();//Llenamos los lbl que quedaron con los asteriscos
                lblPro.Text = registro["Producto"].ToString();
                lblCan.Text = registro["Cantidad"].ToString();
            }
            else
            {
                MessageBox.Show("No existe un registro con el ID ingresado");
            }
            conexion.Close();
            MessageBox.Show("Busqueda exitosa");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblPro_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DIOUSEK\\DIOUSEKSQL;database=siga;Integrated Security=true;");
            conexion.Open();
            int idBorrar = Convert.ToInt32(txtCons.Text);
            string cadena = "delete from Inventarioo where Id=" + idBorrar;
            SqlCommand com = new SqlCommand(cadena, conexion);
            int cant = com.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Se ha eliminado el articulo!:D");
            }
            else
            {
                MessageBox.Show("No existe ningun articulo con el id ingresado:c");

            }
            conexion.Close();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DIOUSEK\\DIOUSEKSQL;database=siga;Integrated Security=true;");
            conexion.Open();
            int cod = Convert.ToInt32(txtCons.Text);
            string nombre = txtEditNom.Text;
            string precio = txtEditPre.Text;
            string producto = txtEditPro.Text;
            string cantidad = txtEditCant.Text;
            string cadena = "update Inventarioo set NombreP='" + nombre + "', Precio='" + precio + "',Producto='" + producto + "',Cantidad='" + cantidad + "' where Id="+cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();

            if (registro.Read())
            {
                txtEditNom.Text = "";
                txtEditPre.Text = "";
                txtEditPro.Text = "";
                txtEditCant.Text = "";
            }
            else {
                MessageBox.Show("Se modificó:D");
            }
        }

        private void btnLista_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DIOUSEK\\DIOUSEKSQL;database=siga;Integrated Security=true;");
            conexion.Open();
            string cadena = "select Id, NombreP, Precio, Producto, Cantidad from Inventarioo";
            SqlCommand com = new SqlCommand(cadena, conexion);
            SqlDataReader registro = com.ExecuteReader();
            txtLista.Clear();
            while (registro.Read())
            {
                txtLista.AppendText(registro["Id"].ToString());
                txtLista.AppendText(" - ");
                txtLista.AppendText(registro["NombreP"].ToString()); //Append funciona para agregar llos registros
                txtLista.AppendText(" - ");
                txtLista.AppendText(registro["Precio"].ToString());
                txtLista.AppendText(" - ");
                txtLista.AppendText(registro["Producto"].ToString());
                txtLista.AppendText(" - ");
                txtLista.AppendText(registro["Cantidad"].ToString());
                txtLista.AppendText(Environment.NewLine);

            }
            conexion.Close();
            MessageBox.Show("Busqueda exitosa");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lblPre_Click(object sender, EventArgs e)
        {

        }

        private void txtLista_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
