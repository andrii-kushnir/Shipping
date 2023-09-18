﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using ApiUkrPost.Base;
using ApiUkrPost.Adresses;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
//using System.Net.Http;
//using System.Net.Http.Headers;

namespace ApiUkrPost
{
    public class Controller
    {
        private const string ApiLink = "https://www.ukrposhta.ua/ecom/0.0.1";
        private const string ApiLinkAddress = "https://www.ukrposhta.ua/address-classifier-ws";
        private const string ApiLinkStatuses = "https://www.ukrposhta.ua/status-tracking/0.0.1";
        private const string ApiLink_test = "https://dev.ukrposhta.ua/ecom/0.0.1";

        //private static HttpClient Client;
        private static string _server;
        private static string _authorizationBearer;
        private static string _authorizationBearerTracking;
        private static string _userToken;

        //File.WriteAllText(@"E:\temp\log.txt", "1. " + success.ToString() + message + " текст: " + response);

        public Controller(string bearer, string token, string bearerTracking, string server = "")
        {
            _authorizationBearerTracking = bearerTracking;
            Init(bearer, token, server);
        }

        public static void Init(string bearer, string token, string server)
        {
            if (server == "Test")
            {
                _server = ApiLink_test;
            }
            else
            {
                _server = ApiLink;
            }
            _authorizationBearer = bearer;
            _userToken = token;
            //Client = new HttpClient();
            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationBearer);
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static HttpWebRequest GetHttpWebRequest(string url, string bearer = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + (bearer == "" ? _authorizationBearer : bearer));
            request.Accept = "application/json";
            return request;
        }

