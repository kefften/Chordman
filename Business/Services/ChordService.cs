using ChordMan.Models;
using ChordMan.ExtensionMethods;

namespace ChordMan.Business.Services;

public class ChordService : IChordService
{
    public Dictionary<ChordFunction, List<Chord>> GetAvailableChords(Chord chord, ChromaticScale key)
    {
        var availableChords = new Dictionary<ChordFunction, List<Chord>>();
        
        switch (chord.Function)
        { 
            case ChordFunction.Main:
                var mainChords = GetMainChords(key);
                var modalChangeChords = GetModalChangeChords(key);
                var secondaryDominantChords = GetSecondaryDominants(key);
                
                availableChords.Add(ChordFunction.Main, mainChords);
                availableChords.Add(ChordFunction.ModalChange, modalChangeChords);
                availableChords.Add(ChordFunction.SecondaryDominant, secondaryDominantChords);
                break;
            
            case ChordFunction.ModalChange:
                
                modalChangeChords = GetModalChangeChords(key);
                secondaryDominantChords = GetSecondaryDominants(key)
                    .Select(x => { x.Available = false; return x; })
                    .ToList();
                mainChords = GetMainChords(key)
                    .Select(x => { 
                        x.Available = 
                            x.Interval == ChordInterval.I || 
                            x.Interval == ChordInterval.IV || 
                            x.Interval == ChordInterval.V;
                        return x;
                    })
                    .ToList();
                
                availableChords.Add(ChordFunction.Main, mainChords);
                availableChords.Add(ChordFunction.ModalChange, modalChangeChords);
                availableChords.Add(ChordFunction.SecondaryDominant, secondaryDominantChords);
                break;
            
            case ChordFunction.SecondaryDominant:

                secondaryDominantChords = GetSecondaryDominants(key)
                    .Select(x =>
                    {
                        x.Available = false;
                        return x;
                    })
                    .Select(x =>
                    {
                        x.Available =
                            x.RootNote == chord.RootNote;
                        return x;
                    }).ToList();
                modalChangeChords = GetModalChangeChords(key)
                    .Select(x => { x.Available = false; return x; })
                    .ToList();
                mainChords = GetMainChords(key)
                    .Select(x =>
                    {
                        x.Available = x.Interval == chord.Interval;
                        return x;
                    }).ToList();
                
                availableChords.Add(ChordFunction.Main, mainChords);
                availableChords.Add(ChordFunction.ModalChange, modalChangeChords);
                availableChords.Add(ChordFunction.SecondaryDominant, secondaryDominantChords);
                break;
        }
        return availableChords;
    }
    
    public List<Chord> GetSecondaryDominants(ChromaticScale key)
    {
        var chords = new List<Chord>()
        {
            GetSecondaryDominantChord((int)ChordInterval.I, key),
            GetSecondaryDominantChord((int)ChordInterval.VI, key),
            GetSecondaryDominantChord((int)ChordInterval.IV, key),
            GetSecondaryDominantChord((int)ChordInterval.II, key),
            GetSecondaryDominantChord((int)ChordInterval.V, key),
            GetSecondaryDominantChord((int)ChordInterval.III, key),
        };

        return chords;
    }
    
    public List<Chord> GetMainChords(ChromaticScale key)
    {
        var chords = new List<Chord>()
        {
            GetMainChord((int)ChordInterval.I, key),
            GetMainChord((int)ChordInterval.VI, key),
            GetMainChord((int)ChordInterval.IV, key),
            GetMainChord((int)ChordInterval.II, key),
            GetMainChord((int)ChordInterval.V, key),
            GetMainChord((int)ChordInterval.III, key),
        };

        return chords;
    }



    public List<Chord> GetModalChangeChords(ChromaticScale key)
    {
        var chords = new List<Chord>()
        {
            GetModalChangeChord((int)ChordInterval.III, key, ChordQuality.Major),
            GetModalChangeChord((int)ChordInterval.VI, key, ChordQuality.Major),
            GetModalChangeChord((int)ChordInterval.IV, key, ChordQuality.Minor),
            GetModalChangeChord((int)ChordInterval.VII, key, ChordQuality.Major),
        };
        return chords;
    }

    private Chord GetModalChangeChord(int interval, ChromaticScale key, ChordQuality quality)
    {
        var chord = GetChordFromInterval(interval, key, ChordFunction.ModalChange);
        chord.Quality = quality;
        return chord;
    }
    
    private Chord GetSecondaryDominantChord(int interval, ChromaticScale key)
    {
        var chord = GetChordFromInterval(interval, key + 4.GetSteps());
        chord.Function = ChordFunction.SecondaryDominant;
        chord.Extension = ChordExtension.Seventh;
        return chord;
    }
    
    private Chord GetMainChord(int interval, ChromaticScale key)
    {
        var chord = GetChordFromInterval(interval, key);
        chord.Function = ChordFunction.Main;
        chord.Extension = ChordExtension.None;
        return chord;
    }

    public Chord GetChordFromInterval(int interval, ChromaticScale key, ChordFunction function = ChordFunction.Main)
    {
        var stepPosition = interval - 1;
        var chord = new Chord();
        var moves = (int)key + stepPosition.GetSteps();
        var chromaticScale = Enum
            .GetValues(typeof(ChromaticScale))
            .Cast<int>()
            .ToArray();
        var qualityOrder = Orders.MajorQuality
            .ToList()
            .Select(x => (int)x)
            .ToArray();

        if (function == ChordFunction.ModalChange)
        {
            moves--;
            chord.Function = ChordFunction.ModalChange;
            chord.Extension = ChordExtension.None;
        }
        
        chord.RootNote = (ChromaticScale)chromaticScale.GetWrappedIndex(moves);
        chord.Quality = Orders.MajorQuality[qualityOrder.GetWrappedIndex(stepPosition)];
        chord.Interval = (ChordInterval)interval;
        chord.Available = true;

        return chord;
    }
}