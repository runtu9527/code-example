using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;

            Init();
        }

        private void Init()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "Image", "background.png");
            if (File.Exists(path))
            {
                var bitmap = new BitmapImage(new Uri(path));
                MinBackground = bitmap;
            }
           
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= MainWindow_Loaded;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // This can't be done any earlier than the SourceInitialized event:
            GlassHelper.ExtendGlassFrame(this, new Thickness(-1));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }


        #region 依赖属性


        public ImageSource MinBackground
        {
            get { return (ImageSource)GetValue(MinBackgroundProperty); }
            set { SetValue(MinBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinBackgroundProperty =
            DependencyProperty.Register("MinBackground", typeof(ImageSource), typeof(MainWindow), new PropertyMetadata(null));

        
        #endregion

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
