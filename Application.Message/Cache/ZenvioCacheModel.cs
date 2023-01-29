namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Cache
{
    public class ZenvioCacheModel
    {
        public DateTime? LastAttempt { get; set; }
        public int Attempts { get; set; }
        public bool Blocked { get; set; }
    }
}
