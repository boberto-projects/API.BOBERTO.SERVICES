namespace API.BOBERTO.SERVICES.APPLICATION.MESSAGES.Config
{
    /// <summary>
    /// This is because i want to limit the maximum request of sms to my month limit at zenvio. I dont want to pay above my contracted plan
    /// </summary>
    public class ZenvioSecurityConfig
    {
        /// <summary>
        /// MAx sconds to expire
        /// </summary>
        public int SecondsExpiration { get; set; }
        /// <summary>
        /// Max diary SMS
        /// </summary>
        public int MaxDiarySMSLimit { get; set; }
    }
}
