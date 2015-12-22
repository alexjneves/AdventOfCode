namespace Day6
{
    internal sealed class Light
    {
        private bool _on;

        public Light()
        {
            _on = false;
        }

        public void ExecuteInstruction(LightInstruction instruction)
        {
            switch (instruction)
            {
                case LightInstruction.On:
                    TurnOn();
                    break;
                case LightInstruction.Off:
                    TurnOff();
                    break;
                case LightInstruction.Toggle:
                    Toggle();
                    break;
            }
        }

        private void TurnOn()
        {
            _on = true;
        }

        private void TurnOff()
        {
            _on = false;
        }

        private void Toggle()
        {
            _on = !_on;
        }

        public bool IsOn() => _on;
    }
}