using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Pagos.Enumeraciones
{
    public enum enmTipoIdentificacion
    {
        [Description("Cedula de Ciudadania")]
        Cedula = 1,
        [Description("Cédula Extranjería")]
        CedulaExtranjera = 2,
        [Description("Tarjeta de Identidad")]
        TI = 3,
        [Description("Pasaporte")]
        Pasaporte = 4,
    }
}