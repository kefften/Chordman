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
    C = 0,
    CSharp = 1,
    D = 2,
    DSharp = 3,
    E = 4,
    F = 5,
    FSharp = 6,
    G = 7,
    GSharp = 8,
    A = 9,
    ASharp = 10,
    B = 11
}
public enum ChordQuality
{
    Major = 0,
    Minor = 1,
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
    None = 0,     // No extension
    Seventh = 7,  // Dominant 7th (C7)
    MajorSeventh = 107, // Major 7th (Cmaj7)
    Ninth = 9,    // C9
    Eleventh = 11,// C11
    Thirteenth = 13, // C13
    Add9 = 109,   // Cadd9 (Distinct from C9)
    Add11 = 111,  // Cadd11
    Add13 = 113   // Cadd13
}


public enum ChordFunction
{
    Main,
    ModalChange,
    SecondaryDominant
}

public static class Orders
{
    // public static Dictionary<ChordFunction, List<Chord>> AllChords = new()
    // {
    //     { ChordFunction.Main, new List<Chord> 
    //         { 
    //             new Chord()
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.I,
    //             },
    //             new Chord()                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.II,
    //             },
    //             new Chord()                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.III,
    //             },
    //             new Chord()                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.IV,
    //             },
    //             new Chord()                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.V,
    //             },
    //             new Chord(                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.VI,
    //             },
    //             new Chord(                
    //             {
    //                 Function = ChordFunction.Main,
    //                 Interval = ChordIntervals.VII,
    //             },
    //         }
    //     },
    //     { ChordFunction.ModalChange, new List<Chord> 
    //         { 
    //             new Chord()
    //             {
    //                 Function = ChordFunction.ModalChange,
    //                 Interval = ChordIntervals.III,
    //                 ChordQuality = ChordQuality.Major
    //             },
    //             new Chord()
    //             {
    //                 Function = ChordFunction.ModalChange,
    //                 Interval = ChordIntervals.IV,
    //                 ChordQuality = ChordQuality.Minor
    //             },
    //             new Chord()
    //             {
    //                 Function = ChordFunction.ModalChange,
    //                 Interval = ChordIntervals.VI,
    //                 ChordQuality = ChordQuality.Major
    //             },
    //             new Chord()
    //             {
    //                 Function = ChordFunction.ModalChange,
    //                 Interval = ChordIntervals.VII,
    //                 ChordQuality = ChordQuality.Major
    //             },
    //         }
    //     },
    //     { ChordFunction.Subdominant, new List<Chord> 
    //         { 
    //             new Chord()
    //             {
    //                 Function = ChordFunction.Subdominant,
    //                 Interval = ChordIntervals.I + 4,
    //             },
    //             new Chord(),
    //             new Chord(),
    //             new Chord(),
    //             new Chord(),
    //             new Chord()
    //         }
    //     }
    // };


    public static readonly int[] StepOrder =
    [
        2,2,1,2,2,2,1
    ];
    public static readonly ChordQuality[] MajorQuality =
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