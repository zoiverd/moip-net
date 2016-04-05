using System;

namespace Moip.Net.Assinaturas
{
    public class AssinaturasClient : BaseClient
    {
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

        #endregion

    }
}
