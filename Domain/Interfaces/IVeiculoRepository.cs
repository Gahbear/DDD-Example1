﻿using Domain.Commands;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<string> PostAsync(VeiculoCommand command);
        void PostAsync();
        void GetAsync();
        Task<IEnumerable<VeiculoCommand>> GetVeiculosAlugadosAsync();
        Task<VeiculoPrecoCommand> GetPrecoDiaria(ETipoVeiculo tipoVeiculo);
    }
}
