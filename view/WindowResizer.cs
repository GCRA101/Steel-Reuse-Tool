using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Autodesk.Revit.DB.SpecTypeId;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ReuseSchemeTool.view
{
    public static class WindowResizer
    {
        // Import necessary Windows API functions
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        // Delegate for the EnumWindows method
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        public static void DockWindow(ProcessName processName, DockType dockType)
        {
            // Enumerate all open windows
            EnumWindows((hWnd, lParam) =>
            {
                // Skip windows that are not visible
                if (!IsWindowVisible(hWnd))
                {
                    return true;
                }

                // Get the window's title
                StringBuilder title = new StringBuilder(256);
                GetWindowText(hWnd, title, 256);

                // Check for a specific window title
                if (title.ToString().Contains(ProcessNameRetriever.getName(processName)))
                {
                    // Dock the window to the specified position
                    switch (dockType)
                    {
                        case DockType.LEFT:
                            MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, true);
                            break;
                        case DockType.TOP:
                            MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, true);
                            break;
                        case DockType.RIGHT:
                            MoveWindow(hWnd, Screen.PrimaryScreen.Bounds.Width / 2, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, true);
                            break;
                        case DockType.BOTTOM:
                            MoveWindow(hWnd, 0, Screen.PrimaryScreen.Bounds.Height / 2, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, true);
                            break;
                        case DockType.CENTER:
                            MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, true);
                            break;
                    }
                    return false; // Stop enumerating windows
                }
                return true; // Continue enumerating windows
            }, IntPtr.Zero);
        }
    }
}