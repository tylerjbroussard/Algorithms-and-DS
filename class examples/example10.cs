using System;
using System.Collections.Generic;

namespace Ex1
{
	class Graph1
	{
		private Dictionary<string, HashSet<string>> adjacencyList;

		public Graph1()
		{
			adjacencyList = new Dictionary<string, HashSet<string>>();
		}

		static void Main(string[] args)
		{
			DoGraphThingies();
		}

		static void DoGraphThingies()
		{
			int graphNum = 2;
			Graph1 g = CreateGraph(graphNum);
			g.PrintGraph();

			bool recursive = true;

			g.DFSTraversal("b", recursive);
			g.DFSTraversal("c", recursive);
			
			g.DFSTraversal("a", recursive);
			g.DFSTraversal("a", !recursive);

			g.BFSTraversal("a");
		}

		static Graph1 CreateGraph(int graphNum)
		{
			Graph1 g = new Graph1();
			if (graphNum == 1)
			{
				g.AddEdge("a", "b");
				g.AddEdge("b", "c");
				g.AddEdge("b", "d");
				g.AddEdge("d", "c");
				g.AddEdge("d", "c");
				g.AddEdge("c", "a");
			}
			else if (graphNum == 2)
			{
				g.AddEdge("a", "b");
				g.AddEdge("b", "c");
				g.AddEdge("c", "d");
				g.AddEdge("d", "d1");
				g.AddEdge("d1", "d2");
				g.AddEdge("c", "c1");
				g.AddEdge("c1", "c2");
			}
			else if (graphNum == 3)		// this one is essentially a binary tree
			{
				g.AddEdge("a", "b");
				g.AddEdge("a", "c");
				g.AddEdge("b", "d");
				g.AddEdge("b", "e");
				g.AddEdge("c", "f");
				g.AddEdge("c", "g");
				g.AddEdge("d", "h");
				g.AddEdge("d", "i");
			}
			else
			{
				g.AddEdge("a", "b");
				g.AddEdge("a", "c");
			}
			return g;
		}

		private void DFSTraversal(string startingVertex, bool recursive)
		{
			Console.WriteLine("DFS " + (recursive ? "recursive" : "non-recursive") + 
				              " starting at vertex " + startingVertex + ":");

			Dictionary<string, bool> visited = new Dictionary<string, bool>();

			if (recursive)
				DFS(startingVertex, visited);
			else
				DFSNonRecursive(startingVertex, visited);

			Console.WriteLine();
		}

		private void VisitVertex(string v, Dictionary<string, bool>  visited)
		{
			visited[v] = true;
			Console.Write(v + " ");
		}

		private void DFSNonRecursive(string v, Dictionary<string, bool> visited)
		{
			Stack<string> s = new Stack<string>();
			s.Push(v);

			while (s.Count > 0)
			{
				string vertex = s.Pop();
				VisitVertex(vertex, visited);

				PushUnvisitedNeighbors(vertex, s, visited);
			}
		}
		private void PushUnvisitedNeighbors(string vertex, Stack<string> s, Dictionary<string, bool> visited)
		{
			// If vertex has no neighbors, nothing to do
			if (!adjacencyList.ContainsKey(vertex))
				return;

			HashSet<string> neighbors = adjacencyList[vertex];

			foreach (var neighborVertex in neighbors)
			{
				if (!visited.ContainsKey(neighborVertex) || (visited[neighborVertex] == false))
				{
					s.Push(neighborVertex);
				}
			}
		}

		private void PushUnvisitedNeighborsMaintainDFSRecursiveOrder(string vertex, Stack<string> s, Dictionary<string, bool> visited)
		{
			// If vertex has no neighbors, nothing to do
			if (!adjacencyList.ContainsKey(vertex))
				return;

			HashSet<string> neighbors = adjacencyList[vertex];
			string neighborsStr = string.Join(" ", adjacencyList);

			Stack<string> s2 = new Stack<string>();

			foreach (var neighborVertex in neighbors)
			{
				if (!visited.ContainsKey(neighborVertex) || (visited[neighborVertex] == false))
				{
					s2.Push(neighborVertex);
				}
			}
			foreach( var vtx in s2)
			{
				s.Push(vtx);
			}
		}

		private void DFS(string v, Dictionary<string, bool> visited)
		{
			VisitVertex(v, visited);

			// If v has no neighbors, nothing more to do
			if (!adjacencyList.ContainsKey(v))
				return;

			HashSet<string> neighbors = adjacencyList[v];
			foreach( var neighborVertex in neighbors)
			{
				if (!visited.ContainsKey(neighborVertex) || (visited[neighborVertex] == false))
				{
					DFS(neighborVertex, visited);
				}
			}
		}

		private void BFSTraversal(string startingVertex)
		{
			Console.WriteLine("BFS starting at vertex " + startingVertex + ":");
			Dictionary<string, bool> visited = new Dictionary<string, bool>();
			BFS(startingVertex, visited);
			Console.WriteLine();
		}

		private void BFS(string v, Dictionary<string, bool> visited)
		{
			Queue<string> q = new Queue<string>();
			q.Enqueue(v);

			while (q.Count > 0)
			{
				string vertex = q.Dequeue();
				VisitVertex(vertex, visited);

				EnqueueUnvisitedNeighbors(vertex, q, visited);
			}
		}

		private void EnqueueUnvisitedNeighbors(string vertex, Queue<string> q, Dictionary<string, bool> visited)
		{
			// If v has no neighbors, nothing to do
			if (!adjacencyList.ContainsKey(vertex))
				return;

			HashSet<string> neighbors = adjacencyList[vertex];
			foreach (var neighborVertex in neighbors)
			{
				if (!visited.ContainsKey(neighborVertex) || (visited[neighborVertex] == false))
				{
					q.Enqueue(neighborVertex);
				}
			}
		}

		public void AddEdge(string v1, string v2)
		{
			if (!adjacencyList.ContainsKey(v1))
			{
				adjacencyList[v1] = new HashSet<string>();
			}
			adjacencyList[v1].Add(v2);
		}

		public void PrintGraph()
		{
			foreach (var entry in adjacencyList)
			{
				HashSet<string> vertexNeighbors = entry.Value;
				Console.Write(entry.Key + ": ");
				PrintVertices(vertexNeighbors);
				Console.WriteLine();
			}
		}

		public void PrintVertices(HashSet<string> vertices)
		{
			foreach ( var entry in vertices)
			{
				Console.Write(entry + " ");
			}
		}
	}
}
