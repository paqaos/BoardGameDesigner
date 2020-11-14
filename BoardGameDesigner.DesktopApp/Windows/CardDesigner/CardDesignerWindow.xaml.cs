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
using System.Windows.Shapes;

namespace BoardGameDesigner.DesktopApp.Windows.CardDesigner
{
    /// <summary>
    /// Interaction logic for CardDesignerWindow.xaml
    /// </summary>
    public partial class CardDesignerWindow : Window, ICardDesignerWindow
    {
        public CardDesignerWindow()
        {
            InitializeComponent();

            Closing += CardDesignerWindow_Closing;
        }

        private void CardDesignerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void ShowWindow()
        {
            this.Show();
        }

        public void CloseWindow()
        {

        }
    }
}
