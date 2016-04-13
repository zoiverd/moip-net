# Moip.Net

Moip.Net é uma biblioteca para utilizar as funções da API do Moip.

ATENÇÃO! A implementação da V1 da API não será considerada neste componente, uma vez que a V2 já está em ambiente de produção.

Estão implementadas as bibliotecas de Assinatura e Pagamento V2.

## Instalação

Moip.Net está disponível como um [NuGet Package](https://www.nuget.org/packages/moip-net/). Esta é a melhor forma de instalar a biblioteca no seu projeto.

### Visual Studio

Click on *Tools -> NuGet Package Manager -> Package Manager Console* and enter the following

PM> Install-Package moip-net

## Pagamentos v2

### Como usar

A biblioteca irá chamar a API do moip. Veja na [Documentação do moip](http://dev.moip.com.br/referencia-api/) os parâmetros que devem ser enviadas a cada chamada.

Nos exemplos escritos, estamos assumindo que há os seguintes usings

```cs
using Moip.Net.V2;
using Moip.Net.V2.Model;
```

### Exemplos

Todas as funções de pagamento são chamadas através de uma instância da classe V2Client.
Para criar uma instância, você deve informar o ambiente (produção ou sandbox), sua API_Key e seu Token.

#### Criando um pedido com um novo cliente

Veja a documentação aqui: [Criar pedido](http://dev.moip.com.br/referencia-api/#criar-pedido-post)

```cs

var v2Client =  new V2Client(
	new Uri("https://sandbox.moip.com.br/"), 
	"API_TOKEN",
	"API_KEY"
);

var pedido = new Pedido()
{
	OwnId = "SEU_CODIGO_PEDIDO",
	Amount = new Valores()
	{
		Currency = CurrencyType.BRL,
		Subtotals = new Subtotal()
		{
			Shipping = 1000
		}
	},
	Items = new List<ItemPedido>()
	{
		new ItemPedido()
		{
			Product = "Descrição do produto",
			Quantity = 1,
			Detail = "Detalhes",
			Price = 1000
		}
	},
	Customer = new Cliente()
	{
		OwnId = "SEU_ID_CLIENTE",
		Fullname = "José Silva",
		Email = "josesilva@acme.com.br",
		BirthDate = DateTime.Now.Date.AddYears(-18).ToString("yyyy-MM-dd"),
		TaxDocument = new Documento()
		{
			Type = DocumentType.CPF,
			Number = "65374721054"
		},
		Phone = new Telefone()
		{
			CountryCode = 55,
			AreaCode = 11,
			Number = 999999999
		},
		ShippingAddress = new Endereco()
		{
			ZipCode = "01234000",
			Street = "Avenida Faria Lima",
			StreetNumber = "2927",
			Complement = "SL 1",
			City = "São Paulo",
			District = "Itaim",
			State = "SP",
			Country = "BRA"
		}
	};
};

var clienteCriado = v2Client.CriarPedido(pedido);
```
#### Listando os pedidos com filters
Veja a documentação aqui: [Listar todos pedidos](http://dev.moip.com.br/referencia-api/#listar-todos-pedidos-get)

```cs

var v2Client =  new V2Client(
	new Uri("https://sandbox.moip.com.br/"), 
	"API_TOKEN",
	"API_KEY"
);

//Listar todos os pedidos pagos e criados com data superior a 01/01/2016
var filters = new Filters()
	.Add(new GreatherThanFilter<DateTime>("createdAt", new DateTime(2016, 01, 01)))
	.Add(new InFilter<OrderStatusType>("status", OrderStatusType.CREATED, OrderStatusType.PAID));

var pedidos = v2Client.ListarTodosPedidos(filters: filters);
```
#### Tratamento de erro
Todas as exceções geradas durante a chamada da API serão retornadas como uma MoipException.
			

```cs

try
{
	var v2Client =  new V2Client(
		new Uri("https://sandbox.moip.com.br/"), 
		"API_TOKEN",
		"API_KEY"
	);

	var cliente = new Cliente();
	v2Client.CriarCliente(cliente);
}
catch (MoipException ex)
{
	//ex.Message = Mensagem de retorno + descrição de todos os erros retornados do moip com quebra de linha
	//ex.ResponseError.Errors = Coleção de [Codigo, Path e Description](http://dev.moip.com.br/referencia-api/#abordagem-restful)
}

```

### O que está implementado

Este componente não faz ABSOLUTAMENTE nenhuma validação de dados. Tudo isto fica a cargo da própria API.
Para verificar os parâmetros obrigatórios e especificidades de cada chamada, verifique a [documentação](http://dev.moip.com.br/referencia-api/).

- Clientes
..- CriarCliente
..- ConsultarCliente
..- AdicionarCartaoCliente
- Pedidos
..- CriarPedido
..- ConsultarPedido
..- ListarTodosPedidos
- Pagamentos
..- CriarPagamento
..- ConsultarPagamento
..- CapturarPagamentoPreAutorizado
..- CancelarPagamentoPreAutorizado

NÃO IMPLEMENTADOS
- Reembolsos
- Multipedidos
- Multipagamentos
- Permissões de terceiros
- Contas Moip
- Contas Bancárias
- Transferências
- Conciliação Financeira

## Assinaturas

Todas as funções de assinatura são chamadas através de uma instância da classe AssinaturasClient.
Para criar uma instância, você deve informar o ambiente (dev ou sandbox), sua API_Key e seu Token.

```cs
var assinaturasClient = 
	new AssinaturasClient(
		new Uri("https://sandbox.moip.com.br/"), 
		"API_TOKEN",
		"API_KEY");
```

#### Criando uma Assinatura com um novo cliente

http://dev.moip.com.br/assinaturas-api/#criar-assinaturas-post

```cs

var subscription = new Subscription()
{
    Code = "_test_assinatura_" + DateTime.Now.Ticks,
    PaymentMethod = Plan.PaymentMethodPlan.CREDIT_CARD,
    Plan = firstPlan,
    Customer = new CustomerRequest()
	{
		Code = "CodigoCliente,
		Email = "rogerr@acme.com",
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

assinaturasClient.CreateSubscription(subscription, true);

```

## Observações

- As outras funções seguem a mesma linha e a biblioteca possui documentação dos parâmetros (mas sempre é bom consultar a documentação oficial)
- Sobre os nomes das propriedades em inglês e funções em portugês, tentei seguir ao máximo a descrição da documentação oficial do moip, para facilitar o uso.
- Os testes unitários estão passando 100%, com 90% de code coverage :)
- Qualquer dúvida ou sugestão, crie seu issue ou [entre em contato](mailto:rafagoncalves+moipnet@gmail.com)
