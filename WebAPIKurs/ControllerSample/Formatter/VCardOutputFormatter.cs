using ControllerSample.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace ControllerSample.Formatter
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type type)
        {
            return typeof(Contact).IsAssignableFrom(type) || typeof(IEnumerable<Contact>).IsAssignableFrom(type);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<VCardOutputFormatter>>();



            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<Contact> contacts)
            {
                foreach (var contact in contacts)
                {
                    //Gleich geht es hier weiter :-) 
                    FormatVCard(buffer, contact, logger);
                }
            }
            else
            {
                FormatVCard(buffer, (Contact)context.Object, logger);
            }

            await httpContext.Response.WriteAsync(buffer.ToString());
        }


        private static void FormatVCard(StringBuilder buffer, Contact contact, ILogger logger)
        {
            buffer.AppendLine("BEGIN:VCARD");
            buffer.AppendLine("VERSION:2.1");
            buffer.AppendLine($"N:{contact.LastName};{contact.FirstName}");
            buffer.AppendLine($"FN:{contact.FirstName} {contact.LastName}");
            buffer.AppendLine($"UID:{contact.ID}");
            buffer.AppendLine("END:VCARD");

            logger.LogInformation("Writing {FirstName} {LastName}",
                contact.FirstName, contact.LastName);
        }
    }
}
