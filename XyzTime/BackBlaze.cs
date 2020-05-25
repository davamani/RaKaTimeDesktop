using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Collections;
using System.Security.Cryptography;


using Newtonsoft.Json.Linq;
using Microsoft.Office.Interop.Word;

namespace XyzTime
{
    public class BackBlaze
    {
        string str_AppUrl = "";
       // string str_DownloadUrl = "";
        string str_AuthToken = "";

        string str_UploadUrl = "";
        string str_UploadUrlAuthToken = "";

        System.Data.DataTable dt_Account;

        public BackBlaze()
        {
            this.dt_Account = (System.Data.DataTable)Properties.Settings.Default.StorageAccountTable;
        }
        public async void GenerateAuthorizationToken()
        {
            String applicationKeyId = this.dt_Account.Rows[0]["AccountMasterKey"].ToString(); // "c25794983d48"; //B2 Cloud Storage Application Key ID
            String applicationKey = this.dt_Account.Rows[0]["AccountApplicationKey"].ToString(); //"002a3831d402222439f9a7bc76db3f5c2e87824509"; //B2 Cloud Storage Application Key
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://api.backblazeb2.com/b2api/v2/b2_authorize_account");
            String credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(applicationKeyId + ":" + applicationKey));
            webRequest.Headers.Add("Authorization", "Basic " + credentials);
            webRequest.ContentType = "application/json; charset=utf-8";
            WebResponse response = await webRequest.GetResponseAsync();
            String json = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();
            JObject ObjJson = JObject.Parse(json);
            this.str_AppUrl = ObjJson["apiUrl"].ToString();
            this.str_AuthToken = ObjJson["authorizationToken"].ToString();
            Properties.Settings.Default.BackAppUrl = this.str_AppUrl;
            Properties.Settings.Default.BackAppToken = this.str_AuthToken;
            // this.str_DownloadUrl = ObjJson["downloadUrl"].ToString();

            this.RetrieveUploadUrl();

        }

        public async void RetrieveUploadUrl()
        {
            // this.GenerateAuthorizationToken();  //this will get api url and authorization token

            String apiUrl = Properties.Settings.Default.BackAppUrl; //Provided by b2_authorize_account 
            String accountAuthorizationToken = Properties.Settings.Default.BackAppToken; //Provided by b2_authorize_account
            String bucketId = this.dt_Account.Rows[0]["AccountBucketId"].ToString(); //"2cc2e577d994c9f8731d0418"; //The unique bucket ID
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(apiUrl + "/b2api/v2/b2_get_upload_url");
            string body = "{\"bucketId\":\"" + bucketId + "\"}";
            var data = Encoding.UTF8.GetBytes(body);
            webRequest.Method = "POST";
            webRequest.Headers.Add("Authorization", accountAuthorizationToken);
            webRequest.ContentType = "application/json; charset=utf-8";
            webRequest.ContentLength = data.Length;
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            WebResponse response = await webRequest.GetResponseAsync();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            response.Close();

            JObject ObjJson = JObject.Parse(responseString);
            this.str_UploadUrl = ObjJson["uploadUrl"].ToString();
            this.str_UploadUrlAuthToken = ObjJson["authorizationToken"].ToString();
            Properties.Settings.Default.BackUploadUrl = this.str_UploadUrl;
            Properties.Settings.Default.BackUploadToken = this.str_UploadUrlAuthToken;
            Properties.Settings.Default.BackUploadTokenGeneratedDate = DateTime.Now;

        }

