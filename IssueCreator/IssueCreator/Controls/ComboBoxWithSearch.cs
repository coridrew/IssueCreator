﻿using IssueCreator.Helpers;
using System.Windows.Forms;

namespace IssueCreator.Controls
{
    public partial class ComboBoxWithSearch : ComboBox
    {
        public ComboBoxWithSearch() : base()
        {
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var returnValue = base.CreateParams;
                returnValue.Style |= 0x2; // Add LBS_SORT
                returnValue.Style ^= 128; // Remove LBS_USETABSTOPS (optional)
                return returnValue;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Back))
            {
                var result =  StringHelpers.ProcessCtrlBackspace(Text, SelectionStart, out string remainingText, out int newSelectionIndex);
                Text = remainingText;
                SelectionStart = newSelectionIndex;
                return result;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
