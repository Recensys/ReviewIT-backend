namespace RecensysCoreBLL.BusinessEntities
{

    public enum DataType
    {
        String, Boolean, Radio, Checkbox, Number, Resource
    }

    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Input { get; set; }
        public DataType DataType { get; set; }
    }
}