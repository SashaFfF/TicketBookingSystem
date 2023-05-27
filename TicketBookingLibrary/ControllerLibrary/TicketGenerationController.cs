using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLibrary.TicketClasses;

using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;
using System.Diagnostics;
using Image = iText.Layout.Element.Image;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using Cell = iText.Layout.Element.Cell;
using Border = iText.Layout.Borders.Border;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using EntityLibrary.EventClasses;
using System.Numerics;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace ControllerLibrary
{
    public class TicketGenerationController
    {
        public static string BackgroundImage = "D:\\oop\\background.png";

        public static string GenerationTicketPdf(Ticket ticket)// Id
        {
            //PdfWriter: To pass the file name and write content to the document.
            string ticketPath = $"C:\\Users\\user\\Documents\\OOP\\tickets\\ticket{ticket.Id}.pdf"; //"D:\\oop\\tickets\\ticket{ticket.Id}.pdf"
            PdfWriter writer = new PdfWriter(ticketPath);

            //PdfDocument: open a PDF document in writing mode.
            PdfDocument pdf = new PdfDocument(writer);

            //Document: Creates a document from PdfDocument in memory.
            Document document = new Document(pdf, PageSize.A5);

            PdfCanvas canvas = new PdfCanvas(pdf.AddNewPage());
            canvas.AddImageFittedIntoRectangle(ImageDataFactory.Create(BackgroundImage), PageSize.A5, false);

            Event ev = ticket.Event;

            //Header
            Paragraph header = new Paragraph("TICKET")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(30)
                .SetFontColor(ColorConstants.WHITE);
            document.Add(header);
            //Subheader
            Paragraph subheader = new Paragraph(" ")
                .SetFontSize(18)
                .SetFontColor(ColorConstants.WHITE);
            document.Add(subheader);
            //Image
            Image image = new Image(ImageDataFactory.Create(ev.Poster)).SetHeight(260).SetTextAlignment(TextAlignment.CENTER);
            //Table
            Table table = new Table(2);
            Cell cell11 = new Cell()
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontColor(ColorConstants.WHITE)
               .SetFontSize(15)
               //.Add(new Paragraph($"Place: {ev.EventLocation.BuildingName}"))
               //.Add(new Paragraph($"Location: {ev.EventLocation.Street.ToString()}, {ev.EventLocation.BuildingNumber}"))
               .Add(new Paragraph($"Location: {ev.EventLocation.BuildingName}"))
               .Add(new Paragraph($"Date and time: {ev.Date}"))
               .Add(new Paragraph($"Row: {ticket.Row}"))
               .Add(new Paragraph($"Number: {ticket.Number}"))
               .Add(new Paragraph($"Price: {ticket.TicketCategory.Price} BYN"));
            Cell cell12 = new Cell().Add(image);
            table.AddCell(cell11);
            table.AddCell(cell12);
            document.Add(table);
            //id paragraph
            Paragraph paragraphId = new Paragraph($"Id: {ticket.Id}")
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(15)
                .SetFontColor(ColorConstants.WHITE);
            document.Add(paragraphId);
            //wish paragraph
            Paragraph paragraph = new Paragraph($"Have a good time!")
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetFontSize(24)
                .SetFontColor(ColorConstants.WHITE);
            document.Add(paragraph);
            document.Close();
            return ticketPath;
        }
        public static async void SendEmail(string recipient, string ticketPath)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("TicketSystem", "ticket.system23@gmail.com"));
            message.To.Add(MailboxAddress.Parse(recipient));
            message.Subject = "Билет на мероприятие";

            var builder = new BodyBuilder();
            builder.TextBody = @"Здраствуйте! Ваш билет на мероприятие!";
            builder.Attachments.Add(ticketPath); // add my ticket pdf

            message.Body = builder.ToMessageBody();

            string emailAddress = "ticket.system23@gmail.com";
            string password = "ejjakzdehvllomvn";

            SmtpClient client = new SmtpClient();
            try
            {
                //connect to the gmail smtp server uing port 465 with SSL enabled
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);
                await client.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

    }
}
