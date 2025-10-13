# 🏗️ Steel Reuse Inspector & Scheme Tool

<img width="2020" height="1237" alt="Scheming and Inspector Tools - Solid Background" src="https://github.com/user-attachments/assets/99a566b4-84c9-4b7c-bc7c-287c01d2bdcf" />

## Overview

The **Steel Reuse Inspector & Scheme Tool** is a pair of Revit plugins developed by **Buro Happold** to empower structural engineers in assessing the potential for reuse of existing steelwork in refurbishment projects. 
These tools streamline sustainable design workflows by integrating directly into the Revit environment and producing outputs in Revit sheets, Excel, PDF, and JSON formats.

## 🚀 Features

- **Inspector Tool**: Analyzes existing steel assets in a Revit model and generates detailed summaries.
- **Scheme Tool**: Assesses reuse potential based on customizable criteria and outputs a reuse strategy.
- **Revit Integration**: Seamless UI via the “BH Plugins” Ribbon Tab.
- **Multi-format Outputs**: Excel dashboards, PDF reports, Revit view sheets, and JSON datasets.
- **Sustainability Focus**: Helps drive reuse strategies and quantify potential CO₂ savings.

## 🛠️ Installation

1. Close Revit before installation.
2. Run the provided `.msi` installer.
3. Choose the installation folder: C:\Users<username>\AppData\Roaming\Autodesk\Revit\Addins<versionNumber>
4. Complete the installation wizard.
5. Do NOT delete or rename the following files/folders:
- `RevitRibbonTabsFactory`
- `ReuseSchemeTool`
- `__RevitRibbonTabsFactory.addin`
- `01_ReuseSchemeTool.addin`

## 🧭 Getting Started

1. Launch Revit (2020 or later).
2. Accept plugin load prompt (choose “Always Load”).
3. Open or create a model.
4. Go to the “BH Plugins” tab.
5. Run the Inspector Tool first, then the Scheme Tool.

## 👩‍💻 User Interface

### Inspector Tool
- Splashscreen → AboutBox → Folder Selection → Progress Bar → Excel Summary

### Scheme Tool
- Splashscreen → AboutBox → Inputs Form → Folder Selection → Progress Bar → Revit Sheet + JSON + Excel/PDF

## 📦 Outputs

### Inspector Tool
- **Excel Dashboard**: Charts and analytics.
- **PDF Report**: Visual documentation.

### Scheme Tool
- **Revit View Sheet**: 3D views, charts, CO₂ savings.
- **JSON Dataset**: Metadata for reusable elements.
- **Excel Dashboard**: Expanded analytics.
- **PDF Report**: Presentation-ready visuals.

## 🧰 Revit Model Setup

Ensure the following parameters are assigned:

- `BHE_Material`: Must be “Steel”
- `BHE_Reuse Strategy`: Must be “EXISTING TO DISMANTLE - TO RECYCLE”
- `BHE_Reuse Rating`: Will be overwritten by the tool

Use “Manage” → “Project Parameters” in Revit to add missing parameters.

## 🐞 Troubleshooting

### ❌ COM Object Error (Excel)

If you encounter a COM error:
1. Go to Control Panel → Programs and Features
2. Search for Office / 365
3. Right-click → Change
4. Choose Quick Repair (or Online Repair if needed)

## 📁 Repository Structure
├── README.md
├── /docs
│   └── Steel Reuse Tool - User Guide.docx
├── /src
│   ├── RevitRibbonTabsFactory
│   └── ReuseSchemeTool
├── /outputs
│   ├── *.xlsx
│   ├── *.pdf
│   └── *.json

## 📄 License
