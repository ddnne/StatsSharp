using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.Extensions
{
    public static class GraphProperty
    {
        public static IEnumerable<INode> GetConnectedNodes(this Graph.Graph graph, INode node)
        {
            return graph.Edges.Where(edge => edge.From.Equals(node) || edge.To.Equals(node))
                .Select(edge =>
                {
                    if (edge.From.Equals(node))
                        return edge.To;
                    else
                        return edge.From;
                });
        }

        public static IEnumerable<INode> GetConnectedNodesFrom(this DirectedGraph graph, INode node)
        {
            return graph.Edges.Where(edge => edge.From.Equals(node))
                .Select(edge => edge.To);
        }

        public static IEnumerable<INode> GetConnectedNodesTo(this DirectedGraph graph, INode node)
        {
            return graph.Edges.Where(edge => edge.To.Equals(node))
                .Select(edge => edge.From);
        }
    }
}
