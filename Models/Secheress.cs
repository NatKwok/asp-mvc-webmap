using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace asp_mvc_webmap;

public partial class Secheress
{
    public int OgcFid { get; set; }

    public int? Fid { get; set; }

    public int? Secherescl { get; set; }

    public double? SumShape { get; set; }

    public double? SumShape1 { get; set; }

    public string Secherecat { get; set; }

    public MultiPolygon WkbGeometry { get; set; }
}
