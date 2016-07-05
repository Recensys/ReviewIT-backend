namespace RecensysRepository.Entities
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public int Stage_Id { get; set; }
        public int Article_Id { get; set; }
        public int User_Id { get; set; }
        public int TaskType_Id { get; set; }
        public int Parent_Id { get; set; }
    }
}