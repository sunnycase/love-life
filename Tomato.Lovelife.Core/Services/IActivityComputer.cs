using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomato.Lovelife.Services
{
    public interface IActivityComputer<in TParam, out TResult>
    {
        TResult Compute(TParam parameters);
    }
}
