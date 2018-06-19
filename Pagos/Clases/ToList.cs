using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pagos.Clases
{
    public static class ConverEnum
    {
        public static List<ItemListaDTO> ToList(this Enum enumeracion)
        {
            Array oItems = Enum.GetValues(enumeracion.GetType());
            List<ItemListaDTO> oListaDTO = new List<ItemListaDTO>();
            ItemListaDTO oItemBlanco = new ItemListaDTO();

            for (int nContador = 0; nContador < oItems.Length; nContador++)
            {
                ItemListaDTO oItem = new ItemListaDTO();
                object oValorEnum = oItems.GetValue(nContador);

                if ((int)oItems.GetValue(nContador) == -1)
                {
                    oItemBlanco = new ItemListaDTO() { Nombre = GetEnumDescription(oValorEnum.GetType().GetField(oValorEnum.ToString())), Valor = ((int)oValorEnum).ToString(), Value = (int)oItems.GetValue(nContador) };
                    continue;
                }
                oListaDTO.Add(new ItemListaDTO() { Nombre = GetEnumDescription(oValorEnum.GetType().GetField(oValorEnum.ToString())), Valor = ((int)oValorEnum).ToString(), Value = (int)oItems.GetValue(nContador) });
            }
            if (oItemBlanco.Valor != null)
                oListaDTO.Insert(0, oItemBlanco);
            return oListaDTO;
        }
        public static string GetEnumDescription(FieldInfo oFieldInfo)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])oFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return oFieldInfo.Name;
        }

    }
}