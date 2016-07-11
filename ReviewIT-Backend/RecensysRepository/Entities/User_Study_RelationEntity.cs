namespace RecensysRepository.Entities
{
    public class User_Study_RelationEntity
    {
        public int User_Id { get; set; }
        public int Study_Id { get; set; }
        public bool isAdmin { get; set; }
    }
}