using EmotionCalculator.EmotionCalculator.Tools.Errors;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Tools.API
{
    public class APIParseResult
    {
        private readonly List<FaceData> faces = new List<FaceData>();
        private readonly List<ErrorLog> errors = new List<ErrorLog>();

        public IReadOnlyList<FaceData> Faces { get { return faces.AsReadOnly(); } }
        public IReadOnlyList<ErrorLog> Errors { get { return errors.AsReadOnly(); } }

        internal APIParseResult(IEnumerable<FaceData> faces, IEnumerable<ErrorLog> errors)
        {
            this.faces.AddRange(faces);
            this.errors.AddRange(errors);
        }
    }
}