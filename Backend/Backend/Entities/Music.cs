using System;
namespace Backend.Entities
{
    public class Music:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
    }
}