        public async void UploadFileToCloud(string str_LocalFileName, string str_LocalFilePath)
        {
            TimeSpan diff = DateTime.Now - Properties.Settings.Default.BackUploadTokenGeneratedDate;
            double hours = diff.TotalHours;
            if (hours > 23)
                this.RetrieveUploadUrl();   //upload auth token valid for 24 hours only.

            int int_Attempt = 0;
            //try 3 times for upload 
            try
            {

                String uploadAuthorizationToken = Properties.Settings.Default.BackUploadToken; //Provided by b2_get_upload_url
                String contentType = "image/jpeg"; //Type of file i.e. image/jpeg, audio/mpeg...
                String filePath = str_LocalFilePath; //File path of desired upload 
                String fileName = str_LocalFileName; //Desired name for the file
                String sha1Str = "SHA_1"; //Sha1 verification for the file

                // Read the file into memory and take a sha1 of the data.
                FileInfo fileInfo = new FileInfo(filePath);
                byte[] bytes = File.ReadAllBytes(filePath);
                SHA1 sha1 = SHA1.Create();
                // NOTE: Loss of precision. You may need to change this code if the file size is larger than 32-bits.
                byte[] hashData = sha1.ComputeHash(bytes, 0, (int)fileInfo.Length);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashData)
                {
                    sb.Append(b.ToString("x2"));
                }
                sha1Str = sb.ToString();

                // Send over the wire
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Properties.Settings.Default.BackUploadUrl);
                webRequest.Method = "POST";
                webRequest.Headers.Add("Authorization", uploadAuthorizationToken);
                webRequest.Headers.Add("X-Bz-File-Name", fileName);
                webRequest.Headers.Add("X-Bz-Content-Sha1", sha1Str);
                webRequest.ContentType = contentType;
                using (var stream = webRequest.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                }
                WebResponse response = await webRequest.GetResponseAsync();
                //(HttpWebResponse)webRequest.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                response.Close();

                Console.WriteLine("uploaded: " + str_LocalFilePath);
                File.Delete(str_LocalFilePath);
                Console.WriteLine("file deleted: " + str_LocalFileName);
                try
                {
                    new SqlLiteDb().InsertCaptureScreen(str_LocalFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("InsertCaptureScreen failed: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                int_Attempt++;
                if (int_Attempt <= 3)
                {
                    //this.RetrieveUploadUrl();   //get the upload auth token again
                    this.UploadFileToCloud(str_LocalFileName, str_LocalFilePath);
                }
            }
        }

        //public void UploadFileToCloud(string str_LocalFileName, string str_LocalFilePath)
        //{
        //    this.RetrieveUploadUrl();

        //    String uploadAuthorizationToken = this.str_UploadUrlAuthToken; //Provided by b2_get_upload_url
        //    String contentType = "image/jpeg"; //Type of file i.e. image/jpeg, audio/mpeg...
        //    String filePath = str_LocalFilePath; //File path of desired upload 
        //    String fileName = str_LocalFileName; //Desired name for the file
        //    String sha1Str = "SHA_1"; //Sha1 verification for the file

        //    // Read the file into memory and take a sha1 of the data.
        //    FileInfo fileInfo = new FileInfo(filePath);
        //    byte[] bytes = File.ReadAllBytes(filePath);
        //    SHA1 sha1 = SHA1.Create();
        //    // NOTE: Loss of precision. You may need to change this code if the file size is larger than 32-bits.
        //    byte[] hashData = sha1.ComputeHash(bytes, 0, (int)fileInfo.Length);
        //    StringBuilder sb = new StringBuilder();
        //    foreach (byte b in hashData)
        //    {
        //        sb.Append(b.ToString("x2"));
        //    }
        //    sha1Str = sb.ToString();

        //    // Send over the wire
        //    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(this.str_UploadUrl);
        //    webRequest.Method = "POST";
        //    webRequest.Headers.Add("Authorization", uploadAuthorizationToken);
        //    webRequest.Headers.Add("X-Bz-File-Name", fileName);
        //    webRequest.Headers.Add("X-Bz-Content-Sha1", sha1Str);
        //    webRequest.ContentType = contentType;
        //    using (var stream = webRequest.GetRequestStream())
        //    {
        //        stream.Write(bytes, 0, bytes.Length);
        //        stream.Close();
        //    }
        //    WebResponse response = (HttpWebResponse)webRequest.GetResponse();
        //    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        //    response.Close();

        //    Console.WriteLine("uploaded: " + str_LocalFilePath);
        //}
    }
}
