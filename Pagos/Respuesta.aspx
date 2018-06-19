<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Respuesta.aspx.cs" Inherits="Pagos.Respuesta" %>

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
        <div class="container medios borde-arriba">
            <div class="row col-md-12 row pago  ">

                <div class="col-md-3"></div>

                <div class="col-md-6">

                    <div class="card bg-light">

                        <div class="card-header">
                            <h2><strong>Informacion importante</strong></h2>
                        </div>

                        <div class="card-body">

                            <p class="card-text">La transacción ha sido creada satisfactoriamente, tome nota del siguiente Identificador si desea conocer el estado de la misma más adelante.</p>

                            <div class="rowcenter">
                                <strong>
                                    <asp:Label runat="server" ID="lblIdTransaccion" CssClass="letra-verde h2 rowcenter"></asp:Label>
                                    <asp:Label runat="server" ID="lblRuta" Visible="false"></asp:Label>
                                </strong>
                            </div>

                            <br />

                            <asp:Button runat="server" ID="btnContinuarBanco" CssClass="btn btn-primary" Text="Ir al banco" OnClick="btnContinuarBanco_Click" Width="100%" />

                        </div>
                    </div>
                </div>

                <div class="col-md-3"></div>


            </div>


        </div>



    </form>
</body>
</html>
