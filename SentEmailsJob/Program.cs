using SentEmailsJob.Data;
using SentEmailsJob.Dto;
using SentEmailsJob.EmailService;
using SentEmailsJob.Entities;
using System.Text;

namespace SentEmailsJob
{
    class Program
    {
        static void Main(string[] args)
        {
            //EmailControl emailControl = new EmailControl()
            //{
            //    ProcessDate = DateTime.Now,
            //    CustomerId = 1,
            //    Address = "",
            //    NumberOfTransactionsSent = 0,
            //    Subject = ""
            //};

            //CustomerPersistence customerPersistence = new CustomerPersistence();
            //TransactionPersistence transactionPersistence = new TransactionPersistence();
            //EmailControlPersistence emailControlPersistence = new EmailControlPersistence();
            //emailControlPersistence.InsertEmailControl(emailControl);
            Execute();
        }

        public static async void Execute()
        {
            const int daysToExpirate = 30;
            const string address = "test1999@outlook.com";
            const string subject = "Consolidado de transações proximas a vencer.";

            CustomerPersistence customerPersistence = new CustomerPersistence();
            TransactionPersistence transactionPersistence = new TransactionPersistence();
            EmailControlPersistence emailControlPersistence = new EmailControlPersistence();
            SentEmail sentEmail = new SentEmail();

            var customers = customerPersistence.GetAll();
            if (customers == null)
                return;

            var transactionsReports = new List<TransactionReportDto>();
            var emailControllRegisters = new List<EmailControl>();

            foreach (var customer in customers)
            {
                var getReports = transactionPersistence.GetTransactionReportByEmailAndDaysToExpirate(customer.Email, daysToExpirate);

                emailControllRegisters.Add(new EmailControl()
                {
                    Address = address,
                    Subject = subject,
                    NumberOfTransactionsSent = getReports.Count(),
                    CustomerId = customer.Id,
                    ProcessDate = DateTime.Now
                });

                transactionsReports.AddRange(getReports);
            }

            string csvData = ToCsv(transactionsReports);
            byte[] csvBytes = Encoding.UTF8.GetBytes(csvData);

            //send email
            await sentEmail.SendEmailAsync(address, "", "", subject, csvData);

            //save control register
            foreach (var emailControl in emailControllRegisters)
            {
                emailControlPersistence.InsertEmailControl(emailControl);
            }
        }

        public static string ToCsv<T>(List<T> objects)
        {
            var csvBuilder = new StringBuilder();

            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                csvBuilder.Append(property.Name + ",");
            }
            csvBuilder.AppendLine();

            foreach (var obj in objects)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(obj);
                    if (value is string)
                    {
                        csvBuilder.Append("\"" + value + "\",");
                    }
                    else
                    {
                        csvBuilder.Append(value + ",");
                    }
                }
                csvBuilder.AppendLine();
            }

            return csvBuilder.ToString();
        }
    }
}