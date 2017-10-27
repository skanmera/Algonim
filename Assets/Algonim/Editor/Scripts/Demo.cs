using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using Algonim.Drawers;
using Algonim.DrawProperties;

namespace Algonim.Editor
{
    public class Demo
    {
        [MenuItem("Algonim/Execute Demo")]
        public static void CreateTriangles()
        {
            //var points = new List<Vector3>();
            //Enumerable.Range(0, 10).ToList().ForEach(i =>
            //{
            //    var x = UnityEngine.Random.Range(-5f, 5f);
            //    var y = UnityEngine.Random.Range(-5f, 5f);

            //    var pos = new Vector3(x, y, 0);

            //    points.Add(pos);
            //});

            //var drs = new Drawer();
            //var triangles = DelaunayTriangulator.Triangulate(points);
            //foreach (var t in triangles)
            //{
            //    var triangleProp = new TriangleDrawProperty()
            //    {
            //        VertexA = t.A.Position,
            //        VertexB = t.B.Position,
            //        VertexC = t.C.Position,
            //        VertexAColor = Color.cyan,
            //        VertexBColor = Color.cyan,
            //        VertexCColor = Color.cyan,
            //        EdgeABColor = Color.green,
            //        EdgeBCColor = Color.green,
            //        EdgeCAColor = Color.green,
            //    };

            //    var triangleDrawer = new TriangleDrawer(triangleProp);
            //    triangleDrawer.BatchDraw = true;

            //    drs.Drawers.Add(triangleDrawer);
            //}

            //DrawerManager.Instance.AddDrawer("delaunay", drs);

            //return;


            //var cube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //var mesh = cube.GetComponent<MeshFilter>().sharedMesh;
            //var data = new DrawData();
            //var index = 1;
            //for (int i = 0; i < mesh.triangles.Length;)
            //{
            //    var a = mesh.vertices[mesh.triangles[i++]];
            //    var b = mesh.vertices[mesh.triangles[i++]];
            //    var c = mesh.vertices[mesh.triangles[i++]];

            //    var triangleProp = new TriangleDrawerProperty()
            //    {
            //        A = a,
            //        B = b,
            //        C = c,
            //        Color = Color.yellow,
            //        Delay = 1 * (index++),
            //    };
            //    var triangleDraer = new TriangleDrawer(triangleProp);

            //    data.Draweres.Add(triangleDraer);
            //}

            //DrawerManager.Instance.Record("test", data);



            var drawer = new Drawer();
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var mesh = cube.GetComponent<MeshFilter>().sharedMesh;

            for (int i = 0; i < mesh.triangles.Length;)
            {
                var a = mesh.vertices[mesh.triangles[i++]];
                var b = mesh.vertices[mesh.triangles[i++]];
                var c = mesh.vertices[mesh.triangles[i++]];

                var triangleProp = new TriangleDrawProperty()
                {
                    VertexA = a,
                    VertexB = b,
                    VertexC = c,
                    VertexAColor = Color.cyan,
                    VertexBColor = Color.cyan,
                    VertexCColor = Color.cyan,
                    EdgeABColor = Color.green,
                    EdgeBCColor = Color.green,
                    EdgeCAColor = Color.green,
                };

                var triangleDrawer = new TriangleDrawer(triangleProp);

                drawer.Drawers.Add(triangleDrawer);
            }

            drawer.BatchDraw = true;
            DrawerManager.Instance.AddDrawer("cube", drawer);
            GameObject.DestroyImmediate(cube);


            {
                var drawer2 = new Drawer();
                var cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var mesh2 = cube2.GetComponent<MeshFilter>().sharedMesh;

                for (int i = 0; i < mesh2.triangles.Length;)
                {
                    var a = mesh2.vertices[mesh2.triangles[i++]];
                    var b = mesh2.vertices[mesh2.triangles[i++]];
                    var c = mesh2.vertices[mesh2.triangles[i++]];

                    var triangleProp = new TriangleDrawProperty()
                    {
                        VertexA = a,
                        VertexB = b,
                        VertexC = c,
                        VertexAColor = Color.cyan,
                        VertexBColor = Color.cyan,
                        VertexCColor = Color.cyan,
                        EdgeABColor = Color.green,
                        EdgeBCColor = Color.green,
                        EdgeCAColor = Color.green,
                    };

                    var triangleDrawer = new TriangleDrawer(triangleProp);
                    triangleDrawer.BatchDraw = true;

                    drawer2.Drawers.Add(triangleDrawer);
                }

                DrawerManager.Instance.AddDrawer("cube_batch_1", drawer2);
                GameObject.DestroyImmediate(cube2);
            }

            {
                var drawer2 = new Drawer();
                var cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var mesh2 = cube2.GetComponent<MeshFilter>().sharedMesh;

                for (int i = 0; i < mesh2.triangles.Length;)
                {
                    var a = mesh2.vertices[mesh2.triangles[i++]];
                    var b = mesh2.vertices[mesh2.triangles[i++]];
                    var c = mesh2.vertices[mesh2.triangles[i++]];

                    var triangleProp = new TriangleDrawProperty()
                    {
                        VertexA = a,
                        VertexB = b,
                        VertexC = c,
                        VertexAColor = Color.cyan,
                        VertexBColor = Color.cyan,
                        VertexCColor = Color.cyan,
                        EdgeABColor = Color.green,
                        EdgeBCColor = Color.green,
                        EdgeCAColor = Color.green,
                    };

                    var triangleDrawer = new TriangleDrawer(triangleProp);
                    triangleDrawer.BatchDraw = true;

                    drawer2.Drawers.Add(triangleDrawer);
                }

                drawer2.BatchDraw = true;
                DrawerManager.Instance.AddDrawer("cube_batch_2", drawer2);
                GameObject.DestroyImmediate(cube2);
            }


var circlesDrawer = new Drawer();
for (int i = 0; i <= 36; i++)
{
    var circleDrawerProp = new CircleDrawProperty();
    circleDrawerProp.Center = UnityEngine.Vector3.zero;
    circleDrawerProp.Angle = 10 * i;
    circleDrawerProp.Color = Color.yellow;
    var d = i / 70f;
    circleDrawerProp.From = new Vector3(0.1f + d, 0.1f + d, 0.1f + d);
    circleDrawerProp.Radius = Vector3.Distance(circleDrawerProp.Center, circleDrawerProp.From);
    var vec1 = circleDrawerProp.From - circleDrawerProp.Center;
    var vec2 = new Vector3(-0.1f - d, -0.1f - d, 0.0f) - circleDrawerProp.Center;
    var normal = Vector3.Cross(vec1, vec2).normalized;
    circleDrawerProp.Normal = normal;
    var circleDrawer = new CircleDrawer(circleDrawerProp);
    circlesDrawer.Drawers.Add(circleDrawer);
}

DrawerManager.Instance.AddDrawer("circle", circlesDrawer);


            //{
            //    var drawer2 = new Drawer();
            //    var cube2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //    var mesh2 = cube2.GetComponent<MeshFilter>().sharedMesh;

            //    for (int i = 0; i < mesh2.triangles.Length;)
            //    {
            //        var a = mesh2.vertices[mesh2.triangles[i++]];
            //        var b = mesh2.vertices[mesh2.triangles[i++]];
            //        var c = mesh2.vertices[mesh2.triangles[i++]];

            //        var triangleProp = new TriangleDrawProperty()
            //        {
            //            VertexA = a,
            //            VertexB = b,
            //            VertexC = c,
            //            VertexAColor = Color.cyan,
            //            VertexBColor = Color.cyan,
            //            VertexCColor = Color.cyan,
            //            EdgeABColor = Color.green,
            //            EdgeBCColor = Color.green,
            //            EdgeCAColor = Color.green,
            //        };

            //        var triangleDrawer = new TriangleDrawer(triangleProp);

            //        drawer2.Drawers.Add(triangleDrawer);
            //    }

            //    DrawerManager.Instance.AddDrawer("cylinder", drawer2);
            //    GameObject.DestroyImmediate(cube2);
            //}

            //{
            //    var drawer2 = new Drawer();
            //    var cube2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //    var mesh2 = cube2.GetComponent<MeshFilter>().sharedMesh;

            //    for (int i = 0; i < mesh2.triangles.Length;)
            //    {
            //        var a = mesh2.vertices[mesh2.triangles[i++]];
            //        var b = mesh2.vertices[mesh2.triangles[i++]];
            //        var c = mesh2.vertices[mesh2.triangles[i++]];

            //        var triangleProp = new TriangleDrawProperty()
            //        {
            //            VertexA = a,
            //            VertexB = b,
            //            VertexC = c,
            //            VertexAColor = Color.cyan,
            //            VertexBColor = Color.cyan,
            //            VertexCColor = Color.cyan,
            //            EdgeABColor = Color.green,
            //            EdgeBCColor = Color.green,
            //            EdgeCAColor = Color.green,
            //        };

            //        var triangleDrawer = new TriangleDrawer(triangleProp);
            //        triangleDrawer.BatchDraw = true;

            //        drawer2.Drawers.Add(triangleDrawer);
            //    }

            //    drawer2.BatchDraw = true;
            //    DrawerManager.Instance.AddDrawer("sphere", drawer2);
            //    GameObject.DestroyImmediate(cube2);
            //}



            //for (int i = 0; i < 50; i++)
            //{
            //    var circleDrawerProp = new CircleDrawProperty();
            //    circleDrawerProp.Center = UnityEngine.Vector3.zero;
            //    circleDrawerProp.Angle = 280f;
            //    circleDrawerProp.Color = Color.cyan;
            //    circleDrawerProp.From = new UnityEngine.Vector3(1.0f, 1.0f, 1.0f);
            //    circleDrawerProp.Radius = UnityEngine.Vector3.Distance(circleDrawerProp.Center, circleDrawerProp.From);
            //    var vec1 = new UnityEngine.Vector3(1.0f, 1.0f, 1.0f) - circleDrawerProp.Center;
            //    var vec2 = new UnityEngine.Vector3(-1.0f, -1.0f, -0.0f) - circleDrawerProp.Center;
            //    var normal = UnityEngine.Vector3.Cross(vec1, vec2).normalized;
            //    circleDrawerProp.Normal = normal;
            //    var circleDrawer = new CircleDrawer(circleDrawerProp);
            //    DrawerManager.Instance.AddDrawer("circle" + i.ToString(), circleDrawer);
            //}
        }

