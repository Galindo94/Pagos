<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PagoPSE.aspx.cs" Inherits="Pagos.PAgoPSE" Async="true" %>

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

    <!-- Jquery UI v1.11.4 -->
    <script src="../../js/jquery-ui.min.js"></script>
    <link href="../../css/jquery-ui.css" rel="stylesheet" />

    <!-- Mask JQuery -->
    <script src="../../js/plugins/mask-jquery-3x/jquery.mask.min.js"></script>

    <!-- Chosen -->
    <script src="../../js/plugins/chosen/chosen.jquery.min.js"></script>
    <link href="../../js/plugins/chosen/chosen.min.css" rel="stylesheet" />

    <link rel="stylesheet" type="text/css" href="../../css/icontabi-style.css" />
    <link href="../../css/sticky-footer.css" rel="stylesheet" />

    <%--Mostrar alertas--%>
    <script src="../../js/Mensajes.js"></script>
    <script src="../../js/sweetalert.min.js"></script>
    <link href="../../css/sweetalert.css" rel="stylesheet" />
    <link href="../../css/normalize.css" rel="stylesheet" />


    <script type="text/javascript">
        function pageLoad() {
            $('.select-combobox').chosen({
                disable_search_threshold: 0,
                no_results_text: "¡El item no existe!. ",
                search_contains: true,
                width: '100%'
            });

            $(".fecha").datepicker({
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2100',
            });

            $('.Moneda').mask('#.##0,00', { reverse: true });
            $('.Entero').mask('#.##0', { reverse: true });
        }



    </script>

    <script src="../../js/modernizr-custom.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <%--Informacion general--%>
        <div class="container medios borde-arriba">

            <div class="col-md-12">
                <h2 class="letra-verde rowcenter">Información general</h2>
            </div>

            <div class="row col-md-12 ">

                <%--DIV Informacion Del Banco--%>
                <div class="col-md-4 pago">

                    <h4 class="letra-verde rowcenter">Información del banco.</h4>

                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Tipo de Banca: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:DropDownList ID="cmbTipoBanca" runat="server" DataTextField="Nombre" DataValueField="Value" Width="100%"></asp:DropDownList>
                    </div>

                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Banco: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:DropDownList ID="cmbBancos" runat="server" DataTextField="bankName" DataValueField="bankCode" Width="100%"></asp:DropDownList>
                    </div>

                </div>

                <%--DIV informacion del comprador--%>
                <div class="col-md-4 pago">

                    <h4 class="letra-verde rowcenter">Información del comprador.</h4>

                    <asp:RadioButtonList ID="RBInfo" runat="server" OnSelectedIndexChanged="RBInfo_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0" Selected="True">&nbsp;Llenar de forma manual.</asp:ListItem>
                        <asp:ListItem Value="1">&nbsp;Llenar automáticamente.</asp:ListItem>
                    </asp:RadioButtonList>

                </div>

                <%--DIV BOTON PAGAR--%>
                <div class="col-md-3 pago">
                    <asp:ImageButton ID="btnPagar" runat="server" CssClass="btn btn-outline-light rowcenter" OnClick="btnPagar_Click" ImageUrl="~/img/psepagos.jpg" Width="208px" Height="154px" />
                </div>

            </div>

        </div>

        <%--Triangulo abajo--%>
        <div class="rowcenter">
            <asp:Image runat="server" ImageUrl="~/img/SectionAbajo.png" />
        </div>

        <%--Informacion del comprador--%>
        <div class="container medios borde-arriba">

            <div class="col-md-12">
                <h2 class="letra-verde rowcenter">Información del comprador</h2>
            </div>

            <div class="row  col-md-12 pago">



                <div class="col-md-4">

                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Tipo documento: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:DropDownList ID="cmbTipoIdentificacion" runat="server" DataTextField="Nombre" DataValueField="Value" Width="100%"></asp:DropDownList>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Numero documento: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtNroDocumento" Width="100%" MaxLength="12"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Nombres: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtNombres" Width="100%" MaxLength="60"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Apellidos: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtApellidos" Width="100%" MaxLength="60"></asp:TextBox>
                    </div>

                </div>

                <div class="col-md-4">
                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Dirección: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtDireccion" Width="100%" MaxLength="100"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Teléfono fijo: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtTelFijo" Width="100%" MaxLength="30"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Teléfono móvil: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtTelMovil" Width="100%" MaxLength="30"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="E-mail: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtEmail" Width="100%" TextMode="Email" MaxLength="80"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Ciudad: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtCiudad" Width="100%" MaxLength="50"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Departamento: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtDepartamento" Width="100%" MaxLength="60"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="País: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtPais" Width="100%" Text="CO" Enabled="false"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Empresa: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtEmpresa" Width="100%" MaxLength="60"></asp:TextBox>
                    </div>
                </div>

            </div>

        </div>

        <%--Triangulo abajo--%>
        <div class="rowcenter">
            <asp:Image runat="server" ImageUrl="~/img/SectionAbajo.png" />
        </div>

        <%--Informacion del pago--%>
        <div class="container medios borde-arriba">

            <div class="col-md-12">
                <h2 class="letra-verde rowcenter">Información del pago</h2>
            </div>

            <div class="row  col-md-12 pago">

                <div class="col-md-6">

                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Referencia de pago: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtReferenciaPago" Width="100%" MaxLength="32"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Descripción: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtDescripcion" Width="100%" MaxLength="255" TextMode="MultiLine"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Lenguaje: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="TextBox6" Width="100%" MaxLength="2" Text="ES" Enabled="false"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Moneda: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="TextBox7" Width="100%" MaxLength="3" Text="COP" Enabled="false"></asp:TextBox>
                    </div>


                </div>

                <div class="col-md-6">

                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Total: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtTotal" Width="100%" TextMode="Number"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Impuesto: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtImpuesto" Width="100%" TextMode="Number"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Base impuesto: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtBaseImpuesto" Width="100%" TextMode="Number"></asp:TextBox>
                    </div>


                    <div class="col-md-12">
                        <strong>
                            <asp:Label runat="server" Text="Propinas: "></asp:Label>
                        </strong>
                    </div>

                    <div class="col-md-12">
                        <asp:TextBox runat="server" ID="txtPropinas" Width="100%" TextMode="Number"></asp:TextBox>
                    </div>

                </div>

            </div>

        </div>

        <%--Triangulo abajo--%>
        <div class="rowcenter">
            <asp:Image runat="server" ImageUrl="~/img/SectionAbajo.png" />
        </div>

    </form>
</body>
</html>
