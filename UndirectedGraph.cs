using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication
{
    interface UndirectedGraph<V, E> : Graph <V, E>
    {
        int degreeOf(V vertex);
    }
}
