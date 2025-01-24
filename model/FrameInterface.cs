using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public interface FrameInterface
    {
        // Setters
        void setSection(Section section);
        void setMaterial(String material);
        void setLength(Double length);
        void setUniqueId(String uniqueId);
        void setGeometry(Line geometry);
        void setType(FrameType type);

        // Getters
        Section getSection();
        String getMaterial();
        Double getLength();
        String getUniqueId();
        Line getGeometry();
        FrameType getType();
    }
}
