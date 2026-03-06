namespace SlowReporting;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnReport1Clicked(object? sender, EventArgs e)
    {
        using var report = new Report1();
        ShowReport(report);
    }

    private void OnReport2Clicked(object? sender, EventArgs e)
    {
        using var report = new Report2();
        ShowReport(report);
    }

    private void ShowReport(DevExpress.XtraReports.UI.XtraReport report)
    {
        report.CreateDocument();

        using var stream = new MemoryStream();
        report.ExportToImage(stream, new DevExpress.XtraPrinting.ImageExportOptions());

        var bytes = stream.ToArray();
        ReportImage.Source = ImageSource.FromStream(() => new MemoryStream(bytes));
    }
}
