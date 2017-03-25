using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Data
{
    public interface ICreatorsDbSaveChangesContext
    {
        int SaveChanges();
    }
}
