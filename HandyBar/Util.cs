using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;

namespace HandyBar
{
	public struct Shortcut
	{
		public string Filename;
		public string Args;
		public string ToolTip;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SHFILEINFO
	{
		public IntPtr hIcon;
		public IntPtr iIcon;
		public uint dwAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	};

	class Win32
	{
		public const uint SHGFI_ICON = 0x100;
		public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
		public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);
	}

	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public static Icon GetIconFromFile(string Filename)
		{
			IntPtr hImgSmall; //the handle to the system image list
			//			IntPtr hImgLarge; //the handle to the system image list
			SHFILEINFO shinfo = new SHFILEINFO();

			//Use this to get the small Icon
			hImgSmall = Win32.SHGetFileInfo(Filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
				Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

			//Use this to get the large Icon
			//hImgLarge = SHGetFileInfo(Filename, 0,
			//	ref shinfo, (uint)Marshal.SizeOf(shinfo),
			//	Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);

			//The icon is returned in the hIcon member of the shinfo struct
			System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);

			return myIcon;
		}

		public static IntPtr GetIntPtrFromFile(string Filename)
		{
			IntPtr hImgSmall; //the handle to the system image list
			//			IntPtr hImgLarge; //the handle to the system image list
			SHFILEINFO shinfo = new SHFILEINFO();

			//Use this to get the small Icon
			hImgSmall = Win32.SHGetFileInfo(Filename, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo),
				Win32.SHGFI_ICON | Win32.SHGFI_SMALLICON);

			return shinfo.hIcon;
		}
	}
}
