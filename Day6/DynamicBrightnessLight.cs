namespace Day6
{
    internal sealed class DynamicBrightnessLight : Light
    {
        public int Brightness { get; private set; }

        public DynamicBrightnessLight()
        {
            Brightness = 0;
        }

        protected override void TurnOn() => ++Brightness;

        protected override void TurnOff()
        {
            if (Brightness > 0)
            {
                --Brightness;
            }
        }

        protected override void Toggle() => Brightness += 2;
    }
}