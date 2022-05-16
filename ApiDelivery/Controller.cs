using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

        private static string _apiKey;
        private static string _apiSecretKey;

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
        }

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

        public static string GetClientCards()
        {
            var result = string.Empty;
            var response = SendGet($"v4/Public/GetClientCards", out bool success, out string message);
            if (success)
            {
                //var mess = JsonConvert.DeserializeObject<InvoiceResponse>(response);
                //if (mess.status) result = mess.data;
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

        public static void GetRegionListSQL(string publicKey, string secretKey)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            var regions = GetRegionList();
            ListToSQL<Region>(regions);
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

        public static void GetAreasListSQL(string publicKey, string secretKey, int regionId)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            var Areas = GetAreasList(regionId);
            ListToSQL<Area>(Areas);
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

        public static void GetWarehousesListSQL(string publicKey, string secretKey, string regionId, string cityId)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            var Warehouses = GetWarehousesList(regionId, cityId);
            ListToSQL<Warehouse>(Warehouses);
        }

        public static WarehousesInfo GetWarehousesInfo(string warehouseId)
        {
            var result = new WarehousesInfo();
            var response = SendGet($"v4/Public/GetWarehousesInfo?culture=uk-UA&WarehousesId={warehouseId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<WarehousesInfoResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static void GetWarehousesInfoXml(string publicKey, string secretKey, string warehouseId, out string result)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            result = GetWarehousesInfo(warehouseId).ToXml<WarehousesInfo>();
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

        public static void GetCargoCategorySQL(string publicKey, string secretKey)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            var CargoCategory = GetCargoCategory();
            ListToSQL<CargoCategory>(CargoCategory);
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

        public static void GetTariffCategorySQL(string publicKey, string secretKey, string citySendId, string cityReciveId, string warehouseReceiveId)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            var TariffCategory = GetTariffCategory(citySendId, cityReciveId, warehouseReceiveId);
            ListToSQL<Tariff>(TariffCategory);
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

        public static List<Payer> GetPayer(string CitySendId, string CityReceiveId, string ClientSenderId)
        {
            var result = new List<Payer>();
            var response = SendGet($"v4/Public/GetPayer?CitySendId={CitySendId}&CityReceiveId={CityReceiveId}&ClientSenderId={ClientSenderId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<PayerResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static bool GetClientPaymentType(string ClientId)
        {
            var result = false;
            var response = SendGet($"v4/Public/GetClientPaymentType?ClientId={ClientId}", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<ClientPaymentTypeResponse>(response);
                if (mess.status) result = mess.data;
            }
            //true - готівка
            //false - безготівка
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

            //File.AppendAllText(@"E:\temp\log.txt", $"clientModel  - : {clientModel.ToJson()} \r");

            var response = SendPost($"v4/Public/PostCreateAddressOrClient", clientModel.ToJson(), out bool success, out string message);
            //File.AppendAllText(@"E:\temp\log.txt", $"message  - : {message} \r");
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<AddressAndClientResponse>(response);
                if (mess.status) result = mess.data;
            }
            return result;
        }

        public static List<ReceiptResp> PostCreateReceipts(CreateReceipts receipt)
        {
            var result = new List<ReceiptResp>();
            var response = SendPost($"v4/Public/PostCreateReceipts", receipt.ToJson(), out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<ReceiptResponse>(response);
                if (mess.status)
                {
                    result = mess.receipts;
                }
                else
                {
                    throw new Exception(mess.message[0]);
                }
            }
            return result;
        }

        public static void CreateReceiptsXml(int id, out string result)
        {
            result = "";
            string publicKey = null, secretKey = null;
            int senderId = 0, deliScheme = 0, insurValue = 0, payerType = 0, postPay = 0;
            string uuid = null, number = null, recipFName = null, recipLName = null, recipMName = null, recipPhone = null, recipCity = null, recipWareh = null, address = null, descriptio = null;
            bool isEconom = false;
            string senderUuid = null, citySender = null, warehousSender = null, senderName = null, phoneNumbr = null;
            var cargoList = new List<Cargo>();

            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM [InetClient].[dbo].[DeliveryShipments] WHERE id = {id}", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        uuid = reader[2] as string;
                        number = reader[3] as string;
                        senderId = reader.GetInt32(5);
                        recipFName = reader[6] as string;
                        recipLName = reader[7] as string;
                        recipMName = reader[8] as string;
                        recipPhone = reader[9] as string;
                        recipCity = reader[11] as string;
                        recipWareh = reader[12] as string;
                        address = reader[13] as string;
                        deliScheme = reader.GetInt32(14);
                        insurValue = reader.GetInt32(15);
                        payerType = reader.GetBoolean(16) ? 1 : 0;
                        isEconom = reader.GetBoolean(17);
                        postPay = reader.GetInt32(18);
                        descriptio = reader[19] as string;
                    }
                using (SqlCommand command = new SqlCommand($"SELECT * FROM [InetClient].[dbo].[DeliveryInfoSender] WHERE id = {senderId}", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        publicKey = reader.GetString(1);
                        secretKey = reader.GetString(2);
                        _apiKey = publicKey;
                        _apiSecretKey = secretKey;
                        senderUuid = reader.GetString(3);
                        senderName = reader.GetString(4);
                        citySender = reader.GetString(5);
                        warehousSender = reader.GetString(6);
                        phoneNumbr = reader.GetString(8);
                    }
                using (SqlCommand command = new SqlCommand($"SELECT * FROM [InetClient].[dbo].[DeliveryCargo] WHERE shipmentId = {id}", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        cargoList.Add(new Cargo(){
                            categoryId = reader.GetString(2),
                            cargoCategoryId = reader.GetString(4),
                            countPlace = reader.GetInt32(6),
                            helf = (float)reader.GetDecimal(7),
                            size = (float)reader.GetDecimal(8),
                            isEconom = isEconom});
                    }
            }

            string[] words = address.Split(',');
            string street = words[0];
            string house = (words.Length > 1) ? words[1] : "0";
            string appartament = (words.Length > 2) ? words[2] : "";

            var client = CreateClient(recipFName, recipLName, recipMName, recipPhone.Substring(recipPhone.Length - 10), recipCity, street, house, appartament, senderUuid);
            //File.AppendAllText(@"E:\temp\log.txt", $"client  - : {client.ToXml<AddressAndClient>()} \r");
            if (client == null)
            {
                return;
            }

            var receipt = new CreateReceipts()
            {
                culture = "uk-UA",
                flSave = "true",
                debugMode = "false",
                receiptsList = new List<ReceiptsList>
                {
                    new ReceiptsList
                    {
                        areasSendId = citySender,
                        warehouseSendId = warehousSender,
                        areasResiveId = recipCity,
                        warehouseResiveId = recipWareh,
                        deliveryScheme = deliScheme,
                        senderId = senderUuid,
                        receiverName = client.account.Name,
                        receiverPhone = client.account.PhoneNumber.Substring(client.account.PhoneNumber.Length - 10),
                        receiverType = false,
                        payerType = payerType,
                        paymentType = (payerType == 1) ? 0 : 1, // ЗМІНИТИ!!!!
                        dateSend = DateTime.Now,
                        currency = 100000000,
                        InsuranceValue = insurValue,
                        payerInsuranceId = senderUuid, //або client.account.AccountId
                        paymentTypeInsuranse = 1,      //або 0
                        deliveryContactName = client.account.Name,
                        deliveryContactPhone = client.account.PhoneNumber.Substring(client.account.PhoneNumber.Length - 10),
                        DeliveryComment = descriptio,
                        cashOnDeliveryType = 2,
                        CashOnDeliveryValuta = 100000000,
                        CashOnDeliveryValue = postPay,
                        CashOnDeliveryWarehouseId = warehousSender,
                        CashOnDeliveryPayerAccountId = client.account.AccountId,
                        CashOnDeliverySenderFullName = senderName,
                        CashOnDeliverySenderPhone = phoneNumbr.Substring(phoneNumbr.Length - 10),
                        category = cargoList
                    }
                }
            };
            //File.AppendAllText(@"E:\temp\log.txt", $"receipt - : {receipt.ToXml<CreateReceipts>()} \r \r");
            var shipments = Controller.PostCreateReceipts(receipt);
            if (shipments.Count > 0)
            {
                var shipment = shipments[0];
                result = shipment.ToXml<ReceiptResp>();
                //File.AppendAllText(@"E:\temp\log.txt", $"result - : {result} \r \r");

                using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand($"UPDATE [InetClient].[dbo].[DeliveryShipments] SET uuid = '{shipment.Id}', number = '{shipment.Number}' WHERE id = {id}", connection))
                        command.ExecuteNonQuery();
                }
            }
        }

        public static string GetPdfDocument(string number)
        {
            var fileNamePDF = Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

            try { if (File.Exists(fileNamePDF)) File.Delete(fileNamePDF); }
            catch { return null; }

            var response = SendGet($"v4/Public/GetPdfDocument?number={number}&type=0", out bool success, out string message);
            if (success)
            {
                var mess = JsonConvert.DeserializeObject<PdfFileResponse>(response);
                if (mess.status)
                {
                    byte[] buffer = Convert.FromBase64String(mess.file);
                    using (Stream outputStream = File.OpenWrite(fileNamePDF))
                    {
                        outputStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            return fileNamePDF;
        }

        public static void GetPdfDocumentXml(string publicKey, string secretKey, string number)
        {
            _apiKey = publicKey;
            _apiSecretKey = secretKey;
            string fileName = GetPdfDocument(number);

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

        private static void DoSQLCommand(string query)
        {
            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    //command.Parameters.Add("@param1", SqlDbType.NVarChar).Value = param[0];
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private static void ListToSQL<T>(List<T> data)
        {
            if (data == null || data.Count == 0)
                return;
            using (SqlConnection connection = new SqlConnection("Context Connection = true;"))
            {
                connection.Open();

                var query = new StringBuilder();
                var properties = typeof(T).GetProperties();
                query.Append("CREATE TABLE [TempTableKA](");

                foreach (var prop in typeof(T).GetProperties())
                {
                    var attrs = ((SQLTypeAttribute)prop.GetCustomAttributes(typeof(SQLTypeAttribute), false)[0]).Name;
                    query.Append($"{prop.Name} {attrs},");
                }
                query.Remove(query.Length - 1, 1);
                query.Append(") ");

                int count = (data.Count - 1) / 1000;
                for (int i = 0; i <= count; i++)
                {
                    query.Append("INSERT INTO [TempTableKA] VALUES");
                    for (int j = 1000 * i; (j < 1000 * i + 1000 && j < data.Count); j++)
                    {
                        var item = data[j];
                        query.Append("(");
                        foreach (var prop in properties)
                        {
                            var value = prop.GetValue(item, null);
                            if (value == null)
                                query.Append("NULL");
                            else
                                switch (Type.GetTypeCode(Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType))
                                {
                                    case TypeCode.String:
                                        query.Append("'");
                                        query.Append(((string)value).Replace('\'', '\"'));
                                        query.Append("'");
                                        break;
                                    case TypeCode.Int32:
                                        query.Append(value);
                                        break;
                                    case TypeCode.Int64:
                                        query.Append(value);
                                        break;
                                    case TypeCode.Boolean:
                                        query.Append((bool)value ? 1 : 0);
                                        break;
                                    case TypeCode.Single:
                                        query.Append(((float)value).ToString("G", new System.Globalization.CultureInfo("en-US")));
                                        break;
                                }
                            query.Append(",");
                        }
                        query.Remove(query.Length - 1, 1);
                        query.Append("),");
                    }
                    query.Remove(query.Length - 1, 1);
                    //File.WriteAllText(@"C:\temp\test.txt", query.ToString());
                    using (var command = new SqlCommand(query.ToString(), connection))
                        command.ExecuteNonQuery();

                    query.Clear();
                }

                connection.Close();
            }
        }
    }
}