using System.Data.SqlClient;
namespace CRUD_ADONET.Data
{
    public class Conexion
    {
        private readonly string cadenaSQL = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
                
                cadenaSQL = builder.GetConnectionString("CadenaSQL") ?? 
                throw new InvalidOperationException("Connection string 'CadenaSQL' not found.");
        }
        public string GetCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}