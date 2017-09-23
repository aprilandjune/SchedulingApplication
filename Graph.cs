using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApplication
{
    interface Graph <V,E>
    {
        E addEdge(V srcVertex, V targetVertex);
        Boolean addEdge(V srcVertex, V targetVertex, E e);
        Boolean addVertex(V v);
        Boolean containsEdge(E e);
        Boolean containsEdge(V srcVertex, V targetVertex);
        List<E> edgeSet();
        List<E> edgeSet(V vertex);
        double getEdgeWeight(E e);
        Boolean removeEdge(E e);
        E removeEdge(V srcVertex, V targetVertex);
        Boolean removeVertex(V v);
        List<V> vertexSet();
    }
}
