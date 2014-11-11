using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Diagnostics;
using IWshRuntimeLibrary;

namespace HandyBar
{
	public partial class Form1 : Form
	{
		Timer _Timer;
		private int _SaveX;
		private int _SaveY;
		private Point _SaveLocation;
		private DateTimeOption _DateTimeOption;
		private bool _In;
		private RegistryKey _RegistryKey;
		private string _ShortcutsKeyName;
		private string _ShortcutKeyName;
		private string _FilenameKeyName;
		private string _ArgsKeyName;
		private string _ToolTipKeyName;
		private ToolStripButton _SelectedButton;
        private Rectangle _SaveWorkingArea;

		private Rectangle _DragBoxFromMouseDown;
		private Cursor _MoveDragCursor;

		private HandyBarDragItem _HandyBarDragItem;
		private int _DragOverIndex;
		private bool _MoveDragInProgress;
		private int _PrevInsertionX;
		private int _MoveIndex;
		//private double _SaveOpacity;

		enum DateTimeOption
		{
			NoDateTime,
			DateOnly,
			TimeOnly,
			DateAndTime
		}

		public Form1()
		{
			//_SaveOpacity = Opacity;
			_DateTimeOption = DateTimeOption.NoDateTime;

			_HandyBarDragItem = new HandyBarDragItem();
			_DragOverIndex = -1;
			_MoveDragInProgress = false;
			_PrevInsertionX = -1;
			_MoveIndex = -1;

			_ShortcutsKeyName = "Shortcuts";
			_ShortcutKeyName = "Shortcut";

			_FilenameKeyName = "Filename";
			_ArgsKeyName = "Args";
			_ToolTipKeyName = "ToolTip";

			InitializeComponent();
            
            _SaveWorkingArea = Screen.AllScreens[0].WorkingArea;

            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

			_RegistryKey = Registry.CurrentUser.OpenSubKey(@"Software\HandyBar", true);
			if (_RegistryKey == null)
				_RegistryKey = Registry.CurrentUser.CreateSubKey(@"Software\HandyBar");

			//FormBorderStyle = FormBorderStyle.None;
			//TransparencyKey = Color.FloralWhite;
			TransparencyKey = Color.Fuchsia;
			BackColor = Color.Fuchsia;

			pictureBoxInsertionBar.Size = new Size(2, 18);
			pictureBoxInsertionBarSerif1.Size = new Size(2, 2);
			pictureBoxInsertionBarSerif2.Size = new Size(2, 2);
			pictureBoxInsertionBarSerif3.Size = new Size(2, 2);
			pictureBoxInsertionBarSerif4.Size = new Size(2, 2);
		}

        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Rectangle newWorkingArea = Screen.AllScreens[0].WorkingArea;

            double newWidth = Convert.ToDouble(newWorkingArea.Width);
            double oldWidth = Convert.ToDouble(_SaveWorkingArea.Width);
            double widthPercent = newWidth / oldWidth;
            double newX = Convert.ToDouble(Location.X) * widthPercent;

            double newHeight = Convert.ToDouble(newWorkingArea.Height);
            double oldHeight = Convert.ToDouble(_SaveWorkingArea.Height);
            double heightPercent = newHeight / oldHeight;
            double newY = Convert.ToDouble(Location.Y) * heightPercent;

            Location = new Point(Convert.ToInt32(newX), Convert.ToInt32(newY));

            _RegistryKey.SetValue("X", Location.X);
            _RegistryKey.SetValue("Y", Location.Y);

            _SaveLocation = Location;
            _SaveWorkingArea = newWorkingArea;
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			Restore();

			SetTime();

//			_Timer = new Timer();
//			_Timer.Interval = 1000;
//			_Timer.Tick += new EventHandler(_Timer_Tick);

//			_Timer.Start();
		}

		void _Timer_Tick(object sender, EventArgs e)
		{
			SetTime();
		}

		private void Restore()
		{
			int x = -1;
			object obj = _RegistryKey.GetValue("X");
			if (obj != null)
				x = (int)obj;

			int y = -1;
			obj = _RegistryKey.GetValue("Y");
			if (obj != null)
				y = (int)obj;

			if (x >= 0 && y >= 0)
				Location = new Point(x, y);

			//obj = _RegistryKey.GetValue("DateTimeOption");
			//if (obj != null)
			//    _DateTimeOption = (DateTimeOption)obj;

			obj = _RegistryKey.GetValue("TopMost");
			if (obj != null)
				TopMost = Convert.ToBoolean(obj);

			RestoreShortcuts();
		}

