using System;
using Xamarin.Forms;

namespace Projeto
{
    public class HeaderCell: ViewCell
    {
        public HeaderCell()
        {
            this.Height = 40;

            var title = new Label
            {
                FontSize = 16,
                TextColor = Color.Black,
                VerticalOptions = LayoutOptions.Center
            };

            title.SetBinding(Label.TextProperty, "Key");

            View = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 40,
                BackgroundColor = Color.White,
                Padding = 5,
                Orientation = StackOrientation.Horizontal,
                Children = { title }
            };


        }

    }
}
