using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mail;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace MHCotton.Common
{
    public class SMTPMail
    {
        public static void GetEmailContent(string xslttemplatename, IDictionary objDictionary, string emailTo)
        {
            //var templatepath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates");
            //var objxslt = new XslTransform();
            //objxslt.Load(templatepath + "\\" + xslttemplatename);
            string templatepath = ConfigurationSettings.AppSettings["EmailTemplates"];

            var objxslt = new XslTransform();

            objxslt.Load(templatepath + xslttemplatename);
            var xmldoc = new XmlDocument();
            xmldoc.AppendChild(xmldoc.CreateElement("DocumentRoot"));
            var xpathnav = xmldoc.CreateNavigator();
            var xslarg = new XsltArgumentList();
            if (objDictionary != null)
            {
                foreach (DictionaryEntry entry in objDictionary)
                {
                    xslarg.AddParam(entry.Key.ToString(), "ext:User", entry.Value);
                }
            }
            var emailbuilder = new StringBuilder();
            var xmlwriter = new XmlTextWriter(new System.IO.StringWriter(emailbuilder));
            objxslt.Transform(xpathnav, xslarg, xmlwriter, null);
            string subjecttext, bodytext;
            var xemaildoc = new XmlDocument();
            xemaildoc.LoadXml(emailbuilder.ToString());
            var titlenode = xemaildoc.SelectSingleNode("//title");
            subjecttext = titlenode.InnerText;
            var bodynode = xemaildoc.SelectSingleNode("//body");
            bodytext = bodynode.InnerXml;
            if (!string.IsNullOrEmpty(bodytext))
            {
                bodytext = bodytext.Replace("&amp;", "&");
            }
            SendEmail(emailTo, subjecttext, bodytext);
        }
        static private void SendEmail(string emailto, string subjecttext, string bodyText)
        {
            //string SMTPServer = ConfigurationSettings.AppSettings["SMTPServer"];
            //string EmailFrom = ConfigurationSettings.AppSettings["EmailFrom"];

            System.Net.Mail.MailMessage mailmessage = new System.Net.Mail.MailMessage("nareshpalza@gmail.com", emailto);
            subjecttext = subjecttext.Replace('\r', ' ').Replace('\n', ' ');
            mailmessage.Subject = subjecttext;
            mailmessage.Body = bodyText;
            mailmessage.BodyEncoding = Encoding.UTF8;
            mailmessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "nareshpalza@gmail.com",
                Password = "Pushpa@1229"
            };
            smtpClient.Send(mailmessage);
            
        }
    }
}
