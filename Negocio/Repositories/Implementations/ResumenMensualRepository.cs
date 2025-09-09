using MySqlConnector;
using Negocio.Models;
using Negocio.Repositories.Interfaces;
using Negocio.Services.Interfaces;
using System.Data;

namespace Negocio.Repositories.Implementations
{
    public class ResumenMensualRepository : IResumenMensualRepository
    {
        private readonly string _connectionString;

        public ResumenMensualRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conexion");
        }

        public async Task<ResumenMensualDTO> ObtenerResumenMensualAsync(int anio, int mes)
        {
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = new MySqlCommand("GenerarArqueoMensual", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_anio", anio);
            cmd.Parameters.AddWithValue("@p_mes", mes);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return new ResumenMensualDTO
                {
                    Anio = anio,
                    Mes = mes,
                    Ingresos = 0,
                    Egresos = 0,
                    EgresosCompras = 0,
                    EgresosSueldos = 0,
                    GananciaNeta = 0
                };

            return new ResumenMensualDTO
            {
                Anio = anio,
                Mes = mes,
                Ingresos = reader.GetDecimal("ingresos"),
                Egresos = reader.GetDecimal("egresos"),
                EgresosCompras = reader.GetDecimal("egresos_compras"),
                EgresosSueldos = reader.GetDecimal("egresos_sueldos"),
                GananciaNeta = reader.GetDecimal("ganancia_neta")
            };
        }
    }
}
