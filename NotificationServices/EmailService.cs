public class EmailSerivce{
    public void SendEmail(string message, string notificationType)
    {
        if(notificationType == "Email" || notificationType == "All")
        {
            Console.WriteLine("Sending Email....");
            Thread.Sleep(1000);
            Console.WriteLine("Email Sent");
        }
    }
}