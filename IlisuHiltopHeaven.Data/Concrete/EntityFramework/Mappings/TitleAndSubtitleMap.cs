using IlisuHiltopHeaven.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlisuHiltopHeaven.Data.Concrete.EntityFramework.Mappings
{
    public class TitleAndSubtitleMap : IEntityTypeConfiguration<TitleAndSubtitle>
    {
        public void Configure(EntityTypeBuilder<TitleAndSubtitle> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Title1).HasMaxLength(500);
            builder.Property(s => s.Title1).IsRequired(true);
            builder.Property(s => s.Subtitle1).IsRequired(true);
            builder.Property(s => s.Title2).HasMaxLength(500);
            builder.Property(s => s.Title2).IsRequired(true);
            builder.Property(s => s.Subtitle2).IsRequired(true);
            builder.Property(s => s.Title3).HasMaxLength(500);
            builder.Property(s => s.Title3).IsRequired(true);
            builder.Property(s => s.Subtitle3).IsRequired(true);
            builder.Property(s => s.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.TitleAndSubtitles).HasForeignKey(a => a.LanguageId);

            builder.ToTable("TitlesAndSubtitles");
            Guid languageGroupId = Guid.NewGuid();
            builder.HasData(
                new TitleAndSubtitle
                {
                    Id  = 1,
                    LanguageId = 1,
                    LanguageGroupId = languageGroupId,
                    Title1 = "Azərbaycanda ilk olaraq yaşayış və qeyri-yaşayışı bir arada birləşdirərək sizlərə yeni bir biznes-mənzil modelini yaratdıq",
                    Subtitle1 = "Qafqaz dağlarının ətəyində, Kümrük çayına və İlisu dərəsinə baxış görünüşü olan 1 ha özəl torpaqda inşa etdiyimiz 11 ədəd binada, istəyinizə uyğun olan sahəli biznes-mənzillər təklif edirik.",
                    Title2 = "Sakinlər aşağıdakı xidmətləri əldə edir",
                    Subtitle2 = "Mənzil əldə etdikdən sonra əldə ediləcək xidmətlərə dair qısa məzmunlu iki cümlə.",
                    Title3 = "Ekoturizmin ən gözəl məkanlarından birində ev sahibi olun",
                    Subtitle3 = "Yaşayış kompleksimiz İlisu Dövlət Təbiət Qoruğunun bir addımlığındadır. İlisu dövlət qoruğu Böyük Qafqazın cənub yamacında Qax rayonu ərazisində, Zaqatala və İsmayıllı qoruqlarının arasında 700–2100 m hündürlükdə yerləşir. Ərazi Baş Qafqaz dağlarının dik yamaclı,çay dərələri vasitəsilə intensiv parçalanmış sahələri üçün səciyyəvi olan relyefə malikdir. Hündürlüyə qalxdıqca müasir kontinental, alt və üst təbaşirin, orta yuranın terrigen çöküntüləri bir birini əvəz edir.",
                },
                new TitleAndSubtitle
                {
                    Id = 2,
                    LanguageId = 2,
                    LanguageGroupId = languageGroupId,
                    Title1 = "For the first time in Azerbaijan, we have created a new business-housing model for you, combining residential and non-residential",
                    Subtitle1 = "At the foot of the Caucasus Mountains, in 11 buildings we built on 1 hectare of private land with a view of the Kumruk River and Ilisu Gorge, we offer business apartments in the area that suits your needs.",
                    Title2 = "Residents receive the following services",
                    Subtitle2 = "Two short sentences about the services to be obtained after obtaining an apartment.",
                    Title3 = "Host one of the most beautiful places in ecotourism",
                    Subtitle3 = "Our residential complex is one step away from the Ilisu State Nature Reserve. Ilisu State Reserve is located on the southern slope of the Greater Caucasus in the Gakh region, between the Zagatala and Ismayilli reserves at an altitude of 700-2100 m. The area has a relief typical of the steep slopes of the Main Caucasus Mountains, intensively divided by river valleys. As it rises, terrigenous sediments of modern continental, lower and upper Cretaceous, and Middle Jurassic replace each other.",
                },
                new TitleAndSubtitle
                {
                    Id = 3,
                    LanguageId = 3,
                    LanguageGroupId = languageGroupId,
                    Title1 = "Впервые в Азербайджане мы создали для вас новую модель бизнес-жилья, сочетающую жилое и нежилое.",
                    Subtitle1 = "У подножия Кавказских гор, в 11 зданиях, которые мы построили на 1 гектаре частной земли с видом на реку Кумрук и ущелье Илису, мы предлагаем бизнес-апартаменты в районе, который соответствует вашим потребностям.",
                    Title2 = "Жители получают следующие услуги",
                    Subtitle2 = "Два коротких предложения об услугах, которые необходимо получить после получения квартиры.",
                    Title3 = "Разместите одно из самых красивых мест в экотуризме.",
                    Subtitle3 = "Наш жилой комплекс находится в одном шаге от государственного природного заповедника Илису. Илисуский государственный заповедник расположен на южном склоне Большого Кавказа в Гахском районе, между Загатальским и Исмаиллинским заповедниками на высоте 700-2100 м. Рельеф местности характерен для крутых склонов Главного Кавказского хребта, интенсивно разделенных речными долинами. По мере его подъема терригенные отложения современного континентального, нижнего и верхнего мела и средней юры сменяют друг друга.",
                }
            );
        }
    }
}
