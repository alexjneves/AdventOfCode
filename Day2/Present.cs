namespace Day2
{
    internal sealed class Present
    {
        public int Length { get; }
        public int Width { get; }
        public int Height { get; }

        public Present(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public int CalculateSurfaceArea()
        {
            return (2 * Length * Width) + (2 * Width * Height) + (2 * Height * Length);
        }
    }
}