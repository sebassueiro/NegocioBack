using Microsoft.EntityFrameworkCore;
using Negocio.Repositories.Interfaces;
using MySqlConnector;
using System.Data;
using Negocio.Models;

namespace Negocio.Repositories.Implementations
{
    public class ResumenDiarioRepository : IResumenDiarioRepository
    {
        private readonly string _connectionString;

        public ResumenDiarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conexion");
        }

        public async Task<ResumenDiarioDTO> GenerarYObtenerArqueoDiarioAsync(DateTime fecha)
        {
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            await using var cmd = new MySqlCommand("GenerarArqueoDiario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_fecha", fecha.Date);

            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return new ResumenDiarioDTO
                {
                    Fecha = fecha.Date,
                    Ingresos = 0,
                    Egresos = 0,
                    GananciaNeta = 0
                };

            return new ResumenDiarioDTO
            {
                Fecha = reader.GetDateTime("fecha"),
                Ingresos = reader.GetDecimal("ingresos"),
                Egresos = reader.GetDecimal("egresos"),
                GananciaNeta = reader.GetDecimal("ganancia_neta")
            };
        }
    }
}
