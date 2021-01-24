using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using StatsSharp.Graph.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StatsSharp.StochasticProcess.RandomWalkConfig;

namespace StatsSharp.StochasticProcess.RandomWalk
{
    public abstract class ARandomWalk<RandomWalkConfig> : IRandomWalk<RandomWalkConfig>
        where RandomWalkConfig : IRandomWalkConfig
    {
        public ARandomWalk(IGraph graph, RandomWalkConfig config)
        {
            Graph = graph;
            Config = config;
            LocationHistory = new INode[] { config.Initial };

            if (graph is Graph.Graph.Graph)
                NodeToConnectedNodes = graph.Nodes.ToDictionary(node => node, node => ((Graph.Graph.Graph)graph).GetConnectedNodes(node));
            else if (graph is Graph.Graph.DirectedGraph)
                NodeToConnectedNodes = graph.Nodes.ToDictionary(node => node, node => ((Graph.Graph.DirectedGraph)graph).GetConnectedNodesFrom(node));
            else
                throw new ArgumentException();
        }

        public IGraph Graph { get; }
        public RandomWalkConfig Config { get; }

        public IEnumerable<INode> LocationHistory { get; set; }

        protected Dictionary<INode, IEnumerable<INode>> NodeToConnectedNodes { get; }

        public abstract void Walk();
    }
}
