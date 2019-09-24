namespace EmotionCalculator.EmotionCalculator.Tools.Errors
{
    internal struct ErrorLog
    {
        internal string Code { get; private set; }
        internal string Message { get; private set; }

        internal ErrorLog(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public override string ToString()
        {
            return $"{Code} : {Message}";
        }
    }
}