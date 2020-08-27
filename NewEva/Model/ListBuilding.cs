using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public static class ListBuilding
    {
        public static IEnumerable<Category> Categories => new Category[]
        {
            new Category
            {
                Name = "Жилая недвижимость",
                Items = new List<BuildingBase>(new List<Dwelling>()
                {
                    new Dwelling("Квартира"),
                    new Dwelling("Комната")
                })
            },
            new Category
            {
                Name = "Нежилое помещение",
                Items = new List<BuildingBase>(new List<Dwelling>()
                {
                    new Dwelling("Офисно-торговый объект свободного назначения"),
                    new Dwelling("Офисы класса А, В"),
                    new Dwelling("Торговая недвижимость"),
                    new Dwelling("Производственно-складская недвижимость")
                })

            },
            new Category
            {
                Name = "Здание",
                Items = new List<BuildingBase>(new List<Dwelling>()
                {
                    new Dwelling("Жилой дом"),
                    new Dwelling("Офисно-торговый объект свободного назначения"),
                    new Dwelling("Офисы класса А, В"),
                    new Dwelling("Торговая недвижимость"),
                    new Dwelling("Производственно-складская недвижимость")
                })

            },
            new Category
            {
                Name = "Здание с земельным участком",
                Items = new List<BuildingBase>(new List<Dwelling>()
                {
                    new Dwelling("Жилой дом"),
                    new Dwelling("Офисно-торговый объект свободного назначения"),
                    new Dwelling("Офисы класса А, В"),
                    new Dwelling("Торговая недвижимость"),
                    new Dwelling("Производственно-складская недвижимость")
                })

            },
            new Category
            {
                Name = "Земельный участок",
                Items = new List<BuildingBase>(new List<Dwelling>()
                {
                    new Dwelling("Под индустриальную застройку"),
                    new Dwelling("Под офисно-торговую застройку"),
                    new Dwelling("Под многоквартирную жилую застройку"),
                    new Dwelling("Под индивидуальную жилую застройку"),
                    new Dwelling("Под объекты рекреации"),
                    new Dwelling("Под объекты придорожного сервиса")
                })

            },
        };
    }
}
