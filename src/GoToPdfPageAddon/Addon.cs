using GoToPdfPage.Properties;
using SwissAcademic.Citavi.Controls.Wpf;
using SwissAcademic.Citavi.Shell;
using SwissAcademic.Citavi.Shell.Controls.Preview;
using SwissAcademic.Controls;
using System;
using System.Windows.Forms;

namespace GoToPdfPage
{
    public class Addon : CitaviAddOn<MainForm>
    {
        #region Constants

        const string PDFPageJumpAddon_Command = "PDFPageJumpAddon.Command";

        #endregion

        #region Eventhandlers

        public override void OnApplicationIdle(MainForm mainForm)
        {
            var button = mainForm
                            .GetMainCommandbarManager()
                            .GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu)
                            .GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.View)
                            .GetCommandbarButton(PDFPageJumpAddon_Command);

            if (button != null)
            {
                button.Tool.SharedProps.Enabled = mainForm.PreviewControl.ActiveLocation?.Address.Resolve().GetLocalPathSafe().EndsWith("pdf") ?? false;
            }
        }

        public override void OnHostingFormLoaded(MainForm mainForm)
        {
            var button = mainForm.GetMainCommandbarManager()
                              .GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu)
                              .GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.View)
                              .AddCommandbarButton(PDFPageJumpAddon_Command, Strings.Command, CommandbarItemStyle.Text);
            button.Shortcut = Shortcut.CtrlJ;
            button.Visible = false;
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
        }

        public override void OnLocalizing(MainForm mainForm)
        {
            var button = mainForm
                            .GetMainCommandbarManager()
                            .GetReferenceEditorCommandbar(MainFormReferenceEditorCommandbarId.Menu)
                            .GetCommandbarMenu(MainFormReferenceEditorCommandbarMenuId.View)
                            .GetCommandbarButton(PDFPageJumpAddon_Command);

            if (button != null)
            {
                button.Text = Strings.Command;
            }
        }

        #endregion
    }
}
