namespace Lab1Kruskal.DSU
{
    public interface IDsu<in T>
    {
        void MakeSet(T t);
        void UnionSets(T first, T second);
        int FindSet(T t);
    }
}