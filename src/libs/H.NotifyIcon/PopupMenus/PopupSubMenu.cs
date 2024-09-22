namespace H.NotifyIcon.Core;

/// <inheritdoc/>
public class PopupSubMenu : PopupItem
{
    /// <inheritdoc/>
    public PopupSubMenu()
    { }

    /// <inheritdoc/>
    public PopupSubMenu(string text)
    {
        Text = text;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public ICollection<PopupItem> Items { get; } = [];

}
