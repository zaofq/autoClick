/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2019-10-21
 * 时间: 9:55
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Runtime.InteropServices;


namespace ZMECG
{
    /// <summary>
    /// Description of mouseClass.
    /// </summary>
    static class mouseClass
	{
			enum MouseEventFlag : uint
			{
				Move = 0x0001,
				LeftDown = 0x0002,
				LeftUp = 0x0004,
				RightDown = 0x0008,
				RightUp = 0x0010,
				MiddleDown = 0x0020,
				MiddleUp = 0x0040,
				XDown = 0x0080,
				XUp = 0x0100,
				Wheel = 0x0800,
				VirtualDesk = 0x4000,
				Absolute = 0x8000
			}
//其中flags标志位集,指定点击按钮和鼠标动作的多种情况.
//dx指鼠标沿x轴绝对位置或上次鼠标事件位置产生以来移动的数量.
//dy指沿y轴的绝对位置或从上次鼠标事件以来移动的数量.
//data如果flags为MOUSE_WHEEL则该值指鼠标轮移动的数量(否则为0),正值向前转动.
//extraInfo指定与鼠标事件相关的附加32位值.
			[DllImport("user32.dll")]
			static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

			[DllImport("user32.dll")]
			public static extern int SetCursorPos(int x, int y);

			public static void MouseLeftDown(int dx, int dy, uint data)
			{
				SetCursorPos(dx, dy);
				//System.Threading.Thread.Sleep(2 * 1000);
				mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
				//mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
			}
			
			public static void MouseLeftUp(int dx, int dy, uint data)
			{
				SetCursorPos(dx, dy);
				//System.Threading.Thread.Sleep(2 * 1000);
				//mouse_event(MouseEventFlag.LeftDown, dx, dy, data, UIntPtr.Zero);
				mouse_event(MouseEventFlag.LeftUp, dx, dy, data, UIntPtr.Zero);
			}
 
			public static void MouseRightDown(int dx, int dy, uint data)
			{
				SetCursorPos(dx, dy);
				//System.Threading.Thread.Sleep(2 * 1000);
				mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
				//mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
			}
			public static void MouseRightUp(int dx, int dy, uint data)
			{
				SetCursorPos(dx, dy);
				//System.Threading.Thread.Sleep(2 * 1000);
				//mouse_event(MouseEventFlag.RightDown, dx, dy, data, UIntPtr.Zero);
				mouse_event(MouseEventFlag.RightUp, dx, dy, data, UIntPtr.Zero);
			}
		

	}
}
