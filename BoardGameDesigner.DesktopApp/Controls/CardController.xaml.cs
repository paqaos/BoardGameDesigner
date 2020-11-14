using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BoardGameDesigner.ViewModel;
using SimpleInjector;

namespace BoardGameDesigner.DesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for CardController.xaml
    /// </summary>
    public partial class CardController : UserControl, IBoardGameControl
    {
        public CardController()
        {
            InitializeComponent();
        }

        private void CardFamilies_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is GameDetailsViewModel context)
            {
                var selectedItem = this.CardFamilies.SelectedItem;

                context.SelectedCardFamily = selectedItem as CardFamilyViewModel;
            }
        }

        public void InitializeControl(Container container)
        {
            CardMetadataEditor.InitializeControl(container);
        }
    }
}
