using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GestionEmpleados.Controllers
{
    public class EmpleadosController : ApiController
    {
        public IEnumerable<Empleado> Get()
        {
            return EmpleadoBL.ObtenerEmpleadosConCalculos();
        }
    }
}
