using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitrix24;
using Bitrix24.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bitrix24Tests
{
    [TestClass]
    public class CreateLeadTest
    {
        protected string _email;
        protected string _password;
        protected string _b24Address;

        public CreateLeadTest()
        {
            _b24Address = ConfigurationManager.AppSettings["Bitrix24Address"];
            _email = ConfigurationManager.AppSettings["Bitrix24Login"];
            _password = ConfigurationManager.AppSettings["Bitrix24Password"];

            if (String.IsNullOrEmpty(_b24Address)
                || String.IsNullOrEmpty(_email)
                || String.IsNullOrEmpty(_password))
            {
                throw new ArgumentException("Must be address, email and password");
            }

        }

        [TestMethod]
        public async Task CreateLead_Ok_Test()
        {
            var client = new Bitrix24Client(_email, _password, _b24Address);
            var lead = new BitrixLead
            {
                Comments = "Комментарий к лиду",
                EmailWork = "pupsik@pups.ru",
                LastName = "Пупсиков",
                Name = "Пупсик",
                PhoneMobile = "+79999999999",
                SecondName = "Пупсикович",
                Title = "Пупсик хочет, чтобы ему перезвонили!",
                AssignedById = 1,
                StatusId = "1"
            };

            var leadId = await client.CreateLead(lead);

            Assert.IsFalse(String.IsNullOrEmpty(leadId));
        }
    }
}
