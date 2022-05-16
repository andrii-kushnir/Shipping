using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
//using Newtonsoft.Json;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace UkrPostTest
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static int SendPost(string url, string authorizationBearer, string requestBody, out string message)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + authorizationBearer);
            request.Accept = "application/json";
            request.Method = "POST";
            request.ContentType = "application/json";
            var data = Encoding.UTF8.GetBytes(requestBody);
            request.ContentLength = data.Length;

            try
            {
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -2;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                message = response.StatusCode.ToString();
                return -3;
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
                message = ex.Message;
                return -4;
            }

            message = responseBody;
            response.Close();
            return 0;
        }

        public static int SendGet(string url, string authorizationBearer, out string message)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.PreAuthenticate = true;
            request.Headers.Add("Authorization", "Bearer " + authorizationBearer);
            request.Accept = "application/json";
            request.Method = "GET";

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -2;
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                message = response.StatusCode.ToString();
                return -3;
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
                message = ex.Message;
                return -4;
            }

            message = responseBody;
            response.Close();
            return 0;
        }

    }
}
