using System.Collections.Generic;
using Lab1Kruskal.DSU;

namespace Lab1Kruskal.Kruskal
{
    public class KruskalImpl : IKruskalAlgorithm
    {
        private readonly IDsu<int> _dsu;

        public KruskalImpl(IDsu<int> dsu)
        {
            _dsu = dsu;
        }

        public int Cost { get; set; }

        public List<Edge> FindMst(int amountOfVertices, List<Edge> edges)
        {
            var result = new List<Edge>();

            edges.Sort(); 

            for (var i = 0; i < amountOfVertices; i++) _dsu.MakeSet(i);

            Cost = 0;
            foreach (var edge in edges)
            {
                var from = edge.From;
                var to = edge.To;
                var weight = edge.Weight;
                if (_dsu.FindSet(from) == _dsu.FindSet(to)) continue;

                Cost += weight;
                result.Add(new Edge(from, to, 0));
                _dsu.UnionSets(from, to);
            }

            return result;
        }
    }
}