using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UiDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool close = true;
        public bool max = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_close_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_close);
            
        }

        private void Btn_close_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_close);
        }
        private void Btn_minimize_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_minimize);
        }

        private void Btn_minimize_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_minimize);
        }

        private void Btn_maximize_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_maximize);
        }

        private void Btn_maximize_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimationExecute(btn_maximize);
        }

        public void AnimationExecute(Button b)
        {
            DoubleAnimation expand = new DoubleAnimation();
            if (close)
            {
                expand.From = 15;
                expand.To = 35;
                expand.Duration = TimeSpan.FromMilliseconds(100);
            }
            else
            {             
                expand.From = 35;
                expand.To = 15;
                expand.Duration = TimeSpan.FromMilliseconds(100);
            }
            close = !close;

            Storyboard.SetTargetName(expand, b.Name.ToString());
            Storyboard.SetTargetProperty(expand, new PropertyPath(WidthProperty));

            Storyboard sb = new Storyboard();
            sb.Children.Add(expand);
            sb.Begin(this);
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Btn_maximize_Click(object sender, RoutedEventArgs e)
        {
            if (!max)
            {
                this.WindowState = WindowState.Maximized;
                max = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                max = false;
            }
        }
    }
}
