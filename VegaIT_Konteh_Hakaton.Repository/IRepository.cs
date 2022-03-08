using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VegaIT_Konteh_Hakaton.Repository
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
