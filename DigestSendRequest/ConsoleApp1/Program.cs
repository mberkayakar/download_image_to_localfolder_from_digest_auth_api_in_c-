using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uri myUri = new Uri("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2");
            //WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;

            //NetworkCredential myNetworkCredential = new NetworkCredential("test", "test?123");

            //myHttpWebRequest.PreAuthenticate = true;
            //myHttpWebRequest.Credentials = myNetworkCredential;

            //WebResponse myWebResponse = myWebRequest.GetResponse();
            //Stream responseStream = myWebResponse.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(responseStream);

            //string pageContent = myStreamReader.ReadToEnd();

            //responseStream.Close();

            //myWebResponse.Close();

            //var model = pageContent;


            //byte[] bytes = Convert.FromBase64String(pageContent);
            //using (MemoryStream ms = new MemoryStream(bytes))
            //{

            //}

            ////Console.ReadLine();

            ////Byte[] b = System.IO.File.ReadAllBytes(pageContent);   // You can use your own method over here.         

            //Console.ReadLine();




            Uri myUri = new Uri("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2");
            WebRequest myWebRequest = HttpWebRequest.Create(myUri);
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)myWebRequest;

            NetworkCredential myNetworkCredential = new NetworkCredential("test", "test?123");

            myHttpWebRequest.PreAuthenticate = true;
            myHttpWebRequest.Credentials = myNetworkCredential;


            var webClient = new WebClient();
            var credentialCache = new CredentialCache();
            credentialCache.Add(new Uri("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2"), "Digest", new NetworkCredential("test", "test?123"));
            webClient.Credentials = credentialCache;
            var imgStream = new MemoryStream(webClient.DownloadData("http://212.125.30.226:60213/cgi-bin/snapshot.cgi?channel=2"));
            var Image = new System.Drawing.Bitmap(imgStream);



            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);




            string outputFileName = "resim.jpeg";
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    Image.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }







            var deneme = 123;
            //var image =  new System.Drawing.Bitmap(imgStream);

            //var webClient = new WebClient();
            //webClient.Credentials = new NetworkCredential("test", "test?123");
            //var imgStream = new MemoryStream(webClient.DownloadData(mySnapUrl));//Good to go!
            //picturebox0.Image = new System.Drawing.Bitmap(imgStream);

        }
    }
}
