using EmotionCalculator.EmotionCalculator.Tools.Errors;
using System.Collections.Generic;

namespace EmotionCalculator.EmotionCalculator.Tools.API
{
    internal class APIParseResult
    {
        private List<FaceData> faces = new List<FaceData>();
        private List<ErrorLog> errors = new List<ErrorLog>();

        internal IReadOnlyList<FaceData> Faces { get { return faces.AsReadOnly(); } }
        internal IReadOnlyList<ErrorLog> Errors { get { return errors.AsReadOnly(); } }

        internal APIParseResult(IEnumerable<FaceData> faces, IEnumerable<ErrorLog> errors)
        {
            this.faces.AddRange(faces);
            this.errors.AddRange(errors);
        }
    }
}