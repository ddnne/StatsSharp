using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.Extensions
{
    public static class ComputeDegreeMethod
    {
        public static int ComputeDegree(this Graph.Graph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.From.Equals(targetNode) || edge.To.Equals(targetNode))
                .Count();
        }

        public static int ComputeInDegree(this DirectedGraph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.To.Equals(targetNode))
                .Count();
        }

        public static int ComputeOutDegree(this DirectedGraph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.From.Equals(targetNode))
                .Count();
        }

        public static double ComputeWeightedDegree(this WeightedGraph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.From.Equals(targetNode) || edge.To.Equals(targetNode))
                .Select(edge => ((WeightedEdge)edge).Weight).Sum();
        }


        public static double ComputeWeightedInDegree(this WeightedDirectedGraph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.To.Equals(targetNode))
                .Select(edge => ((WeightedEdge)edge).Weight).Sum();
        }

        public static double ComputeWeightedOutDegree(this WeightedDirectedGraph graph, INode targetNode)
        {
            return graph.Edges.Where(edge => edge.From.Equals(targetNode))
                .Select(edge => ((WeightedEdge)edge).Weight).Sum();
        }
    }
}
