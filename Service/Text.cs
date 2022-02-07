using JaywappWorld.Service.Helper;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class Text
    {
        #region Properties
        public string Kor { get; }
        public string Eng { get; }
        #endregion

        #region Constructor
        public Text(string text) 
        {
            Kor = text;
            Eng = text;
        }

        public Text(string kor, string eng) 
        {
            Kor = kor;
            Eng = eng;
        }
        #endregion

        #region Functions
        public string GetText()
        {
            if (string.IsNullOrEmpty(Kor) && !string.IsNullOrEmpty(Eng))
                return Kor;
            else if (!string.IsNullOrEmpty(Kor) && string.IsNullOrEmpty(Eng))
                return Eng;

            return GlobalProperties.Language == eLanguage.Kor ? Kor : Eng;
        }

        public static bool TryLoad(XElement element, out Text text)
        {
            text = null;

            if (!element.TryGetAttributeValue(nameof(Kor), out string kor)
                || !element.TryGetAttributeValue(nameof(Eng), out string eng))
                return false;

            text = new Text(kor, eng);
            return true;
        }

        public XElement Save(string name = null)
        {
            var element = new XElement(name ?? nameof(Text));

            element.Add(
                new XAttribute(nameof(Kor), Kor), 
                new XAttribute(nameof(Eng), Eng));

            return element;
        }
        #endregion
    }
}