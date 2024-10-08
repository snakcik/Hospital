﻿namespace Hospital.Dtos
{
    public class DepartmanDto
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool ? IsDeleted { get; set; }
        public string KeyValue { get; set; }    
        public DateTime? DeletedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
