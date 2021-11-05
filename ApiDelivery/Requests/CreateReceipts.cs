using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiDelivery.Requests
{
    public class CreateReceipts
    {
        public string culture { get; set; } //Культура
        public string flSave { get; set; }  //Флаг сохраниния
        public string debugMode { get; set; } //Флаг режима дебага
        public List<ReceiptsList> receiptsList { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }

    public class ReceiptsList
    {
        public string senderId { get; set; } //Id отправтеля
        public string areasSendId { get; set; } //Город отправки
        public string areasResiveId { get; set; } //Город получения
        public string warehouseSendId { get; set; }  //Склад отправки
        public string warehouseResiveId { get; set; } //Склад получения
        public DateTime dateSend { get; set; } //Дата отправки
        public int deliveryScheme { get; set; }  //Схема доставки 0- Склад-склад, 1- Двери двери, 2- Склад-двери, 3- Двери-склад
        public string receiverName { get; set; }  //Получатель; для физ.лица - Ф.И.О.
        public string receiverPhone { get; set; } //Телефон получателя
        public bool receiverType { get; set; } //false – физ. лицо, true – юр. лицо
        public int currency { get; set; } //Валюта квитанции
        public float InsuranceValue { get; set; } //Застрахованная стоимость груза
        public string payerInsuranceId { get; set; } //плательщик страховки
        public string payerId { get; set; } //если плательщиком надо передать третье лицо
        public int payerType { get; set; }  //Тип плательщика 0-отправитель, 1-полуатель
        public int paymentType { get; set; } //Тип оплаты 1-безнал., 0-нал.
        public int paymentTypeInsuranse { get; set; } //Тип оплаты страховки 1-безнал., 0-нал.
        public string deliveryAddress { get; set; }  //Адрес доставки
        public string deliveryContactName { get; set; } //Контактное лицо для доставки
        public string deliveryContactPhone { get; set; }  //Телефон для доставки
        public string DeliveryComment { get; set; } //Комментарий при доставке
        public bool ReturnDocuments { get; set; } //Флаг возврат документо при доставке
        public int climbingToFloor { get; set; } //Подъем на этаж
        public bool EconomDelivery { get; set; } //Эконом доставка
        public bool IsOverSize { get; set; } //Негабарит, для Доставки груза
        public bool IsGidrobort { get; set; } //Гидроборт, для Доставки груза
        public bool EconomPickUp { get; set; }  //Эконом забор, для Забора груза
        public bool ExpressPickUp { get; set; }  //Экспресс забор, для Забора груза
        public float CustomsCost { get; set; }  //Таможенна стоимость груза
        public int CustomsCurrency { get; set; } //Валюта для таможни
        public bool CustomsDocuments { get; set; } //Флаг наличия документов для таможни
        public string CustomsDescriptions { get; set; }  // Опиание для таможни
        public int cashOnDeliveryType { get; set; } //Тип наложенного платежа 0-плетажна карта, 1-расчетый счет, 2-наличными, 3-Безопасная сделка
        public int CashOnDeliveryValuta { get; set; } //Валюта наложенного платежа
        public float CashOnDeliveryValue { get; set; } //Сумма наложенного платежа
        public string CashOnDeliveryCardId { get; set; } //Id платежной карты
        public string CashOnDeliveryPayerAccountId { get; set; } //плательщик наложенного платежа
        public string CashOnDeliveryRasschSchetId { get; set; } //Id расчетного счета(при Безопасной сделке поле обязательно для заполнения)
        public string CashOnDeliveryDescription { get; set; } //Описание наложенного платежа
        public string CashOnDeliveryWarehouseId { get; set; } //Склад выплаты наложенного платежа
        public string CashOnDeliverySenderFullName { get; set; } //Ф.И.О. получателя наложенного платежа
        public string CashOnDeliverySenderPhone { get; set; } //Телефон получателя наложенного  платежа
        public string CashOnDeliveryReceiverFullName { get; set; } //Ф.И.О. плательщика наложенного платежа
        public string CashOnDeliveryReceiverPhone { get; set; } //Телефон плательщика наложенного платежа
        public DateTime? pickUpDate { get; set; } //Дата забора
        public string pickUpContactName { get; set; } //контактное лицо для забора
        public string pickUpContactPhone { get; set; } //Контактный телефон для забора
        public string pickUpAddressId { get; set; } //Адрес забора
        public int? descentFromFloor { get; set; } //спуск с этажа
        public List<Cargo> category { get; set; }
    }

    public class Cargo
    {
        public string categoryId { get; set; } //Категория тарифа
        public string cargoCategoryId { get; set; } //Категория отправляемого груза
        public int countPlace { get; set; } //Количество мест
        public float? helf { get; set; } //Вес
        public float? size { get; set; }  //Объем
        public bool isEconom { get; set; } //Экономная, но более долгая доставка
        public string PartnerNumber { get; set; } //Номер декларации партнера
    }

    public enum DeliveryType
    {
        [Description("Відділення на відділення")]
        W2W = 0,
        [Description("Відділення на дім")]
        W2D = 1,
        [Description("З дому на відділення")]
        D2W = 2,
        [Description("З дому на дім")]
        D2D = 3
    }
}
