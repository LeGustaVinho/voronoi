using System.Collections.Generic;
using UnityEngine;

namespace SharpVoronoiLib
{
    public class VoronoiExample : MonoBehaviour
    {
        private VoronoiPlane plane;
        List<VoronoiEdge> edges;

        void Start()
        {
            plane = new VoronoiPlane(0, 0, 2000, 2000);
            plane.GenerateRandomSites(100, PointGenerationMethod.Uniform); // also supports .Gaussian
            edges = plane.Tessellate(BorderEdgeGeneration.MakeBorderEdges);
            edges = plane.Relax(3, 0.7f); // relax 3 times with 70% strength each time  
        }

        private void OnDrawGizmos()
        {
            if (plane == null) return;
            if (plane.Sites == null) return;
            if (edges == null) return;

            //plane.GizmosDrawPoints();

            foreach (VoronoiEdge edge in edges)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(edge.Start.ToVector2(), edge.End.ToVector2());

                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(edge.Start.ToVector2(), 5);
                Gizmos.DrawSphere(edge.End.ToVector2(), 5);
            }
        }
    }
}