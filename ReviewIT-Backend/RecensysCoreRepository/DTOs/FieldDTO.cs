using System;
using System.Collections.Generic;

namespace RecensysCoreRepository.DTOs
{
    public enum DataType
    {
        String, Boolean, Radio, Checkbox, Number, Resource
    }

    public class FieldDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; }
    }
}
