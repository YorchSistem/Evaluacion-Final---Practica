using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados
{
    public class EmpleadoBL
    {
        public static List<Empleado> ObtenerEmpleadosConCalculos()
        {
            List<Empleado> empleados = EmpleadoDAL.ObtenerEmpleados();

            foreach (Empleado empleado in empleados)
            {
                empleado.MontoAumento = CalcularMontoAumento(empleado.SueldoBruto);
                empleado.SueldoNeto = empleado.SueldoBruto + empleado.MontoAumento;
            }

            return empleados;
        }

        private static decimal CalcularMontoAumento(decimal sueldoBruto)
        {
            if (sueldoBruto <= 1000)
            {
                return sueldoBruto * 0.1m;
            }
            else if (sueldoBruto <= 2000)
            {
                return sueldoBruto * 0.2m;
            }
            else if (sueldoBruto <= 4000)
            {
                return sueldoBruto * 0.3m;
            }
            else
            {
                return sueldoBruto * 0.4m;
            }
        }
    }
}
