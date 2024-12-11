public class Program{
    public static void Main(string[] args){
        EmailSerivce emailService = new EmailSerivce();
        SMSService smsService = new SMSService();
        NotifcationService notifcationService= new NotifcationService();
        notifcationService.OnNotify += emailService.SendEmail;
        notifcationService.OnNotify += smsService.SendSMS;

        notifcationService.Notify("HEllo WorlD!", "All");
    }
}