using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Crystallography;
using GL;
using GLU;
using WGL;
using GLSharp;

namespace CSManager
{
    public class atom
    {
        public Vector3D position;
        public Vector3D positionRatio;
        public float[] PosArray;
        public bool IsInside;
        public bool IsDraw;
        public int selectedNo = 0;
        public string element;
        public float radius;
        public List<List<int>> Pair = new List<List<int>>();
        public Material mat;
        public Position pos;
        public int colorSource;
        public float[] matSource;
        public string Label;
        public int MainID;
        public int SubID;

        public atom(Vector3D pos,Vector3D posRatio, float radius, Material mat, int colorSource, float[] matSource, string element,string label, int MainID, int SubID,bool IsInside)
        {
            this.position = pos;
            this.positionRatio = posRatio;
            this.PosArray = new float[] { (float)pos.X, (float)pos.Y, (float)pos.Z };
            this.radius = radius;
            this.IsInside = IsInside;
            this.mat = mat;
            this.pos = new Position(new float[] { (float)pos.X, (float)pos.Y, (float)pos.Z });
            this.element = element;
            this.matSource = matSource;
            this.colorSource = colorSource;
            this.Label = label;
            this.MainID = MainID;
            this.SubID = SubID;
        }
    }


    public class bond
    {
        public double[] matrix = new double[16];
        public float height;
        public float radius;
        public Material mat;
        public bool IsDraw;
        public Vector3D pos1;
        public Vector3D pos2;
        public Vector3D centroid;//重心位置
        public int ID1, ID2;
        public bool IsInside;

        public bond(Vector3D pos1, Vector3D pos2, int ID1, int ID2, float radius, float height, Material mat)
        {
            this.pos1 = pos1;
            this.pos2 = pos2;
            this.radius = radius;
            this.height = height;
            this.mat = mat;
            this.ID1 = ID1;
            this.ID2 = ID2;
            this.centroid = (pos1 + pos2) / 2;
            this.matrix = bond.GetMatrix(pos1, pos2);
        }

