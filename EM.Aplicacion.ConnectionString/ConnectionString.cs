namespace EM.Aplicacion.ConnectionString
{
    public static class ConnectionString
    {
        private const string DataBase = "EventManagerDB";

        private const string Server = @"DESKTOP-NDJOGL2\SQLEXPRESS";

        private const string User = "sa";

        private const string Password = "santi42175";

        public static string GetStringConection => $"Data Source={Server};" +
                                                   $"Initial Catalog={DataBase};" +
                                                   $"Integrated Security=true";
    }
}