namespace RecensysRepository.Entities
{
    public class FieldEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DataType_Id { get; set; }

        public int Study_Id { get; set; }

    }
}