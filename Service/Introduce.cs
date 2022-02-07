using JaywappWorld.Service.Helper;
using System;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class Introduce
    {
        #region Properties
        public Text Name { get; }
        public DateTime Birth { get; }
        #endregion

        #region Constructor
        public Introduce(Text name, DateTime birth)
        {
            Name = name;
            Birth = birth;
        }

        public Introduce(string nameKor, string nameEng, DateTime birth)
            : this(new Text(nameKor, nameEng), birth)
        {
        }
        #endregion

        #region Functions
        public string GetBirth() => Birth.ToString("yyyy.MM.dd");

        public static bool TryLoad(XElement element, out Introduce introduce)
        {
            introduce = null;

            if (element.Name != nameof(Introduce))
                return false;

            if (!Text.TryLoad(element.Element(nameof(Name)), out Text name)
                || !element.TryGetAttributeValue(nameof(Birth), out DateTime birth))
                return false;

            introduce = new Introduce(name, birth);
            return true;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(Introduce));

            element.Add(
                Name.Save(nameof(Name)),
                new XAttribute(nameof(Birth), Birth));

            return element;
        }
        #endregion
    }
}