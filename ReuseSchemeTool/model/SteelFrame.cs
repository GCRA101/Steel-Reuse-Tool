using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public abstract class SteelFrame : FrameDecorator
    {
        // ATTRIBUTES
        private SteelSectionType sectionType;

        // CONSTRUCTORS
        public SteelFrame(Frame frame) : base(frame) 
        {
            this.acquireSectionType();
        }


        // METHODS
        private void acquireSectionType()
        {

            Array sstypes = Enum.GetValues(typeof(SteelSectionType));
            Dictionary<string, SteelSectionType> ssTypeNames = new Dictionary<string, SteelSectionType>();
            foreach (var sstype in sstypes) ssTypeNames.Add(sstype.ToString(),(SteelSectionType)sstype);

            string sectionTypeName = new string(this.frame.getSection().getName().ToUpper().TakeWhile(ch => ((!char.IsDigit(ch)) && (!char.IsWhiteSpace(ch)))).ToArray());
            KeyValuePair<string,SteelSectionType> searchType =ssTypeNames.FirstOrDefault(ssTypeName => sectionTypeName == ssTypeName.Key);

            if ((searchType.Key!=null)&&(searchType.Value != null)) this.sectionType=searchType.Value;

        }

        public SteelSectionType getSectionType() { return this.sectionType; }


    }
}
