using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flanellib.Sbd.Interfaces
{
    public interface IReturn<TInput, T> where T : class
    {
        T Return(TInput input);
    }
}
