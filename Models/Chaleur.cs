using System;
using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace asp_mvc_webmap;

public partial class Chaleur
{
    public int OgcFid { get; set; }

    public int? Fid { get; set; }

    public int? Chaleurcl { get; set; }

    public double? SumShape { get; set; }

    public double? SumShape1 { get; set; }

    public string Chaleurcat { get; set; }

    public MultiPolygon WkbGeometry { get; set; }
}
