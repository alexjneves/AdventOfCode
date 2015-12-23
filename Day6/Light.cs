namespace Day6
{
    internal abstract class Light
    {
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

        protected abstract void TurnOn();

        protected abstract void TurnOff();

        protected abstract void Toggle();

    }
}