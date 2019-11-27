using System;
using SwissAcademic.Citavi.Shell;
using System.Windows.Forms;
using SwissAcademic.Controls;
using SwissAcademic.Citavi.Shell.Controls.Preview;
using SwissAcademic.Citavi.Controls.Wpf;
using GoToPdfPage.Properties;

namespace GoToPdfPage
{
    public class PDFPageJumpAddon : CitaviAddOn<MainForm>
    {
        #region Constants

        const string PDFPageJumpAddon_Command = "PDFPageJumpAddon.Command";

        #endregion

        #region Fields

        CommandbarButton _button;

        #endregion

        #region Eventhandlers

        public override void OnApplicationIdle(MainForm mainForm)
        {
            if (_button != null)
            {
                _button.Tool.SharedProps.Enabled = mainForm.PreviewControl.ActiveLocation?.Address.Resolve().GetLocalPathSafe().EndsWith("pdf") ?? false;
            }

            base.OnApplicationIdle(mainForm);
        }

        public override void OnHostingFormLoaded(MainForm mainForm)
        {
            _button = mainForm.GetMainCommandbarManager()
                              .GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu)
                              .GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.View)
                              .AddCommandbarButton(PDFPageJumpAddon_Command, Strings.Command, CommandbarItemStyle.Text);
            _button.Shortcut = Shortcut.CtrlJ;
            _button.Visible = false;
            base.OnHostingFormLoaded(mainForm);
        }

        public override void OnBeforePerformingCommand(MainForm mainForm, BeforePerformingCommandEventArgs e)
        {
            if (e.Key.Equals(PDFPageJumpAddon_Command, StringComparison.OrdinalIgnoreCase))
            {
                var pdfViewControl = mainForm.PreviewControl.GetProperty<PreviewControl, PdfViewControl>("PdfViewControl");

                if (pdfViewControl != null)
                {
                    using (var pdfPageJump = new GoToPageForm(mainForm, pdfViewControl))
                    {
                        pdfPageJump.ShowDialog();
                    }
                }

                e.Handled = true;
            }

            base.OnBeforePerformingCommand(mainForm, e);
        }

        public override void OnLocalizing(MainForm form)
        {
            if (_button != null) _button.Text = Strings.Command;

            base.OnLocalizing(form);
        }

        #endregion
    }
}
