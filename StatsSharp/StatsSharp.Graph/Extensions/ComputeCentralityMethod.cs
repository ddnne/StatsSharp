using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.Extensions
{
    public static class ComputeCentralityMethod
    {
        public static double ComputeClosenessCentrality(this IGraph graph, INode targetNode)
        {
            var distances = Algorithm.ShortestPath.BellmanFord(graph, targetNode);
            distances.TargetToDistance.Remove(targetNode);
            var averageDistance = distances.TargetToDistance.Values.Average();
            return 1.0 / averageDistance;
        }
    }
}