        private void Delaunay()
        {

        }

    }

    public class Triangle
    {
        public Vertex A { get; private set; }
        public Vertex B { get; private set; }
        public Vertex C { get; private set; }
        public Vector3 Normal { get; private set; }
        public IEnumerable<Vertex> Vertices
        {
            get
            {
                yield return A;
                yield return B;
                yield return C;
            }
        }

        public Triangle(Vertex a, Vertex b, Vertex c)
        {
            A = a;
            B = b;
            C = c;
            Normal = Vector3.Cross(B.Position - A.Position, C.Position - A.Position).normalized;
        }

        public bool IsValid()
        {
            return !Normal.Equals(Vector3.zero);
        }

        public bool HasCommonVertex(Triangle other)
        {
            return Vertices.Except(other.Vertices).Count() == 3;
        }
    }

    public class Vertex : IEquatable<Vertex>
    {
        public int Id { get; private set; }
        public Vector3 Position { get; private set; }

        public Vertex(int id, Vector3 position)
        {
            Id = id;
            Position = position;
        }

        public bool Equals(Vertex other)
        {
            return Position.Equals(other.Position);
        }
    }

    public class TriangleComparer : IEqualityComparer<Triangle>
    {
        public bool Equals(Triangle x, Triangle y)
        {
            return
                (x.A.Equals(y.A) && x.B.Equals(y.B) && x.C.Equals(y.C)) ||
                (x.A.Equals(y.A) && x.B.Equals(y.C) && x.C.Equals(y.B)) ||
                (x.A.Equals(y.B) && x.B.Equals(y.A) && x.C.Equals(y.C)) ||
                (x.A.Equals(y.B) && x.B.Equals(y.C) && x.C.Equals(y.A)) ||
                (x.A.Equals(y.C) && x.B.Equals(y.B) && x.C.Equals(y.A)) ||
                (x.A.Equals(y.C) && x.B.Equals(y.A) && x.C.Equals(y.B));
        }

