using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ApiDelivery.Requests;
using ApiDelivery.Responses;
using Newtonsoft.Json;

namespace ApiDelivery
{
    public class Controller
    {
        private const string ApiLink = "http://www.delivery-auto.com/api/";

        //private const string UserName = "andrii.kushnir@ars.ua";
        //private const string Password = "poiand";

        private static string _apiKey;
        private static string _apiSecretKey;

        //File.WriteAllText(@"E:\temp\log.txt", "1. " + success.ToString() + message + " текст: " + response);

        public Controller(string apiKey, string apiSecretKey)
        {
            _apiKey = apiKey;
            _apiSecretKey = apiSecretKey;
        }

        public static void TestJSApi()
        {
            string dataString = @"{""egs"": [{""Id"": ""f6ee49fa-3e29-e311-8b0d-00155d037960"", ""PartnerNumber"": ""123456"" } ] }";
            var response = SendPost($"v4/Public/PostDeactivateEg", dataString, out bool success, out string message);
            if (!success) return;
            //var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return;
        }

        //public static bool PostLogin()
        //{
        //    var result = false;
        //    var response = SendPost($"v4/Public/PostLogin", $"{{\"UserName\": \"{UserName}\", \"Password\": \"{Password}\", \"RememberMe\": false }}", out bool success, out string message);
        //    if (success)
        //    {
        //        var mess = JsonConvert.DeserializeObject<BaseResponse>(response);
        //        if (mess.status) result = true;
        //    }
        //    return result;
        //}

        //public static bool PostLogoff()
        //{
        //    var result = false;
        //    var response = SendPost($"v4/Public/PostLogoff", $"{{}}", out bool success, out string message);
        //    if (success)
        //    {
        //        var mess = JsonConvert.DeserializeObject<BaseResponse>(response);
        //        if (mess.status) result = true;
        //    }
        //    return result;
        //}

        public static List<Invoice> GetClientInvoices()
        {
            var result = new List<Invoice>();
            var response = SendGet($"v4/Public/GetClientInvoices?culture=uk-UA", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<InvoiceResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Region> GetRegionList()
        {
            var result = new List<Region>();
            var response = SendGet($"v4/Public/GetRegionList?culture=uk-UA", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<RegionListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Area> GetAreasList(int regionId)
        {
            var result = new List<Area>();
            var response = SendGet($"v4/Public/GetAreasList?culture=uk-UA&fl_all=false&regionId={regionId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<AreaListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Warehouse> GetWarehousesList(string regionId, string cityId)
        {
            var result = new List<Warehouse>();
            var response = SendGet($"v4/Public/GetWarehousesList?culture=uk-UA&CityId={cityId}&RegionId={regionId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<WarehouseListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<CargoCategory> GetCargoCategory()
        {
            var result = new List<CargoCategory>();
            var response = SendGet($"v4/Public/GetCargoCategory?culture=uk-UA&TariffCategoryId=0656bab4-e62c-e411-bd10-000d3a200936", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<CargoCategoryListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Tariff> GetTariffCategory(string citySendId, string cityReciveId, string warehouseReceiveId)
        {
            var result = new List<Tariff>();
            var response = SendGet($"v4/Public/GetTariffCategory?CitySendId={citySendId}&CityReceiveId={cityReciveId}&WarehouseReceiveId={warehouseReceiveId}&culture=uk-UA", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<TariffListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Sender> GetSenderList()
        {
            var result = new List<Sender>();
            var response = SendGet($"v4/Public/GetSenderList", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<SenderListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<Reciver> GetPosibleReciver(string CityReceiveId, string ClientSenderId)
        {
            var result = new List<Reciver>();
            var response = SendGet($"v4/Public/GetPosibleReciver?CityReceiveId={CityReceiveId}&ClientSenderId={ClientSenderId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<ReciverListResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static AddressAndClient CreateClient(string firstName, string lastName, string middleName, string phoneNumber, string cityId, string street, string house, string appartament, string senderId)
        {
            var result = new AddressAndClient();
            var clientModel = new CreateClientModel()
            {
                ClientType = "false", // фізичне
                SecondName = lastName,
                FirstName = firstName,
                LastName = middleName,
                CityId = cityId,
                PhoneNumber = phoneNumber,
                Street = street,
                House = house,
                Appartament = appartament,
                senderId = senderId
            };

            var response = SendPost($"v4/Public/PostCreateAddressOrClient", clientModel.ToJson(), out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<AddressAndClientResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        #region Base Methods REST
        private static HttpWebRequest GetHttpWebRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.ContentType = "application/json";
            var timestampMilliseconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 00)).Milliseconds.ToString();
            var HMAC = CryptoHMAC.GetHMAC(_apiKey, timestampMilliseconds, _apiSecretKey);
            request.Headers["HMACAuthorization"] = $"amx {_apiKey}:{timestampMilliseconds}:{HMAC}";
            return request;
        }

        private static string SendGet(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(ApiLink + url);
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
            var request = GetHttpWebRequest(ApiLink + url);
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
            var request = GetHttpWebRequest(ApiLink + url);
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
            var request = GetHttpWebRequest(ApiLink + url);
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
        #endregion Base Methods REST
    }
}