		public void RemoveButtons()
		{
			while (toolStrip.Items.Count > 1)
				toolStrip.Items.RemoveAt(toolStrip.Items.Count - 1);
		}

		private void RestoreShortcuts()
		{
			RegistryKey key = _RegistryKey.OpenSubKey(_ShortcutsKeyName);
			if (key != null)
			{
				for (int i = 0; i < key.SubKeyCount; i++)
				{
					RegistryKey subKey = key.OpenSubKey(_ShortcutKeyName + i.ToString());
					if (subKey != null)
					{
						string filename = (string)subKey.GetValue(_FilenameKeyName);
						string args = (string)subKey.GetValue(_ArgsKeyName);
						string toolTip = (string)subKey.GetValue(_ToolTipKeyName);

						AddButton(filename, args, toolTip);

						subKey.Close();
					}
				}

				key.Close();
			}
		}

		public void SaveShortcuts()
		{
			RegistryKey key = _RegistryKey.OpenSubKey(_ShortcutsKeyName);
			if (key != null)
			{
				key.Close();
				_RegistryKey.DeleteSubKeyTree(_ShortcutsKeyName);
			}

			key = _RegistryKey.CreateSubKey(_ShortcutsKeyName);

			for (int i = 1; i < toolStrip.Items.Count; i++)
			{
				ToolStripButton button = (ToolStripButton)toolStrip.Items[i];
				Shortcut shortcut = (Shortcut)button.Tag;
				int index = i - 1;
				RegistryKey subKey = key.CreateSubKey(_ShortcutKeyName + index.ToString());

				subKey.SetValue(_FilenameKeyName, shortcut.Filename);
				subKey.SetValue(_ArgsKeyName, shortcut.Args);
				subKey.SetValue(_ToolTipKeyName, shortcut.ToolTip);

				subKey.Close();
			}

			key.Close();

			SetTime();
		}

