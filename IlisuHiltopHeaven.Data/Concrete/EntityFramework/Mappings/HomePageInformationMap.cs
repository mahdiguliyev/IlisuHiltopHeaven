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
    public class HomePageInformationMap : IEntityTypeConfiguration<HomePageInformation>
    {
        public void Configure(EntityTypeBuilder<HomePageInformation> builder)
        {
            builder.HasKey(hp => hp.Id);
            builder.Property(hp => hp.Id).ValueGeneratedOnAdd();
            builder.Property(hp => hp.Title).HasMaxLength(100);
            builder.Property(hp => hp.Title).IsRequired(true);
            builder.Property(hp => hp.Description).HasMaxLength(500);
            builder.Property(hp => hp.Description).IsRequired(true);
            builder.Property(hp => hp.Image).HasMaxLength(250);
            builder.Property(hp => hp.Image).IsRequired(true);
            builder.Property(hp => hp.LanguageGroupId).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.HomePageInformations).HasForeignKey(a => a.LanguageId);

            builder.ToTable("HomePageInformation");

            Guid languageGroupId1 = Guid.NewGuid();
            Guid languageGroupId2 = Guid.NewGuid();
            Guid languageGroupId3 = Guid.NewGuid();

            builder.HasData(
                 new HomePageInformation
                 {
                    Id = 1,
                    LanguageId = 1,
                     LanguageGroupId = languageGroupId1,
                     Title = "Stabil qazanc gətirən mənzillər",
                    Description = "Bu mənzilləri əldə ederek siz heç bir əziyyət və əlavə sənədləşməyə zaman itirməden bizim kömeyimizlə istədiyiniz şəxslərə icarəyə verə biləcəksiniz. Və həmin qonaqlar da Sizin kimi kompleksdəki servis və xidmətlərdən, resepşn, təhlükəsizlik, mənzillərə xidmət, ərazidə yerləşən idman kompleksindən, uşaq meydançasından, açıq və qapalı hovuzlardan, restoran, gözəllik salonlarindan, mağazadan, kompleksi tərk etmədən istifadə edəcəksiniz.",
                    Image = "homepageinformation/homepageinf1.png"
                 },
                 new HomePageInformation
                 {
                     Id = 2,
                     LanguageId = 2,
                     LanguageGroupId = languageGroupId1,
                     Title = "Stable income apartments",
                     Description = "By purchasing these apartments, you will be able to rent them to anyone with our help without any hassle and without wasting time on additional documentation. And those guests, like you, will use the services of the complex, reception, security, housing, sports complex located in the area, playground, indoor and outdoor pools, restaurants, beauty salons, shops, without leaving the complex.",
                     Image = "homepageinformation/homepageinf1.png"
                 },
                 new HomePageInformation
                 {
                     Id = 3,
                     LanguageId = 3,
                     LanguageGroupId = languageGroupId1,
                     Title = "Квартиры со стабильным доходом",
                     Description = "Купив эти апартаменты, вы сможете сдать их кому угодно с нашей помощью без лишних хлопот и тратя время на дополнительную документацию. А такие гости, как и вы, будут пользоваться услугами комплекса, ресепшн, охраны, жилья, спорткомплекса, расположенного на территории, детской площадки, закрытого и открытого бассейнов, ресторанов, салонов красоты, магазинов, не выходя из комплекса.",
                     Image = "homepageinformation/homepageinf1.png"
                 },
                 new HomePageInformation
                 {
                     Id = 4,
                     LanguageId = 1,
                     LanguageGroupId = languageGroupId2,
                     Title = "Hilltop Heaven kompleksi: ev və biznesin vəhdətidir.",
                     Description = "Siz bu kompleksden mənzil alaraq istediyiniz zaman Azerbaycana, ilisuya gelerek seyahet edib öz dostlariniz ve tanişlarinizla maraqli istirahet etmək imkani elde edirsiniz. Əgər öz eviniz varsa niye diğer yerlere elave vesait xercləməlisiniz? Bizim biznes-mənzillərimiz yerleşdiyi dağlar kimi möhkem, dayaniqli bir biznes temelidir. Siz mənzil almaqla öz sermayenizi hem saxlaya hem da artırıa bilərsiniz. Həm özünüzə, həm də övladlarınıza.",
                     Image = "homepageinformation/homepageinf2.png"
                 },
                 new HomePageInformation
                 {
                     Id = 5,
                     LanguageId = 2,
                     LanguageGroupId = languageGroupId2,
                     Title = "Hilltop Heaven complex: a combination of home and business.",
                     Description = "When you buy an apartment in this complex, you can travel to Azerbaijan, Ilisu at any time and have an interesting vacation with your friends and acquaintances. If you have your own house, why spend extra money elsewhere? Our business apartments are as solid and sustainable as the mountains in which they are located. You can both save and increase your capital by buying an apartment. To yourself and your children.",
                     Image = "homepageinformation/homepageinf2.png"
                 },
                 new HomePageInformation
                 {
                     Id = 6,
                     LanguageId = 3,
                     LanguageGroupId = languageGroupId2,
                     Title = "Комплекс Hilltop Heaven: сочетание дома и бизнеса.",
                     Description = "Приобретая квартиру в этом комплексе, вы можете в любое время поехать в Азербайджан, Илису и провести интересный отдых в кругу друзей и знакомых. Если у вас есть собственный дом, зачем тратить лишние деньги в другом месте? Наши бизнес-апартаменты такие же прочные и экологичные, как и горы, в которых они расположены. Купив квартиру, вы можете как сэкономить, так и приумножить свой капитал. Для себя и своих детей.",
                     Image = "homepageinformation/homepageinf2.png"
                 },
                 new HomePageInformation
                 {
                     Id = 7,
                     LanguageId = 1,
                     LanguageGroupId = languageGroupId3,
                     Title = "Mənzillərə mülkiyyət hüququ əldə etmək şərtləri",
                     Description = "Azərbaycan qanunvericiliyinə əsasən hansı ölkənin vətəndaşı olmağınnan asılı olmayaraq biznes-mənzilin mülkiyyetçisi ola biler. Bunun üçün ödeniş olunaraq notariusda ve ya muvaviq olaraq Asan xidmet merkezkerində resmileşdirmə apararaq menzilin mulkiyyetçisi olmağınlz barede dövlət reyestrindən çixarış təqdim olunacaq",
                     Image = "homepageinformation/homepageinf3.png"
                 },
                 new HomePageInformation
                 {
                     Id = 8,
                     LanguageId = 2,
                     LanguageGroupId = languageGroupId3,
                     Title = "Conditions for acquiring property rights to apartments",
                     Description = "According to the legislation of Azerbaijan, a person can be the owner of a business apartment, regardless of the country of citizenship. For this purpose, an extract from the state register will be submitted to you, stating that you are the owner of the apartment by making a registration at a notary or, accordingly, in the Easy service center.",
                     Image = "homepageinformation/homepageinf3.png"
                 },
                 new HomePageInformation
                 {
                     Id = 9,
                     LanguageId = 3,
                     LanguageGroupId = languageGroupId3,
                     Title = "Условия приобретения имущественных прав на квартиры",
                     Description = "Согласно законодательству Азербайджана, лицо может быть владельцем деловой квартиры независимо от страны гражданства. Для этого вам будет предоставлена ​​выписка из государственного реестра о том, что вы являетесь собственником квартиры, сделав регистрацию у нотариуса или, соответственно, в сервисном центре Easy.",
                     Image = "homepageinformation/homepageinf3.png"
                 }
            );
        }
    }
}
