using System.Data.SqlClient;

namespace GestionEmpleados
{
    public class EmpleadoDAL
    {
        private static string cadenaConexion = "Server=localhost;Database=GestionEmpleados;User Id=sa;Password=12345;";

        public static List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand("SELECT Id, Nombre, Apellidos, SueldoBruto, Categoria FROM Empleados", conexion))
                {
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Empleado empleado = new Empleado();
                            empleado.Id = lector.GetInt32(0);
                            empleado.Nombre = lector.GetString(1);
                            empleado.Apellidos = lector.GetString(2);
                            empleado.SueldoBruto = lector.GetDecimal(3);
                            empleado.Categoria = lector.GetString(4);

                            empleados.Add(empleado);
                        }
                    }
                }
            }

            return empleados;
        }

        public static void AgregarEmpleado(Empleado empleado)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (SqlCommand comando = new SqlCommand("INSERT INTO Empleados (Nombre, Apellidos, SueldoBruto, Categoria) VALUES (@Nombre, @Apellidos, @SueldoBruto, @Categoria)", conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    comando.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                    comando.Parameters.AddWithValue("@SueldoBruto", empleado.SueldoBruto);
                    comando.Parameters.AddWithValue("@Categoria", empleado.Categoria);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}