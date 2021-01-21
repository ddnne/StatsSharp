using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.Algorithm
{

    public partial class ShortestPath
    {
        public static Result BellmanFord(IGraph graph, INode node)
        {
            if (graph is Graph.Graph)
                return BellmanFord((Graph.Graph)graph, node);
            else if (graph is WeightedGraph)
                return BellmanFord((WeightedGraph)graph, node);
            else if (graph is DirectedGraph)
                return BellmanFord((DirectedGraph)graph, node);
            else if (graph is WeightedDirectedGraph)
                return BellmanFord((WeightedDirectedGraph)graph, node);

            else
                throw new NotImplementedException();

        }
        private static Result BellmanFord(Graph.Graph graph, INode source)
        {
            var weightedDiGraph = new WeightedDirectedGraph(
                graph.Edges.Select(edge => new WeightedEdge(edge.From, edge.To, 1)).Concat(
                    graph.Edges.Select(edge => new WeightedEdge(edge.To, edge.From, 1))),
                graph.Nodes.Select(node => new Node.Node(node.NodeName)));
            return BellmanFord(weightedDiGraph, source);
        }

        private static Result BellmanFord(WeightedGraph graph, INode source)
        {
            var weightedDiGraph = new WeightedDirectedGraph(
                graph.Edges.Select(edge => new WeightedEdge(edge.From, edge.To, ((WeightedEdge)edge).Weight))
                .Concat(graph.Edges.Select(edge => new WeightedEdge(edge.To, edge.From, ((WeightedEdge)edge).Weight))),
                graph.Nodes.Select(node => new Node.Node(node.NodeName)));
            return BellmanFord(weightedDiGraph, source);
        }

        private static Result BellmanFord(DirectedGraph graph, INode source)
        {
            var weightedDiGraph = new WeightedDirectedGraph(
                graph.Edges.Select(edge => new WeightedEdge(edge.From, edge.To, 1)),
                graph.Nodes.Select(node => new Node.Node(node.NodeName)));
            return BellmanFord(weightedDiGraph, source);
        }

        private static Result BellmanFord(WeightedDirectedGraph graph, INode source)
        {
            if (!graph.Edges.Any() || !graph.Nodes.Any())
                throw new Exception("Graph has no edges or no nodes");
            else if (!graph.Nodes.Where(node => node.Equals(source)).Any())
                throw new Exception("Nodes of graph should have the source node");
            else
            {
                // https://en.wikipedia.org/wiki/Bellman%E2%80%93Ford_algorithm
                var result = new Result()
                {
                    Source = source,
                    Targets = graph.Nodes,
                    TargetToDistance = graph.Nodes.ToDictionary(node => node, node => Double.PositiveInfinity),
                    TargetToPredecessor = graph.Nodes.ToDictionary(node => node, node => new List<INode>())
                };
                
                result.TargetToDistance[source] = 0;

                for (int i = 1; i < graph.Nodes.Count(); ++i)
                {
                    foreach (var edge in (IEnumerable<WeightedEdge>)graph.Edges)
                    {
                        if (result.TargetToDistance[edge.From] + edge.Weight < result.TargetToDistance[edge.To])
                        {
                            result.TargetToDistance[edge.To] = result.TargetToDistance[edge.From] + edge.Weight;
                            result.TargetToPredecessor[edge.To].Add(edge.From);
                        }
                    }
                }

                foreach (var edge in (IEnumerable<WeightedEdge>)graph.Edges)
                {
                    if (result.TargetToDistance[edge.From] + edge.Weight < result.TargetToDistance[edge.To])
                        throw new Exception("Graph contains a negatve-weight cycle");
                }

                return result;
            }
        }
    }
}
