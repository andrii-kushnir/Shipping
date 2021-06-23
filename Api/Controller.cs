using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Api.Base;
using Api.Requests;
using Api.Responses;
using Newtonsoft.Json;
using System.Drawing;
using GemBox.Pdf;

namespace Api
{
    public class Controller
    {
        private const string ApiLink = "https://api.novaposhta.ua/v2.0/json/";
        private const string GetMarking = "https://my.novaposhta.ua/orders/printMarking85x85/orders[]/{0}/type/pdf8/apiKey/{1}";
        private const string GetDocument = "https://my.novaposhta.ua/orders/printDocument/orders[]/{0}/type/pdf/apiKey/{1}";
        private static readonly HttpClient Client = new HttpClient();
        private readonly string _apiKey;

        public Controller(string apiKey)
        {
            _apiKey = apiKey;
        }

        public ResponseWrap<InternetDocumentDeleteOut> SendInternetDocumentDelete(string _ref = null)
        {
            var methodProperties = new InternetDocumentDeleteIn
            {
                DocumentRefs = _ref
            };
            var request = new Request<InternetDocumentDeleteIn>("InternetDocument", "delete", methodProperties);
            var response = Send<InternetDocumentDeleteIn, InternetDocumentDeleteOut>(request, out bool success, out string message);
            var result = new ResponseWrap<InternetDocumentDeleteOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<InternetDocumentSaveOut> SendInternetDocumentSave()
        {
            var methodProperties = new InternetDocumentSaveIn
            {
                NewAddress = "1",
                PayerType = "Sender",
                PaymentMethod = "Cash",
                CargoType = "Parcel",
                VolumeGeneral = "0.1", // об"єм
                Weight = "10",  // вага
                ServiceType = "WarehouseWarehouse", // доставака відділенні-відділення
                SeatsAmount = "1",
                Description = "книжка(Тестова ТТН!!!)",
                Cost = "120", // вартість
                CitySender = "736b2f80-0050-11e5-8a92-005056887b8d",  // місто відправки (наприклад Біла) //////
                Sender = "510d6693-dc23-11e8-8b24-005056881c6b",  // код відправника - головний ref
                SenderAddress = "736b2f92-0050-11e5-8a92-005056887b8d", // відділення відправки
                ContactSender = "11895969-dc24-11e8-8b24-005056881c6b", // контактна особа - ref
                SendersPhone = "380973334300",
                RecipientCityName = "Харків",
                RecipientArea = "7150813b-9b87-11de-822f-000c2965ae0e",
                RecipientAreaRegions = "3",
                RecipientAddressName = "1",
                RecipientHouse = "",
                RecipientFlat = "",
                RecipientName = "Тест Тест Тест",
                RecipientType = "PrivatePerson",
                RecipientsPhone = "380991234567",
                DateTime = "20.06.2021"
            };
            var request = new Request<InternetDocumentSaveIn>("InternetDocument", "save", methodProperties);
            var response = Send<InternetDocumentSaveIn, InternetDocumentSaveOut>(request, out bool success, out string message);
            var result = new ResponseWrap<InternetDocumentSaveOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<AddressWarehousesOut> SendAddressWarehouses(string findByString = null)
        {
            var methodProperties = new AddressWarehousesIn
            {
                CityName = findByString
            };
            var request = new Request<AddressWarehousesIn>("Address", "getWarehouses", methodProperties);
            var response = Send<AddressWarehousesIn, AddressWarehousesOut>(request, out bool success, out string message);
            var ddd = response.data.Find(d => d.Ref == "d492290b-55f2-11e5-ad08-005056801333");

            var result = new ResponseWrap<AddressWarehousesOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<AddressAreasOut> SendAddressAreas()
        {
            var methodProperties = new AddressAreasIn
            {
            };
            var request = new Request<AddressAreasIn>("Address", "getAreas", methodProperties);
            var response = Send<AddressAreasIn, AddressAreasOut>(request, out bool success, out string message);
            var result = new ResponseWrap<AddressAreasOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<AddressCitiesOut> SendAddressCities(string reff = null, int page = 0, string findByString = null)
        {
            var methodProperties = new AddressCitiesIn
            {
                Ref = reff,
                Page = page,
                FindByString = findByString
            };
            var request = new Request<AddressCitiesIn>("Address", "getCities", methodProperties);
            var response = Send<AddressCitiesIn, AddressCitiesOut>(request, out bool success, out string message);
            var result = new ResponseWrap<AddressCitiesOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<InternetDocumentDocumentListOut> SendInternetDocumentDocumentList(DateTime? dateTimeFrom = null, DateTime? dateTimeTo = null, string page = null, string getFullList = null, DateTime? dateTime = null)
        {
            var methodProperties = new InternetDocumentDocumentListIn
            {
                DateTimeFrom = dateTimeFrom,
                DateTimeTo = dateTimeTo,
                Page = page,
                GetFullList = getFullList,
                DateTime = dateTime
            };
            var request = new Request<InternetDocumentDocumentListIn>("InternetDocument", "getDocumentList", methodProperties);
            var response = Send<InternetDocumentDocumentListIn, InternetDocumentDocumentListOut>(request, out bool success, out string message);
            var result = new ResponseWrap<InternetDocumentDocumentListOut> { Response = response, Success = success, Message = message };
            return result;
        }

        public ResponseWrap<TrackingDocumentStatusDocumentsOut> TrackingDocumentStatusDocuments(List<Documents> documents)
        {
            var methodProperties = new TrackingDocumentStatusDocumentsIn
            {
                Documents = documents
            };
            var request = new Request<TrackingDocumentStatusDocumentsIn>("TrackingDocument", "getStatusDocuments", methodProperties);
            var response = Send<TrackingDocumentStatusDocumentsIn, TrackingDocumentStatusDocumentsOut>(request, out bool success, out string message);
            var result = new ResponseWrap<TrackingDocumentStatusDocumentsOut> { Response = response, Success = success, Message = message };
            return result;
        }

        private Response<TResponse> Send<TRequest, TResponse>(Request<TRequest> request, out bool success, out string message)
        {
            //old code(work):
            //var values = new Dictionary<string, object>
            //{
            //    { "modelName", "Address" },
            //    { "calledMethod", "getCities" },
            //    { "methodProperties", new Dictionary<string, object> {{ "FindByString", "Бровари" }, { "Page", 1 } } },
            //    { "apiKey", "34c150f0fdcead5e9188e939ee167efe" }
            //};
            //var request = JsonConvert.SerializeObject(values);
            request.apiKey = _apiKey;
            var content = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                response = Client.PostAsync(ApiLink, content).Result;
            }
            catch (Exception ex)
            {
                success = false;
                message = ex.Message;
                return null;
            }

            if (!response.IsSuccessStatusCode)
            {
                success = false;
                message = response.ReasonPhrase;
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

            Response<TResponse> result;
            try
            {
                result = JsonConvert.DeserializeObject<Response<TResponse>>(responseBody);

            }
            catch (JsonReaderException ex)
            {
                success = false;
                message = "Error Deserialize:  " + ex.Message;
                return null;
            }

            if (!result.success)
            {
                success = false;
                message = "";
                foreach (var error in result.errors)
                    message += "Error: " + error + " \n";
                return null;
            }

            success = true;
            message = "";
            return result;
        }

        public Image PrintMarking(string nomer)
        {
            var url = string.Format(GetMarking, nomer, _apiKey);
            return GetPdf(url);
        }

        public Image PrintDocument(string nomer)
        {
            var url = string.Format(GetDocument, nomer, _apiKey);
            return GetPdf(url);
         }

        private Image GetPdf(string url)
        {
            var temp = Path.GetTempPath();
            var fileNamePDF = temp + @"NovaPost.pdf";
            var fileNameJPG = temp + @"NovaPost.jpg";

            try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
            catch { fileNamePDF = temp + @"NovaPost1.pdf"; }

            try { if (File.Exists(fileNameJPG)) File.Delete(fileNameJPG); }
            catch { fileNameJPG = temp + @"NovaPost1.jpg"; }

            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream inputStream = response.GetResponseStream())
                {
                    using (Stream outputStream = File.OpenWrite(fileNamePDF))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        do
                        {
                            bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                            outputStream.Write(buffer, 0, bytesRead);
                        } while (bytesRead != 0);
                    }
                }

                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                using (PdfDocument document = PdfDocument.Load(fileNamePDF))
                {
                    document.Save(fileNameJPG);
                }
                var image = Image.FromFile(fileNameJPG);
                return image;
            }

            return null;
        }
    }
}