        public int GetHashCode(Triangle obj)
        {
            var hashes = new List<int>(3)
            {
                obj.A.GetHashCode(),
                obj.B.GetHashCode(),
                obj.C.GetHashCode(),
            };

            hashes.Sort();

            var hash = 17;
            hash = hash * 23 + hashes[0];
            hash = hash * 23 + hashes[1];
            hash = hash * 23 + hashes[2];

            return hash;
        }
    }

    public class Circle
    {
        public Vector3 Center { get; private set; }
        public float Radius { get; private set; }

        public Circle(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

        /// <summary>
        /// 指定した点を包含しているか
        /// </summary>
        public bool IsEncompass(Vector3 point)
        {
            return Vector3.Distance(Center, point) <= Radius;
        }
    }


    public class DelaunayTriangulator
    {
        public static List<Triangle> Triangulate(IEnumerable<Vector3> points)
        {
            // 重複を削除する
            var uniquePoints = points.Distinct();

            // 3点以上ないと分割できない
            if (uniquePoints.Count() < 3)
                return new List<Triangle>();

            // 与えられた点群をVertexクラスに変換する
            var vertices = uniquePoints.Select((v, i) => new Vertex(i, v)).ToList();

            // XY平面上に変換するため、元の座標をIDをキーにして保持しておく
            var pointMap = vertices.ToDictionary(v => v.Id, v => v.Position);

            // XY平面上に変換する
            var convertedVertices = ConvertToXYPlane(vertices).ToList();

            // 全ての点を包含する外部三角形を求める
            var externalTriangle = CreateExternalTriangle(convertedVertices);

            // 三角形のハッシュセットに外部三角形を追加する
            var triangles = new HashSet<Triangle>(new TriangleComparer());
            triangles.Add(externalTriangle);

            // 重複を調べるための一時マップ
            var tmpTriangleMap = new Dictionary<Triangle, bool>(new TriangleComparer());

            // 点を逐一追加してドロネー性を調べる
            foreach (var vertex in vertices)
            {
                // 一時マップをクリアする
                tmpTriangleMap.Clear();

                // 分割された三角形を削除する
                triangles.RemoveWhere(t => Triangulate(t, vertex, tmpTriangleMap));

                // 一時マップのうち、重複フラグが立っていないものだけ追加する
                foreach (var elem in tmpTriangleMap)
                {
                    if (!elem.Value)
                        triangles.Add(elem.Key);
                }
            }

            // 外部三角形の頂点を含む三角形を削除する
            triangles.RemoveWhere(t => externalTriangle.HasCommonVertex(t));

            // 元の平面上に復元する
            var result = RestoreVertices(triangles, pointMap).ToList();

            return result;
        }

