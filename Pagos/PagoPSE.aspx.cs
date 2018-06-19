using Pagos.Clases;
using Pagos.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Pagos
{
    public partial class PAgoPSE : System.Web.UI.Page
    {

        public PAgoPSE()
        {
            this.AsyncMode = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se carga la informacion inicial
            if (!IsPostBack)
            {
                ConsultarTipoBanca();
                LlenarListaBancos();
                ConsultarTipoIdentificacion();
            }
        }

        #region Metodos

        //Metodo encargado de llenar el cmbTipoIdentificacion
        private void ConsultarTipoBanca()
        {
            try
            {
                //Se crea una lista y se llena segun la enumeracion
                List<ItemListaDTO> oListaTipoBanca = new List<ItemListaDTO>();
                oListaTipoBanca = new enmTipoBanca().ToList();

                //Se asigna la lista al DataSource del combobox y se refresca el dAtaBind
                cmbTipoBanca.DataSource = oListaTipoBanca;
                cmbTipoBanca.DataBind();

                //Se inserta un elemento al principio de la lsita
                cmbTipoBanca.Items.Insert(0, new ListItem("- Seleccione el Tipo de Banca -", "0"));
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error en el proceso. Contacte al administrador del sistema.');</script>");
                return;
            }

        }

        //Metodo encargado de llenar el cmbBancos
        private void LlenarListaBancos()
        {
            try
            {
                //Se instancia un Objeto de Tipo Autenticacion
                Servicio.PlaceToPlayPSEService.Authentication Auth = new Servicio.PlaceToPlayPSEService.Authentication();

                //Se llena la autenticacion
                Auth = CrearAutenticacion();

                //Se instancion un objeto de Tipo PSEPORTCLIENTE 
                Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient Servicio = new Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient();

                //Se instancia una lista de Tipo Banco
                List<Servicio.PlaceToPlayPSEService.Bank> olst = new List<Servicio.PlaceToPlayPSEService.Bank>();

                //A la lista de tipo Banco se le pasa el resultado de la consulta de getBanckList
                olst = Servicio.getBankList(Auth).ToList();

                //Se valida que la lista sea diferente de Null y tenga Elementos
                if (olst != null && olst.Count > 0)
                {
                    //Se le asignan los valores al Datasource y se refresca
                    cmbBancos.DataSource = olst;
                    cmbBancos.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error al tratar de consultar los bancos. Inténtelo de nuevo mas tarde.');</script>");
                    return;

                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error en el proceso. Contacte al administrador del sistema.');</script>");
                return;
            }
        }

        //Metodo encargado de Crear un OBjeto de conexion
        public Servicio.PlaceToPlayPSEService.Authentication CrearAutenticacion()
        {
            //Se instancia un Objeto de Tipo Autenticacion
            Servicio.PlaceToPlayPSEService.Authentication Auth = new Servicio.PlaceToPlayPSEService.Authentication();

            //Se le asignan los valores al objeto de conexion
            Auth.login = "6dd490faf9cb87a9862245da41170ff2";
            Auth.seed = DateTime.UtcNow.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            Auth.tranKey = GetSHA1(Auth.seed + "024h1IlD");

            //Se retorna la conexion
            return Auth;
        }

        //MEtodo que crea el Tankey
        private string GetSHA1(string text)
        {
            ASCIIEncoding UE = new ASCIIEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);
            SHA1 hashString = new SHA1CryptoServiceProvider();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

        //Metodo encargado de llenar el cmbTipoIdentificacion
        private void ConsultarTipoIdentificacion()
        {
            try
            {
                //Se crea una lista y se llena segun la enumeracion
                List<ItemListaDTO> oListaTipoIdentificacion = new List<ItemListaDTO>();
                oListaTipoIdentificacion = new enmTipoIdentificacion().ToList();

                //Se asigna la lista al DataSource del combobox y se refresca el dAtaBind
                cmbTipoIdentificacion.DataSource = oListaTipoIdentificacion;
                cmbTipoIdentificacion.DataBind();

                //Se inserta un elemento al principio de la lsita
                cmbTipoIdentificacion.Items.Insert(0, new ListItem("- Seleccione el Tipo de Identificación -", "0"));

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error en el proceso. Contacte al administrador del sistema.');</script>");
                return;
            }

        }






        #endregion

        #region Eventos
        //Metodo encargado de controlar si el user desea llenar la informacion o desea que se llene por el sistema
        protected void RBInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Se limpia el formulario
                LimpiarFormularioClientes();

                //Se vaida si el user desea llenar la info
                #region User quiere llenar la info

                if (RBInfo.SelectedValue == "0")
                {
                    //Se habilitan todos los campos
                    cmbTipoIdentificacion.Enabled = true;
                    txtNroDocumento.Enabled = true;
                    txtNombres.Enabled = true;
                    txtApellidos.Enabled = true;
                    txtDireccion.Enabled = true;
                    txtTelFijo.Enabled = true;
                    txtTelMovil.Enabled = true;
                    txtEmail.Enabled = true;
                    txtCiudad.Enabled = true;
                    txtDepartamento.Enabled = true;
                    txtEmpresa.Enabled = true;
                }

                #endregion

                //Se valida si el user desea que al info la llene el sistema
                #region User quiere que la info se llene por el sistema

                if (RBInfo.SelectedValue == "1")
                {
                    //Se asignan los valores a cada una de las cajas de texto
                    cmbTipoIdentificacion.SelectedValue = "1";
                    txtNroDocumento.Text = "1017756453";
                    txtNombres.Text = "Alisson Jhoana";
                    txtApellidos.Text = "Castro Perez";
                    txtDireccion.Text = "Cra 23 # 15 A 78";
                    txtTelFijo.Text = "576-23-23";
                    txtTelMovil.Text = "300 6567652";
                    txtEmail.Text = "emailprueba@prueba.com";
                    txtCiudad.Text = "Medellin";
                    txtDepartamento.Text = "Antioquia";
                    txtEmpresa.Text = "Place To Pay";

                    //Se desabilitan todos los campos
                    cmbTipoIdentificacion.Enabled = false;
                    txtNroDocumento.Enabled = false;
                    txtNombres.Enabled = false;
                    txtApellidos.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtTelFijo.Enabled = false;
                    txtTelMovil.Enabled = false;
                    txtEmail.Enabled = false;
                    txtCiudad.Enabled = false;
                    txtDepartamento.Enabled = false;
                    txtEmpresa.Enabled = false;
                }

                #endregion

            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error en el proceso. Contacte al administrador del sistema.');</script>");
                return;
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            #region Validaciones

            #region Validaciones Prrsona que paga

            if (cmbTipoBanca.SelectedValue == null || cmbTipoBanca.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe seleccionar el Tipo de banca.');</script>");
                return;
            }

            if (cmbBancos.SelectedValue == null || cmbBancos.SelectedValue == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe seleccionar el Banco.');</script>");
                return;
            }

            //Validacion para ambiente de pruebas, para garantizar que se seleccione el banco de prueba y no genere errores por el tipo de conexion
            if (cmbBancos.SelectedValue != "1022")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Por pruebas el Banco seleccionado debe ser BANCO UNION COLOMBIANO.');</script>");
                return;
            }


            //Validar campos si se digitaron manualmente
            if (RBInfo.SelectedValue == "0")
            {
                #region Validar Campos si el user Digita

                if (cmbTipoIdentificacion.SelectedValue == null || cmbTipoIdentificacion.SelectedValue == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe seleccionar el Tipo de identificación.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtNroDocumento.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Documento.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtNombres.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Nombres.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtApellidos.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Apellidos.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtDireccion.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Dirección.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtTelFijo.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Teléfono fijo.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtTelMovil.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Teléfono móvil.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo E-mail.');</script>");
                    return;
                }

                if (!ComprobarFormatoEmail(txtEmail.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('MAil invalido.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtCiudad.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Ciudad.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtDepartamento.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Departamento.');</script>");
                    return;
                }

                if (string.IsNullOrEmpty(txtEmpresa.Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Empresa.');</script>");
                    return;
                }


                #endregion
            }

            #endregion

            #region Validaciones Informacion Pago

            if (string.IsNullOrEmpty(txtReferenciaPago.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Referencia de pago.');</script>");
                return;

            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Descripción.');</script>");
                return;

            }

            if (string.IsNullOrEmpty(txtTotal.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Total.');</script>");
                return;

            }

            if (double.Parse(txtTotal.Text) <= 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Total debe ser mayor a cero (0).');</script>");
                return;

            }

            if (string.IsNullOrEmpty(txtImpuesto.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Impuesto.');</script>");
                return;

            }

            if (double.Parse(txtImpuesto.Text) < 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Impuesto debe ser mayor a cero (0).');</script>");
                return;

            }

            if (string.IsNullOrEmpty(txtBaseImpuesto.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Base impuesto.');</script>");
                return;

            }

            if (double.Parse(txtBaseImpuesto.Text) < 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Base impuesto debe ser mayor a cero (0).');</script>");
                return;

            }

            if (string.IsNullOrEmpty(txtPropinas.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar el campo Propinas.');</script>");
                return;

            }

            if (double.Parse(txtPropinas.Text) < 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('El campo Propinas debe ser mayor a cero (0).');</script>");
                return;

            }

            #endregion

            #endregion

            Servicio.PlaceToPlayPSEService.Authentication Auth = new Servicio.PlaceToPlayPSEService.Authentication();

            Auth = CrearAutenticacion();

            //Se crea la isntancia de tipo Person para el PAgador, Comprador, y Shiping
            Servicio.PlaceToPlayPSEService.Person Pagador = new Servicio.PlaceToPlayPSEService.Person();
            Servicio.PlaceToPlayPSEService.Person Comprador = new Servicio.PlaceToPlayPSEService.Person();
            Servicio.PlaceToPlayPSEService.Person Shiping = new Servicio.PlaceToPlayPSEService.Person();


            //Al objeto Pagador se le pasan los datos del cliente
            Pagador.document = txtNroDocumento.Text;
            Pagador.documentType = cmbTipoIdentificacion.SelectedValue == "1" ? "CC" : cmbTipoIdentificacion.SelectedValue == "2" ? "CE" : cmbTipoIdentificacion.SelectedValue == "3" ? "TI" : "PPN";
            Pagador.firstName = txtNombres.Text;
            Pagador.lastName = txtApellidos.Text;
            Pagador.company = txtEmpresa.Text;
            Pagador.emailAddress = txtEmail.Text;
            Pagador.address = txtDireccion.Text;
            Pagador.city = txtCiudad.Text;
            Pagador.province = txtDepartamento.Text;
            Pagador.country = txtPais.Text;
            Pagador.phone = txtTelFijo.Text;
            Pagador.mobile = txtTelMovil.Text;

            //Se instancia un Objeto de Tipo PSETransactionRequest
            Servicio.PlaceToPlayPSEService.PSETransactionRequest oTransaccion = new Servicio.PlaceToPlayPSEService.PSETransactionRequest();
            oTransaccion.bankCode = cmbBancos.SelectedValue.ToString();
            oTransaccion.bankInterface = cmbTipoBanca.SelectedValue == "1" ? "0" : "1";
            oTransaccion.returnURL = "http://localhost:61281/Respuesta.aspx";
            oTransaccion.reference = txtReferenciaPago.Text;
            oTransaccion.description = txtDescripcion.Text;
            oTransaccion.language = "ES";
            oTransaccion.currency = "COP";
            oTransaccion.totalAmount = double.Parse(txtTotal.Text);
            oTransaccion.taxAmount = double.Parse(txtImpuesto.Text);
            oTransaccion.devolutionBase = double.Parse(txtBaseImpuesto.Text);
            oTransaccion.tipAmount = double.Parse(txtPropinas.Text);
            oTransaccion.payer = Pagador;
            oTransaccion.ipAddress = ObtenerIp();
            oTransaccion.userAgent = "UNE";

            //Se instancion un objeto de Tipo PSEPORTCLIENTE 
            Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient Servicio = new Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient();
            //Se crea el Obeto para guardar los datos de la transaccion
            Servicio.PlaceToPlayPSEService.PSETransactionResponse RespuestaTransaccion = new Servicio.PlaceToPlayPSEService.PSETransactionResponse();
            //Se crea OBjeto para consultar la informacion de la transaccion
            Servicio.PlaceToPlayPSEService.TransactionInformation InformacionTransaccion = new Servicio.PlaceToPlayPSEService.TransactionInformation();


            //Se manda a crear la transaccion y se guarda la respuesta
            RespuestaTransaccion = Servicio.createTransaction(Auth, oTransaccion);

            //Se valida que la transaccion sea exitosa para re dirigir al usuario a la pagina del banco
            if (RespuestaTransaccion.returnCode == "SUCCESS")
            {
                //Se redirecciona a pagina para que el ID de la transaccion sea visible y el user tome nota de el
                Response.Redirect("http://localhost:61281/Respuesta.aspx?IdTransaccion=" + RespuestaTransaccion.transactionID.Value + "&Ruta=" + RespuestaTransaccion.bankURL);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presento un error, intentalo de nuevo.');</script>");
                return;
            }

        }

        #endregion









        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string ObtenerIp()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }








        private void LimpiarFormularioClientes()
        {
            cmbTipoIdentificacion.SelectedValue = "0";
            txtNroDocumento.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelFijo.Text = string.Empty;
            txtTelMovil.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtDepartamento.Text = string.Empty;
            txtEmpresa.Text = string.Empty;

        }




    }
}