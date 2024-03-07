namespace HoleReordering
{
    internal sealed class Hole
    {
        //text indices
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
