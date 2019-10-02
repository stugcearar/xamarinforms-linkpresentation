using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using XFLPApp.CustomControls;
using XFLPApp.iOS.CustomRenderers;
using LinkPresentation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LPView), typeof(LPViewRenderer))]
namespace XFLPApp.iOS.CustomRenderers
{
    public class LPViewRenderer : ViewRenderer<LPView, UIView>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<LPView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null) return;
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var linkView = new LPLinkView(new NSUrl(e.NewElement.Url.ToString()));
                    var provider = new LPMetadataProvider();
                    provider.StartFetchingMetadata(new NSUrl(e.NewElement.Url), (metadata, error) =>
                    {
                        DispatchQueue.MainQueue.DispatchAsync(() =>
                        {
                            linkView.Metadata = metadata;
                        });
                    });
                    linkView.Frame = new CoreGraphics.CGRect(20, 20, 1000, 1000);
                    SetNativeControl(linkView);
                }
            }

        }
    }
}
