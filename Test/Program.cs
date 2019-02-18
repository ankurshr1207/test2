using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Globalization;
using System.Xml.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string group = GetAccountType("O");
            //System.Console.WriteLine(group);
            //System.Console.ReadLine();
            //DateTime dt = System.DateTime.Today.AddDays(-1);
            // Find all pdf documents in input folder.
            //DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Scan");
            //FileInfo[] allPDFs = directoryInfo.GetFiles("*.pdf");

            //// Create a document for the merged result.
            //XDocument mergedDocument = new Document();

            //// Keep a list of input streams to close when done.
            //List<FileStream> streams = new List<FileStream>();
            //foreach (FileInfo fileInfo in allPDFs)
            //{
            //    // Open input stream and add to list of streams.
            //    FileStream stream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read);
            //    streams.Add(stream);

            //    // Open input document.
            //    Document document = new Document(stream);

            //    // Append all pages to target document.
            //    // The target document holds references to data in the input stream.
            //    // For efficiency it does not copy this data so the input streams
            //    // should not be closed before the merged document is saved.
            //    mergedDocument.Pages.AddRange(document.Pages.CloneToArray());
            //}

            //// Save merged document.
            //using (FileStream output = new FileStream(@"..\..\output.pdf", FileMode.Create, FileAccess.Write))
            //{
            //    mergedDocument.Write(output);
            //}

            //// Close all input streams.
            //streams.ForEach(stream => stream.Close());
            //string aa = "1.0000000000000000-ea";
            //string startDate = JobRunStatus("2018-05-28 00:00:00", "RET");
            //string endDate = SetEndDateTime("2018-05-24 00:00:00");
            //string[] array = aa.Split('-');
            //string packsize = array[0];
            //string UOM = array[1];
            //string newGuid = Guid.NewGuid().ToString();
            //var downloadLocation = "https://pgwd365testdf8a975dd9db2.blob.core.windows.net/temporary-file/%7BB9C9DBD4-9558-4C5F-BAAE-BDF6EDC20E6A%7D/RDMS%20Export_E6388BC2-CE98-48E8-B10E-529918C9D8FA_DMFPackage.zip?sv=2014-02-14&sr=b&sig=3NxRn0Jd7NTZTEQNxaZVBcbf3HfUMv5jSW8HXRfbWfs%3D&st=2018-02-26T21%3A18%3A53Z&se=2018-02-26T22%3A23%3A53Z&sp=r";
            //string filePath = @"C:\Data\PGG\Robust\Profectus\";

            // 4. Download the file from Url to a local folder
            //Console.WriteLine("Downloading the file ...");
            //var blob = new CloudBlockBlob(new Uri(downloadLocation));
            //blob.DownloadToFile(Path.Combine(filePath, Guid.NewGuid().ToString() + ".zip"), System.IO.FileMode.Create);
            //Console.WriteLine("Downloading the file ...Complete");

            //string decodedLocation = HttpUtility.UrlEncode(downloadLocation);
            // int downloadLocLength = downloadLocation.Length;
            // string url1 = downloadLocation.Substring(70, 42);
            //string url2 = downloadLocation.Substring(113, (downloadLocLength - 113));
            //System.Console.WriteLine(decodedLocation);
            // System.Console.WriteLine(url2);
            //DateTime strDate = System.DateTime.Now.AddMinutes(2);
            //DateTime currentTime = System.DateTime.Now;
            //int exitprocess = DateTime.Compare(strDate, currentTime);
            //string accountnumber = FormatAccountNumber("15104-1234");

            //string companyID = ConvertUTCDatetoLocal("2018-03-01 20:29:39");
            //System.Console.WriteLine(companyID);
            //string errorMsg = "There was a failure executing the response(receive) pipeline:  Reason: No Disassemble stage components can recognize the data.  ";
            //if(errorMsg.Contains("No Disassemble stage components can recognize the data"))
            //{
            //    System.Console.WriteLine(errorMsg);
            //}
            //string fileName = "Manifest.xml";
            //if (!(fileName.Contains("PackageHeader") || fileName.Contains("Manifest")))
            //{
            //    System.Console.WriteLine(fileName);
            //}
            //string beh = @"<behavior name='EndpointBehavior'><PGGW.BizTalk.Common.Components.AzureADBehaviour username='svc-dev-ax-integration@pggwrightson.co.nz' password='z5q9Wrs0!0yfAM19' clientId='bb83fe8c-5c81-438d-b39d-97b1e4354004' resourceId='https://pgw-d365-devdevaos.sandbox.ax.dynamics.com' /></behavior>";
            //string username = "svc-dev-ax-integration@pggwrightson.co.nz";
            //string password = "z5q9Wrs0!0yfAM19";
            //string clintID = "asdsd";
            //string resourceID = "sdfggg";
            //string EndB = System.String.Format("<behavior name='EndpointBehavior'><PGGW.BizTalk.Common.Components.AzureADBehaviour username='{0}' password='{1}' clientId='{2}' resourceId='{3}' /></behavior>", username,password,clintID,resourceID);
            //bool active = IsAXCustomer("E", "050");
            //string guids = System.Guid.NewGuid().ToString();
            ////string BlockECL = GetCustomerBlockECL("C", "AvR", "N", "Y", "Y");
            //System.Console.WriteLine(guids);

            string SS = "2018-04-26 16:00:00";
            string final = JDEHeaderSaleDate(SS);

            string UTCFinal = ConvertUTCDatetoLocal(SS);

            string formatedDate = FormatDate(SS);
            //SS = SS.Replace(".", "");
            //DateTime dt = DateTime.ParseExact(SS, "dd/MM/yyyy h:mm:ss tt", new CultureInfo("en-US"), System.Globalization.DateTimeStyles.None);
            //string final = dt.ToString("yyyy-MM-dd");
            System.Console.WriteLine(final);
            System.Console.ReadLine();
        }

        public static string SetStartDateTime(string strCanonStartDateTime)
        {
            string[] strStartDate = strCanonStartDateTime.Split(' ');
            DateTime dt = System.DateTime.Now;

            if (System.String.IsNullOrWhiteSpace(strStartDate[0].Trim()))
            {
                strStartDate[0] = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }

            DateTime.TryParse(strStartDate[0], out dt);
            return dt.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public static string JobRunStatus(string startDate, string legalEntity)
        {
            DateTime dt = System.DateTime.Now;
            DateTime.TryParse(startDate, new CultureInfo("en-NZ"), System.Globalization.DateTimeStyles.AdjustToUniversal, out dt);

            DateTime dtToday = System.DateTime.Today;

            string status = legalEntity;
            if (dtToday.CompareTo(dt) < 0)
            {
                status = "Completed";
            }
             return status;
        }

        public static string SetEndDateTime(string strCanonEndDateTime)
        {
            string[] strEndDate = strCanonEndDateTime.Split(' ');
            DateTime dt = System.DateTime.Now;

            if (System.String.IsNullOrWhiteSpace(strEndDate[0].Trim()))
            {
                strEndDate[0] = System.DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }

            DateTime.TryParse(strEndDate[0], out dt);
            return dt.AddMilliseconds(-1).ToString("yyyy-MM-ddTHH:mm:ss");
        }

        public static string FormatAccountNumber(string accountNumber)
        {
            string[] account = accountNumber.Split('-');
            string strObjectSubsidary = account[1];
            if(strObjectSubsidary.Length > 5)
            {
                string strObject = strObjectSubsidary.Substring(0, 5);
                string strSubsidary = strObjectSubsidary.Substring(5);
                return string.Concat(account[0], ".", strObject, ".", strSubsidary);
            }
            else
            {
                return string.Concat(account[0], ".", strObjectSubsidary);
            }

        }

        public static string GetCompanyId(string businessUnit)
        {
            string compID = string.Empty;
            List<string> BUList = new List<string>(new string[] { "22202", "22204", "22205" });
            if (businessUnit.StartsWith("15") || BUList.Contains(businessUnit))
            {
                compID = "1050";              
            }
            else if (businessUnit.StartsWith("16"))
            {               
                compID = "1060";
            }
            else
            {
                compID = "1";
            }
            return compID;

        }



        public static bool IsAXCustomer(string accountTypeCode, string subSystemExportFlag)
        {
            bool isValid = false;
            List<string> customersGroupList = new List<string>(new string[] { "C", "E", "IC", "IJD" });
            List<string> subSystemExportFlagList = new List<string>(new string[] { "010", "011", "020", "021", "022", "023", "024", "025", "026", "027", "028", "029", "030", "031", "032", "033", "034" });

            if ((customersGroupList.Contains(accountTypeCode) || accountTypeCode.StartsWith("Z")) && subSystemExportFlagList.Contains(subSystemExportFlag))
            {
                isValid = true;
            }

            return isValid;

        }
        public static string GetCustomerBlockECL(string accountTypeCode, string subSystemExportFlag, string CustomerInactiveFlag, string CreditStopFlag, string invoiceHoldFlag)
        {
            string blockECL = string.Empty;
            List<string> customersGroupList = new List<string>(new string[] { "C", "E", "IC", "IJD" });

            if (customersGroupList.Contains(accountTypeCode))
            {
                if (subSystemExportFlag.Contains("AvR") && CustomerInactiveFlag == "N" && CreditStopFlag == "Y" && invoiceHoldFlag == "Y")
                {
                    blockECL = "Invoice";

                }
                else if(subSystemExportFlag.Contains("AvR") && CustomerInactiveFlag == "N" && CreditStopFlag == "N" && invoiceHoldFlag == "N")
                {
                    blockECL = "No";
                }
                else
                {
                    blockECL = "All";
                }
            }
            else
            {
                blockECL = "All";
            }

            return blockECL;

        }

      
        //public static string GetAccountType(string accountTypeCode)
        //    {
        //        string typeGroup = string.Empty;
        //        List<string> customersList = new List<string>(new string[] { "C", "IC", "ZC" });
        //        List<string> suppliersList = new List<string>(new string[] { "V", "VTR", "VFX", "ZV" });

        //        if(customersList.Contains(accountTypeCode))
        //        {
        //            typeGroup = "C";
        //        }
        //        else if(suppliersList.Contains(accountTypeCode))
        //        {
        //            typeGroup = "V";
        //        }

        //        return typeGroup;

        //    }

        public static string JDEHeaderSaleDate(string strCanonicalDate)
        {
            DateTime tDate;
            bool result = DateTime.TryParse(strCanonicalDate, out tDate);
            return tDate.ToString("dd/MM/yyyy");
        }

        public static string ConvertUTCDatetoLocal(string uTCDate)
        {
            DateTime convertedDate = DateTime.SpecifyKind(DateTime.Parse(uTCDate), DateTimeKind.Utc);
            convertedDate = convertedDate.ToLocalTime();
            return convertedDate.ToString("dd/MM/yyyy");

        }

        public static string FormatDate(string strDate)
        {
            //string[] strSplitDate = strDate.Split(' ');
            DateTime dt = System.DateTime.Now;

            DateTime.TryParse(strDate, new CultureInfo("en-NZ"), System.Globalization.DateTimeStyles.AdjustToUniversal, out dt);

            if ((dt.ToString("yyyy-MM-dd") == "0001-01-01") || (dt.ToString("yyyy-MM-dd") == "1753-01-01"))
            {
                return System.String.Empty;
            }
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
