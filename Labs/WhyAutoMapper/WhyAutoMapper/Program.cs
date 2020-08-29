using AutoMapper;
using System;

namespace WhyAutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 沒有使用 AutoMapper 的程式設計
            {
                Person person = new Person()
                {
                    Name = "Vulcan",
                    Address = "Kaohsiung City",
                    Age = 18,
                };
                Console.WriteLine($"Name:{person.Name} / {person.Age}");
                Console.WriteLine($"將 Person 物件值，指派給 PersonDto 型別物件");
                PersonDto personDto = new PersonDto();
                personDto.Name = person.Name;
                personDto.Age = person.Age;
                personDto.Address = person.Address;
                Console.WriteLine($"personDto:{person.Name} / {personDto.Age}");
            }
            #endregion

            #region 使用 AutoMapper 的程式設計
            {
                #region 設定 AutoMapper 的對應關係
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Person, PersonDto>();
                });
                IMapper mapper = config.CreateMapper();
                #endregion
                Person person = new Person()
                {
                    Name = "Vulcan",
                    Address = "Kaohsiung City",
                    Age = 18,
                };
                Console.WriteLine($"Name:{person.Name} / {person.Age}");
                Console.WriteLine($"將 Person 物件值，指派給 PersonDto 型別物件");

                PersonDto personDto = mapper.Map<PersonDto>(person);
                Console.WriteLine($"personDto:{person.Name} / {personDto.Age}");
            }
            #endregion

        }
    }
}
