//Scintilla.cs:

protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_DESTROY)
            {
                if (this.IsHandleCreated)
                {
                    NativeMethods.SetParent(this.Handle, NativeMethods.HWND_MESSAGE);
                    return;
                }
            }
            else
            {
                switch (m.Msg)
                {
                    case (NativeMethods.WM_REFLECT + NativeMethods.WM_NOTIFY):
                        WmReflectNotify(ref m);
                        break;

                    case NativeMethods.WM_SETCURSOR:
                        DefWndProc(ref m);
                        break;

                    case NativeMethods.WM_LBUTTONDBLCLK:
                    case NativeMethods.WM_RBUTTONDBLCLK:
                    case NativeMethods.WM_MBUTTONDBLCLK:
                    case NativeMethods.WM_XBUTTONDBLCLK:
                        doubleClick = true;
                        goto default;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            }           
        }
		
		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (fillUpChars != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(fillUpChars);
                    fillUpChars = IntPtr.Zero;
                }
            }
            if (disposing && IsHandleCreated)
	        {
	        //  wi11811 2008-07-28 Chris Rickard
	        //  Since we eat the destroy message in WndProc
	        //  we have to manually let Scintilla know to
	        //  clean up its resources.
	        Message destroyMessage = new Message();
	        destroyMessage.Msg = NativeMethods.WM_DESTROY;
	        destroyMessage.HWnd = Handle;
	        base.DefWndProc(ref destroyMessage);
	        }
            base.Dispose(disposing);
        }
		
	

		
//NativeMethods.cs:
		
		//-------dockpanel fix-----------
        internal const int WM_DESTROY = 0x02;
	    internal const int ERROR_MOD_NOT_FOUND = 126;
        internal const int WM_PAINT = 0x000F;
	    internal static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

	    [DllImport("user32.dll")]
	    internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        //------------------
		
		
		
		
		