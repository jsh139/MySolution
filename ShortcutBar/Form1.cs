using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using IWshRuntimeLibrary;
using Microsoft.Win32;

namespace ShortcutBar
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem mnuOnTop;
		private System.Windows.Forms.MenuItem mnuClose;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuAddShortcut;
		private System.Windows.Forms.MenuItem mnuRemoveAll;
		private System.Windows.Forms.MenuItem mnuCustomize;
		private System.Windows.Forms.MenuItem mnuRemove;
		private ArrayList arrShortcuts;
		private ToolBarButton SelectedButton;
		private int RightPixels = 75;
		private System.Windows.Forms.MenuItem mnuLeft;
		private System.Windows.Forms.MenuItem mnuRight;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ToolTip toolTip1;
		
		public ArrayList arrNewShortcuts;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			SystemEvents.DisplaySettingsChanged += new EventHandler(this.DisplayChanged);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuAddShortcut = new System.Windows.Forms.MenuItem();
			this.mnuRemove = new System.Windows.Forms.MenuItem();
			this.mnuRemoveAll = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuCustomize = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.mnuLeft = new System.Windows.Forms.MenuItem();
			this.mnuRight = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuOnTop = new System.Windows.Forms.MenuItem();
			this.mnuClose = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.AllowDrop = true;
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.ButtonSize = new System.Drawing.Size(16, 16);
			this.toolBar1.ContextMenu = this.contextMenu1;
			this.toolBar1.Divider = false;
			this.toolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(118, 20);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolBar1_MouseDown);
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			this.toolBar1.DragDrop += new System.Windows.Forms.DragEventHandler(this.toolBar1_DragDrop);
			this.toolBar1.DragEnter += new System.Windows.Forms.DragEventHandler(this.toolBar1_DragEnter);
			this.toolBar1.MouseHover += new System.EventHandler(this.toolBar1_MouseHover);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuAddShortcut,
            this.mnuRemove,
            this.mnuRemoveAll,
            this.menuItem1,
            this.mnuCustomize,
            this.menuItem2,
            this.mnuLeft,
            this.mnuRight,
            this.menuItem3,
            this.mnuOnTop,
            this.mnuClose});
			// 
			// mnuAddShortcut
			// 
			this.mnuAddShortcut.Index = 0;
			this.mnuAddShortcut.Text = "&Add Shortcut";
			this.mnuAddShortcut.Click += new System.EventHandler(this.mnuAddShortcut_Click);
			// 
			// mnuRemove
			// 
			this.mnuRemove.Enabled = false;
			this.mnuRemove.Index = 1;
			this.mnuRemove.Text = "R&emove Shortcut";
			this.mnuRemove.Click += new System.EventHandler(this.mnuRemove_Click);
			// 
			// mnuRemoveAll
			// 
			this.mnuRemoveAll.Index = 2;
			this.mnuRemoveAll.Text = "&Remove All Shortcuts";
			this.mnuRemoveAll.Click += new System.EventHandler(this.mnuRemoveAll_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// mnuCustomize
			// 
			this.mnuCustomize.Index = 4;
			this.mnuCustomize.Text = "C&ustomize...";
			this.mnuCustomize.Click += new System.EventHandler(this.mnuCustomize_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Text = "-";
			// 
			// mnuLeft
			// 
			this.mnuLeft.Index = 6;
			this.mnuLeft.Text = "Move Shortcut Bar &Left";
			this.mnuLeft.Click += new System.EventHandler(this.mnuLeft_Click);
			// 
			// mnuRight
			// 
			this.mnuRight.Index = 7;
			this.mnuRight.Text = "&Move Shortcut Bar Right";
			this.mnuRight.Click += new System.EventHandler(this.mnuRight_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 8;
			this.menuItem3.Text = "-";
			// 
			// mnuOnTop
			// 
			this.mnuOnTop.Checked = true;
			this.mnuOnTop.Index = 9;
			this.mnuOnTop.Text = "Always on &Top";
			this.mnuOnTop.Click += new System.EventHandler(this.mnuOnTop_Click);
			// 
			// mnuClose
			// 
			this.mnuClose.Index = 10;
			this.mnuClose.Text = "&Close";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "All files (*.*)|*.*";
			this.openFileDialog1.Title = "Choose";
			// 
			// toolTip1
			// 
			this.toolTip1.ShowAlways = true;
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(118, 22);
			this.ControlBox = false;
			this.Controls.Add(this.toolBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			arrShortcuts = new ArrayList();
			LoadShortcuts();
			PositionToolbar();
		}

		private void LoadShortcuts()
		{
			if (System.IO.File.Exists(Application.StartupPath + "\\Settings.xml"))
			{
				XmlDocument xmlObj = new XmlDocument();
				xmlObj.Load(Application.StartupPath + "\\Settings.xml");

				foreach (XmlNode node in xmlObj.SelectNodes("/shortcutList/shortcutItem"))
				{
					string Filename = node.SelectSingleNode("filename").InnerText;
					string Args = node.SelectSingleNode("args").InnerText;
					string ToolTip = node.SelectSingleNode("toolTip").InnerText;

					AddButton(Filename, Args, ToolTip);
				}

				if (xmlObj.SelectSingleNode("/shortcutList/rightPixels") != null)
					RightPixels = Convert.ToInt32(xmlObj.SelectSingleNode("/shortcutList/rightPixels").InnerText);
			}
		}

		private void SaveShortcuts()
		{
			XmlDocument x = new XmlDocument();
			XmlElement node = null;
			XmlElement node2 = null;

			x.LoadXml("<shortcutList/>");
			XmlNode root = x.SelectSingleNode("shortcutList");

			foreach (Shortcut s in arrShortcuts)
			{
				node = x.CreateElement("shortcutItem");
				root.AppendChild(node);

				node2 = x.CreateElement("filename");
				node2.InnerText = s.Filename;
				node.AppendChild(node2);

				node2 = x.CreateElement("args");
				node2.InnerText = s.Args;
				node.AppendChild(node2);

				node2 = x.CreateElement("toolTip");
				node2.InnerText = s.ToolTip;
				node.AppendChild(node2);
			}

			node = x.CreateElement("rightPixels");
			node.InnerText = RightPixels.ToString();
			root.AppendChild(node);

			x.Save(Application.StartupPath + "\\Settings.xml");
		}

		private void PositionToolbar()
		{
			int FormWidth = this.Width;
			int ScreenWidth = SystemInformation.WorkingArea.Width;

			this.Left = (ScreenWidth - FormWidth) - RightPixels;
			this.Top = 0;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string ExecutableName = "";
			string Args = "";

			Shortcut s = (Shortcut)arrShortcuts[Convert.ToInt32(e.Button.Tag)];
			ExecutableName = s.Filename;
			Args = s.Args;

			if (System.IO.File.Exists(ExecutableName))
				Process.Start(ExecutableName, Args);
			else
				MessageBox.Show("Unable to launch application associated with button '" + e.Button.Tag + "'.",
					"Unable to launch application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void mnuClose_Click(object sender, System.EventArgs e)
		{
			SaveShortcuts();
			Application.Exit();
		}

		private void mnuOnTop_Click(object sender, System.EventArgs e)
		{
			this.TopMost = !this.TopMost;
			mnuOnTop.Checked = this.TopMost;
			this.ShowInTaskbar = !this.TopMost;
		}

		private void mnuAddShortcut_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				AddButton(openFileDialog1.FileName, "", Path.GetFileName(openFileDialog1.FileName));
				PositionToolbar();
				SaveShortcuts();
			}
		}

		private void AddButton(string Filename, string Args, string ToolTip)
		{
			if (System.IO.File.Exists(Filename) || System.IO.Directory.Exists(Filename))
			{
				imageList1.Images.Add(Util.GetIconFromFile(Filename));
				
				ToolBarButton tb = new ToolBarButton();
				tb.ImageIndex = imageList1.Images.Count-1;
				tb.Tag = tb.ImageIndex;
				tb.ToolTipText = ToolTip;

				toolBar1.Buttons.Add(tb);

				Shortcut s = new Shortcut();
				s.Filename = Filename;
				s.Args = Args;
				s.ToolTip = ToolTip;
				arrShortcuts.Add(s);

				if ((toolBar1.Buttons.Count * 24) > this.Width)
					this.Width = toolBar1.Buttons.Count * 24;
			}
			else
				MessageBox.Show(String.Format("Unable to locate file/folder {0}. Shortcut was not added.", Filename),
					"Unable to Add Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void mnuRemoveAll_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you wish to remove all of your shortcuts?", "Remove All Shortcuts?",
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				toolBar1.Buttons.Clear();
				imageList1.Images.Clear();
				arrShortcuts.Clear();

				this.Width = 120;
				PositionToolbar();
				SaveShortcuts();
			}
		}

		private void toolBar1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileNameW")) 
			{
				Object item = (object)e.Data.GetData("FileNameW");
				Array a = (System.Array)item;

				string Filename = Convert.ToString(a.GetValue(0));
				string Args = "";

				if (Path.GetExtension(Filename).ToUpper() == ".LNK")
				{
					try
					{
						/* Shortcut, get the actual contents */
						WshShell shell = new WshShellClass();
						Object sc = (object)shell.CreateShortcut(Filename);
						Filename = ((WshShortcut)sc).TargetPath;
						Args = ((WshShortcut)sc).Arguments;
					}
					catch (Exception ex)
					{ 
						string s = ex.Message;
					}
				}

				AddButton(Filename, Args, Path.GetFileName(Filename));
				PositionToolbar();
				SaveShortcuts();
			}
		}

		private void toolBar1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileNameW"))
				e.Effect = DragDropEffects.Link;
			else
				e.Effect = DragDropEffects.None;
		}

		private void mnuCustomize_Click(object sender, System.EventArgs e)
		{
			arrNewShortcuts = new ArrayList();

			Customize c = new Customize(arrShortcuts);
			
			if (c.ShowDialog(this) == DialogResult.OK)
			{
				toolBar1.Buttons.Clear();
				imageList1.Images.Clear();
				arrShortcuts.Clear();
				this.Width = 120;

				foreach (Shortcut s in arrNewShortcuts)
					AddButton(s.Filename, s.Args, s.ToolTip);

				PositionToolbar();
				SaveShortcuts();
			}
		}

		private void toolBar1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Point p = new Point(e.X, e.Y);

			if (e.Button == MouseButtons.Right)
				mnuRemove.Enabled = false;
			SelectedButton = null;

			foreach (ToolBarButton tb in toolBar1.Buttons)
			{
				if (p.X >= tb.Rectangle.Left && p.X <= (tb.Rectangle.Left + tb.Rectangle.Width))
				{
					if (e.Button == MouseButtons.Right)
						mnuRemove.Enabled = true;
					SelectedButton = tb;
					break;
				}
			}
		}

		private void mnuRemove_Click(object sender, System.EventArgs e)
		{
			if (SelectedButton != null)
			{
				int i = toolBar1.Buttons.IndexOf(SelectedButton);

				if (i >= 0)
				{
					toolBar1.Buttons.RemoveAt(i);
					imageList1.Images.RemoveAt(i);
					arrShortcuts.RemoveAt(i);

					int j = 0;
					foreach (ToolBarButton tb in toolBar1.Buttons)
						tb.ImageIndex = j++;

					this.Width = toolBar1.Buttons.Count * 24;
					PositionToolbar();
					SaveShortcuts();
				}
			}
		}

		private void mnuLeft_Click(object sender, System.EventArgs e)
		{
			RightPixels += 25;
			PositionToolbar();
			SaveShortcuts();
		}

		private void mnuRight_Click(object sender, System.EventArgs e)
		{
			RightPixels -= 25;
			PositionToolbar();
			SaveShortcuts();
		}

		private void toolBar1_MouseHover(object sender, System.EventArgs e)
		{
			ToolBarButton stb = null;

			if (!this.Focused)
			{
				Point p = new Point(MousePosition.X, MousePosition.Y);

				foreach (ToolBarButton tb in toolBar1.Buttons)
				{
					if ((p.X - this.Left) >= tb.Rectangle.Left && (p.X - this.Left) <= (tb.Rectangle.Left + tb.Rectangle.Width))
					{
						stb = tb;
						break;
					}
				}

				if (stb != null)
				{
					int i = toolBar1.Buttons.IndexOf(stb);
					toolTip1.SetToolTip(toolBar1, ((Shortcut)arrShortcuts[i]).ToolTip);
				}
			}
		}

		private void DisplayChanged(object sender, System.EventArgs e)
		{
			PositionToolbar();
		}

	}
}