		private void SetTime()
		{
			int trailFiller = 6;
			if (_DateTimeOption == DateTimeOption.NoDateTime)
			{
				toolStripLabelDateTime.Text = " ";
				trailFiller += 8;
			}
			//else if (_DateTimeOption == DateTimeOption.DateAndTime)
			//    toolStripLabelDateTime.Text = DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString() + "  ";
			//else if (_DateTimeOption == DateTimeOption.DateOnly)
			//    toolStripLabelDateTime.Text = DateTime.Now.ToLongDateString();
			//else
			//    toolStripLabelDateTime.Text = DateTime.Now.ToLongTimeString();

			toolStripLabelDateTime.Size = toolStripLabelDateTime.GetPreferredSize(new Size(500, 100));

			//Text = DateTime.Now.ToLongTimeString();

			int buttonsWidth = (toolStrip.Items.Count - 1) * 23;
			Size = new Size(toolStripLabelDateTime.Width + buttonsWidth + trailFiller, Height);

			//if (TopMost)
			//    BringToFront();

			MoveMe(Bounds);
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			if (_In)
			{
				_SaveLocation = Location;
				Point p = PointToClient(MousePosition);
				_SaveX = p.X;
				_SaveY = p.Y;
				//Capture = true;
			}
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up)
			{
				if (Location.Y - 1 >= 0)
					Location = new Point(Location.X, Location.Y - 1);
			}
			else if (e.KeyCode == Keys.Left)
			{
				if (Location.X - 1 >= 0)
					Location = new Point(Location.X - 1, Location.Y);
			}
			else if (e.KeyCode == Keys.Down)
			{
				Rectangle testRect = new Rectangle(Bounds.X, Bounds.Y + 1, Bounds.Width, Bounds.Height);
				MoveMe(testRect);
			}
			else if (e.KeyCode == Keys.Right)
			{
				Rectangle testRect = new Rectangle(Bounds.X + 1, Bounds.Y, Bounds.Width, Bounds.Height);
				MoveMe(testRect);
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = Location.X + e.X - _SaveX;
				int y = Location.Y + e.Y - _SaveY;

				Rectangle testRect = new Rectangle(Math.Max(x, 0), Math.Max(y, 0), Bounds.Width, Bounds.Height);

				MoveMe(testRect);
			}
		}
		private void MoveMe(Rectangle testRect)
		{
			bool allow = false;
			int right = -1;
			int bottom = -1;
			int count = 0;

			for (int i = 0; !allow && i < Screen.AllScreens.Length; i++)
			{
				Screen s = Screen.AllScreens[i];

				Rectangle screenBounds = new Rectangle(s.Bounds.X, s.Bounds.Y, s.Bounds.Width, s.Bounds.Height + 9);

				if (screenBounds.IntersectsWith(testRect))
				{
					if (++count > 1)
						allow = true;
					else
					{
						allow = screenBounds.Contains(testRect);

						if (!allow)
						{
							Rectangle intersectRect = new Rectangle(screenBounds.Location, screenBounds.Size);

							intersectRect.Intersect(testRect);

							if (intersectRect.Right == screenBounds.Right)
								right = screenBounds.Right;

							if (intersectRect.Bottom == screenBounds.Bottom)
								bottom = screenBounds.Bottom;
						}
					}
				}
			}

			if (allow)
				Location = new Point(testRect.X, testRect.Y);

			else if (right != -1 && bottom != -1)
				Location = new Point(right - Width, bottom - Height);

			else if (right != -1)
				Location = new Point(right - Width, testRect.Y);

			else if (bottom != -1)
				Location = new Point(testRect.X, bottom - Height);

			_RegistryKey.SetValue("X", Location.X);
			_RegistryKey.SetValue("Y", Location.Y);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			Capture = false;
		}

		private void toolStripLabelDateTime_MouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(sender, e);
		}

		private void OnMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_SaveLocation = Location;
				_SaveX = e.X;
				_SaveY = e.Y;
				Capture = true;
			}
		}

		private void toolStripLabelDateTime_MouseEnter(object sender, EventArgs e)
		{
			_In = true;
		}

		private void toolStripLabelDateTime_MouseLeave(object sender, EventArgs e)
		{
			_In = false;
		}

		private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			topMostToolStripMenuItem.Checked = TopMost;

			//noDateTimeToolStripMenuItem.Checked = (_DateTimeOption == DateTimeOption.NoDateTime);
			//dateOnlyToolStripMenuItem.Checked = (_DateTimeOption == DateTimeOption.DateOnly);
			//timeOnlyToolStripMenuItem.Checked = (_DateTimeOption == DateTimeOption.TimeOnly);
			//dateAndTimeToolStripMenuItem.Checked = (_DateTimeOption == DateTimeOption.DateAndTime);

			removeShortcutToolStripMenuItem.Enabled = (_SelectedButton != null);
		}

		//private void noDateTimeToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    SetDateTimeOption(DateTimeOption.NoDateTime);
		//}

		//private void dateAndTimeToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    SetDateTimeOption(DateTimeOption.DateAndTime);
		//}

		//private void dateOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    SetDateTimeOption(DateTimeOption.DateOnly);
		//}

		//private void timeOnlyToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    SetDateTimeOption(DateTimeOption.TimeOnly);
		//}

		//private void SetDateTimeOption(DateTimeOption option)
		//{
		//    _DateTimeOption = option;
		//    _RegistryKey.SetValue("DateTimeOption", (int)_DateTimeOption);
		//    SetTime();
		//}

		private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TopMost = !TopMost;
			_RegistryKey.SetValue("TopMost", TopMost);
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void toolStrip_DragEnter(object sender, DragEventArgs e)
		{
			HandleDragEnterOver(sender, e);
			//if (e.Data.GetDataPresent(_HandyBarDragItem.DragFormat))
			//    e.Effect = DragDropEffects.Move;
			//else if (e.Data.GetDataPresent("FileNameW"))
			//    e.Effect = DragDropEffects.Link;
			//else
			//    e.Effect = DragDropEffects.None;
		}

		private void toolStrip_DragLeave(object sender, EventArgs e)
		{
			//toolStripLabelDateTime.Text = 
			//    toolStrip.Bounds.Y.ToString() + "," +
			//    toolStrip.Bounds.Height.ToString() + "," +
			//    Control.MousePosition.Y.ToString() + "," + 
			//    DateTime.Now.ToLongTimeString();


			Rectangle bounds = toolStrip.RectangleToScreen(toolStrip.Bounds);

			if (!bounds.Contains(Control.MousePosition))
			{
				HideInsertionBar();
				_PrevInsertionX = -1;
			}
		}

		private int GetMidway(ToolStripItem item)
		{
			int half = item.Bounds.Width / 2;
			return item.Bounds.X + half;
		}

		private void toolStrip_DragOver(object sender, DragEventArgs e)
		{
			HandleDragEnterOver(sender, e);
		}

		private void HandleDragEnterOver(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(_HandyBarDragItem.DragFormat))
				e.Effect = DragDropEffects.Move;
			else if (e.Data.GetDataPresent("FileNameW"))
			{
				e.Effect = DragDropEffects.Link;
				_MoveIndex = -1;
			}
			else
				e.Effect = DragDropEffects.None;

			//if (e.Effect == DragDropEffects.Move)
			if (e.Effect != DragDropEffects.None)
			{
				_DragOverIndex = -1;
				int mouseX = toolStrip.PointToClient(new Point(e.X, e.Y)).X;
				for (int i = 0; _DragOverIndex == -1 && i < toolStrip.Items.Count; i++)
				{
					ToolStripItem item = toolStrip.Items[i];

					int midway = GetMidway(item);

					if (mouseX < midway)
						_DragOverIndex = i;
				}

				if (_DragOverIndex == -1)
					_DragOverIndex = toolStrip.Items.Count;

				else if (_DragOverIndex == 0)
					_DragOverIndex = 1;

				if (_DragOverIndex != -1 && _DragOverIndex != _MoveIndex && _DragOverIndex != _MoveIndex+1)
				{
					int x = -1;

					if (_DragOverIndex < toolStrip.Items.Count)
					{
						ToolStripItem item = toolStrip.Items[_DragOverIndex];
						x = item.Bounds.X - 2;
					}
					else
					{
						ToolStripItem item = toolStrip.Items[toolStrip.Items.Count - 1];
						x = item.Bounds.X - 2 + item.Bounds.Width;
					}

					if (_PrevInsertionX != x)
					{
						pictureBoxInsertionBar.Location = new Point(x, 3);
						pictureBoxInsertionBarSerif1.Location = new Point(x - 2, 2);
						pictureBoxInsertionBarSerif2.Location = new Point(x + 2, 2);
						pictureBoxInsertionBarSerif3.Location = new Point(x - 2, 20);
						pictureBoxInsertionBarSerif4.Location = new Point(x + 2, 20);

						_PrevInsertionX = x;
					}
				}
				else
					HideInsertionBar();
			}
		}

		private void HideInsertionBar()
		{
			pictureBoxInsertionBar.Location = new Point(100, 100);
			pictureBoxInsertionBarSerif1.Location = new Point(100, 100);
			pictureBoxInsertionBarSerif2.Location = new Point(100, 100);
			pictureBoxInsertionBarSerif3.Location = new Point(100, 100);
			pictureBoxInsertionBarSerif4.Location = new Point(100, 100);
		}

		private void toolStrip_DragDrop(object sender, DragEventArgs e)
		{
			string format = "FileNameW";
			if (e.Data.GetDataPresent(format))
			{
				object obj = e.Data.GetData(format);
				if (obj.GetType() == typeof(string[]))
				{
					string[] array = (string[])obj;
					foreach (string text in array)
					{
						string filename = text;
						string args = "";

						if (Path.GetExtension(filename).ToUpper() == ".LNK")
						{
							try
							{
								/* Shortcut, get the actual contents */
								WshShell shell = new WshShellClass();
								Object sc = (object)shell.CreateShortcut(filename);
								filename = ((WshShortcut)sc).TargetPath;
								args = ((WshShortcut)sc).Arguments;
							}
							catch (Exception ex)
							{
								string s = ex.Message;
							}
						}

						if (_DragOverIndex != -1)
						{
							AddButton(filename, args, Path.GetFileName(filename));

							if (_DragOverIndex < toolStrip.Items.Count - 1)
							{
								ToolStripButton added = (ToolStripButton)toolStrip.Items[toolStrip.Items.Count - 1];
								toolStrip.Items.RemoveAt(toolStrip.Items.Count - 1);
								toolStrip.Items.Insert(_DragOverIndex, added);
							}

							_DragOverIndex = -1;
						}

						SaveShortcuts();
					}
				}
			}

			_PrevInsertionX = -1;
			HideInsertionBar();
			_DragBoxFromMouseDown = Rectangle.Empty;

			//else if (e.Data.GetDataPresent(_HandyBarDragItem.DragFormat))
			//{
			//    int index = toolStrip.Items.IndexOf(_HandyBarDragItem._SelectedButton);
			//    Point p = toolStrip.PointToClient(new Point(e.X, e.Y));
			//    ToolStripItem item = toolStrip.GetItemAt(p);
			//    if (item != null)
			//    {
			//        int insertIndex = toolStrip.Items.IndexOf(item);
			//        if (index != insertIndex)
			//            MessageBox.Show("aa");
			//    }
			//}
		}

		public void AddButton(string filename, string args, string toolTip)
		{
			if (System.IO.File.Exists(filename) || System.IO.Directory.Exists(filename))
			{
				Shortcut shortcut = new Shortcut();
				shortcut.Filename = filename;
				shortcut.Args = args;
				shortcut.ToolTip = toolTip;

				ToolStripButton button = new System.Windows.Forms.ToolStripButton();

				button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
				button.Size = new System.Drawing.Size(23, 22);
				button.Tag = shortcut;
				button.Image = Util.GetIconFromFile(filename).ToBitmap();
				button.ToolTipText = toolTip;
				button.ImageTransparentColor = Color.Fuchsia;

				button.Click += new System.EventHandler(this.button_Click);
				button.MouseEnter += new EventHandler(button_MouseEnter);
				button.MouseDown += new MouseEventHandler(button_MouseDown);
				button.MouseMove += new MouseEventHandler(button_MouseMove);
				button.MouseUp += new MouseEventHandler(button_MouseUp);

				toolStrip.Items.Add(button);

				MoveMe(Bounds);
			}
			else
				MessageBox.Show(String.Format("Unable to locate file/folder {0}. Shortcut was not added.", filename),
					"Unable to Add Shortcut", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		void button_MouseDown(object sender, MouseEventArgs e)
		{
			if (_SelectedButton != null)
				_DragBoxFromMouseDown = _SelectedButton.Bounds;
		}

		void button_MouseUp(object sender, MouseEventArgs e)
		{
			_DragBoxFromMouseDown = Rectangle.Empty;
		}

		void button_MouseEnter(object sender, EventArgs e)
		{
			if (_DragBoxFromMouseDown.IsEmpty)
				_SelectedButton = (ToolStripButton)sender;

			//Activate();
			Focus();
			//toolStrip.Focus();
			//ActiveControl = toolStrip;
		}

		private Cursor MakeCursor(IntPtr c1, Cursor c2)
		{
			//Bitmap bmCur = new Bitmap(c1.Size.Width, c1.Size.Height);

			Bitmap bmCur = Bitmap.FromHicon(c1);

			Graphics g = Graphics.FromImage(bmCur);

			//Graphics g = Graphics.FromHdcInternal(c1);

			//c1.Draw(g, new Rectangle(0, 0, c1.Size.Width, c1.Size.Height));

			Cursor cursor = new Cursor(bmCur.GetHicon());

			return cursor;
		}

		void button_MouseMove(object sender, MouseEventArgs e)
		{
			if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
			{
				ToolStripButton button = (ToolStripButton)sender;
				
				// If the mouse moves outside the rectangle, start the drag.

				if (_DragBoxFromMouseDown != Rectangle.Empty &&
					!_DragBoxFromMouseDown.Contains(button.Bounds.X + e.X, button.Bounds.Y + e.Y))
				{
					// Create custom cursors for the drag-and-drop operation.
					try
					{
						Shortcut shortcut = (Shortcut)_SelectedButton.Tag;
						_MoveDragCursor = new Cursor(Util.GetIntPtrFromFile(shortcut.Filename));
					}
					catch
					{
						_MoveDragCursor = null;
					}
					finally
					{
						_HandyBarDragItem._SelectedButton = _SelectedButton;

						_MoveIndex = toolStrip.Items.IndexOf(_SelectedButton);

						_MoveDragInProgress = true;

						DragDropEffects dropEffect = DoDragDrop(_HandyBarDragItem, DragDropEffects.Move);

						_PrevInsertionX = -1;

						if (_PrevInsertionX != -1)
							toolStrip.Invalidate(new Rectangle(_PrevInsertionX - 1, 0, _PrevInsertionX + 1, toolStrip.Height));

						_PrevInsertionX = -1;

						HideInsertionBar();

						_MoveDragInProgress = false;

						_DragBoxFromMouseDown = Rectangle.Empty;

						if (dropEffect == DragDropEffects.Move)
						{
							if (_DragOverIndex != -1)
							{
								if (_DragOverIndex > _MoveIndex)
									_DragOverIndex--;

								if (_DragOverIndex != _MoveIndex)
								{
									toolStrip.Items.RemoveAt(_MoveIndex);
									toolStrip.Items.Insert(_DragOverIndex, _HandyBarDragItem._SelectedButton);

									SaveShortcuts();
								}
							}
						}

						// Dispose of the cursors since they are no longer needed.
						if (_MoveDragCursor != null)
							_MoveDragCursor.Dispose();
					}
				}
			}
		}

		private void Form1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{
			e.UseDefaultCursors = false;

			if (Bounds.Contains(Control.MousePosition))
			{
				if (_MoveDragInProgress && _MoveDragCursor != null)
					Cursor.Current = _MoveDragCursor;

				else
					e.UseDefaultCursors = true;
			}
			else
			{
				_PrevInsertionX = -1;
				Cursor.Current = Cursors.No;
				HideInsertionBar();
			}
		}

		private void button_Click(object sender, EventArgs e)
		{
			ToolStripButton button = (ToolStripButton)sender;
			Shortcut shortcut = (Shortcut)button.Tag;

			string executableName = shortcut.Filename;
			string args = shortcut.Args;

			if (executableName != "")
				Process.Start(executableName, args);
			else
				MessageBox.Show("Unable to launch application '" + executableName + "'.",
					"Unable to launch application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		private void removeShortcutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_SelectedButton != null)
			{
				toolStrip.Items.Remove(_SelectedButton);
				_SelectedButton = null;
				//toolTip.SetToolTip(toolStrip, String.Empty);
				MoveMe(Bounds);
				SaveShortcuts();
			}
		}

		private void toolStrip_MouseDown(object sender, MouseEventArgs e)
		{
			//toolStripLabelDateTime.Text = "toolStrip_MouseDown " + DateTime.Now.ToLongTimeString();
			OnMouseDown(sender, e);
		}

		private void toolStrip_MouseMove(object sender, MouseEventArgs e)
		{
			_SelectedButton = null;
			//toolTip.SetToolTip(toolStrip, String.Empty);
		}

		private void toolStripLabelDateTime_MouseMove(object sender, MouseEventArgs e)
		{
			_SelectedButton = null;
			//toolTip.SetToolTip(toolStrip, String.Empty);
		}

		private void addShortcutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				AddButton(openFileDialog.FileName, "", Path.GetFileName(openFileDialog.FileName));
				SaveShortcuts();
			}
		}

		private void configureToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormConfigure form = new FormConfigure(this, toolStrip);
			form.ShowDialog();
		}

		private string ChildText(XmlNode parent, string childName)
		{
			string text = String.Empty;
			string xpath = String.Format("{0}/text()", childName);
			XmlNode textNode = parent.SelectSingleNode(xpath);
			if (textNode != null)
				text = textNode.InnerText;
			return text;
		}

		//private void loadShortcutsFromJoshsGoodbarToolStripMenuItem_Click(object sender, EventArgs e)
		//{
		//    if (openFileDialog.ShowDialog() == DialogResult.OK)
		//    {
		//        XmlDocument doc = new XmlDocument();
		//        doc.Load(openFileDialog.FileName);
		//        XmlNodeList list = doc.SelectNodes("shortcutList/shortcutItem");
		//        foreach (XmlNode node in list)
		//            AddButton(ChildText(node, "filename"), ChildText(node, "args"), ChildText(node, "toolTip"));

		//        SaveShortcuts();
		//    }
		//}

		private void Form1_MouseEnter(object sender, EventArgs e)
		{
			//toolStripLabelDateTime.Text = "Form1_MouseEnter " + DateTime.Now.ToLongTimeString();
			//Activate();
			Focus();
			//toolStrip.Focus();
			//ActiveControl = toolStrip;
		}

		private void Form1_MouseLeave(object sender, EventArgs e)
		{
			_PrevInsertionX = -1;
			//HideInsertionBar();
		}

		private void toolStrip_Click(object sender, EventArgs e)
		{
			//toolStripLabelDateTime.Text = "toolStrip_Click " + DateTime.Now.ToLongTimeString();
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			//toolStripLabelDateTime.Text = "Form1_MouseDown " + DateTime.Now.ToLongTimeString();
		}

        private void toolStrip_MouseEnter(object sender, EventArgs e)
        {
            //Opacity = 1;
        }

        private void toolStrip_MouseLeave(object sender, EventArgs e)
        {
			//Opacity = _SaveOpacity;
        }
	}

	public class HandyBarDragItem
	{
		public string DragFormat
		{
			get { return "HandyBar.HandyBarDragItem"; }
		}

		public ToolStripButton _SelectedButton;
	}
}