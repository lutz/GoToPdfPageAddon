using GoToPdfPage.Properties;
using SwissAcademic.Citavi.Controls.Wpf;
using SwissAcademic.Citavi.Shell;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoToPdfPage
{
    public partial class GoToPageForm : Form
    {
        #region Fields

        MainForm _mainForm;
        PdfViewControl _pdfViewControl;
        List<PageLabelWrapper> _labels;

        #endregion

        #region Constructors

        public GoToPageForm(MainForm owner, PdfViewControl pdfViewControl)
        {
            InitializeComponent();

            _labels = new List<PageLabelWrapper>();
            Owner = _mainForm = owner;
            _pdfViewControl = pdfViewControl;
            Icon = owner.Icon;
        }

        #endregion

        #region EventHandler

        void CboSuggestions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();

            if (e.KeyCode == Keys.Enter)
            {
                var index = cboSuggestions.SelectedIndex;

                if (index == -1) return;

                _pdfViewControl.CurrentPage = _labels[index].PhysicalNumber;
                Close();
            }
        }

        void Window_Load(object sender, EventArgs e)
        {
            Text = Strings.Command;

            var pageCount = _pdfViewControl.Document.GetPageCount();

            for (int i = 1; i <= pageCount; i++)
            {
                var label = _pdfViewControl.Document.GetPageLabel(i);
                if (label.IsValid())
                {
                    var labelTitle = label.GetLabelTitle(i);
                    cboSuggestions.Items.Add(labelTitle);
                    _labels.Add(new PageLabelWrapper { PhysicalNumber = i, HasLogicalNumber = true, LogicalNumber = labelTitle });
                }
                else
                {
                    cboSuggestions.Items.Add(i.ToString());
                    _labels.Add(new PageLabelWrapper { PhysicalNumber = i, HasLogicalNumber = false });
                }
            }

            cboSuggestions.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        #endregion
    }
}
