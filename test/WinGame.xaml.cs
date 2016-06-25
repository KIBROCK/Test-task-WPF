using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;

namespace test
{
	public partial class WinGame : Window
	{
		public List<Pen> newPens = new List<Pen>();
		public List<Pen> oldPens = new List<Pen>();
		public int countPens = 0;
		public int countNeedPens = 0;
		public bool numActive = false;
		
		public WinGame()
		{
			InitializeComponent();
		}
		
		void Esc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
		
		void Anim1 (Pen pen)
		{
			PathGeometry pathGeom =new PathGeometry();
			 
			PolyLineSegment vertArr =new PolyLineSegment();
			vertArr.Points = new PointCollection();
			vertArr.Points.Add(new Point(220, 650));
			PathFigure vertArrF =new PathFigure();
			vertArrF.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
			vertArrF.Segments.Add(vertArr);
			pathGeom.Figures.Add(vertArrF);
			
			DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
			dapY.Duration = TimeSpan.FromSeconds(1);
			dapY.PathGeometry = pathGeom;
			dapY.Source = PathAnimationSource.Y;
			pen.image.BeginAnimation(Canvas.TopProperty, dapY);
			
			DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
			dapX.Duration = TimeSpan.FromSeconds(1);
			dapX.PathGeometry = pathGeom;
			dapX.Source = PathAnimationSource.X;
			pen.image.BeginAnimation(Canvas.LeftProperty, dapX);
			Anim2(pen);
		}
		
		void Anim2 (Pen pen)
		{
			DoubleAnimation da = new DoubleAnimation();
			da.To = 0;
			da.Duration = TimeSpan.FromSeconds(0.5);
			da.BeginTime = TimeSpan.FromSeconds(0.5);
			da.Completed += delegate {Anim3(pen);};
			pen.image.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, da);
		}

		void Anim3 (Pen pen)
		{
			PathGeometry pathGeom =new PathGeometry();
			 
			PolyLineSegment vertArr =new PolyLineSegment();
			vertArr.Points = new PointCollection();
			vertArr.Points.Add(new Point(220, 300));
			PathFigure vertArrF =new PathFigure();
			vertArrF.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
			vertArrF.Segments.Add(vertArr);
			pathGeom.Figures.Add(vertArrF);
			
			DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
			dapY.Duration = TimeSpan.FromSeconds(1);
			dapY.PathGeometry = pathGeom;
			dapY.Source = PathAnimationSource.Y;
			pen.image.BeginAnimation(Canvas.TopProperty, dapY);
			
			DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
			dapX.Duration = TimeSpan.FromSeconds(1);
			dapX.PathGeometry = pathGeom;
			dapX.Source = PathAnimationSource.X;
			dapX.Completed += delegate {Anim4(pen);};
			pen.image.BeginAnimation(Canvas.LeftProperty, dapX);
		}
		
		void Anim4 (Pen pen)
		{
			toch.Source = new BitmapImage(new Uri(@"Images\toch2.png", UriKind.Relative));
			DoubleAnimation da = new DoubleAnimation();
			da.AutoReverse = true;
			da.RepeatBehavior = new RepeatBehavior(5);
			da.From = Canvas.GetLeft(toch);
			da.To = Canvas.GetLeft(toch) + 5;
			da.Duration = TimeSpan.FromMilliseconds(100);
			da.Completed += delegate {toch.Source = new BitmapImage(new Uri(@"Images\toch.png", UriKind.Relative)); Anim5(pen);};
			toch.BeginAnimation(Canvas.LeftProperty, da);
		}
		
