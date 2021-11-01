using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiDelivery.Requests
{
    public class CreateClientModel
    {
        public string AccountId { get; set; }
        public string ClientType { get; set; }  //Тип клиента false–физ. лицо true–юр. лицо
        public string Name { get; set; }        //Наименование организации (юр. лицо)
        public string SecondName { get; set; }  //Фамилия
        public string FirstName { get; set; }   //Имя
        public string LastName { get; set; }    //Отчество
        public string CityId { get; set; }      //Id города
        public string Egrpo { get; set; }       //ОКПО клиента
        public string PhoneNumber { get; set; } //Телефон Клиента
        public string Street { get; set; }      //Улица
        public string House { get; set; }       //Дом
        public string Appartament { get; set; } //Квартира
        public string senderId { get; set; }    //Id отправителя
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
