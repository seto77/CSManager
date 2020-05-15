using MessagePack;
using Crystallography;
using MessagePack.Resolvers;
using System.Data;
using System;
using System.Linq;
using System.Text;

namespace CSManager
{


    partial class DataSet
    {
        static readonly object lockObj = new object();
        public static void ReplaceBase(DataRowCollection rows, DataRow r, int i)
        {
            for (int j = 0; j < rows[i].ItemArray.Length; j++)
                rows[i][j] = r[j];
        }

        partial class DataTableDataTable
        {
            readonly MessagePackSerializerOptions msgOptions = StandardResolverAllowPrivate.Options.WithCompression(MessagePackCompression.Lz4BlockArray);
            byte[] serialize<T>(T c) => MessagePackSerializer.Serialize(c, msgOptions);
            T deserialize<T>(object obj) => MessagePackSerializer.Deserialize<T>((byte[])obj, msgOptions);


            /// <summary>
            /// 引数はbindingSourceMain.Currentオブジェクト. 
            /// </summary>
            /// <param name="o"></param>
            /// <returns></returns>
            public Crystal2 Get(object o) => o is DataRowView drv && drv.Row is DataTableRow r ? deserialize<Crystal2>(r[SerializedCrystal2Column]) : null;

            public void Add(Crystal2 crystal) => Add(CreateRow(crystal));
            public void Add(DataTableRow row) => Rows.Add(row);

            public new void Clear() => Rows.Clear();

            public void Remove(int i) => Rows.RemoveAt(i);

            /// <summary>
            /// srcCrystalはbindingSourceMain.Currentオブジェクト. 
            /// </summary>
            /// <param name="srcCrystal"></param>
            /// <param name="targetcrystal"></param>
            public void Replace(object srcCrystal, Crystal2 targetcrystal)
            {
                if (srcCrystal is DataRowView drv && drv.Row is DataTableRow src)
                {
                    var target = CreateRow(targetcrystal);
                    for (int j = 0; j < drv.Row.ItemArray.Length; j++)
                        src[j] = target[j];
                }

            }
            public DataTableRow CreateRow(Crystal2 c)
            {
                var elementList = new StringBuilder();
                foreach (var n in c.atoms.Select(a => a.AtomNo).Distinct())
                    elementList.Append($"{n:000} ");

                var d = new double[8];
                Array.Copy(c.d, d, c.d.Length);

                DataTableRow dr;
                lock (lockObj)
                    dr = NewDataTableRow();

                dr.SerializedCrystal2 = serialize(c);
                dr.Visible = true;
                dr.Name = c.name;
                dr.Formula = c.formula;
                dr.Density = c.density;
                dr.A = c.a * 10;
                dr.B = c.b * 10;
                dr.C = c.c * 10;
                dr.Alpha = c.alpha * 180 / Math.PI;
                dr.Beta = c.beta * 180 / Math.PI;
                dr.Gamma = c.gamma * 180 / Math.PI;
                dr.CrystalSystem = SymmetryStatic.StrArray[c.sym][16];//s.CrystalSystemStr;
                dr.PointGroup = SymmetryStatic.StrArray[c.sym][13];
                dr.SpaceGroup = SymmetryStatic.StrArray[c.sym][4];
                dr.Authors = c.auth;
                dr.Title = Crystal2.GetFullTitle(c.sect);
                dr.Journal = Crystal2.GetFullJournal(c.jour);
                dr.Elements = elementList.ToString();
                dr.D1 = d[0];
                dr.D2 = d[1];
                dr.D3 = d[2];
                dr.D4 = d[3];
                dr.D5 = d[4];
                dr.D6 = d[5];
                dr.D7 = d[6];
                dr.D8 = d[7];

                return dr;
            }





        }
    }
}
