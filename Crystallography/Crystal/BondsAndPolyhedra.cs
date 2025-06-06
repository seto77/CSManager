using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Serialization;
//using MemoryPack;

namespace Crystallography;

[Serializable()]
//[MemoryPackable]
public partial class Bonds
{
    #region フィールド
    public string Element1;
    public string Element2;
    public float MinLength;//nm単位
    public float MaxLength;//nm単位
    public float Radius;//nm単位
    public float BondTransParency;
    public int ArgbBond;
    public float PolyhedronTransParency;
    public bool ShowPolyhedron;
    public bool ShowCenterAtom;
    public bool ShowVertexAtom;
    public bool ShowInnerBonds;
    public int ArgbPolyhedron;
    public bool ShowEdges;
    public float EdgeLineWidth;
    public int ArgbEdge;
    public bool Enabled = true;
    public bool ShowBond = true;
    public bool UseFixedColor = false;

    //[MemoryPackIgnore]
    public string[] ElementList;

    //2020/05/11追加 (標準の単位をnmに変更したための対処)
    //[MemoryPackIgnore]
    public bool NanometerUnit = false;


    [XmlIgnore]
    //[MemoryPackIgnore]
    public List<int[]> pairID = [];

    #endregion

    #region コンストラクタ
    //[MemoryPackConstructor]
    public Bonds() { }

    public Bonds(bool enabled,
        string[] elementList, string element1, string element2, float minLength, float maxLength,
        bool showBond, float radius, float bondTranParency,
        bool showPolyhedron, bool showCenterAtom, bool showVertexAtom, bool showInnerBonds,
        float polyhedronTransParency, bool showEdges, float edgeLineWidth)
    {
        Enabled = enabled;

        ElementList = elementList;
        Element1 = element1;
        Element2 = element2;

        MinLength = minLength;
        MaxLength = maxLength;

        ShowBond = showBond;
        Radius = radius;

        BondTransParency = bondTranParency;

        PolyhedronTransParency = polyhedronTransParency;

        ShowPolyhedron = showPolyhedron;
        ShowCenterAtom = showCenterAtom;
        ShowVertexAtom = showVertexAtom;
        ShowInnerBonds = showInnerBonds;

        ShowEdges = showEdges;
        EdgeLineWidth = edgeLineWidth;

        UseFixedColor = false;

        NanometerUnit = true;
    }

    public Bonds(bool enabled,
       string[] elementList, string element1, string element2, double minLength, double maxLength,
       bool showBond, double radius, double bondTranParency,
       bool showPolyhedron, bool showCenterAtom, bool showVertexAtom, bool showInnerBonds,
       double polyhedronTransParency, bool showEdges, double edgeLineWidth)
        : this(enabled,
        elementList, element1, element2, (float)minLength, (float)maxLength,
        showBond, (float)radius, (float)bondTranParency,
        showPolyhedron, showCenterAtom, showVertexAtom, showInnerBonds,
       (float)polyhedronTransParency, showEdges, (float)edgeLineWidth)
    { }




    public Bonds(bool enabled,
         string[] elementList, string element1, string element2, float minLength, float maxLength,
         bool showBond, float radius, float bondTranParency, Color bondColor,
         bool showPolyhedron, bool showCenterAtom, bool showVertexAtom, bool showInnerBonds,
         float polyhedronTransParency, Color polyhedronColor, bool showEdges, float edgeLineWidth, Color edgeColor)
         : this(enabled, elementList, element1, element2, minLength, maxLength,
         showBond, radius, bondTranParency,
         showPolyhedron, showCenterAtom, showVertexAtom, showInnerBonds,
         polyhedronTransParency, showEdges, edgeLineWidth)
    {
        ArgbBond = bondColor.ToArgb();
        ArgbPolyhedron = polyhedronColor.ToArgb();
        ArgbEdge = edgeColor.ToArgb();
        UseFixedColor = true;
    }
    public Bonds(bool enabled,
     string[] elementList, string element1, string element2, double minLength, double maxLength,
      bool showBond, double radius, double bondTranParency, Color bondColor,
      bool showPolyhedron, bool showCenterAtom, bool showVertexAtom, bool showInnerBonds,
      double polyhedronTransParency, Color polyhedronColor, bool showEdges, double edgeLineWidth, Color edgeColor)
     : this(enabled, elementList, element1, element2, (float)minLength, (float)maxLength,
      showBond, (float)radius, (float)bondTranParency, bondColor,
      showPolyhedron, showCenterAtom, showVertexAtom, showInnerBonds,
      (float)polyhedronTransParency, polyhedronColor, showEdges, (float)edgeLineWidth, edgeColor)
    {

    }
    #endregion

    #region static メソッド、コンストラクタ

    /// <summary>
    /// Vesta標準のボンドを生成. 入力形式は、原子番号の配列
    /// </summary>
    /// <param name="atomicNumbers"></param>
    /// <returns></returns>
    public static Bonds[] GetVestaBonds(IEnumerable<int> atomicNumbers) => GetVestaBonds(atomicNumbers.Select(n => $"{n}: {AtomStatic.AtomicName(n)}"));

