using ChordMan.Models;

namespace ChordMan.Helpers;

public class Helpers
{
    public static bool TryParseNumberToEnum(int number, out ChromaticScale note)
    {
        if (Enum.IsDefined(typeof(ChromaticScale), number))
        {
            note = (ChromaticScale)number;
            return true;
        }
        note = default; // Assigns C (0) by default
        return false;
    }

}