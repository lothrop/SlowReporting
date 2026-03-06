using Android.App;
using Android.Runtime;
using DevExpress.Drawing;

namespace SlowReporting;

[Application]
public class MainApplication(IntPtr handle, JniHandleOwnership ownership) : MauiApplication(handle, ownership)
{
    protected override MauiApp CreateMauiApp()
    {
        return MauiProgram.CreateMauiApp();
    }

    public override void OnCreate()
    {
        base.OnCreate();
        LoadFont("OpenSans-Regular.ttf");
        LoadFont("OpenSans-Semibold.ttf");
    }

    private void LoadFont(string assetFileName)
    {
        using var rd = new StreamReader(Assets.Open(assetFileName));
        using var ms = new MemoryStream();
        rd.BaseStream.CopyTo(ms);
        DXFontRepository.Instance.AddFont(ms);
    }
}