namespace Day6
{
    internal sealed class OnOffLight : Light
    {
        private bool _on;

        public OnOffLight()
        {
            _on = false;
        }

        protected override void TurnOn() => _on = true;

        protected override void TurnOff() => _on = false;

        protected override void Toggle() => _on = !_on;

        public bool IsOn() => _on;
    }
}