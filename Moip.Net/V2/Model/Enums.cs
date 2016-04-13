using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moip.Net.V2
{
    public enum BrandType
    {
        VISA,
        MASTERCARD,
        AMEX,
        DINERS,
        ELO,
        HIPER,
        HIPERCARD
    }
    public enum DocumentType
    {
        CPF,
        CNPJ
    }
    public enum MethodType
    {
        CREDIT_CARD,
        BOLETO,
        ONLINE_DEBIT,
        WALLET,
        MOIP_ACCOUNT
    }

    public enum OrderStatusType
    {
        CREATED,
        WAITING,
        PAID,
        NOT_PAID,
        REVERTED
    }

    public enum CurrencyType
    {
        BRL
    }

    public enum PaymentStatusType
    {
        CREATED,
        WAITING,
        IN_ANALYSIS,
        PRE_AUTHORIZED,
        AUTHORIZED,
        CANCELLED,
        REFUNDED,
        REVERSED,
        SETTLED
    }

    public enum FeeType
    {
        TRANSACTION,
        PRE_PAYMENT
    }
    public enum CancelledByType
    {
        MOIP,
        ACQUIRER
    }
    public enum RefundStatusType
    {
        REQUESTED,
        COMPLETED,
        FAILED
    }
    public enum RefundType
    {
        FULL,
        PARTIAL
    }

    public enum BankAccountType
    {
        CHECKING,
        SAVING
    }

    public enum EntryStatusType
    {
        SCHEDULED,
        SETTLED
    }

    public enum OperationType
    {
        CREDIT,
        DEBIT
    }

    public enum ReceiverType
    {
        PRIMARY,
        SECONDARY
    }
}
