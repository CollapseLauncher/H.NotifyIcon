#nullable enable

namespace H.NotifyIcon
{
    internal sealed class EventSubscription : IDisposable
    {
        private readonly Action action;

        public EventSubscription(Action action)
        {
            this.action = action;
        }

        public void Dispose()
        {
            action();
        }
    }

    public partial class GeneratedIconSource
    {
        /// <summary>
        /// Occured when any dependency property was changed
        /// </summary>
        public event EventHandler? DependencyPropertyChanged;

        /// <summary>
        /// A helper method to subscribe the DependencyPropertyChanged event.
        /// </summary>
        public IDisposable SubscribeToDependencyPropertyChanged(EventHandler handler)
        {
            DependencyPropertyChanged += handler;

            return new EventSubscription(() => DependencyPropertyChanged -= handler);
        }

        /// <summary>
        /// A helper method to raise the DependencyPropertyChanged event.
        /// </summary>
        private EventArgs OnDependencyPropertyChanged()
        {
            var args = new EventArgs();
            DependencyPropertyChanged?.Invoke(this, args);

            return args;
        }
    }
}
