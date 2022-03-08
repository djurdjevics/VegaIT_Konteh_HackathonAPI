using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VegaIT_Konteh_Hackathon.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
