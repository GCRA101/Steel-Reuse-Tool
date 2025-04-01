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












//{
//        'Import necessary Windows API functions
//<DllImport("user32.dll")>
//Private Shared Function EnumWindows(enumProc As EnumWindowsProc, lParam As IntPtr) As Boolean
//End Function
//    <DllImport("user32.dll")>
//Private Shared Function GetWindowText(hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer) As Integer
//End Function

//<DllImport("user32.dll")>
//Private Shared Function IsWindowVisible(hWnd As IntPtr) As Boolean
//End Function

//<DllImport("user32.dll", SetLastError:=True)>
//Private Shared Function MoveWindow(hWnd As IntPtr, X As Integer, Y As Integer, nWidth As Integer, nHeight As Integer, bRepaint As Boolean) As Boolean
//End Function

//'Delegate for the EnumWindows method
//Private Delegate Function EnumWindowsProc(hWnd As IntPtr, lParam As IntPtr) As Boolean


//Public Shared Sub dockWindow(processName As ProcessName, dockType As DockType)
//    'Enumerate all open windows
//    EnumWindows((Function(hWnd, lParam)
//                     ' Skip windows that are Not visible
//                     If Not IsWindowVisible(hWnd) Then
//                         Return True
//                     End If
//                     ' Get the window's title
//                     Dim title As StringBuilder = New StringBuilder(256)
//                     GetWindowText(hWnd, title, 256)
//                     ' Check for a specific window title
//                     If title.ToString().Contains(ProcessNameRetriever.getName(processName)) Then
//                         ' Dock the window to the left half of the screen
//                         Select Case dockType
//                             Case DockType.LEFT
//                                 MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, True)
//                             Case DockType.TOP
//                                 MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, True)
//                             Case DockType.RIGHT
//                                 MoveWindow(hWnd, Screen.PrimaryScreen.Bounds.Width / 2, 0, Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height, True)
//                             Case DockType.BOTTOM
//                                 MoveWindow(hWnd, 0, Screen.PrimaryScreen.Bounds.Height / 2, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height / 2, True)
//                             Case DockType.CENTER
//                                 MoveWindow(hWnd, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, True)
//                         End Select
//                         Return False 'Stop enumerating windows
//                     End If
//                     Return True ' Continue enumerating windows
//                 End Function), IntPtr.Zero)

//End Sub

