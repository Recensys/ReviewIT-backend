namespace RecensysRepository.Repository.DTO
{
    public class CredentialsDTO
    {
        public int C_Id { get; set; }
        public int U_Id { get; set; }
        public string User_Name { get; set; }
        public string Password_Salt { get; set; }
    }
}