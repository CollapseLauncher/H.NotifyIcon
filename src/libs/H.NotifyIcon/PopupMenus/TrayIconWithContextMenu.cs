#if !MACOS
using H.NotifyIcon.Interop;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedMember.Global

namespace H.NotifyIcon.Core;

/// <inheritdoc/>
[SupportedOSPlatform("windows5.1.2600")]
public class TrayIconWithContextMenu : TrayIcon
{
    /// <summary>
    /// 
    /// </summary>
    public PopupMenu? ContextMenu { get; set; }

    private Thread? Thread { get; set; }
    private uint ThreadId { get; set; }

    /// <inheritdoc/>
    public TrayIconWithContextMenu(Guid id) : base(id)
    {
        MessageWindow.MouseEventReceived += OnMouseEvent;
    }

    /// <inheritdoc/>
    public TrayIconWithContextMenu(ILogger? logger) : base()
    {
        Logger = logger;

        MessageWindow.MouseEventReceived += OnMouseEvent;
    }

    /// <inheritdoc/>
    public TrayIconWithContextMenu(string name) : base(name)
    {
        MessageWindow.MouseEventReceived += OnMouseEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    public new void Create()
    {
        if (Thread != null)
        {
            base.Create();
            return;
        }

        // This code is required to support the context menu.
        Thread = new Thread(() =>
        {
            ThreadId = PInvoke.GetCurrentThreadId();

            base.Create();

            WindowUtilities.RunMessageLoop();
        });
        Thread.Start();
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (Thread == null)
        {
            base.Dispose(disposing);
            return;
        }

        _ = PInvoke.PostThreadMessage(
            idThread: ThreadId,
            Msg: PInvoke.WM_QUIT,
            wParam: default,
            lParam: default).EnsureNonZero();

        if (PInvoke.GetCurrentThreadId() != ThreadId)
        {
            Thread.Join();
        }
        Thread = null;

        base.Dispose(disposing);
    }

    private void OnMouseEvent(object? sender, MessageWindow.MouseEventReceivedEventArgs args)
    {
        switch (args.MouseEvent)
        {
            case MouseEvent.MouseMove:
                return;
            case MouseEvent.IconRightMouseUp:
                ShowContextMenu();
                break;
            case MouseEvent.IconLeftMouseDown:
                break;
            case MouseEvent.IconLeftMouseUp:
                break;
            case MouseEvent.IconLeftDoubleClick:
                break;
            case MouseEvent.IconRightMouseDown:
                break;
            case MouseEvent.IconRightDoubleClick:
                break;
            case MouseEvent.IconMiddleMouseDown:
                break;
            case MouseEvent.IconMiddleMouseUp:
                break;
            case MouseEvent.IconMiddleDoubleClick:
                break;
            case MouseEvent.IconDoubleClick:
                break;
            case MouseEvent.BalloonToolTipClicked:
                break;
            default:
                throw new NotSupportedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void ShowContextMenu()
    {
        var cursorPosition = CursorUtilities.GetCursorPos();

        _ = WindowUtilities.SetForegroundWindow(WindowHandle);
        ContextMenu?.Show(
            ownerHandle: WindowHandle,
            x: cursorPosition.X,
            y: cursorPosition.Y);
    }
}
#endif
