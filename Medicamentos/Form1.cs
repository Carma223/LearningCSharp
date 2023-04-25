using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VO;
using UIL;

namespace Medicamentos
{
    public partial class Form1 : Form
    {
        #region Variables
        List<Medicamento> _lstMedicamentos;
        MedicamentosUIL _medicamentoUIL;
        #endregion

        #region Propiedades
        EstadoPantalla EstadoDatos { get; set; }
        #endregion

        /*
         ENUMERADOS PARA LOS DISTINTOS ESTADOS DE PANTALLA
         * Ninguno = Cuando se ha instanciado por primera vez el programa Ó cuando se elimina un registro que se está consultando, debe retornar este estado de pantalla.
         * Consultando = Cuando el registro está a nivel maestro (llenando los campos en base al registro en el grid [tabla])
         * Agregando = Cuando se da click en Nuevo
         * Modificando = Cuando se da click en Modificar Y SE TIENE UN REGISTRO CONSULTANDO.
         * Eliminando = Cuando se está eliminando un registro Y SE TIENE UN REGISTRO ELIMINANDO       
        */

        #region Enumerados
        enum EstadoPantalla
        {
            Ninguno,
            Consultando,
            Agregando,
            Modificando,
            Eliminando
        } 
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            Inicializa();
        }
        #endregion

        #region Métodos instanciadores
        private void Inicializa()
        {
            LlenaTipos();
            _medicamentoUIL = new MedicamentosUIL();
            _lstMedicamentos = new List<Medicamento>();
            EstadoDatos = EstadoPantalla.Ninguno;
            AjusteControles();
        }
        #endregion

        #region Métodos
        private void LlenaTipos()
        {
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add("Id", typeof(int));
            dtTipos.Columns.Add("Nombre", typeof(string));

            dtTipos.Rows.Add(1, "Analgésicos y antiinflamatorios");
            dtTipos.Rows.Add(2, "Antiinfecciones");
            dtTipos.Rows.Add(3, "Mucolíticos y antitusivos");
            dtTipos.Rows.Add(4, "Antipiréticos");
            dtTipos.Rows.Add(5, "Antialérgicos");

            lueTipoMedicamento.Properties.DataSource = dtTipos;
        } 
        #endregion

