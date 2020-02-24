using System.Collections.Generic;

namespace Lab1Kruskal.DSU
{
    public class DsuNaiveImpl : IDsu<int>
    {
        private readonly List<int> _parent = new List<int>();

        public void MakeSet(int t)
        {
            _parent.Add(t);
        }

        public void UnionSets(int first, int second)
        {
            var a = FindSet(first);
            var b = FindSet(second);
            if (a != b) _parent[b] = a;
        }

        public int FindSet(int t)
        {
            return t == _parent[t] ? t : FindSet(_parent[t]);
        }
    }
}