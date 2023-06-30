using CartasMatematicas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartasMatematicas
{
    public static class Extension
    {
        public static string TomaSimbolo(this OperacionEnum operacion)
        {
            switch (operacion)
            {
                case OperacionEnum.Suma:
                    return "+";
                case OperacionEnum.Multiplo:
                    return "*";
                default: throw new Exception("Operacion no soportada");
            }
        }

        public static int ObtResp(this OperacionEnum operacion, int x, int y)
        {
            switch (operacion)
            {
                case OperacionEnum.Suma:
                    return x + y;
                case OperacionEnum.Multiplo:
                    return x * y;
                default: throw new Exception("Operacion no soportada");
            }
        }
    }
}
