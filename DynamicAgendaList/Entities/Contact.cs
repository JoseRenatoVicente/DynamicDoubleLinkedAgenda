using DynamicAgendaList.Entities.Base;

namespace DynamicAgendaList.Entities
{
    internal class Contact : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ContactPhone[] ContactPhones { get; set; }
        public Contact Next { get; set; }
        public Contact Previous { get; set; }

        public override string ToString()
        {
            string phones = "";
            foreach (var phone in ContactPhones)  
                phones += phone.ToString();   

            return @$"Contact Data
    Id: {Id}
    Name: {Name}
    Email: {Email}
    Phones: {"none registered" ?? phones }";
        }
    }
}
