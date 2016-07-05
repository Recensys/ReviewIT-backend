namespace RecensysBLL.Models.FullModels
{
    
    public class DataModel
    {
        public int Id { get; set; }
        public string DataType { get; set; }
        public int DataTypeId { get; set; }
        public int ArticleId { get; set; }
        public string Data { get; set; }
    }
}