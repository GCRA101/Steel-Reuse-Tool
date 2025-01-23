using ReuseSchemeTool.model;
using ReuseSchemeTool.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReuseSchemeTool.controller
{
    public class RST_Controller : ControllerInterface
    {

        // ATTRIBUTES
        // References to Model and View
        public RST_Model model { get; set; }
        public RST_View view { get; set; }
        // Reference to Revit UI Application
        public Autodesk.Revit.UI.UIApplication uiApp { get; set; }
        // ExceptionHandlers
        public MissingInputsHandler missingInputsHandler { get; set; }
        // EventListeners
        public EventsListener eventsListener { get; set; }
        // AudioManagers
        public SoundManager soundManager { get; set; }
        // Other Variables
        public string jsonFilePath { get; set; }



        public RST_Controller(Autodesk.Revit.UI.UIApplication uiApp)
        {
            //Instantiate the Model
            this.model = RST_Model.getInstance();
            this.model.uiApp = uiApp;
            //Instantiate the View
            this.view = new RST_View(this.model, this);
            //Instantiate AudioManagers
            this.soundManager = SoundManager.getInstance();
            //Instatiate EventsListener
            this.eventsListener = new EventsListener(this, this.view);
            //Instantiate ExceptionHandlers
            this.createExceptionHandlers();
        }

        public void createExceptionHandlers()
        {
            this.missingInputsHandler = new MissingInputsHandler(this);
        }

        public void deserialize()
        {
            throw new NotImplementedException();
        }

        public void initialize()
        {
            //Show the SplashScreen
            this.view.createSplashScreen();
            //Show the AboutBox
            this.view.createAboutBox();
            //Activate the EventsListener of the AboutBox
            this.eventsListener.initializeAboutBox();
        }

        public void run()
        {
            throw new NotImplementedException();
        }

        public void serialize()
        {
            throw new NotImplementedException();
        }

        public void terminate()
        {
            //Close and dispose the form
            //this.view.getInputsView.close();
            //this.view.getInputsView.dispose();

        }


        public void processInputData()
        {
            // 1. Get the Input Data from the UI

            // SECTION TYPES
            //Get the list of section types selected by the user in the UI by the help of an Enumerator
            List<string> selSectionTypes = new List<string>();
            IEnumerator<string> enumerator = this.view.inputsView.clbSectionTypes.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSectionTypes.Add(enumerator.Current); }

            // STEEL GRADES
            //Get the list of steel grades selected by the user in the UI by the help of an Enumerator
            List<string> selSteelGrades = new List<string>();
            enumerator = this.view.inputsView.clbSteelGrades.CheckedItems.Cast<String>().GetEnumerator();
            while (enumerator.MoveNext()) { selSteelGrades.Add(enumerator.Current); }

            // MAX/MIN LENGHTS
            Single[] lengthsRange = {
                Single.Parse(this.view.inputsView.lblMinLengthValue.Text),
                Single.Parse(this.view.inputsView.lblMaxLengthValue.Text)
            };

            // MAX/MIN WEIGHTS
            Single[] weightsRange = {
                Single.Parse(this.view.inputsView.lblMinWeightValue.Text),
                Single.Parse(this.view.inputsView.lblMaxWeightValue.Text)
            };





            '2. Initialize the Model

        Me.model.initialize(Me.SapModel, pDispFilePath, selLoadCombo, selGroup,
                            CInt(Me.view.getViewInputs().cbIterations.Items(Me.view.getViewInputs().cbIterations.SelectedIndex)),
                            CDbl(Strings.Split(CStr(Me.view.getViewInputs().cbDispVariation.
                            Items(Me.view.getViewInputs().cbDispVariation.SelectedIndex)), "%")(0)) / 100.0)

        'Retain only points belonging to selected Group

        Me.model.filterPointsByGroup()



        '3. Set Up the pile objects restraints/stiffnesses based on input criteria


        If Me.view.getViewInputs().rbRigid.Checked = True Then

            ' Rigid Piles

            Dim restraintBools As Boolean() = { True, True, True, False, False, False}
            Me.model.setPointRestraints(restraintBools)

        ElseIf Me.view.getViewInputs().rbSpring.Checked = True Then

            ' Constant Stiffness Piles

            If Me.view.getViewInputs().tbStiffness.Text() = "" Then Throw New MissingInputsException("Piles Stiffness Missing")
			Dim stiffness_Nmm As Double = CDbl(Me.view.getViewInputs().tbStiffness.Text()) * 1000

            Dim stiffnessValues As Double() = { 0.0, 0.0, stiffness_Nmm, 0.0, 0.0, 0.0}
            Me.model.setPointStiffnessesFromValues(stiffnessValues)

        ElseIf Me.view.getViewInputs().rbImportFromFile.Checked = True Then

            ' Input Json Stiffness Piles

            Me.model.setPointStiffnessesFromJson(Me.getJsonFilePath())

            Me.model.setPileObjsInit(Me.model.deserialize(Me.getJsonFilePath))

        End If





        }

    }

}
