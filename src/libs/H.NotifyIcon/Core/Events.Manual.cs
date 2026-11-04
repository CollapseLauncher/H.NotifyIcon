#pragma warning disable CA1034 // Preserve the public API formerly emitted by EventGenerator.
#pragma warning disable IDE0290

using System.Drawing;

namespace H.NotifyIcon.Core
{
    internal sealed class EventSubscription : IDisposable
    {
        private readonly Action _action;

        public EventSubscription(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class BalloonToolTipChangedEventArgs : EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public bool IsVisible { get; }

            /// <summary>
            ///
            /// </summary>
            public BalloonToolTipChangedEventArgs(bool isVisible)
            {
                IsVisible = isVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out bool isVisible)
            {
                isVisible = IsVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(IsVisible={IsVisible})";
            }
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class ChangeToolTipStateRequestEventArgs : EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public bool IsVisible { get; }

            /// <summary>
            ///
            /// </summary>
            public ChangeToolTipStateRequestEventArgs(bool isVisible)
            {
                IsVisible = isVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out bool isVisible)
            {
                isVisible = IsVisible;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(IsVisible={IsVisible})";
            }
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class KeyboardEventReceivedEventArgs : EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public KeyboardEvent KeyboardEvent { get; }

            /// <summary>
            ///
            /// </summary>
            public Point Point { get; }

            /// <summary>
            ///
            /// </summary>
            public KeyboardEventReceivedEventArgs(KeyboardEvent keyboardEvent, Point point)
            {
                KeyboardEvent = keyboardEvent;
                Point = point;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out KeyboardEvent keyboardEvent, out Point point)
            {
                keyboardEvent = KeyboardEvent;
                point = Point;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(KeyboardEvent={KeyboardEvent}, Point={Point})";
            }
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        ///
        /// </summary>
        public class MouseEventReceivedEventArgs : EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public MouseEvent MouseEvent { get; }

            /// <summary>
            ///
            /// </summary>
            public Point Point { get; }

            /// <summary>
            ///
            /// </summary>
            public MouseEventReceivedEventArgs(MouseEvent mouseEvent, Point point)
            {
                MouseEvent = mouseEvent;
                Point = point;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out MouseEvent mouseEvent, out Point point)
            {
                mouseEvent = MouseEvent;
                point = Point;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(MouseEvent={MouseEvent}, Point={Point})";
            }
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if a balloon ToolTip was either displayed or closed (indicated by the boolean flag).
        /// </summary>
        public event EventHandler<BalloonToolTipChangedEventArgs>? BalloonToolTipChanged;

        /// <summary>
        /// A helper method to subscribe the BalloonToolTipChanged event.
        /// </summary>
        public IDisposable SubscribeToBalloonToolTipChanged(EventHandler<BalloonToolTipChangedEventArgs> handler)
        {
            BalloonToolTipChanged += handler;

            return new EventSubscription(() => BalloonToolTipChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the BalloonToolTipChanged event.
        /// </summary>
        protected virtual BalloonToolTipChangedEventArgs OnBalloonToolTipChanged(BalloonToolTipChangedEventArgs args)
        {
            BalloonToolTipChanged?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the BalloonToolTipChanged event.
        /// </summary>
        protected virtual BalloonToolTipChangedEventArgs OnBalloonToolTipChanged(
            bool isVisible)
        {
            var args = new BalloonToolTipChangedEventArgs(isVisible);
            BalloonToolTipChanged?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// The custom tooltip should be closed or hidden.
        /// </summary>
        public event EventHandler<ChangeToolTipStateRequestEventArgs>? ChangeToolTipStateRequest;

        /// <summary>
        /// A helper method to subscribe the ChangeToolTipStateRequest event.
        /// </summary>
        public IDisposable SubscribeToChangeToolTipStateRequest(EventHandler<ChangeToolTipStateRequestEventArgs> handler)
        {
            ChangeToolTipStateRequest += handler;

            return new EventSubscription(() => ChangeToolTipStateRequest -= handler);
        }

        /// <summary>
        /// A helper method to raise the ChangeToolTipStateRequest event.
        /// </summary>
        protected virtual ChangeToolTipStateRequestEventArgs OnChangeToolTipStateRequest(ChangeToolTipStateRequestEventArgs args)
        {
            ChangeToolTipStateRequest?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the ChangeToolTipStateRequest event.
        /// </summary>
        protected virtual ChangeToolTipStateRequestEventArgs OnChangeToolTipStateRequest(
            bool isVisible)
        {
            var args = new ChangeToolTipStateRequestEventArgs(isVisible);
            ChangeToolTipStateRequest?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if dpi change window message received.
        /// </summary>
        public event EventHandler? DpiChanged;

        /// <summary>
        /// A helper method to subscribe the DpiChanged event.
        /// </summary>
        public IDisposable SubscribeToDpiChanged(EventHandler handler)
        {
            DpiChanged += handler;

            return new EventSubscription(() => DpiChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the DpiChanged event.
        /// </summary>
        protected virtual EventArgs OnDpiChanged()
        {
            var args = new EventArgs();
            DpiChanged?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Sent when a drop-down menu or submenu is about to become active. This allows an application to modify the menu before it is displayed, without changing the entire menu.
        /// </summary>
        public event EventHandler? InitMenuPopup;

        /// <summary>
        /// A helper method to subscribe the InitMenuPopup event.
        /// </summary>
        public IDisposable SubscribeToInitMenuPopup(EventHandler handler)
        {
            InitMenuPopup += handler;

            return new EventSubscription(() => InitMenuPopup -= handler);
        }

        /// <summary>
        /// A helper method to raise the InitMenuPopup event.
        /// </summary>
        protected virtual EventArgs OnInitMenuPopup()
        {
            var args = new EventArgs();
            InitMenuPopup?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired in case the user interacted with the taskbar icon area with keyboard shortcuts.
        /// </summary>
        public event EventHandler<KeyboardEventReceivedEventArgs>? KeyboardEventReceived;

        /// <summary>
        /// A helper method to subscribe the KeyboardEventReceived event.
        /// </summary>
        public IDisposable SubscribeToKeyboardEventReceived(EventHandler<KeyboardEventReceivedEventArgs> handler)
        {
            KeyboardEventReceived += handler;

            return new EventSubscription(() => KeyboardEventReceived -= handler);
        }

        /// <summary>
        /// A helper method to raise the KeyboardEventReceived event.
        /// </summary>
        protected virtual KeyboardEventReceivedEventArgs OnKeyboardEventReceived(KeyboardEventReceivedEventArgs args)
        {
            KeyboardEventReceived?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the KeyboardEventReceived event.
        /// </summary>
        protected virtual KeyboardEventReceivedEventArgs OnKeyboardEventReceived(
            KeyboardEvent keyboardEvent,
            Point point)
        {
            var args = new KeyboardEventReceivedEventArgs(keyboardEvent, point);
            KeyboardEventReceived?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired in case the user clicked or moved within the taskbar icon area.
        /// </summary>
        public event EventHandler<MouseEventReceivedEventArgs>? MouseEventReceived;

        /// <summary>
        /// A helper method to subscribe the MouseEventReceived event.
        /// </summary>
        public IDisposable SubscribeToMouseEventReceived(EventHandler<MouseEventReceivedEventArgs> handler)
        {
            MouseEventReceived += handler;

            return new EventSubscription(() => MouseEventReceived -= handler);
        }

        /// <summary>
        /// A helper method to raise the MouseEventReceived event.
        /// </summary>
        protected virtual MouseEventReceivedEventArgs OnMouseEventReceived(MouseEventReceivedEventArgs args)
        {
            MouseEventReceived?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the MouseEventReceived event.
        /// </summary>
        protected virtual MouseEventReceivedEventArgs OnMouseEventReceived(
            MouseEvent mouseEvent,
            Point point)
        {
            var args = new MouseEventReceivedEventArgs(mouseEvent, point);
            MouseEventReceived?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class MessageWindow
    {
        /// <summary>
        /// Fired if the taskbar was created or restarted. Requires the taskbar icon to be reset
        /// </summary>
        public event EventHandler? TaskbarCreated;

        /// <summary>
        /// A helper method to subscribe the TaskbarCreated event.
        /// </summary>
        public IDisposable SubscribeToTaskbarCreated(EventHandler handler)
        {
            TaskbarCreated += handler;

            return new EventSubscription(() => TaskbarCreated -= handler);
        }

        /// <summary>
        /// A helper method to raise the TaskbarCreated event.
        /// </summary>
        protected virtual EventArgs OnTaskbarCreated()
        {
            var args = EventArgs.Empty;
            TaskbarCreated?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        ///
        /// </summary>
        public class VersionChangedEventArgs : EventArgs
        {
            /// <summary>
            ///
            /// </summary>
            public IconVersion Version { get; }

            /// <summary>
            ///
            /// </summary>
            public VersionChangedEventArgs(IconVersion version)
            {
                Version = version;
            }

            /// <summary>
            ///
            /// </summary>
            public void Deconstruct(out IconVersion version)
            {
                version = Version;
            }

            /// <summary>
            ///
            /// </summary>
            public override string ToString()
            {
                return $"(Version={Version})";
            }
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// TrayIcon was created.
        /// This can happen in the following cases:
        ///  - Via direct Create call
        ///  - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event EventHandler? Created;

        /// <summary>
        /// A helper method to subscribe the Created event.
        /// </summary>
        public IDisposable SubscribeToCreated(EventHandler handler)
        {
            Created += handler;

            return new EventSubscription(() => Created -= handler);
        }

        /// <summary>
        /// A helper method to raise the Created event.
        /// </summary>
        protected virtual EventArgs OnCreated()
        {
            var args = new EventArgs();
            Created?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// TrayIcon was removed.
        /// This can happen in the following cases:
        /// - Via direct TryRemove call
        /// - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event EventHandler? Removed;

        /// <summary>
        /// A helper method to subscribe the Removed event.
        /// </summary>
        public IDisposable SubscribeToRemoved(EventHandler handler)
        {
            Removed += handler;

            return new EventSubscription(() => Removed -= handler);
        }

        /// <summary>
        /// A helper method to raise the Removed event.
        /// </summary>
        protected virtual EventArgs OnRemoved()
        {
            var args = new EventArgs();
            Removed?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class TrayIcon
    {
        /// <summary>
        /// Version was changed.
        /// This can happen in the following cases:
        /// - Via direct Create call
        /// - Through the ClearNotifications call since its implementation uses TrayIcon re-creation
        /// </summary>
        public event EventHandler<VersionChangedEventArgs>? VersionChanged;

        /// <summary>
        /// A helper method to subscribe the VersionChanged event.
        /// </summary>
        public IDisposable SubscribeToVersionChanged(EventHandler<VersionChangedEventArgs> handler)
        {
            VersionChanged += handler;

            return new EventSubscription(() => VersionChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the VersionChanged event.
        /// </summary>
        protected virtual VersionChangedEventArgs OnVersionChanged(VersionChangedEventArgs args)
        {
            VersionChanged?.Invoke(this, args);

            return args;
        }

        /// <summary>
        /// A helper method to raise the VersionChanged event.
        /// </summary>
        protected virtual VersionChangedEventArgs OnVersionChanged(
            IconVersion version)
        {
            var args = new VersionChangedEventArgs(version);
            VersionChanged?.Invoke(this, args);

            return args;
        }
    }
}

namespace H.NotifyIcon.Core
{
    public partial class TrayIconWithContextMenu
    {
        /// <summary>
        /// Occurs before the context menu is displayed.
        /// </summary>
        public event EventHandler? ContextMenuOpening;

        /// <summary>
        /// A helper method to subscribe the ContextMenuOpening event.
        /// </summary>
        public IDisposable SubscribeToContextMenuOpening(EventHandler handler)
        {
            ContextMenuOpening += handler;

            return new EventSubscription(() => ContextMenuOpening -= handler);
        }

        /// <summary>
        /// A helper method to raise the ContextMenuOpening event.
        /// </summary>
        protected virtual EventArgs OnContextMenuOpening()
        {
            var args = new EventArgs();
            ContextMenuOpening?.Invoke(this, args);

            return args;
        }
    }
}
