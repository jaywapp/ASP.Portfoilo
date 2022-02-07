using System.IO;
using System.Xml.Linq;

namespace JaywappWorld.Service.Loader
{
    public class AboutLoader
    {
        #region Properties
        public Introduce Introduce { get; private set; }
        public Education Education { get; private set; }
        public WorkExperience WorkExperience { get; private set; }
        #endregion

        #region Functions
        public static AboutLoader Load(string path)
        {
            if (!File.Exists(path))
                return null;

            var doc = XDocument.Load(path);

            if (doc.Root.Name != nameof(AboutLoader))
                return null;

            var introduceElement = doc.Root.Element(nameof(Introduce));
            var educationElement = doc.Root.Element(nameof(Education));
            var workExperienceElement = doc.Root.Element(nameof(WorkExperience));

            var about = new AboutLoader();

            if (introduceElement != null && Introduce.TryLoad(introduceElement, out Introduce introduce))
                about.Introduce = introduce;

            if (educationElement != null && Education.TryLoad(educationElement, out Education education))
                about.Education = education;

            if (workExperienceElement != null && WorkExperience.TryLoad(workExperienceElement, out WorkExperience workExperience))
                about.WorkExperience = workExperience;

            return about;
        }

        public XElement Save()
        {
            var element = new XElement(nameof(AboutLoader));

            if (Introduce != null)
                element.Add(Introduce.Save());
            if (Education != null)
                element.Add(Education.Save());
            if (WorkExperience != null)
                element.Add(WorkExperience.Save());

            return element;
        }

        public void Save(string path)
        {
            Save().Save(path);
        }
        #endregion
    }
}