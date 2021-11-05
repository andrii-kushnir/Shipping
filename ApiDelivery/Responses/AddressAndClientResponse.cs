using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiDelivery.Responses;
using Newtonsoft.Json;

namespace ApiDelivery.Requests
{
    public class AddressAndClientResponse : BaseResponse
    {
        public AddressAndClient data;
    }

    public class AddressAndClient
    {
        public Address address { get; set; }
        public Account account { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }      //Улица
        public string House { get; set; }       //Дом
        public string Appartament { get; set; } //Квартира
        public string AccountId { get; set; }
        public string CityId { get; set; }      //Id города
        public object Territoria { get; set; }
        public int StateCode { get; set; }
        public string EntityId { get; set; }
        public object Index { get; set; }
        public object NotActive { get; set; }
        public string NameFromApi { get; set; }
        public override string ToString()
        {
            return NameFromApi;
        }
    }

    public class Account
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string ClientType { get; set; }  //Тип клиента false–физ. лицо true–юр. лицо
        public string Name { get; set; }        
        public string SecondName { get; set; }  //Фамилия
        public string FirstName { get; set; }   //Имя
        public string LastName { get; set; }    //Отчество
        public bool PaymentType { get; set; }
        public string CityId { get; set; }
        public string Egrpo { get; set; }       //ОКПО клиента
        public object Inn { get; set; }
        public object Kpp { get; set; }
        public int OwnershipCode { get; set; }
        public string PhoneNumber { get; set; } //Телефон Клиента
        public string SmsPhoneNumber { get; set; }
        public object ParentAccountId { get; set; }
        public object ParentAccountName { get; set; }
        public int StateCode { get; set; }
        public string CountryCode { get; set; }
        public object MasterId { get; set; }
        public object ForwarderId { get; set; }
        public object HideChild { get; set; }
        public object SmsLang { get; set; }
        public object SecretMode { get; set; }
        public object IsTradingNetwork { get; set; }
        public object IsDenyAddDeliveryAddress { get; set; }
        public object CreatedOn { get; set; }
        public object AccountNumber { get; set; }
        public object IsPhoneConfirmed { get; set; }
        public object BanShowCost { get; set; }
        public object AutoReturn { get; set; }
        public object EmployeeDeliveryId { get; set; }
        public object Marketplace { get; set; }
        public object ChangePayerForYourself { get; set; }
        public object HideCostForSender { get; set; }
        public object HideCostForRecipient { get; set; }
        public object[] InternetShopOrders { get; set; }
        public object[] InternetShopPreOrders { get; set; }
        //public string senderId { get; set; }    //Id отправителя
        public override string ToString()
        {
            return Name;
        }
    }
}