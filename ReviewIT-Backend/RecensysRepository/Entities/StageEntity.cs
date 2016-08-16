﻿namespace RecensysRepository.Entities
{
    public class StageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Study_Id { get; set; }
        public int Next_Stage_Id { get; set; }
        public bool StageInitiated { get; set; }
        
    }
}