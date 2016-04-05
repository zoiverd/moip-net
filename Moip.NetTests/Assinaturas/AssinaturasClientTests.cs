using Moip.Net.Assinaturas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moip.NetTests;
using System;
using System.Linq;

namespace Moip.Net.Assinaturas.Tests
{
    [TestClass()]
    public class AssinaturasClientTests
    {
        private AssinaturasClient assinaturasClient = new AssinaturasClient(Settings.ApiUri, Settings.ApiToken, Settings.ApiKey);

        #region Plans
        private Plan NewMockPlan()
        {
            return new Plan()
            {
                Code = "test_Plano_" + DateTime.Now.Ticks,
                Name = "Plano Especial",
                Description = "Descrição do plano especial",
                Amount = 9990,
                SetupFee = 500,
                MaxQty = 999,
                Interval = new PlanInterval()
                {
                    Length = 1,
                    Unit = PlanInterval.IntervalUnit.MONTH
                },
                BillingCycles = 12,
                Trial = new PlanTrial()
                {
                    Days = 30,
                    Enabled = true,
                    HoldSetupFee = true
                },
                PaymentMethod = Plan.PaymentMethodPlan.ALL
            };
        }

        [TestMethod()]
        public void CreatePlanTest()
        {
            var retorno = assinaturasClient.CreatePlan(NewMockPlan());
            Assert.AreEqual("Plano criado com sucesso", retorno.Message);

        }

        [TestMethod()]
        public void GetPlansTest()
        {
            var retorno = assinaturasClient.GetPlans();
            Assert.IsNotNull(retorno);
            Assert.IsNotNull(retorno.Plans);
            Assert.IsTrue(retorno.Plans.Length > 0);
            Assert.IsNotNull(retorno.Plans[0].Code);
        }

        private PlansResponse GetPlans()
        {
            var plans = assinaturasClient.GetPlans();

            if (plans == null || plans.Plans.Length == 0)
            {
                throw new AssertInconclusiveException("Nenhum plano foi encontrado no cadastro");
            }

            return plans;
        }

        [TestMethod()]
        public void GetPlanTest()
        {
            var firstPlan = GetPlans().Plans.First();
            var gettedPlan = assinaturasClient.GetPlan(firstPlan.Code);

            Assert.AreEqual(firstPlan.Code, gettedPlan.Code);
        }


        [TestMethod()]
        public void InactivatePlan()
        {
            var firstPlan = GetPlans().Plans.FirstOrDefault(x => x.Status == Plan.StatusPlan.ACTIVE);

            if (firstPlan == null)
            {
                Assert.Inconclusive("Nenhum plano ATIVO foi encontrado no cadastro");
            }
            else
            {
                assinaturasClient.InactivatePlan(firstPlan.Code);
                var plan = assinaturasClient.GetPlan(firstPlan.Code);
                Assert.IsTrue(plan.Status == Plan.StatusPlan.INACTIVE);
            }
        }

        [TestMethod()]
        public void ActivatePlan()
        {
            var firstPlan = GetPlans().Plans.FirstOrDefault(x => x.Status == Plan.StatusPlan.INACTIVE);

            if (firstPlan == null)
            {
                Assert.Inconclusive("Nenhum plano INATIVO foi encontrado no cadastro");
            }
            else
            {
                assinaturasClient.ActivatePlan(firstPlan.Code);
                var plan = assinaturasClient.GetPlan(firstPlan.Code);
                Assert.IsTrue(plan.Status == Plan.StatusPlan.ACTIVE);
            }
        }

        [TestMethod()]
        public void AlterarPlanoTest()
        {
            var firstPlan = GetPlans().Plans.FirstOrDefault(x => x.Status == Plan.StatusPlan.ACTIVE);
            if (firstPlan == null)
            {
                Assert.Inconclusive("Nenhum plano ATIVO foi encontrado no cadastro");
            }
            else
            {
                var plan = assinaturasClient.GetPlan(firstPlan.Code);
                plan.Name = "Plano Alterado - " + DateTime.Now.Ticks;
                assinaturasClient.UpdatePlan(plan.Code, plan);
                var updatedPlan = assinaturasClient.GetPlan(firstPlan.Code);
                Assert.AreEqual(plan.Name, updatedPlan.Name);
            }
        }
        #endregion

        #region Customers

        private CustomerRequest NewMockCustomer()
        {
            var code = "teste_cliente_" + DateTime.Now.Ticks;
            return new CustomerRequest()
            {
                Code = code,
                Email = code + "@acme.com",
                Fullname = "Roger Rabbit",
                Cpf = "72716422699",
                PhoneAreaCode = 11,
                PhoneNumber = "555555555",
                BirthdateDay = 19,
                BirthdateMonth = 7,
                BirthdateYear = 1985,
                Address = new CustomerAddress()
                {
                    Street = "Rua Nome da Rua",
                    Number = "100",
                    Complement = "AP 51",
                    District = "Nossa Senhora do Ó",
                    City = "São Paulo",
                    State = "SP",
                    Country = "BRA",
                    Zipcode = "02927100"
                },
                BillingInfo = new BillingInfoRequest()
                {
                    CreditCard = new CreditCard()
                    {
                        HolderName = "Roger Rabbit",
                        Number = "4111111111111111",
                        ExpirationMonth = "04",
                        ExpirationYear = "30"
                    }
                }
            };
        }

        private CustomersResponse GetCustomers()
        {
            var customers = assinaturasClient.GetCustomers();

            if (customers == null || customers.Customers == null || customers.Customers.Length == 0)
            {
                throw new AssertInconclusiveException("Nenhum cliente encontrado no cadastro do moip.");
            }

            return customers;
        }

        [TestMethod()]
        public void CreateCustomerTest()
        {
            var customer = NewMockCustomer();
            var respose = assinaturasClient.CreateCustomer(customer, true);
            Assert.AreEqual("Cliente criado com sucesso", respose.Message);
        }

        [TestMethod()]
        public void GetCustomersTest()
        {
            var retorno = GetCustomers();
            Assert.IsNotNull(retorno);
            Assert.IsNotNull(retorno.Customers);
            Assert.IsTrue(retorno.Customers.Length > 0);
            Assert.IsNotNull(retorno.Customers[0].Code);
        }

        [TestMethod()]
        public void GetCustomerTest()
        {
            var firstCustomer = GetCustomers().Customers.First();
            var gettedCustomer = assinaturasClient.GetCustomer(firstCustomer.Code);

            Assert.AreEqual(firstCustomer.Code, gettedCustomer.Code);
        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            var firstCustomer = GetCustomers().Customers.First();
            var customerRequest = NewMockCustomer();
            customerRequest.BillingInfo = null;
            customerRequest.Code = firstCustomer.Code;
            customerRequest.Fullname = "Nome alterado - " + DateTime.Now.Ticks.ToString();
            assinaturasClient.UpdateCustomer(firstCustomer.Code, customerRequest);

            var updatedCustomer = assinaturasClient.GetCustomer(customerRequest.Code);

            Assert.AreEqual(customerRequest.Fullname, updatedCustomer.Fullname);

        }

        #endregion


    }
}