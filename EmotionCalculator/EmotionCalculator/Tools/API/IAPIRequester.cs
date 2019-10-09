using System.Drawing;
using System.Threading.Tasks;

namespace EmotionCalculator.EmotionCalculator.Tools.API
{
    interface IAPIRequester
    {
        Task<APIParseResult> RequestParseResultAsync(byte[] imageByteArray);
        Task<APIParseResult> RequestParseResultAsync(Image imageIn);
        Task<APIParseResult> RequestParseResultAsync(string imageURL);
    }
}