using System.Collections.Generic;

namespace Lab1Kruskal.Kruskal
{
    public interface IKruskalAlgorithm
    {
        int Cost { get; }
        public List<Edge> FindMst(int amountOfVertices, List<Edge> edges);
    }
}