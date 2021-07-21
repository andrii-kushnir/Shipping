using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using ApiUkrPost.Base;
using ApiUkrPost.Adresses;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiUkrPost
{
    public class Controller
    {
        private const string ApiLink = "https://www.ukrposhta.ua/ecom/0.0.1";
        private const string AddressLink = "https://www.ukrposhta.ua/address-classifier-ws";
        private const string ApiLink_test = "https://dev.ukrposhta.ua/ecom/0.0.1";

        private static HttpClient Client;
        private static string _server;
        private static string _authorizationBearer;
        private static string _userToken;

        public Controller(string bearer, string token, string server = "")
        {
            Init(bearer, token, server);
        }

        public void Init(string bearer, string token, string server)
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
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationBearer);
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private HttpWebRequest GetHttpWebRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + _authorizationBearer);
            request.Accept = "application/json";
            return request;
        }

        public AddressDto CreateAddress(string postcode, string region, string district, string city, string street, string houseNumber, string apartmentNumber, string description = "")
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

        public string CreateAddressXml(string bearer, string token, string postcode, string region, string district, string city, string street, string houseNumber, string apartmentNumber, string description = "")
        {
            Init(bearer, token, "");
            return CreateAddress(postcode, region, district, city, street, houseNumber, apartmentNumber, description).ToXml<AddressDto>();
        }

        public AddressDto GetAddressByID(long id)
        {
            var response = SendGet($"/addresses/{id}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<AddressDto>(response);
            return result;
        }

        public string GetAddressByIDXml(string bearer, string token, long id)
        {
            Init(bearer, token, "");
            return GetAddressByID(id).ToXml<AddressDto>();
        }

        public ClientDto CreateClient(string firstName, string lastName, string middleName, long addressId, string phoneNumber, ClientIndivType type)
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

        public string CreateClientXml(string bearer, string token, string firstName, string lastName, string middleName, long addressId, string phoneNumber, ClientIndivType type)
        {
            Init(bearer, token, "");
            return CreateClient(firstName, lastName, middleName, addressId, phoneNumber, type).ToXml<ClientDto>();
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

        public ClientDto GetClient(string uuid)
        {
            var response = SendGet($"/clients/{uuid}?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public string GetClientXml(string bearer, string token, string uuid)
        {
            Init(bearer, token, "");
            return GetClient(uuid).ToXml<ClientDto>();
        }

        public List<ClientDto> GetClients(string phone)
        {
            var response = SendGet($"/clients/phone?token={_userToken}&countryISO3166=UA&phoneNumber={phone}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<List<ClientDto>>(response);
            return result;
        }

        public string GetClientsXml(string bearer, string token, string phone)
        {
            Init(bearer, token, "");
            return GetClients(phone).ToXml<List<ClientDto>>();
        }

        public ShipmentDto CreateShipment(string sender, string recipient, DeliveryType deliveryType, ShipmentType type, int weight, int length, int width = 0, int height = 0, int declaredPrice = 0, string description = "")
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
                description = description
            };
            var response = SendPost($"/shipments?token={_userToken}", shipment.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ShipmentDto>(response);
            return result;
        }

        public string CreateShipmentXml(string bearer, string token, string sender, string recipient, DeliveryType deliveryType, ShipmentType type, int weight, int length, int width = 0, int height = 0, int declaredPrice = 0, string description = "")
        {
            Init(bearer, token, "");
            return CreateShipment(sender, recipient, deliveryType, type, weight, length, width, height, declaredPrice, description).ToXml<ShipmentDto>();
        }

        public ShipmentDto GetShipment(string uuid)
        {
            var response = SendGet($"/shipments/{uuid}?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ShipmentDto>(response);
            return result;
        }

        public string GetShipmentXml(string bearer, string token, string uuid)
        {
            Init(bearer, token, "");
            return GetShipment(uuid).ToXml<ShipmentDto>();
        }

        public List<ShipmentDto> GetShipmentBySender(string uuid)
        {
            var response = SendGet($"/shipments?token={_userToken}&senderUuid={uuid}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<List<ShipmentDto>>(response);
            return result;
        }

        public string GetShipmentBySenderXml(string bearer, string token, string uuid)
        {
            Init(bearer, token, "");
            return GetShipmentBySender(uuid).ToXml<List<ShipmentDto>>();
        }

        public bool DeleteShipment(string uuid)
        {
            SendDelete($"/shipments/{uuid}?token={_userToken}", out bool success, out string message);
            return success;
        }


        #region Address Methods
        public List<Region> GetRegions(string region)
        {
            var result = new List<Region>();
            var response = GetFromAddress($"/get_regions_by_region_ua?region_name={region}", out bool success, out string message);
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

        public string GetRegionsXml(string bearer, string token, string region = "")
        {
            Init(bearer, token, "");
            return GetRegions(region).ToXml<List<Region>>();
        }

        public List<District> GetDistricts(long region, string district)
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

        public string GetDistrictsXml(string bearer, string token, long region, string district)
        {
            Init(bearer, token, "");
            return GetDistricts(region, district).ToXml<List<District>>();
        }

        public List<City> GetCities(long region, long district, string city)
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

        public string GetCitiesXml(string bearer, string token, long region, long district, string city)
        {
            Init(bearer, token, "");
            return GetCities(region, district, city).ToXml<List<City>>();
        }

        public List<Street> GetStreets(long region, long district, long city, string street)
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

        public string GetStreetsXml(string bearer, string token, long region, long district, long city, string street)
        {
            Init(bearer, token, "");
            return GetStreets(region, district, city, street).ToXml<List<Street>>();
        }

        public List<House> GetHouses(long street, string house)
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

        public string GetHousesXml(string bearer, string token, long street, string house)
        {
            Init(bearer, token, "");
            return GetHouses(street, house).ToXml<List<House>>();
        }

        public bool GetCourierarea(long postindex)
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

        public List<AddressDto> GetAddressByPostcode(long postindex)
        {
            var result = new List<AddressDto>();
            var response = GetFromAddress($"/get_address_by_postcode?postcode={postindex}&lang=UA", out bool success, out string message);
            if (success)
            {
                try
                {
                    throw new Exception("Отримаються усі адреси по індексу, але парсінг не реалізовано.");
                    //result = JsonConvert.DeserializeObject<PostofficesRoot>(response).Entries.Entry[0];
                }
                catch { }
            }
            return result;
        }

        public City GetCityByPostcode(long postindex)
        {
            City result = null;
            var response = GetFromAddress($"/get_city_details_by_postcode?postcode={postindex}&lang=UA", out bool success, out string message);
            if (success)
            {
                try
                {
                    var r = JsonConvert.DeserializeObject<CitiesFromIndexRoot>(response).Entries.Entry[0];
                    result = new City()
                    {
                        CITYID = r.CITYID,
                        CITYUA = r.CITYNAME,
                        CITYTYPEUA = r.CITYTYPENAME,
                        DISTRICTID = r.DISTRICTID,
                        DISTRICTUA = r.DISTRICTNAME,
                        REGIONID = r.REGIONID,
                        REGIONUA = r.REGIONNAME
                    };
                }
                catch { }
            }
            return result;
        }

        public string GetCityByPostcodeXml(string bearer, string token, long postindex)
        {
            Init(bearer, token, "");
            return GetCityByPostcode(postindex).ToXml<City>();
        }

        public List<Postoffice> GetPostoffices(long city)
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

        public string GetPostofficesXml(string bearer, string token, long city)
        {
            Init(bearer, token, "");
            return GetPostoffices(city).ToXml<List<Postoffice>>();
        }

        private string GetFromAddress_4_0(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(AddressLink + url);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            var result =  ParseResponse(response, out success, out message);
            response.Close();
            return result;
        }

        private string GetFromAddress(string url, out bool success, out string message)
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync(AddressLink + url).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
        }
        #endregion

        #region Base Method: GET, POST, PUT, DELETE
        private string SendGet_4_0(string url, out bool success, out string message)
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

        private string SendPost_4_0(string url, string requestBody, out bool success, out string message)
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

        private string SendPut_4_0(string url, string requestBody, out bool success, out string message)
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

        private string SendDelete_4_0(string url, out bool success, out string message)
        {
            var request = GetHttpWebRequest(_server + url);
            request.Method = "DETETE";
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

        private string SendGet(string url, out bool success, out string message)
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync(_server + url).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
        }

        private string SendPost(string url, string request, out bool success, out string message)
        {
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = Client.PostAsync(_server + url, content).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
        }

        private string SendPut(string url, string request, out bool success, out string message)
        {
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = Client.PutAsync(_server + url, content).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
        }

        private string SendDelete(string url, out bool success, out string message)
        {
            HttpResponseMessage response;
            try
            {
                response = Client.DeleteAsync(_server + url).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
        }

        private string ParseResponse(HttpWebResponse response, out bool success, out string message)
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

        private string ParseResponse(HttpResponseMessage response, out bool success, out string message)
        {
            if (!response.IsSuccessStatusCode)
            {
                success = false;
                message = response.StatusCode.ToString();
                return null;
            }

            string responseBody;
            try
            {
                responseBody = response.Content.ReadAsStringAsync().Result;
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
        #endregion

        public string GetStickerFile(string uuid)
        {
            var fileNamePDF = Path.GetTempPath() + Guid.NewGuid().ToString();

            try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
            catch { return null; }

            var response = Client.GetAsync(_server + $"/shipments/{uuid}/sticker?token={_userToken}").Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var file = new FileStream(fileNamePDF, FileMode.CreateNew))
                {
                    response.Content.CopyToAsync(file).Wait();
                }
                return fileNamePDF;
            }
            return null;
        }

        public string GetStickerFileXml(string bearer, string token, string uuid)
        {
            Init(bearer, token, "");
            return GetStickerFile(uuid);
        }
    }
}