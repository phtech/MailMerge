using System.Xml;

namespace MailMerge
{
    public static class XmlNodeExtensions
    {
        /// <summary>Abbreviation for <paramref name="me"></paramref><c>.ParentNode.RemoveChild(me)</c></summary>
        /// <param name="me"></param>
        public static void RemoveMe(this XmlNode me) => me.ParentNode.RemoveChild(me);

        public static string EscapeXmlCharacters(this string input)
        {
            switch (input)
            {
                case null: return null;
                case "": return "";
                default:
                {
                    input = 
                        input
                        .Replace("&", "&amp;")
                        .Replace(">", "&gt;")
                        .Replace("<", "&lt;");

                    return input;
                }
            }
        }
        
    }
}