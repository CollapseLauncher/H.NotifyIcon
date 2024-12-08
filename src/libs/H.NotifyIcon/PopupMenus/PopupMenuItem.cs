namespace H.NotifyIcon.Core;

/// <inheritdoc/>
public class PopupMenuItem : PopupItem
{
    /// <inheritdoc/>
    public PopupMenuItem() { }

    /// <inheritdoc/>
    public PopupMenuItem(PopupMenu? subMenu)
    {
        SubMenu = subMenu;
    }

    /// <inheritdoc/>
    public PopupMenuItem(string text, EventHandler<EventArgs> onClick, PopupMenu? subMenu)
    {
        Text = text;
        SubMenu = subMenu;
        Click += onClick;
    }

    /// <summary>
    /// 
    /// </summary>
    public event EventHandler<EventArgs>? Click;

    /// <summary>
    /// 
    /// </summary>
    public bool Checked { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool Enabled { get; set; } = true;

    //public Image? Image { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public PopupMenu? SubMenu { get; }

    /// <summary>
    /// 
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public SystemPopupMenuItemBreak Break { get; set; } = SystemPopupMenuItemBreak.None;

    internal MENU_ITEM_FLAGS NativeFlags
    {
        get
        {
            var flags = (MENU_ITEM_FLAGS)0;

            if (!Enabled)
            {
                flags |= MENU_ITEM_FLAGS.MF_DISABLED;
                flags |= MENU_ITEM_FLAGS.MF_GRAYED;
            }

            if (Checked)
            {
                flags |= MENU_ITEM_FLAGS.MF_CHECKED;
            }

            switch (Break)
            {
                case SystemPopupMenuItemBreak.MenuBreak:
                    flags |= MENU_ITEM_FLAGS.MF_MENUBREAK;
                    break;

                case SystemPopupMenuItemBreak.MenuBarBreak:
                    flags |= MENU_ITEM_FLAGS.MF_MENUBARBREAK;
                    break;
                case SystemPopupMenuItemBreak.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //if (Image != null)
            //{
            //    flags |= MENU_ITEM_FLAGS.MF_BITMAP;
            //}

            return flags;
        }
    }

    /// <summary>
    /// Raises the <see cref="Click"/> event.
    /// </summary>
    internal void OnClick()
    {
        Click?.Invoke(this, EventArgs.Empty);
    }
}
