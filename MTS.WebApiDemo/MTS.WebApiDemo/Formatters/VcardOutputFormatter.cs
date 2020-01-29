using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using MTS.WebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS.WebApiDemo.Formatters
{
    public class VcardOutputFormatter : TextOutputFormatter
    {
        public VcardOutputFormatter()
        {
            //Desteklenen tipler ve headerbaşlıgında gelen isteği tanımlamak için text/vcard eklendi

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

      

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            //gelen contexti aşağıda yazdıgımız formatvcard ile çevireceğiz

            var response = context.HttpContext.Response;


            var stringbuilder = new StringBuilder();

            if (context.Object is List<ContactModel>)
            {
                foreach (ContactModel contactModel in context.Object as List<ContactModel>)
                {
                    FormatVcard(stringbuilder, contactModel);
                }
            }
            else
            {
                var contact = context.Object as ContactModel;
                FormatVcard(stringbuilder,contact);
            }

            return response.WriteAsync(stringbuilder.ToString());
        }
        public static void FormatVcard(StringBuilder stringBuilder,ContactModel contactModel)
        {
            //gelen veriyi bu formata ceviriyoruz
            stringBuilder.AppendLine("BEGIN:VCARD");
            stringBuilder.AppendLine("VERSION:2.1");
            stringBuilder.AppendLine($"N:{contactModel.LastName};{contactModel.FirstName}");
            stringBuilder.AppendLine($"FN:{contactModel.FirstName};{contactModel.LastName}");
            stringBuilder.AppendLine($"UID:{contactModel.ContactID} \r\n");
            stringBuilder.AppendLine("END:VCARD");
        }

        //formattera gelen veririnin contactModel olup olmadıgını kontrol ediyoruz
        protected override bool CanWriteType(Type type)
        {
            //gelen type contact model tipindeyse
            if (typeof(ContactModel).IsAssignableFrom(type) || typeof(List<ContactModel>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);

            }
            return false;
        }
    }
}
