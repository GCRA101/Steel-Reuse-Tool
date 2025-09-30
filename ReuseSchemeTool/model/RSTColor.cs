using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    class RSTColor : ColorInterface
    {
        // ATTRIBUTES
        private Byte red, green, blue;

        // CONSTRUCTOR
        public RSTColor(byte red, byte green, byte blue)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public byte getRed() { return this.red; }
        public byte getGreen() { return this.green; }
        public byte getBlue() { return this.blue; }
        public byte[] getRGB() { return new byte[] { this.red, this.green, this.blue }; }
        public int getETABSIntValue(){ return (int)this.getRed() + (int)this.getGreen() * 256 + (int)this.getBlue() * 256 * 256; }


        // 


    }
}
