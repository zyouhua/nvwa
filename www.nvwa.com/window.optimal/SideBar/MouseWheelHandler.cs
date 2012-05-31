using System;
using System.Windows.Forms;

namespace window.optimal
{
	public sealed class MouseWheelHandler
	{
		const int WHEEL_DELTA = 120;
		
		int mouseWheelDelta;
		
		public int GetScrollAmount(MouseEventArgs e)
		{
			mouseWheelDelta += e.Delta;
			Console.WriteLine("Mouse rotation: new delta=" + e.Delta + ", total delta=" + mouseWheelDelta);
			
			int linesPerClick = Math.Max(SystemInformation.MouseWheelScrollLines, 1);
			
			int scrollDistance = mouseWheelDelta * linesPerClick / WHEEL_DELTA;
			mouseWheelDelta %= Math.Max(1, WHEEL_DELTA / linesPerClick);
			return scrollDistance;
		}
		
		public void Scroll(ScrollBar scrollBar, MouseEventArgs e)
		{
			int newvalue = scrollBar.Value - GetScrollAmount(e) * scrollBar.SmallChange;
			scrollBar.Value = Math.Max(scrollBar.Minimum, Math.Min(scrollBar.Maximum - scrollBar.LargeChange + 1, newvalue));
		}
	}
}
