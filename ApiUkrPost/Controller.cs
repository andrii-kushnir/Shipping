using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;
//using System.Drawing;
using GemBox.Pdf;
using System.Net.Http.Headers;
using ApiUkrPost.Base;
using ApiUkrPost.Adresses;

namespace ApiUkrPost

{
    public class Controller
    {
        private const string ApiLink = "https://www.ukrposhta.ua/ecom/0.0.1";
        private const string AddressLink = "https://www.ukrposhta.ua/address-classifier-ws";
        private const string ApiLink_test = "https://dev.ukrposhta.ua/ecom/0.0.1";

        private static readonly HttpClient Client = new HttpClient();
        private readonly string _authorizationBearer;
        private readonly string _userToken;

        public Controller(string bearer, string token)
        {
            _authorizationBearer = bearer;
            _userToken = token;
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationBearer);
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public AddressDto CreateAddress(string postcode, string region, string district, string city, string street, string houseNumber, string apartmentNumber)
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
                apartmentNumber = apartmentNumber
            };
            var response = SendPost("/addresses", address.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<AddressDto>(response);
            return result;
        }

        public AddressDto GetAddressByID(long id)
        {
            var response = SendGet($"/addresses/{id}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<AddressDto>(response);
            return result;
        }

        public ClientDto CreateClient(string firstName, string lastName, long addressId, string phoneNumber, ClientIndivType type)
        {
            var client = new ClientDto()
            {
                firstName = firstName,
                lastName = lastName,
                addressId = addressId,
                phoneNumber = phoneNumber,
                type = type
            };
            var response = SendPost($"/clients?token={_userToken}", client.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public ClientDto ChangeClient(string uuid, string firstName, string lastName, long addressId, string phoneNumber, ClientIndivType type)
        {
            var client = new ClientDto()
            {
                firstName = firstName,
                lastName = lastName,
                addressId = addressId,
                phoneNumber = phoneNumber,
                type = type
            };
            var response = SendPut($"/clients/{uuid}?token={_userToken}", client.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public ClientDto GetClient(string uuid)
        {
            var response = SendGet($"/clients/{uuid}?token={_userToken}", out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ClientDto>(response);
            return result;
        }

        public ShipmentDto CreateShipment(string sender, string recipient, DeliveryType deliveryType, ShipmentType shipmentType, int weight, int length, string description)
        {
            string DeliveryTypeDescription = DeliveryType.W2W.GetDescription();
             
            var shipment = new ShipmentDto()
            {
                sender = new Sender { uuid = sender }, 
                recipient = new Recipient { uuid = recipient },
                deliveryType = deliveryType,
                shipmentType = shipmentType,
                weight = weight,
                length = length,
                description = description
            };
            var response = SendPost($"​/shipments?token ={_userToken}", shipment.ToJson(), out bool success, out string message);
            if (!success) return null;
            var result = JsonConvert.DeserializeObject<ShipmentDto>(response);
            return result;
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
                    result = JsonConvert.DeserializeObject<RegionsRoot>(response).Entries.Entry;
                }
                catch { }
            }
            return result;
        }

        public List<District> GetDistricts(long region, string district)
        {
            var result = new List<District>();
            var response = GetFromAddress($"/get_districts_by_region_id_and_district_ua?region_id={region}&district_ua={district}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<DistrictsRoot>(response).Entries.Entry;
                }
                catch { }
            }
            return result;
        }

        public List<City> GetCities(long region, long district, string city)
        {
            var result = new List<City>();
            var response = GetFromAddress($"/get_city_by_region_id_and_district_id_and_city_ua?district_id={district}&region_id={region}&city_ua={city}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<CitiesRoot>(response).Entries.Entry;
                }
                catch { }
            }
            return result;
        }

        public List<Street> GetStreets(long region, long district, long city, string street)
        {
            var result = new List<Street>();
            var response = GetFromAddress($"/get_street_by_region_id_and_district_id_and_city_id_and_street_ua?region_id={region}&district_id ={district}&city_id={city}&street_ua={street}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<StreetsRoot>(response).Entries.Entry;
                }
                catch { }
            }
            return result;
        }

        public List<House> GetHouses(long street, string house)
        {
            var result = new List<House>();
            var response = GetFromAddress($"/get_addr_house_by_street_id?street_id={street}&housenumber={house}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<HousesRoot>(response).Entries.Entry;
                }
                catch { }
            }
            return result;
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

        public List<Postoffice> GetPostoffices(long city)
        {
            var result = new List<Postoffice>();
            var response = GetFromAddress($"/get_postoffices_by_city_id?city_id={city}", out bool success, out string message);
            if (success)
            {
                try
                {
                    result = JsonConvert.DeserializeObject<PostofficesRoot>(response).Entries.Entry;
                }
                catch { }
            }
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
        private string SendGet(string url, out bool success, out string message)
        {
            HttpResponseMessage response;
            try
            {
                response = Client.GetAsync(ApiLink + url).Result;
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
                response = Client.PostAsync(ApiLink + url, content).Result;
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
                response = Client.PutAsync(ApiLink + url, content).Result;
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
                response = Client.DeleteAsync(ApiLink + url).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }
            return ParseResponse(response, out success, out message);
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

        //private Image GetPdf(string url)
        //{
        //    var temp = Path.GetTempPath();
        //    var fileNamePDF = temp + @"NovaPost.pdf";
        //    var fileNameJPG = temp + @"NovaPost.jpg";

        //    try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
        //    catch { fileNamePDF = temp + @"NovaPost1.pdf"; }

        //    try { if (File.Exists(fileNameJPG)) File.Delete(fileNameJPG); }
        //    catch { fileNameJPG = temp + @"NovaPost1.jpg"; }

        //    var request = (HttpWebRequest)WebRequest.Create(url);
        //    var response = (HttpWebResponse)request.GetResponse();

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        using (Stream inputStream = response.GetResponseStream())
        //        {
        //            using (Stream outputStream = File.OpenWrite(fileNamePDF))
        //            {
        //                byte[] buffer = new byte[4096];
        //                int bytesRead;
        //                do
        //                {
        //                    bytesRead = inputStream.Read(buffer, 0, buffer.Length);
        //                    outputStream.Write(buffer, 0, bytesRead);
        //                } while (bytesRead != 0);
        //            }
        //        }

        //        ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        //        using (PdfDocument document = PdfDocument.Load(fileNamePDF))
        //        {
        //            document.Save(fileNameJPG);
        //        }
        //        var image = Image.FromFile(fileNameJPG);
        //        return image;
        //    }

        //    return null;
        //}
    }
}

