using System;

namespace Lab1Kruskal
{
    public class Edge : IComparable<Edge>
    {
        public Edge(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }

        public int From { get; }

        public int To { get; }

        public int Weight { get; }

        public int CompareTo(Edge other)
        {
            return Weight.CompareTo(other.Weight);
        }
    }
}