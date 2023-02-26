using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Domain.Services
{
    public interface ICrudService<TModel> 
    {
        Task<TModel> Get(int id);
        Task<IEnumerable<TModel>> GetAll();
        Task<bool> Add(TModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(TModel model);
    }
}
