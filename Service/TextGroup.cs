namespace JaywappWorld.Service
{
    public class TextGroup
    {
        #region Properties
        public Text Text1 { get; set; }
        public Text Text2 { get; set; }
        public Text Text3 { get; set; }
        #endregion

        #region Constructor
        public TextGroup() { }

        public TextGroup(Text text1) : this()
        {
            Text1 = text1;
        }

        public TextGroup(Text text1, Text text2) : this(text1)
        {
            Text2 = text2;
        }

        public TextGroup(Text text1, Text text2, Text text3) : this(text1, text2)
        {
            Text3 = text3;
        }
        #endregion
    }
}