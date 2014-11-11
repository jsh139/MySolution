using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HandyBar
{
	public partial class FormConfigure : Form
	{
		private Form1 _Form1;

		public FormConfigure(Form1 form1, ToolStrip toolStrip)
		{
			_Form1 = form1;

			InitializeComponent();
			for (int i = 1; i < toolStrip.Items.Count; i++)
			{
				ToolStripButton button = (ToolStripButton)toolStrip.Items[i];
				Shortcut shortcut = (Shortcut)button.Tag;
				dataGridViewShortcuts.Rows.Add(shortcut.Filename, shortcut.Args, shortcut.ToolTip);
			}
			Enable();
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			int index = dataGridViewShortcuts.SelectedRows[0].Index;
			DataGridViewRow row = dataGridViewShortcuts.Rows[index];
			dataGridViewShortcuts.Rows.RemoveAt(index);
			dataGridViewShortcuts.Rows.Insert(index - 1, row);

			for (int i = dataGridViewShortcuts.SelectedRows.Count-1; i >= 0; i--)
				dataGridViewShortcuts.SelectedRows[i].Selected = false;
			
			row.Selected = true;
			dataGridViewShortcuts.FirstDisplayedScrollingRowIndex = index - 1;
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			int index = dataGridViewShortcuts.SelectedRows[0].Index;
			DataGridViewRow row = dataGridViewShortcuts.Rows[index];
			dataGridViewShortcuts.Rows.RemoveAt(index);
			dataGridViewShortcuts.Rows.Insert(index + 1, row);

			for (int i = dataGridViewShortcuts.SelectedRows.Count - 1; i >= 0; i--)
				dataGridViewShortcuts.SelectedRows[i].Selected = false;

			row.Selected = true;

			dataGridViewShortcuts.FirstDisplayedScrollingRowIndex = index + 1;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			_Form1.RemoveButtons();

			foreach (DataGridViewRow row in dataGridViewShortcuts.Rows)
				if (!row.IsNewRow)
				{
					string filename = (string)row.Cells[0].Value;
					string args = (string)row.Cells[1].Value;
					string toolTip = (string)row.Cells[2].Value;

					_Form1.AddButton(filename, args, toolTip);
				}

			_Form1.SaveShortcuts();
		}

		private void Enable()
		{
			bool enable = (dataGridViewShortcuts.SelectedRows.Count == 1);

			if (enable)
			{
				int index = dataGridViewShortcuts.SelectedRows[0].Index;
				buttonMoveUp.Enabled = (index > 0);
				buttonMoveDown.Enabled = (index < dataGridViewShortcuts.Rows.Count-2);
			}
			else
			{
				buttonMoveUp.Enabled = false;
				buttonMoveDown.Enabled = false;
			}
		}

		private void dataGridViewShortcuts_SelectionChanged(object sender, EventArgs e)
		{
			Enable();
		}

		private void FormConfigure_Load(object sender, EventArgs e)
		{
			Enable();
		}
	}
}