        /// <summary>
        /// XY平面から元の平面に復元する
        /// </summary>
        private static IEnumerable<Triangle> RestoreVertices(HashSet<Triangle> triangles, Dictionary<int, Vector3> pointMap)
        {
            foreach (var triangle in triangles)
            {
                var vertices = new List<Vertex>();
                foreach (var vertex in triangle.Vertices)
                {
                    var pos = pointMap[vertex.Id];

                    vertices.Add(new Vertex(vertex.Id, pos));
                }

                yield return new Triangle(vertices[0], vertices[1], vertices[2]);
            }
        }

        /// <summary>
        /// XY平面上に変換する
        /// </summary>
        public static IEnumerable<Vertex> ConvertToXYPlane(IEnumerable<Vertex> vertices)
        {
            var origin = vertices.First().Position;
            var translation = Vector3.zero - origin;
            var normal = Vector3.Cross(vertices.ElementAt(1).Position - origin, vertices.ElementAt(2).Position - origin).normalized;
            var rotation = Quaternion.FromToRotation(normal, Vector3.forward);

            return vertices.Select(v =>
            {
                var p = rotation * (v.Position + translation);
                var pos = new Vector3(p.x, p.y, 0);

                return new Vertex(v.Id, pos);
            });
        }

        /// <summary>
        /// 追加した点で三角形を分割する
        /// </summary>
        private static bool Triangulate(Triangle triangle, Vertex vertex, Dictionary<Triangle, bool> tmpTriangleMap)
        {
            // この三角形の外接円に追加した点が包含されているか調べる
            var circle = CreateCircumscribedCircle(triangle);
            if (!circle.IsEncompass(vertex.Position))
                return false;

            // 包含されている場合は分割して一時マップに追加
            AddTriangle(new Triangle(vertex, triangle.A, triangle.B), tmpTriangleMap);
            AddTriangle(new Triangle(vertex, triangle.B, triangle.C), tmpTriangleMap);
            AddTriangle(new Triangle(vertex, triangle.C, triangle.A), tmpTriangleMap);

            return true;
        }

