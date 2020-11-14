using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BoardGameDesigner.BusinessLayer.External;
using BoardGameDesigner.DesktopApp.Helpers;
using BoardGameDesigner.Model.Components;
using BoardGameDesigner.Model.Design;
using BoardGameDesigner.ViewModel.DataSources;

namespace BoardGameDesigner.DesktopApp.Windows.CardViewer
{
    /// <summary>
    /// Interaction logic for CardViewerWindow.xaml
    /// </summary>
    public partial class CardViewerWindow : Window, ICardViewerWindow
    {
        private readonly IDataSource<CardDesign> _cardDesignSource;
        private readonly ICardDesignGenerator _cardDesignGenerator;
        private readonly IDataSource<Card> _cardDataSource;

        public CardViewerWindow(IDataSource<CardDesign> cardDesignSource, ICardDesignGenerator cardDesignGenerator, IDataSource<Card> cardDataSource)
        {
            _cardDesignSource = cardDesignSource;
            _cardDesignGenerator = cardDesignGenerator;
            _cardDataSource = cardDataSource;
            InitializeComponent();

            Closing += CardViewerWindow_Closing;
        }

        private void CardViewerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        public Window GetWindow()
        {
            return this;
        }

        public void ShowWindow()
        {
            var card = _cardDataSource.GetAll().FirstOrDefault();
            var cardDesign = _cardDesignSource.GetAll().FirstOrDefault();
            _cardDesignGenerator.ApplyToCanvas(CardCanvas, cardDesign, card);
            this.Show();
        }

        public void CloseWindow()
        {
            Close();
        }

        private void ExportToPng(object sender, RoutedEventArgs e)
        {
            double dpi = 96d;

            Visual target = CardCanvas;
            Rect bounds = VisualTreeHelper.GetDescendantBounds(target);

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)CardCanvas.Width, (int) CardCanvas.Height, dpi, dpi, PixelFormats.Default);

            DrawingVisual dv = new DrawingVisual();

            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(target);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }

            rtb.Render(dv);

            PngBitmapEncoder png = new PngBitmapEncoder();

            png.Frames.Add(BitmapFrame.Create(rtb));

            using (Stream stm = File.Create("local.png"))
            {
                png.Save(stm);
            }
        }
    }
}
