using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SharpVoronoiLib
{
    public static class VoronoiUnityExtensions
    {
        public static void GizmosDrawPoints(this VoronoiPlane plane)
        {
            if (plane == null) return;
            if (plane.Sites == null) return;

            foreach (VoronoiSite voronoiSite in plane.Sites)
            {
                Gizmos.color = Color.green;
                List<VoronoiPoint> points = new List<VoronoiPoint>(voronoiSite.ClockwisePoints);
                for (int i = 0; i < points.Count() - 1; i++)
                {
                    Gizmos.DrawLine(points[i].ToVector2(), points[i + 1].ToVector2());
                }

                Gizmos.DrawLine(points[points.Count - 1].ToVector2(), points[0].ToVector2());

                for (int i = 0; i < points.Count(); i++)
                {
                    Gizmos.DrawSphere(points[i].ToVector2(), 5);
                }

                Gizmos.color = Color.red;
                Gizmos.DrawSphere(voronoiSite.Position(), 5);
            }
        }

        public static Vector2 ToVector2(this VoronoiPoint voronoiPoint)
        {
            return new Vector2(System.Convert.ToSingle(voronoiPoint.X), System.Convert.ToSingle(voronoiPoint.Y));
        }

        public static Vector2 Position(this VoronoiSite voronoiSite)
        {
            return new Vector2(System.Convert.ToSingle(voronoiSite.X), System.Convert.ToSingle(voronoiSite.Y));
        }
    }
}