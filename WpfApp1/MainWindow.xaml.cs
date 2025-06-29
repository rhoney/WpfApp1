using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;

namespace WpfApp1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow ()
		{
			var settings = new CefSettings();

			//////https://github.com/cefsharp/CefSharp/discussions/4855
			//////https://github.com/cefsharp/CefSharp/issues/4668
			//////Cannot share cache path between 2 instances of a CefSharp application. Hence need to have a unique cache path.
			////var baseCachePath = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Browser\\Cache");

			//////First remove all cache directories more than 2 days old, to prevent unnecessary cache directory size explosion.
			////if (Directory.Exists(baseCachePath))
			////{
			////	var twoDaysOldName = DateTime.Now.AddDays(-2).ToString("yyyyMMdd");
			////	var subDirectories = Directory.GetDirectories(baseCachePath, "*", SearchOption.TopDirectoryOnly);
			////	foreach (var subDirectory in subDirectories)
			////	{
			////		var subDirectoryName = System.IO.Path.GetFileName(subDirectory);
			////		if (string.Compare(subDirectoryName, twoDaysOldName) <= 0)
			////		{
			////			Directory.Delete(subDirectory, true);
			////		}
			////	}
			////}
			////else
			////{
			////	Directory.CreateDirectory(baseCachePath);
			////}

			////var currentCachePath = System.IO.Path.Combine(baseCachePath, DateTime.Now.ToString("yyyyMMdd"), Guid.NewGuid().ToString());
			////settings.CachePath = currentCachePath;

			//////CefSharpSettings.RuntimeStyle = CefRuntimeStyle.Chrome;

			//////Enables WebRTC
			////settings.CefCommandLineArgs.Add("enable-media-stream");
			//////https://github.com/cefsharp/CefSharp/issues/1634
			////settings.CefCommandLineArgs.Add("disable-gpu");
			//////settings.CefCommandLineArgs.Add("disable-gpu-vsync"); //Disable GPU vsync
			//////settings.CefCommandLineArgs.Add("disable-chrome-login-prompt");
			//////settings.CefCommandLineArgs.Add("hide-crash-restore-bubble");
			////settings.CefCommandLineArgs.Add("disable-extensions"); //Disable GPU vsync
			////settings.CefCommandLineArgs.Add("disable-popup-blocking"); //Disable GPU vsync
			////settings.ChromeRuntime = true;
			////settings.CefCommandLineArgs.Add("disable-threaded-scrolling");

			////// Set BrowserSubProcessPath based on app bitness at runtime
			////settings.BrowserSubprocessPath = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
			////									   Environment.Is64BitProcess ? "x64" : "x86",
			////									   "CefSharp.BrowserSubprocess.exe");

			////settings.LogFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Cef.log");

			// Make sure you set performDependencyCheck false
			CefSharp.Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

			InitializeComponent();
		}

		private void FormBase_Loaded (object sender, RoutedEventArgs e)
		{
			this.ctlBrowser.BrowserCore.MainFrame.LoadUrl("https://www.google.com/");
		}
	}
}
