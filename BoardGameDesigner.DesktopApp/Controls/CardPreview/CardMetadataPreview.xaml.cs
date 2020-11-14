using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using BoardGameDesigner.Model.Design;
using BoardGameDesigner.Model.Design.Metatada;
using BoardGameDesigner.ViewModel;
using BoardGameDesigner.ViewModel.DataSources;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp.Controls.CardPreview
{
    /// <summary>
    /// Interaction logic for CardMetadataPreview.xaml
    /// </summary>
    public partial class CardMetadataPreview : UserControl, IBoardGameControl
    {
        private IDataSource<CardDesign> _cardDesignSource;

        public CardMetadataPreview()
        {
            InitializeComponent();
        }

        private void _cardViewModel_SelectedFamilyCardChanged(object sender, Model.Events.CardEvents.SelectedCardFamilyChanged e)
        {
            var grid = this.PropertiesGrid;

            grid.RowDefinitions.Clear();

            var currentItem= _cardDesignSource.GetAll().First();

            int row = 0;
            foreach (var item in currentItem.ComponentMetadata)
            {
                grid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(30)
                });

                Label block = new Label();
                block.Content = item.Name;
                Grid.SetRow(block,row);
                Grid.SetColumn(block, 0);
                grid.Children.Add(block);

                var type = item.GetType();
                var arguments = type.GenericTypeArguments.FirstOrDefault();

                if (arguments == typeof(ColorMetadata))
                {
                    ComboBox colorSelect = new ComboBox();
                    colorSelect.Items.Add(new ColorItem{Name = "Red"});

                    var dataTemplate = new DataTemplate();

                    var stackPanel = new FrameworkElementFactory(typeof(StackPanel));

                    var text = new FrameworkElementFactory(typeof(TextBlock));
                    text.SetBinding(TextBlock.TextProperty, new Binding("Name"));

                    stackPanel.AppendChild(text);

                    dataTemplate.VisualTree = stackPanel;

                    colorSelect.ItemTemplate = dataTemplate;

                    Grid.SetRow(colorSelect, row);
                    Grid.SetColumn(colorSelect, 1);
                    grid.Children.Add(colorSelect);
                }
                row++;
            }
        }

        public class ColorItem
        {
            public string Name { get; set; }
        }

        private void _cardViewModel_SelectedCardChanged(object sender, Model.Events.CardEvents.SelectedCardChanged e)
        {

        }

        public void InitializeControl(Container container)
        {
            var gameDetailsVm = container.GetInstance<GameDetailsViewModel>();
            _cardDesignSource = container.GetInstance<IDataSource<CardDesign>>();

            gameDetailsVm.SelectedFamilyCardChanged += _cardViewModel_SelectedFamilyCardChanged;
            gameDetailsVm.SelectedCardChanged += _cardViewModel_SelectedCardChanged;
        }
    }
}
