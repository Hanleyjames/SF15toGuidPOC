using System.Text;

namespace poc_62_64;

class Program
{
    static void Main(string[] args)
    {
        String salesforceId = "50130000000014C";
        Console.WriteLine("Salesforce Id: " + salesforceId);
        Guid guid = salesforceIdToGuid(salesforceId);
        Console.WriteLine("Guid: " + guid);
        String salesforceId2 = guidToSalesforceId(guid);
        Console.WriteLine("Salesforce Id: " + salesforceId2);
       
    }

    public static Guid salesforceIdToGuid(string salesforceId)
    {
        if(salesforceId.Length != 15)
        {
            throw new Exception("Salesforce Id must be 15 characters long");
        }
        salesforceId+="0";
        char[] chars = salesforceId.ToCharArray();
        byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(chars);
        return new Guid(bytes);
    }

    public static String guidToSalesforceId(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        char[] chars = Encoding.GetEncoding("UTF-8").GetChars(bytes);
        return new String(chars).Substring(0,15);
    }
    
}
