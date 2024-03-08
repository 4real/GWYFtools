namespace HoleReordering
{
    internal sealed class Hole
    {
        //"object" as in Json terminology
        public string ObjectBeforePar;
        public string ObjectAfterPar;

        public int SpawnNumber;
        public int Par;

        public string Object => ObjectBeforePar + Par + ObjectAfterPar;

        public override string ToString()
        {
            return "Hole " + SpawnNumber + "\t Par " + Par;
        }
    }
}
