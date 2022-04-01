﻿using System.Drawing;
using H.NotifyIcon.Interop;

using var iconStream = H.Resources.Red_ico.AsStream();
using var icon = new Icon(iconStream);
using var trayIcon = new TrayIcon
{
    Icon = icon.Handle,
    ToolTip = "StandardTooltip",
    UseStandardTooltip = true,
};
_ = trayIcon.Create();

using var iconStream2 = H.Resources.icon_ico.AsStream();
using var icon2 = new Icon(iconStream2);
using var trayIcon2 = new TrayIcon
{
    Icon = icon2.Handle,
    ToolTip = "ModernTooltip",
};
_ = trayIcon2.Create();

while (true)
{
    var line = Console.ReadLine();
    var result = false;
    if (line.StartsWith("message"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.None),
            message: line.Substring("message".Length + 1),
            icon: NotificationIcon.None);
    }
    else if (line.StartsWith("info"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Info),
            message: line.Substring("info".Length + 1),
            icon: NotificationIcon.Info);
    }
    else if (line.StartsWith("warning"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Warning),
            message: line.Substring("warning".Length + 1),
            icon: NotificationIcon.Warning);
    }
    else if (line.StartsWith("error"))
    {
        result = trayIcon.ShowNotification(
            title: nameof(NotificationIcon.Error),
            message: line.Substring("error".Length + 1),
            icon: NotificationIcon.Error);
    }
    else if (line.StartsWith("custom"))
    {
        result = trayIcon.ShowNotification(
            title: "Custom",
            message: line.Substring("custom".Length + 1),
            customIcon: icon.Handle);
    }
    else if (line.StartsWith("clear"))
    {
        result = trayIcon.ClearNotifications();
    }
    else if (line.StartsWith("set-focus"))
    {
        result = trayIcon.SetFocus();
    }
    else if (line.StartsWith("remove"))
    {
        result = trayIcon.Remove();
    }
    else if (line.StartsWith("create"))
    {
        result = trayIcon.Create();
    }

    Console.WriteLine($"{line}: {result}");
}