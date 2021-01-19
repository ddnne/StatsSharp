using StatsSharp.Graph.Edge;
using StatsSharp.Graph.Graph;
using StatsSharp.Graph.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsSharp.Graph.Extensions
{
    public static class ExtensionsComputeAdjointMatrix
    {
        public static MathNet.Numerics.LinearAlgebra.Matrix<double> ComputeAdjointMatrix(this Graph.Graph graph)
        {
            var names = graph.Nodes.OrderBy(name => name.NodeName);
            var size = names.Count();
            var indexToName = names.Zip(Enumerable.Range(0, size), (name, index) => new { name, index })
                .ToDictionary(pair => pair.index, pair => pair.name);

            return MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(size, size, (i, j) =>
                {
                    var from = indexToName[i];
                    var to = indexToName[j];
                    var targetEdge = graph.Edges.Where(edge => (edge.From.Equals(from) && edge.To.Equals(to)) ||
                                                            edge.To.Equals(from) && edge.From.Equals(to));
                    if (targetEdge.Any())
                        return 1;
                    else
                        return 0;
                });
        }

        public static MathNet.Numerics.LinearAlgebra.Matrix<double> ComputeAdjointMatrix(this DirectedGraph graph)
        {
            var names = graph.Nodes.OrderBy(name => name.NodeName);
            var size = names.Count();
            var indexToName = names.Zip(Enumerable.Range(0, size), (name, index) => new { name, index })
                .ToDictionary(pair => pair.index, pair => pair.name);

            return MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(size, size, (i, j) =>
                {
                    var from = indexToName[i];
                    var to = indexToName[j];
                    var targetEdge = graph.Edges.Where(edge => edge.From.Equals(from) && edge.To.Equals(to));
                    if (targetEdge.Any())
                        return 1;
                    else
                        return 0;
                });
        }

        public static MathNet.Numerics.LinearAlgebra.Matrix<double> ComputeAdjointMatrix(this WeightedGraph graph)
        {
            var names = graph.Nodes.OrderBy(name => name.NodeName);
            var size = names.Count();
            var indexToName = names.Zip(Enumerable.Range(0, size), (name, index) => new { name, index })
                .ToDictionary(pair => pair.index, pair => pair.name);

            return MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(size, size, (i, j) =>
                {
                    var from = indexToName[i];
                    var to = indexToName[j];
                    var targetEdge = graph.Edges.Where(edge => (edge.From.Equals(from) && edge.To.Equals(to)) ||
                                                            edge.To.Equals(from) && edge.From.Equals(to));
                    if (targetEdge.Any())
                        return ((WeightedEdge)targetEdge.First()).Weight;
                    else
                        return 0;
                });
        }

        public static MathNet.Numerics.LinearAlgebra.Matrix<double> ComputeAdjointMatrix(this WeightedDirectedGraph graph)
        {
            var names = graph.Nodes.OrderBy(name => name.NodeName);
            var size = names.Count();
            var indexToName = names.Zip(Enumerable.Range(0, size), (name, index) => new { name, index })
                .ToDictionary(pair => pair.index, pair => pair.name);

            return MathNet.Numerics.LinearAlgebra.Double.Matrix.Build
                .Dense(size, size, (i, j) =>
                {
                    var from = indexToName[i];
                    var to = indexToName[j];
                    var targetEdge = graph.Edges.Where(edge => edge.From.Equals(from) && edge.To.Equals(to));
                    if (targetEdge.Any())
                        return ((WeightedEdge)targetEdge.First()).Weight;
                    else
                        return 0;
                });
        }
    }
}