        #region Eventos ABC
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            //Cuando se da click en nuevo, inicializamos nuestra VO en los siguientes valores nulos
            //(a excepción de nuestro IdMedicamento, que es la referencia para llevar un control de identificadores)
            #region Ejemplo del llenado de la información
            _medicamentoUIL.IdMedicamento = (_lstMedicamentos.Count + 1); // aquí puede llamarse al método Obtiene de la UIL. Dependerá de la lógica que empleen.            
            _medicamentoUIL.Nombre = string.Empty;
            _medicamentoUIL.IdTipoMedicamento = 0;
            _medicamentoUIL.FechaCaducidad = DateTime.MinValue; //01/01/0001 
            #endregion
            LimpiarCampos();
            //SIEMPRE EN CADA ACCIÓN, HAY QUE ASIGNAR SU ESTADO CORRESPONDIENTE Y LLAMAR EL AJUSTE DE CONTROLES (SIEMPRE Y CUANDO APLIQUE)
            EstadoDatos = EstadoPantalla.Agregando;
            AjusteControles();
        }


        //COMO PLUS: LAS SIGUIENTES ETIQUETAS PERMITEN AGREGAR UNA DESCRIPCIÓN AL MÉTODO O CÓDIGO EN ESPECÍFICO.
        //SI PARAN SU PUNTERO EN EL MÉTODO LES VA A MOSTRAR LA INFORMACIÓN DESEADA:
        /// <summary>
        /// Este método limpia los campos del maestro (los campos de texto, el combo desplegable y la fecha).
        /// </summary>
        private void LimpiarCampos()
        {
            teIdMedicamento.Text = teNombre.Text = string.Empty;
            lueTipoMedicamento.EditValue = null;
            deFechaCaducidad.EditValue = null;
        }

        /// <summary>
        /// Este método lleva a cabo el ajuste de controles entre acciones (cuando se instancia por primera vez la forma, cuando se consulta, agrega, modifica o elimina un registro.
        /// </summary>
        private void AjusteControles()
        {
            //TENER EN CONSIDERACIÓN QUE POSTERIOR A UN CAMBIO DE PANTALLA (ES DECIR, ENTRE CADA ACCIÓN, DEBE EJECUTARSE INMEDIATAMENTE DESPUÉS EL MÉTODO
            //PARA QUE REALICE EL AJUSTE DE CONTROLES EN LOS COMPONENTES DE LA FORMA.

            //PUEDEN SELECCIONAR CUALQUIERA DE LAS DOS FORMAS, LA QUE SEA MÁS FÁCIL DE COMPRENDER Y MANIPULAR. AMBAS SON CORRECTAS.
            #region 1ra Forma
            //Agregar las demás estados en banderas y sus validaciones correspondientes.
            bool bNinguno = EstadoDatos == EstadoPantalla.Ninguno;
            bool bAgregando = EstadoDatos == EstadoPantalla.Agregando;
            
            #region Código ejemplo visto el sábado
            tsbAceptar.Visible = tsbCancelar.Visible = tsbModificar.Visible = tsbEliminar.Visible = !bNinguno;
            teNombre.Enabled = lueTipoMedicamento.Enabled = deFechaCaducidad.Enabled =
            gcMedicamentos.Enabled = !bNinguno; 
            #endregion

            //Pista de cómo pudiera quedar
            tsbAceptar.Visible = tsbCancelar.Visible = bAgregando;
            tsbNuevo.Visible = bNinguno;
            teNombre.Enabled = lueTipoMedicamento.Enabled = deFechaCaducidad.Enabled = bAgregando;
            gcMedicamentos.Enabled = !bNinguno;
            #endregion

            #region 2da Forma
            //Agregar los demás estados en cases y sus validaciones correspondientes.


            //Pista de cómo pudiera quedar
            switch (EstadoDatos)
            {
                case EstadoPantalla.Ninguno:
                    tsbAceptar.Visible = tsbCancelar.Visible = tsbModificar.Visible = tsbEliminar.Visible =
                    teNombre.Enabled = lueTipoMedicamento.Enabled = deFechaCaducidad.Enabled =
                    gcMedicamentos.Enabled = false;
                    break;
                case EstadoPantalla.Agregando:
                    tsbAceptar.Visible = tsbCancelar.Visible = 
                    teNombre.Enabled = lueTipoMedicamento.Enabled = deFechaCaducidad.Enabled = true;
                    tsbModificar.Visible = tsbEliminar.Visible =
                    gcMedicamentos.Enabled = false;
                    break;
            }
            #endregion
        }

        private void tsbAceptar_Click(object sender, EventArgs e)
        {
            //LO CORRECTO ES QUE CUANDO SE AGREGUE O MODIFIQUE EL REGISTRO (HAY QUE VALIDAR),
            //[1] LA INFORMACIÓN SE VEA REFLEJADA INMEDIATAMENTE EN EL MAESTRO Y SU ESTADO DE PANTALLA SEA CONSULTANDO.
            //[2] DE IGUAL FORMA, DEBE CONSULTARSE LA INFORMACIÓN DE LA LISTA Y REFLEJARSE EN EL GRID.
           
            #region Ejemplo del llenado de la información
            _medicamentoUIL.IdMedicamento = 1;
            _medicamentoUIL.Nombre = teNombre.Text.Trim();
            _medicamentoUIL.IdTipoMedicamento = Convert.ToInt32(lueTipoMedicamento.EditValue);
            _medicamentoUIL.Tipo = lueTipoMedicamento.Text;
            _medicamentoUIL.FechaCaducidad = DateTime.Today;
            _lstMedicamentos.Add(_medicamentoUIL);
            gcMedicamentos.DataSource = _lstMedicamentos;
            #endregion

            if (EstadoDatos == EstadoPantalla.Agregando)
            {
                //OJO: Como arriba ya estoy instanciando los valores de ejemplo, pues ya viven en esa misma variable, entonces, por eso no tengo parámetros.
                //PERO SIEMPRE pueden manejarlo de la forma que más fácil les parezca: por ejemplo, metiendo los valores de los campos en variables
                //declaradas en la parte superior, y luego parametrizando el método Inserta, para ahora sí formar el objeto del lado de la UIL y/o BLL.
                _medicamentoUIL.Inserta();
            } else if (EstadoDatos == EstadoPantalla.Modificando)
            {

            }

            //[1]
            //Consultar la información posteriormente a realizar CORRECTAMENTE la acción, y actualizar el estado de pantalla antes de su ajuste de controles.
            EstadoDatos = EstadoPantalla.Consultando;
            AjusteControles();
            //[2]
            //Por medio de la propiedad DataSource le asignamos una lista de cualquier objeto o una tabla, como se amolde a sus procesos y forma de trabajar.
            //Si no se encuentra inmediatamente esta propiedad posteriormente al nombre del componente,
            //puede accederse y buscarse mediante la propiedad: Properties.
            //Ejemplo:
            //1) NombreComponente.DataSource = <asignación>;
            //2) NombreComponente.Properties.DataSource = <asignación>;
            gcMedicamentos.DataSource = _lstMedicamentos;

        }

        #endregion

        #region Eventos
        private void gvMedicamentos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //En este método hay que considerar que se va a consultar la información, entonces hay que actualizar el estado de pantalla y ajustar controles
            //para una óptima visualización de la forma.

            //Con esta línea de código podemos extraer el Id del renglón de la tabla seleccionado 
                                               //Lo siguiente puede leerse como: extraeme el valor de la celda en base a:
                                               //al nombre de la columna (si es que se asignó uno)
                                               //o en base al nombre en la propiedad FieldName: "IdMedicamento"
                                               //CUIDADO. RECORDATORIO:
                                               //El "fieldname" debe llamarse exactamente igual que la propiedad en su clase o clases a bindear.
            int idMedicamento = Convert.ToInt32(gvMedicamentos.GetFocusedRowCellValue("IdMedicamento"));
        } 
        #endregion
    }
}
