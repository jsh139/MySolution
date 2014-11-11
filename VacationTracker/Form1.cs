using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VacationTracker
{
	public partial class Form1 : Form
	{
		private string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September",
				"October", "November", "December" };
		private string[] Days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
		
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			int Year = DateTime.Today.AddYears(-1).Year;
			foreach (string s in Months)
				cboMonth.Items.Add(s + " - " + Year);

			Year = DateTime.Today.Year;
			foreach (string s in Months)
				cboMonth.Items.Add(s + " - " + Year);
			
			Year = DateTime.Today.AddYears(1).Year;
			foreach (string s in Months)
				cboMonth.Items.Add(s + " - " + Year);

			cboMonth.SelectedItem = Months[DateTime.Today.Month-1] + " - " + DateTime.Today.Year;
		}

		private void AddLabel(string Text, int Col, int Row)
		{
			AddLabel(Text, Col, Row, Color.White, Color.Black);
		}

		private void AddLabel(string Text, int Col, int Row, Color BackColor, Color ForeColor)
		{
			Label l = new Label();
			l.Text = Text;
			l.BackColor = BackColor;
			l.ForeColor = ForeColor;
			l.Height = 16;

			tabCalendar.Controls.Add(l, Col, Row);
		}

		private void AddWeekdays()
		{
			int i = 0;
			foreach (string s in Days)
				AddLabel(s, i++, 0, Color.LightBlue, Color.Black);
		}

		private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			/* Fill in the days of the month selected */
			tabCalendar.Controls.Clear();
			AddWeekdays();

			int StartingCol = 0;
			int StartingRow = 1;
			string Item = cboMonth.SelectedItem.ToString();
			string Month = Item.Substring(0, Item.IndexOf('-') - 1);
			string Year = Item.Substring(Item.IndexOf('-') + 2, 4);
			DateTime FirstOfMonth = DateTime.Parse(String.Format("{0} 1, {1}", Month, Year));

			StartingCol = Convert.ToInt32(FirstOfMonth.DayOfWeek);

			for (int i = 1; i <= DateTime.DaysInMonth(FirstOfMonth.Year, FirstOfMonth.Month); i++)
			{
				AddLabel(i.ToString(), StartingCol++, StartingRow);

				if (StartingCol == 7)
				{
					StartingCol = 0;
					StartingRow++;
				}
			}

			/* Fill in the prior month's dates */
			StartingCol = Convert.ToInt32(FirstOfMonth.DayOfWeek) - 1;
			DateTime PrevMonth = FirstOfMonth.AddMonths(-1);
			int StartingDay = DateTime.DaysInMonth(PrevMonth.Year, PrevMonth.Month);

			while (StartingCol >= 0)
			{
				AddLabel(StartingDay.ToString(), StartingCol--, 1, Color.White, Color.DarkGray);
				--StartingDay;
			}

			/* Fill in the next month's dates */
			DateTime NextMonth = FirstOfMonth.AddMonths(1);
			StartingCol = Convert.ToInt32(NextMonth.DayOfWeek);

			for (int i = 1; i <= DateTime.DaysInMonth(NextMonth.Year, NextMonth.Month) && 
				StartingRow < tabCalendar.RowCount; i++)
			{
				AddLabel(i.ToString(), StartingCol++, StartingRow, Color.White, Color.DarkGray);

				if (StartingCol == 7)
				{
					StartingCol = 0;
					StartingRow++;
				}
			}

			btnAdvanceMonth.Enabled = (cboMonth.SelectedIndex < cboMonth.Items.Count - 1);
			btnDecreaseMonth.Enabled = (cboMonth.SelectedIndex > 0);
		}

		private void btnAdvanceMonth_Click(object sender, EventArgs e)
		{
			cboMonth.SelectedIndex++;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			cboMonth.SelectedIndex--;
		}

		private void tabCalendar_MouseClick(object sender, MouseEventArgs e)
		{
			Control c = tabCalendar.GetChildAtPoint(new Point(e.X, e.Y));

			
		}
	}
}