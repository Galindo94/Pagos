using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using System.Web.Services.Protocols;
using System.Text;
using System.Security.Cryptography;

namespace Pagos
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnConsultar_Click(object sender, EventArgs e)
        {

            try
            {


                Servicio.PlaceToPlayPSEService.Authentication Auth = new Servicio.PlaceToPlayPSEService.Authentication();

                Auth = CrearAutenticacion();

                //Se instancion un objeto de Tipo PSEPORTCLIENTE 
                Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient Servicio = new Servicio.PlaceToPlayPSEService.PlacetoPay_PSEPortClient();


                //Se crea OBjeto para consultar la informacion de la transaccion
                Servicio.PlaceToPlayPSEService.TransactionInformation InformacionTransaccion = new Servicio.PlaceToPlayPSEService.TransactionInformation();

                if (!string.IsNullOrEmpty(txtIdTransaccion.Text))
                {
                    InformacionTransaccion = Servicio.getTransactionInformation(Auth, int.Parse(txtIdTransaccion.Text));

                    if (InformacionTransaccion != null)
                    {

                        if (InformacionTransaccion.transactionState == "OK")
                        {
                            lblAprobada.Visible = true;
                            lblRechazada.Visible = false;
                            lblPendiente.Visible = false;

                            lblAprobada.Text = "APROBADA";
                            lblRechazada.Text = "";
                            lblPendiente.Text = "";

                            txtDetalle.Visible = true;
                            txtDetalle.Text = "Felicidades, su compra ha sido aprobada por el banco.";
                        }

                        if (InformacionTransaccion.transactionState == "PENDING")
                        {
                            lblAprobada.Visible = false;
                            lblPendiente.Visible = true;
                            lblRechazada.Visible = false;

                            lblAprobada.Text = "";
                            lblPendiente.Text = "PENDIENTE";
                            lblRechazada.Text = "";

                            txtDetalle.Visible = true;
                            txtDetalle.Text = InformacionTransaccion.responseReasonText;
                        }

                        if (InformacionTransaccion.transactionState == "FAILED")
                        {
                            lblAprobada.Visible = false;
                            lblPendiente.Visible = false;
                            lblRechazada.Visible = true;

                            lblAprobada.Text = "";
                            lblPendiente.Text = "";
                            lblRechazada.Text = "FALLIDA";

                            txtDetalle.Visible = true;
                            txtDetalle.Text = InformacionTransaccion.responseReasonText;
                        }

                        if (InformacionTransaccion.transactionState == "NOT_AUTHORIZED")
                        {
                            lblAprobada.Visible = false;
                            lblPendiente.Visible = false;
                            lblRechazada.Visible = true;

                            lblAprobada.Text = "";
                            lblPendiente.Text = "";
                            lblRechazada.Text = "NO AUTORIZADA";

                            txtDetalle.Visible = true;
                            txtDetalle.Text = InformacionTransaccion.responseReasonText;
                        }
                    }
                }

                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Debe ingresar un Id de transacción.');</script>");
                    return;

                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Se presentó un error en el proceso. Contacte al administrador del sistema.');</script>");
                return;

            }





        }
    }
}