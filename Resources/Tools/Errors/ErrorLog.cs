namespace EmotionCalculator.EmotionCalculator.Tools.Errors
{
    public struct ErrorLog
    {
        public string Code { get; private set; }
        public string Message { get; private set; }

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