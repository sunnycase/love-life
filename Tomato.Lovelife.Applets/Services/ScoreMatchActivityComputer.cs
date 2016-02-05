using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomato.Lovelife.Primitives;
using Tomato.Lovelife.Services;

namespace Tomato.Lovelife.Applets.Services
{
    class ScoreMatchActivityComputer : IActivityComputer<ScoreMatchActivityComputeParam, ScoreMatchActivityComputeResult>
    {
        public ScoreMatchActivityComputeResult Compute(ScoreMatchActivityComputeParam parameters)
        {
            return new ScoreMatchActivityComputeResult
            {
                
            };
        }
    }
}
