using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace StatsSharp.Probability.Parameter.Discrete.Graph
{
    public class BernoulliGraph : IParameter
    {
        public BernoulliGraph(double edgeConnectedProbability, IEnumerable<Edge> edges, IEnumerable<Node> nodes)
        {
            if (edgeConnectedProbability < 0 || edgeConnectedProbability > 1)
                throw new ArgumentException();

            EdgeConnectedProbability = edgeConnectedProbability;
            Edges = edges;
            Nodes = nodes;
        }

        public double EdgeConnectedProbability { get; }
        public IEnumerable<Edge> Edges { get; }
        public IEnumerable<Node> Nodes { get; }
        public bool Equals([AllowNull] IParameter other)
        {
            if (other is null)
                return false;
            else if (!(other is BernoulliGraph))
                return false;
            else
                return EdgeConnectedProbability.Equals(((BernoulliGraph)other).EdgeConnectedProbability) &&
                    Edges.Equals(((BernoulliGraph)other).Edges) && Nodes.Equals(((BernoulliGraph)other).Nodes);
        }
    }
}
