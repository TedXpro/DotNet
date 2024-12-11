public class NotifcationService
{
    // declaring a delegate
    public delegate void NotificationServiceEvent(string message, string notificationType);

    // declaring an event using the delegate type
    public event NotificationServiceEvent OnNotify; // OnNotify is an event NAME
    
    public void Notify(string message, string notificationType="All")
    {
        
        OnNotify?.Invoke(message, notificationType);        
    }
}
