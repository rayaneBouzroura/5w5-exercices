namespace _5W5_exo02_cookie_backend.Models.DTO
{   //TODO07 CREER DTO
    public class RegisterDTO
    {
        //class has username mail and password and generic stuff like they cant be empty n stuff i guess

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        //controller will validate them
        

        
    }
}
