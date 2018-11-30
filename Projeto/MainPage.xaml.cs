using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Projeto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            listview();
        }

        public class ListItem
        {
            public string Source { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }

        }


        public void listview()
        {
            List<ListViewGroup> listItems = new List<ListViewGroup>
            {
                new ListViewGroup("Important", new List<ListItem>
                {
                    new ListItem{Title = "First", Description = "1st"},
                    new ListItem{Title = "Second", Description = "2st"},

                }),

                new ListViewGroup("Less Important", new List<ListItem>
                {
                    new ListItem{Title = "Third", Description = "3rd Third"}

                })


            };




            var listview = new ListView
            {
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("Key"),
                GroupHeaderTemplate = new DataTemplate(typeof(HeaderCell)),
                ItemTemplate = new DataTemplate(typeof(TextCell))
                {
                    Bindings =
                    {
                        {TextCell.TextProperty, new Binding("Title")},
                        {TextCell.DetailProperty, new Binding("Description")}

                    }

                },
                ItemsSource = listItems
            };

        

            listview.RowHeight = 80;
            listview.BackgroundColor = Color.Black;
            listview.ItemTemplate = new DataTemplate(typeof(ListItemCell));
            Content = listview;


        }


        class ListItemCell : ViewCell
        {
            public ListItemCell()
            {
                Label titlelabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 15,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White
                };
                titlelabel.SetBinding(Label.TextProperty, "Title");

                Label desclabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 15,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White
                };
                desclabel.SetBinding(Label.TextProperty, "Desc");

                StackLayout viewlayoutitem = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Vertical,
                    Children = { titlelabel, desclabel }
                };

                Label pricelabel = new Label
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    FontSize = 15,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.White
                };
                pricelabel.SetBinding(Label.TextProperty, "Price");

                var moreAction = new MenuItem
                {
                    Text = "More"
                };

                moreAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                moreAction.Clicked += (sender, e) =>
                {
                    var mi = ((MenuItem)sender);
                    var item = (ListItem)mi.CommandParameter;
                    Debug.WriteLine("More clickked on row" + item.Title.ToString());

                };

                ContextActions.Add(moreAction);


                var deleteAction = new MenuItem
                {
                    Text = "Delete",
                    IsDestructive = true
                };

                deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));

                deleteAction.Clicked += DeleteAction_Clicked;
                ContextActions.Add(deleteAction);

                StackLayout stackLayout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(25, 10, 55, 15),
                    Children = { viewlayoutitem, pricelabel }
                };
     

                View = stackLayout;

            }


            void DeleteAction_Clicked(object sender, EventArgs e)
            {
                var mi = ((MenuItem)sender);
                var item = (ListItem)mi.CommandParameter;


            }

        }

    }
}