using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace ReuseSchemeTool.model.revit
{
    public class ViewsFactory
    {
        /* ATTRIBUTES */
        private Autodesk.Revit.DB.Document dbDoc;
        private static ViewsFactory instance;

        /* CONSTRUCTOR */
        private ViewsFactory() { }


        /* METHODS */
        public static ViewsFactory getInstance()
        {
            if (instance == null) return instance=new ViewsFactory();
            return instance;
        }

        public Autodesk.Revit.DB.View create(Autodesk.Revit.DB.Document dbDoc, 
            RevitViewType viewType, String name, int scale)
        {
            this.dbDoc= dbDoc;

            switch (viewType)
            {
                case (RevitViewType.THREE_D):
                    return this.createView3D(name, scale);
                case (RevitViewType.PLAN):
                    return this.createViewPlan(name, scale);
                case (RevitViewType.DRAFTING):
                    return this.createViewDrafting(name, scale);
                case (RevitViewType.SECTION):
                    return this.createViewSection(name, scale);
                case (RevitViewType.SHEET):
                    return this.createViewSheet(name);
                case (RevitViewType.TABLE):
                    return this.createTableView(name);
                default:
                    break;
            }

            return null;
        }

        private Autodesk.Revit.DB.View3D createView3D(String name, int scale)
        {
            // Find the ViewFamilyType for a 3D view
            ViewFamilyType viewFamilyType3D = new FilteredElementCollector(this.dbDoc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.ThreeDimensional);

            View3D new3DView = null;

            if (viewFamilyType3D != null)
            {
                Transaction revitTransaction = null;

                try
                {
                    //Start New Transaction
                    if (!dbDoc.IsModifiable)
                    {
                        revitTransaction = new Transaction(dbDoc, "Create 3D View");
                        revitTransaction.Start();
                    }

                    // Create the new 3D view
                    new3DView = View3D.CreateIsometric(dbDoc, viewFamilyType3D.Id);
                    new3DView.Name = name;
                    new3DView.Scale = scale;
                    new3DView.AreAnnotationCategoriesHidden = true;
                    // Set the view to shaded and hidden edges
                    new3DView.DisplayStyle = DisplayStyle.Shading;


                    /* ************* ADD FURTHER PROPERTIES FOR THE VIEW !!!! ******* */

                    if (revitTransaction != null)
                    {
                        // Close and Dispose Transaction
                        revitTransaction.Commit();
                        revitTransaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    if (revitTransaction != null) { 
                        
                        revitTransaction.RollBack(); 

                        TaskDialog.Show("ERROR MESSAGES", ex.Message);

                        // Close and Dispose Transaction
                        revitTransaction.Commit();
                        revitTransaction.Dispose();
                    }
                }
            }
            return new3DView;
        }


        private Autodesk.Revit.DB.ViewPlan createViewPlan(String name, int scale)
        {
            /* ************* ADD CODE HERE !!!! ******* */
            return null;
        }

        private Autodesk.Revit.DB.ViewDrafting createViewDrafting(String viewName, int scale)
        {

            // Find the ViewFamilyType for a Drafting View
            ViewFamilyType viewFamilyTypeDrafting = new FilteredElementCollector(this.dbDoc)
                        .OfClass(typeof(ViewFamilyType))
                        .Cast<ViewFamilyType>()
                        .FirstOrDefault(vft => vft.ViewFamily == ViewFamily.Drafting);

            ViewDrafting newDraftingView = null;


            if (viewFamilyTypeDrafting != null)
            {
                Transaction revitTransaction = null;

                try
                {
                    //Start New Transaction
                    if (!dbDoc.IsModifiable)
                    {
                        revitTransaction = new Transaction(dbDoc, "Create View Drafting");
                        revitTransaction.Start();
                    }

                    // Create the new 3D view
                    newDraftingView = ViewDrafting.Create(dbDoc, viewFamilyTypeDrafting.Id);
                    newDraftingView.Name = viewName;
                    newDraftingView.Scale = scale;


                    /* ************* ADD FURTHER PROPERTIES FOR THE VIEW !!!! ******* */

                    if (revitTransaction != null)
                    {
                        // Close and Dispose Transaction
                        revitTransaction.Commit();
                        revitTransaction.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    if (revitTransaction != null)
                    {

                        revitTransaction.RollBack();

                        TaskDialog.Show("ERROR MESSAGES", ex.Message);

                        // Close and Dispose Transaction
                        revitTransaction.Commit();
                        revitTransaction.Dispose();
                    }
                }
            }
            return newDraftingView;
        }

        private Autodesk.Revit.DB.ViewSection createViewSection(String name, int scale)
        {
            /* ************* ADD CODE HERE !!!! ******* */
            return null;
        }

        private Autodesk.Revit.DB.ViewSheet createViewSheet(String name)
        {

            ViewSheet placeholder = null;

            Transaction revitTransaction = null;

            try
            {
                //Start New Transaction
                if (!dbDoc.IsModifiable)
                {
                    revitTransaction=new Transaction(dbDoc, "Create ViewSheet");
                    revitTransaction.Start();
                }
                
                // Create ViewSheet PlaceHolder
                placeholder = ViewSheet.CreatePlaceholder(dbDoc);

                if (revitTransaction != null) { 
                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
            }
            catch (Exception ex)
            {
                if (revitTransaction != null) {

                    revitTransaction.RollBack();
                
                    TaskDialog.Show("ERROR MESSAGES", ex.Message);

                    // Close and Dispose Transaction
                    revitTransaction.Commit();
                    revitTransaction.Dispose();
                }
                MessageBox.Show(ex.Message);
            }
            return placeholder;
        }


        private Autodesk.Revit.DB.TableView createTableView(String name)
        {
            /* ************* ADD CODE HERE !!!! ******* */
            return null;
        }

    }

}
