﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReClassNET.UI
{
	public class PlaceholderTextBox : TextBox
	{
		private Font fontBackup;
		private Color foreColorBackup;
		private Color backColorBackup;

		/// <summary>
		/// The color of the placeholder text.
		/// </summary>
		public Color PlaceholderColor { get; set; } = SystemColors.ControlDarkDark;

		/// <summary>
		/// The placeholder text.
		/// </summary>
		public string PlaceholderText { get; set; }

		public PlaceholderTextBox()
		{
			fontBackup = Font;
			foreColorBackup = ForeColor;
			backColorBackup = BackColor;

			SetStyle(ControlStyles.UserPaint, true);
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);

			if (string.IsNullOrEmpty(Text))
			{
				if (!GetStyle(ControlStyles.UserPaint))
				{
					fontBackup = Font;
					foreColorBackup = ForeColor;
					backColorBackup = BackColor;

					SetStyle(ControlStyles.UserPaint, true);
				}
			}
			else
			{
				if (GetStyle(ControlStyles.UserPaint))
				{
					SetStyle(ControlStyles.UserPaint, false);

					Font = fontBackup;
					ForeColor = foreColorBackup;
					BackColor = backColorBackup;
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (string.IsNullOrEmpty(Text) && Focused == false)
			{
				e.Graphics.DrawString(PlaceholderText ?? string.Empty, Font, new SolidBrush(PlaceholderColor), new PointF(-1.0f, 1.0f));
			}
		}
	}
}
