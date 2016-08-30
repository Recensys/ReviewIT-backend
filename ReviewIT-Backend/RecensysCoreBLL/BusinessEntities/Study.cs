﻿using System;
using System.Collections.Generic;
using TypeLite;

namespace RecensysBLL.BusinessEntities
{
    [TsClass]
    public class Study
    {
        public int Id { get; set; }
        public StudyDetails StudyDetails { get; set; }
        public List<Stage> Stages { get; set; }
        public List<Object> Sources { get; set; }
        public List<User> Researchers { get; set; }
        public List<Field> AvailableFields { get; set; }
    }
}
