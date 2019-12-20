using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Crystallography;
using GL;
using GLU;
using WGL;
using GLSharp;

namespace CSManager
{
    public partial class FormStructureViewer : Form
    {
        #region フィールド
        
        int slices;

        RenderingContext contextMain = null;

        RenderingContext contextLight = null;

        RenderingContext contextAxes = null;

        BitmapFontLabel[] labelAxis;
        BitmapFontLabel[] labelAtom;

        DisplayList DisplayListMain=null;

        Vector3D CellTranslation=new Vector3D();

        public List<atom> atoms = new List<atom>();
        public List<bond> bonds = new List<bond>();
        public List<polyhedron> polyhedra = new List<polyhedron>();
        
        public List<polyhedronPlane> polyhedraPlane = new List<polyhedronPlane>();
        public List<polyhedronEdge> polyhedraEdge = new List<polyhedronEdge>();
        
        public List<cellPlane> cellPlane = new List<cellPlane>();
        public List<cellEdge> cellEdge = new List<cellEdge>();

        public List<latticePlane> latticePlane = new List<latticePlane>();
        public List<latticeEdge> latticeEdge = new List<latticeEdge>();

        private double[] matrixModel = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
        private double[] matrixLight = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
        private double OrthoZoom = 20;
        private double CamPosZ = 40;
        private double aspect = 1;
        public Crystal crystal;

        public FormMain formMain;
        FormAtom formAtom;

        private sort[] AtomAndBond, PolyhedronAndEdge, UnitCell, LatticePlane;
        IntPtr obj = glu.NewQuadric();

        #endregion フィールド

        /// <summary>
        /// 結晶構造をセッティング
        /// </summary>
        /// <param name="_crystal"></param>
        public void SetCrystal(Crystal _crystal)
        {
            if (_crystal == null) return;
            crystal = _crystal;

            selectedAtomCount = 0;

            //まず大きめに原子を検索・設定する
            Vector3D Min = new Vector3D((double)numericUpDownMinA.Value, (double)numericUpDownMinB.Value, (double)numericUpDownMinC.Value);
            Vector3D Max = new Vector3D((double)numericUpDownMaxA.Value, (double)numericUpDownMaxB.Value, (double)numericUpDownMaxC.Value);
            Vector3D tempMin = new Vector3D((double)numericUpDownMinA.Value - 1, (double)numericUpDownMinB.Value - 1, (double)numericUpDownMinC.Value - 1);
            Vector3D tempMax = new Vector3D((double)numericUpDownMaxA.Value + 1, (double)numericUpDownMaxB.Value + 1, (double)numericUpDownMaxC.Value + 1);
            atoms = new List<atom>();
            for (int i = 0; i < crystal.atoms.Length; i++)
            {
                Material mat = new Material("Material Sample", crystal.atoms[i].color, crystal.atoms[i].transparency, crystal.atoms[i].ambient,
                       crystal.atoms[i].diffusion, crystal.atoms[i].specular, crystal.atoms[i].emission, crystal.atoms[i].shininess);
                
                int colorSource = crystal.atoms[i].color.ToArgb();
                float[] matSource = new float[] { crystal.atoms[i].transparency, crystal.atoms[i].ambient, crystal.atoms[i].diffusion, 
                    crystal.atoms[i].specular, crystal.atoms[i].emission, crystal.atoms[i].shininess };

                for (int j = 0; j < crystal.atoms[i].atom.Count; j++)
                {
                    Vector3D v = new Vector3D(crystal.atoms[i].atom[j].X, crystal.atoms[i].atom[j].Y, crystal.atoms[i].atom[j].Z, false);
                    for (int x = (int)tempMin.X - 1; x <= (int)tempMax.X + 1; x++)
                        for (int y = (int)tempMin.Y - 1; y <= (int)tempMax.Y + 1; y++)
                            for (int z = (int)tempMin.Z - 1; z <= (int)tempMax.Z + 1; z++)
                            {
                                Vector3D vTemp = v + new Vector3D(x, y, z, false);
                                if (tempMin <= vTemp && vTemp <= tempMax)
                                {
                                    atoms.Add(new atom((crystal.aAxisOriginal * vTemp.X + crystal.bAxisOriginal * vTemp.Y + crystal.cAxisOriginal * vTemp.Z) * 10,
                                        vTemp, crystal.atoms[i].radius, mat, colorSource, matSource, crystal.atoms[i].element, crystal.atoms[i].label, i, j, (Min <= vTemp && vTemp <= Max)));
                                    atoms[atoms.Count - 1].IsDraw = Min <= vTemp && vTemp <= Max;
                                }
                            }
                }
            }

            //bondを検索
            bonds = new List<bond>();
            for (int i = 0; crystal.bonds != null && i < crystal.bonds.Count; i++)
            {
                Material mat = new Material("bond", crystal.bonds[i].BondColor, (float)crystal.bonds[i].BondTransParency, 0.1f, 0.8f, 1.0f, 0f, 50f);
                for (int j = 0; j < atoms.Count; j++)
                    atoms[j].Pair.Add(new List<int>());
                for (int j = 0; j < atoms.Count; j++)
                    if (atoms[j].element == crystal.bonds[i].Element1)
                        for (int k = 0; k < atoms.Count; k++)
                            if (atoms[k].element == crystal.bonds[i].Element2)//elementに一致したとき
                                if (atoms[j].element != atoms[k].element || (atoms[j].element == atoms[j].element && j < k))
                                {
                                    double length = (atoms[j].position - atoms[k].position).Length2();
                                    if (length < crystal.bonds[i].MaxLength * crystal.bonds[i].MaxLength && crystal.bonds[i].MinLength * crystal.bonds[i].MinLength < length)//長さが適正のとき
                                        if (atoms[j].IsInside || atoms[k].IsInside)//どちらかが描画範囲内であれば
                                        {
                                            atoms[j].Pair[i].Add(k);
                                            atoms[k].Pair[i].Add(j);
                                            atoms[j].IsDraw = atoms[k].IsDraw = true;
                                            bonds.Add(new bond(new Vector3D(atoms[j].PosArray), new Vector3D(atoms[k].PosArray),
                                                j, k, (float)crystal.bonds[i].Radius, (float)Math.Sqrt((float)length), mat));
                                            bonds[bonds.Count - 1].IsDraw = true;
                                            bonds[bonds.Count - 1].IsInside = (atoms[j].IsInside && atoms[k].IsInside);
                                        }
                                }
            }

            polyhedra = new List<polyhedron>();
            //PolyHedraを検索する
            for (int i = 0; crystal.bonds != null && i < crystal.bonds.Count; i++)
                if (crystal.bonds[i].ShowPolyhedron)
                {
                    Material Mat = new Material("polyhedra", crystal.bonds[i].PolyhedronColor, (float)crystal.bonds[i].PolyhedronTransParency, 0.1f, 0.8f, 1.0f, 0f, 50f);
                    if (crystal.bonds[i].ShowPolyhedron)
                        for (int j = 0; j < atoms.Count; j++)
                            if (atoms[j].element == crystal.bonds[i].Element1 && atoms[j].Pair[i].Count >= 4)//4回以上現れるIDでCenter
                            {
                                List<Vector3D> vertexPos = new List<Vector3D>();
                                for (int k = 0; k < atoms[j].Pair[i].Count; k++)
                                    vertexPos.Add(new Vector3D(atoms[atoms[j].Pair[i][k]].PosArray));

                                polyhedra.Add(new polyhedron(j, new Vector3D(atoms[j].PosArray), atoms[j].Pair[i], vertexPos,
                                    Mat, crystal.bonds[i].ShowEdges ? (float)crystal.bonds[i].EdgeLineWidth : 0, crystal.bonds[i].EdgeColor));

                                if (polyhedra[polyhedra.Count - 1].IsDraw)//多面体として成立したとき
                                {
                                    if (!crystal.bonds[i].ShowInnerBonds)//多面体内部のBondを表示しないとき
                                        for (int l = 0; l < bonds.Count; l++)
                                            if (bonds[l].ID1 == j)//bondsのID1がjと一致するものを検索して
                                                for (int k = 0; k < atoms[j].Pair[i].Count; k++)
                                                    if (bonds[l].ID2 == atoms[j].Pair[i][k])//さらにID2が一致したとき
                                                        bonds[l].IsDraw = false;

                                    if (!crystal.bonds[i].ShowVertexAtom)//多面体の頂点原子を表示しないとき
                                        for (int k = 0; k < atoms[j].Pair[i].Count; k++)
                                            atoms[atoms[j].Pair[i][k]].IsDraw = false;

                                    if (!crystal.bonds[i].ShowCenterAtom)//多面体の中心原子を表示しないとき
                                        atoms[j].IsDraw = false;

                                }
                                else//多面体が不完全だったらAtom,Bondを消去する
                                {
                                    for (int l = 0; l < bonds.Count; l++)
                                        if (bonds[l].ID1 == j)//bondsのID1がjと一致するものを検索して
                                            for (int k = 0; k < atoms[j].Pair[i].Count; k++)
                                                if (bonds[i].ID2 == atoms[j].Pair[i][k])//さらにID2が一致したとき
                                                    bonds[i].IsDraw = false; ;
                                    for (int k = 0; k < atoms[j].Pair[i].Count; k++)
                                        atoms[atoms[j].Pair[i][k]].IsDraw = false;
                                    atoms[j].IsDraw = false;
                                }
                            }
                }
            
            //polyhedraPlaneを設定
            polyhedraPlane=new List<polyhedronPlane>();
            for (int i = 0; i < polyhedra.Count; i++)
                if (polyhedra[i].IsDraw)
                    for(int j = 0; j<polyhedra[i].vertexList.Count ;j++)
                        polyhedraPlane.Add(new polyhedronPlane(polyhedra[i].planeMat,polyhedra[i].vertexList[j],polyhedra[i].normal[j],true));
            
            //polyhedraEdgeを設定
            polyhedraEdge = new List<polyhedronEdge>();
            for (int i = 0; i < polyhedra.Count; i++)
                if (polyhedra[i].IsDraw && polyhedra[i].edgeLineWidth > 0)
                {
                    //2回描画しないように重なりをチェックしながら追加
                    for(int j = 0; j<polyhedra[i].vertexList.Count ;j++)
                    {
                        for (int k = 0; k < polyhedra[i].vertexList[j].GetLength(0); k++)
                        {
                            float[][] pos = k == polyhedra[i].vertexList[j].GetLength(0) - 1 ?
                                new float[][] { polyhedra[i].vertexList[j][k], polyhedra[i].vertexList[j][0] } :
                                new float[][] { polyhedra[i].vertexList[j][k], polyhedra[i].vertexList[j][k + 1] };
                            bool flag = true;
                            foreach (polyhedronEdge p in polyhedraEdge)
                                if ((p.pos[0][0] == pos[0][0] && p.pos[0][1] == pos[0][1] && p.pos[0][2] == pos[0][2]
                                    && p.pos[1][0] == pos[1][0] && p.pos[1][1] == pos[1][1] && p.pos[1][2] == pos[1][2]) ||
                                    (p.pos[1][0] == pos[0][0] && p.pos[1][1] == pos[0][1] && p.pos[1][2] == pos[0][2]
                                    && p.pos[0][0] == pos[1][0] && p.pos[0][1] == pos[1][1] && p.pos[0][2] == pos[1][2]))
                                    flag = false;

                            if (flag)
                                polyhedraEdge.Add(new polyhedronEdge(
                                    new float[] { polyhedra[i].lineColor.R / (float)256, polyhedra[i].lineColor.G / (float)256, polyhedra[i].lineColor.B / (float)256 },
                                    (float)polyhedra[i].edgeLineWidth, pos, true));
                        }
                    }
                }
            for (int i = 0; i < polyhedra.Count; i++)
                if (!polyhedra[i].IsDraw)
                    polyhedra.RemoveAt(i--);
            
            //最後にbondを構成したためにIsDrawになったもののPolyhedraには寄与できなかったBondと原子を削除する
            //まず余分なBondを削除
            for (int i = 0; i < bonds.Count; i++)
                if (!bonds[i].IsInside && bonds[i].IsDraw)//範囲外にあるのに描くBondsを検索
                {
                    bonds[i].IsDraw = false;//いったんfalseにして
                    for (int j = 0; j < polyhedra.Count && bonds[i].IsDraw == false; j++)
                        //Polyhedoronを構成するBondであるならばそのままIsDrawはTrue
                        if (polyhedra[j].IsDraw)
                            if ((bonds[i].ID1 == polyhedra[j].centerID && polyhedra[j].vertexIDs.Contains(bonds[i].ID2)))
                                bonds[i].IsDraw = true;
                }
            for (int i = 0; i < bonds.Count; i++)
                if (!bonds[i].IsDraw)
                    bonds.RemoveAt(i--);

            //次に余分な原子を削除
            for (int i = 0; i < atoms.Count; i++)
                if (!atoms[i].IsInside && atoms[i].IsDraw)//範囲外にあるのに描くAtomを検索
                {
                    atoms[i].IsDraw = false;
                    for (int j = 0; j < polyhedra.Count && atoms[i].IsDraw == false; j++)
                        if (polyhedra[j].IsDraw)
                            //Polyhedoronを構成するBondであるならばそのままIsDrawはTrue
                            if (i == polyhedra[j].centerID || polyhedra[j].vertexIDs.Contains(i))
                                atoms[i].IsDraw = true;
                }
            for (int i = 0; i < atoms.Count; i++)
                if(!atoms[i].IsDraw)
                    atoms.RemoveAt(i--);

            SetUnitCellProperty();
            SetLatticePlaneProperty();

            Draw();
        }

