using System.Collections.Generic;

namespace Lab1Kruskal.DSU
{
    public class DsuEffectiveImpl : IDsu<int>
    {
        private readonly List<int> _parent = new List<int>();
        private readonly List<int> _rank = new List<int>();

        public void MakeSet(int t)
        {
            _parent.Add(t);
            _rank.Add(0);
        }

        public void UnionSets(int first, int second)
        {
            var x = FindSet(first);
            var y = FindSet(second);

            if (x == y) return;

            if (_rank[x] == _rank[y]) _rank[x]++;

            if (_rank[x] < _rank[y])
                _parent[x] = y;
            else
                _parent[y] = x;
        }

        public int FindSet(int t)
        {
            if (_parent[t] != t) _parent[t] = FindSet(_parent[t]);
            return _parent[t];
        }
    }
}