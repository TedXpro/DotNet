public class SMSService{
    public void SendSMS(string message, string notificationType)
    {
        if( notificationType == "SMS" || notificationType == "All")
        {
            Console.WriteLine("Sending SMS....");
            Thread.Sleep(1000);
            Console.WriteLine("SMS Sent");
        }
    }
}