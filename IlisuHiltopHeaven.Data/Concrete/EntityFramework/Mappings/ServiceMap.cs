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
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Title).HasMaxLength(100);
            builder.Property(s => s.Title).IsRequired(true);
            builder.Property(s => s.Description).IsRequired(true);
            builder.Property(s => s.Image).HasMaxLength(250);
            builder.Property(s => s.Image).IsRequired(true);

            builder.HasOne<Language>(a => a.Language).WithMany(c => c.Services).HasForeignKey(a => a.LanguageId);

            builder.ToTable("Service");

            builder.HasData(
                new Service
                {
                    Id = 1,
                    LanguageId = 1,
                    Title = "İcarəyə verilmə prosesinin təşkili",
                    Description = "Mənzilinizin sahəsindən asılı olaraq icarəyə verəcəyiniz məbləğ fərqli olacaq. Həmin icarə məbləğinin 55%-i sizin təmiz gəliriniz hesab ediləcək. Bu məbləğdən siz heçbir vergi, komissiya və komunal xərclər ödəməyəcəksiniz (bu şərtlər yalnız icarəyə verilən dövrü əhatə edir). Yerdə qalan 45% şirkətin idarəetmə komissiyası, komunal xərclər və xidmətlər, gəlir və mənfəət vergisi xərcləri və sair fors-major xərclər daxildir. İcarədən əldə edilən vəsaitin bölünmə sxemi:",
                    PercentageOwner = 55,
                    PercentageIHH = 45,
                    Image = "sprite.svg#icon-big-1",
                },
                new Service
                {
                    Id = 2,
                    LanguageId = 2,
                    Title = "Organization of the leasing process",
                    Description = "The amount you will rent will vary depending on the area of your apartment. 55% of that rent will be considered your net income. From this amount you will not pay any taxes, commissions and utilities (these terms only cover the lease period). The remaining 45% includes the company's management commission, utilities and services, income and profit tax expenses, and other force majeure expenses. Distribution scheme of rental funds:",
                    PercentageOwner = 55,
                    PercentageIHH = 45,
                    Image = "sprite.svg#icon-big-1",
                },
                new Service
                {
                    Id = 3,
                    LanguageId = 3,
                    Title = "Организация процесса лизинга",
                    Description = "Сумма арендной платы будет варьироваться в зависимости от площади вашей квартиры. 55% этой арендной платы будет считаться вашим чистым доходом. Из этой суммы вы не будете платить никаких налогов, комиссий и коммунальных услуг (эти условия распространяются только на период аренды). Оставшиеся 45% включают комиссию управления компании, коммунальные услуги и услуги, расходы по налогу на прибыль и прибыль и другие расходы на форс-мажорные обстоятельства. Схема распределения арендных средств:",
                    PercentageOwner = 55,
                    PercentageIHH = 45,
                    Image = "sprite.svg#icon-big-1",
                },
                new Service
                {
                    Id = 4,
                    LanguageId = 1,
                    Title = "Mənzillərin təmizliyi",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə mənzillərinizin təmizliyini ödənişsiz şirkətimiz tərəfindən həyata keçirilr.",
                    Image = "sprite.svg#icon-big-2"
                },
                new Service
                {
                    Id = 5,
                    LanguageId = 2,
                    Title = "Cleanliness of apartments",
                    Description = "Except for the period of your stay, the cleaning of your apartments during the lease period is carried out by our company free of charge.",
                    Image = "sprite.svg#icon-big-2"
                },
                new Service
                {
                    Id = 6,
                    LanguageId = 3,
                    Title = "Чистота квартир",
                    Description = "За исключением периода вашего пребывания, уборка ваших квартир в период аренды осуществляется нашей компанией бесплатно.",
                    Image = "sprite.svg#icon-big-2"
                },
                new Service
                {
                    Id = 7,
                    LanguageId = 1,
                    Title = "Cihaz və avadanliqlarin cari təmiri",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-3"
                },
                new Service
                {
                    Id = 8,
                    LanguageId = 2,
                    Title = "Current repair of devices and equipment ",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-3"
                },
                new Service
                {
                    Id = 9,
                    LanguageId = 3,
                    Title = "Текущий ремонт приборов и оборудования",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-3"
                },
                new Service
                {
                    Id = 10,
                    LanguageId = 1,
                    Title = "Açıq və qapalı hovuz",
                    Description = "Məişət əşyalarının qorunması tam təmin olunur. Əlavə olaraq bir neçə cümlədə əlavə olaraq qeyd edilə bilər.",
                    Image = "sprite.svg#icon-big-4"
                },
                new Service
                {
                    Id = 11,
                    LanguageId = 2,
                    Title = "Outdoor and indoor pool",
                    Description = "The protection of household items is fully provided. It can be additionally noted in a few sentences.",
                    Image = "sprite.svg#icon-big-4"
                },
                new Service
                {
                    Id = 12,
                    LanguageId = 3,
                    Title = "ЗОткрытый и закрытый бассейн",
                    Description = "Полностью предусмотрена защита предметов домашнего обихода. Это можно дополнительно отметить несколькими предложениями.",
                    Image = "sprite.svg#icon-big-4"
                },
                new Service
                {
                    Id = 13,
                    LanguageId = 1,
                    Title = "Kommunikasiya xidmetlerinin fasiləsiz işinin təşkili",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-5"
                },
                new Service
                {
                    Id = 14,
                    LanguageId = 2,
                    Title = "Organization of uninterrupted work of communication services",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-5"
                },
                new Service
                {
                    Id = 15,
                    LanguageId = 3,
                    Title = "Организация бесперебойной работы служб связи",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-5"
                },
                new Service
                {
                    Id = 16,
                    LanguageId = 1,
                    Title = "Əngəlli sakin və qonaqlarına köməklik",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-6"
                },
                new Service
                {
                    Id = 17,
                    LanguageId = 2,
                    Title = "Assistance to disabled residents and guests",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-6"
                },
                new Service
                {
                    Id = 18,
                    LanguageId = 3,
                    Title = "Помощь инвалидам и гостям",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-6"
                },
                new Service
                {
                    Id = 19,
                    LanguageId = 1,
                    Title = "Mənzilinizin onlayn idarə edilməsi",
                    Description = "Biznes-mənzilinizin onlayn idarə edilməsi",
                    Image = "sprite.svg#icon-big-7"
                },
                new Service
                {
                    Id = 20,
                    LanguageId = 2,
                    Title = "Manage your apartment online",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-7"
                },
                new Service
                {
                    Id = 21,
                    LanguageId = 3,
                    Title = "Управляйте своей квартирой онлайн",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-7"
                },
                new Service
                {
                    Id = 22,
                    LanguageId = 1,
                    Title = "Spa və gözəllik salonu",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-8"
                },
                new Service
                {
                    Id = 23,
                    LanguageId = 2,
                    Title = "Spa and beauty salon",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-8"
                },
                new Service
                {
                    Id = 24,
                    LanguageId = 3,
                    Title = "Спа и салон красоты",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-8"
                },
                new Service
                {
                    Id = 25,
                    LanguageId = 1,
                    Title = "Qapalı fitnes idman zalı",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-9"
                },
                new Service
                {
                    Id = 26,
                    LanguageId = 2,
                    Title = "Indoor fitness gym",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-9"
                },
                new Service
                {
                    Id = 27,
                    LanguageId = 3,
                    Title = "Крытый фитнес-зал",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-9"
                },
                new Service
                {
                    Id = 28,
                    LanguageId = 1,
                    Title = "Uşaq əyləncə meydançası",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-10"
                },
                new Service
                {
                    Id = 29,
                    LanguageId = 2,
                    Title = "Children's playground",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-10"
                },
                new Service
                {
                    Id = 30,
                    LanguageId = 3,
                    Title = "Детская площадка",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-10"
                },
                new Service
                {
                    Id = 31,
                    LanguageId = 1,
                    Title = "Turist marşturlarının təşkili",
                    Description = "Yaşadığınız müddət istisna olmaqla icarəyə verilən müddətdə cihaz və avadanlıqların cari təmiri ödnişsiz həyata keçirilir.",
                    Image = "sprite.svg#icon-big-11"
                },
                new Service
                {
                    Id = 32,
                    LanguageId = 2,
                    Title = "Организация туристических маршрутов",
                    Description = "Except for the period of your stay, the current repair of devices and equipment is carried out free of charge during the lease period.",
                    Image = "sprite.svg#icon-big-11"
                },
                new Service
                {
                    Id = 33,
                    LanguageId = 3,
                    Title = "Organization of tourist routes",
                    Description = "За исключением периода вашего пребывания текущий ремонт приборов и оборудования проводится бесплатно в период аренды.",
                    Image = "sprite.svg#icon-big-11"
                }
            );
        }
    }
}
