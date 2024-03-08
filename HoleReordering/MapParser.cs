namespace HoleReordering
{
    internal static class MapParser
    {
        public static void ParseMapData(string text, out string[] parts, out Hole[]? holes)
        {
            holes = null;

            const string MarkerString = "\"obName\":\"SingleSpawn\",\"spawnName\":\"Spawn";

            //assumptions:
            //1) immediately after MarkerString, we can read the hole number
            //2) around MarkerString we can find the local object scope { }
            //3) each MarkerString occurrence is a hole

            parts = text.Split(MarkerString);
            if (parts.Length <= 1)
                return;

            holes = new Hole[parts.Length - 1];
            for (int i = 1; i < parts.Length; ++i)
            {
                var beforeMarker = parts[i - 1];
                var afterMarker = parts[i];

                int? objectBegin = SearchScope(beforeMarker, beforeMarker.Length - 1, -1, -1);
                if (!objectBegin.HasValue)
                    throw new Exception("No hole object beginning???");

                int? objectEnd = SearchScope(afterMarker, 0, 1, 1);
                if (!objectEnd.HasValue)
                    throw new Exception("No hole object ending???");

                var beforeMarkerObject = beforeMarker.Substring(objectBegin.Value);
                parts[i - 1] = beforeMarker.Substring(0, objectBegin.Value);

                var afterMarkerObject = afterMarker.Substring(0, objectEnd.Value);
                parts[i] = afterMarker.Substring(objectEnd.Value);

                var fullObject = beforeMarkerObject + MarkerString + afterMarkerObject;
                const string ParMarker = "\"par\":";
                int parIndex = fullObject.IndexOf(ParMarker);
                if (parIndex == -1)
                {
                    throw new Exception("No par in hole object???");
                }
                int parEndIndex = fullObject.IndexOf(',', parIndex);
                if (parEndIndex == -1)
                {
                    throw new Exception("No par ending comma in hole object???");
                }
                int parFieldIndex = parIndex + ParMarker.Length;

                int spawnEndIndex = afterMarkerObject.IndexOf("\",");

                var hole = new Hole()
                {
                    ObjectBeforePar = fullObject.Substring(0, parFieldIndex),
                    ObjectAfterPar = fullObject.Substring(parEndIndex),
                    Par = int.Parse(fullObject.Substring(parFieldIndex, parEndIndex - parFieldIndex)),
                    SpawnNumber = int.Parse(afterMarkerObject.Substring(0, spawnEndIndex)),
                };

                holes[i - 1] = hole;
            }
        }

        private static int? SearchScope(string s, int start, int targetBalance, int step)
        {
            if (step == 0)
                throw new ArgumentException("Step of 0 would lead to infinite loop", nameof(step));

            int balance = 0;
            while (start >= 0 && start < s.Length)
            {
                char c = s[start];
                if (c == '{')
                {
                    balance -= 1;
                }
                else if (c == '}')
                {
                    balance += 1;
                }

                if (balance == targetBalance)
                {
                    if (step < 0)
                        start -= 1;

                    return start;
                }

                start += step;
            }

            return null;
        }
    }
}
