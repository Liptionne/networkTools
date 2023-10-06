using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace networkScanner
{
    internal static class networkTools
    {
        public static void listAllInterfacesWithIPs()
        {
            // Getting host name 
            string host = Dns.GetHostName();

            // Getting ip address using host name 
            IPHostEntry ip = Dns.GetHostEntry(host);
            IPAddress[] listeAdresses = ip.AddressList;

            int indiceInterface = 0;
            int longueurListeAdresses = listeAdresses.Length;

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up)
                {
                    if((longueurListeAdresses / 2 + indiceInterface) >= longueurListeAdresses)
                    {
                        break;
                    }

                    Debug.WriteLine(netInterface.NetworkInterfaceType.ToString() + ";IPV6 = " + listeAdresses[indiceInterface] + " ;IPV4 = " + listeAdresses[longueurListeAdresses / 2 + indiceInterface]);
                    indiceInterface++;
                }
            }
        }

        public static string PingAdresse(string adresse)
        {
            Ping ping = new Ping();

            try
            {
                PingReply reply = ping.Send(adresse);
                Debug.WriteLine("Envoi d'un ping (ICMP) à l'adresse : " + adresse);
                if (reply.Status == IPStatus.Success)
                {
                    return $"Réponse reçue de {adresse}: Temps = {reply.RoundtripTime}ms";
                }
                else
                {
                    return $"Aucune réponse reçue de {adresse}";
                }
            }
            catch (PingException ex)
            {
                return $"Erreur de ping : {ex.Message}";
            }
        }




    }
}
