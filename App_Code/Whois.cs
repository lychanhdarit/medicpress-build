using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for Whois
/// </summary>
public class Whois
{
	public Whois()
	{
		
	}
    private const int Whois_Server_Default_PortNumber = 43;
    private const string Domain_Record_Type = "domain";
    private const string DotCom_Whois_Server = "whois.verisign-grs.com";

    /// <summary>
    /// Retrieves whois information
    /// </summary>
    /// <param name="domainName">The registrar or domain or name server whose whois information to be retrieved</param>
    /// <param name="recordType">The type of record i.e a domain, nameserver or a registrar</param>
    /// <returns></returns>
    public static string Lookup(string domainName)
    {
        using (TcpClient whoisClient = new TcpClient())
        {
            whoisClient.Connect(DotCom_Whois_Server, Whois_Server_Default_PortNumber);

            string domainQuery = Domain_Record_Type + " " + domainName + "\r\n";
            byte[] domainQueryBytes = Encoding.ASCII.GetBytes(domainQuery.ToCharArray());

            Stream whoisStream = whoisClient.GetStream();
            whoisStream.Write(domainQueryBytes, 0, domainQueryBytes.Length);

            StreamReader whoisStreamReader = new StreamReader(whoisClient.GetStream(), Encoding.ASCII);

            string streamOutputContent = "";
            List<string> whoisData = new List<string>();
            while (null != (streamOutputContent = whoisStreamReader.ReadLine()))
            {
                whoisData.Add(streamOutputContent);
            }

            whoisClient.Close();

            return String.Join(Environment.NewLine, whoisData);
        }
    }
    public static string GetWhoisInformation(string url)
    {
        StringBuilder stringBuilderResult = new StringBuilder();
        TcpClient tcpClinetWhois = new TcpClient(DotCom_Whois_Server, 43);
        NetworkStream networkStreamWhois = tcpClinetWhois.GetStream();
        BufferedStream bufferedStreamWhois = new BufferedStream(networkStreamWhois);
        StreamWriter streamWriter = new StreamWriter(bufferedStreamWhois);

        streamWriter.WriteLine(url);
        streamWriter.Flush();

        StreamReader streamReaderReceive = new StreamReader(bufferedStreamWhois);

        while (!streamReaderReceive.EndOfStream)
            stringBuilderResult.AppendLine(streamReaderReceive.ReadLine());

        return stringBuilderResult.ToString();
    } 
}