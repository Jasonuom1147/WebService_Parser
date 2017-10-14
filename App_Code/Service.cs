using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
//add parse libs
using System.Net;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod]                            //leather   lining      collar   button          
    public int Calculatepricecustomproduct(int cost1,int cost2,int cost3,int cost4, int length, int sleeve, int shoulder)
    {
        double value = Convert.ToDouble(cost1); 
        //parsing data  
        WebClient wc = new WebClient();
        string htmlString = wc.DownloadString("http://sentra.com.gr/index.php?option=com_content&view=article&id=3291:rekor-times-oloklirothike-dimoprasia-kopenhagen-fur-dekembrios-2012&catid=75:auction&Itemid=141");

        if (cost1 == 210) //check if the leather is chinchila
        {
            //chinchila current auction
            string chinchilaleather = "";
            Match mChinchila = Regex.Match(htmlString, @"<p>Chinchilla(.*?)<p>", RegexOptions.Singleline);
            if (mChinchila.Success)
            {
                chinchilaleather = mChinchila.Groups[1].Value;
                Console.WriteLine(chinchilaleather);
            }
            string prosimo1 = Regex.Replace(chinchilaleather, "[^+--.]", "");
            double auction = Convert.ToDouble(Regex.Replace(chinchilaleather, "[^0-9.]", ""));
            if (prosimo1 == "+")
            {
                value = value + value * (auction / 100);
            }
            else
            {
                value = value - value * (auction / 100);
            }
            
        }
        //end of chinchila current auction
        else if (cost2 == 120) //check if leather is vison
        {
            //parse mink 
            string minkleather = "";
            Match mMink = Regex.Match(htmlString, @"<p>White M(.*?)<p>", RegexOptions.Singleline);
            if (mMink.Success)
            {
                minkleather = mMink.Groups[1].Value;
                Console.WriteLine(minkleather);
            }
            string prosimo = Regex.Replace(minkleather, "[^+--.]", "");
            double auction = Convert.ToDouble(Regex.Replace(minkleather, "[^0-9.]", ""));
            if (prosimo == "+")
            {
                value = value + value * (auction / 100);
            }
            else
            {
                value = value - value * (auction / 100);
            }
            //end of parsing data
        }
        else if (cost1 == 90) //check if leather is fox
        {
            //parse fox 
            string foxleather = "";
            Match mfox = Regex.Match(htmlString, @"<p>White F(.*?)<p>", RegexOptions.Singleline);
            if (mfox.Success)
            {
                foxleather = mfox.Groups[1].Value;
            }
            string prosimo = Regex.Replace(foxleather, "[^+--.]", "");
            double auction = Convert.ToDouble(Regex.Replace(foxleather, "[^0-9.].", ""));
            if (prosimo == "+")
            {
                value = value + value * (auction / 100);
            }
            else
            {
                value = value - value * (auction / 100);
            }
            //end of parse fox
        }
        else if (cost1 == 60) //check if the leather is beaver
        {
            //parse beaver
            string beaverleather = "";
            Match mbeaver = Regex.Match(htmlString, @"<p>Brown M(.*?)<p>", RegexOptions.Singleline);
            if (mbeaver.Success)
            {
                beaverleather = mbeaver.Groups[1].Value;
            }
            string prosimo = Regex.Replace(beaverleather, "[^+--.]", "");
            double auction = Convert.ToDouble(Regex.Replace(beaverleather, "[^0-9.].", ""));
            if (prosimo == "+")
            {
                value = value + value * (auction / 100);
            }
            else
            {
                value = value - value * (auction / 100);
            }
            //end of parse beaver
        }
        else if (cost1 == 50) //check if leather rabbit
        {
            //parse rabbit data
            string rabitleather = "";
            Match mrabit = Regex.Match(htmlString, @"<p>White Velvet M(.*?)<p>", RegexOptions.Singleline);
            if (mrabit.Success)
            {
                rabitleather = mrabit.Groups[1].Value;
            }
            string prosimo = Regex.Replace(rabitleather, "[^+--.]", "");
            double auction = Convert.ToDouble(Regex.Replace(rabitleather, "[^0-9.].", ""));
            if (prosimo == "+")
            {
                value = value + value * (auction / 100);
            }
            else
            {
                value = value - value * (auction / 100);
            }
            //end of parse rabit data
        }
        
        int temp;
        int work = 0; //cost of work
        //estimated work value
        int fulll = (length + sleeve + shoulder)/10;
        if(cost1>=100)
            {
                work = 40 * fulll;
            }
        else if (cost1 < 100)
            {
                work = 20 * fulll;
            }
        //end of estimated work value

        temp = (length + sleeve + shoulder) / 10; //ypologizoume posa dermata peripou tha xreiastoun
        int calc;
        int newvalauction = Convert.ToInt32(value); //new price of fur leather!
        calc = (int)(newvalauction * temp) + cost2 + (cost3 * shoulder) + cost4 + work;
        return calc;
    }
    
}