using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEmpleados;

namespace ClienteConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = EmpleadoBL.ObtenerEmpleadosConCalculos();

            foreach (Empleado empleado in empleados)
            {
                Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellidos}");
                Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto}");
                Console.WriteLine($"Monto Aumento: {empleado.MontoAumento}");
                Console.WriteLine($"Sueldo Neto: {empleado.SueldoNeto}");
                Console.WriteLine();
            }

            Console.WriteLine($"Monto total de Sueldos Netos: {empleados.Sum(e => e.SueldoNeto)}");
        }
    }
}
