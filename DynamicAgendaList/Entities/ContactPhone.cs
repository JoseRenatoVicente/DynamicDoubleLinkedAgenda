using DynamicAgendaList.Entities.Enums;

namespace DynamicAgendaList.Entities
{
    public class ContactPhone
    {
        public int DDD { get; set; }
        public int Phone { get; set; }

        public TypesPhone TypesPhone { get; set; }

        public ContactPhone()
        {

        }
        public ContactPhone(int dDD, int phone, TypesPhone typesPhone)
        {
            DDD = dDD;
            Phone = phone;
            TypesPhone = typesPhone;
        }

        public override string ToString()
        {
            return @$"
        Type: {TypesPhone}
        Phone:({DDD}) {Phone}
";
        }

    }
}