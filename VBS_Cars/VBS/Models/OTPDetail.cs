namespace VBS.Controllers
{
    public class OTPDetail
    {
        public string email { get; internal set; }
        public int getIndex { get; internal set; }
        public object finalDigit { get; internal set; }
        public object? otp { get; internal set; }
        public object num { get; internal set; }
        public int len { get; internal set; }
        public int otpDigit { get; internal set; }
    }
}