using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianCreators.Models.Contracts
{
    public interface IComment
    {
        Guid Id { get; set; }

        DateTime PostedOn { get; set; }

        User PostedBy { get; set; }
    }
}
