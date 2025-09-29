using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class LargestAreaTriangle
    {
        public double LargestTriangleArea(int[][] points)
        {
            double largestArea = 0;
            int nPoints = points.Length;

            if (nPoints < 3) return 0;

            points.Sort((int[] point1, int[] point2) => point1[0] == point2[0]? point1[1] - point2[1] : point1[0] - point2[0]);

            if (nPoints == 3) return Area(new Point(points[0][0], points[0][1]),
                                          new Point(points[1][0], points[1][1]),
                                          new Point(points[2][0], points[2][1]));

            for (int i = 0; i < nPoints - 2; i++)
            {
                for (int j = i+1; j < nPoints - 1; j++)
                {
                    for (int k = 0; k < nPoints; k++)
                    {
                        double area = Area(new Point(points[i][0], points[i][1]),
                                          new Point(points[j][0], points[j][1]),
                                          new Point(points[k][0], points[k][1]));

                        if (area > largestArea) largestArea = area;
                    }
                }
            }

            return largestArea;
        }

        public double Area(Point point1, Point point2, Point point3)
        {
            return 0.5 * ((point1.x * (point2.y - point3.y)) + (point2.x * (point3.y - point1.y)) + (point3.x * (point1.y - point2.y)));
        }

        public record Point(int x, int y);
    }
}
