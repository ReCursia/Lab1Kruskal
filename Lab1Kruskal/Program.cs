using System;
using System.Collections.Generic;
using Lab1Kruskal.DSU;
using Lab1Kruskal.Kruskal;

namespace Lab1Kruskal
{
    internal class Program
    {
        private static void Main()
        {
            //Uncomment what you want to test
            //TestKruskal();
            TestDsu();
        }

        private static void TestDsu()
        {
            var dsu = new DsuNaiveImpl() as IDsu<int>;
            var result = new List<string>();

            var n = ReadInt();
            //Init
            for (var i = 0; i < n; i++) dsu.MakeSet(i);
            //Action
            for (var i = 0; i < n - 1; i++)
            {
                var elems = Console.ReadLine().Split(null);
                dsu.UnionSets(ConvertToInt(elems[0]), ConvertToInt(elems[1]));
                var output = dsu.FindSet(0) == dsu.FindSet(n - 1) ? "YES" : "NO";
                result.Add(output);
            }

            //Outputting result
            foreach (var line in result) Console.Out.Write(line + "\n");
        }

        private static void TestKruskal()
        {
            //Init
            var sizes = Console.ReadLine().Split(null);
            var amountOfVertices = ConvertToInt(sizes[0]);
            var amountOfEdges = ConvertToInt(sizes[1]);
            var edges = GetEdgesFromConsole(amountOfEdges);

            //Algorithm
            var kruskal = new KruskalImpl(new DsuEffectiveImpl()) as IKruskalAlgorithm;
            var result = kruskal.FindMst(amountOfVertices, edges);

            //Outputting result
            Console.Out.Write(result.Count + " ");
            Console.Out.Write(kruskal.Cost + "\n");
            foreach (var edge in result) Console.Out.Write(edge.From + " " + edge.To + "\n");
        }

        private static List<Edge> GetEdgesFromConsole(int amountOfEdges)
        {
            var edges = new List<Edge>();
            for (var i = 0; i < amountOfEdges; i++)
            {
                var numbers = Console.ReadLine().Split(null);
                edges.Add(new Edge(
                        ConvertToInt(numbers[0]),
                        ConvertToInt(numbers[1]),
                        ConvertToInt(numbers[2])
                    )
                );
            }

            return edges;
        }

        private static int ConvertToInt(string str)
        {
            return Convert.ToInt32(str);
        }

        private static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}