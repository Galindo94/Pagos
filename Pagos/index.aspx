<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Pagos.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" />

    <%--Estilos--%>
    <link href="css/Style.css" type="text/css" rel="stylesheet" />



    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container medios borde-arriba">

            <div class="row justify-content-center">
                <h2>Seleccione  <b class="letra-verde">método de pago</b> que desea utilizar.</h2>
            </div>

            <div class="row center-xs">

                <div class="col-sm-6 col-md-3">
                    <a href="PagoTC.aspx">
                        <div class="pago rowcenter">
                            <img src="img/credito.png" />
                        </div>
                        <h3>Tarjeta de credito</h3>
                    </a>
                </div>

                <div class="col-sm-6 col-md-3">
                    <a href="PagoPSE.aspx">
                        <div class="pago">
                            <img src="img/pse.png" />
                        </div>
                        <h3>PSE</h3>
                    </a>
                </div>

                <div class="col-sm-6 col-md-3">
                    <a href="PagoEfectivo.aspx">
                        <div class="pago">
                            <img src="img/efectivo.png" />
                        </div>
                        <h3>Efectivo</h3>
                    </a>
                </div>

                <div class="col-sm-6 col-md-3">
                    <a href="PagoTExito.aspx">
                        <div class="pago">
                            <img src="img/exito.png" />
                        </div>
                        <h3>Tarjeta Exito</h3>
                    </a>
                </div>

            </div>

        </div>

        <div class="rowcenter">
            <img src="img/SectionAbajo.png" />
        </div>

        <div class="container medios borde-arriba">


            <div class="card bg-light">

                <div class="card-header center-xs">
                    <h2>Consultar <b class="letra-verde">Estado</b></h2>
                </div>

                <div class="card-body col-md-12 row center-xs">



                    <div class="col-md-12 pago">
                        <div class="col-md-12">
                            <h2 class="letra-verde">Id Transaccion</h2>
                            <asp:TextBox runat="server" ID="txtIdTransaccion" TextMode="Number" Width="100%"></asp:TextBox>
                            <br />
                            <br />
                            <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary btn-block  rowcenter" OnClick="btnConsultar_Click" />
                        </div>
                    </div>

                    <div class="col-md-4 pago">
                        <div class="col-md-12">
                            <h2 class="letra-verde">Estado</h2>
                            <asp:Button runat="server" ID="lblAprobada" CssClass="btn btn-success btn-block  rowcenter" Visible="false" Enabled="false"></asp:Button>
                            <asp:Button runat="server" ID="lblRechazada" CssClass="btn btn-danger btn-block  rowcenter" Visible="false" Enabled="false"></asp:Button>
                            <asp:Button runat="server" ID="lblPendiente" CssClass="btn btn-warning btn-block  rowcenter" Visible="false" Enabled="false"></asp:Button>
                        </div>
                    </div>

                    <div class="col-md-4 pago">
                        <div class="col-md-12">
                            <h2 class="letra-verde">Detalle</h2>
                            <asp:TextBox runat="server" ID="txtDetalle" CssClass="btn btn-light btn-block  rowcenter" Visible="false" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                            <%--<asp:Button runat="server" ID="btnDetalle" CssClass="btn btn-light btn-block  rowcenter" Visible="false" Enabled="false"></asp:Button>--%>
                            <%--<asp:Label runat="server" ID="lblDetalle" CssClass="btn btn-success" Visible="false" Enabled="false"></asp:Label>--%>
                        </div>
                    </div>






                </div>
            </div>
        </div>


        <div class="rowcenter">
            <img src="img/SectionAbajo.png" />
        </div>





    </form>
</body>
</html>