        public static AddressDto CreateAddress(string postcode, string region, string district, string city, string street = "", string houseNumber = "", string apartmentNumber = "", string description = "")
        {
            var address = new AddressDto()
            {
                postcode = postcode,
                country = "UA",
                region = region,
                district = district,
                city = city,
                street = street,
                houseNumber = houseNumber,
                apartmentNumber = apartmentNumber,
                description = description
            };
            var response = SendPost("/addresses", address.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<AddressDto>(response);
            return result;
        }

        public static void CreateAddressXml(string bearer, string token, string postcode, string region, string district, string city, string street, string houseNumber, string apartmentNumber, out string result)
        {
            Init(bearer, token, "");
            result = CreateAddress(postcode, region, district, city, street, houseNumber, apartmentNumber).ToXml<AddressDto>();
        }

        public static AddressDto GetAddressByID(long id)
        {
            var response = SendGet($"/addresses/{id}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<AddressDto>(response);
            return result;
        }

        public static void GetAddressByIDXml(string bearer, string token, long id, out string result)
        {
            Init(bearer, token, "");
            result = GetAddressByID(id).ToXml<AddressDto>();
        }

        public static ClientDto CreateClient(string firstName, string lastName, string middleName, long addressId, string phoneNumber, ClientIndivType type)
        {
            var client = new ClientDto()
            {
                firstName = firstName,
                lastName = lastName,
                middleName = middleName,
                addressId = addressId,
                phoneNumber = phoneNumber,
                type = type
            };
            var response = SendPost($"/clients?token={_userToken}", client.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        private static bool _one = false;
        public static ClientDto CreateClientArbitrary(long addressId, string phoneNumber)
        {
            if (_one) return null;
            var client = new ClientDto()
            {
                name = "АРС-Кераміка",
                addressId = addressId,
                //tin = "3413904819",
                edrpou = "32549732",
                phoneNumber = phoneNumber,
                type = ClientIndivType.COMPANY,
                contactPersonName = "АРС-Кераміка"
            };
            var response = SendPost($"/clients?token={_userToken}", client.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            _one = true;
            return result;
        }

        public static void CreateClientXml(string bearer, string token, string firstName, string lastName, string middleName, long addressId, string phoneNumber, string type, out string result)
        {
            var typeEnum = (ClientIndivType)Enum.Parse(typeof(ClientIndivType), type);
            Init(bearer, token, "");
            result = CreateClient(firstName, lastName, middleName, addressId, phoneNumber, typeEnum).ToXml<ClientDto>();
        }

        public ClientDto ChangeClient(string uuid, string firstName, string lastName, string middleName, long addressId, string phoneNumber, ClientIndivType type)
        {
            var client = new ClientDto()
            {
                firstName = firstName,
                lastName = lastName,
                middleName = middleName,
                addressId = addressId,
                phoneNumber = phoneNumber,
                type = type
            };
            var response = SendPut($"/clients/{uuid}?token={_userToken}", client.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public string ChangeClientXml(string bearer, string token, string uuid, string firstName, string lastName, string middleName, long addressId, string phoneNumber, ClientIndivType type)
        {
            Init(bearer, token, "");
            return ChangeClient(uuid, firstName, lastName, middleName, addressId, phoneNumber, type).ToXml<ClientDto>();
        }

        public static ClientDto GetClient(string uuid)
        {
            var response = SendGet($"/clients/{uuid}?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public static void GetClientXml(string bearer, string token, string uuid, out string result)
        {
            Init(bearer, token, "");
            result = GetClient(uuid).ToXml<ClientDto>();
        }

        public static List<ClientDto> GetClients(string phone)
        {
            var response = SendGet($"/clients/phone?token={_userToken}&countryISO3166=UA&phoneNumber={phone}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<List<ClientDto>>(response);
            return result;
        }

        public static void GetClientsXml(string bearer, string token, string phone, out string result)
        {
            Init(bearer, token, "");
            result = GetClients(phone).ToXml<List<ClientDto>>();
        }

        public static ShipmentDto CreateShipment(string sender, string recipient, DeliveryType deliveryType, ShipmentType type, bool paidByRecipient, bool checkOnDelivery, double? postPay, bool postPayPaidByRecipient, int weight, int length, int? width = 0, int? height = 0, double? declaredPrice = 0, string description = "")
        {
            var shipment = new ShipmentDto()
            {
                sender = new ClientDto { uuid = sender },
                recipient = new ClientDto { uuid = recipient },
                deliveryType = deliveryType,
                type = type,
                parcels = new List<ParcelDto> {
                    new ParcelDto()
                    {
                        weight = weight,
                        length = length,
                        width = width,
                        height = height,
                        declaredPrice = declaredPrice
                    }},
                paidByRecipient = paidByRecipient,
                checkOnDelivery = checkOnDelivery,
                postPay = postPay,
                postPayPaidByRecipient = postPayPaidByRecipient,
                description = description
            };
            var response = SendPost($"/shipments?token={_userToken}", shipment.ToJson(), out bool success, out string message);
            //File.WriteAllText(@"E:\temp\log.txt", "1. " + success.ToString() + message + " текст: " + response + "data" + shipment.ToJson());
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ShipmentDto>(response);
            return result;
        }

        public static void CreateShipmentXml(string bearer, string token, string sender, string recipient, string deliveryType, string type, bool paidByRecipient, bool checkOnDelivery, double? postPay, bool postPayPaidByRecipient, int weight, int length, int width, int height, double declaredPrice, string description, out string result)
        {
            var DeliveryTypeEnum = (DeliveryType)Enum.Parse(typeof(DeliveryType), deliveryType);
            var typeEnum = (ShipmentType)Enum.Parse(typeof(ShipmentType), type);
            Init(bearer, token, "");
            result = CreateShipment(sender, recipient, DeliveryTypeEnum, typeEnum, paidByRecipient, checkOnDelivery, postPay, postPayPaidByRecipient, weight, length, width, height, declaredPrice, description).ToXml<ShipmentDto>();
        }

        public static ShipmentDto GetShipment(string uuid)
        {
            var response = SendGet($"/shipments/{uuid}?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ShipmentDto>(response);
            return result;
        }

        public static void GetShipmentXml(string bearer, string token, string uuid, out string result)
        {
            Init(bearer, token, "");
            result = GetShipment(uuid).ToXml<ShipmentDto>();
        }

        public static void GetLifecycleXml(string bearer, string token, string barcodeOrUuid, out string result)
        {
            result = "";
            Init(bearer, token, "");
            var response = SendGet($"/shipments/{barcodeOrUuid}/lifecycle?token={_userToken}", out bool success, out string message);
            if (!success) return;
            result = JsonConvert.DeserializeObject<MinifiedShipmentLifecycleRequestDto>(response).ToXml<MinifiedShipmentLifecycleRequestDto>();
        }

        public static Postpay GetPostpay(string barcode)
        {
            var response = SendGet($"/transfers/shipment-postpays/{barcode}/with-recipient?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<Postpay>(response);
            return result;
        }

        public static void GetPostpayXml(string bearer, string token, string barcode, out string result)
        {
            Init(bearer, token, "");
            result = GetPostpay(barcode).ToXml<Postpay>();
        }

        public static List<ShipmentDto> GetShipmentBySender(string uuid)
        {
            var response = SendGet($"/shipments?token={_userToken}&senderUuid={uuid}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<List<ShipmentDto>>(response).Where(s => s.lifecycle.status != Status1.DELETED).ToList();
            return result;
        }

        public static void GetShipmentBySenderXml(string bearer, string token, string uuid, out string result)
        {
            Init(bearer, token, "");
            result = GetShipmentBySender(uuid).ToXml<List<ShipmentDto>>();
        }

        public static bool DeleteShipment(string uuid)
        {
            SendDelete($"/shipments/{uuid}?token={_userToken}", out bool success, out string message);
            return success;
        }

        public static void DeleteShipmentXml(string bearer, string token, string uuid, out bool result)
        {
            result = false;
            Init(bearer, token, "");
            if (DeleteShipment(uuid))
            {
                result = true;
            }
        }


        #region Address Methods
        public static List<Region> GetRegions(string region)
        {
            var result = new List<Region>();
            var response = GetFromAddress($"/get_regions_by_region_ua?region_name={region}", out bool success, out string message);
            //var response = GetFromAddress($"/get_regions_by_region_ua", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<RegionsRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetRegionsXml(string bearer, out string result)
        {
            Init(bearer, "", "");
            result = GetRegions("").ToXml<List<Region>>();
        }

        public static List<District> GetDistricts(long region, string district)
        {
            var result = new List<District>();
            var response = GetFromAddress($"/get_districts_by_region_id_and_district_ua?region_id={region}&district_ua={district}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<DistrictsRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetDistrictsXml(string bearer, long region, out string result)
        {
            Init(bearer, "", "");
            result = GetDistricts(region, "").ToXml<List<District>>();
        }

        public static List<City> GetCities(long region, long district, string city)
        {
            var result = new List<City>();
            var response = GetFromAddress($"/get_city_by_region_id_and_district_id_and_city_ua?district_id={district}&region_id={region}&city_ua={city}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<CitiesRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetCitiesXml(string bearer, long region, long district, out string result)
        {
            Init(bearer, "", "");
            result = GetCities(region, district, "").ToXml<List<City>>();
        }

        public static List<Street> GetStreets(long region, long district, long city, string street)
        {
            var result = new List<Street>();
            var response = GetFromAddress($"/get_street_by_region_id_and_district_id_and_city_id_and_street_ua?region_id={region}&district_id ={district}&city_id={city}&street_ua={street}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<StreetsRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetStreetsXml(string bearer, long region, long district, long city, out string result)
        {
            Init(bearer, "", "");
            result = GetStreets(region, district, city, "").ToXml<List<Street>>();
        }

        public static List<House> GetHouses(long street, string house)
        {
            var result = new List<House>();
            var response = GetFromAddress($"/get_addr_house_by_street_id?street_id={street}&housenumber={house}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<HousesRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetHousesXml(string bearer, long street, out string result)
        {
            Init(bearer, "", "");
            result = GetHouses(street, "").ToXml<List<House>>();
        }

        public bool GetCourierarea(int postindex)
        {
            var response = GetFromAddress($"/get_courierarea_by_postindex?postindex={postindex}", out bool success, out string message);
            if (success)
            {
                string result = null;
                try
                {
                    result = JsonConvert.DeserializeObject<CourierareasRoot>(response).Entries.Entry[0].ISCOURIERAREA;
                }
                catch { }
                if (result != null && result == "1")
                {
                    return true;
                }
            }
            return false;
        }

        public List<AddressDto> GetAddressByPostcode(int postindex)
        {
            var result = new List<AddressDto>();
            var response = GetFromAddress($"/get_address_by_postcode?postcode={postindex}&lang=UA", out bool success, out string message);
            if (success)
            {
                try
                {
                    throw new Exception("Отримаються усі адреси по індексу, але парсінг не реалізовано. Це тому що обєм даних дуже великий - дуже багато адрес(будинків)");
                    //result = JsonConvert.DeserializeObject<PostofficesRoot>(response).Entries.Entry[0];
                }
                catch { }
            }
            return result;
        }

        public static City GetCityByPostcode(int postindex)
        {
            City result = null;
            var response = GetFromAddress($"/get_city_details_by_postcode?postcode={postindex}&lang=UA", out bool success, out string message);
            if (success)
            {
                var indexs = JsonConvert.DeserializeObject<CitiesFromIndexRoot>(response).Entries;
                if (indexs != null && indexs.Entry != null && indexs.Entry.Count != 0)
                {
                    result = new City()
                    {
                        CITYID = indexs.Entry[0].CITYID,
                        CITYUA = indexs.Entry[0].CITYNAME,
                        CITYTYPEUA = indexs.Entry[0].CITYTYPENAME,
                        DISTRICTID = indexs.Entry[0].DISTRICTID,
                        DISTRICTUA = indexs.Entry[0].DISTRICTNAME,
                        REGIONID = indexs.Entry[0].REGIONID,
                        REGIONUA = indexs.Entry[0].REGIONNAME
                    };
                }
            }
            return result;
        }

        public static void GetCityByPostcodeXml(string bearer, int postindex, out string result)
        {
            Init(bearer, "", "");
            result = GetCityByPostcode(postindex).ToXml<City>();
        }

        public static List<Postoffice> GetPostoffices(long city)
        {
            var result = new List<Postoffice>();
            var response = GetFromAddress($"/get_postoffices_by_city_id?city_id={city}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<PostofficesRoot>(response).Entries.Entry ?? result;
                }
                catch { }
            }
            return result;
        }

        public static void GetPostofficesXml(string bearer, long city, out string result)
        {
            Init(bearer, "", "");
            result = GetPostoffices(city).ToXml<List<Postoffice>>();
        }

        public static List<Status> GetStatuses(string barcode)
        {
            var result = new List<Status>();
            var response = GetFromStatuses($"/statuses?barcode={barcode}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<List<Status>>(response);
                }
                catch { }
            }
            return result;
        }

        public static void GetStatusesXml(string bearer, string barcode, out string result)
        {
            _authorizationBearerTracking = bearer;
            result = GetStatuses(barcode).ToXml<List<Status>>();
        }

        private static string GetFromAddress(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(ApiLinkAddress + url);
            request.Method = "GET";
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        //private string GetFromAddress(string url, out bool success, out string message)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.GetAsync(AddressLink + url).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        private static string GetFromStatuses(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(ApiLinkStatuses + url, _authorizationBearerTracking);
            request.Method = "GET";
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        public static GroupDto CreateGroup(string groupName, ShipmentType type)
        {
            var group = new GroupDto()
            {
                name = groupName,
                type = type
            };
            var response = SendPost($"/shipment-groups?token={_userToken}", group.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<GroupDto>(response);
            return result;
        }

        public static void CreateGroupXml(string bearer, string token, string groupName, string type, out string result)
        {
            var typeEnum = (ShipmentType)Enum.Parse(typeof(ShipmentType), type);
            Init(bearer, token, "");
            result = CreateGroup(groupName, typeEnum).ToXml<GroupDto>();
        }

        public static GroupAddResponse AddShipmentToGroup(string groupUuid, string shipmentUuid)
        {
            var response = SendPut($"/shipment-groups/{groupUuid}/shipments?token={_userToken}", $"[\"{shipmentUuid}\"]", out bool success, out string message);
            if (!success) return null;
            var listShipments = JsonConvert.DeserializeObject<List<GroupAddResponse>>(response);
            return (listShipments != null && listShipments.Count != 0) ? listShipments[0] : null;
        }

        public static void AddShipmentToGroupXml(string bearer, string token, string groupUuid, string shipmentUuid, out string result)
        {
            Init(bearer, token, "");
            result = AddShipmentToGroup(groupUuid, shipmentUuid).ToXml<GroupAddResponse>();
        }

        public static List<ShipmentDto> GetShipmentByGroup(string groupUuid)
        {
            var response = SendGet($"/shipment-groups/{groupUuid}/shipments?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<List<ShipmentDto>>(response);
            return result;
        }

        public static bool DeleteShipmentByGroup(string shipmentUuid)
        {
            var response = SendDelete($"/shipments/{shipmentUuid}/shipment-group?token={_userToken}", out bool success, out string message);
            return success;
        }

        //private string GetFromStatuses(string url, out bool success, out string message)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.GetAsync(ApiLinkStatuses + url).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        #endregion

        #region Base Method: GET, POST, PUT, DELETE
        private static string SendGet(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(_server + url);
            request.Method = "GET";
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        private static string SendPost(string url, string requestBody, out bool success, out string message)
        {
            var request = GetHttpWebRequest(_server + url);
            request.Method = "POST";
            request.ContentType = "application/json";
            var data = Encoding.UTF8.GetBytes(requestBody);
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        private static string SendPut(string url, string requestBody, out bool success, out string message)
        {
            var request = GetHttpWebRequest(_server + url);
            request.Method = "PUT";
            request.ContentType = "application/json";
            var data = Encoding.UTF8.GetBytes(requestBody);
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        private static string SendDelete(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(_server + url);
            request.Method = "DELETE";
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            var result = ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        //private string SendGet(string url, out bool success, out string message)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.GetAsync(_server + url).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        //private string SendPost(string url, string request, out bool success, out string message)
        //{
        //    var content = new StringContent(request, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.PostAsync(_server + url, content).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        //private string SendPut(string url, string request, out bool success, out string message)
        //{
        //    var content = new StringContent(request, Encoding.UTF8, "application/json");
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.PutAsync(_server + url, content).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        //private string SendDelete(string url, out bool success, out string message)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {
        //        response = Client.DeleteAsync(_server + url).Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }
        //    return ParseResponse(response, out success, out message);
        //}

        private static string ParseResponse(HttpWebResponse response, out bool success, out string message)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                success = false;
                message = response.StatusCode.ToString();
                return null;
            }
            string responseBody = null;
            try
            {
                using (Stream inputStream = response.GetResponseStream())
                {
                    if (inputStream != null)
                    {
                        responseBody = new StreamReader(inputStream, Encoding.UTF8).ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }

            success = true;
            message = "";
            return responseBody;
        }

        //private string ParseResponse(HttpResponseMessage response, out bool success, out string message)
        //{
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        success = false;
        //        message = response.StatusCode.ToString();
        //        return null;
        //    }

        //    string responseBody;
        //    try
        //    {
        //        responseBody = response.Content.ReadAsStringAsync().Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        success = false;
        //        message = ex.Message;
        //        return null;
        //    }

        //    success = true;
        //    message = "";
        //    return responseBody;
        //}
        #endregion

        public static string GetStickerFile(string uuid)
        {
            var fileNamePDF = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
            catch { return null; }

            var request = GetHttpWebRequest(_server + $"/shipments/{uuid}/sticker?token={_userToken}");
            HttpWebResponse response;
            try { response = (HttpWebResponse)request.GetResponse(); }
            catch { return null; }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream inputStream = response.GetResponseStream())
                {
                    using (Stream outputStream = File.OpenWrite(fileNamePDF))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
            }
            response.Close();
            return fileNamePDF;
        }

        public static void GetStickerFileXml(string bearer, string token, string uuid)
        {
            Init(bearer, token, "");
            string fileName = GetStickerFile(uuid);

            byte[] imageData;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                using (var query = new SqlCommand(@"INSERT INTO #tablePdf (data) Values(@File)", connection))
                {
                    query.Parameters.Add("@File", SqlDbType.Image).Value = imageData;
                    query.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static string GetForm103(string groupUuid)
        {
            var fileNamePDF = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
            catch { return null; }

            var request = GetHttpWebRequest(_server + $"/shipment-groups/{groupUuid}/form103a?token={_userToken}");
            HttpWebResponse response;
            try { response = (HttpWebResponse)request.GetResponse(); }
            catch { return null; }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream inputStream = response.GetResponseStream())
                {
                    using (Stream outputStream = File.OpenWrite(fileNamePDF))
                    {
                        var buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }
            }
            response.Close();
            return fileNamePDF;
        }

        public static void GetForm103Xml(string bearer, string token, string groupUuid)
        {
            Init(bearer, token, "");
            string fileName = GetForm103(groupUuid);

            byte[] imageData;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
            }
            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                using (var query = new SqlCommand(@"INSERT INTO #tablePdf (data) Values(@File)", connection))
                {
                    query.Parameters.Add("@File", SqlDbType.Image).Value = imageData;
                    query.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}