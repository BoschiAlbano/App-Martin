using System;
using System.Windows.Forms;
using Aplicacion.IoC;
using Presentacion.Core.Reportes;

namespace CommerceApp
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuracion del Inyector (StructureMap)
            new StructureMapContainer().Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            //Application.Run(new Principal());
        
        }
    }
}
