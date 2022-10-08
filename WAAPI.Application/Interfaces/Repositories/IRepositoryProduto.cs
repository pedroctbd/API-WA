using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAAPI.Domain.Entities;

namespace WAAPI.Application.Interfaces
{
    public interface IRepositoryProduto : IRepositoryBase<Produto>
    {
        Task<float> GetTotalMoneySpent();

    }
}