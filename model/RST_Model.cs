using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.model
{
    public class RST_Model : Observable
    {

        // ATTRIBUTES
        private static RST_Model instance;
        private List<Observer> observers;
        private JSONSerializer<List<FrameDecorator>> jsonSerializer;
        private List<ExistingSteelFrame> existingSteelFrames;
        private List<ProposedSteelFrame> proposedSteelFrames;
        public Autodesk.Revit.UI.UIApplication uiApp;
        public Autodesk.Revit.UI.UIDocument uiDoc;



        private const string MODEL_NAME = "Reuse Scheme Tool";
        private const string MODEL_VERSION = "Version: " + "1.0.0";
        private const string MODEL_COPYRIGHT = "Copyright @ Buro Happold Ltd Inc.2024";
        private const string MODEL_AUTHOR = "Giorgio Carlo Roberto Albieri";
        private const string MODEL_OWNER = "Buro Happold Ltd";




        // STATIC METHOD .getInstance()
        public static RST_Model getInstance()
        {
            if (instance==null) return new RST_Model();
            return instance;
        }

        // CONSTRUCTOR - Private
        private RST_Model() 
        { 
            this.observers= new List<Observer>();
            this.jsonSerializer= new JSONSerializer<List<FrameDecorator>>();
            this.existingSteelFrames = new List<ExistingSteelFrame>();
            this.proposedSteelFrames = new List<ProposedSteelFrame>();
        
        }


        public void initialize(Autodesk.Revit.UI.UIApplication uiApp)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
            this.uiDoc = uiApp.ActiveUIDocument;

        }

        public void runScheming()
        {

        }


        public void setRevitUIApp(Autodesk.Revit.UI.UIApplication uiApp)
        {
            if (uiApp == null) throw new MissingInputsException("Revit UI Application is missing/not valid.");
            this.uiApp = uiApp;
        }

        // METHODS

        public void registerObserver(Observer o){this.observers.Add(o);}
        public void removeObserver(Observer o){this.observers.Remove(o);}
        public void notifyObservers(){this.observers.ForEach(o=>o.update());}

    }
}