    /// <summary>
    /// Vesta標準のボンドを生成. 入力形式は、 "26: Fe" のような原子番号と元素記号のセットにした文字列の配列
    /// </summary>
    /// <param name="elementNames"></param>
    /// <returns></returns>
    public static Bonds[] GetVestaBonds(IEnumerable<string> elementNames)
    {
        var list = elementNames.ToList().Distinct().ToArray();
        var list2 = list.Select(l => l.Split(" ", true)[1]).ToList();

        var bonds = new List<Bonds>();

        foreach ((string e1, string e2, double min, double max) in bondCandidates)
            if (list2.Contains(e1) && list2.Contains(e2))
            {
                bonds.Add(new Bonds(true, list, list[list2.IndexOf(e1)], list[list2.IndexOf(e2)],
                    min / 10.0, max / 10.0, true, 0.01, 1, false, true, true, true, 0.7, true, 0));
            }

        //CationとAnionが両方含まれている場合は、同種原子の結合を除去
        if (VestaAnions.Any(anion => list.Contains(anion)) && VestaCations.Any(cation => list.Contains(cation)))
        {
            VestaAnions.ForEach(anion => bonds.Remove(bonds.Find(b => b.Element1 == anion && b.Element2 == anion)));
            VestaCations.ForEach(cation => bonds.Remove(bonds.Find(b => b.Element1 == cation && b.Element2 == cation)));
        }

        return [.. bonds];
    }

    static Bonds()
    {
        var anionNum = new List<int> { 8, 9, 16, 17, 34, 35, 52, 53 };
        VestaAnions = [.. anionNum.Select(n => $"{n}: {AtomStatic.AtomicName(n)}")];

        var cationNum = new List<int>();
        cationNum.AddRange(Enumerable.Range(3, 5));
        cationNum.AddRange(Enumerable.Range(11, 5));
        cationNum.AddRange(Enumerable.Range(19, 15));
        cationNum.AddRange(Enumerable.Range(37, 15));
        cationNum.AddRange(Enumerable.Range(55, 20));
        VestaCations = [.. cationNum.Select(n => $"{n}: {AtomStatic.AtomicName(n)}")];
    }

    public static List<string> VestaCations { get; }
    public static List<string> VestaAnions { get; }

