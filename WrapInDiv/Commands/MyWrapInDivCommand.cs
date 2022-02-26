namespace WrapInDiv
{
    [Command(PackageIds.MyWrapInDivCommand)]
    internal sealed class MyWrapInDivCommand : BaseCommand<MyWrapInDivCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var docView = await VS.Documents.GetActiveDocumentViewAsync();
            var selections = docView?.TextView.Selection.SelectedSpans;

            for (int i = selections.Count - 1; i >= 0; i--)
            {
                docView.TextBuffer.Replace(selections[i], $@"<div class="""">{selections[i].GetText()}</div>");
            }

        }
    }
}
