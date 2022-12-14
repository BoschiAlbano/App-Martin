namespace Aplicacion.CadenaConexion
{
    public static class CadenaConecion
    {
        //private const string Servidor = @"DESKTOP-2STKJOV";   // Noteboock
        //private const string Servidor = @"DESKTOP-N02BDJ1";   // MARTIN
        //private const string Servidor = @"DESKTOP-Q8KOGOT";   // Escritorio
        private const string Servidor = @".";
        private const string BaseDatos = @"App-Martin";
        private const string Usuario = @"sa";
        private const string Password = @"androy";

        // Propiedad
        public static string ObtenerCadenaSql => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"User Id={Usuario}; " +
                                                 $"Password={Password};";

        public static string ObtenerCadenaWin => $"Data Source={Servidor}; " +
                                                 $"Initial Catalog={BaseDatos}; " +
                                                 $"Integrated Security=true;";
    }
}
