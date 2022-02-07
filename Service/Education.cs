using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class Education
    {
        #region Properties
        public List<EducationUnit> Units { get; }
        #endregion

        #region Constructor
        public Education()
        {
            Units = new List<EducationUnit>();
        }

        public Education(IEnumerable<EducationUnit> units)
        {
            Units = units.ToList();
        }
        #endregion

        #region Functions
        public static bool TryLoad(XElement element, out Education education)
        {
            education = null;

            if (element.Name != nameof(Education))
                return false;

            education = new Education();

            var subElements = element.Elements().ToList();

            foreach(var subElement in subElements)
            {
                if (!EducationUnit.TryLoad(subElement, out EducationUnit unit))
                    continue;

                education.Units.Add(unit);
            }

            return true;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(Education));

            foreach (var unit in Units)
                element.Add(unit.Save());

            return element;
        }
        #endregion
    }
}