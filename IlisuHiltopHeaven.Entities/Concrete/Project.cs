using System;

namespace IlisuHiltopHeaven.Entities.Concrete
{
    public class Project
    {
        public virtual int Id { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string MainPlan { get; set; }
        public string ComlexLoc { get; set; }
        public string BuildingProject { get; set; }
        public string MainImageOne { get; set; }
        public string MainImageTwo { get; set; }
        public string MainImageThree { get; set; }
        public string MainImageFour { get; set; }
        public string MainImageFive { get; set; }
        public string MainImageSix { get; set; }
        public string ImageOne { get; set; }
        public string ImageTwo { get; set; }
        public string ImageThree { get; set; }
        public string ImageFour { get; set; }
        public string ImageFive { get; set; }
        public string ImageSix { get; set; }
        public string MapUrl { get; set; }
        public int LanguageId { get; set; }
        public Guid LanguageGroupId { get; set; }
        public Language Language { get; set; }
    }
}
