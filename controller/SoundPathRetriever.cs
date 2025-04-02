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
                    return "ReuseSchemeTool.controller.sounds.SPLASHSCREEN.wav";
                    break;
                case Sound.CLICKBUTTON:
                    return "ReuseSchemeTool.controller.sounds.CLICKBUTTON.wav";
                    break;
                case Sound.CHECKBOX:
                    return "ReuseSchemeTool.controller.sounds.CHECKBOX.wav";
                    break;
                case Sound.WARNING:
                    return "ReuseSchemeTool.controller.sounds.WARNING.wav";
                    break;
                case Sound.END_INSPECTION:
                    return "ReuseSchemeTool.controller.sounds.ENDINSPECTION.wav";
                    break;
                case Sound.END_SCHEME:
                    return "ReuseSchemeTool.controller.sounds.ENDSCHEME.wav";
                default:
                    return "";
                    break;
            }
            return null;
        }


    }
}
