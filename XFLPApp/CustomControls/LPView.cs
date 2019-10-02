using System;
using Xamarin.Forms;

namespace XFLPApp.CustomControls
{
    public class LPView:View
    {
        public LPView()
        {
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
        }

        public static readonly BindableProperty UrlProperty =
           BindableProperty.Create("Url", typeof(string), typeof(LPView), "");

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
    }
}
