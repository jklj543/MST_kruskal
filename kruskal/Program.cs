using System;
using System.Linq;
using System.Collections.Generic;

namespace kruskal
{
	public class edge
	{
		public int Vertex1 { get; set; }
		public int Vertex2 { get; set; }
		public int Weight { get; set; }
    }
	class Program
    {
        static void Main(string[] args)
        {
			Console.Write("Finding MST by Kruskal Algo\n");
			Console.Write("*-----------------------------------------*\n");

			List<edge> E = new List<edge>();
			List<int> V = new List<int>() {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 };
			
			Console.WriteLine("Enter number of edges : ");
			int e = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Enter edges : \n");
			for (int i = 1; i <= e; i++)
			{
				Console.WriteLine("Edges"+i+": ");
				Console.Write("Vertex1 : " + " "); int v1 = Convert.ToInt32(Console.ReadLine());
				Console.Write("Vertex2 : " + " "); int v2 = Convert.ToInt32(Console.ReadLine());
				Console.Write("Weight : " + " "); int w = Convert.ToInt32(Console.ReadLine());
				E.Add(new edge() { Vertex1 = v1, Vertex2 = v2, Weight = w });
				Console.WriteLine("\n");
			}

			List<edge> mst = kruskal(E, V);
			int MST_cost = 0;

			Console.WriteLine("MST Edges: ");
			foreach (edge edge in mst)
			{
				Console.WriteLine("Edge: {0} ----- {1} ,Weight= {2}", edge.Vertex1, edge.Vertex2, edge.Weight);
				MST_cost += edge.Weight;
			}
			Console.WriteLine("MST Cost= "+ MST_cost);
		}

		//-----------------------------------------------------------------------------------------------------------------

		static List<edge> kruskal(List<edge> E, List<int> V)
		{
			List<edge> A = new List<edge>();
			
			//Make_set
			foreach (int v in V)
			{
				parent[v] = v;
			}

			//sort edges into nondecreasing order by weight
			var oederedE = E.OrderBy(w => w.Weight).ToList();

			//eliminate cycles
			foreach (edge edge in oederedE)
			{
				int V1 = edge.Vertex1;
				int V2 = edge.Vertex2;
				int W = edge.Weight;

				if (find_set(V1) != find_set(V2))
				{
					A.Add(edge);
					union(V1, V2);
				}
			}
			return A;
		}

		//-----------------------------------------------------------------------------------------------------------------

		//Disjoint (find,union) set
		static int[] parent = new int[100];

		//return the set that vertix(i) belongs
		public static int find_set(int i)
		{
			while (parent[i] != i)
				i = parent[i];
			return i;
		}
		//combine set1(that contain vertix(x)) with set2(that contain vertix(y))
		public static void union(int x, int y)
		{
			int a = find_set(x);
			int b = find_set(y);

            if (a != b)
            {
                parent[a] = b;
            }
        }
	}
}
