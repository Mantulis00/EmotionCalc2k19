using EmotionCalculator.EmotionCalculator.Tools.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmotionCalculator.EmotionCalculator.Tools.API.Face
{
    class FaceAPIParser
    {
        internal static FaceAPIParseResult ParseJSON(string jsonString)
        {
            //JsonTextReader reference:
            //https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonTextReader.htm
            //JSON structure reference:
            //https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236

            var faces = new List<FaceData>();
            var errors = new List<ErrorLog>();

            using (StringReader stringReader = new StringReader(jsonString))
            using (JsonTextReader jsonReader = new JsonTextReader(stringReader))
            {
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType == JsonToken.StartObject)
                    {
                        //NEW OBJECT
                        JObject jObject = JObject.Load(jsonReader);

                        List<JProperty> children = jObject.Properties().ToList();

                        FaceData face = new FaceData();
                        bool faceFound = true;

                        foreach (var child in children)
                        {
                            string childName = child.Name;

                            switch (childName)
                            {
                                case "error":
                                    {
                                        errors.Add(ParseError(child));

                                        faceFound = false;
                                    }
                                    break;
                                case "faceId":
                                    {
                                        face.Id = ParseId(child);
                                    }
                                    break;
                                case "faceRectangle":
                                    {
                                        //...
                                    }
                                    break;
                                case "faceAttributes":
                                    {
                                        face.EmotionData = ParseEmotions(child);
                                    }
                                    break;
                            }
                        }

                        if (faceFound)
                        {
                            faces.Add(face);
                        }
                    }
                }
            }

            return new FaceAPIParseResult(faces, errors);
        }

        private static ErrorLog ParseError(JProperty property)
        {
            JObject supaObject = JObject.Parse(property.Children().First().ToString());
            List<JProperty> properties = supaObject.Properties().ToList();

            string code = properties.Where(prop => prop.Name == "code").First().Value.ToString();
            string message = properties.Where(prop => prop.Name == "message").First().Value.ToString();

            return new ErrorLog(code, message);
        }

        private static EmotionData ParseEmotions(JProperty property)
        {
            JToken emotions = property.First().First().First();

            return new EmotionData(
                emotions.Value<float>("anger"),
                emotions.Value<float>("contempt"),
                emotions.Value<float>("disgust"),
                emotions.Value<float>("fear"),
                emotions.Value<float>("happiness"),
                emotions.Value<float>("neutral"),
                emotions.Value<float>("sadness"),
                emotions.Value<float>("surprise"));
        }

        private static string ParseId(JProperty property)
        {
            List<JToken> children = property.Children().ToList();

            if (children.Count == 1
                && children[0].Type == JTokenType.String)
            {
                return children[0].Value<string>();
            }
            else
            {
                //incorrect faceId
            }

            return "";
        }
    }
}
