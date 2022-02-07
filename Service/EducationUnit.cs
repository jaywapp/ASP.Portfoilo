using JaywappWorld.Service.Helper;
using System;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class EducationUnit
    {
        #region Properties
        public Text Name { get; }
        public Text Major { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        #endregion

        #region Constructor
        public EducationUnit(Text name, Text major, DateTime start, DateTime end)
        {
            Name = name;
            Major = major;
            Start = start;
            End = end;
        }

        public EducationUnit(string nameKor, string nameEng, string majorKor, string majorEng, DateTime start, DateTime end)
            : this(new Text(nameKor, nameEng), new Text(majorKor, majorEng), start, end)
        {
        }
        #endregion

        #region Functions
        public string GetTerm() => $"{Start.ToString("yyyy.MM")} ~ {End.ToString("yyyy.MM")}";

        public static bool TryLoad(XElement element, out EducationUnit education)
        {
            education = null;

            if (element.Name != nameof(EducationUnit))
                return false;

            if (!Text.TryLoad(element.Element(nameof(Name)), out Text name)
                || !Text.TryLoad(element.Element(nameof(Major)), out Text major)
                || !element.TryGetAttributeValue(nameof(Start), out DateTime start)
                || !element.TryGetAttributeValue(nameof(End), out DateTime end))
                return false;

            education = new EducationUnit(name, major, start, end);
            return true;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(EducationUnit));

            element.Add(
                Name.Save(),
                Major.Save(),
                new XAttribute(nameof(Start), Start),
                new XAttribute(nameof(End), End));

            return element;
        }
        #endregion
    }
}