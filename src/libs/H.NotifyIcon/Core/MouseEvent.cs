﻿namespace H.NotifyIcon.Core;

/// <summary>
/// Possible mouse events.
/// </summary>
public enum MouseEvent
{
    /// <summary>
    /// The mouse was moved withing the
    /// taskbar icon's area.
    /// </summary>
    MouseMove,

    /// <summary>
    /// The left mouse button was clicked.
    /// </summary>
    IconLeftMouseDown,

    /// <summary>
    /// The left mouse button was released.
    /// </summary>
    IconLeftMouseUp,

    /// <summary>
    /// The left mouse button was double clicked.
    /// </summary>
    IconLeftDoubleClick,

    /// <summary>
    /// The right mouse button was clicked.
    /// </summary>
    IconRightMouseDown,

    /// <summary>
    /// The right mouse button was released.
    /// </summary>
    IconRightMouseUp,

    /// <summary>
    /// The right mouse button was double clicked.
    /// </summary>
    IconRightDoubleClick,

    /// <summary>
    /// The middle mouse button was clicked.
    /// </summary>
    IconMiddleMouseDown,

    /// <summary>
    /// The middle mouse button was released.
    /// </summary>
    IconMiddleMouseUp,

    /// <summary>
    /// The middle mouse button was double clicked.
    /// </summary>
    IconMiddleDoubleClick,

    /// <summary>
    /// The taskbar icon was double clicked.
    /// </summary>
    IconDoubleClick,

    /// <summary>
    /// The balloon tip was clicked.
    /// </summary>
    BalloonToolTipClicked,
}
