namespace RecensysRepository.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password_Salt { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string eMail { get; set; }
    }
}