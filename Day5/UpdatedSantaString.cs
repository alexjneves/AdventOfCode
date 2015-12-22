namespace Day5
{
    internal sealed class UpdatedSantaString
    {
        private readonly RepeatingPairsValidator _repeatingPairsValidator;
        private readonly RepeatingCharWithGapValidator _repeatingCharWithGapValidator;

        public UpdatedSantaString(string input)
        {
            _repeatingPairsValidator = new RepeatingPairsValidator(input);
            _repeatingCharWithGapValidator = new RepeatingCharWithGapValidator(input);
        }

        public bool IsNice()
        {
            var containsRepeatingPairs = _repeatingPairsValidator.ContainsAny();
            var containsRepeatingCharWithGap = _repeatingCharWithGapValidator.ContainsAny();

            return containsRepeatingPairs && containsRepeatingCharWithGap;
        }
    }
}