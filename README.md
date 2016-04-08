# Moip.Net

Moip.Net é uma biblioteca para utilizar as funções da API do Moip.

ATENÇÃO! Apenas as funções de assinatura estão implementadas, mas você pode ajudar o projeto e implementar as outras funções. Toda a arquitetura já está pronta.

## Instalação

Moip.Net está disponível como um [NuGet Package](https://www.nuget.org/packages/moip-net/). Esta é a melhor forma de instalar a biblioteca no seu projeto.

#### Visual Studio

Click on *Tools -> NuGet Package Manager -> Package Manager Console* and enter the following

	PM> Install-Package moip-net

## Como usar

A biblioteca irá chamar a API do moip. Veja na [Documentação do moip](http://dev.moip.com.br/assinaturas-api/) os parâmetros que devem ser enviadas a cada chamada.

Nos exemplos escritos, estamos assumindo que há esta linha nos usings

```cs
using Moip.Net.Assinaturas;
```

#### Inicio

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

- As outras funções seguem a mesma linha e a DLL possui documentação dos parâmetros (mas sempre é bom consultar a documentação oficial)
- Sobre os nomes das funções em inglês e nome da api em portugês, tentei seguir ao máximo a descrição da documentação oficial do moip
- Acabei utilizando apenas a API de Assinaturas, então acabei não implementando as de pagamento comum. Não chamei este projeto de MoipAssinaturas porque creio ter ficado fácil extender, caso queira ajudar entre em contato.
- Os testes estão 100% funcionais
