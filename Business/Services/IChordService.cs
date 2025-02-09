using ChordMan.Models;

namespace ChordMan.Business.Services;

public interface IChordService
{
    public Dictionary<ChordFunction, List<Chord>> GetAvailableChords(Chord chord, ChromaticScale key);
    public List<Chord> GetMainChords(ChromaticScale key);
    public List<Chord> GetSecondaryDominants(ChromaticScale key);
    public List<Chord> GetModalChangeChords(ChromaticScale key);
    public Chord GetChordFromInterval(int interval, ChromaticScale key, ChordFunction function = ChordFunction.Main);
}