        public static double[] GetMatrix(Vector3D v1, Vector3D v2)
        {
            double x1 = v1.X, y1 = v1.Y, z1 = v1.Z;
            double x2 = v2.X, y2 = v2.Y, z2 = v2.Z;
            double x, y, z, A, B, C;
            x = (x2 - x1);
            y = (y2 - y1);
            z = (z2 - z1);
            B = Math.Sqrt(1 / (x * x + y * y + z * z));
            C = Math.Sqrt((x * x + y * y) / (x * x + y * y + z * z));
            if ((x * x + y * y) / z / z < 0.00000000000000001)
                return new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, x1, y1, z1, 1 };
            else
            {
                A = Math.Sqrt(1 / (x * x + y * y));
                return new double[] { -A * y, A * x, 0, 0, -A * B * x * z, -A * B * y * z, C, 0, A * C * x, A * C * y, B * z, 0, x1, y1, z1, 1 };
            }
        }
    }


    public class polyhedron
    {
        public List<float[][]> vertexList;
        public List<Vector3D> vertexCentroid;
        public List<float[]> normal;
        public Material planeMat;
        public float edgeLineWidth;
        public Color lineColor;
        public bool IsDraw;
        public int centerID;
        public Vector3D centerPos;
        public List<int> vertexIDs;

        public polyhedron(int centerID, Vector3D centerPos, List<int> vertexIDs, List<Vector3D> vertexPos, Material planeMat, float edgeLineWidth, Color lineColor)
        {
            this.planeMat = planeMat;
            this.edgeLineWidth = edgeLineWidth;
            this.lineColor = lineColor;
            this.centerID = centerID;
            this.centerPos = centerPos;
            this.vertexIDs = vertexIDs;
            IsDraw = true;
            SetVertexPolygon(vertexPos);
        }

        private void SetVertexPolygon(List<Vector3D> V)
        {
            this.vertexList = new List<float[][]>();
            this.normal = new List<float[]>();
            for (int v1 = 0; v1 < V.Count; v1++)
                for (int v2 = v1 + 1; v2 < V.Count; v2++)
                    for (int v3 = v2 + 1; v3 < V.Count; v3++)
                    {
                        Vector3D vP = Vector3D.VectorProduct(V[v1] - V[v2], V[v2] - V[v3]);//外積を計算

                        double s = vP * V[v2];// vP のX,Y,Z成分を a,b,c, としたとき a x + by + c z = sという平面である。
                        int count = 0;
                        for (int i = 0; i < V.Count; i++)
                            if (i != v1 && i != v2 && i != v3)
                                count = (vP * V[i] / s < 1) ? count + 1 : count - 1;
                        if (Math.Abs(count) == V.Count - 3)
                        {
                            if (count * s > 0)
                            {
                                this.vertexList.Add(new float[][] { V[v1].ToSingle(), V[v2].ToSingle(), V[v3].ToSingle() });
                                this.normal.Add(vP.ToSingle());
                            }
                            else
                            {
                                this.vertexList.Add(new float[][] { V[v1].ToSingle(), V[v3].ToSingle(), V[v2].ToSingle() });
                                this.normal.Add((-vP).ToSingle());
                            }
                        }
                    }
            //近すぎるnormalがチェック
            for (int i = 0; i < normal.Count; i++)
                for (int j = i + 1; j < normal.Count; j++)
                    if (Vector3D.AngleBetVectors(new Vector3D(normal[i]), new Vector3D(normal[j])) < 1.0 / 180.0 * Math.PI)
                        IsDraw = false;
        }
    }

    public class polyhedronPlane
    {
        public Material mat;
        public float[][] VertexPos;
        public float[] Normal;
        public Vector3D Centroid;
        public bool IsDraw;
        public polyhedronPlane(Material mat, float[][] pos, float[] normal, bool IsDraw)
        {
            this.mat = mat;
            this.VertexPos = pos;
            this.Normal = normal;
            this.IsDraw = IsDraw;
            Centroid = new Vector3D(0,0,0,false);
            for (int i = 0; i < pos.GetLength(0); i++)
                Centroid += new Vector3D(pos[i][0], pos[i][1], pos[i][2],false);
            Centroid /= pos.GetLength(0);
        }
    }

    public class polyhedronEdge
    {
        public float[] color;
        public float lineWidth;
        public float[][] pos;
        public Vector3D centroid;
        public bool IsDraw;
        public polyhedronEdge(float[] color, float lineWidth, float[][] pos, bool IsDraw)
        {
            this.color = color;
            this.lineWidth = lineWidth;
            this.pos = pos;
            this.IsDraw = IsDraw;
            centroid = new Vector3D((pos[0][0] + pos[1][0])/2, (pos[0][1] + pos[1][1])/2, (pos[0][2] + pos[1][2])/2, false);
        }
    }

    public class cellPlane
    {
        public Material mat;
        public float[][] pos;
        public float[] normal;
        public Vector3D centroid;
        public bool IsDraw;
        public cellPlane(Material mat, float[][] pos, float[] normal, bool IsDraw)
        {
            this.mat = mat;
            this.pos = pos;
            this.normal = normal;
            this.IsDraw = IsDraw;
            centroid = new Vector3D(0,0,0,false);
            for (int i = 0; i < pos.GetLength(0); i++)
                centroid += new Vector3D(pos[i][0], pos[i][1], pos[i][2],false);
            centroid /= pos.GetLength(0);
        }
    }

    public class cellEdge
    {
        public float[] color;
        public float lineWidth;
        public float[][] pos;
        public Vector3D centroid;
        public bool IsDraw;
        public cellEdge(float[] color, float lineWidth, float[][] pos, bool IsDraw)
        {
            this.color = color;
            this.lineWidth = lineWidth;
            this.pos = pos;
            this.IsDraw = IsDraw;
            centroid = new Vector3D((pos[0][0] + pos[1][0]) / 2, (pos[0][1] + pos[1][1]) / 2, (pos[0][2] + pos[1][2]) / 2, false);
        }
    }

    public class latticePlane
    {
        public Material mat;
        public float[][] pos;
        public float[] normal;
        public Vector3D centroid;
        public bool IsDraw;
        public latticePlane(Material mat, float[][] pos, float[] normal, bool IsDraw)
        {
            this.mat = mat;
            this.pos = pos;
            this.normal = normal;
            this.IsDraw = IsDraw;
            centroid = new Vector3D(0, 0, 0, false);
            //for (int i = 0; i < pos.GetLength(0); i++)
            //    centroid += new Vector3D(pos[i][0], pos[i][1], pos[i][2], false);
            //centroid /= pos.GetLength(0);
            centroid = new Vector3D(pos[0][0], pos[0][1], pos[0][2], false);
        }
    }

    public class latticeEdge
    {
        public float[] color;
        public float lineWidth;
        public float[][] pos;
        public Vector3D centroid;
        public bool IsDraw;
        public latticeEdge(float[] color, float lineWidth, float[][] pos, bool IsDraw)
        {
            this.color = color;
            this.lineWidth = lineWidth;
            this.pos = pos;
            this.IsDraw = IsDraw;
            centroid = new Vector3D((pos[0][0] + pos[1][0]) / 2, (pos[0][1] + pos[1][1]) / 2, (pos[0][2] + pos[1][2]) / 2, false);
        }
    }

    enum ObjectType
    {
        Plane,
        Line,
        Sphere,
        Cylinder
    }

    class sort : System.IComparable
    {
        public object o;
        public double z;
        public Type type;
        public ObjectType t;
        public Material mat;
        //public Position pos;
        public float[] spherePos;
        public double[] matrix;
        public float[][] planePos;
        public float[][] linePos;
        public float[] color;
        public float[] normal;
        public float lineWidth;
        public float radius;
        public int selectedNo;
        public float height;

        public sort(object o)
        {
            this.o = o;
            z = 0;
        }

        public sort(object o, double[] m)
        {
            this.o = o;
            
            Vector3D v = new Vector3D(0, 0, 0, false);
            this.type = o.GetType();

            if (type.Equals(typeof(atom)))
            {
                t = ObjectType.Sphere;
                v = ((atom)o).position;
                mat = ((atom)o).mat;
                //pos = ((atom)o).pos;
                spherePos = ((atom)o).PosArray;
                radius = ((atom)o).radius;
                selectedNo = ((atom)o).selectedNo;
            }

            else if (type.Equals(typeof(bond)))
            {
                t = ObjectType.Cylinder;
                v = ((bond)o).centroid;
                radius = ((bond)o).radius;
                mat = ((bond)o).mat;
                matrix = ((bond)o).matrix;
                height = ((bond)o).height;
            }
            else if (type.Equals(typeof(polyhedronPlane)))
            {
                t = ObjectType.Plane;
                v = ((polyhedronPlane)o).Centroid;
                mat = ((polyhedronPlane)o).mat;
                planePos = ((polyhedronPlane)o).VertexPos;
                normal = ((polyhedronPlane)o).Normal;
            }
            else if (type.Equals(typeof(polyhedronEdge)))
            {
                t = ObjectType.Line;
                v = ((polyhedronEdge)o).centroid;
                color = ((polyhedronEdge)o).color;
                linePos = ((polyhedronEdge)o).pos;
                lineWidth = ((polyhedronEdge)o).lineWidth;
                
            }
            else if (type.Equals(typeof(cellPlane)))
            {
                t = ObjectType.Plane;
                v = ((cellPlane)o).centroid;
                mat = ((cellPlane)o).mat;
                planePos = ((cellPlane)o).pos;
                normal = ((cellPlane)o).normal;

            }
            else if (type.Equals(typeof(cellEdge)))
            {
                t = ObjectType.Line;
                v = ((cellEdge)o).centroid;
                color = ((cellEdge)o).color;
                linePos = ((cellEdge)o).pos;
                lineWidth = ((cellEdge)o).lineWidth;

            }
            else if (type.Equals(typeof(latticePlane)))
            {
                t = ObjectType.Plane;
                v = ((latticePlane)o).centroid;
                mat = ((latticePlane)o).mat;
                planePos = ((latticePlane)o).pos;
                normal = ((latticePlane)o).normal;

            }
            else if (type.Equals(typeof(latticeEdge)))
            {
                t = ObjectType.Line;
                v = ((latticeEdge)o).centroid;
                color = ((latticeEdge)o).color;
                linePos = ((latticeEdge)o).pos;
                lineWidth = ((latticeEdge)o).lineWidth;

            }

            z = m[0] * v.X + m[1] * v.Y + m[2] * v.Z;
        }
        
        public int CompareTo(object obj)
        {
            return z.CompareTo(((sort)obj).z);
        }
    }

}