		void Anim5 (Pen pen)
		{
			PathGeometry pathGeom =new PathGeometry();
			 
			PolyLineSegment vertArr =new PolyLineSegment();
			vertArr.Points = new PointCollection();
			vertArr.Points.Add(new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image) + 100));
			PathFigure vertArrF =new PathFigure();
			vertArrF.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
			vertArrF.Segments.Add(vertArr);
			pathGeom.Figures.Add(vertArrF);
			
			DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
			dapY.Duration = TimeSpan.FromSeconds(1);
			dapY.PathGeometry = pathGeom;
			dapY.Source = PathAnimationSource.Y;
			pen.image.BeginAnimation(Canvas.TopProperty, dapY);
			
			DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
			dapX.Duration = TimeSpan.FromSeconds(1);
			dapX.PathGeometry = pathGeom;
			dapX.Source = PathAnimationSource.X;
			dapX.Completed += delegate {Anim6(pen);};
			pen.image.BeginAnimation(Canvas.LeftProperty, dapX);
		}
		
		void Anim6 (Pen pen)
		{
			PathGeometry pathGeom =new PathGeometry();
			 
			PolyLineSegment vertArr =new PolyLineSegment();
			vertArr.Points = new PointCollection();
			vertArr.Points.Add(new Point(Canvas.GetLeft(pen.image) + 170 + ((newPens.Count+1) * 10) ,Canvas.GetTop(pen.image) - 170));
			PathFigure vertArrF =new PathFigure();
			vertArrF.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
			vertArrF.Segments.Add(vertArr);
			pathGeom.Figures.Add(vertArrF);
			
			DoubleAnimationUsingPath dapY = new DoubleAnimationUsingPath();
			dapY.Duration = TimeSpan.FromSeconds(1);
			dapY.BeginTime = TimeSpan.FromMilliseconds(200);
			dapY.PathGeometry = pathGeom;
			dapY.Source = PathAnimationSource.Y;
			pen.image.BeginAnimation(Canvas.TopProperty, dapY);
			
			DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
			dapX.Duration = TimeSpan.FromSeconds(1);
			dapX.BeginTime = TimeSpan.FromMilliseconds(200);
			dapX.PathGeometry = pathGeom;
			dapX.Source = PathAnimationSource.X;
			dapX.Completed += delegate {Anim7(pen);};
			pen.image.BeginAnimation(Canvas.LeftProperty, dapX);
			
			DoubleAnimation da = new DoubleAnimation();
			da.To = 45;
			da.Duration = TimeSpan.FromMilliseconds(200);
			da.BeginTime = TimeSpan.FromMilliseconds(200);
			pen.image.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, da);
			
		}
		
		void Anim7 (Pen pen)
		{
			DoubleAnimation da = new DoubleAnimation();
			da.To = 0;
			da.Duration = TimeSpan.FromMilliseconds(100);
			da.BeginTime = TimeSpan.FromMilliseconds(100);
			da.Completed += delegate {StartAnim();};
			pen.image.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, da);
		}
		
		void StartAnim()
		{
			if (newPens.Count < countPens)
			{
				Pen pen = new Pen("pen" + newPens.Count.ToString(), this, 358, 526, -135, 5);
				newPens.Add(pen);
				Anim1(pen);
			}
			else
			{
				Image img = new Image();
				img.Source = new BitmapImage(new Uri(@"Images\next.png", UriKind.Relative));
				img.Width = 100;
				img.Height = 100;
				img.Name = "next";
				img.MouseLeftButtonDown += delegate {canva.Children.Remove(img); FinishAnim(); newGame();};
				canva.Children.Add(img);
				Canvas.SetLeft(img, 700);
				Canvas.SetTop(img, 350);
			}
		}
		
		void FinishAnim ()
		{
			foreach (Pen pen in oldPens) {
				PathGeometry pathGeom =new PathGeometry();
				 
				PolyLineSegment vertArr =new PolyLineSegment();
				vertArr.Points = new PointCollection();
				vertArr.Points.Add(new Point(1000, Canvas.GetTop(pen.image)));
				PathFigure vertArrF =new PathFigure();
				vertArrF.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
				vertArrF.Segments.Add(vertArr);
				pathGeom.Figures.Add(vertArrF);

				DoubleAnimationUsingPath dapX = new DoubleAnimationUsingPath();
				dapX.Duration = TimeSpan.FromMilliseconds(500);
				dapX.PathGeometry = pathGeom;
				dapX.Source = PathAnimationSource.X;
				dapX.Completed += delegate {canva.Children.Remove(pen.image);};
				pen.image.BeginAnimation(Canvas.LeftProperty, dapX);
			}
			
			for (int i = 0; i < newPens.Count; i++) {
				Pen pen = newPens[i];
				PathGeometry pathGeom2 =new PathGeometry();
				 
				PolyLineSegment vertArr2 =new PolyLineSegment();
				vertArr2.Points = new PointCollection();
				vertArr2.Points.Add(new Point(550 + i * 10, 400));
				PathFigure vertArrF2 =new PathFigure();
				vertArrF2.StartPoint = new Point(Canvas.GetLeft(pen.image), Canvas.GetTop(pen.image));
				vertArrF2.Segments.Add(vertArr2);
				pathGeom2.Figures.Add(vertArrF2);
				
				DoubleAnimationUsingPath dapY2 = new DoubleAnimationUsingPath();
				dapY2.Duration = TimeSpan.FromSeconds(1);
				dapY2.PathGeometry = pathGeom2;
				dapY2.Source = PathAnimationSource.Y;
				pen.image.BeginAnimation(Canvas.TopProperty, dapY2);
				
				DoubleAnimationUsingPath dapX2 = new DoubleAnimationUsingPath();
				dapX2.Duration = TimeSpan.FromSeconds(1);
				dapX2.PathGeometry = pathGeom2;
				dapX2.Source = PathAnimationSource.X;
				pen.image.BeginAnimation(Canvas.LeftProperty, dapX2);
			}
		}
		
		void newGame()
		{
			oldPens.Clear();
			oldPens.AddRange(newPens);
			int rand = new Random().Next(5) + 1;
			if (rand % 2 == 0)
		    {
				if (rand >= oldPens.Count)
				{
					rand++;
				}
		    }
		    else
		    {
		    	if (oldPens.Count > 5)
		    	{
		    		if (rand < 3)
		    		{
		    			rand++;
		    		}
		    		else
		    		{
		    			rand--;
		    		}
		    	}
		    }
			string text = "";
			switch (rand) {
				case 1 : 
					text = "карандаш";
					break;
				case 5 : 
					text = "карандашей";
					break;
				default:
					text = "карандаша";
					break;
			}
			if (rand % 2 == 0)
			{
				textBlock.Text = "Подточи на " + rand.ToString() + " " + text + " меньше";
			}
			else
			{
				textBlock.Text = "Подточи на " + rand.ToString() + " " + text + " больше";
			}
			countNeedPens = rand;
			numActive = true;
		}
		
		void GameWin_Loaded(object sender, RoutedEventArgs e)
		{
			int rand = new Random().Next(5) + 1;
			for (int i = 1; i <= rand; i++) {
				Pen pen = new Pen("pen" + i.ToString(), this, (550 + i * 10), 400, 0, i);
				newPens.Add(pen);
			}
			newGame();
		}

		void Num_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (numActive)
			{
				bool next = false;
				int num = Convert.ToInt32(((Image)e.Source).Name.Substring(3));
				if (countNeedPens % 2 == 0)
				{
					if (oldPens.Count - countNeedPens == num) next = true;
				}
				else
				{
					if (oldPens.Count + countNeedPens == num) next = true;
				}
				if (next)
				{
					numActive = false;
					newPens.Clear();
					countPens = num;
					StartAnim();
				}
				else
				{
					TextBlock tb = new TextBlock();
					tb.Text = "Неправильно";
					tb.Foreground = Brushes.Red;
					tb.FontSize = 140;
					tb.Width = this.ActualWidth;
					tb.Height = this.ActualHeight;
					tb.HorizontalAlignment = HorizontalAlignment.Center;
					tb.VerticalAlignment = VerticalAlignment.Center;
					tb.Loaded += delegate { 
						DoubleAnimation day = new DoubleAnimation();
						day.From = tb.ActualHeight;
						day.To = 0;
						day.Duration = TimeSpan.FromMilliseconds(1000);
						day.Completed += delegate {canva.Children.Remove(tb);};
						tb.BeginAnimation(TextBlock.HeightProperty, day);
					};
					Canvas.SetTop(tb, 300);
					Canvas.SetLeft(tb, 50);
					canva.Children.Add(tb);
				}
			}
		}
		
		void Num_MouseEnter(object sender, MouseEventArgs e)
		{
			((Image)e.Source).Source = new BitmapImage(new Uri(@"Images\pum" + ((Image)e.Source).Name.Substring(3) + ".png", UriKind.Relative));
		}
		
		void Num_MouseLeave(object sender, MouseEventArgs e)
		{
			((Image)e.Source).Source = new BitmapImage(new Uri(@"Images\num" + ((Image)e.Source).Name.Substring(3) + ".png", UriKind.Relative));
		}

		void Canva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			this.DragMove();
		}

	}

	public class Pen
	{
		public Image image;
		
		/// <summary>
		/// Карандаш
		/// </summary>
		/// <param name="name">Имя</param>
		/// <param name="parent">Расположение</param>
		/// <param name="left">Отступ слева</param>
		/// <param name="top">Отступ сверху</param>
		/// <param name="rot">Поворот</param>
		/// <param name="rnd">Вариативность цвета</param>
		public Pen(string name, WinGame parent, int left, int top, int rot, int rnd)
		{
			int rand = new Random().Next(rnd);
			Image img = new Image();
			img.Source = new BitmapImage(new Uri(@"Images\pen" + (rand + 1).ToString() + ".png", UriKind.Relative));
			img.Width = 10;
			img.Height = 100;
			img.Name = name;
			parent.canva.Children.Add(img);
			Canvas.SetLeft(img, left);
			Canvas.SetTop(img, top);
			img.RenderTransform = new RotateTransform(rot, img.Width/2, img.Height/2);
			image = img;
		}
	}
}