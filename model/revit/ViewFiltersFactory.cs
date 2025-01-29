// Libraries for Revit
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ReuseSchemeTool.model.revit
{
    public class ViewFiltersFactory
    {

        /* ATTRIBUTES */
        //Private instance - SINGLETON PATTERN
        private static ViewFiltersFactory instance;

        /* CONSTRUCTORS */
        //Private Default Constructor - SINGLETON PATTERN
        private ViewFiltersFactory() { }

        /* METHODS */

        //getInstance Method - SINGLETON PATTERN
        public static ViewFiltersFactory getInstance()
        {
            if (instance == null)
            { return new ViewFiltersFactory(); }
            return instance;
        }


        /* METHODS */

        //createNewFilters()
        public void createNewFilter(Autodesk.Revit.DB.View view, List<BuiltInCategory> categoriesList,
                                     List<String> materialsList, string parameterName)
        {

            Transaction revitTransaction = null;

            try
            {

                //1. GET CATEGORIES LIST IDS
                List<ElementId> catIdsList = categoriesList
                                            .Select(builtInCat => new ElementId(builtInCat))
                                            .ToList();

                ElementMulticategoryFilter elMultiCatFilter = new ElementMulticategoryFilter(categoriesList);


                //2. GET MATERIALS LIST

                //List<ElementId> selectedMaterialIds = new FilteredElementCollector(view.Document).
                //                        OfClass(typeof(Material)).
                //                        Where(mat => materialsList.Contains(mat.Name)).
                //                        Select(mat => mat.Id).
                //                        ToList();


                //3. GET FRAME SECTION NAMES


                Parameter parameter = new FilteredElementCollector(view.Document)
                                        .OfClass(typeof(FamilyInstance))
                                        .WherePasses(elMultiCatFilter)
                                        .First()
                                        .LookupParameter(parameterName);


                List<String> parameterValues = new List<String>();

                parameterValues = new FilteredElementCollector(view.Document).
                                        OfClass(typeof(FamilyInstance)).
                                        WherePasses(elMultiCatFilter).
                                        //Where(el => el.GetMaterialIds(false).Intersect(selectedMaterialIds).Count() != 0).
                                        Where(el => materialsList.Contains(el.LookupParameter("BHE_Material").AsString())).
                                        Select(el => el.LookupParameter(parameterName).AsString()).
                                        ToHashSet().
                                        ToList();

                parameterValues.Sort();


                /*4.CREATE COLORS PALETTE FOR VIEW FILTERS */

                List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();
                colors = ColorsFactory.getInstance().create(ColorPalette.RANDOM, parameterValues.Count());



                /*6. CREATE NEW VIEW FILTERS IN THE VIEW*/

                //Utility List Variables Declaration
                List<FilterRule> filterRules = new List<FilterRule>();
                List<OverrideGraphicSettings> overrideGraphicSettings = new List<OverrideGraphicSettings>();
                List<ParameterFilterElement> filters = new List<ParameterFilterElement>();

                //Start New Transaction
                if (!view.Document.IsModifiable) {
                    revitTransaction=new Transaction(view.Document, "View Filters Factory");
                    revitTransaction.Start(); }

                /* REMOVE ALL FILTERS CURRENTLY ASSIGNED TO THE VIEW */
                view.GetFilters().ToList().ForEach(filter => view.RemoveFilter(filter));


                for (int i = 0; i < parameterValues.Count(); i++)
                {
                    List<ElementFilter> elParamFilters = new List<ElementFilter>();
                    String paramValue = parameterValues[i];
                    if (ParameterFilterElement.IsNameUnique(view.Document, paramValue))
                    {
                        filters.Add(ParameterFilterElement.Create(view.Document, paramValue, catIdsList));
                        filterRules.Add(ParameterFilterRuleFactory.CreateEqualsRule(parameter.Id, paramValue, false));
                        elParamFilters.Add(new ElementParameterFilter(filterRules[i]));
                        filters[i].SetElementFilter(new LogicalAndFilter(elParamFilters));
                        view.AddFilter(filters[i].Id);
                    }
                    else
                    {
                        view.AddFilter(new FilteredElementCollector(view.Document).
                            OfClass(typeof(ParameterFilterElement)).
                            ToElements().
                            Where(elFilter => elFilter.Name == paramValue).
                            Select(elFilter => elFilter.Id).
                            First());
                    }
                }

                // Get back the created View Filters
                List<ElementId> viewFilterIds = new List<ElementId>();
                viewFilterIds = (List<ElementId>)view.GetFilters();

                // Get the element id of the solid fill pattern
                FillPatternElement fillPattern = new FilteredElementCollector(view.Document)
                    .OfClass(typeof(FillPatternElement))
                    .Cast<FillPatternElement>()
                    .FirstOrDefault(pattern => pattern.Name.Contains("Solid fill"));

                // Assign OverrideGraphicSettings to all View Filters
                for (int i = 0; i < viewFilterIds.Count(); i++)
                {
                    overrideGraphicSettings.Add(OverrideGraphicsFactory.getInstance().create(fillPattern.Id, colors[i]));
                    view.SetFilterOverrides(viewFilterIds[i], overrideGraphicSettings[i]);
                }

                if (revitTransaction!=null) { 
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

                MessageBox.Show(ex.Message);
            }

        }

    }

}
