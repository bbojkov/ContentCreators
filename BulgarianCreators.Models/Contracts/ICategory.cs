using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Models.Contracts
{
    public interface ICategory
    {
        Guid Id { get; set; }

        string CategoryName { get; set; }
        
    }
}
