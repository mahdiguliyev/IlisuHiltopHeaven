using System;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class SellCondition
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
    }
}
