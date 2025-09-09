using MySqlConnector;
using Negocio.Models;
using Negocio.Repositories.Interfaces;

namespace Negocio.Repositories.Implementations
{
    public class PagosClienteRepository : IPagosClienteRepository
    {
        private readonly string _connectionString;

        public PagosClienteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("conexion");
        }

        private async Task<int> ObtenerSaldoActualAsync(int idCliente)
        {
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = @"SELECT saldo FROM pagos_clientes 
                                 WHERE id_cliente = @IdCliente 
                                 ORDER BY fecha DESC, id_pago DESC 
                                 LIMIT 1;";

            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

            var result = await cmd.ExecuteScalarAsync();
            return result == null ? 0 : Convert.ToInt32(result);
        }

        public async Task<int> RegistrarMovimientoAsync(PagosClienteDTO movimiento)
        {
            int saldoActual = await ObtenerSaldoActualAsync(movimiento.IdCliente);

            // Calcular nuevo saldo según tipo
            int nuevoSaldo = movimiento.Tipo.ToUpper() == "DEUDA"
                ? saldoActual - movimiento.Monto
                : saldoActual + movimiento.Monto;

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = @"
                INSERT INTO pagos_clientes (id_cliente, fecha, pagado, deuda, saldo)
                VALUES (@IdCliente, @Fecha, @Pagado, @Deuda, @Saldo);
                SELECT LAST_INSERT_ID();";

            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdCliente", movimiento.IdCliente);
            cmd.Parameters.AddWithValue("@Fecha", movimiento.Fecha);
            cmd.Parameters.AddWithValue("@Pagado", movimiento.Tipo.ToUpper() == "PAGO" ? movimiento.Monto : 0);
            cmd.Parameters.AddWithValue("@Deuda", movimiento.Tipo.ToUpper() == "DEUDA" ? movimiento.Monto : 0);
            cmd.Parameters.AddWithValue("@Saldo", nuevoSaldo);

            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task<IEnumerable<PagosClienteDTO>> ObtenerPagosPorClienteAsync(int idCliente)
        {
            var pagos = new List<PagosClienteDTO>();

            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            const string sql = @"
                SELECT id_pago, id_cliente, fecha, pagado, deuda, saldo
                FROM pagos_clientes
                WHERE id_cliente = @IdCliente
                ORDER BY fecha DESC;";

            await using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@IdCliente", idCliente);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                pagos.Add(new PagosClienteDTO
                {
                    IdPago = reader.GetInt32("id_pago"),
                    IdCliente = reader.GetInt32("id_cliente"),
                    Fecha = reader.GetDateTime("fecha"),
                    Monto = reader.GetInt32("pagado") > 0
                                ? reader.GetInt32("pagado")
                                : reader.GetInt32("deuda"),
                    Tipo = reader.GetInt32("pagado") > 0 ? "PAGO" : "DEUDA",
                    Saldo = reader.GetInt32("saldo")
                });
            }

            return pagos;
        }
    }
}
