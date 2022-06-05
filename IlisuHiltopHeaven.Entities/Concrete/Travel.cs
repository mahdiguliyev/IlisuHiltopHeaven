using System;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Travel
    {
        public virtual int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageOne { get; set; }
        public string ImageTwo { get; set; }
        public string ImageThree { get; set; }
        public string ImageFour { get; set; }
        public string ImageFive { get; set; }
        public string ImageSix { get; set; }
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
    }
}
