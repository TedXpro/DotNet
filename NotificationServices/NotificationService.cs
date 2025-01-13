public class NotifcationService // publisher class
{
    // declaring a delegate
    public delegate void NotifyDelegate(string message, string messageType);

    // declaring an event using the delegate type
    public event NotifyDelegate OnNotifyEvent;
    
    public void Notify(string message, string notificationType="All")
    {
        // random code here(process done )

        // after finishing the random code, we can raise the event
        OnNotifyEvent?.Invoke(message, notificationType);
        OnNotifyEvent(message, notificationType);
        // OnNotify?.Invoke(message, notificationType);        
    }
}
