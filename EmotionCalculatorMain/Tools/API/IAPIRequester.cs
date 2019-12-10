using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.API
{
    public interface IAPIRequester
    {
        Task<APIParseResult> RequestParseResultAsync(byte[] imageByteArray);
        Task<APIParseResult> RequestParseResultAsync(string imageURL);
    }
}