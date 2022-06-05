using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Title1).HasMaxLength(500);
            builder.Property(b => b.Title1).IsRequired(true);
            builder.Property(b => b.Title2).HasMaxLength(500);
            builder.Property(b => b.Title2).IsRequired(true);
            builder.Property(b => b.MainPlan).IsRequired(true);
            builder.Property(b => b.ComlexLoc).IsRequired(true);
            builder.Property(b => b.BuildingProject).IsRequired(true);
            builder.Property(b => b.ImageOne).HasMaxLength(250);
            builder.Property(b => b.ImageOne).IsRequired(true);
            builder.Property(b => b.ImageTwo).HasMaxLength(250);
            builder.Property(b => b.ImageTwo).IsRequired(true);
            builder.Property(b => b.ImageThree).HasMaxLength(250);
            builder.Property(b => b.ImageThree).IsRequired(true);
            builder.Property(b => b.ImageFour).HasMaxLength(250);
            builder.Property(b => b.ImageFour).IsRequired(true);
            builder.Property(b => b.ImageFive).HasMaxLength(250);
            builder.Property(b => b.ImageFive).IsRequired(true);
            builder.Property(b => b.ImageSix).HasMaxLength(250);
            builder.Property(b => b.ImageSix).IsRequired(true);
            builder.Property(b => b.MainImageOne).HasMaxLength(250);
            builder.Property(b => b.MainImageOne).IsRequired(true);
            builder.Property(b => b.MainImageTwo).HasMaxLength(250);
            builder.Property(b => b.MainImageTwo).IsRequired(true);
            builder.Property(b => b.MainImageThree).HasMaxLength(250);
            builder.Property(b => b.MainImageThree).IsRequired(true);
            builder.Property(b => b.MainImageFour).HasMaxLength(250);
            builder.Property(b => b.MainImageFour).IsRequired(true);
            builder.Property(b => b.MainImageFive).HasMaxLength(250);
            builder.Property(b => b.MainImageFive).IsRequired(true);
            builder.Property(b => b.MainImageSix).HasMaxLength(250);
            builder.Property(b => b.MainImageSix).IsRequired(true);
            builder.Property(b => b.MapUrl).IsRequired(true);
            builder.Property(b => b.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(b => b.Language).WithMany(l => l.Projects).HasForeignKey(b => b.LanguageId);

            Guid languageGroupId = Guid.NewGuid();

            builder.HasData(
                new Project
                {
                    Id = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    Title1 = "Kompleksin lokasiyası",
                    Title2 = "Mənzillərin layihəsi",
                    MainPlan = "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur. 3 mərtəbəli yaşayış binasının ümumi sahəsi 570 kv. metrdir. Qeyri yaşayış binalarının hər birinin ümumi sahəsi 500 kv. metrdir. Burada qapalı və açıq restoran, qapalı hovuz, spa mərkəzi, fitnes mərkəzi, diyetik kafe, qadınlar üçün estetik mərkəz, gözəllik salonu və market nəzərdə tutulmuşdur.",
                    ComlexLoc = "1 ha torpaq sahəsində 11 ədəd 3 mərtəbəli yaşayış binası, açıq uşaq meydançası və 2 ədəd iki mərtəbəli qeyri-yaşayış binası nəzərdə tutulmuşdur.",
                    BuildingProject = "Biz ilk olaraq Azərbaycanda alıcının maliyyə durumuna uyğun olaraq mənzil sahəsini müyənnləşdirib sata bilirik. 28 kv. metrdən 190 kv. metrədək istənilən sahədə mənzil sahibi ola bilərsiniz. Mərtəbələr üzrə mənzilin palını yükləyə bilərsizniz. Daha ətraflı məlumata ehtiyacınız varsa məmnuniyyətlə bütün suallarınızı cavablandırmağa hazırıq.",
                    ImageOne = "project/projectimage1.png",
                    ImageTwo = "project/projectimage2.png",
                    ImageThree = "project/projectimage3.png",
                    ImageFour = "project/projectimage4.png",
                    ImageFive = "project/projectimage5.png",
                    ImageSix = "project/projectimage6.png",
                    MainImageOne = "project/projectimage7.png",
                    MainImageTwo = "project/projectimage8.png",
                    MainImageThree = "project/projectimage9.png",
                    MainImageFour = "project/projectimage10.jpg",
                    MainImageFive = "project/projectimage11.jpg",
                    MainImageSix = "project/projectimage12.jpg",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                },
                new Project
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    Title1 = "Location of the complex",
                    Title2 = "Housing project",
                    MainPlan = "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land. The total area of the 3-storey residential building is 570 sq.m. meters. The total area of each of the non-residential buildings is 500 sq.m. meters. There is an indoor and outdoor restaurant, an indoor pool, a spa center, a fitness center, a diet cafe, an aesthetic center for women, a beauty salon and a market.",
                    ComlexLoc = "There are 11 3-storey residential buildings, an open children's playground and 2 two-storey non-residential buildings on 1 hectare of land.",
                    BuildingProject = "First of all, we can determine and sell the housing area in Azerbaijan according to the financial situation of the buyer. 28 sq. M. 190 square meters. You can own an apartment in any area up to a meter. You can download the floor of the apartment. If you need more information, we are happy to answer all your questions.",
                    ImageOne = "project/projectimage1.png",
                    ImageTwo = "project/projectimage2.png",
                    ImageThree = "project/projectimage3.png",
                    ImageFour = "project/projectimage4.png",
                    ImageFive = "project/projectimage5.png",
                    ImageSix = "project/projectimage6.png",
                    MainImageOne = "project/projectimage7.png",
                    MainImageTwo = "project/projectimage8.png",
                    MainImageThree = "project/projectimage9.png",
                    MainImageFour = "project/projectimage10.jpg",
                    MainImageFive = "project/projectimage11.jpg",
                    MainImageSix = "project/projectimage12.jpg",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                },
                new Project
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    Title1 = "Расположение комплекса",
                    Title2 = "Жилищный проект",
                    MainPlan = "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома. Общая площадь 3-х этажного жилого дома 570 кв.м. метров. Общая площадь каждого нежилого дома составляет 500 кв.м. метров. Здесь есть крытый и открытый ресторан, крытый бассейн, спа-центр, фитнес-центр, диетическое кафе, эстетический центр для женщин, салон красоты и рынок.",
                    ComlexLoc = "На 1 га земли расположены 11 3-х этажных жилых домов, открытая детская площадка и 2 2-х этажных нежилых дома.",
                    BuildingProject = "Прежде всего, мы можем определить и продать жилую площадь в Азербайджане исходя из финансового положения покупателя. 28 кв. М. 190 квадратных метров. Вы можете владеть квартирой любой площади до метра. Вы можете скачать этаж квартиры. Если вам нужна дополнительная информация, мы с радостью ответим на все ваши вопросы.",
                    ImageOne = "project/projectimage1.png",
                    ImageTwo = "project/projectimage2.png",
                    ImageThree = "project/projectimage3.png",
                    ImageFour = "project/projectimage4.png",
                    ImageFive = "project/projectimage5.png",
                    ImageSix = "project/projectimage6.png",
                    MainImageOne = "project/projectimage7.png",
                    MainImageTwo = "project/projectimage8.png",
                    MainImageThree = "project/projectimage9.png",
                    MainImageFour = "project/projectimage10.jpg",
                    MainImageFive = "project/projectimage11.jpg",
                    MainImageSix = "project/projectimage12.jpg",
                    MapUrl = "<iframe src=\"https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3778.379899589656!2d49.8313591598617!3d40.39711718830179!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d7d1d7e6e47%3A0x18844c22b43281ea!2s123%20Game%20Lounge!5e1!3m2!1saz!2s!4v1629146008779!5m2!1saz!2s\" width = \"600\" height = \"450\" style=\"border: 0\" allowfullscreen = \"\" loading = \"lazy\"></iframe>"
                }
            );
        }
    }
}
