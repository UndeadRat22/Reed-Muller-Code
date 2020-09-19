namespace Communication.Codes.ReedMuller
{
    public class ReedMullerDecoder : IDecoder
    {
        private readonly ReedMullerGeneratorMatrix _generatorMatrix;
        public ReedMullerDecoder(int r, int m)
        {
            _generatorMatrix = new ReedMullerGeneratorMatrix(r, m);
        }

        public byte[] Decode(Message bits)
        {
            return null;
        }
    }
}