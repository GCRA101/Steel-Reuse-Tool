using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ReuseSchemeTool.controller
{
    
    public static class SoundPathRetriever
    {
        //METHODS
        public static string getPath(Sound sound) {
            switch (sound)
            {
                case Sound.SPLASHSCREEN:
                    return "ReuseSchemeTool.sounds.SPLASHSCREEN.wav";
                    break;
                case Sound.CLICKBUTTON:
                    return "ReuseSchemeTool.sounds.CLICKBUTTON.wav";
                    break;
                case Sound.CHECKBOX:
                    return "ReuseSchemeTool.sounds.CHECKBOX.wav";
                    break;
                case Sound.WARNING:
                    return "ReuseSchemeTool.sounds.WARNING.wav";
                    break;
                case Sound.ENDRUN:
                    return "ReuseSchemeTool.sounds.ENDRUN.wav";
                    break;
                default:
                    return "";
                    break;
            }
            return null;
        }


    }
}
