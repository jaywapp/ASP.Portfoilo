using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace JaywappWorld.Service
{
    public class WorkExperience
    {
        #region Properties
        public List<WorkExperienceUnit> Units { get; }
        #endregion

        #region Constructor
        public WorkExperience()
        {
            Units = new List<WorkExperienceUnit>();
        }

        public WorkExperience(IEnumerable<WorkExperienceUnit> units)
        {
            Units = units.ToList();
        }
        #endregion

        #region Functions
        public static bool TryLoad(XElement element, out WorkExperience education)
        {
            education = null;

            if (element.Name != nameof(WorkExperience))
                return false;

            education = new WorkExperience();

            var subElements = element.Elements().ToList();

            foreach (var subElement in subElements)
            {
                if (!WorkExperienceUnit.TryLoad(subElement, out WorkExperienceUnit unit))
                    continue;

                education.Units.Add(unit);
            }

            return true;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(WorkExperience));

            foreach (var unit in Units)
                element.Add(unit.Save());

            return element;
        }
        #endregion
    }
}