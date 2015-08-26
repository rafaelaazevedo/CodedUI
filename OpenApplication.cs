using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.Playback;
using System.Windows.Forms;

namespace ProjectName
{
	public class Application{

	        public static void Open()
	        {
	        		System.Diagnostics.Process proc = new System.Diagnostics.Process();
	            	proc.EnableRaisingEvents = false;
	            	proc.StartInfo.FileName = "C:\\Users\\yourUser\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\UI.appref-ms";
	        	 try
	            	{ 				
	            		proc.Start();
						WaitApplicationLoad();
					}
 				catch (Exception e)
	             	{
	                   	MessageBox.Show(e.Message);
	               	}
	        }

	        public static bool WaitApplicationLoad(){
	        	WinButton button = new WinButton();
				while(!button.WaitForControlExist())
					{
						PlayBack.Wait(5000);
					}
	        }	
	}
}
