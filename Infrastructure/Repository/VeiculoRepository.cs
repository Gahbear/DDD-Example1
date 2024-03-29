﻿using Dapper;
using Domain.Commands;
using Domain.Entidades;
using Domain.Enum;
using Domain.Interfaces;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        string conexao = @"Server=(localdb)\mssqllocaldb;Database=AluguelVeiculos;Trusted_Connection=True;MultipleActiveResultSets=true";
        public async Task<string> PostAsync(VeiculoCommand command)
        {
            string queryInsert = @"
INSERT INTO Veiculo(Placa, AnoFabricacao, TipoVeiculoId, Estado, MontadoraId)
VALUES(@Placa, @AnoFabricacao, @TipoVeiculoId, @Estado, @MontadoraId)";

            using (var conn = new SqlConnection())
            {
                conn.Execute(queryInsert, new
                {
                    Placa = command.Placa,
                    AnoFabricacao = command.AnoFabricacao,
                    TipoVeiculoId = command.TipoVeiculo,
                    Estado = command.Estado,
                    MontadoraId = command.Montadora
                });

                return "Veiculo Cadastrado com sucesso";
            }

        }
        public void PostAsync()
        {

        }
        public void GetAsync()
        {

        }

        public async Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync()
        {
            string queryBuscarGetVeiculosAlugadosAsync = @"
             SELECT * FROM Veiculo WHERE ALUGADO = 0";
            using(SqlConnection conn = new SqlConnection(conexao)) 
            {
                return conn.QueryAsync<VeiculoCommand>(
                    queryBuscarGetVeiculosAlugadosAsync).Result.ToList();
            }
        }
        public async Task<VeiculoPrecoCommand> GetPrecoDiaria(ETipoVeiculo tipoVeiculo)
        {
            string queryGetPrecoDiaria = @"SELECT * FROM Veiculopreco WHERE TipoVeiculo = @TIPOVEICULO";
            using (SqlConnection conn = new SqlConnection(conexao)) 
            {
                return conn.Query<VeiculoPrecoCommand>(queryGetPrecoDiaria, new{
                    TipoVeiculo = tipoVeiculo
                }).FirstOrDefault();
            }

        }
    }
}
