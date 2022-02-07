using JaywappWorld.Service.Helper;
using System;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class WorkExperienceUnit
    {
        #region Properties
        public Text Name { get; }
        public Text Position { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        #endregion

        #region Constructor
        public WorkExperienceUnit(Text name, Text position, DateTime start, DateTime end)
        {
            Name = name;
            Position = position;
            Start = start;
            End = end;
        }

        public WorkExperienceUnit(string nameKor, string nameEng, string positionKor, string positionEng, DateTime start, DateTime end)
            : this(new Text(nameKor, nameEng), new Text(positionKor, positionEng), start, end)
        {
        }
        #endregion

        #region Functions
        public string GetTerm() => $"{Start.ToString("yyyy.MM")} ~ {End.ToString("yyyy.MM")}";

        public static bool TryLoad(XElement element, out WorkExperienceUnit experience)
        {
            experience = null;

            if (element.Name != nameof(WorkExperienceUnit))
                return false;

            if (!Text.TryLoad(element.Element(nameof(Name)), out Text name)
                || !Text.TryLoad(element.Element(nameof(Position)), out Text position)
                || !element.TryGetAttributeValue(nameof(Start), out DateTime start)
                || !element.TryGetAttributeValue(nameof(End), out DateTime end))
                return false;

            experience = new WorkExperienceUnit(name, position, start, end);
            return true;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(WorkExperienceUnit));

            element.Add(
                Name.Save(),
                Position.Save(),
                new XAttribute(nameof(Start), Start),
                new XAttribute(nameof(End), End));

            return element;
        }
        #endregion
    }
}