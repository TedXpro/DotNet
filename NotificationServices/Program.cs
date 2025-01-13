public class Program{
    public static void Main(string[] args){
        EmailSerivce emailService = new EmailSerivce();
        SMSService smsService = new SMSService();


        // creating a publisher object;
        NotifcationService notifcationService = new NotifcationService();
        // Subscribe to the event(publisher)
        
        notifcationService.OnNotifyEvent += smsService.SendSMS;
        notifcationService.OnNotifyEvent += emailService.SendEmail;

        // calling the notify method to Raise the event
        notifcationService.Notify("HEllo WorlD!", "All");
    }
}