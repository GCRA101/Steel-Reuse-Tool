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
using System.Drawing.Imaging;

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
        public void createNewFilters(Autodesk.Revit.DB.View view, List<BuiltInCategory> categoriesList,
                                     List<String> materialsList, string parameterName, ColorPalette colorPalette, bool ascendingSort = true)
        {
            Transaction revitTransaction = null;

            try
            {

                //1. GET CATEGORIES LIST IDS
                List<ElementId> catIdsList = categoriesList
                                            .Select(builtInCat => new ElementId(builtInCat))
                                            .ToList();

                ElementMulticategoryFilter elMultiCatFilter = new ElementMulticategoryFilter(categoriesList);

                //2. GET FRAME SECTION NAMES

                Parameter parameter = new FilteredElementCollector(view.Document)
                                        .OfClass(typeof(FamilyInstance))
                                        .WherePasses(elMultiCatFilter)
                                        .First()
                                        .LookupParameter(parameterName);

                List<String> parameterValues = new List<String>();

                parameterValues = new FilteredElementCollector(view.Document).
                                        OfClass(typeof(FamilyInstance)).
                                        WherePasses(elMultiCatFilter).
                                        Where(el => materialsList.Contains(el.LookupParameter(AppConfig.PARAM_STRUCTURAL_MATERIAL).AsString())).
                                        Select(el => el.LookupParameter(parameterName).AsString()).
                                        Where(parName => parName != null && parName !="").
                                        ToHashSet().
                                        ToList();

                parameterValues.Sort();

                if (!ascendingSort) parameterValues.Reverse();


                /*4.CREATE COLORS PALETTE FOR VIEW FILTERS */

                List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();
                colors = ColorsFactory.getInstance().create(colorPalette, parameterValues.Count());


                /*6. CREATE NEW VIEW FILTERS IN THE VIEW*/

                //Utility List Variables Declaration
                List<FilterRule> filterRules = new List<FilterRule>();
                List<OverrideGraphicSettings> overrideGraphicSettings = new List<OverrideGraphicSettings>();
                List<ParameterFilterElement> filters = new List<ParameterFilterElement>();

                //Start New Transaction
                if (!view.Document.IsModifiable)
                {
                    revitTransaction = new Transaction(view.Document, "View Filters Factory");
                    revitTransaction.Start();
                }

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
                viewFilterIds = view.GetFilters().ToList();
                viewFilterIds.Sort((elId0, elId1) => view.Document.GetElement(elId0).Name.CompareTo(view.Document.GetElement(elId1).Name));


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

                MessageBox.Show(ex.Message);
            }
        }



        //createNewFilters()
        public void createNewBHFilters(Autodesk.Revit.DB.View view, List<BuiltInCategory> categoriesList,
                                     List<String> materialsList, string parameterName, BHColorPalette bhColorPalette, bool ascendingSort=true)
        {
            Transaction revitTransaction = null;

            try
            {

                //1. GET CATEGORIES LIST IDS
                List<ElementId> catIdsList = categoriesList
                                            .Select(builtInCat => new ElementId(builtInCat))
                                            .ToList();

                ElementMulticategoryFilter elMultiCatFilter = new ElementMulticategoryFilter(categoriesList);

                //2. GET FRAME SECTION NAMES

                Parameter parameter = new FilteredElementCollector(view.Document)
                                        .OfClass(typeof(FamilyInstance))
                                        .WherePasses(elMultiCatFilter)
                                        .First()
                                        .LookupParameter(parameterName);

                List<String> parameterValues = new List<String>();

                parameterValues = new FilteredElementCollector(view.Document).
                                        OfClass(typeof(FamilyInstance)).
                                        WherePasses(elMultiCatFilter).
                                        Where(el => materialsList.Contains(el.LookupParameter(AppConfig.PARAM_STRUCTURAL_MATERIAL).AsString())).
                                        Select(el => el.LookupParameter(parameterName).AsString()).
                                        Where(parName => parName != null && parName !="").
                                        ToHashSet().
                                        ToList();

                parameterValues.Sort();


                /*4.CREATE COLORS PALETTE FOR VIEW FILTERS */

                List<Autodesk.Revit.DB.Color> colors = new List<Autodesk.Revit.DB.Color>();
                colors = ColorsFactory.getInstance().create(bhColorPalette, parameterValues.Count());


                /*6. CREATE NEW VIEW FILTERS IN THE VIEW*/

                //Utility List Variables Declaration
                List<FilterRule> filterRules = new List<FilterRule>();
                List<OverrideGraphicSettings> overrideGraphicSettings = new List<OverrideGraphicSettings>();
                List<ParameterFilterElement> filters = new List<ParameterFilterElement>();

                //Start New Transaction
                if (!view.Document.IsModifiable)
                {
                    revitTransaction = new Transaction(view.Document, "View Filters Factory");
                    revitTransaction.Start();
                }

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
                viewFilterIds = view.GetFilters().ToList();
                viewFilterIds.Sort((elId0, elId1) => view.Document.GetElement(elId0).Name.CompareTo(view.Document.GetElement(elId1).Name));


                if (!ascendingSort) viewFilterIds.Reverse();


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

                MessageBox.Show(ex.Message);
            }
        }




        public void createNewFilter(Autodesk.Revit.DB.View view, List<BuiltInCategory> categoriesList, string viewFilterName, string parameterName, string parameterValue, Color color, int transparency, bool inverse)
        {

            Transaction revitTransaction = null;

            try
            {

                //1. GET CATEGORIES LIST IDS
                List<ElementId> catIdsList = categoriesList
                                            .Select(builtInCat => new ElementId(builtInCat))
                                            .ToList();

                ElementMulticategoryFilter elMultiCatFilter = new ElementMulticategoryFilter(categoriesList);

                //3. GET FRAME SECTION NAMES

                Parameter parameter = new FilteredElementCollector(view.Document)
                                        .OfClass(typeof(FamilyInstance))
                                        .WherePasses(elMultiCatFilter)
                                        .First()
                                        .LookupParameter(parameterName);

                //Utility List Variables Declaration
                OverrideGraphicSettings overrideGraphicSettings = new OverrideGraphicSettings();
                IList<ElementFilter> elParamFilters = new List<ElementFilter>();

                //Start New Transaction
                if (!view.Document.IsModifiable)
                {
                    revitTransaction = new Transaction(view.Document, "View Filters Factory");
                    revitTransaction.Start();
                }
                if (ParameterFilterElement.IsNameUnique(view.Document, viewFilterName))
                {
                    ParameterFilterElement filter = ParameterFilterElement.Create(view.Document, viewFilterName, catIdsList);
                    FilterRule filterRule;
                    if (!inverse) filterRule = ParameterFilterRuleFactory.CreateEqualsRule(parameter.Id, parameterValue, false);
                    else filterRule = ParameterFilterRuleFactory.CreateNotEqualsRule(parameter.Id, parameterValue, false);
                    elParamFilters.Add(new ElementParameterFilter(filterRule));
                    filter.SetElementFilter(new LogicalAndFilter(elParamFilters));
                    view.AddFilter(filter.Id);
                }
                else
                {
                    view.AddFilter(new FilteredElementCollector(view.Document).
                        OfClass(typeof(ParameterFilterElement)).
                        ToElements().
                        Where(elFilter => elFilter.Name == viewFilterName).
                        Select(elFilter => elFilter.Id).
                        First());
                }

                // Get back the created View Filters
                ElementId viewFilterId = (ElementId)view.GetFilters().FirstOrDefault(elId => ((ParameterFilterElement)view.Document.GetElement(elId)).Name == viewFilterName);

                // Get the element id of the solid fill pattern
                FillPatternElement fillPattern = new FilteredElementCollector(view.Document)
                    .OfClass(typeof(FillPatternElement))
                    .Cast<FillPatternElement>()
                    .FirstOrDefault(pattern => pattern.Name.Contains("Solid fill"));

                // Assign OverrideGraphicSettings to all View Filters
                overrideGraphicSettings=OverrideGraphicsFactory.getInstance().create(fillPattern.Id, color, transparency);
                view.SetFilterOverrides(viewFilterId, overrideGraphicSettings);

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

                MessageBox.Show(ex.Message);
            }

        }

    }

}