    private static readonly (string e1, string e2, double min, double max)[] bondCandidates =
    [
			#region VestaのStyles.iniからコピーした内容。原子の結合の情報。
		
("Ac","O",0,2.7326),
("Ac","F",0,2.58646),
("Ac","Cl",0,3.08646),
("Ac","Br",0,3.22726),
("Ag","O",0,2.81139),
("Ag","S",0,3.08839),
("Ag","F",0,2.76939),
("Ag","Cl",0,3.05939),
("Ag","Br",0,2.37642),
("Ag","I",0,2.53642),
("Ag","Se",0,2.41642),
("Ag","Te",0,2.66642),
("Ag","N",0,2.00642),
("Ag","P",0,2.37642),
("Ag","As",0,2.45642),
("Ag","H",0,1.65642),
("Al","O",0,2.1074),
("Al","S",0,2.66646),
("Al","Se",0,2.72646),
("Al","Te",0,2.93646),
("Al","F",0,2.00146),
("Al","Cl",0,2.48846),
("Al","Br",0,2.65646),
("Al","I",0,2.86646),
("Al","N",0,2.24646),
("Al","P",0,2.69646),
("Al","As",0,2.75646),
("Al","H",0,1.90646),
("Am","O",0,2.71649),
("Am","F",0,2.61945),
("Am","Cl",0,3.08945),
("Am","Br",0,3.22944),
("As","S",0,2.84649),
("As","Se",0,2.98649),
("As","O",0,2.24546),
("As","Te",0,3.10646),
("As","F",0,2.15646),
("As","Cl",0,2.61646),
("As","Br",0,2.80646),
("As","I",0,3.03646),
("As","C",0,2.38646),
("Au","Cl",0,2.88295),
("Au","I",0,3.21295),
("Au","O",0,2.34646),
("Au","S",0,2.8326),
("Au","F",0,2.34646),
("Au","Br",0,2.77646),
("Au","N",0,2.3826),
("Au","Se",0,2.22998),
("Au","Te",0,2.45998),
("Au","P",0,2.18998),
("Au","As",0,2.26998),
("Au","H",0,1.41998),
("B","O",0,1.82746),
("B","S",0,2.27646),
("B","Se",0,2.40646),
("B","Te",0,2.65646),
("B","F",0,1.76646),
("B","Cl",0,2.19646),
("B","Br",0,2.33646),
("B","I",0,2.55646),
("B","N",0,1.93846),
("B","P",0,2.37646),
("B","As",0,2.42646),
("B","H",0,1.59646),
("B","B",0,1.85846),
("Ba","O",0,3.14795),
("Ba","S",0,3.66195),
("Ba","Se",0,3.74295),
("Ba","Te",0,3.94295),
("Ba","F",0,3.05095),
("Ba","Cl",0,3.55295),
("Ba","Br",0,3.74295),
("Ba","I",0,3.99295),
("Ba","N",0,3.33295),
("Ba","P",0,3.48295),
("Ba","As",0,3.69),
("Ba","H",0,3.08295),
("Be","O",0,1.98749),
("Be","S",0,2.43649),
("Be","Se",0,2.57649),
("Be","Te",0,2.81649),
("Be","F",0,1.88749),
("Be","Cl",0,2.36649),
("Be","Br",0,2.50649),
("Be","I",0,2.70649),
("Be","N",0,2.10649),
("Be","P",0,2.55649),
("Be","As",0,2.60649),
("Be","H",0,1.71649),
("Bi","O",0,2.6608),
("Bi","S",0,3.13291),
("Bi","Se",0,3.24329),
("Bi","F",0,2.55291),
("Bi","Cl",0,3.04291),
("Bi","Br",0,3.17993),
("Bi","I",0,3.38291),
("Bi","N",0,2.56329),
("Bi","Te",0,3.02642),
("Bi","P",0,2.78642),
("Bi","As",0,2.87642),
("Bi","H",0,2.12642),
("Bk","O",0,2.64329),
("Bk","F",0,2.54233),
("Bk","Cl",0,3.02291),
("Bk","Br",0,3.15233),
("Br","O",0,2.35646),
("Br","F",0,2.20646),
("Br","Cl",0,2.33296),
("C","O",0,1.97249),
("C","Cl",0,2.11002),
("C","C",0,1.89002),
("C","S",0,2.15002),
("C","F",0,1.76002),
("C","Br",0,2.26002),
("C","N",0,1.79202),
("C","Se",0,2.01998),
("C","I",0,2.16998),
("C","Te",0,2.25998),
("C","P",0,1.93998),
("C","H",0,1.2),
("Ca","O",0,2.83062),
("Ca","S",0,3.31295),
("Ca","Se",0,3.42295),
("Ca","Te",0,3.62295),
("Ca","F",0,2.70495),
("Ca","Cl",0,3.23295),
("Ca","Br",0,3.36995),
("Ca","I",0,3.58295),
("Ca","N",0,3.00295),
("Ca","P",0,3.41295),
("Ca","As",0,3.48295),
("Ca","H",0,2.69295),
("Cd","O",0,2.76695),
("Cd","S",0,3.16695),
("Cd","Se",0,3.26295),
("Cd","Te",0,3.45295),
("Cd","F",0,2.67395),
("Cd","Cl",0,3.09295),
("Cd","Br",0,3.21295),
("Cd","I",0,3.46295),
("Cd","N",0,2.82295),
("Cd","P",0,3.20295),
("Cd","As",0,3.29295),
("Cd","H",0,2.52295),
("Ce","O",0,2.86393),
("Ce","S",0,3.36293),
("Ce","F",0,2.75452),
("Ce","Cl",0,3.25293),
("Ce","Br",0,3.40452),
("Ce","I",0,3.62452),
("Ce","N",0,2.78549),
("Ce","Se",0,3.04644),
("Ce","Te",0,3.22644),
("Ce","P",0,3.00644),
("Ce","As",0,3.08644),
("Ce","H",0,2.34644),
("Cf","O",0,2.63291),
("Cf","F",0,2.53233),
("Cf","Cl",0,3.01291),
("Cf","Br",0,3.14233),
("Cl","O",0,2.16646),
("Cl","F",0,2.14646),
("Cl","Cl",0,2.14296),
("Cm","O",0,2.79291),
("Cm","F",0,2.68291),
("Cm","Cl",0,3.18291),
("Co","H",0,1.9278),
("Co","O",0,2.40493),
("Co","S",0,2.65293),
("Co","F",0,2.35293),
("Co","Cl",0,2.74593),
("Co","N",0,2.36293),
("Co","C",0,2.19691),
("Co","Br",0,2.33642),
("Co","I",0,2.52878),
("Co","Se",0,2.39642),
("Co","Te",0,2.61642),
("Co","P",0,2.36642),
("Co","As",0,2.43642),
("Cr","O",0,2.44293),
("Cr","F",0,2.45293),
("Cr","Cl",0,2.80293),
("Cr","Br",0,2.97293),
("Cr","I",0,3.19293),
("Cr","N",0,2.5152),
("Cr","S",0,2.72491),
("Cr","Se",0,2.44642),
("Cr","Te",0,2.67642),
("Cr","P",0,2.42642),
("Cr","As",0,2.49642),
("Cr","H",0,1.67642),
("Cs","O",0,3.53642),
("Cs","S",0,4.24942),
("Cs","Se",0,4.21655),
("Cs","Te",0,4.4631),
("Cs","F",0,3.49942),
("Cs","Cl",0,3.91042),
("Cs","Br",0,4.06942),
("Cs","I",0,4.40942),
("Cs","N",0,3.94942),
("Cs","P",0,3.64194),
("Cs","As",0,4.15942),
("Cs","H",0,3.55942),
("Cu","O",0,2.47295),
("Cu","S",0,2.76095),
("Cu","Se",0,2.76295),
("Cu","F",0,2.46295),
("Cu","Cl",0,2.75295),
("Cu","Br",0,2.89295),
("Cu","I",0,3.01795),
("Cu","N",0,2.49295),
("Cu","P",0,2.65649),
("Cu","As",0,2.71895),
("Cu","C",0,2.32649),
("Cu","Te",0,2.87649),
("Cu","H",0,1.81649),
("Dy","O",0,2.65651),
("Dy","F",0,2.52944),
("Dy","Cl",0,3.01945),
("Dy","Br",0,3.16945),
("Dy","I",0,3.39945),
("Dy","S",0,2.823),
("Dy","Se",0,2.81),
("Dy","Te",0,3.22),
("Dy","N",0,2.38),
("Dy","P",0,2.77),
("Dy","As",0,3.14),
("Dy","H",0,2.09),
("Er","O",0,2.63651),
("Er","S",0,3.27651),
("Er","Se",0,3.18649),
("Er","F",0,2.51049),
("Er","Cl",0,2.99944),
("Er","Br",0,3.14945),
("Er","I",0,3.38945),
("Er","Te",0,3.22),
("Er","N",0,2.36),
("Er","P",0,2.75),
("Er","As",0,3.18),
("Er","H",0,2.06),
("Es","O",0,2.70139),
("Eu","O",0,2.94249),
("Eu","S",0,3.37949),
("Eu","F",0,2.83549),
("Eu","Cl",0,3.32549),
("Eu","Br",0,3.46549),
("Eu","I",0,3.69549),
("Eu","N",0,2.95549),
("Eu","Se",0,2.89898),
("Eu","Te",0,3.08898),
("Eu","P",0,2.85898),
("Eu","As",0,2.93898),
("Eu","H",0,2.18898),
("Fe","O",0,2.44693),
("Fe","S",0,2.83793),
("Fe","F",0,2.36293),
("Fe","Cl",0,2.86293),
("Fe","Br",0,2.8952),
("Fe","I",0,3.1552),
("Fe","N",0,2.48193),
("Fe","C",0,2.25191),
("Fe","Se",0,2.43642),
("Fe","Te",0,2.68642),
("Fe","P",0,2.42642),
("Fe","As",0,2.50642),
("Fe","H",0,1.68642),
("Ga","Se",0,3.41295),
("Ga","O",0,2.18646),
("Ga","S",0,2.61946),
("Ga","F",0,2.14646),
("Ga","Cl",0,2.52646),
("Ga","Br",0,2.6426),
("Ga","I",0,2.91646),
("Ga","Te",0,2.58998),
("Ga","N",0,1.96),
("Ga","P",0,2.46998),
("Ga","As",0,2.38998),
("Ga","H",0,1.55998),
("Gd","O",0,2.76651),
("Gd","F",0,3.15651),
("Gd","S",0,3.13649),
("Gd","Cl",0,3.06349),
("Gd","Br",0,3.19945),
("Gd","I",0,3.41945),
("Gd","Se",0,2.85),
("Gd","Te",0,3.24),
("Gd","N",0,2.42),
("Gd","P",0,2.81),
("Gd","As",0,3.18),
("Gd","H",0,2.13),
("Ge","O",0,2.09802),
("Ge","S",0,2.56702),
("Ge","Se",0,2.70002),
("Ge","F",0,2.01002),
("Ge","Cl",0,2.49002),
("Ge","Br",0,2.34998),
("Ge","I",0,2.54998),
("Ge","Te",0,2.60998),
("Ge","N",0,1.92998),
("Ge","P",0,2.36998),
("Ge","As",0,2.47998),
("Ge","H",0,1.59998),
("Ge","Ge",0,2.6),
("O","H",0,1.2),
("H","O",1.2,2.1),
("H","F",0,1.1),
("H","Cl",0,1.5),
("H","N",0,1.2),
("O","D",0,1.2),
("D","O",1.2,2.1),
("D","F",0,1.1),
("D","Cl",0,1.5),
("D","N",0,1.2),
("Hf","F",0,3.18291),
("Hf","O",0,2.37946),
("Hf","Cl",0,2.75646),
("Hf","Br",0,2.62642),
("Hf","S",0,2.64642),
("Hf","Se",0,2.67642),
("Hf","Te",0,2.87642),
("Hf","I",0,2.83642),
("Hf","N",0,2.24642),
("Hf","P",0,2.63642),
("Hf","As",0,2.71642),
("Hf","H",0,1.93642),
("Hg","O",0,2.86939),
("Hg","F",0,2.88293),
("Hg","Cl",0,3.24939),
("Hg","S",0,3.42093),
("Hg","Br",0,3.09293),
("Hg","I",0,3.33293),
("Hg","Se",0,2.82642),
("Hg","Te",0,2.76642),
("Hg","N",0,2.17642),
("Hg","P",0,2.57642),
("Hg","As",0,2.65642),
("Hg","H",0,1.86642),
("Hg","Hg",0,3.1952),
("Ho","O",0,2.67047),
("Ho","S",0,3.13547),
("Ho","F",0,2.56159),
("Ho","Cl",0,3.05159),
("Ho","Br",0,3.20159),
("Ho","I",0,3.44159),
("Ho","Se",0,2.84898),
("Ho","Te",0,3.03898),
("Ho","N",0,2.41898),
("Ho","P",0,2.79898),
("Ho","As",0,2.87898),
("Ho","H",0,2.11898),
("I","I",0,2.4),
("I","F",0,3.18295),
("I","Cl",0,3.33295),
("I","O",0,2.47646),
("In","Cl",0,3.52939),
("In","O",0,2.46491),
("In","S",0,2.93291),
("In","F",0,2.35491),
("In","Br",0,3.05329),
("In","I",0,3.19291),
("In","Co",0,3.13629),
("In","Mn",0,3.14729),
("In","Se",0,2.62642),
("In","Te",0,2.84642),
("In","N",0,2.18642),
("In","P",0,2.68642),
("In","As",0,2.66642),
("In","H",0,1.87642),
("Ir","O",0,2.27746),
("Ir","F",0,2.15002),
("Ir","Cl",0,2.56746),
("Ir","S",0,2.42998),
("Ir","Se",0,2.55998),
("Ir","Te",0,2.75998),
("Ir","Br",0,2.49998),
("Ir","I",0,2.70998),
("Ir","N",0,2.10998),
("Ir","P",0,2.50998),
("Ir","As",0,2.58998),
("Ir","H",0,1.80998),
("K","O",0,3.25142),
("K","S",0,3.79285),
("K","Se",0,4.00186),
("K","Te",0,4.23284),
("K","F",0,3.11142),
("K","Cl",0,3.65976),
("K","Br",0,3.8513),
("K","I",0,4.11717),
("K","N",0,3.41942),
("K","P",0,3.44942),
("K","As",0,3.94942),
("K","H",0,3.21942),
("Kr","F",0,2.67549),
("La","O",0,2.90983),
("La","S",0,3.35593),
("La","Se",0,3.45293),
("La","Te",0,3.65293),
("La","F",0,2.79293),
("La","Cl",0,3.33452),
("La","Br",0,3.43293),
("La","I",0,3.64293),
("La","N",0,3.05293),
("La","P",0,3.32293),
("La","As",0,3.51293),
("La","H",0,2.77293),
("Li","O",0,2.60087),
("Li","S",0,3.02481),
("Li","Se",0,3.2433),
("Li","Te",0,3.42496),
("Li","F",0,2.34276),
("Li","Cl",0,2.91814),
("Li","Br",0,3.11654),
("Li","I",0,3.37676),
("Li","N",0,2.66213),
("Lu","O",0,2.57749),
("Lu","S",0,3.03649),
("Lu","Se",0,3.16649),
("Lu","Te",0,3.35649),
("Lu","F",0,2.48249),
("Lu","Cl",0,2.96944),
("Lu","Br",0,3.11945),
("Lu","I",0,3.36945),
("Lu","N",0,2.71649),
("Lu","P",0,3.11649),
("Lu","As",0,3.19649),
("Lu","H",0,2.42649),
("Mg","O",0,2.41824),
("Mg","S",0,2.89293),
("Mg","Se",0,3.03293),
("Mg","Te",0,3.24293),
("Mg","F",0,2.29093),
("Mg","Cl",0,2.79293),
("Mg","Br",0,2.99293),
("Mg","I",0,3.17293),
("Mg","N",0,2.56293),
("Mg","P",0,3.00293),
("Mg","As",0,3.09293),
("Mg","H",0,2.24293),
("Mn","O",0,2.51652),
("Mn","S",0,2.93293),
("Mn","F",0,2.41093),
("Mn","Cl",0,2.84593),
("Mn","Br",0,3.05293),
("Mn","I",0,3.23293),
("Mn","N",0,2.56193),
("Mn","Se",0,2.47642),
("Mn","Te",0,2.70642),
("Mn","P",0,2.39642),
("Mn","As",0,2.51642),
("Mn","H",0,1.70642),
("Mo","S",0,2.80067),
("Mo","Cl",0,2.80447),
("Mo","O",0,2.3475),
("Mo","F",0,2.2998),
("Mo","Br",0,2.8535),
("Mo","N",0,2.4735),
("Mo","I",0,2.74701),
("Mo","Se",0,2.59701),
("Mo","Te",0,2.79701),
("Mo","P",0,2.54701),
("Mo","As",0,2.62701),
("Mo","H",0,1.83701),
("N","O",0,1.81746),
("N","F",0,1.82646),
("N","Cl",0,2.20646),
("N","N",0,1.8826),
("Na","O",0,2.95693),
("Na","S",0,3.57685),
("Na","Se",0,3.71593),
("Na","Te",0,3.95459),
("Na","F",0,2.80398),
("Na","Cl",0,3.39412),
("Na","Br",0,3.57715),
("Na","I",0,3.88251),
("Na","N",0,3.12942),
("Na","P",0,3.47942),
("Na","As",0,3.64942),
("Na","H",0,2.79942),
("Nb","O",0,2.45329),
("Nb","F",0,2.35646),
("Nb","Cl",0,2.76291),
("Nb","Br",0,3.07646),
("Nb","N",0,2.46046),
("Nb","I",0,3.1439),
("Nb","S",0,2.74),
("Nb","Se",0,2.66642),
("Nb","Te",0,2.85642),
("Nb","P",0,2.61642),
("Nb","As",0,2.69642),
("Nb","H",0,1.90642),
("Nd","O",0,2.8587),
("Nd","S",0,3.42712),
("Nd","Se",0,3.42293),
("Nd","Te",0,3.60293),
("Nd","F",0,2.73452),
("Nd","Cl",0,3.22493),
("Nd","Br",0,3.37293),
("Nd","I",0,3.59452),
("Nd","N",0,3.01293),
("NH","O",0,3.08895),
("NH","F",0,2.99195),
("NH","Cl",0,3.48195),
("Ni","O",0,2.28149),
("Ni","S",0,2.58649),
("Ni","F",0,2.20249),
("Ni","Cl",0,2.62649),
("Ni","Br",0,2.80649),
("Ni","I",0,3.00649),
("Ni","N",0,2.30649),
("Ni","Se",0,2.18998),
("Ni","Te",0,2.47998),
("Ni","P",0,2.31998),
("Ni","As",0,2.28998),
("Ni","H",0,1.44998),
("Np","F",0,2.59233),
("Np","Cl",0,3.07233),
("Np","S",0,3.2),
("Np","Br",0,3.21233),
("Np","I",0,3.44233),
("Np","O",0,2.63646),
("O","O",0,1.7),
("Os","O",0,2.23),
("Os","S",0,2.56002),
("Os","F",0,2.07746),
("Os","Cl",0,2.54002),
("Os","Br",0,2.72002),
("P","O",0,2.08646),
("P","S",0,2.57646),
("P","Se",0,2.69646),
("P","F",0,2.01002),
("P","Cl",0,2.28746),
("P","Br",0,2.44293),
("P","N",0,1.97146),
("P","I",0,2.44998),
("P","P",0,2.48381),
("P","As",0,2.29998),
("P","H",0,1.45998),
("Pa","O",0,2.63383),
("Pa","F",0,2.54437),
("Pa","Cl",0,3.01437),
("Pa","Br",0,3.18437),
("Pb","O",0,3.04096),
("Pb","S",0,3.40395),
("Pb","Se",0,3.55295),
("Pb","F",0,2.92045),
("Pb","Cl",0,3.39295),
("Pb","Br",0,3.62451),
("Pb","I",0,3.69562),
("Pb","N",0,3.0967),
("Pb","Te",0,3.14644),
("Pb","P",0,2.94644),
("Pb","As",0,3.02644),
("Pb","H",0,2.27644),
("Pd","O",0,2.39849),
("Pd","S",0,2.69649),
("Pd","F",0,2.34649),
("Pd","Cl",0,2.65649),
("Pd","Br",0,2.80649),
("Pd","I",0,2.96649),
("Pd","N",0,2.40451),
("Pd","C",0,2.33649),
("Pd","Se",0,2.26998),
("Pd","Te",0,2.52998),
("Pd","P",0,2.46998),
("Pd","As",0,2.34998),
("Pd","H",0,1.51998),
("Pm","F",0,2.55233),
("Pm","Cl",0,3.41233),
("Pm","Br",0,3.18233),
("Po","O",0,2.64646),
("Po","F",0,2.83646),
("Pr","O",0,2.74449),
("Pr","S",0,3.20649),
("Pr","Se",0,3.32649),
("Pr","Te",0,3.50649),
("Pr","F",0,2.62945),
("Pr","Cl",0,3.12749),
("Pr","Br",0,3.27649),
("Pr","I",0,3.49649),
("Pr","N",0,2.90649),
("Pr","P",0,3.28649),
("Pr","As",0,3.35649),
("Pr","H",0,2.62649),
("Pt","O",0,2.40649),
("Pt","S",0,2.76649),
("Pt","F",0,2.54002),
("Pt","Cl",0,2.75646),
("Pt","Br",0,2.94191),
("Pt","C",0,2.36649),
("Pt","N",0,2.41649),
("Pt","I",0,2.41998),
("Pt","Se",0,2.23998),
("Pt","Te",0,2.49998),
("Pt","P",0,2.23998),
("Pt","As",0,2.30998),
("Pt","H",0,1.44998),
("Pu","O",0,2.68329),
("Pu","F",0,2.58233),
("Pu","Cl",0,3.05233),
("Pu","S",0,3.3),
("Pu","Br",0,3.19233),
("Pu","I",0,3.43233),
("Rb","O",0,3.43945),
("Rb","S",0,3.97645),
("Rb","Se",0,4.13773),
("Rb","Te",0,4.28802),
("Rb","F",0,3.37645),
("Rb","Cl",0,3.86664),
("Rb","Br",0,4.05498),
("Rb","I",0,4.33462),
("Rb","N",0,3.79645),
("Rb","P",0,3.50645),
("Rb","As",0,4.04645),
("Rb","H",0,3.43645),
("Re","Cl",0,3.44712),
("Re","O",0,2.3426),
("Re","F",0,2.16002),
("Re","Br",0,2.70002),
("Re","I",0,2.65998),
("Re","S",0,2.61998),
("Re","Se",0,2.54998),
("Re","Te",0,2.74998),
("Re","N",0,2.10998),
("Re","P",0,2.50998),
("Re","As",0,2.61998),
("Re","H",0,1.79998),
("Rh","O",0,2.24946),
("Rh","F",0,2.16646),
("Rh","Cl",0,2.62646),
("Rh","Br",0,2.7126),
("Rh","N",0,2.2626),
("Rh","I",0,2.52998),
("Rh","S",0,2.19998),
("Rh","Se",0,2.37998),
("Rh","Te",0,2.59998),
("Rh","P",0,2.43998),
("Rh","As",0,2.41998),
("Rh","H",0,1.59998),
("Ru","Se",0,2.69451),
("Ru","F",0,2.57646),
("Ru","O",0,2.22646),
("Ru","S",0,2.6426),
("Ru","Cl",0,2.70646),
("Ru","N",0,2.2626),
("Ru","Br",0,2.30998),
("Ru","I",0,2.52998),
("Ru","Te",0,2.58998),
("Ru","P",0,2.33998),
("Ru","As",0,2.40998),
("Ru","H",0,1.65998),
("S","O",0,1.8),
("S","S",0,2.2),
("S","N",0,2.28849),
("S","F",0,1.95002),
("S","Cl",0,2.37002),
("S","Br",0,2.21998),
("S","I",0,2.40998),
("S","H",0,1.42998),
("Sb","O",0,2.45237),
("Sb","S",0,3.05),
("Sb","Se",0,3.05646),
("Sb","F",0,2.35646),
("Sb","Cl",0,2.80646),
("Sb","Br",0,2.96646),
("Sb","I",0,3.21646),
("Sb","N",0,2.56446),
("Sb","Te",0,2.82998),
("Sb","P",0,2.56998),
("Sb","As",0,2.64998),
("Sb","H",0,2.81998),
("Sc","O",0,2.42029),
("Sc","S",0,2.88391),
("Sc","Se",0,3.00291),
("Sc","Te",0,3.20291),
("Sc","F",0,2.32291),
("Sc","Cl",0,2.92291),
("Sc","Br",0,2.94291),
("Sc","I",0,3.15291),
("Sc","N",0,2.54291),
("Sc","P",0,2.96291),
("Sc","As",0,3.04291),
("Sc","H",0,2.24291),
("Se","S",0,2.81649),
("Se","Se",0,2.93649),
("Se","O",0,2.16102),
("Se","F",0,2.08002),
("Se","Cl",0,2.57002),
("Se","Br",0,2.78002),
("Se","N",0,2.1),
("Se","I",0,2.58998),
("Se","H",0,1.58998),
("Si","O",0,1.99002),
("Si","S",0,2.47602),
("Si","Se",0,2.61002),
("Si","Te",0,2.84002),
("Si","F",0,1.93002),
("Si","Cl",0,2.38002),
("Si","Br",0,2.55002),
("Si","I",0,2.76002),
("Si","C",0,2.23302),
("Si","N",0,2.12002),
("Si","P",0,2.58002),
("Si","As",0,2.66002),
("Si","H",0,1.82002),
("Si","Si",0,2.6),
("Sm","O",0,2.88251),
("Sm","N",0,3.02351),
("Sm","S",0,3.15649),
("Sm","Se",0,3.27649),
("Sm","Te",0,3.46649),
("Sm","F",0,2.60649),
("Sm","Cl",0,3.08749),
("Sm","Br",0,3.26649),
("Sm","I",0,3.44649),
("Sm","P",0,3.23649),
("Sm","As",0,3.30649),
("Sm","H",0,2.56649),
("Sn","O",0,2.82146),
("Sn","S",0,3.15293),
("Sn","F",0,2.63793),
("Sn","Cl",0,3.13111),
("Sn","Br",0,3.2152),
("Sn","I",0,3.52293),
("Sn","N",0,2.7152),
("Sn","Se",0,2.96646),
("Sn","Te",0,2.91642),
("Sn","P",0,2.60642),
("Sn","As",0,2.77642),
("Sn","H",0,2.00642),
("Sr","O",0,2.98095),
("Sr","S",0,3.51295),
("Sr","Se",0,3.58295),
("Sr","Te",0,3.73295),
("Sr","F",0,2.88195),
("Sr","Cl",0,3.37295),
("Sr","Br",0,3.54295),
("Sr","I",0,3.74295),
("Sr","N",0,3.09295),
("Sr","P",0,3.43295),
("Sr","As",0,3.62295),
("Sr","H",0,2.87295),
("Ta","O",0,2.74646),
("Ta","S",0,2.8439),
("Ta","F",0,2.2539),
("Ta","Cl",0,2.6739),
("Ta","Br",0,2.60642),
("Ta","I",0,2.81642),
("Ta","Se",0,2.66642),
("Ta","Te",0,2.85642),
("Ta","N",0,2.16642),
("Ta","P",0,2.62642),
("Ta","As",0,2.70642),
("Ta","H",0,1.91642),
("Tb","O",0,2.65549),
("Tb","S",0,3.11649),
("Tb","Se",0,3.23649),
("Tb","Te",0,3.42649),
("Tb","F",0,2.54249),
("Tb","Cl",0,3.04349),
("Tb","Br",0,3.18649),
("Tb","I",0,3.40945),
("Tb","N",0,2.80649),
("Tb","P",0,3.19649),
("Tb","As",0,3.26649),
("Tb","H",0,2.51649),
("Tc","O",0,2.22446),
("Tc","F",0,2.24219),
("Tc","Cl",0,2.56002),
("Te","O",0,2.3334),
("Te","S",0,2.79002),
("Te","F",0,2.22002),
("Te","Cl",0,2.73906),
("Te","Br",0,2.90002),
("Te","I",0,3.13702),
("Te","Se",0,2.57998),
("Te","Te",0,2.80998),
("Te","N",0,2.16998),
("Te","P",0,2.56998),
("Te","H",0,1.87998),
("Th","O",0,2.77349),
("Th","S",0,3.24649),
("Th","Se",0,3.36649),
("Th","Te",0,3.54649),
("Th","F",0,2.68945),
("Th","Cl",0,3.15945),
("Th","Br",0,3.31945),
("Th","I",0,3.56649),
("Th","N",0,2.94649),
("Th","P",0,3.33649),
("Th","As",0,3.40649),
("Th","H",0,2.67649),
("Ti","F",0,2.86293),
("Ti","Cl",0,3.02293),
("Ti","Br",0,3.20293),
("Ti","O",0,2.35391),
("Ti","S",0,2.74646),
("Ti","I",0,3.08291),
("Ti","Se",0,2.53642),
("Ti","Te",0,2.95642),
("Ti","N",0,2.08642),
("Ti","P",0,2.51642),
("Ti","As",0,2.87642),
("Ti","H",0,1.76642),
("Tl","O",0,3.36945),
("Tl","S",0,3.66442),
("Tl","F",0,3.26942),
("Tl","Cl",0,3.72942),
("Tl","Br",0,3.80942),
("Tl","I",0,3.94142),
("Tl","Se",0,3.00644),
("Tl","Te",0,3.23644),
("Tl","N",0,2.59644),
("Tl","P",0,3.01644),
("Tl","As",0,3.09644),
("Tl","H",0,2.35644),
("Tm","O",0,2.60649),
("Tm","S",0,3.05649),
("Tm","Se",0,3.18649),
("Tm","Te",0,3.37649),
("Tm","F",0,2.51649),
("Tm","Cl",0,2.98944),
("Tm","Br",0,3.13945),
("Tm","I",0,3.37945),
("Tm","N",0,2.74649),
("Tm","P",0,3.13649),
("Tm","As",0,3.22649),
("Tm","H",0,2.45649),
("U","O",0,2.94295),
("U","S",0,3.25293),
("U","F",0,2.80293),
("U","Cl",0,3.24452),
("U","Br",0,3.39452),
("U","I",0,3.62452),
("U","N",0,2.78649),
("U","Se",0,3.00644),
("U","Te",0,3.16644),
("U","P",0,2.94644),
("U","As",0,3.02644),
("U","H",0,2.27644),
("V","O",0,2.84939),
("V","Cl",0,3.15293),
("V","S",0,2.82293),
("V","F",0,2.87293),
("V","Br",0,2.87329),
("V","N",0,2.38329),
("V","I",0,2.66642),
("V","Se",0,2.48642),
("V","Te",0,2.72642),
("V","P",0,2.46642),
("V","As",0,2.54642),
("V","H",0,1.73642),
("W","O",0,2.20102),
("W","F",0,2.03),
("W","Cl",0,2.47),
("W","Br",0,2.49998),
("W","I",0,2.70998),
("W","S",0,2.43998),
("W","Se",0,2.55998),
("W","Te",0,2.75998),
("W","N",0,2.10998),
("W","P",0,2.50998),
("W","As",0,2.58998),
("W","H",0,1.80998),
("Xe","O",0,2.63451),
("Xe","F",0,2.62649),
("Y","O",0,2.62549),
("Y","S",0,3.08649),
("Y","Se",0,3.21649),
("Y","Te",0,3.40649),
("Y","F",0,2.51049),
("Y","Cl",0,3.00649),
("Y","Br",0,3.15649),
("Y","I",0,3.37649),
("Y","N",0,2.77649),
("Y","P",0,3.17649),
("Y","As",0,3.24649),
("Y","H",0,2.46649),
("Yb","O",0,2.74551),
("Yb","N",0,2.84851),
("Yb","S",0,3.03649),
("Yb","Se",0,3.16649),
("Yb","Te",0,3.36649),
("Yb","F",0,2.50649),
("Yb","Cl",0,2.98249),
("Yb","Br",0,3.12945),
("Yb","I",0,3.37945),
("Yb","P",0,3.13649),
("Yb","As",0,3.19649),
("Yb","H",0,2.42649),
("Zn","O",0,2.41693),
("Zn","S",0,2.80293),
("Zn","Se",0,2.93293),
("Zn","Te",0,3.16293),
("Zn","F",0,2.38293),
("Zn","Cl",0,2.72293),
("Zn","Br",0,2.86293),
("Zn","I",0,3.07293),
("Zn","N",0,2.43293),
("Zn","P",0,2.86293),
("Zn","As",0,2.95293),
("Zn","H",0,2.13293),
("Zr","O",0,3.09651),
("Zr","F",0,2.99651),
("Zr","Cl",0,3.33651),
("Zr","S",0,2.91004),
("Zr","Se",0,3.03004),
("Zr","Te",0,3.17004),
("Zr","Br",0,2.98004),
("Zr","I",0,3.19004),
("Zr","N",0,2.65004),
("Zr","P",0,3.02004),
("Zr","As",0,3.07004),
("Zr","H",0,2.29004),

	#endregion
		];
    #endregion

}