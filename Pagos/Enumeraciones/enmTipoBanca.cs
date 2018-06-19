using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pagos.Enumeraciones
{
    public enum enmTipoBanca
    {
        [Description("Personas")]
        Cedula = 1,
        [Description("Empresas")]
        CedulaExtranjera = 2,
    }
}