        /// <summary>
        /// 単位格子のセッティング
        /// </summary>
        private void SetUnitCellProperty()
        {
            if (crystal == null) return;
            Vector3D CellA_Axis = crystal.aAxisOriginal * 10;
            Vector3D CellB_Axis = crystal.bAxisOriginal * 10;
            Vector3D CellC_Axis = crystal.cAxisOriginal * 10;

            CellTranslation =
                (double)numericUpDownCellTransrationA.Value * CellA_Axis +
                (double)numericUpDownCellTransrationB.Value * CellB_Axis +
                (double)numericUpDownCellTransrationC.Value * CellC_Axis;
            CellA_Axis /= 2;
            CellB_Axis /= 2;
            CellC_Axis /= 2;

            Vector3D[] CellVector = new Vector3D[] { CellA_Axis + CellB_Axis + CellC_Axis, CellA_Axis - CellB_Axis + CellC_Axis, CellA_Axis + CellB_Axis - CellC_Axis, CellA_Axis - CellB_Axis - CellC_Axis, -CellA_Axis + CellB_Axis + CellC_Axis, -CellA_Axis - CellB_Axis + CellC_Axis, -CellA_Axis + CellB_Axis - CellC_Axis, -CellA_Axis - CellB_Axis - CellC_Axis };
            float[][][] CellQuad = new float[][][]{
                    new float[][] { CellVector[0].ToSingle(), CellVector[2].ToSingle(), CellVector[3].ToSingle(), CellVector[1].ToSingle() },
                    new float[][] { CellVector[1].ToSingle(), CellVector[3].ToSingle(), CellVector[7].ToSingle(), CellVector[5].ToSingle() },
                    new float[][] { CellVector[5].ToSingle(), CellVector[7].ToSingle(), CellVector[6].ToSingle(), CellVector[4].ToSingle() },
                    new float[][] { CellVector[4].ToSingle(), CellVector[6].ToSingle(), CellVector[2].ToSingle(), CellVector[0].ToSingle() },
                    new float[][] { CellVector[5].ToSingle(), CellVector[4].ToSingle(), CellVector[0].ToSingle(), CellVector[1].ToSingle() },
                    new float[][] { CellVector[3].ToSingle(), CellVector[2].ToSingle(), CellVector[6].ToSingle(), CellVector[7].ToSingle() }
                    };
            float[][] CellNormal = new float[][] { 
                    Vector3D.VectorProduct(-CellC_Axis,-CellB_Axis).ToSingle(),
                    Vector3D.VectorProduct(-CellA_Axis,CellC_Axis).ToSingle(),
                    Vector3D.VectorProduct(CellB_Axis,CellC_Axis).ToSingle(),
                    Vector3D.VectorProduct(-CellC_Axis,CellA_Axis).ToSingle(),
                    Vector3D.VectorProduct(CellB_Axis,CellA_Axis).ToSingle(),
                    Vector3D.VectorProduct(-CellA_Axis,-CellB_Axis).ToSingle()
                    };

            Material planeMat = new Material("", pictureBoxCellPlaneColor.BackColor, (float)numericUpDownCellPlaneAlpha.Value, 0.1f, 0.8f, 1.0f, 0f, 50f);
            cellPlane = new List<cellPlane>();
            for (int i = 0; i < 6; i++)
                if (checkBoxUnitCell.Checked && checkBoxCellShowPlane.Checked)
                    cellPlane.Add(new cellPlane(planeMat, CellQuad[i], CellNormal[i], true));

            //Edgeを設定
            cellEdge = new List<cellEdge>();
            float[] color = new float[] { pictureBoxCellEdgeColor.BackColor.R / (float)256, pictureBoxCellEdgeColor.BackColor.G / (float)256, pictureBoxCellEdgeColor.BackColor.B / (float)256 };
            float width = (float)numericUpDownCellEdgeLineWidth.Value;
            if (checkBoxUnitCell.Checked && checkBoxCellShowEdge.Checked)
            {
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[0].ToSingle(), CellVector[2].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[2].ToSingle(), CellVector[3].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[3].ToSingle(), CellVector[1].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[1].ToSingle(), CellVector[0].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[1].ToSingle(), CellVector[5].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[3].ToSingle(), CellVector[7].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[7].ToSingle(), CellVector[5].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[6].ToSingle(), CellVector[7].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[4].ToSingle(), CellVector[5].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[4].ToSingle(), CellVector[0].ToSingle() }, true));
                cellEdge.Add(new cellEdge(color, width, new float[][] { CellVector[2].ToSingle(), CellVector[6].ToSingle() }, true));
            }
        }

        /// <summary>
        /// 格子面の計算をしてセッティング
        /// </summary>
        public void SetLatticePlaneProperty()
        {
            latticePlane = new List<latticePlane>();
            latticeEdge = new List<latticeEdge>();
            if (crystal == null) return;
            if (checkBoxLatticePlane.Checked==false) return;

            //まずhkl面の基本ベクトルを取得
            int h = (int)numericUpDownLatticePlaneH.Value;
            int k = (int)numericUpDownLatticePlaneK.Value;
            int l = (int)numericUpDownLatticePlaneL.Value;
            if (h == 0 && k == 0 && l == 0) return;

            double translation = (double)numericUpDownLatticePlaneTranslation.Value;

            double[] xRange = new double[] { (double)numericUpDownMinA.Value - 0.2, (double)numericUpDownMaxA.Value + 0.2 };
            double[] yRange = new double[] { (double)numericUpDownMinB.Value - 0.2, (double)numericUpDownMaxB.Value + 0.2 };
            double[] zRange = new double[] { (double)numericUpDownMinC.Value - 0.2, (double)numericUpDownMaxC.Value + 0.2 };

            List<List<Vector3D>> crossPoint = new List<List<Vector3D>>();

            int iMin = (int)(Math.Min(h * xRange[0], h * xRange[1]) + Math.Min(k * yRange[0], k * yRange[1]) + Math.Min(l * zRange[0], l * zRange[1]) - Math.Abs(translation) - 1);
            int iMax = (int)(Math.Max(h * xRange[0], h * xRange[1]) + Math.Max(k * yRange[0], k * yRange[1]) + Math.Max(l * zRange[0], l * zRange[1]) + Math.Abs(translation) + 1);
            for (int i = iMin; i <= iMax; i++)
            {
                crossPoint.Add(new List<Vector3D>());
                double R = i + translation;
                for (int n = 0; n < 2; n++)
                    for (int m = 0; m < 2; m++)
                    {
                        if (h != 0)
                        {
                            double x = (R - k * yRange[n] - l * zRange[m]) / h;
                            if (xRange[0] <= x && x <= xRange[1])
                                crossPoint[crossPoint.Count - 1].Add(new Vector3D(x, yRange[n], zRange[m], false));
                        }
                        if (k != 0)
                        {
                            double y = (R - h * xRange[n] - l * zRange[m]) / k;
                            if (yRange[0] <= y && y <= yRange[1])
                                crossPoint[crossPoint.Count - 1].Add(new Vector3D(xRange[n], y, zRange[m], false));
                        }
                        if (l != 0)
                        {
                            double z = (R - h * xRange[n] - k * yRange[m]) / l;
                            if (zRange[0] <= z && z <= zRange[1])
                                crossPoint[crossPoint.Count - 1].Add(new Vector3D(xRange[n], yRange[m], z, false));
                        }
                    }
            }

            for (int i = 0; i < crossPoint.Count; i++)
            {
                for (int j = 0; j < crossPoint[i].Count; j++)
                    for (int p = j + 1; p < crossPoint[i].Count; p++)
                        if (((Vector3D)(crossPoint[i][j] - crossPoint[i][p])).Length() < 0.0000000001)
                            crossPoint[i].RemoveAt(p--);
                if (crossPoint[i].Count == 0)
                    crossPoint.RemoveAt(i--);
            }

            
            Vector3D v1 = new Vector3D(0, 0, 0, false), v2 = new Vector3D(0, 0, 0, false);
            Material mat = new Material("", pictureBoxLatticePlaneColor.BackColor, (float)numericUpDownLatticePlaneAlpha.Value, 0.1f, 0.8f, 1.0f, 0f, 50f);
            float width = 1;
            float[] color = new float[] { pictureBoxLatticePlaneColor.BackColor.R / (float)256, pictureBoxLatticePlaneColor.BackColor.G / (float)256, pictureBoxLatticePlaneColor.BackColor.B / (float)256 };
            Matrix3D matrix = Matrix3D.Inverse(new Matrix3D(crystal.aAxisOriginal * 10, crystal.bAxisOriginal * 10, crystal.cAxisOriginal * 10));
            Vector3D normal = h * (new Vector3D(matrix.E11, matrix.E12, matrix.E13, false)) + k * (new Vector3D(matrix.E21, matrix.E22, matrix.E23, false)) + l * (new Vector3D(matrix.E31, matrix.E32, matrix.E33, false));

            for (int i = 0; i < crossPoint.Count; i++)
            {
                //交点の並び順が時計回りになるように設定

                //0を固定し、1番以降の順番を入れ替えていく
                List<int> z = new List<int>();
                for (int m = 1; m < crossPoint[i].Count; m++)
                    z.Add(m);
                List<List<int>> index = GenArray(z);
                for (int m = 0; m < index.Count; m++)
                {
                    index[m].Insert(0, 0);
                    index[m].Add(index[m][0]);
                }

                Vector3D center = new Vector3D(0, 0, 0, false);
                for (int n = 0; n < crossPoint[i].Count; n++)
                    center += crossPoint[i][n];
                center = center / crossPoint[i].Count;

                int j = -1;
                double MinimumTotalLength = double.PositiveInfinity;
                for (int m = 0; m < index.Count; m++)
                {
                    bool flag = true;
                    double totalLength = 0;
                    for (int n = 0; n < crossPoint[i].Count; n++)
                    {
                        v1 = crossPoint[i][index[m][n]] - center;
                        v2 = crossPoint[i][index[m][n + 1]] - center;
                        if (Vector3D.VectorProduct(v1, v2) * new Vector3D(h, k, l, false) > 0)
                        {
                            flag = false;
                            break;
                        }
                        else
                            totalLength += ((Vector3D)(crossPoint[i][index[m][n + 1]] - crossPoint[i][index[m][n]])).Length2();
                    }
                    if (flag && totalLength < MinimumTotalLength)
                    {
                        MinimumTotalLength = totalLength;
                        j = m;   
                    }
                }
                //交点の並びかえ終了
                if (j >= 0 && j < index.Count)
                {
                    for (int n = 0; n < crossPoint[i].Count; n++)
                        crossPoint[i][n] = (crossPoint[i][n].X * crystal.aAxisOriginal + crossPoint[i][n].Y * crystal.bAxisOriginal + crossPoint[i][n].Z * crystal.cAxisOriginal) * 10;

                    center = (center.X * crystal.aAxisOriginal + center.Y * crystal.bAxisOriginal + center.Z * crystal.cAxisOriginal) * 10;

                    for (int n = 0; n < crossPoint[i].Count; n++)
                    {
                        latticePlane.Add(new latticePlane(mat,
                            new float[][] { center.ToSingle(), crossPoint[i][index[j][n]].ToSingle(), crossPoint[i][index[j][n + 1]].ToSingle() },
                            normal.ToSingle(), true));

                        latticeEdge.Add(new latticeEdge(color, width,
                            new float[][] { crossPoint[i][index[j][n]].ToSingle(), crossPoint[i][index[j][n + 1]].ToSingle() }, true));
                    }
                }
            }
        }

        /// <summary>
        /// 引数Zに対するすべての順列を返す
        /// </summary>
        /// <param name="Z"></param>
        /// <returns></returns>
        public List<List<int>> GenArray(List<int> Z)
        {
            List<List<int>> list= new List<List<int>>();
            if (Z.Count == 1)
            {
                List<int> l = new List<int>();
                l.Add(Z[0]);
                list.Add(l);
                return list;
            }
            for (int i = 0; i < Z.Count; i++)
            {
                List<int> z = new List<int>();;
                for (int j = 0; j < Z.Count; j++)
                    if (i != j)
                        z.Add(Z[j]);
                List<List<int>> l = GenArray(z);
                for (int j = 0; j < l.Count; j++)
                {
                    l[j].Insert(0, Z[i]);
                    list.Add(l[j]);
                }
            }
            return list;
        }

        public void SetMisc()
        {
            SetUnitCellProperty();
            SetLatticePlaneProperty();
            Draw();
        }

        #region コンストラクタ


        public FormStructureViewer()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            // OpenGLレンダリングコンテキストの作成・初期化
            contextMain = new RenderingContext(this.panelMain);
            BitmapFontGlyphDictionary BitmapFontGlyphDictionaryMain = new BitmapFontGlyphDictionary(contextMain.HDC);
            labelAtom = new BitmapFontLabel[]{
                new BitmapFontLabel("1", new Font("Tahoma", 14f, FontStyle.Bold),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryMain),
                 new BitmapFontLabel("2", new Font("Tahoma", 14f, FontStyle.Bold),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryMain),
                 new BitmapFontLabel("3", new Font("Tahoma", 14f, FontStyle.Bold),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryMain)};
            InitGL();
            SetProjectionMain();

            contextLight = new RenderingContext(this.panelLight);
            contextLight.MakeCurrent();
            InitGL();
            SetProjectionLight();
            
            
            contextAxes = new RenderingContext(this.panelAxes);
            contextAxes.MakeCurrent();
            BitmapFontGlyphDictionary BitmapFontGlyphDictionaryAxes = new BitmapFontGlyphDictionary(contextAxes.HDC);
            labelAxis = new BitmapFontLabel[]{
                new BitmapFontLabel("a", new Font("Tahoma", 14f, FontStyle.Italic),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryAxes),
                new BitmapFontLabel("b", new Font("Tahoma", 14f, FontStyle.Italic),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryAxes),
                 new BitmapFontLabel("c", new Font("Tahoma", 14f, FontStyle.Italic),TextLayout.Right,0f,0f,BitmapFontGlyphDictionaryAxes)};
            InitGL();
            SetProjectionLight();

            formAtom = new FormAtom();
            formAtom.formStructureViewer = this;
            this.AddOwnedForm(formAtom);

            this.MouseWheel += new MouseEventHandler(panelMain_MouseMove);

        }

        #endregion コンストラクタ

        #region InitGL
        /// <summary>
        /// 初期設定など。
        /// </summary>
        public void InitGL()
        {
            gl.ClearColor(1f, 1f, 1f, 1f);//画面クリア時に使用する色（背景色）を指定。

            gl.Enable(EnableCapability.DEPTH_TEST);
            gl.DepthFunc(DepthFunction.LESS);

            //陰面消去設定
            //gl.Enable( EnableCapability.CULL_FACE );
            //gl.CullFace( CullFaceMode.BACK );

            //アルファブレンディング設定
            gl.Enable(EnableCapability.BLEND);
            gl.BlendFunc(BlendingFactorSrc.SRC_ALPHA, BlendingFactorDest.ONE_MINUS_SRC_ALPHA);

            //ライティングの設定
            gl.LightModelLocalViewer = true;
            gl.LightModelTwoSide = true;
        }
        #endregion InitGL

        #region SetProjection プロジェクション行列の設定を行う。

        /// <summary>
        /// プロジェクション行列の設定を行う。
        /// </summary>
        public void SetProjectionMain()
        {
            aspect = (double)panelMain.ClientRectangle.Width / (double)panelMain.ClientRectangle.Height;
            gl.MatrixMode(MatrixMode.PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, panelMain.ClientRectangle.Width, panelMain.ClientRectangle.Height);
            if (radioButtonOrtho.Checked)
                gl.Ortho(-OrthoZoom * aspect, OrthoZoom * aspect, -OrthoZoom, OrthoZoom, -2000, 2000);
            else if (radioButtonperspective.Checked)
                glu.Perspective(trackBarPerspective.Value, aspect, 1, 2000);
        }

        public void SetProjectionLight()
        {
            double aspectLight = (double)panelLight.ClientRectangle.Width / (double)panelLight.ClientRectangle.Height;
            gl.MatrixMode(MatrixMode.PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, panelLight.ClientRectangle.Width, panelLight.ClientRectangle.Height);
            gl.Ortho(-aspectLight, aspectLight, -1, 1, -2000, 2000);
        }

        public void SetProjectionAxes(double width)
        {
            double aspectAxes = (double)panelAxes.ClientRectangle.Width / (double)panelAxes.ClientRectangle.Height;
            gl.MatrixMode(MatrixMode.PROJECTION);
            gl.LoadIdentity();
            gl.Viewport(0, 0, panelAxes.ClientRectangle.Width, panelAxes.ClientRectangle.Height);
            gl.Ortho(-aspectAxes * width, aspectAxes * width, -width, width, -2000, 2000);
        }


        #endregion SetProjection

        #region Draw

        /// <summary>
        /// OpenGLによる描画を行う。
        /// </summary>
        public void Draw()
        {
            Draw(true);
        }

        public void Draw(bool IsReNewList)
        {
            if (IsReNewList)
                slices = (int)numericUpDownStacks.Value;
            else if ((int)numericUpDownStacks.Value == slices)
            {
                slices = (int)numericUpDownStacks.Value / 2;
                IsReNewList = true;
            }

            if (IsReNewList)
            {
                contextMain.MakeCurrent();
                double[] m = new double[] { matrixModel[2], matrixModel[6], matrixModel[10] };
                
                //原子とボンド
                List<sort> s = new List<sort>();
                for (int i = 0; i < atoms.Count; i++)
                    if (atoms[i].IsDraw)
                        s.Add(new sort(atoms[i], m));
                for (int i = 0; i < bonds.Count; i++)
                    if (bonds[i].IsDraw)
                        s.Add(new sort(bonds[i], m));
                s.Sort();
                AtomAndBond = s.ToArray();
                
                //多面体の面と稜
                s.Clear();
                for (int i = 0; i < polyhedraPlane.Count; i++)
                    if (polyhedraPlane[i].IsDraw)
                        s.Add(new sort(polyhedraPlane[i], m));
                for (int i = 0; i < polyhedraEdge.Count; i++)
                    if (polyhedraEdge[i].IsDraw)
                        s.Add(new sort(polyhedraEdge[i], m));
                s.Sort();
                PolyhedronAndEdge = s.ToArray();
                
                //単位格子の面と稜
                s.Clear();
                for (int i = 0; i < cellPlane.Count; i++)
                    if (cellPlane[i].IsDraw)
                        s.Add(new sort(cellPlane[i], m));
                s.Sort();
                for (int i = 0; i < cellEdge.Count; i++)
                    if (cellEdge[i].IsDraw)
                        s.Insert(0, new sort(cellEdge[i], m));
                UnitCell = s.ToArray();

                //格子面の面と稜
                s.Clear();
                for (int i = 0; i < latticePlane.Count; i++)
                    if (latticePlane[i].IsDraw)
                        s.Add(new sort(latticePlane[i], m));
                s.Sort();
                for (int i = 0; i < latticeEdge.Count; i++)
                    if (latticeEdge[i].IsDraw)
                        s.Insert(0, new sort(latticeEdge[i], m));
                LatticePlane = s.ToArray();
                if(DisplayListMain!=null)
                    DisplayListMain.Dispose();
                DisplayListMain = GenerateDisplayListMain();
                GC.Collect();
            }
            
            DrawLightBall();
            
            DrawAxes();

            DrawMain();
        }

        //光源位置を表示する部分
        public void DrawLightBall()
        {
            //base.OnPaint(e);
            if (contextLight == null) return;
            contextLight.MakeCurrent();
            SetProjectionLight();
            // 描画前の設定など
            gl.Clear(ClearBufferMask.COLOR_BUFFER_BIT | ClearBufferMask.DEPTH_BUFFER_BIT);//バッファのクリア
            
            gl.MatrixMode(MatrixMode.MODELVIEW);
            gl.LoadIdentity();

            //カメラの位置と向きを適用
            glu.LookAt(0, 0, CamPosZ, 0, 0, 0, 0, 1, 0);
            
            //ライティングの設定を適用
            gl.MultMatrix(GetNormarize(matrixLight));
            gl.LightingEnabled = true;
            gl.Enable(EnableCapability.LIGHTING);
            gl.Light(LightName.LIGHT0, LightParameter.POSITION, new float[] { 0f, 0f, 1f, 0f });
            gl.Enable(EnableCapability.LIGHT0);

            new Material("", Color.Gray, 1, 0.3f, 0.1f, 1.0f, 0.2f, 30f).ApplyMaterials();
            
            gl.Begin(BeginMode.POLYGON);
            glu.QuadricNormals(obj, QuadricNormal.SMOOTH);//法線の設定
            glu.QuadricDrawStyle(obj, QuadricDrawStyle.FILL);//オブジェクトの描画タイプを設定（省略可）
            glu.Sphere(obj, 0.90, 40, 40);//球を描画 
            gl.End();

            gl.Finish();
            contextLight.SwapBuffers();
        }

        //軸の情報を表示する部分
        public void DrawAxes()
        {
            if (crystal == null) return;
            //base.OnPaint(e);
            if (contextAxes == null) return;
            contextAxes.MakeCurrent();
            double maxLength = 1.3 * Math.Max(Math.Max(crystal.a, crystal.b), crystal.c); 
            SetProjectionAxes(maxLength);
            // 描画前の設定など
            gl.Clear(ClearBufferMask.COLOR_BUFFER_BIT | ClearBufferMask.DEPTH_BUFFER_BIT);//バッファのクリア
            
            gl.MatrixMode(MatrixMode.MODELVIEW);
            gl.LoadIdentity();

            //カメラの位置と向きを適用
            //gl.LoadMatrix(matrixView);
            glu.LookAt(0, 0, CamPosZ, 0, 0, 0, 0, 1, 0);


            //ライティングの設定を適用
            gl.PushMatrix();
            gl.MultMatrix(GetNormarize(matrixLight));
            gl.LightingEnabled = true;
            gl.Enable(EnableCapability.LIGHTING);
            gl.Light(LightName.LIGHT0, LightParameter.POSITION, new float[] { 0f, 0f, 1f, 0f });
            gl.Enable(EnableCapability.LIGHT0);
            gl.PopMatrix();
            
            gl.MultMatrix(GetNormarize(matrixModel));

            bond bond;

            Color[] color = new Color[] { Color.Red, Color.Green, Color.Blue };
            double[] height = new double[] { crystal.a, crystal.b, crystal.c };
            Vector3D[] vector = new Vector3D[] { crystal.aAxisOriginal, crystal.bAxisOriginal, crystal.cAxisOriginal };
            for (int i = 0; i < 3; i++)
            {
                gl.PushMatrix();
                bond = new bond(new Vector3D(0, 0, 0), vector[i], 0, 0, 0, 0, new Material("", color[i], 1));
                bond.mat.ApplyMaterials();
                gl.MultMatrix(bond.matrix);

                gl.PushMatrix();
                gl.Translate(0, 0, -height[i] );
                gl.Begin(BeginMode.POLYGON);
                glu.QuadricNormals(obj, QuadricNormal.SMOOTH);//法線の設定
                glu.QuadricDrawStyle(obj, QuadricDrawStyle.FILL);//オブジェクトの描画タイプを設定（省略可）
                glu.Cylinder(obj, 0.05 * maxLength, 0.05 * maxLength, height[i] * 1.5, 30, 30);
                glu.Disk(obj, 0, 0.05 * maxLength, 30, 30);
                gl.End();
                gl.PopMatrix();

                gl.PushMatrix();
                gl.Translate(0, 0, height[i]/2.0);
                gl.Begin(BeginMode.POLYGON);
                glu.Cylinder(obj, 0.15 * maxLength, 0, height[i] / 2.0, 20, 20);
                glu.Disk(obj, 0, 0.15 * maxLength, 30, 30);
                gl.End();
                gl.PopMatrix();

                gl.PushMatrix();
                gl.Translate(0, 0, height[i]*1.2);
                gl.Disable(EnableCapability.LIGHTING);
                gl.RasterPos2(0, 0);
                labelAxis[i].Draw();
                gl.Enable(EnableCapability.LIGHTING);
                gl.PopMatrix();

                gl.PopMatrix();
            }

            gl.Finish();
            contextAxes.SwapBuffers();
        }

        //メインの結晶構造を表示する部分
        public void DrawMain()
        {
            if (contextMain == null) return;
            contextMain.MakeCurrent();
            SetProjectionMain();
            // 描画前の設定など
            gl.Clear(ClearBufferMask.COLOR_BUFFER_BIT | ClearBufferMask.DEPTH_BUFFER_BIT);//バッファのクリア
            gl.MatrixMode(MatrixMode.MODELVIEW);
            gl.LoadIdentity();//モデルビュー変換行列のリセット
            gl.Enable(EnableCapability.NORMALIZE);//法線ベクトルを規格化

            //カメラの位置と向きを適用
            glu.LookAt(0, 0, CamPosZ, 0, 0, 0, 0, 1, 0);
            
            //ライティングの設定を適用
            gl.PushMatrix();
            gl.MultMatrix(GetNormarize(matrixLight));
            gl.LightingEnabled = true;
            gl.Enable(EnableCapability.LIGHTING);
            gl.Light(LightName.LIGHT0, LightParameter.POSITION, new float[] { 0f, 0f, 1f, 0f });
            gl.Enable(EnableCapability.LIGHT0);
            gl.PopMatrix();

            gl.PushMatrix();
            gl.MultMatrix(matrixModel);
            //ディスプレイリストを呼び出して描画
            DisplayListMain.CallList();
            gl.PopMatrix();

            gl.Finish();
            contextMain.SwapBuffers();

           


        }

        private double[] GetNormarize(double[] m)
        {
            return new double[] { m[0], m[1], m[2], 0, m[4], m[5], m[6], 0, m[8], m[9], m[10], 0, 0, 0, 0, 1 };
        }
        #endregion Draw

        #region その他イベント
        private void FormStructureViewer_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Draw();
        }

        private void panel_Resize(object sender, EventArgs e)
        {
            this.SetProjectionMain();

            this.Draw();
        }
        private void FormStructureViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonStructureViewer.Checked = false;
        }

        #endregion

        #region マウスイベント



        Point lastPosMain = new Point();
        Point lastPosLight = new Point();
        Point lastPosAxes = new Point();

        /// <summary>
        /// マウス移動イベント。
        /// マウスドラッグで視点（＝カメラの位置）を移動する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > tabControl1.Width || e.Y > tabControl1.Height - 20)
                panel1.BringToFront();
            
            float dx = e.X - lastPosMain.X, dy = lastPosMain.Y - e.Y;

            if (e.Button == MouseButtons.Middle)
            {
                gl.MatrixMode(MatrixMode.MODELVIEW);
                gl.LoadMatrix(matrixModel);
                if (dx != 0)
                    gl.Translate(matrixModel[0] * dx * 0.06f, matrixModel[4] * dx * 0.06f, matrixModel[8] * dx * 0.06f);
                if (dy != 0)
                    gl.Translate(matrixModel[1] * dy * 0.06f, matrixModel[5] * dy * 0.06f, matrixModel[9] * dy * 0.06f);
                gl.CurrentModelviewMatrixDouble.CopyTo(matrixModel, 0);
                this.Draw(false);//counter % 10 == 0);
            }
            else if (e.Button == MouseButtons.Left)
            {
                gl.MatrixMode(MatrixMode.MODELVIEW);
                gl.LoadMatrix(matrixModel);
                double[] m = gl.CurrentModelviewMatrixDouble;

                double x = e.X - panelMain.Width / 2.0;
                double y = e.Y - panelMain.Height / 2.0;
                double r = Math.Min(panelMain.Width / 2.0, panelMain.Height / 2.0);

                if (r * r * 0.7 > x * x + y * y)
                {
                    if (dx != 0)
                        gl.Rotate(dx, m[1], m[5], m[9]);
                    if (dy != 0)
                        gl.Rotate(-dy, m[0], m[4], m[8]);
                }
                else
                {
                    double lastx = lastPosMain.X - panelMain.Width / 2.0;
                    double lasty = lastPosMain.Y - panelMain.Height / 2.0;
                    double angle = (Math.Atan2(x, y) - Math.Atan2(lastx, lasty)) / Math.PI * 180;
                    gl.Rotate(angle, m[2], m[6], m[10]);
                }

                gl.CurrentModelviewMatrixDouble.CopyTo(matrixModel, 0);
                this.Draw(false);//counter % 10 == 0);
            }
            else if (e.Button == MouseButtons.Right || e.Delta != 0)
            {
                if (e.Delta > 0)
                    dy = 40;
                else if (e.Delta < 0)
                    dy = -40;

                OrthoZoom *= (1 + dy * 0.005);

                if (radioButtonOrtho.Checked)
                {
                    gl.MatrixMode(MatrixMode.PROJECTION);
                    gl.LoadIdentity();
                    gl.Ortho(-OrthoZoom * aspect, OrthoZoom * aspect, -OrthoZoom, OrthoZoom, -2000, 2000);
                    gl.MatrixMode(MatrixMode.MODELVIEW);
                }
                else
                {
                    CamPosZ = OrthoZoom / Math.Tan(trackBarPerspective.Value / 2.0 / 180 * Math.PI);
                }
                this.Draw(false);//counter % 10 == 0);
            }
            lastPosMain = e.Location;
        }

        private void panelAxes_MouseMove(object sender, MouseEventArgs e)
        {
            float dx = e.X - lastPosAxes.X, dy = lastPosAxes.Y - e.Y;
            if (e.Button == MouseButtons.Left)
            {
                gl.MatrixMode(MatrixMode.MODELVIEW);
                gl.LoadIdentity();


                gl.LoadMatrix(matrixModel);
                double[] m = gl.CurrentModelviewMatrixDouble;
                if (dx != 0)
                    gl.Rotate(dx, m[1], m[5], m[9]);
                if (dy != 0)
                    gl.Rotate(-dy, m[0], m[4], m[8]);
                gl.CurrentModelviewMatrixDouble.CopyTo(matrixModel, 0);
                this.Draw(false);//counter % 10 == 0);
            }
            lastPosAxes = e.Location;
        }

        private void panelLight_MouseMove(object sender, MouseEventArgs e)
        {
            float dx = e.X - lastPosLight.X, dy = lastPosLight.Y - e.Y;

            if (e.Button == MouseButtons.Left)
            {
                gl.MatrixMode(MatrixMode.MODELVIEW);
                gl.LoadMatrix(matrixLight);
                double[] m = gl.CurrentModelviewMatrixDouble;

                if (dx != 0)
                    gl.Rotate(dx, m[1], m[5], m[9]);
                if (dy != 0)
                    gl.Rotate(-dy, m[0], m[4], m[8]);
                gl.CurrentModelviewMatrixDouble.CopyTo(matrixLight, 0);
                this.Draw(false);//counter % 10 == 0);
            }
            lastPosLight = e.Location;
        }
       
        int selectedAtomCount = 0;
        /// <summary>
        /// ピクチャーボックスをクリックしたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMain_MouseDown(object sender, MouseEventArgs e)
        {
            panelMain.Select();
            Vector3D mouse = new Vector3D((double)e.X * 2 / panelMain.ClientSize.Width - 1, 1 - (double)e.Y * 2.0 / panelMain.ClientSize.Height, 0);
            contextMain.MakeCurrent();
            SetProjectionMain();
            gl.MatrixMode(MatrixMode.PROJECTION);
            Crystallography.Matrix projection = new Crystallography.Matrix(gl.CurrentProjectionMatrixDouble, 4, 4);
            gl.MatrixMode(MatrixMode.MODELVIEW);
            gl.LoadIdentity();
            glu.LookAt(0, 0, CamPosZ, 0, 0, 0, 0, 1, 0);
            gl.MultMatrix(matrixModel);
            Crystallography.Matrix modeling = new Crystallography.Matrix(gl.CurrentModelviewMatrixDouble, 4, 4);
            Crystallography.Matrix matrix = projection * modeling;

            if ((e.Button == MouseButtons.Left && e.Clicks == 2) || (e.Button == MouseButtons.Right && e.Clicks == 1))
            {
                double[] A = BoudaryTest(matrix.E, mouse.X, mouse.Y);
                int selectedAtom = -1;
                double selectedAtomZ = double.PositiveInfinity;
                for (int i = atoms.Count - 1; i >= 0; i--)
                    if (atoms[i].IsDraw)
                    {
                        double Ax = atoms[i].position.X, Ay = atoms[i].position.Y, Az = atoms[i].position.Z;
                        double z = (matrix * new Crystallography.Matrix(new double[] { Ax, Ay, Az, 1 }, 4, 1)).E[2, 0]; ;
                        if (selectedAtomZ > z)
                        {
                            double[] a = new double[] { Ax * Ax, Ay * Ay, Az * Az, Ax * Ay, Ay * Az, Az * Ax, Ax, Ay, Az };
                            if (atoms[i].radius * atoms[i].radius > a[0] * A[0] + a[1] * A[1] + a[2] * A[2] + a[3] * A[3] + a[4] * A[4] + a[5] * A[5] + a[6] * A[6] + a[7] * A[7] + a[8] * A[8] + A[9])
                            {
                                selectedAtom = i;
                                selectedAtomZ = z;
                            }
                        }
                    }
                if (e.Button == MouseButtons.Left && selectedAtom < 0)
                {
                    for (int i = atoms.Count - 1; i >= 0; i--)
                        atoms[i].selectedNo = 0;
                    selectedAtomCount = 0;
                }
                else if (e.Button == MouseButtons.Left && selectedAtom >= 0 && atoms[selectedAtom].selectedNo != 0)
                {
                    int n = 0;
                    if (atoms[selectedAtom].selectedNo == 1)
                        for (int i = atoms.Count - 1; i >= 0 && n < 2; i--)
                        {
                            if (atoms[i].selectedNo == 2) { atoms[i].selectedNo = 1; n++; }
                            else if (atoms[i].selectedNo == 3) { atoms[i].selectedNo = 2; n++; }
                        }
                    if (atoms[selectedAtom].selectedNo == 2)
                        for (int i = atoms.Count - 1; i >= 0; i--)
                            if (atoms[i].selectedNo == 3) { atoms[i].selectedNo = 2; break; }
                    atoms[selectedAtom].selectedNo = 0;
                    selectedAtomCount--;
                }
                else if (e.Button == MouseButtons.Left && selectedAtom >= 0 && atoms[selectedAtom].selectedNo == 0)
                {
                    selectedAtomCount++;
                    if (selectedAtomCount == 4)
                    {
                        for (int i = atoms.Count - 1; i >= 0; i--)
                            atoms[i].selectedNo = 0;
                        selectedAtomCount = 1;
                        atoms[selectedAtom].selectedNo = 1;
                    }
                    else
                        atoms[selectedAtom].selectedNo = selectedAtomCount;
                }
                else if (e.Button == MouseButtons.Right && selectedAtom >= 0 && atoms[selectedAtom].selectedNo != 0)
                {
                    formAtom.SkipChange = true;
                    formAtom.Location = new Point(this.Location.X + panel1.Location.X + e.X + 20, this.Location.Y + panel1.Location.Y + e.Y + 50);
                    formAtom.StartPosition = FormStartPosition.Manual;
                    formAtom.pictureBoxAtomColor.BackColor = Color.FromArgb(atoms[selectedAtom].colorSource);
                    formAtom.numericUpDownAtomTransparency.Value = (decimal)atoms[selectedAtom].matSource[0];
                    formAtom.numericUpDownAtomAmbient.Value = (decimal)atoms[selectedAtom].matSource[1];
                    formAtom.numericUpDownAtomDiffusion.Value = (decimal)atoms[selectedAtom].matSource[2];
                    formAtom.numericUpDownAtomSpecular.Value = (decimal)atoms[selectedAtom].matSource[3];
                    formAtom.numericUpDownAtomEmmision.Value = (decimal)atoms[selectedAtom].matSource[4];
                    formAtom.numericUpDownAtomShininess.Value = (decimal)atoms[selectedAtom].matSource[5];
                    formAtom.numericUpDownAtomRadius.Value = (decimal)atoms[selectedAtom].radius;
                    formAtom.selectedAtom = selectedAtom;
                    formAtom.checkBoxIsDraw.Checked = atoms[selectedAtom].IsDraw;
                    formAtom.SkipChange = false;
                    formAtom.SetOriginal();
                    formAtom.ShowDialog();
                }

                textBoxInformation.Text = "";
                if (selectedAtomCount > 0)
                {
                    atom[] a = new atom[3];
                    string str = "";
                    int[] list = new int[] { 0, 0, 0 };
                    for (int i = atoms.Count - 1; i >= 0; i--)
                        if (atoms[i].selectedNo == 1) a[0] = atoms[i];
                        else if (atoms[i].selectedNo == 2) a[1] = atoms[i];
                        else if (atoms[i].selectedNo == 3) a[2] = atoms[i];
                    if (a[0] != null)
                        str += "Atom 1:  " + "label: " + a[0].Label + "  element: " + a[0].element + "  ID: " + a[0].MainID.ToString() + "-" + a[0].SubID.ToString() +
                        "  Pos.: " + "(" + a[0].position.X.ToString("f3") + "," + a[0].position.Y.ToString("f3") + "," + a[0].position.Z.ToString("f3") + ")[Å] " +
                        "(" + a[0].positionRatio.X.ToString("f3") + "," + a[0].positionRatio.Y.ToString("f3") + "," + a[0].positionRatio.Z.ToString("f3") + ")[Cell]\r\n";
                    if (a[1] != null)
                        str += "Atom 2:  " + "label: " + a[1].Label + "  element: " + a[1].element + "  ID: " + a[1].MainID.ToString() + "-" + a[1].SubID.ToString() +
                        "  Pos.: " + "(" + a[1].position.X.ToString("f3") + "," + a[1].position.Y.ToString("f3") + "," + a[1].position.Z.ToString("f3") + ")[Å] " +
                        "(" + a[1].positionRatio.X.ToString("f3") + "," + a[1].positionRatio.Y.ToString("f3") + "," + a[1].positionRatio.Z.ToString("f3") + ")[Cell]\r\n";
                    if (a[2] != null)
                        str += "Atom 3:  " + "label: " + a[2].Label + "  element: " + a[2].element + "  ID: " + a[2].MainID.ToString() + "-" + a[2].SubID.ToString() +
                        "  Pos.: " + "(" + a[2].position.X.ToString("f3") + "," + a[2].position.Y.ToString("f3") + "," + a[2].position.Z.ToString("f3") + ")[Å] " +
                        "(" + a[2].positionRatio.X.ToString("f3") + "," + a[2].positionRatio.Y.ToString("f3") + "," + a[2].positionRatio.Z.ToString("f3") + ")[Cell]\r\n";

                    if (a[2] != null)
                    {
                        str += "Distance[Å]:" +
                            "     Atom 1-2:  " + ((Vector3D)(a[0].position - a[1].position)).Length().ToString("f4") +
                            "     Atom 2-3:  " + ((Vector3D)(a[1].position - a[2].position)).Length().ToString("f4") +
                            "     Atom 3-1:  " + ((Vector3D)(a[2].position - a[0].position)).Length().ToString("f4") + "\r\n";
                        str += "Angle[°]:" +
                            "     Atom 1-2-3:  " + (Vector3D.AngleBetVectors(a[0].position - a[1].position, a[2].position - a[1].position) / Math.PI * 180).ToString("f4") +
                            "     Atom 2-3-1:  " + (Vector3D.AngleBetVectors(a[1].position - a[2].position, a[0].position - a[2].position) / Math.PI * 180).ToString("f4") +
                            "     Atom 3-1-2:  " + (Vector3D.AngleBetVectors(a[2].position - a[0].position, a[1].position - a[0].position) / Math.PI * 180).ToString("f4");
                    }
                    else if (a[1] != null)
                        str += "Distance[Å]:" + "     Atom 1 to 2:  " + ((Vector3D)(a[0].position - a[1].position)).Length().ToString("f4") + "\r\n";

                    textBoxInformation.Text = str;
                }
                Draw();
            }
        }

        #endregion イベント

        #region 結晶構造を描く部分

        /// <summary>
        /// 結晶構造を描くディスプレイリストを作成する。
        /// </summary>
        /// <returns></returns>
        private DisplayList GenerateDisplayListMain()
        {
            DisplayList dl = new DisplayList("mat");
            dl.NewList(ListMode.COMPILE);
            for (int i = 0; i < AtomAndBond.Length; i++)
            {
                //原子を描画するとき
                if (AtomAndBond[i].t == ObjectType.Sphere)
                {
                    gl.PushMatrix();
                    AtomAndBond[i].mat.ApplyMaterials();
                    gl.Translate(AtomAndBond[i].spherePos);
                    gl.Begin(BeginMode.POLYGON);
                    glu.QuadricNormals(obj, QuadricNormal.SMOOTH);//法線の設定
                    glu.QuadricDrawStyle(obj, QuadricDrawStyle.FILL);//オブジェクトの描画タイプを設定（省略可）
                    glu.Sphere(obj, AtomAndBond[i].radius, slices, slices);//球を描画 
                    if (AtomAndBond[i].selectedNo != 0)
                    {
                        new Material("", Color.White, 0.8f).ApplyMaterials();
                        glu.QuadricDrawStyle(obj, QuadricDrawStyle.LINE);

                        glu.Sphere(obj, AtomAndBond[i].radius * 1.1, (int)(numericUpDownStacks.Value / 2), (int)(numericUpDownStacks.Value / 2));//球を描画 
                        new Material("", Color.Black, 0.8f).ApplyMaterials();
                        gl.Disable(EnableCapability.LIGHTING);
                        gl.Disable(EnableCapability.DEPTH_TEST);
                        gl.RasterPos2(0, 0);
                        labelAtom[AtomAndBond[i].selectedNo - 1].Draw();
                        gl.Enable(EnableCapability.DEPTH_TEST);
                        gl.Enable(EnableCapability.LIGHTING);
                    }
                    gl.End();
                    gl.PopMatrix();
                }
                //Bondを描画するとき
                else if (AtomAndBond[i].t == ObjectType.Cylinder)
                {
                    gl.PushMatrix();
                    AtomAndBond[i].mat.ApplyMaterials();
                    gl.MultMatrix(AtomAndBond[i].matrix);
                    gl.Begin(BeginMode.POLYGON);
                    glu.QuadricNormals(obj, QuadricNormal.SMOOTH);//法線の設定
                    glu.QuadricDrawStyle(obj, QuadricDrawStyle.FILL);//オブジェクトの描画タイプを設定（省略可）
                    glu.Cylinder(obj, AtomAndBond[i].radius, AtomAndBond[i].radius, AtomAndBond[i].height, slices, slices);
                    gl.End();
                    gl.PopMatrix();
                }
            }

            for (int i = 0; i < PolyhedronAndEdge.Length; i++)
            {
                //多面体を描画するとき
                if (PolyhedronAndEdge[i].t == ObjectType.Plane)
                {
                    PolyhedronAndEdge[i].mat.ApplyMaterials();
                    gl.Begin(BeginMode.TRIANGLE_STRIP);
                    gl.Normal(PolyhedronAndEdge[i].normal);
                    for (int k = 0; k < 3; k++)
                        gl.Vertex3(PolyhedronAndEdge[i].planePos[k]);
                    gl.End();
                }
                //多面体の稜を描画するとき
                else if (PolyhedronAndEdge[i].t == ObjectType.Line)
                {
                    gl.Disable(EnableCapability.LIGHTING);
                    gl.Color3(PolyhedronAndEdge[i].color);
                    gl.LineWidth(PolyhedronAndEdge[i].lineWidth);
                    gl.Begin(BeginMode.LINES);
                    for (int k = 0; k < 2; k++)
                        gl.Vertex3(PolyhedronAndEdge[i].linePos[k]);
                    gl.End();
                    gl.Enable(EnableCapability.LIGHTING);
                }
            }


            //ここからUnitCellを描画
            gl.PushMatrix();
            gl.Translate(CellTranslation.X, CellTranslation.Y, CellTranslation.Z);
            for (int i = 0; i < UnitCell.Length; i++)
            {
                if (UnitCell[i].t == ObjectType.Plane)
                {
                    UnitCell[i].mat.ApplyMaterials();
                    gl.Begin(BeginMode.QUADS);
                    gl.Normal(UnitCell[i].normal);
                    for (int j = 0; j < 4; j++)
                        gl.Vertex3(UnitCell[i].planePos[j]);
                    gl.End();
                }
                else if (UnitCell[i].t == ObjectType.Line)//エッジを書くとき
                {
                    gl.Disable(EnableCapability.LIGHTING);
                    gl.Color3(UnitCell[i].color);
                    gl.LineWidth(UnitCell[i].lineWidth);
                    gl.Begin(BeginMode.LINES);
                    for (int j = 0; j < 2; j++)
                        gl.Vertex3(UnitCell[i].linePos[j]);
                    gl.End();
                    gl.Enable(EnableCapability.LIGHTING);
                }
            }
            gl.PopMatrix();

            //ここからLatticePlaneを描画
            for (int i = 0; i < LatticePlane.Length; i++)
            {
                if (LatticePlane[i].t == ObjectType.Plane)
                {
                    LatticePlane[i].mat.ApplyMaterials();
                    gl.Begin(BeginMode.TRIANGLES);
                    gl.Normal(LatticePlane[i].normal);
                    for (int j = 0; j < 3; j++)
                        gl.Vertex3(LatticePlane[i].planePos[j]);
                    gl.End();
                }
                else if (LatticePlane[i].t== ObjectType.Line)//エッジを書くとき
                {
                    gl.Disable(EnableCapability.LIGHTING);
                    gl.Color3(LatticePlane[i].color);
                    gl.LineWidth(LatticePlane[i].lineWidth);
                    gl.Begin(BeginMode.LINES);
                    for (int j = 0; j < 2; j++)
                        gl.Vertex3(LatticePlane[i].linePos[j]);
                    gl.End();
                    gl.Enable(EnableCapability.LIGHTING);
                }
            }

            dl.EndList();
            return dl;
        }
        #endregion 結晶構造を描く部分

        private void numericUpDownMinA_ValueChanged(object sender, EventArgs e)
        {
            SetCrystal(crystal);
        }

        private void radioButtonOrtho_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonOrtho.Checked)
                trackBarPerspective.Enabled = false;
            else
            {
                CamPosZ = OrthoZoom / Math.Tan(trackBarPerspective.Value / 2.0 / 180 * Math.PI);
                trackBarPerspective.Enabled = true;
            }
            Draw();
        }

        private void trackBarPerspective_Scroll(object sender, EventArgs e)
        {
            CamPosZ = OrthoZoom / Math.Tan(trackBarPerspective.Value / 2.0 / 180 * Math.PI);
            Draw();
        }

        private void checkBoxShowUnitCell_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxShowUnitCell.Enabled = checkBoxUnitCell.Checked;
            SetMisc();
        }

        private void pictureBoxColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = ((PictureBox)sender).BackColor;
            colorDialog.AllowFullOpen = true; colorDialog.AnyColor = true; colorDialog.SolidColorOnly = false; colorDialog.ShowHelp = true;
            colorDialog.ShowDialog();
            ((PictureBox)sender).BackColor = colorDialog.Color;
            SetMisc();
        }

        private void FormStructureViewer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                if (formMain.crystalForm.presentCrystal != null)
                    SetCrystal(formMain.crystalForm.presentCrystal);
        }

        #region イメージ保存
        /// <summary>
        /// イメージを保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Picture File[*.png]|*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                if (!filename.EndsWith(".png"))
                    filename += ".png";
                FormResolution formResolution = new FormResolution();
                if (formResolution.ShowDialog() == DialogResult.OK)
                {
                    int width = (int)formResolution.numericUpDownWidth.Value;
                    int height = (int)formResolution.numericUpDownHeight.Value;
                    int widthNum = (width % panelMain.ClientSize.Width == 0 || width < panelMain.ClientSize.Width) 
                        ? width / panelMain.Width : width / panelMain.Width + 1;
                    int heightNum = (height % panelMain.ClientSize.Height == 0 || height < panelMain.ClientSize.Height) 
                        ? height / panelMain.Height : height / panelMain.Height + 1;
                    
                    Size originalSize = panelMain.ClientSize;
                    panelMain.ClientSize = new Size(width, height);
                    
                    Bitmap bmp = new Bitmap(width,height);
                    Graphics g = Graphics.FromImage(bmp);

                    WaitDlg d = new WaitDlg();
                    d.Text = "Now saving image ....";
                    d.progressBar.Maximum = widthNum * heightNum;
                    d.Show(this);
                    d.Location = new Point(this.Location.X, this.Location.Y);
                    for(int w = 0 ; w < widthNum ; w++)
                        for (int h = 0; h < heightNum; h++)
                        {
                            d.progressBar.Value += 1;
                            panelMain.Location = new Point(-originalSize.Width * w,- originalSize.Height * h);
                            Draw(true);
                            Bitmap srcbmp = new Bitmap(1,1);
                            if (h == heightNum - 1)
                            {
                                srcbmp =
                                    GLSharp.Capture.CaptureBufferAsBitmapRGBA(ReadBufferMode.FRONT,
                                    originalSize.Width * w, 0, originalSize.Width, height - h * originalSize.Height, false);
                                
                                g.DrawImage(srcbmp, new Rectangle(originalSize.Width * w, originalSize.Height * h, originalSize.Width, originalSize.Height
),
                               new Rectangle(0, 0, originalSize.Width, originalSize.Height), GraphicsUnit.Pixel);
                            }
                            else
                            {
                                srcbmp =
                                    GLSharp.Capture.CaptureBufferAsBitmapRGBA(ReadBufferMode.FRONT,
                                    originalSize.Width * w, height - originalSize.Height * (1 + h), originalSize.Width, originalSize.Height, false);
                                g.DrawImage(srcbmp, new Rectangle(originalSize.Width * w, originalSize.Height * h, originalSize.Width, originalSize.Height),
                               new Rectangle(0, 0, originalSize.Width, originalSize.Height), GraphicsUnit.Pixel);
                            }
                                Application.DoEvents();
                                System.Threading.Thread.Sleep(100);
                        }
                    d.Close();
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                    panelMain.Location = new Point(0, 0);
                    panelMain.ClientSize = originalSize;
                    Draw();
                }
            }
        }
        #endregion

        #region 回転ボタン
        //角度リセットボタン
        private void buttonReset_Click(object sender, EventArgs e)
        {
            matrixModel = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            matrixLight = new double[] { 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 };
            OrthoZoom = 20;
            CamPosZ = 20;
            Draw();
        }
        private void buttonTopRight_Click(object sender, EventArgs e)
        {
            setRotate(-1, 1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonRght_Click(object sender, EventArgs e)
        {
            setRotate(0, 1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonBottomRight_Click(object sender, EventArgs e)
        {
            setRotate(1, 1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonBottom_Click(object sender, EventArgs e)
        {
            setRotate(1, 0, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonBottomLeft_Click(object sender, EventArgs e)
        {
            setRotate(1, -1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            setRotate(0, -1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonTopLeft_Click(object sender, EventArgs e)
        {
            setRotate(-1, -1, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonTop_Click(object sender, EventArgs e)
        {
            setRotate(-1, 0, 0, (double)numericUpDownRotationStep.Value);
        }

        private void buttonClock_Click(object sender, EventArgs e)
        {
            setRotate(0, 0, -1, (double)numericUpDownRotationStep.Value);
        }

        private void buttonAntiClock_Click(object sender, EventArgs e)
        {
            setRotate(0, 0, 1, (double)numericUpDownRotationStep.Value);
        }

        private void setRotate(double x, double y, double z, double angle)
        {
            gl.MatrixMode(MatrixMode.MODELVIEW);
            gl.LoadMatrix(matrixModel);
            double[] m = matrixModel;
            Matrix3D matrix = new Matrix3D(m[0], m[4], m[8], m[1], m[5], m[9], m[2], m[6], m[10]);
            Vector3D v = matrix * new Vector3D(x, y, z, false);
            gl.Translate(m[12], m[13], m[14]);
            gl.Rotate(angle, v.X, v.Y, v.Z);
            gl.Translate(-m[12], -m[13], -m[14]);
            gl.CurrentModelviewMatrixDouble.CopyTo(matrixModel, 0);

            this.Draw();
        }

        #endregion 回転ボタン

        #region ベクトルでの回転指定
        private void buttonSetVector_Click(object sender, EventArgs e)
        {
            if (crystal == null) return;
            int u = 0, v = 0, w = 0, h = 0, k = 0, l = 0;
            u = (int)numericUpDownAxisU.Value;
            v = (int)numericUpDownAxisV.Value;
            w = (int)numericUpDownAxisW.Value;
            h = (int)numericUpDownPlaneH.Value;
            k = (int)numericUpDownPlaneK.Value;
            l = (int)numericUpDownPlaneL.Value;

            Vector3D xVector = new Vector3D(), yVector = new Vector3D(), zVector = new Vector3D();
            Vector3D aAxis = crystal.aAxisOriginal;
            Vector3D bAxis = crystal.bAxisOriginal;
            Vector3D cAxis = crystal.cAxisOriginal;
            Matrix3D matrixInverse = Matrix3D.Inverse(new Matrix3D(aAxis, bAxis, cAxis));
            Vector3D aStar = new Vector3D(matrixInverse.E11, matrixInverse.E12, matrixInverse.E13);
            Vector3D bStar = new Vector3D(matrixInverse.E21, matrixInverse.E22, matrixInverse.E23);
            Vector3D cStar = new Vector3D(matrixInverse.E31, matrixInverse.E32, matrixInverse.E33);
            //軸を立てるとき
            if (radioButtonAxis.Checked && !(u == 0 && v == 0 && w == 0))
            {
                //まず立てる軸のベクトルを探す
                zVector = u * aAxis + v * bAxis + w * cAxis;
                zVector.Normarize();
                //上向きのベクトルを決める
                if (u * h + v * k + w * l != 0 || (h == 0 && k == 0 && l == 0))//正しく設定されていないときはhkl面を設定してやる
                {
                    if (u == 0 && v != 0 && w != 0) { h = 1; k = 0; l = 0; }
                    else if (u != 0 && v == 0 && w != 0) { h = 0; k = 1; l = 0; }
                    else if (u != 0 && v != 0 && w == 0) { h = 0; k = 0; l = 1; }
                    else if (u == 0 && v == 0 && w != 0) { h = 1; k = 0; l = 0; }
                    else if (u != 0 && v == 0 && w == 0) { h = 0; k = 1; l = 0; }
                    else if (u == 0 && v != 0 && w == 0) { h = 0; k = 0; l = 1; }
                    else { h = v; k = -u; l = 0; }
                }
                yVector = h * aStar + k * bStar + l * cStar;
                yVector.Normarize();
            }//面を立てるとき
            else if (radioButtonPlane.Checked && !(h == 0 && k == 0 && l == 0))
            {
                //まず立てる面のベクトルを探す
                zVector = h * aStar + k * crystal.bStar + l * cStar;
                zVector.Normarize();
                //上向きのベクトルを決める
                if (u * h + v * k + w * l != 0 || (u == 0 && v == 0 && w == 0))//正しく設定されていないときはhkl面を設定してやる
                {
                    if (h == 0 && k != 0 && l != 0) { u = 1; v = 0; w = 0; }
                    else if (h != 0 && k == 0 && l != 0) { u = 0; v = 1; w = 0; }
                    else if (h != 0 && k != 0 && l == 0) { u = 0; v = 0; w = 1; }
                    else if (h == 0 && k == 0 && l != 0) { u = 1; v = 0; w = 0; }
                    else if (h != 0 && k == 0 && l == 0) { u = 0; v = 1; w = 0; }
                    else if (h == 0 && k != 0 && l == 0) { u = 0; v = 0; w = 1; }
                    else { u = k; v = -h; w = 0; }
                }
                yVector = u * aAxis + v * bAxis + w * cStar;
                yVector.Normarize();
            }
            else
                return;

            xVector = Vector3D.VectorProduct(yVector, zVector);
            //xVector,yVector,zVectorが(100),(010),(001)に一致すればいいのだから　
            Matrix3D matrix = Matrix3D.Inverse(new Matrix3D(xVector, yVector, zVector));
            matrixModel[0] = matrix.E11;
            matrixModel[1] = matrix.E21;
            matrixModel[2] = matrix.E31;
            matrixModel[4] = matrix.E12;
            matrixModel[5] = matrix.E22;
            matrixModel[6] = matrix.E32;
            matrixModel[8] = matrix.E13;
            matrixModel[9] = matrix.E23;
            matrixModel[10] = matrix.E33;
            Draw();
        }
        #endregion 

        #region クリックした点を原子が通るかどうかチェック
        private double[] BoudaryTest(double[,] m, double ex, double ey)
        {
            double Px, Py, Pz, Qx, Qy, Qz;
            double a11 = m[0, 0], a12 = m[0, 1], a13 = m[0, 2], a14 = m[0, 3];
            double a21 = m[1, 0], a22 = m[1, 1], a23 = m[1, 2], a24 = m[1, 3];
            double a31 = m[2, 0], a32 = m[2, 1], a33 = m[2, 2], a34 = m[2, 3];
            double a41 = m[3, 0], a42 = m[3, 1], a43 = m[3, 2], a44 = m[3, 3];


            Px = ((-(a12 * a24 * a33) + a12 * a23 * a34 + a24 * a33 * a42 * ex - a23 * a34 * a42 * ex - a24 * a32 * a43 * ex + a22 * a34 * a43 * ex + a23 * a32 * a44 * ex - a22 * a33 * a44 * ex -
           a12 * a34 * a43 * ey + a12 * a33 * a44 * ey + a14 * (-(a23 * a32) + a22 * a33 - a33 * a42 * ey + a32 * a43 * ey) + a13 * (a24 * a32 - a22 * a34 + a34 * a42 * ey - a32 * a44 * ey)) /
         (a13 * a22 * a31 - a12 * a23 * a31 - a13 * a21 * a32 + a11 * a23 * a32 + a12 * a21 * a33 - a11 * a22 * a33 - a23 * a32 * a41 * ex + a22 * a33 * a41 * ex + a23 * a31 * a42 * ex - a21 * a33 * a42 * ex -
           a22 * a31 * a43 * ex + a21 * a32 * a43 * ex + (a13 * a32 * a41 - a12 * a33 * a41 - a13 * a31 * a42 + a11 * a33 * a42 + a12 * a31 * a43 - a11 * a32 * a43) * ey));

            Py = ((a14 * a23 * a31 - a13 * a24 * a31 - a14 * a21 * a33 + a11 * a24 * a33 + a13 * a21 * a34 - a11 * a23 * a34 - a24 * a33 * a41 * ex + a23 * a34 * a41 * ex + a24 * a31 * a43 * ex - a21 * a34 * a43 * ex -
            a23 * a31 * a44 * ex + a21 * a33 * a44 * ex + (a14 * a33 * a41 - a13 * a34 * a41 - a14 * a31 * a43 + a11 * a34 * a43 + a13 * a31 * a44 - a11 * a33 * a44) * ey) /
          (a13 * a22 * a31 - a12 * a23 * a31 - a13 * a21 * a32 + a11 * a23 * a32 + a12 * a21 * a33 - a11 * a22 * a33 - a23 * a32 * a41 * ex + a22 * a33 * a41 * ex + a23 * a31 * a42 * ex - a21 * a33 * a42 * ex -
            a22 * a31 * a43 * ex + a21 * a32 * a43 * ex + (a13 * a32 * a41 - a12 * a33 * a41 - a13 * a31 * a42 + a11 * a33 * a42 + a12 * a31 * a43 - a11 * a32 * a43) * ey));

            Pz = ((-(a11 * a24 * a32) + a11 * a22 * a34 + a24 * a32 * a41 * ex - a22 * a34 * a41 * ex - a24 * a31 * a42 * ex + a21 * a34 * a42 * ex + a22 * a31 * a44 * ex - a21 * a32 * a44 * ex - a11 * a34 * a42 * ey +
            a11 * a32 * a44 * ey + a14 * (-(a22 * a31) + a21 * a32 - a32 * a41 * ey + a31 * a42 * ey) + a12 * (a24 * a31 - a21 * a34 + a34 * a41 * ey - a31 * a44 * ey)) /
          (a13 * a22 * a31 - a12 * a23 * a31 - a13 * a21 * a32 + a11 * a23 * a32 + a12 * a21 * a33 - a11 * a22 * a33 - a23 * a32 * a41 * ex + a22 * a33 * a41 * ex + a23 * a31 * a42 * ex - a21 * a33 * a42 * ex -
            a22 * a31 * a43 * ex + a21 * a32 * a43 * ex + (a13 * a32 * a41 - a12 * a33 * a41 - a13 * a31 * a42 + a11 * a33 * a42 + a12 * a31 * a43 - a11 * a32 * a43) * ey));

            Qx = ((a12 * a24 * a33 - a12 * a23 * a34 - a12 * a24 * a43 + a12 * a23 * a44 - a24 * a33 * a42 * ex + a23 * a34 * a42 * ex + a24 * a32 * a43 * ex - a22 * a34 * a43 * ex - a23 * a32 * a44 * ex +
            a22 * a33 * a44 * ex + a12 * a34 * a43 * ey - a12 * a33 * a44 * ey + a14 * (-(a22 * a33) + a23 * (a32 - a42) + a22 * a43 + a33 * a42 * ey - a32 * a43 * ey) +
            a13 * (-(a24 * a32) + a22 * a34 + a24 * a42 - a22 * a44 - a34 * a42 * ey + a32 * a44 * ey)) /
          (-(a11 * a23 * a32) + a11 * a22 * a33 + a11 * a23 * a42 - a11 * a22 * a43 + a23 * a32 * a41 * ex - a22 * a33 * a41 * ex - a23 * a31 * a42 * ex + a21 * a33 * a42 * ex + a22 * a31 * a43 * ex -
            a21 * a32 * a43 * ex - a11 * a33 * a42 * ey + a11 * a32 * a43 * ey + a13 * (a21 * a32 + a22 * (-a31 + a41) - a21 * a42 - a32 * a41 * ey + a31 * a42 * ey) +
            a12 * (a23 * a31 - a21 * a33 - a23 * a41 + a21 * a43 + a33 * a41 * ey - a31 * a43 * ey)));

            Qy = ((-(a11 * a24 * a33) + a11 * a23 * a34 + a11 * a24 * a43 - a11 * a23 * a44 + a24 * a33 * a41 * ex - a23 * a34 * a41 * ex - a24 * a31 * a43 * ex + a21 * a34 * a43 * ex + a23 * a31 * a44 * ex -
            a21 * a33 * a44 * ex - a11 * a34 * a43 * ey + a11 * a33 * a44 * ey + a14 * (a21 * a33 + a23 * (-a31 + a41) - a21 * a43 - a33 * a41 * ey + a31 * a43 * ey) +
            a13 * (a24 * a31 - a21 * a34 - a24 * a41 + a21 * a44 + a34 * a41 * ey - a31 * a44 * ey)) /
          (-(a11 * a23 * a32) + a11 * a22 * a33 + a11 * a23 * a42 - a11 * a22 * a43 + a23 * a32 * a41 * ex - a22 * a33 * a41 * ex - a23 * a31 * a42 * ex + a21 * a33 * a42 * ex + a22 * a31 * a43 * ex -
            a21 * a32 * a43 * ex - a11 * a33 * a42 * ey + a11 * a32 * a43 * ey + a13 * (a21 * a32 + a22 * (-a31 + a41) - a21 * a42 - a32 * a41 * ey + a31 * a42 * ey) +
            a12 * (a23 * a31 - a21 * a33 - a23 * a41 + a21 * a43 + a33 * a41 * ey - a31 * a43 * ey)));

            Qz = ((a11 * a24 * a32 - a11 * a22 * a34 - a11 * a24 * a42 + a11 * a22 * a44 - a24 * a32 * a41 * ex + a22 * a34 * a41 * ex + a24 * a31 * a42 * ex - a21 * a34 * a42 * ex - a22 * a31 * a44 * ex +
             a21 * a32 * a44 * ex + a11 * a34 * a42 * ey - a11 * a32 * a44 * ey + a14 * (-(a21 * a32) + a22 * (a31 - a41) + a21 * a42 + a32 * a41 * ey - a31 * a42 * ey) +
             a12 * (-(a24 * a31) + a21 * a34 + a24 * a41 - a21 * a44 - a34 * a41 * ey + a31 * a44 * ey)) /
           (-(a11 * a23 * a32) + a11 * a22 * a33 + a11 * a23 * a42 - a11 * a22 * a43 + a23 * a32 * a41 * ex - a22 * a33 * a41 * ex - a23 * a31 * a42 * ex + a21 * a33 * a42 * ex + a22 * a31 * a43 * ex -
             a21 * a32 * a43 * ex - a11 * a33 * a42 * ey + a11 * a32 * a43 * ey + a13 * (a21 * a32 + a22 * (-a31 + a41) - a21 * a42 - a32 * a41 * ey + a31 * a42 * ey) +
             a12 * (a23 * a31 - a21 * a33 - a23 * a41 + a21 * a43 + a33 * a41 * ey - a31 * a43 * ey)));

            double Axx, Ayy, Azz, Axy, Ayz, Azx, Ax, Ay, Az, C;
            double PQx = (Px - Qx) * (Px - Qx);
            double PQy = (Py - Qy) * (Py - Qy);
            double PQz = (Pz - Qz) * (Pz - Qz);
            double Px2 = Px * Px;
            double Py2 = Py * Py;
            double Pz2 = Pz * Pz;
            double Qx2 = Qx * Qx;
            double Qy2 = Qy * Qy;
            double Qz2 = Qz * Qz;
            double PQxyz = 1 / (PQx + PQy + PQz);
            Axx = PQxyz * (Py2 + Pz2 - 2 * Py * Qy + Qy2 - 2 * Pz * Qz + Qz2);
            Ayy = PQxyz * (Px2 + Pz2 - 2 * Px * Qx + Qx2 - 2 * Pz * Qz + Qz2);
            Azz = PQxyz * (Px2 + Py2 - 2 * Px * Qx + Qx2 - 2 * Py * Qy + Qy2);
            Axy = -2 * PQxyz * (Px - Qx) * (Py - Qy);
            Ayz = -2 * PQxyz * (Py - Qy) * (Pz - Qz);
            Azx = -2 * PQxyz * (Px - Qx) * (Pz - Qz);
            Ax = 2 * PQxyz * (-(Qx * (Py2 + Pz2 - Py * Qy - Pz * Qz)) + Px * (Py * Qy - Qy2 + Pz * Qz - Qz2));
            Ay = 2 * PQxyz * (-((Px2 + Pz2) * Qy) + Px * Qx * (Py + Qy) + Pz * Qy * Qz - Py * (Qx2 - Pz * Qz + Qz2));
            Az = 2 * PQxyz * (-(Pz * (Qx2 - Py * Qy + Qy2)) - (Px2 + Py2) * Qz + Py * Qy * Qz + Px * Qx * (Pz + Qz));
            C = PQxyz * (Pz2 * (Qx2 + Qy2) - 2 * (Px * Py * Qx * Qy + Px * Pz * Qx * Qz + Py * Pz * Qy * Qz) + Py2 * (Qx2 + Qz2) + Px2 * (Qy2 + Qz2));

            return new double[] { Axx, Ayy, Azz, Axy, Ayz, Azx, Ax, Ay, Az, C };
        }
        #endregion

        private void checkBoxLatticePlane_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxLatticePlane.Enabled = checkBoxLatticePlane.Checked;
            SetMisc();
        }

        private void panelAxes_MouseUp(object sender, MouseEventArgs e)
        {
            Draw();
        }

        private void panelLight_MouseUp(object sender, MouseEventArgs e)
        {
            Draw();
        }

        private void panelMain_MouseUp(object sender, MouseEventArgs e)
        {
            Draw();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            tabControl1.BringToFront();
        }

        




    }
}