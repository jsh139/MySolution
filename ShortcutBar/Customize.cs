using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using IWshRuntimeLibrary;

namespace ShortcutBar
{
	/// <summary>
	/// Summary description for Customize.
	/// </summary>
	public class Customize : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnMoveUp;
		private System.Windows.Forms.Button btnMoveDown;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuEditShortcut;
		private System.Windows.Forms.MenuItem mnuEditToolTip;
		private System.Windows.Forms.MenuItem mnuEditArgs;
		private ArrayList arrShortcuts;

		public ArrayList Shortcuts { get { return arrShortcuts; } }

		public Customize(ArrayList a)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			arrShortcuts = new ArrayList();
			arrShortcuts = a;

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
				if(components != null)
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Customize));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.mnuEditShortcut = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuEditToolTip = new System.Windows.Forms.MenuItem();
			this.mnuEditArgs = new System.Windows.Forms.MenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnMoveDown = new System.Windows.Forms.Button();
			this.btnMoveUp = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// listView1
			// 
			this.listView1.AllowDrop = true;
			this.listView1.AutoArrange = false;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																												this.columnHeader1,
																												this.columnHeader2,
																												this.columnHeader3});
			this.listView1.ContextMenu = this.contextMenu1;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.LabelEdit = true;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(504, 374);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
			this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Shortcut";
			this.columnHeader1.Width = 240;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "ToolTip";
			this.columnHeader2.Width = 110;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Additional Arguments";
			this.columnHeader3.Width = 150;
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																												 this.menuItem1,
																												 this.menuItem3,
																												 this.mnuEditShortcut,
																												 this.mnuEditToolTip,
																												 this.mnuEditArgs});
			// 
			// mnuEditShortcut
			// 
			this.mnuEditShortcut.Index = 2;
			this.mnuEditShortcut.Text = "&Edit Shortcut";
			this.mnuEditShortcut.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuItem1.Text = "&Remove";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// mnuEditToolTip
			// 
			this.mnuEditToolTip.Index = 3;
			this.mnuEditToolTip.Text = "Edit &ToolTip";
			this.mnuEditToolTip.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// mnuEditArgs
			// 
			this.mnuEditArgs.Index = 4;
			this.mnuEditArgs.Text = "Edit &Arguments";
			this.mnuEditArgs.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 374);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(552, 64);
			this.panel1.TabIndex = 2;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(166, 20);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(100, 24);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "&Save Changes";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(286, 20);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnMoveDown);
			this.panel2.Controls.Add(this.btnMoveUp);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(504, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(48, 374);
			this.panel2.TabIndex = 1;
			// 
			// btnMoveDown
			// 
			this.btnMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnMoveDown.Enabled = false;
			this.btnMoveDown.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.btnMoveDown.Location = new System.Drawing.Point(12, 203);
			this.btnMoveDown.Name = "btnMoveDown";
			this.btnMoveDown.Size = new System.Drawing.Size(24, 24);
			this.btnMoveDown.TabIndex = 1;
			this.btnMoveDown.Text = "п";
			this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
			// 
			// btnMoveUp
			// 
			this.btnMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.btnMoveUp.Enabled = false;
			this.btnMoveUp.Font = new System.Drawing.Font("Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(2)));
			this.btnMoveUp.Location = new System.Drawing.Point(12, 147);
			this.btnMoveUp.Name = "btnMoveUp";
			this.btnMoveUp.Size = new System.Drawing.Size(24, 24);
			this.btnMoveUp.TabIndex = 0;
			this.btnMoveUp.Text = "ннн";
			this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
			// 
			// Customize
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(552, 438);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(560, 472);
			this.Name = "Customize";
			this.Text = "Customize";
			this.Load += new System.EventHandler(this.Customize_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Customize_Load(object sender, System.EventArgs e)
		{
			foreach (Shortcut s in arrShortcuts)
				AddListItem(s);
		}

		private void AddListItem(Shortcut s)
		{
			imageList1.Images.Add(Util.GetIconFromFile(s.Filename));

			ListViewItem l = new ListViewItem(s.Filename, imageList1.Images.Count-1);
			l.SubItems.Add(s.ToolTip);
			l.SubItems.Add(s.Args);
			
			listView1.Items.Add(l);
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnMoveUp.Enabled = btnMoveDown.Enabled = (listView1.SelectedIndices.Count == 1);
			mnuEditShortcut.Enabled = mnuEditArgs.Enabled = mnuEditToolTip.Enabled = 
				(listView1.SelectedIndices.Count == 1);
		}

		private void btnMoveUp_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
			{
				int idx = listView1.SelectedIndices[0];
				int NewIdx = idx - 1;

				if (idx == 0)
					NewIdx = listView1.Items.Count-1;

				ListViewItem l = listView1.Items[idx];
				listView1.Items.RemoveAt(idx);
				listView1.Items.Insert(NewIdx, l);
			}
		}

		private void btnMoveDown_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
			{
				int idx = listView1.SelectedIndices[0];
				int NewIdx = idx + 1;

				if (idx == listView1.Items.Count-1)
					NewIdx = 0;

				ListViewItem l = listView1.Items[idx];
				listView1.Items.RemoveAt(idx);
				listView1.Items.Insert(NewIdx, l);
			}
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			foreach (ListViewItem l in listView1.SelectedItems)
				listView1.Items.Remove(l);
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
				listView1.SelectedItems[0].BeginEdit();;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
			{
				Prompt p = new Prompt("Enter new tooltip text", "Edit ToolTip", "OK", listView1.SelectedItems[0].SubItems[1].Text);

				if (p.ShowDialog(this) == DialogResult.OK)
					listView1.SelectedItems[0].SubItems[1].Text = p.Result;
			}
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			if (listView1.SelectedIndices.Count == 1)
			{
				Prompt p = new Prompt("Enter new command line arguments", "Edit Arguments", "OK", listView1.SelectedItems[0].SubItems[2].Text);

				if (p.ShowDialog(this) == DialogResult.OK)
					listView1.SelectedItems[0].SubItems[2].Text = p.Result;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			arrShortcuts.Clear();

			foreach (ListViewItem l in listView1.Items)
			{
				Shortcut s = new Shortcut();
				s.Filename = l.SubItems[0].Text;
				s.ToolTip = l.SubItems[1].Text;
				s.Args = l.SubItems[2].Text;

				arrShortcuts.Add(s);
			}

			Form1 f = (Form1)this.Owner;
			foreach (Shortcut s in arrShortcuts)
				f.arrNewShortcuts.Add(s);
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
			{
				foreach (ListViewItem l in listView1.SelectedItems)
					listView1.Items.Remove(l);
			}
		}

		private void listView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileNameW"))
				e.Effect = DragDropEffects.Link;
			else
				e.Effect = DragDropEffects.None;
		}

		private void listView1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
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

				Shortcut sh = new Shortcut();
				sh.Filename = Filename;
				sh.ToolTip = Path.GetFileName(Filename);
				sh.Args = Args;

				AddListItem(sh);
			}
		}
	}
}
