using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace test
{
	public partial class WinStart : Window
	{
		public WinStart()
		{
			InitializeComponent();
		}
		
		void esc_MouseUp(object sender, MouseButtonEventArgs e)
		{
			DoubleAnimation da = new DoubleAnimation();
			da.From = this.Height;
			da.To = 0;
			da.Duration = TimeSpan.FromMilliseconds(200);
			da.Completed += delegate {Close();};
			this.BeginAnimation(HeightProperty , da);
		}
		
		void esc_MouseEnter(object sender, MouseEventArgs e)
		{
			ImageSourceConverter conv = new ImageSourceConverter();
			esc.Source = new BitmapImage(new Uri(@"Images\esc2.png", UriKind.Relative));
		}
		
		void esc_MouseLeave(object sender, MouseEventArgs e)
		{
			ImageSourceConverter conv = new ImageSourceConverter();
			esc.Source = new BitmapImage(new Uri(@"Images\esc.png", UriKind.Relative));
		}
		
		void start_MouseUp(object sender, MouseButtonEventArgs e)
		{
			WinGame wg = new WinGame();
			wg.Show();
			this.Close();
		}
		
		void start_MouseEnter(object sender, MouseEventArgs e)
		{
			start.Source = new BitmapImage(new Uri(@"Images\start2.png", UriKind.Relative));
		}
		
		void start_MouseLeave(object sender, MouseEventArgs e)
		{
			start.Source = new BitmapImage(new Uri(@"Images\start.png", UriKind.Relative));
		}
	}
}