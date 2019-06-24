using System.Collections.Generic;
using System.Threading.Tasks;

namespace Envision.MDM.Location.Domain.Common
{
    /// <summary>
    /// Author:         Johng
    /// Created Date:   03/27/2019
    /// Description:    This is a generic Query repository for all different repositories on 
    ///                 this domain.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<T> where T : IAggregateRoot
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetList(int pageIndex, int pageSize);
    }
}
