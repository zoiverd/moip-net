using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Moip.Net.Assinaturas
{
    public class AssinaturasClient : BaseClient
    {
        private JsonSerializerSettings _jsonSettings;
        protected override JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings();
                    _jsonSettings.Converters.Add(new StringEnumConverter());
                    _jsonSettings.Formatting = Formatting.Indented;
                    _jsonSettings.ContractResolver = new AssinaturasMoipContractResolver();
                    _jsonSettings.NullValueHandling = NullValueHandling.Ignore;
                }
                return _jsonSettings;
            }
        }

        public AssinaturasClient(Uri apiAddress, string apiToken, string apiKey) : base(apiAddress, apiToken, apiKey) { }

        protected override Uri PathToUri(string path, string query = null)
        {
            path = "/assinaturas/v1/" + path;
            return base.PathToUri(path, query);
        }

        #region Plans

        /// <summary>
        /// Por meio desta API é possível criar um plano.
        /// </summary>
        /// <param name="plan">Plano a ser criado</param>
        /// <returns>Mensagem de retorno do plano</returns>
        public Response CreatePlan(Plan plan)
        {
            if (plan == null)
            {
                throw new ArgumentNullException("Plan");
            }

            var uri = PathToUri("plans");
            return base.DoRequest<Response>(uri, "POST", ToJson(plan));
        }

        /// <summary>
        /// Por meio desta API é possível listar Planos criados.
        /// </summary>
        /// <returns>Lista de planos cadastrados na conta moip</returns>
        public PlansResponse GetPlans()
        {
            var uri = PathToUri("plans");
            return base.DoRequest<PlansResponse>(uri);
        }

        /// <summary>
        /// Por meio desta API é possível consultar um Plano
        /// </summary>
        /// <param name="code">Código do plano</param>
        /// <returns>Plano cadastrado na conta moip</returns>
        public Plan GetPlan(string code)
        {
            var uri = PathToUri("plans/" + code);
            return base.DoRequest<Plan>(uri);
        }

        /// <summary>
        /// Por meio desta API é possível ativar um Plano.
        /// </summary>
        /// <param name="code">Código do plano</param>
        public void ActivatePlan(string code)
        {
            var uri = PathToUri("plans/" + code + "/activate");
            base.DoRequest(uri, "PUT");
        }

        /// <summary>
        /// Por meio desta API é possível desativar um Plano.
        /// </summary>
        /// <param name="code">Código do plano</param>
        public void InactivatePlan(string code)
        {
            var uri = PathToUri("plans/" + code + "/inactivate");
            base.DoRequest(uri, "PUT");
        }

        public void UpdatePlan(string code, Plan plan)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("code");

            if (plan == null )
                throw new ArgumentNullException("plan");

            //Limpa o código para não dar conflito com o que foi passado
            plan.Code = null;

            var uri = PathToUri("plans/" + code);
            base.DoRequest(uri, "PUT", ToJson(plan));
        }

        #endregion

        #region Customers

        /// <summary>
        /// Para criar uma assinatura, você precisa cadastrar um cliente(assinante) com os dados de pagamento. Isso pode ser feito por meio desta API ou no ato de criação da assinatura.
        /// </summary>
        /// <param name="customer">Cliente</param>
        /// <param name="newVault">Se new_valt=true, o envio do node credit_card{} é obrigatório. Utilize isto para criar um assinante com dados de cartão e gerar um cofre para guardar os dados de pagamento com segurança no Moip.</param>
        /// <returns>Mensagem de retorno</returns>
        public Response CreateCustomer(CustomerRequest customer, bool newVault)
        {
            var uri = PathToUri("customers", "new_vault=" + newVault.ToString());
            return DoRequest<Response>(uri, "POST", ToJson(customer));
        }

        /// <summary>
        /// Por meio desta API é possível listar assinantes criados.
        /// </summary>
        /// <returns>Lista de assinantes</returns>
        public CustomersResponse GetCustomers()
        {
            var uri = PathToUri("customers");
            return DoRequest<CustomersResponse>(uri);
        }

        /// <summary>
        /// Por meio desta API é possível consultar um Assinante.
        /// </summary>
        /// <returns>Assinante cadastrado na conta moip</returns>
        public CustomerResponse GetCustomer(string code)
        {
            var uri = PathToUri("customers/" + code);
            return DoRequest<CustomerResponse>(uri);
        }

        /// <summary>
        /// Por meio desta API é possível consultar um Assinante.
        /// </summary>
        /// <remarks>Para alterar os dados de pagamento do assinante utilize o Método UpdateBillingInfo</remarks>
        /// <param name="code">Código do Cliente</param>
        /// <param name="customer">Cliente para alterar</param>
        public void UpdateCustomer(string code, CustomerRequest customer)
        {
            if(string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code");
            }

            if (customer == null)
            {
                throw new ArgumentNullException("customer");
            }

            customer.Code = code;
            
            var uri = PathToUri("customers/" + code);
            DoRequest(uri, "PUT", ToJson(customer));
        }

        /// <summary>
        /// Atualize os dados de pagamento de seu assinante.
        /// </summary>
        /// <param name="customerCode">Código do assinante</param>
        /// <param name="billingInfo">Dados do cartão de crédito</param>
        /// <returns>Dados alterados com sucesso</returns>
        public Response UpdateBillingInfo(string customerCode, BillingInfoRequest billingInfo)
        {
            var uri = PathToUri(string.Format("customers/{0}/billing_infos", customerCode));
            return DoRequest<Response>(uri, "PUT", ToJson(billingInfo));
        }

        #endregion

        #region Subscriptions
        public SubscriptionResponse CreateSubscription(Subscription subscription, bool newCustomer)
        {
            var uri = PathToUri("subscriptions", "new_customer=" + newCustomer.ToString());
            return DoRequest<SubscriptionResponse>(uri, "POST", ToJson(subscription));
        }

        public SubscriptionsResponse GetSubscriptions()
        {
            var uri = PathToUri("subscriptions");
            return DoRequest<SubscriptionsResponse>(uri);
        }

        public SubscriptionResponse GetSubscription(string code)
        {
            var uri = PathToUri("subscriptions/" + code);
            return DoRequest<SubscriptionResponse>(uri);
        }

        public void SuspendSubscription(string code)
        {
            var uri = PathToUri(string.Format("subscriptions/{0}/suspend", code));
            DoRequest(uri, "PUT");
        }

        public void ActivateSubscription(string code)
        {
            var uri = PathToUri(string.Format("subscriptions/{0}/activate", code));
            DoRequest(uri, "PUT");
        }

        public void CancelSubscription(string code)
        {
            var uri = PathToUri(string.Format("subscriptions/{0}/cancel", code));
            DoRequest(uri, "PUT");
        }

        public void UpdateSubscription(string code, Subscription subscription)
        {
            var uri = PathToUri("subscriptions/" + code);
            DoRequest(uri, "PUT", ToJson(subscription));
        }
        #endregion

        #region Invoices

        public InvoicesResponse GetInvoices(string subscriptionCode)
        {
            var uri = PathToUri(string.Format("subscriptions/{0}/invoices", subscriptionCode));
            return DoRequest<InvoicesResponse>(uri);
        }


        public Invoice GetInvoice(int invoiceId)
        {
            var uri = PathToUri("invoices/" + invoiceId.ToString());
            return DoRequest<Invoice>(uri);
        }

        #endregion

        #region Coupons

        public Coupon CreateCoupon(Coupon coupon)
        {
            var uri = PathToUri("coupons");
            return DoRequest<Coupon>(uri, "POST", ToJson(coupon));
        }

        public void AssociateCoupon(string couponCode, string subscriptionCode)
        {
            var subscription = new Subscription()
            {
                Code = subscriptionCode,
                Coupon = new Coupon()
                {
                    Code = couponCode
                }
            };

            var uri = PathToUri("subscriptions/" + subscriptionCode);
            DoRequest(uri, "PUT", ToJson(subscription));
        } 

        public Coupon GetCoupon(string code)
        {
            var uri = PathToUri("coupons/" + code);
            return DoRequest<Coupon>(uri);
        }

        public CouponsResponse GetCoupons()
        {
            var uri = PathToUri("coupons");
            return DoRequest<CouponsResponse>(uri);
        }

        public Coupon ActivateCoupon(string code)
        {
            var uri = PathToUri(string.Format("coupons/{0}/active", code));
            return DoRequest<Coupon>(uri, "PUT");
        }

        public Coupon InactivateCoupon(string code)
        {
            var uri = PathToUri(string.Format("coupons/{0}/inactive", code));
            return DoRequest<Coupon>(uri, "PUT");
        }

        public SubscriptionResponse DesassociateCoupon(string subscriptionCode)
        {
            var uri = PathToUri(string.Format("subscriptions/{0}/coupon", subscriptionCode));
            return DoRequest<SubscriptionResponse>(uri, "DELETE");
        }

        #endregion

        #region Retrys

        public void InvoiceRetry(int invoiceId)
        {
            var uri = PathToUri(string.Format("invoices/{0}/retry", invoiceId));
            DoRequest(uri, "POST");
        }

        public void InvoiceRetryPreferences(PreferencesRetry preferences)
        {
            var uri = PathToUri("users/preferences/retry");
            DoRequest(uri, "POST", ToJson(preferences));
        }

        #endregion

    }
}