        /// <summary>
        /// 分割した三角形を一時マップに追加する
        /// </summary>
        private static void AddTriangle(Triangle triangle, Dictionary<Triangle, bool> tmpTriangleMap)
        {
            // 不正な三角形は追加しない
            if (!triangle.IsValid())
                return;

            if (tmpTriangleMap.ContainsKey(triangle))
            {
                // 重複して追加しようとして場合は既に追加済みの要素も削除するためフラグを立てる
                tmpTriangleMap[triangle] = true;
            }
            else
            {
                tmpTriangleMap.Add(triangle, false);
            }
        }


        /// <summary>
        /// 三角形の外接円を作成する
        /// </summary>
        private static Circle CreateCircumscribedCircle(Triangle triangle)
        {
            var x1 = triangle.A.Position.x;
            var y1 = triangle.A.Position.y;
            var x2 = triangle.B.Position.x;
            var y2 = triangle.B.Position.y;
            var x3 = triangle.C.Position.x;
            var y3 = triangle.C.Position.y;

            var c = 2.0f * ((x2 - x1) * (y3 - y1) - (y2 - y1) * (x3 - x1));
            var x = ((y3 - y1) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)
                     + (y1 - y2) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1)) / c;
            var y = ((x1 - x3) * (x2 * x2 - x1 * x1 + y2 * y2 - y1 * y1)
                     + (x2 - x1) * (x3 * x3 - x1 * x1 + y3 * y3 - y1 * y1)) / c;

            var center = new Vector3(x, y, 0);
            var radius = Vector3.Distance(center, triangle.A.Position);

            return new Circle(center, radius);
        }


        /// <summary>
        /// すべての点を包含する外部三角形を作成する
        /// </summary>
        private static Triangle CreateExternalTriangle(List<Vertex> vertices)
        {
            var maxX = vertices.FindMax(v => v.Position.x);
            var minX = vertices.FindMin(v => v.Position.x);
            var maxY = vertices.FindMax(v => v.Position.y);
            var minY = vertices.FindMin(v => v.Position.y);

            var distanceX = Vector2.Distance(maxX.Position, minX.Position);
            var distanceY = Vector2.Distance(maxY.Position, minY.Position);

            var centerX = ((maxX.Position + minX.Position) / 2).x;
            var centerY = ((maxY.Position + minY.Position) / 2).y;
            var center = new Vector2(centerX, centerY);

            var radius = distanceX > distanceY ? distanceX : distanceY;

            var x1 = center.x - Mathf.Sqrt(3) * radius;
            var y1 = center.y - radius;
            var v1 = new Vector2(x1, y1);

            var x2 = center.x + Mathf.Sqrt(3) * radius;
            var y2 = center.y - radius;
            var v2 = new Vector2(x2, y2);

            var x3 = center.x;
            var y3 = center.y + 2 * radius;
            var v3 = new Vector2(x3, y3);

            var vertex1 = new Vertex(0, v1);
            var vertex2 = new Vertex(0, v2);
            var vertex3 = new Vertex(0, v3);

            return new Triangle(vertex1, vertex2, vertex3);
        }
    }

    public static class Extension
    {
        public static TSource FindMax<TSource, TResult>(
                this IEnumerable<TSource> source,
                Func<TSource, TResult> selector)
        {
            return source
                .ToList()
                .Find(s => selector(s).Equals(source.Max(selector)));
        }

        public static TSource FindMin<TSource, TResult>(
                this IEnumerable<TSource> source,
                Func<TSource, TResult> selector)
        {
            return source
                .ToList()
                .Find(s => selector(s).Equals(source.Min(selector)));
        }
    }
}
