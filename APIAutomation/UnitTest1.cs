using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace APIAutomation
{
    [TestClass]
    
    public class UnitTest1       
    {
        string message;
        private string myToken;
        
        [TestInitialize]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void GetToken()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body5;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.getTokenUrl);
            httpWebRequest.Headers.Add("Authorization", "Basic " + reqObject.basicAut);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
               // streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            //Assert.IsTrue(apiResponse.sparePartNumber.Equals("870794-001") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));

            Console.WriteLine("access_token : {0}", apiResponse.access_token);
            myToken = apiResponse.access_token;
        }
        // ##############  DEV  ####################
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Validation Failed.")]
        public void TestMethod1()
        {
            string html;
            
            var reqObject = new UsersRequestObject();

            string request = reqObject.validationfailed;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.url);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();      

            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nWeb Exception occurred : {0}", e.Message);
                message = e.Message;
            }
            Assert.IsTrue(message.Equals("The remote server returned an error: (400) Bad Request."));
            Console.WriteLine("\r\nWeb Exception occurred : {0}", message);

        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Not Found")]
        public void TestMethod2()
        {
            string html;
            
            var reqObject = new UsersRequestObject();

            string request = reqObject.validationnotfound;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_trackingId_Not Found");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
                Console.WriteLine("Status : {0}", apiResponse.sparePartIdentificationStatus);
                Console.WriteLine("Reason : {0}", apiResponse.sparePartIdentificationReason);
                Console.WriteLine("sparePartNumber : {0}", apiResponse.sparePartNumber);
                Console.WriteLine("csrCode: {0}", apiResponse.csrCode);


            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nWeb Exception occurred : {0}", e.Message);
                message = e.Message;
                

            }
            Assert.IsTrue(message.Equals("The remote server returned an error: (404) Not Found."));
            Console.WriteLine("\r\nWeb Exception occurred : {0}", message);
            
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod3()
        {
            string html;
     
            var reqObject = new UsersRequestObject();
            
            string request = reqObject.body;
       
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
           
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("653971-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HD 900GB 6G SAS 10K 2.5 DP EN SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);


        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod4()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body1;
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("759548-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 600GB 12G 15K 2.5 SAS ENT SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2106") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Spare part has been historically identified.")]
        public void TestMethod5()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body2;
            
            string url = "https://api-int-itg.support.hpecorp.net/apigw/dcm/spare/v1/get-spare";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_trackingId_historically identified");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("881507-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 2.4TB 12G 10K SFF SAS SC DS") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("201") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been historically identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod6()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body5;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_trackingId_Found Regularly");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("870794-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 600GB 12G 15K SFF SAS ENT SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
            Console.WriteLine("trackingId: {0}", apiResponse.trackingId);
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod7()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body6;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.devurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_Found Regularly");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";
            


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("872738-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 1.8TB 12G 10K SFF 512e DS SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));

            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
        }

        // ##############  PRO  ####################

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Validation Failed.")]
        public void TestMethod14()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.validationfailed;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_Validation Failed.");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }


            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nWeb Exception occurred : {0}", e.Message);
                message = e.Message;
            }
            Assert.IsTrue(message.Equals("The remote server returned an error: (400) Bad Request."));
            Console.WriteLine("\r\nWeb Exception occurred : {0}", message);

        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Not Found")]
        public void TestMethod13()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.validationnotfound;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_Not Found");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
                Console.WriteLine("Status : {0}", apiResponse.sparePartIdentificationStatus);
                Console.WriteLine("Reason : {0}", apiResponse.sparePartIdentificationReason);
                Console.WriteLine("sparePartNumber : {0}", apiResponse.sparePartNumber);
                Console.WriteLine("csrCode: {0}", apiResponse.csrCode);


            }
            catch (Exception e)
            {
                Console.WriteLine("\r\nWeb Exception occurred : {0}", e.Message);
                message = e.Message;


            }
            Assert.IsTrue(message.Equals("The remote server returned an error: (404) Not Found."));
            Console.WriteLine("\r\nWeb Exception occurred : {0}", message);

        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod12()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);

            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_Found Regularly");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("653971-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HD 900GB 6G SAS 10K 2.5 DP EN SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
            
       
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod11()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body1;

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("759548-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 600GB 12G 15K 2.5 SAS ENT SC") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.rohsCode.Equals("COMPLY_2106") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
        }

        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Spare part has been historically identified.")]
        public void TestMethod10()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body2;

            string url = "https://api-int-itg.support.hpecorp.net/apigw/dcm/spare/v1/get-spare";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_tracking");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("881507-001") && apiResponse.sparePartDescription.Equals("SPS-DRV HDD 2.4TB 12G 10K SFF SAS SC DS") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("201") && apiResponse.rohsCode.Equals("COMPLY_2306") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been historically identified."));
            Console.WriteLine("Status: {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("sparePartIdentificationReason: {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber: {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("roshCode: {0}", apiResponse.rohsCode);
            Console.WriteLine("sparePartDescription: {0}", apiResponse.sparePartDescription);
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod9()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body5;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan_trackingId");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("870794-001") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));

            Console.WriteLine("Status : {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("Reason : {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber : {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
            Console.WriteLine("trackingId: {0}", apiResponse.trackingId);
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Spare Parts Found Regularly")]
        public void TestMethod8()
        {
            string html;

            var reqObject = new UsersRequestObject();

            string request = reqObject.body6;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.itgurl);
            httpWebRequest.Headers.Add("Authorization", "Bearer " + myToken);
            httpWebRequest.Headers.Add("trackingId", "dragan");
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json";



            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(request);
            }
            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.sparePartNumber.Equals("872738-001") && apiResponse.csrCode.Equals("A") && apiResponse.sparePartIdentificationStatus.Equals("200") && apiResponse.sparePartIdentificationReason.Equals("Spare part has been identified."));
            Console.WriteLine("Status : {0}", apiResponse.sparePartIdentificationStatus);
            Console.WriteLine("Reason : {0}", apiResponse.sparePartIdentificationReason);
            Console.WriteLine("sparePartNumber : {0}", apiResponse.sparePartNumber);
            Console.WriteLine("csrCode: {0}", apiResponse.csrCode);
        }
        [TestMethod]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Description("Test Health")]
        public void TestMethod15()
        {
            string html;

            var reqObject = new UsersRequestObject();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(reqObject.health);
        
            httpWebRequest.Method = "GET";
            httpWebRequest.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var apiResponse = JsonConvert.DeserializeObject<UsersResponseObject>(html);
            Assert.IsTrue(apiResponse.status.Equals("UP"));
            Console.WriteLine("Status : {0}", apiResponse.status);
            
        }

    }

    public class UsersRequestObject
    {
        //public string name { get; set; }
        //public string job { get; set; }
        public string commodity;
        public string serialNumber;
        public string productNumber;
        public string sparePartIdentificationFilter;
        public string partSupplierSerialNumber;
        public string getTokenUrl = "https://curiosity-itg-int-h4.itcs.hpecorp.net/uaa/oauth/token?grant_type=client_credentials&token_format=jwt";
        public string basicAut = "ZGNtX3BhcnRvcmRlcl9zZXJ2aWNlc19jbGllbnQ6RFNQaE5RNjdEdVZNaWxzZDNsR3lTS0tRY2U0Wm1s";
        //public string token = "eyJhbGciOiJSUzI1NiIsImprdSI6Imh0dHBzOi8vYXBpLWd3LWV4dC1kZXYuc3VwcG9ydC5ocGUuY29tL2FwaWd3ZXh0L3VhYS90b2tlbl9rZXlzIiwia2lkIjoibGVnYWN5LXRva2VuLWtleSIsInR5cCI6IkpXVCJ9.eyJqdGkiOiI2ZDllZDAyMzRhYjM0YTI5OGRhMDc5ODZmMGQ3OWViOSIsInN1YiI6ImRjbV9wYXJ0b3JkZXJfc2VydmljZXNfY2xpZW50IiwiYXV0aG9yaXRpZXMiOlsiZGNtLnBhcnRzLndyaXRlIiwiZGNtLnBhcnRzLnJlYWQiLCJkY20uc3BhcmUucmVhZCJdLCJzY29wZSI6WyJkY20ucGFydHMud3JpdGUiLCJkY20ucGFydHMucmVhZCIsImRjbS5zcGFyZS5yZWFkIl0sImNsaWVudF9pZCI6ImRjbV9wYXJ0b3JkZXJfc2VydmljZXNfY2xpZW50IiwiY2lkIjoiZGNtX3BhcnRvcmRlcl9zZXJ2aWNlc19jbGllbnQiLCJncmFudF90eXBlIjoiY2xpZW50X2NyZWRlbnRpYWxzIiwicmV2X3NpZyI6IjVmNTMyZjU0IiwiaWF0IjoxNjcwMzYyNzM1LCJleHAiOjE2NzAzNjYzMzUsImlzcyI6Imh0dHBzOi8vYXBpLWd3LWV4dC1kZXYuc3VwcG9ydC5ocGUuY29tL2FwaWd3ZXh0L3VhYS9vYXV0aC90b2tlbiIsImF1ZCI6WyJkY20uc3BhcmUiLCJkY21fcGFydG9yZGVyX3NlcnZpY2VzX2NsaWVudCIsImRjbS5wYXJ0cyJdfQ.ItUGHOK3_Zc8DiA5RfG6_GkVPwydA00OqLMQoVLHi0LhxA0sATP-73CzK56xtogyHGU6pkAifexN6wTGaL86IjJP6w0_mVV3Msd0z6GYxp80JLwsp0LiwX2S8OGwRFT1DQ0T2lBl2t4WmEKLxD5kOcCia0pBh8OzcxVCj0mY9_J20K7MUc38CvLX-IlBypsabf5UU8Ofxk5ir-3uZFWsbwlcAxooNwBYOtDOyxzCofRWlaJmhVSsFGK8dKY0e9RBIl4MVQPu2XtfH6ODgQgRCkhp5dgdIl0-fIqcdvGxtPeBe8PJNUw-fCmC34u-c_C_ZJJVyVRxXUMDbGed-aquKg";
        public string body = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ3447HVL7\",\"productNumber\":\"755258-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"KXJ2U5YF\"}}";
        public string body1 = "{\"commodity\":\"HDD\",\"serialNumber\":\"USE443D14K\",\"productNumber\":\"727021-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"0XV17V4H\"}}";
        public string body2 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ81609K7\",\"productNumber\":\"824171-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"11J0A2APFF1F\"}}";
        public string body3 = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ29150PX5\",\"productNumber\":\"868703-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"38W0A0BMFA3F\"}}";
        public string body4 = "{\"commodity\":\"HDD\",\"serialNumber\":\"USE843H88K\",\"productNumber\":\"447707-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"39B0A0JAFA1F\"}}";
        public string body5 = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ29150PX5\",\"productNumber\":\"868703-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"39B0A0JAFA1F\"}}";
        public string body6 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ1510RTM\",\"productNumber\":\"868704-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"8150A02ZFF3F\"}}";
        public string body7 = "{\"commodity\":\"HDD\",\"serialNumber\":\"2M292804D0\",\"productNumber\":\"869119-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"4940A0DGFA3F\"}}";
        public string body8 = "{\"commodity\":\"HDD\",\"serialNumber\":\"2M2725003B\",\"productNumber\":\"P19766-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"8150A02ZFF3F\"}}";
        public string body9 = "{\"commodity\":\"HDD\",\"serialNumber\":\"2M28330038\",\"productNumber\":\"819786-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"57L0A0LWFXFD\"}}";
        public string body10 = "{\"commodity\":\"HDD\",\"serialNumber\":\"SGH242E3KD\",\"productNumber\":\"653200-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"58J0A0BCFA1F\"}}";
        public string body11 = "{\"commodity\":\"HDD\",\"serialNumber\":\"USE421YWD5\",\"productNumber\":\"653200-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"6XN1TSJ3\"}}";
        public string body12 = "{\"commodity\":\"HDD\",\"serialNumber\":\"USE519PH13\",\"productNumber\":\"641016-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"6XN27A2P\"}}";
        public string body13 = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ20340JQN\",\"productNumber\":\"P15535-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"6XN7ZCMW\"}}";
        public string body14 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ1510SLP\",\"productNumber\":\"P19766-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"70E0A1RKFF1F\"}}";
        public string body15 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ1510RTM\",\"productNumber\":\"P19766-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"8150A02ZFF3F\"}}";
        public string body16 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ81304KQ\",\"productNumber\":\"719061-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"9170A0KUFF2F\"}}";
        public string body17 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ64908QP\",\"productNumber\":\"719064-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"K7GK62AR\"}}";
        public string body18 = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZJ74006JV\",\"productNumber\":\"767032-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"S7K15Q59\"}}";
        public string body19 = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ20220B51\",\"productNumber\":\"868704-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"W0M0HK7R\"}}";
        public string body20 = "{\"commodity\":\"HDD\",\"serialNumber\":\"MXQ1231510\",\"productNumber\":\"P19766-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"W462LPR7\"}}";
        public string validationnotfound = "{\"commodity\":\"HDD\",\"serialNumber\":\"CZ3447HVL7aa\",\"productNumber\":\"755258-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"KXJ2U5YF\"}}";
        public string validationfailed= "{\"commodity\":\"sDD\",\"serialNumber\":\"CZ3447HVL7\",\"productNumber\":\"755258-B21\",\"sparePartIdentificationFilter\":{\"partSupplierSerialNumber\":\"KXJ2U5YF\"}}";
        public string helthbody = "";
        public string url = "https://api-int-dev.support.hpecorp.net/apigw/dcm/spare/v1/get-spare";
        public string devurl = "https://api-int-dev.support.hpecorp.net/apigw/dcm/spare/v1/get-spare";
        public string itgurl = "https://api-int-itg.support.hpecorp.net/apigw/dcm/spare/v1/get-spare";
        public string health = "https://api-int.support.hpecorp.net/apigw/dcm/spare/spring-management/health";
    }
   

    public class UsersResponseObject
    {
        
        public string sparePartNumber { get; set; }
        public string sparePartDescription { get; set; }
        public string csrCode { get; set; }
        public string rohsCode { get; set; }
        
        public string trackingId { get; set; }
        public string sparePartIdentificationStatus { get; set; }
        public string sparePartIdentificationReason { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        //public string status { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }



    }


}
