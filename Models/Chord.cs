using System.ComponentModel;

namespace ChordMan.Models;

public class Chord
{
    public ChromaticScale RootNote { get; set; }
    public ChordQuality Quality { get; set; }
    public ChordFunction Function { get; set; }
    public ChordInterval Interval { get; set; }
    public ChordExtension Extension { get; set; }
    
    public bool Available { get; set; }
}

public enum ChromaticScale
{
    [Description("C")]
    C = 0,
    [Description("C#")]
    CSharp = 1,
    [Description("D")]
    D = 2,
    [Description("D#")]
    DSharp = 3,
    [Description("E")]
    E = 4,
    [Description("F")]
    F = 5,
    [Description("F#")]
    FSharp = 6,
    [Description("G")]
    G = 7,
    [Description("G#")]
    GSharp = 8,
    [Description("A")]
    A = 9,
    [Description("A#")]
    ASharp = 10,
    [Description("B")]
    B = 11
}
public enum ChordQuality
{
    [Description("")]
    Major = 0,
    [Description("m")]
    Minor = 1,
    [Description("dim")]
    Diminished = 2,
}
public enum ChordInterval
{
    I = 1,
    II = 2,
    III = 3,
    IV = 4,
    V = 5,
    VI = 6,
    VII = 7   
}
public enum ChordExtension
{
    [Description("")]
    None = 0,
    [Description("7")]
    Seventh = 7,
    [Description("maj7")]
    MajorSeventh = 107,
    [Description("9")]
    Ninth = 9,   
    [Description("11")]
    Eleventh = 11,
    [Description("13")]
    Thirteenth = 13,
    [Description("add9")]
    Add9 = 109,   
    [Description("add11")]
    Add11 = 111,
    [Description("add13")]
    Add13 = 113
}


public enum ChordFunction
{
    Main,
    ModalChange,
    SecondaryDominant
}

public static class Orders
{
    public static readonly int[] MajorStepOrder =
    [
        2,2,1,2,2,2,1
    ];
    public static readonly ChordQuality[] MajorQualityOrder =
    [
        ChordQuality.Major , 
        ChordQuality.Minor, 
        ChordQuality.Minor, 
        ChordQuality.Major, 
        ChordQuality.Major, 
        ChordQuality.Minor, 
        ChordQuality.Diminished
    ];
    
}