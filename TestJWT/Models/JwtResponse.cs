namespace TestJWT.Models
{
    [Serializable]
    public class JwtResponse
    {
        //base64
        public string Token { get; set; }
        public string UserName { get; set; }
        public int Expire { get; set; }
    }
}
