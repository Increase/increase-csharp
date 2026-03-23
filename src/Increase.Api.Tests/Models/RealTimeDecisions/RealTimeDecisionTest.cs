using System;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using RealTimeDecisions = Increase.Api.Models.RealTimeDecisions;

namespace Increase.Api.Tests.Models.RealTimeDecisions;

public class RealTimeDecisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecision
        {
            ID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new()
            {
                AccessControlServerTransactionIdentifier =
                    "access_control_server_transaction_identifier",
                AccountID = "account_id",
                BillingAddressCity = "billing_address_city",
                BillingAddressCountry = "billing_address_country",
                BillingAddressLine1 = "billing_address_line1",
                BillingAddressLine2 = "billing_address_line2",
                BillingAddressLine3 = "billing_address_line3",
                BillingAddressPostalCode = "billing_address_postal_code",
                BillingAddressState = "billing_address_state",
                CardID = "card_id",
                CardholderEmail = "cardholder_email",
                CardholderName = "cardholder_name",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
                DeviceChannel = new()
                {
                    Browser = new()
                    {
                        AcceptHeader = "accept_header",
                        IPAddress = "ip_address",
                        JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                        Language = "language",
                        UserAgent = "user_agent",
                    },
                    Category = RealTimeDecisions::Category.App,
                    MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
                },
                DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCountry = "merchant_country",
                MerchantName = "merchant_name",
                MessageCategory = new()
                {
                    Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                    NonPayment = new(),
                    Payment = new()
                    {
                        PurchaseAmount = 0,
                        PurchaseAmountCardholderEstimated = 0,
                        PurchaseCurrency = "purchase_currency",
                        TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                    },
                },
                PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
                RequestorAuthenticationIndicator =
                    RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
                RequestorChallengeIndicator =
                    RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
                RequestorName = "requestor_name",
                RequestorUrl = "requestor_url",
                ShippingAddressCity = "shipping_address_city",
                ShippingAddressCountry = "shipping_address_country",
                ShippingAddressLine1 = "shipping_address_line1",
                ShippingAddressLine2 = "shipping_address_line2",
                ShippingAddressLine3 = "shipping_address_line3",
                ShippingAddressPostalCode = "shipping_address_postal_code",
                ShippingAddressState = "shipping_address_state",
                ThreeDSecureServerTransactionIdentifier =
                    "three_d_secure_server_transaction_identifier",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
            },
            CardAuthenticationChallenge = new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            },
            CardAuthorization = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
                Decline = new(
                    RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
                ),
                DigitalWalletTokenID = null,
                Direction = RealTimeDecisions::Direction.Settlement,
                MerchantAcceptorID = "5665270011000168",
                MerchantCategoryCode = "5734",
                MerchantCity = "New York",
                MerchantCountry = "US",
                MerchantDescriptor = "AMAZON.COM",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                NetworkDetails = new()
                {
                    Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                        PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                        StandInProcessingReason = null,
                        TerminalEntryCapability =
                            RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 10,
                PartialApprovalCapability =
                    RealTimeDecisions::PartialApprovalCapability.NotSupported,
                PhysicalCardID = null,
                PresentmentAmount = 100,
                PresentmentCurrency = "USD",
                ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
                RequestDetails = new()
                {
                    Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                    IncrementalAuthorization = new()
                    {
                        CardPaymentID = "card_payment_id",
                        OriginalCardAuthorizationID = "original_card_authorization_id",
                    },
                    InitialAuthorization = new(),
                },
                SettlementAmount = 100,
                SettlementCurrency = "USD",
                TerminalID = "RCN5VNXS",
                UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                Verification = new()
                {
                    CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "33 Liberty Street",
                        ActualPostalCode = "94131",
                        ProvidedLine1 = "33 Liberty Street",
                        ProvidedPostalCode = "94132",
                        Result =
                            RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            CardBalanceInquiry = new()
            {
                AccountID = "account_id",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
                DigitalWalletTokenID = "digital_wallet_token_id",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCity = "merchant_city",
                MerchantCountry = "merchant_country",
                MerchantDescriptor = "merchant_descriptor",
                MerchantPostalCode = "merchant_postal_code",
                MerchantState = "merchant_state",
                NetworkDetails = new()
                {
                    Category =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                        PointOfServiceEntryMode =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                        StandInProcessingReason =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                        TerminalEntryCapability =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 0,
                PhysicalCardID = "physical_card_id",
                TerminalID = "terminal_id",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
                Verification = new()
                {
                    CardVerificationCode = new(
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                    ),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "actual_line1",
                        ActualPostalCode = "actual_postal_code",
                        ProvidedLine1 = "provided_line1",
                        ProvidedPostalCode = "provided_postal_code",
                        Result =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            Category = RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DigitalWalletAuthentication = new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            },
            DigitalWalletToken = new()
            {
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
                Device = new("identifier"),
                DigitalWallet =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            },
            Status = RealTimeDecisions::Status.Pending,
            TimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = RealTimeDecisions::Type.RealTimeDecision,
        };

        string expectedID = "real_time_decision_j76n2e810ezcg3zh5qtn";
        RealTimeDecisions::RealTimeDecisionCardAuthentication expectedCardAuthentication = new()
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };
        RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge expectedCardAuthenticationChallenge =
            new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            };
        RealTimeDecisions::RealTimeDecisionCardAuthorization expectedCardAuthorization = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = null,
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCity = "New York",
            MerchantCountry = "US",
            MerchantDescriptor = "AMAZON.COM",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                    StandInProcessingReason = null,
                    TerminalEntryCapability =
                        RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 10,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.NotSupported,
            PhysicalCardID = null,
            PresentmentAmount = 100,
            PresentmentCurrency = "USD",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 100,
            SettlementCurrency = "USD",
            TerminalID = "RCN5VNXS",
            UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Verification = new()
            {
                CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                CardholderAddress = new()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94131",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result =
                        RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiry expectedCardBalanceInquiry = new()
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory> expectedCategory =
            RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication expectedDigitalWalletAuthentication =
            new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            };
        RealTimeDecisions::RealTimeDecisionDigitalWalletToken expectedDigitalWalletToken = new()
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };
        ApiEnum<string, RealTimeDecisions::Status> expectedStatus =
            RealTimeDecisions::Status.Pending;
        DateTimeOffset expectedTimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, RealTimeDecisions::Type> expectedType =
            RealTimeDecisions::Type.RealTimeDecision;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCardAuthentication, model.CardAuthentication);
        Assert.Equal(expectedCardAuthenticationChallenge, model.CardAuthenticationChallenge);
        Assert.Equal(expectedCardAuthorization, model.CardAuthorization);
        Assert.Equal(expectedCardBalanceInquiry, model.CardBalanceInquiry);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDigitalWalletAuthentication, model.DigitalWalletAuthentication);
        Assert.Equal(expectedDigitalWalletToken, model.DigitalWalletToken);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTimeoutAt, model.TimeoutAt);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecision
        {
            ID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new()
            {
                AccessControlServerTransactionIdentifier =
                    "access_control_server_transaction_identifier",
                AccountID = "account_id",
                BillingAddressCity = "billing_address_city",
                BillingAddressCountry = "billing_address_country",
                BillingAddressLine1 = "billing_address_line1",
                BillingAddressLine2 = "billing_address_line2",
                BillingAddressLine3 = "billing_address_line3",
                BillingAddressPostalCode = "billing_address_postal_code",
                BillingAddressState = "billing_address_state",
                CardID = "card_id",
                CardholderEmail = "cardholder_email",
                CardholderName = "cardholder_name",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
                DeviceChannel = new()
                {
                    Browser = new()
                    {
                        AcceptHeader = "accept_header",
                        IPAddress = "ip_address",
                        JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                        Language = "language",
                        UserAgent = "user_agent",
                    },
                    Category = RealTimeDecisions::Category.App,
                    MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
                },
                DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCountry = "merchant_country",
                MerchantName = "merchant_name",
                MessageCategory = new()
                {
                    Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                    NonPayment = new(),
                    Payment = new()
                    {
                        PurchaseAmount = 0,
                        PurchaseAmountCardholderEstimated = 0,
                        PurchaseCurrency = "purchase_currency",
                        TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                    },
                },
                PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
                RequestorAuthenticationIndicator =
                    RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
                RequestorChallengeIndicator =
                    RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
                RequestorName = "requestor_name",
                RequestorUrl = "requestor_url",
                ShippingAddressCity = "shipping_address_city",
                ShippingAddressCountry = "shipping_address_country",
                ShippingAddressLine1 = "shipping_address_line1",
                ShippingAddressLine2 = "shipping_address_line2",
                ShippingAddressLine3 = "shipping_address_line3",
                ShippingAddressPostalCode = "shipping_address_postal_code",
                ShippingAddressState = "shipping_address_state",
                ThreeDSecureServerTransactionIdentifier =
                    "three_d_secure_server_transaction_identifier",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
            },
            CardAuthenticationChallenge = new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            },
            CardAuthorization = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
                Decline = new(
                    RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
                ),
                DigitalWalletTokenID = null,
                Direction = RealTimeDecisions::Direction.Settlement,
                MerchantAcceptorID = "5665270011000168",
                MerchantCategoryCode = "5734",
                MerchantCity = "New York",
                MerchantCountry = "US",
                MerchantDescriptor = "AMAZON.COM",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                NetworkDetails = new()
                {
                    Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                        PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                        StandInProcessingReason = null,
                        TerminalEntryCapability =
                            RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 10,
                PartialApprovalCapability =
                    RealTimeDecisions::PartialApprovalCapability.NotSupported,
                PhysicalCardID = null,
                PresentmentAmount = 100,
                PresentmentCurrency = "USD",
                ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
                RequestDetails = new()
                {
                    Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                    IncrementalAuthorization = new()
                    {
                        CardPaymentID = "card_payment_id",
                        OriginalCardAuthorizationID = "original_card_authorization_id",
                    },
                    InitialAuthorization = new(),
                },
                SettlementAmount = 100,
                SettlementCurrency = "USD",
                TerminalID = "RCN5VNXS",
                UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                Verification = new()
                {
                    CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "33 Liberty Street",
                        ActualPostalCode = "94131",
                        ProvidedLine1 = "33 Liberty Street",
                        ProvidedPostalCode = "94132",
                        Result =
                            RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            CardBalanceInquiry = new()
            {
                AccountID = "account_id",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
                DigitalWalletTokenID = "digital_wallet_token_id",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCity = "merchant_city",
                MerchantCountry = "merchant_country",
                MerchantDescriptor = "merchant_descriptor",
                MerchantPostalCode = "merchant_postal_code",
                MerchantState = "merchant_state",
                NetworkDetails = new()
                {
                    Category =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                        PointOfServiceEntryMode =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                        StandInProcessingReason =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                        TerminalEntryCapability =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 0,
                PhysicalCardID = "physical_card_id",
                TerminalID = "terminal_id",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
                Verification = new()
                {
                    CardVerificationCode = new(
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                    ),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "actual_line1",
                        ActualPostalCode = "actual_postal_code",
                        ProvidedLine1 = "provided_line1",
                        ProvidedPostalCode = "provided_postal_code",
                        Result =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            Category = RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DigitalWalletAuthentication = new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            },
            DigitalWalletToken = new()
            {
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
                Device = new("identifier"),
                DigitalWallet =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            },
            Status = RealTimeDecisions::Status.Pending,
            TimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = RealTimeDecisions::Type.RealTimeDecision,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecision
        {
            ID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new()
            {
                AccessControlServerTransactionIdentifier =
                    "access_control_server_transaction_identifier",
                AccountID = "account_id",
                BillingAddressCity = "billing_address_city",
                BillingAddressCountry = "billing_address_country",
                BillingAddressLine1 = "billing_address_line1",
                BillingAddressLine2 = "billing_address_line2",
                BillingAddressLine3 = "billing_address_line3",
                BillingAddressPostalCode = "billing_address_postal_code",
                BillingAddressState = "billing_address_state",
                CardID = "card_id",
                CardholderEmail = "cardholder_email",
                CardholderName = "cardholder_name",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
                DeviceChannel = new()
                {
                    Browser = new()
                    {
                        AcceptHeader = "accept_header",
                        IPAddress = "ip_address",
                        JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                        Language = "language",
                        UserAgent = "user_agent",
                    },
                    Category = RealTimeDecisions::Category.App,
                    MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
                },
                DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCountry = "merchant_country",
                MerchantName = "merchant_name",
                MessageCategory = new()
                {
                    Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                    NonPayment = new(),
                    Payment = new()
                    {
                        PurchaseAmount = 0,
                        PurchaseAmountCardholderEstimated = 0,
                        PurchaseCurrency = "purchase_currency",
                        TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                    },
                },
                PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
                RequestorAuthenticationIndicator =
                    RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
                RequestorChallengeIndicator =
                    RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
                RequestorName = "requestor_name",
                RequestorUrl = "requestor_url",
                ShippingAddressCity = "shipping_address_city",
                ShippingAddressCountry = "shipping_address_country",
                ShippingAddressLine1 = "shipping_address_line1",
                ShippingAddressLine2 = "shipping_address_line2",
                ShippingAddressLine3 = "shipping_address_line3",
                ShippingAddressPostalCode = "shipping_address_postal_code",
                ShippingAddressState = "shipping_address_state",
                ThreeDSecureServerTransactionIdentifier =
                    "three_d_secure_server_transaction_identifier",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
            },
            CardAuthenticationChallenge = new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            },
            CardAuthorization = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
                Decline = new(
                    RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
                ),
                DigitalWalletTokenID = null,
                Direction = RealTimeDecisions::Direction.Settlement,
                MerchantAcceptorID = "5665270011000168",
                MerchantCategoryCode = "5734",
                MerchantCity = "New York",
                MerchantCountry = "US",
                MerchantDescriptor = "AMAZON.COM",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                NetworkDetails = new()
                {
                    Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                        PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                        StandInProcessingReason = null,
                        TerminalEntryCapability =
                            RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 10,
                PartialApprovalCapability =
                    RealTimeDecisions::PartialApprovalCapability.NotSupported,
                PhysicalCardID = null,
                PresentmentAmount = 100,
                PresentmentCurrency = "USD",
                ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
                RequestDetails = new()
                {
                    Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                    IncrementalAuthorization = new()
                    {
                        CardPaymentID = "card_payment_id",
                        OriginalCardAuthorizationID = "original_card_authorization_id",
                    },
                    InitialAuthorization = new(),
                },
                SettlementAmount = 100,
                SettlementCurrency = "USD",
                TerminalID = "RCN5VNXS",
                UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                Verification = new()
                {
                    CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "33 Liberty Street",
                        ActualPostalCode = "94131",
                        ProvidedLine1 = "33 Liberty Street",
                        ProvidedPostalCode = "94132",
                        Result =
                            RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            CardBalanceInquiry = new()
            {
                AccountID = "account_id",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
                DigitalWalletTokenID = "digital_wallet_token_id",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCity = "merchant_city",
                MerchantCountry = "merchant_country",
                MerchantDescriptor = "merchant_descriptor",
                MerchantPostalCode = "merchant_postal_code",
                MerchantState = "merchant_state",
                NetworkDetails = new()
                {
                    Category =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                        PointOfServiceEntryMode =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                        StandInProcessingReason =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                        TerminalEntryCapability =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 0,
                PhysicalCardID = "physical_card_id",
                TerminalID = "terminal_id",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
                Verification = new()
                {
                    CardVerificationCode = new(
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                    ),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "actual_line1",
                        ActualPostalCode = "actual_postal_code",
                        ProvidedLine1 = "provided_line1",
                        ProvidedPostalCode = "provided_postal_code",
                        Result =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            Category = RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DigitalWalletAuthentication = new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            },
            DigitalWalletToken = new()
            {
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
                Device = new("identifier"),
                DigitalWallet =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            },
            Status = RealTimeDecisions::Status.Pending,
            TimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = RealTimeDecisions::Type.RealTimeDecision,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "real_time_decision_j76n2e810ezcg3zh5qtn";
        RealTimeDecisions::RealTimeDecisionCardAuthentication expectedCardAuthentication = new()
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };
        RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge expectedCardAuthenticationChallenge =
            new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            };
        RealTimeDecisions::RealTimeDecisionCardAuthorization expectedCardAuthorization = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_oubs0hwk5rn6knuecxg2",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = null,
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "5665270011000168",
            MerchantCategoryCode = "5734",
            MerchantCity = "New York",
            MerchantCountry = "US",
            MerchantDescriptor = "AMAZON.COM",
            MerchantPostalCode = "10045",
            MerchantState = "NY",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                    StandInProcessingReason = null,
                    TerminalEntryCapability =
                        RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 10,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.NotSupported,
            PhysicalCardID = null,
            PresentmentAmount = 100,
            PresentmentCurrency = "USD",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 100,
            SettlementCurrency = "USD",
            TerminalID = "RCN5VNXS",
            UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
            Verification = new()
            {
                CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                CardholderAddress = new()
                {
                    ActualLine1 = "33 Liberty Street",
                    ActualPostalCode = "94131",
                    ProvidedLine1 = "33 Liberty Street",
                    ProvidedPostalCode = "94132",
                    Result =
                        RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiry expectedCardBalanceInquiry = new()
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory> expectedCategory =
            RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication expectedDigitalWalletAuthentication =
            new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            };
        RealTimeDecisions::RealTimeDecisionDigitalWalletToken expectedDigitalWalletToken = new()
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };
        ApiEnum<string, RealTimeDecisions::Status> expectedStatus =
            RealTimeDecisions::Status.Pending;
        DateTimeOffset expectedTimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z");
        ApiEnum<string, RealTimeDecisions::Type> expectedType =
            RealTimeDecisions::Type.RealTimeDecision;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCardAuthentication, deserialized.CardAuthentication);
        Assert.Equal(expectedCardAuthenticationChallenge, deserialized.CardAuthenticationChallenge);
        Assert.Equal(expectedCardAuthorization, deserialized.CardAuthorization);
        Assert.Equal(expectedCardBalanceInquiry, deserialized.CardBalanceInquiry);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDigitalWalletAuthentication, deserialized.DigitalWalletAuthentication);
        Assert.Equal(expectedDigitalWalletToken, deserialized.DigitalWalletToken);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTimeoutAt, deserialized.TimeoutAt);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecision
        {
            ID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new()
            {
                AccessControlServerTransactionIdentifier =
                    "access_control_server_transaction_identifier",
                AccountID = "account_id",
                BillingAddressCity = "billing_address_city",
                BillingAddressCountry = "billing_address_country",
                BillingAddressLine1 = "billing_address_line1",
                BillingAddressLine2 = "billing_address_line2",
                BillingAddressLine3 = "billing_address_line3",
                BillingAddressPostalCode = "billing_address_postal_code",
                BillingAddressState = "billing_address_state",
                CardID = "card_id",
                CardholderEmail = "cardholder_email",
                CardholderName = "cardholder_name",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
                DeviceChannel = new()
                {
                    Browser = new()
                    {
                        AcceptHeader = "accept_header",
                        IPAddress = "ip_address",
                        JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                        Language = "language",
                        UserAgent = "user_agent",
                    },
                    Category = RealTimeDecisions::Category.App,
                    MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
                },
                DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCountry = "merchant_country",
                MerchantName = "merchant_name",
                MessageCategory = new()
                {
                    Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                    NonPayment = new(),
                    Payment = new()
                    {
                        PurchaseAmount = 0,
                        PurchaseAmountCardholderEstimated = 0,
                        PurchaseCurrency = "purchase_currency",
                        TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                    },
                },
                PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
                RequestorAuthenticationIndicator =
                    RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
                RequestorChallengeIndicator =
                    RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
                RequestorName = "requestor_name",
                RequestorUrl = "requestor_url",
                ShippingAddressCity = "shipping_address_city",
                ShippingAddressCountry = "shipping_address_country",
                ShippingAddressLine1 = "shipping_address_line1",
                ShippingAddressLine2 = "shipping_address_line2",
                ShippingAddressLine3 = "shipping_address_line3",
                ShippingAddressPostalCode = "shipping_address_postal_code",
                ShippingAddressState = "shipping_address_state",
                ThreeDSecureServerTransactionIdentifier =
                    "three_d_secure_server_transaction_identifier",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
            },
            CardAuthenticationChallenge = new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            },
            CardAuthorization = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
                Decline = new(
                    RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
                ),
                DigitalWalletTokenID = null,
                Direction = RealTimeDecisions::Direction.Settlement,
                MerchantAcceptorID = "5665270011000168",
                MerchantCategoryCode = "5734",
                MerchantCity = "New York",
                MerchantCountry = "US",
                MerchantDescriptor = "AMAZON.COM",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                NetworkDetails = new()
                {
                    Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                        PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                        StandInProcessingReason = null,
                        TerminalEntryCapability =
                            RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 10,
                PartialApprovalCapability =
                    RealTimeDecisions::PartialApprovalCapability.NotSupported,
                PhysicalCardID = null,
                PresentmentAmount = 100,
                PresentmentCurrency = "USD",
                ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
                RequestDetails = new()
                {
                    Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                    IncrementalAuthorization = new()
                    {
                        CardPaymentID = "card_payment_id",
                        OriginalCardAuthorizationID = "original_card_authorization_id",
                    },
                    InitialAuthorization = new(),
                },
                SettlementAmount = 100,
                SettlementCurrency = "USD",
                TerminalID = "RCN5VNXS",
                UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                Verification = new()
                {
                    CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "33 Liberty Street",
                        ActualPostalCode = "94131",
                        ProvidedLine1 = "33 Liberty Street",
                        ProvidedPostalCode = "94132",
                        Result =
                            RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            CardBalanceInquiry = new()
            {
                AccountID = "account_id",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
                DigitalWalletTokenID = "digital_wallet_token_id",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCity = "merchant_city",
                MerchantCountry = "merchant_country",
                MerchantDescriptor = "merchant_descriptor",
                MerchantPostalCode = "merchant_postal_code",
                MerchantState = "merchant_state",
                NetworkDetails = new()
                {
                    Category =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                        PointOfServiceEntryMode =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                        StandInProcessingReason =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                        TerminalEntryCapability =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 0,
                PhysicalCardID = "physical_card_id",
                TerminalID = "terminal_id",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
                Verification = new()
                {
                    CardVerificationCode = new(
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                    ),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "actual_line1",
                        ActualPostalCode = "actual_postal_code",
                        ProvidedLine1 = "provided_line1",
                        ProvidedPostalCode = "provided_postal_code",
                        Result =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            Category = RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DigitalWalletAuthentication = new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            },
            DigitalWalletToken = new()
            {
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
                Device = new("identifier"),
                DigitalWallet =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            },
            Status = RealTimeDecisions::Status.Pending,
            TimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = RealTimeDecisions::Type.RealTimeDecision,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecision
        {
            ID = "real_time_decision_j76n2e810ezcg3zh5qtn",
            CardAuthentication = new()
            {
                AccessControlServerTransactionIdentifier =
                    "access_control_server_transaction_identifier",
                AccountID = "account_id",
                BillingAddressCity = "billing_address_city",
                BillingAddressCountry = "billing_address_country",
                BillingAddressLine1 = "billing_address_line1",
                BillingAddressLine2 = "billing_address_line2",
                BillingAddressLine3 = "billing_address_line3",
                BillingAddressPostalCode = "billing_address_postal_code",
                BillingAddressState = "billing_address_state",
                CardID = "card_id",
                CardholderEmail = "cardholder_email",
                CardholderName = "cardholder_name",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
                DeviceChannel = new()
                {
                    Browser = new()
                    {
                        AcceptHeader = "accept_header",
                        IPAddress = "ip_address",
                        JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                        Language = "language",
                        UserAgent = "user_agent",
                    },
                    Category = RealTimeDecisions::Category.App,
                    MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
                },
                DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCountry = "merchant_country",
                MerchantName = "merchant_name",
                MessageCategory = new()
                {
                    Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                    NonPayment = new(),
                    Payment = new()
                    {
                        PurchaseAmount = 0,
                        PurchaseAmountCardholderEstimated = 0,
                        PurchaseCurrency = "purchase_currency",
                        TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                    },
                },
                PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
                RequestorAuthenticationIndicator =
                    RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
                RequestorChallengeIndicator =
                    RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
                RequestorName = "requestor_name",
                RequestorUrl = "requestor_url",
                ShippingAddressCity = "shipping_address_city",
                ShippingAddressCountry = "shipping_address_country",
                ShippingAddressLine1 = "shipping_address_line1",
                ShippingAddressLine2 = "shipping_address_line2",
                ShippingAddressLine3 = "shipping_address_line3",
                ShippingAddressPostalCode = "shipping_address_postal_code",
                ShippingAddressState = "shipping_address_state",
                ThreeDSecureServerTransactionIdentifier =
                    "three_d_secure_server_transaction_identifier",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
            },
            CardAuthenticationChallenge = new()
            {
                AccountID = "account_id",
                CardID = "card_id",
                CardPaymentID = "card_payment_id",
                OneTimeCode = "one_time_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
            },
            CardAuthorization = new()
            {
                AccountID = "account_in71c4amph0vgo2qllky",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_oubs0hwk5rn6knuecxg2",
                Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
                Decline = new(
                    RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
                ),
                DigitalWalletTokenID = null,
                Direction = RealTimeDecisions::Direction.Settlement,
                MerchantAcceptorID = "5665270011000168",
                MerchantCategoryCode = "5734",
                MerchantCity = "New York",
                MerchantCountry = "US",
                MerchantDescriptor = "AMAZON.COM",
                MerchantPostalCode = "10045",
                MerchantState = "NY",
                NetworkDetails = new()
                {
                    Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                        PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Manual,
                        StandInProcessingReason = null,
                        TerminalEntryCapability =
                            RealTimeDecisions::TerminalEntryCapability.MagneticStripe,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 10,
                PartialApprovalCapability =
                    RealTimeDecisions::PartialApprovalCapability.NotSupported,
                PhysicalCardID = null,
                PresentmentAmount = 100,
                PresentmentCurrency = "USD",
                ProcessingCategory = RealTimeDecisions::ProcessingCategory.Purchase,
                RequestDetails = new()
                {
                    Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                    IncrementalAuthorization = new()
                    {
                        CardPaymentID = "card_payment_id",
                        OriginalCardAuthorizationID = "original_card_authorization_id",
                    },
                    InitialAuthorization = new(),
                },
                SettlementAmount = 100,
                SettlementCurrency = "USD",
                TerminalID = "RCN5VNXS",
                UpcomingCardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                Verification = new()
                {
                    CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.Match),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "33 Liberty Street",
                        ActualPostalCode = "94131",
                        ProvidedLine1 = "33 Liberty Street",
                        ProvidedPostalCode = "94132",
                        Result =
                            RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            CardBalanceInquiry = new()
            {
                AccountID = "account_id",
                AdditionalAmounts = new()
                {
                    Clinic = new() { Amount = 0, Currency = "currency" },
                    Dental = new() { Amount = 0, Currency = "currency" },
                    Original = new() { Amount = 0, Currency = "currency" },
                    Prescription = new() { Amount = 0, Currency = "currency" },
                    Surcharge = new() { Amount = 0, Currency = "currency" },
                    TotalCumulative = new() { Amount = 0, Currency = "currency" },
                    TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                    Transit = new() { Amount = 0, Currency = "currency" },
                    Unknown = new() { Amount = 0, Currency = "currency" },
                    Vision = new() { Amount = 0, Currency = "currency" },
                },
                Approval = new(0),
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
                DigitalWalletTokenID = "digital_wallet_token_id",
                MerchantAcceptorID = "merchant_acceptor_id",
                MerchantCategoryCode = "merchant_category_code",
                MerchantCity = "merchant_city",
                MerchantCountry = "merchant_country",
                MerchantDescriptor = "merchant_descriptor",
                MerchantPostalCode = "merchant_postal_code",
                MerchantState = "merchant_state",
                NetworkDetails = new()
                {
                    Category =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                    Pulse = new(),
                    Visa = new()
                    {
                        ElectronicCommerceIndicator =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                        PointOfServiceEntryMode =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                        StandInProcessingReason =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                        TerminalEntryCapability =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                    },
                },
                NetworkIdentifiers = new()
                {
                    AuthorizationIdentificationResponse = null,
                    RetrievalReferenceNumber = "785867080153",
                    TraceNumber = "487941",
                    TransactionID = "627199945183184",
                },
                NetworkRiskScore = 0,
                PhysicalCardID = "physical_card_id",
                TerminalID = "terminal_id",
                UpcomingCardPaymentID = "upcoming_card_payment_id",
                Verification = new()
                {
                    CardVerificationCode = new(
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                    ),
                    CardholderAddress = new()
                    {
                        ActualLine1 = "actual_line1",
                        ActualPostalCode = "actual_postal_code",
                        ProvidedLine1 = "provided_line1",
                        ProvidedPostalCode = "provided_postal_code",
                        Result =
                            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                    },
                    CardholderName = new()
                    {
                        ProvidedFirstName = "provided_first_name",
                        ProvidedLastName = "provided_last_name",
                        ProvidedMiddleName = "provided_middle_name",
                    },
                },
            },
            Category = RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested,
            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            DigitalWalletAuthentication = new()
            {
                CardID = "card_id",
                Channel = RealTimeDecisions::Channel.Sms,
                DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
                Email = "email",
                OneTimePasscode = "one_time_passcode",
                Phone = "phone",
                Result =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
            },
            DigitalWalletToken = new()
            {
                CardID = "card_id",
                Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
                Device = new("identifier"),
                DigitalWallet =
                    RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
            },
            Status = RealTimeDecisions::Status.Pending,
            TimeoutAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
            Type = RealTimeDecisions::Type.RealTimeDecision,
        };

        RealTimeDecisions::RealTimeDecision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthenticationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthentication
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };

        string expectedAccessControlServerTransactionIdentifier =
            "access_control_server_transaction_identifier";
        string expectedAccountID = "account_id";
        string expectedBillingAddressCity = "billing_address_city";
        string expectedBillingAddressCountry = "billing_address_country";
        string expectedBillingAddressLine1 = "billing_address_line1";
        string expectedBillingAddressLine2 = "billing_address_line2";
        string expectedBillingAddressLine3 = "billing_address_line3";
        string expectedBillingAddressPostalCode = "billing_address_postal_code";
        string expectedBillingAddressState = "billing_address_state";
        string expectedCardID = "card_id";
        string expectedCardholderEmail = "cardholder_email";
        string expectedCardholderName = "cardholder_name";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve;
        RealTimeDecisions::DeviceChannel expectedDeviceChannel = new()
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };
        string expectedDirectoryServerTransactionIdentifier =
            "directory_server_transaction_identifier";
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantName = "merchant_name";
        RealTimeDecisions::MessageCategory expectedMessageCategory = new()
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };
        string expectedPriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id";
        ApiEnum<
            string,
            RealTimeDecisions::RequestorAuthenticationIndicator
        > expectedRequestorAuthenticationIndicator =
            RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction;
        ApiEnum<
            string,
            RealTimeDecisions::RequestorChallengeIndicator
        > expectedRequestorChallengeIndicator =
            RealTimeDecisions::RequestorChallengeIndicator.NoPreference;
        string expectedRequestorName = "requestor_name";
        string expectedRequestorUrl = "requestor_url";
        string expectedShippingAddressCity = "shipping_address_city";
        string expectedShippingAddressCountry = "shipping_address_country";
        string expectedShippingAddressLine1 = "shipping_address_line1";
        string expectedShippingAddressLine2 = "shipping_address_line2";
        string expectedShippingAddressLine3 = "shipping_address_line3";
        string expectedShippingAddressPostalCode = "shipping_address_postal_code";
        string expectedShippingAddressState = "shipping_address_state";
        string expectedThreeDSecureServerTransactionIdentifier =
            "three_d_secure_server_transaction_identifier";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";

        Assert.Equal(
            expectedAccessControlServerTransactionIdentifier,
            model.AccessControlServerTransactionIdentifier
        );
        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedBillingAddressCity, model.BillingAddressCity);
        Assert.Equal(expectedBillingAddressCountry, model.BillingAddressCountry);
        Assert.Equal(expectedBillingAddressLine1, model.BillingAddressLine1);
        Assert.Equal(expectedBillingAddressLine2, model.BillingAddressLine2);
        Assert.Equal(expectedBillingAddressLine3, model.BillingAddressLine3);
        Assert.Equal(expectedBillingAddressPostalCode, model.BillingAddressPostalCode);
        Assert.Equal(expectedBillingAddressState, model.BillingAddressState);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCardholderEmail, model.CardholderEmail);
        Assert.Equal(expectedCardholderName, model.CardholderName);
        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedDeviceChannel, model.DeviceChannel);
        Assert.Equal(
            expectedDirectoryServerTransactionIdentifier,
            model.DirectoryServerTransactionIdentifier
        );
        Assert.Equal(expectedMerchantAcceptorID, model.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedMerchantName, model.MerchantName);
        Assert.Equal(expectedMessageCategory, model.MessageCategory);
        Assert.Equal(
            expectedPriorAuthenticatedCardPaymentID,
            model.PriorAuthenticatedCardPaymentID
        );
        Assert.Equal(
            expectedRequestorAuthenticationIndicator,
            model.RequestorAuthenticationIndicator
        );
        Assert.Equal(expectedRequestorChallengeIndicator, model.RequestorChallengeIndicator);
        Assert.Equal(expectedRequestorName, model.RequestorName);
        Assert.Equal(expectedRequestorUrl, model.RequestorUrl);
        Assert.Equal(expectedShippingAddressCity, model.ShippingAddressCity);
        Assert.Equal(expectedShippingAddressCountry, model.ShippingAddressCountry);
        Assert.Equal(expectedShippingAddressLine1, model.ShippingAddressLine1);
        Assert.Equal(expectedShippingAddressLine2, model.ShippingAddressLine2);
        Assert.Equal(expectedShippingAddressLine3, model.ShippingAddressLine3);
        Assert.Equal(expectedShippingAddressPostalCode, model.ShippingAddressPostalCode);
        Assert.Equal(expectedShippingAddressState, model.ShippingAddressState);
        Assert.Equal(
            expectedThreeDSecureServerTransactionIdentifier,
            model.ThreeDSecureServerTransactionIdentifier
        );
        Assert.Equal(expectedUpcomingCardPaymentID, model.UpcomingCardPaymentID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthentication
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthentication>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthentication
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthentication>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccessControlServerTransactionIdentifier =
            "access_control_server_transaction_identifier";
        string expectedAccountID = "account_id";
        string expectedBillingAddressCity = "billing_address_city";
        string expectedBillingAddressCountry = "billing_address_country";
        string expectedBillingAddressLine1 = "billing_address_line1";
        string expectedBillingAddressLine2 = "billing_address_line2";
        string expectedBillingAddressLine3 = "billing_address_line3";
        string expectedBillingAddressPostalCode = "billing_address_postal_code";
        string expectedBillingAddressState = "billing_address_state";
        string expectedCardID = "card_id";
        string expectedCardholderEmail = "cardholder_email";
        string expectedCardholderName = "cardholder_name";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve;
        RealTimeDecisions::DeviceChannel expectedDeviceChannel = new()
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };
        string expectedDirectoryServerTransactionIdentifier =
            "directory_server_transaction_identifier";
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantName = "merchant_name";
        RealTimeDecisions::MessageCategory expectedMessageCategory = new()
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };
        string expectedPriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id";
        ApiEnum<
            string,
            RealTimeDecisions::RequestorAuthenticationIndicator
        > expectedRequestorAuthenticationIndicator =
            RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction;
        ApiEnum<
            string,
            RealTimeDecisions::RequestorChallengeIndicator
        > expectedRequestorChallengeIndicator =
            RealTimeDecisions::RequestorChallengeIndicator.NoPreference;
        string expectedRequestorName = "requestor_name";
        string expectedRequestorUrl = "requestor_url";
        string expectedShippingAddressCity = "shipping_address_city";
        string expectedShippingAddressCountry = "shipping_address_country";
        string expectedShippingAddressLine1 = "shipping_address_line1";
        string expectedShippingAddressLine2 = "shipping_address_line2";
        string expectedShippingAddressLine3 = "shipping_address_line3";
        string expectedShippingAddressPostalCode = "shipping_address_postal_code";
        string expectedShippingAddressState = "shipping_address_state";
        string expectedThreeDSecureServerTransactionIdentifier =
            "three_d_secure_server_transaction_identifier";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";

        Assert.Equal(
            expectedAccessControlServerTransactionIdentifier,
            deserialized.AccessControlServerTransactionIdentifier
        );
        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedBillingAddressCity, deserialized.BillingAddressCity);
        Assert.Equal(expectedBillingAddressCountry, deserialized.BillingAddressCountry);
        Assert.Equal(expectedBillingAddressLine1, deserialized.BillingAddressLine1);
        Assert.Equal(expectedBillingAddressLine2, deserialized.BillingAddressLine2);
        Assert.Equal(expectedBillingAddressLine3, deserialized.BillingAddressLine3);
        Assert.Equal(expectedBillingAddressPostalCode, deserialized.BillingAddressPostalCode);
        Assert.Equal(expectedBillingAddressState, deserialized.BillingAddressState);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCardholderEmail, deserialized.CardholderEmail);
        Assert.Equal(expectedCardholderName, deserialized.CardholderName);
        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedDeviceChannel, deserialized.DeviceChannel);
        Assert.Equal(
            expectedDirectoryServerTransactionIdentifier,
            deserialized.DirectoryServerTransactionIdentifier
        );
        Assert.Equal(expectedMerchantAcceptorID, deserialized.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedMerchantName, deserialized.MerchantName);
        Assert.Equal(expectedMessageCategory, deserialized.MessageCategory);
        Assert.Equal(
            expectedPriorAuthenticatedCardPaymentID,
            deserialized.PriorAuthenticatedCardPaymentID
        );
        Assert.Equal(
            expectedRequestorAuthenticationIndicator,
            deserialized.RequestorAuthenticationIndicator
        );
        Assert.Equal(expectedRequestorChallengeIndicator, deserialized.RequestorChallengeIndicator);
        Assert.Equal(expectedRequestorName, deserialized.RequestorName);
        Assert.Equal(expectedRequestorUrl, deserialized.RequestorUrl);
        Assert.Equal(expectedShippingAddressCity, deserialized.ShippingAddressCity);
        Assert.Equal(expectedShippingAddressCountry, deserialized.ShippingAddressCountry);
        Assert.Equal(expectedShippingAddressLine1, deserialized.ShippingAddressLine1);
        Assert.Equal(expectedShippingAddressLine2, deserialized.ShippingAddressLine2);
        Assert.Equal(expectedShippingAddressLine3, deserialized.ShippingAddressLine3);
        Assert.Equal(expectedShippingAddressPostalCode, deserialized.ShippingAddressPostalCode);
        Assert.Equal(expectedShippingAddressState, deserialized.ShippingAddressState);
        Assert.Equal(
            expectedThreeDSecureServerTransactionIdentifier,
            deserialized.ThreeDSecureServerTransactionIdentifier
        );
        Assert.Equal(expectedUpcomingCardPaymentID, deserialized.UpcomingCardPaymentID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthentication
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthentication
        {
            AccessControlServerTransactionIdentifier =
                "access_control_server_transaction_identifier",
            AccountID = "account_id",
            BillingAddressCity = "billing_address_city",
            BillingAddressCountry = "billing_address_country",
            BillingAddressLine1 = "billing_address_line1",
            BillingAddressLine2 = "billing_address_line2",
            BillingAddressLine3 = "billing_address_line3",
            BillingAddressPostalCode = "billing_address_postal_code",
            BillingAddressState = "billing_address_state",
            CardID = "card_id",
            CardholderEmail = "cardholder_email",
            CardholderName = "cardholder_name",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve,
            DeviceChannel = new()
            {
                Browser = new()
                {
                    AcceptHeader = "accept_header",
                    IPAddress = "ip_address",
                    JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                    Language = "language",
                    UserAgent = "user_agent",
                },
                Category = RealTimeDecisions::Category.App,
                MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
            },
            DirectoryServerTransactionIdentifier = "directory_server_transaction_identifier",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCountry = "merchant_country",
            MerchantName = "merchant_name",
            MessageCategory = new()
            {
                Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
                NonPayment = new(),
                Payment = new()
                {
                    PurchaseAmount = 0,
                    PurchaseAmountCardholderEstimated = 0,
                    PurchaseCurrency = "purchase_currency",
                    TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
                },
            },
            PriorAuthenticatedCardPaymentID = "prior_authenticated_card_payment_id",
            RequestorAuthenticationIndicator =
                RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction,
            RequestorChallengeIndicator =
                RealTimeDecisions::RequestorChallengeIndicator.NoPreference,
            RequestorName = "requestor_name",
            RequestorUrl = "requestor_url",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressLine1 = "shipping_address_line1",
            ShippingAddressLine2 = "shipping_address_line2",
            ShippingAddressLine3 = "shipping_address_line3",
            ShippingAddressPostalCode = "shipping_address_postal_code",
            ShippingAddressState = "shipping_address_state",
            ThreeDSecureServerTransactionIdentifier =
                "three_d_secure_server_transaction_identifier",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
        };

        RealTimeDecisions::RealTimeDecisionCardAuthentication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthenticationDecisionTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Challenge)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Deny)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Challenge)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision.Deny)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeviceChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::DeviceChannel
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };

        RealTimeDecisions::Browser expectedBrowser = new()
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };
        ApiEnum<string, RealTimeDecisions::Category> expectedCategory =
            RealTimeDecisions::Category.App;
        RealTimeDecisions::MerchantInitiated expectedMerchantInitiated = new(
            RealTimeDecisions::Indicator.RecurringTransaction
        );

        Assert.Equal(expectedBrowser, model.Browser);
        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedMerchantInitiated, model.MerchantInitiated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::DeviceChannel
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::DeviceChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::DeviceChannel
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::DeviceChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RealTimeDecisions::Browser expectedBrowser = new()
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };
        ApiEnum<string, RealTimeDecisions::Category> expectedCategory =
            RealTimeDecisions::Category.App;
        RealTimeDecisions::MerchantInitiated expectedMerchantInitiated = new(
            RealTimeDecisions::Indicator.RecurringTransaction
        );

        Assert.Equal(expectedBrowser, deserialized.Browser);
        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedMerchantInitiated, deserialized.MerchantInitiated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::DeviceChannel
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::DeviceChannel
        {
            Browser = new()
            {
                AcceptHeader = "accept_header",
                IPAddress = "ip_address",
                JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
                Language = "language",
                UserAgent = "user_agent",
            },
            Category = RealTimeDecisions::Category.App,
            MerchantInitiated = new(RealTimeDecisions::Indicator.RecurringTransaction),
        };

        RealTimeDecisions::DeviceChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrowserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Browser
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };

        string expectedAcceptHeader = "accept_header";
        string expectedIPAddress = "ip_address";
        ApiEnum<string, RealTimeDecisions::JavascriptEnabled> expectedJavascriptEnabled =
            RealTimeDecisions::JavascriptEnabled.Enabled;
        string expectedLanguage = "language";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedAcceptHeader, model.AcceptHeader);
        Assert.Equal(expectedIPAddress, model.IPAddress);
        Assert.Equal(expectedJavascriptEnabled, model.JavascriptEnabled);
        Assert.Equal(expectedLanguage, model.Language);
        Assert.Equal(expectedUserAgent, model.UserAgent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Browser
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Browser>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Browser
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Browser>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAcceptHeader = "accept_header";
        string expectedIPAddress = "ip_address";
        ApiEnum<string, RealTimeDecisions::JavascriptEnabled> expectedJavascriptEnabled =
            RealTimeDecisions::JavascriptEnabled.Enabled;
        string expectedLanguage = "language";
        string expectedUserAgent = "user_agent";

        Assert.Equal(expectedAcceptHeader, deserialized.AcceptHeader);
        Assert.Equal(expectedIPAddress, deserialized.IPAddress);
        Assert.Equal(expectedJavascriptEnabled, deserialized.JavascriptEnabled);
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.Equal(expectedUserAgent, deserialized.UserAgent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Browser
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Browser
        {
            AcceptHeader = "accept_header",
            IPAddress = "ip_address",
            JavascriptEnabled = RealTimeDecisions::JavascriptEnabled.Enabled,
            Language = "language",
            UserAgent = "user_agent",
        };

        RealTimeDecisions::Browser copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JavascriptEnabledTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::JavascriptEnabled.Enabled)]
    [InlineData(RealTimeDecisions::JavascriptEnabled.Disabled)]
    public void Validation_Works(RealTimeDecisions::JavascriptEnabled rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::JavascriptEnabled> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::JavascriptEnabled>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::JavascriptEnabled.Enabled)]
    [InlineData(RealTimeDecisions::JavascriptEnabled.Disabled)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::JavascriptEnabled rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::JavascriptEnabled> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::JavascriptEnabled>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::JavascriptEnabled>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::JavascriptEnabled>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Category.App)]
    [InlineData(RealTimeDecisions::Category.Browser)]
    [InlineData(RealTimeDecisions::Category.ThreeDSRequestorInitiated)]
    public void Validation_Works(RealTimeDecisions::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Category.App)]
    [InlineData(RealTimeDecisions::Category.Browser)]
    [InlineData(RealTimeDecisions::Category.ThreeDSRequestorInitiated)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MerchantInitiatedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::MerchantInitiated
        {
            Indicator = RealTimeDecisions::Indicator.RecurringTransaction,
        };

        ApiEnum<string, RealTimeDecisions::Indicator> expectedIndicator =
            RealTimeDecisions::Indicator.RecurringTransaction;

        Assert.Equal(expectedIndicator, model.Indicator);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::MerchantInitiated
        {
            Indicator = RealTimeDecisions::Indicator.RecurringTransaction,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::MerchantInitiated>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::MerchantInitiated
        {
            Indicator = RealTimeDecisions::Indicator.RecurringTransaction,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::MerchantInitiated>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimeDecisions::Indicator> expectedIndicator =
            RealTimeDecisions::Indicator.RecurringTransaction;

        Assert.Equal(expectedIndicator, deserialized.Indicator);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::MerchantInitiated
        {
            Indicator = RealTimeDecisions::Indicator.RecurringTransaction,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::MerchantInitiated
        {
            Indicator = RealTimeDecisions::Indicator.RecurringTransaction,
        };

        RealTimeDecisions::MerchantInitiated copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IndicatorTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Indicator.RecurringTransaction)]
    [InlineData(RealTimeDecisions::Indicator.InstallmentTransaction)]
    [InlineData(RealTimeDecisions::Indicator.AddCard)]
    [InlineData(RealTimeDecisions::Indicator.MaintainCardInformation)]
    [InlineData(RealTimeDecisions::Indicator.AccountVerification)]
    [InlineData(RealTimeDecisions::Indicator.SplitDelayedShipment)]
    [InlineData(RealTimeDecisions::Indicator.TopUp)]
    [InlineData(RealTimeDecisions::Indicator.MailOrder)]
    [InlineData(RealTimeDecisions::Indicator.TelephoneOrder)]
    [InlineData(RealTimeDecisions::Indicator.WhitelistStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.OtherPayment)]
    [InlineData(RealTimeDecisions::Indicator.BillingAgreement)]
    [InlineData(RealTimeDecisions::Indicator.DeviceBindingStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.CardSecurityCodeStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.DelayedShipment)]
    [InlineData(RealTimeDecisions::Indicator.SplitPayment)]
    [InlineData(RealTimeDecisions::Indicator.FidoCredentialDeletion)]
    [InlineData(RealTimeDecisions::Indicator.FidoCredentialRegistration)]
    [InlineData(RealTimeDecisions::Indicator.DecoupledAuthenticationFallback)]
    public void Validation_Works(RealTimeDecisions::Indicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Indicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Indicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Indicator.RecurringTransaction)]
    [InlineData(RealTimeDecisions::Indicator.InstallmentTransaction)]
    [InlineData(RealTimeDecisions::Indicator.AddCard)]
    [InlineData(RealTimeDecisions::Indicator.MaintainCardInformation)]
    [InlineData(RealTimeDecisions::Indicator.AccountVerification)]
    [InlineData(RealTimeDecisions::Indicator.SplitDelayedShipment)]
    [InlineData(RealTimeDecisions::Indicator.TopUp)]
    [InlineData(RealTimeDecisions::Indicator.MailOrder)]
    [InlineData(RealTimeDecisions::Indicator.TelephoneOrder)]
    [InlineData(RealTimeDecisions::Indicator.WhitelistStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.OtherPayment)]
    [InlineData(RealTimeDecisions::Indicator.BillingAgreement)]
    [InlineData(RealTimeDecisions::Indicator.DeviceBindingStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.CardSecurityCodeStatusCheck)]
    [InlineData(RealTimeDecisions::Indicator.DelayedShipment)]
    [InlineData(RealTimeDecisions::Indicator.SplitPayment)]
    [InlineData(RealTimeDecisions::Indicator.FidoCredentialDeletion)]
    [InlineData(RealTimeDecisions::Indicator.FidoCredentialRegistration)]
    [InlineData(RealTimeDecisions::Indicator.DecoupledAuthenticationFallback)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Indicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Indicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::Indicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Indicator>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::Indicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class MessageCategoryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::MessageCategory
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };

        ApiEnum<string, RealTimeDecisions::MessageCategoryCategory> expectedCategory =
            RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication;
        RealTimeDecisions::NonPayment expectedNonPayment = new();
        RealTimeDecisions::Payment expectedPayment = new()
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedNonPayment, model.NonPayment);
        Assert.Equal(expectedPayment, model.Payment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::MessageCategory
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::MessageCategory>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::MessageCategory
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::MessageCategory>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimeDecisions::MessageCategoryCategory> expectedCategory =
            RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication;
        RealTimeDecisions::NonPayment expectedNonPayment = new();
        RealTimeDecisions::Payment expectedPayment = new()
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedNonPayment, deserialized.NonPayment);
        Assert.Equal(expectedPayment, deserialized.Payment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::MessageCategory
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::MessageCategory
        {
            Category = RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication,
            NonPayment = new(),
            Payment = new()
            {
                PurchaseAmount = 0,
                PurchaseAmountCardholderEstimated = 0,
                PurchaseCurrency = "purchase_currency",
                TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
            },
        };

        RealTimeDecisions::MessageCategory copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MessageCategoryCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication)]
    [InlineData(RealTimeDecisions::MessageCategoryCategory.NonPaymentAuthentication)]
    public void Validation_Works(RealTimeDecisions::MessageCategoryCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::MessageCategoryCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::MessageCategoryCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::MessageCategoryCategory.PaymentAuthentication)]
    [InlineData(RealTimeDecisions::MessageCategoryCategory.NonPaymentAuthentication)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::MessageCategoryCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::MessageCategoryCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::MessageCategoryCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::MessageCategoryCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::MessageCategoryCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NonPaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NonPayment { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NonPayment { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NonPayment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::NonPayment { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NonPayment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::NonPayment { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::NonPayment { };

        RealTimeDecisions::NonPayment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Payment
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        long expectedPurchaseAmount = 0;
        long expectedPurchaseAmountCardholderEstimated = 0;
        string expectedPurchaseCurrency = "purchase_currency";
        ApiEnum<string, RealTimeDecisions::TransactionType> expectedTransactionType =
            RealTimeDecisions::TransactionType.GoodsServicePurchase;

        Assert.Equal(expectedPurchaseAmount, model.PurchaseAmount);
        Assert.Equal(
            expectedPurchaseAmountCardholderEstimated,
            model.PurchaseAmountCardholderEstimated
        );
        Assert.Equal(expectedPurchaseCurrency, model.PurchaseCurrency);
        Assert.Equal(expectedTransactionType, model.TransactionType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Payment
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Payment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Payment
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Payment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedPurchaseAmount = 0;
        long expectedPurchaseAmountCardholderEstimated = 0;
        string expectedPurchaseCurrency = "purchase_currency";
        ApiEnum<string, RealTimeDecisions::TransactionType> expectedTransactionType =
            RealTimeDecisions::TransactionType.GoodsServicePurchase;

        Assert.Equal(expectedPurchaseAmount, deserialized.PurchaseAmount);
        Assert.Equal(
            expectedPurchaseAmountCardholderEstimated,
            deserialized.PurchaseAmountCardholderEstimated
        );
        Assert.Equal(expectedPurchaseCurrency, deserialized.PurchaseCurrency);
        Assert.Equal(expectedTransactionType, deserialized.TransactionType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Payment
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Payment
        {
            PurchaseAmount = 0,
            PurchaseAmountCardholderEstimated = 0,
            PurchaseCurrency = "purchase_currency",
            TransactionType = RealTimeDecisions::TransactionType.GoodsServicePurchase,
        };

        RealTimeDecisions::Payment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransactionTypeTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::TransactionType.GoodsServicePurchase)]
    [InlineData(RealTimeDecisions::TransactionType.CheckAcceptance)]
    [InlineData(RealTimeDecisions::TransactionType.AccountFunding)]
    [InlineData(RealTimeDecisions::TransactionType.QuasiCashTransaction)]
    [InlineData(RealTimeDecisions::TransactionType.PrepaidActivationAndLoad)]
    public void Validation_Works(RealTimeDecisions::TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::TransactionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::TransactionType.GoodsServicePurchase)]
    [InlineData(RealTimeDecisions::TransactionType.CheckAcceptance)]
    [InlineData(RealTimeDecisions::TransactionType.AccountFunding)]
    [InlineData(RealTimeDecisions::TransactionType.QuasiCashTransaction)]
    [InlineData(RealTimeDecisions::TransactionType.PrepaidActivationAndLoad)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::TransactionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::TransactionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::TransactionType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TransactionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RequestorAuthenticationIndicatorTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.RecurringTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.InstallmentTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.AddCard)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.MaintainCard)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.EmvTokenCardholderVerification)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.BillingAgreement)]
    public void Validation_Works(RealTimeDecisions::RequestorAuthenticationIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.PaymentTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.RecurringTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.InstallmentTransaction)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.AddCard)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.MaintainCard)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.EmvTokenCardholderVerification)]
    [InlineData(RealTimeDecisions::RequestorAuthenticationIndicator.BillingAgreement)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RequestorAuthenticationIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorAuthenticationIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RequestorChallengeIndicatorTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoPreference)]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequested)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference
    )]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequestedMandate)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed
    )]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed
    )]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired
    )]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired
    )]
    public void Validation_Works(RealTimeDecisions::RequestorChallengeIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoPreference)]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequested)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequested3dsRequestorPreference
    )]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequestedMandate)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedTransactionalRiskAnalysisAlreadyPerformed
    )]
    [InlineData(RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedDataShareOnly)]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedStrongConsumerAuthenticationAlreadyPerformed
    )]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.NoChallengeRequestedUtilizeWhitelistExemptionIfNoChallengeRequired
    )]
    [InlineData(
        RealTimeDecisions::RequestorChallengeIndicator.ChallengeRequestedWhitelistPromptRequestedIfChallengeRequired
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RequestorChallengeIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestorChallengeIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardAuthenticationChallengeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge
        {
            AccountID = "account_id",
            CardID = "card_id",
            CardPaymentID = "card_payment_id",
            OneTimeCode = "one_time_code",
            Result = RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
        };

        string expectedAccountID = "account_id";
        string expectedCardID = "card_id";
        string expectedCardPaymentID = "card_payment_id";
        string expectedOneTimeCode = "one_time_code";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success;

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedCardPaymentID, model.CardPaymentID);
        Assert.Equal(expectedOneTimeCode, model.OneTimeCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge
        {
            AccountID = "account_id",
            CardID = "card_id",
            CardPaymentID = "card_payment_id",
            OneTimeCode = "one_time_code",
            Result = RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge
        {
            AccountID = "account_id",
            CardID = "card_id",
            CardPaymentID = "card_payment_id",
            OneTimeCode = "one_time_code",
            Result = RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        string expectedCardID = "card_id";
        string expectedCardPaymentID = "card_payment_id";
        string expectedOneTimeCode = "one_time_code";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success;

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedCardPaymentID, deserialized.CardPaymentID);
        Assert.Equal(expectedOneTimeCode, deserialized.OneTimeCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge
        {
            AccountID = "account_id",
            CardID = "card_id",
            CardPaymentID = "card_payment_id",
            OneTimeCode = "one_time_code",
            Result = RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge
        {
            AccountID = "account_id",
            CardID = "card_id",
            CardPaymentID = "card_payment_id",
            OneTimeCode = "one_time_code",
            Result = RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success,
        };

        RealTimeDecisions::RealTimeDecisionCardAuthenticationChallenge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthenticationChallengeResultTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Failure)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Success)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult.Failure)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthenticationChallengeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorization
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = "digital_wallet_token_id",
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::StandInProcessingReason.IssuerError,
                    TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.Supported,
            PhysicalCardID = "physical_card_id",
            PresentmentAmount = 0,
            PresentmentCurrency = "presentment_currency",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.AccountFunding,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 0,
            SettlementCurrency = "settlement_currency",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::CardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string expectedAccountID = "account_id";
        RealTimeDecisions::AdditionalAmounts expectedAdditionalAmounts = new()
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };
        RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval expectedApproval = new(0);
        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve;
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline expectedDecline = new(
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
        );
        string expectedDigitalWalletTokenID = "digital_wallet_token_id";
        ApiEnum<string, RealTimeDecisions::Direction> expectedDirection =
            RealTimeDecisions::Direction.Settlement;
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCity = "merchant_city";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantDescriptor = "merchant_descriptor";
        string expectedMerchantPostalCode = "merchant_postal_code";
        string expectedMerchantState = "merchant_state";
        RealTimeDecisions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };
        RealTimeDecisions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 0;
        ApiEnum<
            string,
            RealTimeDecisions::PartialApprovalCapability
        > expectedPartialApprovalCapability =
            RealTimeDecisions::PartialApprovalCapability.Supported;
        string expectedPhysicalCardID = "physical_card_id";
        long expectedPresentmentAmount = 0;
        string expectedPresentmentCurrency = "presentment_currency";
        ApiEnum<string, RealTimeDecisions::ProcessingCategory> expectedProcessingCategory =
            RealTimeDecisions::ProcessingCategory.AccountFunding;
        RealTimeDecisions::RequestDetails expectedRequestDetails = new()
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };
        long expectedSettlementAmount = 0;
        string expectedSettlementCurrency = "settlement_currency";
        string expectedTerminalID = "terminal_id";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";
        RealTimeDecisions::Verification expectedVerification = new()
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAdditionalAmounts, model.AdditionalAmounts);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedDecline, model.Decline);
        Assert.Equal(expectedDigitalWalletTokenID, model.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, model.Direction);
        Assert.Equal(expectedMerchantAcceptorID, model.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, model.MerchantCity);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, model.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, model.MerchantState);
        Assert.Equal(expectedNetworkDetails, model.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, model.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, model.NetworkRiskScore);
        Assert.Equal(expectedPartialApprovalCapability, model.PartialApprovalCapability);
        Assert.Equal(expectedPhysicalCardID, model.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, model.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, model.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, model.ProcessingCategory);
        Assert.Equal(expectedRequestDetails, model.RequestDetails);
        Assert.Equal(expectedSettlementAmount, model.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, model.SettlementCurrency);
        Assert.Equal(expectedTerminalID, model.TerminalID);
        Assert.Equal(expectedUpcomingCardPaymentID, model.UpcomingCardPaymentID);
        Assert.Equal(expectedVerification, model.Verification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorization
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = "digital_wallet_token_id",
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::StandInProcessingReason.IssuerError,
                    TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.Supported,
            PhysicalCardID = "physical_card_id",
            PresentmentAmount = 0,
            PresentmentCurrency = "presentment_currency",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.AccountFunding,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 0,
            SettlementCurrency = "settlement_currency",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::CardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorization>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorization
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = "digital_wallet_token_id",
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::StandInProcessingReason.IssuerError,
                    TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.Supported,
            PhysicalCardID = "physical_card_id",
            PresentmentAmount = 0,
            PresentmentCurrency = "presentment_currency",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.AccountFunding,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 0,
            SettlementCurrency = "settlement_currency",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::CardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorization>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        RealTimeDecisions::AdditionalAmounts expectedAdditionalAmounts = new()
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };
        RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval expectedApproval = new(0);
        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve;
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline expectedDecline = new(
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
        );
        string expectedDigitalWalletTokenID = "digital_wallet_token_id";
        ApiEnum<string, RealTimeDecisions::Direction> expectedDirection =
            RealTimeDecisions::Direction.Settlement;
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCity = "merchant_city";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantDescriptor = "merchant_descriptor";
        string expectedMerchantPostalCode = "merchant_postal_code";
        string expectedMerchantState = "merchant_state";
        RealTimeDecisions::NetworkDetails expectedNetworkDetails = new()
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };
        RealTimeDecisions::NetworkIdentifiers expectedNetworkIdentifiers = new()
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };
        long expectedNetworkRiskScore = 0;
        ApiEnum<
            string,
            RealTimeDecisions::PartialApprovalCapability
        > expectedPartialApprovalCapability =
            RealTimeDecisions::PartialApprovalCapability.Supported;
        string expectedPhysicalCardID = "physical_card_id";
        long expectedPresentmentAmount = 0;
        string expectedPresentmentCurrency = "presentment_currency";
        ApiEnum<string, RealTimeDecisions::ProcessingCategory> expectedProcessingCategory =
            RealTimeDecisions::ProcessingCategory.AccountFunding;
        RealTimeDecisions::RequestDetails expectedRequestDetails = new()
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };
        long expectedSettlementAmount = 0;
        string expectedSettlementCurrency = "settlement_currency";
        string expectedTerminalID = "terminal_id";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";
        RealTimeDecisions::Verification expectedVerification = new()
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAdditionalAmounts, deserialized.AdditionalAmounts);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedDecline, deserialized.Decline);
        Assert.Equal(expectedDigitalWalletTokenID, deserialized.DigitalWalletTokenID);
        Assert.Equal(expectedDirection, deserialized.Direction);
        Assert.Equal(expectedMerchantAcceptorID, deserialized.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, deserialized.MerchantCity);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, deserialized.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, deserialized.MerchantState);
        Assert.Equal(expectedNetworkDetails, deserialized.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, deserialized.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, deserialized.NetworkRiskScore);
        Assert.Equal(expectedPartialApprovalCapability, deserialized.PartialApprovalCapability);
        Assert.Equal(expectedPhysicalCardID, deserialized.PhysicalCardID);
        Assert.Equal(expectedPresentmentAmount, deserialized.PresentmentAmount);
        Assert.Equal(expectedPresentmentCurrency, deserialized.PresentmentCurrency);
        Assert.Equal(expectedProcessingCategory, deserialized.ProcessingCategory);
        Assert.Equal(expectedRequestDetails, deserialized.RequestDetails);
        Assert.Equal(expectedSettlementAmount, deserialized.SettlementAmount);
        Assert.Equal(expectedSettlementCurrency, deserialized.SettlementCurrency);
        Assert.Equal(expectedTerminalID, deserialized.TerminalID);
        Assert.Equal(expectedUpcomingCardPaymentID, deserialized.UpcomingCardPaymentID);
        Assert.Equal(expectedVerification, deserialized.Verification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorization
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = "digital_wallet_token_id",
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::StandInProcessingReason.IssuerError,
                    TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.Supported,
            PhysicalCardID = "physical_card_id",
            PresentmentAmount = 0,
            PresentmentCurrency = "presentment_currency",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.AccountFunding,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 0,
            SettlementCurrency = "settlement_currency",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::CardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorization
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve,
            Decline = new(
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
            ),
            DigitalWalletTokenID = "digital_wallet_token_id",
            Direction = RealTimeDecisions::Direction.Settlement,
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::StandInProcessingReason.IssuerError,
                    TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PartialApprovalCapability = RealTimeDecisions::PartialApprovalCapability.Supported,
            PhysicalCardID = "physical_card_id",
            PresentmentAmount = 0,
            PresentmentCurrency = "presentment_currency",
            ProcessingCategory = RealTimeDecisions::ProcessingCategory.AccountFunding,
            RequestDetails = new()
            {
                Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
                IncrementalAuthorization = new()
                {
                    CardPaymentID = "card_payment_id",
                    OriginalCardAuthorizationID = "original_card_authorization_id",
                },
                InitialAuthorization = new(),
            },
            SettlementAmount = 0,
            SettlementCurrency = "settlement_currency",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::CardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        RealTimeDecisions::RealTimeDecisionCardAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AdditionalAmountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        RealTimeDecisions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Original expectedOriginal = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, model.Clinic);
        Assert.Equal(expectedDental, model.Dental);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedPrescription, model.Prescription);
        Assert.Equal(expectedSurcharge, model.Surcharge);
        Assert.Equal(expectedTotalCumulative, model.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, model.TotalHealthcare);
        Assert.Equal(expectedTransit, model.Transit);
        Assert.Equal(expectedUnknown, model.Unknown);
        Assert.Equal(expectedVision, model.Vision);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::AdditionalAmounts>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::AdditionalAmounts>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RealTimeDecisions::Clinic expectedClinic = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Dental expectedDental = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Original expectedOriginal = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Prescription expectedPrescription = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::Surcharge expectedSurcharge = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::TotalCumulative expectedTotalCumulative = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::TotalHealthcare expectedTotalHealthcare = new()
        {
            Amount = 0,
            Currency = "currency",
        };
        RealTimeDecisions::Transit expectedTransit = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Unknown expectedUnknown = new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::Vision expectedVision = new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, deserialized.Clinic);
        Assert.Equal(expectedDental, deserialized.Dental);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedPrescription, deserialized.Prescription);
        Assert.Equal(expectedSurcharge, deserialized.Surcharge);
        Assert.Equal(expectedTotalCumulative, deserialized.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, deserialized.TotalHealthcare);
        Assert.Equal(expectedTransit, deserialized.Transit);
        Assert.Equal(expectedUnknown, deserialized.Unknown);
        Assert.Equal(expectedVision, deserialized.Vision);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::AdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        RealTimeDecisions::AdditionalAmounts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClinicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Clinic { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Clinic { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Clinic>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Clinic { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Clinic>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Clinic { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Clinic { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Clinic copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DentalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Dental { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Dental { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Dental>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Dental { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Dental>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Dental { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Dental { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Dental copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class OriginalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Original { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Original { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Original>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Original { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Original>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Original { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Original { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Original copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PrescriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Prescription { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Prescription { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Prescription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Prescription { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Prescription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Prescription { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Prescription { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Prescription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SurchargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Surcharge { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Surcharge { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Surcharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Surcharge { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Surcharge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Surcharge { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Surcharge { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Surcharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalCumulativeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::TotalCumulative { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::TotalCumulative { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::TotalCumulative>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::TotalCumulative { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::TotalCumulative>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::TotalCumulative { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::TotalCumulative { Amount = 0, Currency = "currency" };

        RealTimeDecisions::TotalCumulative copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TotalHealthcareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::TotalHealthcare { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::TotalHealthcare>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::TotalHealthcare { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::TotalHealthcare>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::TotalHealthcare { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::TotalHealthcare { Amount = 0, Currency = "currency" };

        RealTimeDecisions::TotalHealthcare copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TransitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Transit { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Transit { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Transit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Transit { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Transit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Transit { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Transit { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Transit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Unknown { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Unknown { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Unknown>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Unknown { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Unknown>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Unknown { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Unknown { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Unknown copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Vision { Amount = 0, Currency = "currency" };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Vision { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Vision>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Vision { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Vision>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Vision { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Vision { Amount = 0, Currency = "currency" };

        RealTimeDecisions::Vision copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthorizationApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval
        {
            PartialAmount = 0,
        };

        long expectedPartialAmount = 0;

        Assert.Equal(expectedPartialAmount, model.PartialAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval
        {
            PartialAmount = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval
        {
            PartialAmount = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedPartialAmount = 0;

        Assert.Equal(expectedPartialAmount, deserialized.PartialAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval
        {
            PartialAmount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval
        {
            PartialAmount = 0,
        };

        RealTimeDecisions::RealTimeDecisionCardAuthorizationApproval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthorizationDecisionTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Decline)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision.Decline)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardAuthorizationDeclineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline
        {
            Reason =
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
        };

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason
        > expectedReason =
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline
        {
            Reason =
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline
        {
            Reason =
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason
        > expectedReason =
            RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline
        {
            Reason =
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline
        {
            Reason =
                RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds,
        };

        RealTimeDecisions::RealTimeDecisionCardAuthorizationDecline copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardAuthorizationDeclineReasonTest : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.TransactionNeverAllowed
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.ExceedsApprovalLimit
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.CardTemporarilyDisabled
    )]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.SuspectedFraud)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.Other)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.InsufficientFunds
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.TransactionNeverAllowed
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.ExceedsApprovalLimit
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.CardTemporarilyDisabled
    )]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.SuspectedFraud)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason.Other)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardAuthorizationDeclineReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DirectionTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Direction.Settlement)]
    [InlineData(RealTimeDecisions::Direction.Refund)]
    public void Validation_Works(RealTimeDecisions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Direction> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Direction.Settlement)]
    [InlineData(RealTimeDecisions::Direction.Refund)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Direction rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Direction> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Direction>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::Direction>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NetworkDetails
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };

        ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory> expectedCategory =
            RealTimeDecisions::NetworkDetailsCategory.Visa;
        RealTimeDecisions::Pulse expectedPulse = new();
        RealTimeDecisions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPulse, model.Pulse);
        Assert.Equal(expectedVisa, model.Visa);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NetworkDetails
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NetworkDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::NetworkDetails
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NetworkDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory> expectedCategory =
            RealTimeDecisions::NetworkDetailsCategory.Visa;
        RealTimeDecisions::Pulse expectedPulse = new();
        RealTimeDecisions::Visa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPulse, deserialized.Pulse);
        Assert.Equal(expectedVisa, deserialized.Visa);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::NetworkDetails
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::NetworkDetails
        {
            Category = RealTimeDecisions::NetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
                StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
                TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
            },
        };

        RealTimeDecisions::NetworkDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NetworkDetailsCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::NetworkDetailsCategory.Visa)]
    [InlineData(RealTimeDecisions::NetworkDetailsCategory.Pulse)]
    public void Validation_Works(RealTimeDecisions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::NetworkDetailsCategory.Visa)]
    [InlineData(RealTimeDecisions::NetworkDetailsCategory.Pulse)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::NetworkDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::NetworkDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PulseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Pulse { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Pulse { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Pulse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Pulse { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Pulse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Pulse { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Pulse { };

        RealTimeDecisions::Pulse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Visa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        ApiEnum<
            string,
            RealTimeDecisions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            RealTimeDecisions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            RealTimeDecisions::StandInProcessingReason
        > expectedStandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            RealTimeDecisions::TerminalEntryCapability
        > expectedTerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, model.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, model.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, model.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, model.TerminalEntryCapability);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Visa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Visa>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Visa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Visa>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimeDecisions::ElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            RealTimeDecisions::PointOfServiceEntryMode
        > expectedPointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            RealTimeDecisions::StandInProcessingReason
        > expectedStandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            RealTimeDecisions::TerminalEntryCapability
        > expectedTerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, deserialized.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, deserialized.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, deserialized.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, deserialized.TerminalEntryCapability);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Visa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Visa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode = RealTimeDecisions::PointOfServiceEntryMode.Unknown,
            StandInProcessingReason = RealTimeDecisions::StandInProcessingReason.IssuerError,
            TerminalEntryCapability = RealTimeDecisions::TerminalEntryCapability.Unknown,
        };

        RealTimeDecisions::Visa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElectronicCommerceIndicatorTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.Installment)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        RealTimeDecisions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void Validation_Works(RealTimeDecisions::ElectronicCommerceIndicator rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.MailPhoneOrder)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.Recurring)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.Installment)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.UnknownMailPhoneOrder)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.SecureElectronicCommerce)]
    [InlineData(
        RealTimeDecisions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction)]
    [InlineData(RealTimeDecisions::ElectronicCommerceIndicator.NonSecureTransaction)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::ElectronicCommerceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ElectronicCommerceIndicator>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PointOfServiceEntryModeTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Unknown)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Manual)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Contactless)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void Validation_Works(RealTimeDecisions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Unknown)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Manual)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.MagneticStripeNoCvv)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.OpticalCode)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.IntegratedCircuitCard)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.Contactless)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.CredentialOnFile)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.MagneticStripe)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.ContactlessMagneticStripe)]
    [InlineData(RealTimeDecisions::PointOfServiceEntryMode.IntegratedCircuitCardNoCvv)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::PointOfServiceEntryMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PointOfServiceEntryMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StandInProcessingReasonTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::StandInProcessingReason.IssuerError)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        RealTimeDecisions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        RealTimeDecisions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(RealTimeDecisions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.Other)]
    public void Validation_Works(RealTimeDecisions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::StandInProcessingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::StandInProcessingReason.IssuerError)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InvalidPhysicalCard)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InvalidCryptogram)]
    [InlineData(
        RealTimeDecisions::StandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(RealTimeDecisions::StandInProcessingReason.InternalVisaError)]
    [InlineData(
        RealTimeDecisions::StandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(RealTimeDecisions::StandInProcessingReason.PaymentFraudDisruptionAcquirerBlock)]
    [InlineData(RealTimeDecisions::StandInProcessingReason.Other)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::StandInProcessingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::StandInProcessingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::StandInProcessingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::StandInProcessingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TerminalEntryCapabilityTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.Unknown)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.Barcode)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.NoCapability)]
    public void Validation_Works(RealTimeDecisions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::TerminalEntryCapability> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.Unknown)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.TerminalNotUsed)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.MagneticStripe)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.Barcode)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.OpticalCharacterRecognition)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.ChipOrContactless)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.ContactlessOnly)]
    [InlineData(RealTimeDecisions::TerminalEntryCapability.NoCapability)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::TerminalEntryCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::TerminalEntryCapability> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TerminalEntryCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::TerminalEntryCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class NetworkIdentifiersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(model.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, model.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NetworkIdentifiers>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::NetworkIdentifiers>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(deserialized.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, deserialized.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::NetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        RealTimeDecisions::NetworkIdentifiers copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PartialApprovalCapabilityTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::PartialApprovalCapability.Supported)]
    [InlineData(RealTimeDecisions::PartialApprovalCapability.NotSupported)]
    public void Validation_Works(RealTimeDecisions::PartialApprovalCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::PartialApprovalCapability> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PartialApprovalCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::PartialApprovalCapability.Supported)]
    [InlineData(RealTimeDecisions::PartialApprovalCapability.NotSupported)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::PartialApprovalCapability rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::PartialApprovalCapability> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PartialApprovalCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PartialApprovalCapability>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::PartialApprovalCapability>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProcessingCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::ProcessingCategory.AccountFunding)]
    [InlineData(RealTimeDecisions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(RealTimeDecisions::ProcessingCategory.BillPayment)]
    [InlineData(RealTimeDecisions::ProcessingCategory.OriginalCredit)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Purchase)]
    [InlineData(RealTimeDecisions::ProcessingCategory.QuasiCash)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Refund)]
    [InlineData(RealTimeDecisions::ProcessingCategory.CashDisbursement)]
    [InlineData(RealTimeDecisions::ProcessingCategory.BalanceInquiry)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Unknown)]
    public void Validation_Works(RealTimeDecisions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::ProcessingCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::ProcessingCategory.AccountFunding)]
    [InlineData(RealTimeDecisions::ProcessingCategory.AutomaticFuelDispenser)]
    [InlineData(RealTimeDecisions::ProcessingCategory.BillPayment)]
    [InlineData(RealTimeDecisions::ProcessingCategory.OriginalCredit)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Purchase)]
    [InlineData(RealTimeDecisions::ProcessingCategory.QuasiCash)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Refund)]
    [InlineData(RealTimeDecisions::ProcessingCategory.CashDisbursement)]
    [InlineData(RealTimeDecisions::ProcessingCategory.BalanceInquiry)]
    [InlineData(RealTimeDecisions::ProcessingCategory.Unknown)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::ProcessingCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::ProcessingCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ProcessingCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::ProcessingCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RequestDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RequestDetails
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };

        ApiEnum<string, RealTimeDecisions::RequestDetailsCategory> expectedCategory =
            RealTimeDecisions::RequestDetailsCategory.InitialAuthorization;
        RealTimeDecisions::IncrementalAuthorization expectedIncrementalAuthorization = new()
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };
        RealTimeDecisions::InitialAuthorization expectedInitialAuthorization = new();

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedIncrementalAuthorization, model.IncrementalAuthorization);
        Assert.Equal(expectedInitialAuthorization, model.InitialAuthorization);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RequestDetails
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::RequestDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RequestDetails
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::RequestDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimeDecisions::RequestDetailsCategory> expectedCategory =
            RealTimeDecisions::RequestDetailsCategory.InitialAuthorization;
        RealTimeDecisions::IncrementalAuthorization expectedIncrementalAuthorization = new()
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };
        RealTimeDecisions::InitialAuthorization expectedInitialAuthorization = new();

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedIncrementalAuthorization, deserialized.IncrementalAuthorization);
        Assert.Equal(expectedInitialAuthorization, deserialized.InitialAuthorization);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RequestDetails
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RequestDetails
        {
            Category = RealTimeDecisions::RequestDetailsCategory.InitialAuthorization,
            IncrementalAuthorization = new()
            {
                CardPaymentID = "card_payment_id",
                OriginalCardAuthorizationID = "original_card_authorization_id",
            },
            InitialAuthorization = new(),
        };

        RealTimeDecisions::RequestDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RequestDetailsCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RequestDetailsCategory.InitialAuthorization)]
    [InlineData(RealTimeDecisions::RequestDetailsCategory.IncrementalAuthorization)]
    public void Validation_Works(RealTimeDecisions::RequestDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestDetailsCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RequestDetailsCategory.InitialAuthorization)]
    [InlineData(RealTimeDecisions::RequestDetailsCategory.IncrementalAuthorization)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::RequestDetailsCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RequestDetailsCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestDetailsCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RequestDetailsCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IncrementalAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::IncrementalAuthorization
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };

        string expectedCardPaymentID = "card_payment_id";
        string expectedOriginalCardAuthorizationID = "original_card_authorization_id";

        Assert.Equal(expectedCardPaymentID, model.CardPaymentID);
        Assert.Equal(expectedOriginalCardAuthorizationID, model.OriginalCardAuthorizationID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::IncrementalAuthorization
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::IncrementalAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::IncrementalAuthorization
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::IncrementalAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCardPaymentID = "card_payment_id";
        string expectedOriginalCardAuthorizationID = "original_card_authorization_id";

        Assert.Equal(expectedCardPaymentID, deserialized.CardPaymentID);
        Assert.Equal(expectedOriginalCardAuthorizationID, deserialized.OriginalCardAuthorizationID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::IncrementalAuthorization
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::IncrementalAuthorization
        {
            CardPaymentID = "card_payment_id",
            OriginalCardAuthorizationID = "original_card_authorization_id",
        };

        RealTimeDecisions::IncrementalAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class InitialAuthorizationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::InitialAuthorization { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::InitialAuthorization { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::InitialAuthorization>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::InitialAuthorization { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::InitialAuthorization>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::InitialAuthorization { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::InitialAuthorization { };

        RealTimeDecisions::InitialAuthorization copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Verification
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        RealTimeDecisions::CardVerificationCode expectedCardVerificationCode = new(
            RealTimeDecisions::CardVerificationCodeResult.NotChecked
        );
        RealTimeDecisions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };
        RealTimeDecisions::CardholderName expectedCardholderName = new()
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        Assert.Equal(expectedCardVerificationCode, model.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, model.CardholderAddress);
        Assert.Equal(expectedCardholderName, model.CardholderName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Verification
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Verification>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Verification
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Verification>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        RealTimeDecisions::CardVerificationCode expectedCardVerificationCode = new(
            RealTimeDecisions::CardVerificationCodeResult.NotChecked
        );
        RealTimeDecisions::CardholderAddress expectedCardholderAddress = new()
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };
        RealTimeDecisions::CardholderName expectedCardholderName = new()
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        Assert.Equal(expectedCardVerificationCode, deserialized.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, deserialized.CardholderAddress);
        Assert.Equal(expectedCardholderName, deserialized.CardholderName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Verification
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Verification
        {
            CardVerificationCode = new(RealTimeDecisions::CardVerificationCodeResult.NotChecked),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        RealTimeDecisions::Verification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardVerificationCode
        {
            Result = RealTimeDecisions::CardVerificationCodeResult.NotChecked,
        };

        ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult> expectedResult =
            RealTimeDecisions::CardVerificationCodeResult.NotChecked;

        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardVerificationCode
        {
            Result = RealTimeDecisions::CardVerificationCodeResult.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardVerificationCode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::CardVerificationCode
        {
            Result = RealTimeDecisions::CardVerificationCodeResult.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardVerificationCode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult> expectedResult =
            RealTimeDecisions::CardVerificationCodeResult.NotChecked;

        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::CardVerificationCode
        {
            Result = RealTimeDecisions::CardVerificationCodeResult.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::CardVerificationCode
        {
            Result = RealTimeDecisions::CardVerificationCodeResult.NotChecked,
        };

        RealTimeDecisions::CardVerificationCode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardVerificationCodeResultTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.NotChecked)]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.Match)]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.NoMatch)]
    public void Validation_Works(RealTimeDecisions::CardVerificationCodeResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.NotChecked)]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.Match)]
    [InlineData(RealTimeDecisions::CardVerificationCodeResult.NoMatch)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::CardVerificationCodeResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardVerificationCodeResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, RealTimeDecisions::CardholderAddressResult> expectedResult =
            RealTimeDecisions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, model.ActualLine1);
        Assert.Equal(expectedActualPostalCode, model.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, model.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, model.ProvidedPostalCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardholderAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardholderAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<string, RealTimeDecisions::CardholderAddressResult> expectedResult =
            RealTimeDecisions::CardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, deserialized.ActualLine1);
        Assert.Equal(expectedActualPostalCode, deserialized.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, deserialized.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, deserialized.ProvidedPostalCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::CardholderAddress
        {
            ActualLine1 = "actual_line1",
            ActualPostalCode = "actual_postal_code",
            ProvidedLine1 = "provided_line1",
            ProvidedPostalCode = "provided_postal_code",
            Result = RealTimeDecisions::CardholderAddressResult.NotChecked,
        };

        RealTimeDecisions::CardholderAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CardholderAddressResultTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::CardholderAddressResult.NotChecked)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.Match)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.NoMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void Validation_Works(RealTimeDecisions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::CardholderAddressResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::CardholderAddressResult.NotChecked)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeMatchAddressNoMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeNoMatchAddressMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.Match)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.NoMatch)]
    [InlineData(RealTimeDecisions::CardholderAddressResult.PostalCodeMatchAddressNotChecked)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::CardholderAddressResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::CardholderAddressResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardholderAddressResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::CardholderAddressResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CardholderNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, model.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, model.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, model.ProvidedMiddleName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardholderName>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::CardholderName>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, deserialized.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, deserialized.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, deserialized.ProvidedMiddleName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::CardholderName
        {
            ProvidedFirstName = "provided_first_name",
            ProvidedLastName = "provided_last_name",
            ProvidedMiddleName = "provided_middle_name",
        };

        RealTimeDecisions::CardholderName copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiry
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string expectedAccountID = "account_id";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts expectedAdditionalAmounts =
            new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval expectedApproval = new(0);
        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve;
        string expectedDigitalWalletTokenID = "digital_wallet_token_id";
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCity = "merchant_city";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantDescriptor = "merchant_descriptor";
        string expectedMerchantPostalCode = "merchant_postal_code";
        string expectedMerchantState = "merchant_state";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails expectedNetworkDetails =
            new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers expectedNetworkIdentifiers =
            new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            };
        long expectedNetworkRiskScore = 0;
        string expectedPhysicalCardID = "physical_card_id";
        string expectedTerminalID = "terminal_id";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification expectedVerification =
            new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            };

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedAdditionalAmounts, model.AdditionalAmounts);
        Assert.Equal(expectedApproval, model.Approval);
        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedDigitalWalletTokenID, model.DigitalWalletTokenID);
        Assert.Equal(expectedMerchantAcceptorID, model.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, model.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, model.MerchantCity);
        Assert.Equal(expectedMerchantCountry, model.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, model.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, model.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, model.MerchantState);
        Assert.Equal(expectedNetworkDetails, model.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, model.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, model.NetworkRiskScore);
        Assert.Equal(expectedPhysicalCardID, model.PhysicalCardID);
        Assert.Equal(expectedTerminalID, model.TerminalID);
        Assert.Equal(expectedUpcomingCardPaymentID, model.UpcomingCardPaymentID);
        Assert.Equal(expectedVerification, model.Verification);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiry
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiry>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiry
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiry>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts expectedAdditionalAmounts =
            new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval expectedApproval = new(0);
        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve;
        string expectedDigitalWalletTokenID = "digital_wallet_token_id";
        string expectedMerchantAcceptorID = "merchant_acceptor_id";
        string expectedMerchantCategoryCode = "merchant_category_code";
        string expectedMerchantCity = "merchant_city";
        string expectedMerchantCountry = "merchant_country";
        string expectedMerchantDescriptor = "merchant_descriptor";
        string expectedMerchantPostalCode = "merchant_postal_code";
        string expectedMerchantState = "merchant_state";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails expectedNetworkDetails =
            new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers expectedNetworkIdentifiers =
            new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            };
        long expectedNetworkRiskScore = 0;
        string expectedPhysicalCardID = "physical_card_id";
        string expectedTerminalID = "terminal_id";
        string expectedUpcomingCardPaymentID = "upcoming_card_payment_id";
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification expectedVerification =
            new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            };

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedAdditionalAmounts, deserialized.AdditionalAmounts);
        Assert.Equal(expectedApproval, deserialized.Approval);
        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedDigitalWalletTokenID, deserialized.DigitalWalletTokenID);
        Assert.Equal(expectedMerchantAcceptorID, deserialized.MerchantAcceptorID);
        Assert.Equal(expectedMerchantCategoryCode, deserialized.MerchantCategoryCode);
        Assert.Equal(expectedMerchantCity, deserialized.MerchantCity);
        Assert.Equal(expectedMerchantCountry, deserialized.MerchantCountry);
        Assert.Equal(expectedMerchantDescriptor, deserialized.MerchantDescriptor);
        Assert.Equal(expectedMerchantPostalCode, deserialized.MerchantPostalCode);
        Assert.Equal(expectedMerchantState, deserialized.MerchantState);
        Assert.Equal(expectedNetworkDetails, deserialized.NetworkDetails);
        Assert.Equal(expectedNetworkIdentifiers, deserialized.NetworkIdentifiers);
        Assert.Equal(expectedNetworkRiskScore, deserialized.NetworkRiskScore);
        Assert.Equal(expectedPhysicalCardID, deserialized.PhysicalCardID);
        Assert.Equal(expectedTerminalID, deserialized.TerminalID);
        Assert.Equal(expectedUpcomingCardPaymentID, deserialized.UpcomingCardPaymentID);
        Assert.Equal(expectedVerification, deserialized.Verification);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiry
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiry
        {
            AccountID = "account_id",
            AdditionalAmounts = new()
            {
                Clinic = new() { Amount = 0, Currency = "currency" },
                Dental = new() { Amount = 0, Currency = "currency" },
                Original = new() { Amount = 0, Currency = "currency" },
                Prescription = new() { Amount = 0, Currency = "currency" },
                Surcharge = new() { Amount = 0, Currency = "currency" },
                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                Transit = new() { Amount = 0, Currency = "currency" },
                Unknown = new() { Amount = 0, Currency = "currency" },
                Vision = new() { Amount = 0, Currency = "currency" },
            },
            Approval = new(0),
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve,
            DigitalWalletTokenID = "digital_wallet_token_id",
            MerchantAcceptorID = "merchant_acceptor_id",
            MerchantCategoryCode = "merchant_category_code",
            MerchantCity = "merchant_city",
            MerchantCountry = "merchant_country",
            MerchantDescriptor = "merchant_descriptor",
            MerchantPostalCode = "merchant_postal_code",
            MerchantState = "merchant_state",
            NetworkDetails = new()
            {
                Category =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
                Pulse = new(),
                Visa = new()
                {
                    ElectronicCommerceIndicator =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                    PointOfServiceEntryMode =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                    StandInProcessingReason =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                    TerminalEntryCapability =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
                },
            },
            NetworkIdentifiers = new()
            {
                AuthorizationIdentificationResponse = null,
                RetrievalReferenceNumber = "785867080153",
                TraceNumber = "487941",
                TransactionID = "627199945183184",
            },
            NetworkRiskScore = 0,
            PhysicalCardID = "physical_card_id",
            TerminalID = "terminal_id",
            UpcomingCardPaymentID = "upcoming_card_payment_id",
            Verification = new()
            {
                CardVerificationCode = new(
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
                ),
                CardholderAddress = new()
                {
                    ActualLine1 = "actual_line1",
                    ActualPostalCode = "actual_postal_code",
                    ProvidedLine1 = "provided_line1",
                    ProvidedPostalCode = "provided_postal_code",
                    Result =
                        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
                },
                CardholderName = new()
                {
                    ProvidedFirstName = "provided_first_name",
                    ProvidedLastName = "provided_last_name",
                    ProvidedMiddleName = "provided_middle_name",
                },
            },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic expectedClinic =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental expectedDental =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal expectedOriginal =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription expectedPrescription =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge expectedSurcharge =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative expectedTotalCumulative =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare expectedTotalHealthcare =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit expectedTransit =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown expectedUnknown =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision expectedVision =
            new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, model.Clinic);
        Assert.Equal(expectedDental, model.Dental);
        Assert.Equal(expectedOriginal, model.Original);
        Assert.Equal(expectedPrescription, model.Prescription);
        Assert.Equal(expectedSurcharge, model.Surcharge);
        Assert.Equal(expectedTotalCumulative, model.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, model.TotalHealthcare);
        Assert.Equal(expectedTransit, model.Transit);
        Assert.Equal(expectedUnknown, model.Unknown);
        Assert.Equal(expectedVision, model.Vision);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic expectedClinic =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental expectedDental =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal expectedOriginal =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription expectedPrescription =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge expectedSurcharge =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative expectedTotalCumulative =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare expectedTotalHealthcare =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit expectedTransit =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown expectedUnknown =
            new() { Amount = 0, Currency = "currency" };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision expectedVision =
            new() { Amount = 0, Currency = "currency" };

        Assert.Equal(expectedClinic, deserialized.Clinic);
        Assert.Equal(expectedDental, deserialized.Dental);
        Assert.Equal(expectedOriginal, deserialized.Original);
        Assert.Equal(expectedPrescription, deserialized.Prescription);
        Assert.Equal(expectedSurcharge, deserialized.Surcharge);
        Assert.Equal(expectedTotalCumulative, deserialized.TotalCumulative);
        Assert.Equal(expectedTotalHealthcare, deserialized.TotalHealthcare);
        Assert.Equal(expectedTransit, deserialized.Transit);
        Assert.Equal(expectedUnknown, deserialized.Unknown);
        Assert.Equal(expectedVision, deserialized.Vision);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts
        {
            Clinic = new() { Amount = 0, Currency = "currency" },
            Dental = new() { Amount = 0, Currency = "currency" },
            Original = new() { Amount = 0, Currency = "currency" },
            Prescription = new() { Amount = 0, Currency = "currency" },
            Surcharge = new() { Amount = 0, Currency = "currency" },
            TotalCumulative = new() { Amount = 0, Currency = "currency" },
            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
            Transit = new() { Amount = 0, Currency = "currency" },
            Unknown = new() { Amount = 0, Currency = "currency" },
            Vision = new() { Amount = 0, Currency = "currency" },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmounts copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinicTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
        {
            Amount = 0,
            Currency = "currency",
        };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
        {
            Amount = 0,
            Currency = "currency",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
        {
            Amount = 0,
            Currency = "currency",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
        {
            Amount = 0,
            Currency = "currency",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic
        {
            Amount = 0,
            Currency = "currency",
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsClinic copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsDentalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental
        {
            Amount = 0,
            Currency = "currency",
        };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental
        {
            Amount = 0,
            Currency = "currency",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental
        {
            Amount = 0,
            Currency = "currency",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental
        {
            Amount = 0,
            Currency = "currency",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental
        {
            Amount = 0,
            Currency = "currency",
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsDental copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsOriginal copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsPrescription copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurchargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsSurcharge copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulativeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalCumulative copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcareTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTotalHealthcare copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsTransit copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknownTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
            {
                Amount = 0,
                Currency = "currency",
            };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
            {
                Amount = 0,
                Currency = "currency",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
            {
                Amount = 0,
                Currency = "currency",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
            {
                Amount = 0,
                Currency = "currency",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown
            {
                Amount = 0,
                Currency = "currency",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsUnknown copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryAdditionalAmountsVisionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision
        {
            Amount = 0,
            Currency = "currency",
        };

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision
        {
            Amount = 0,
            Currency = "currency",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision
        {
            Amount = 0,
            Currency = "currency",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision
        {
            Amount = 0,
            Currency = "currency",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision
        {
            Amount = 0,
            Currency = "currency",
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryAdditionalAmountsVision copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryApprovalTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval
        {
            Balance = 0,
        };

        long expectedBalance = 0;

        Assert.Equal(expectedBalance, model.Balance);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval
        {
            Balance = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval
        {
            Balance = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        long expectedBalance = 0;

        Assert.Equal(expectedBalance, deserialized.Balance);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval
        {
            Balance = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval
        {
            Balance = 0,
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryApproval copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryDecisionTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Decline)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision.Decline)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCardBalanceInquiryDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails
        {
            Category =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                StandInProcessingReason =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                TerminalEntryCapability =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            },
        };

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
        > expectedCategory =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa;
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse expectedPulse =
            new();
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedPulse, model.Pulse);
        Assert.Equal(expectedVisa, model.Visa);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails
        {
            Category =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                StandInProcessingReason =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                TerminalEntryCapability =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails
        {
            Category =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                StandInProcessingReason =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                TerminalEntryCapability =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
        > expectedCategory =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa;
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse expectedPulse =
            new();
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa expectedVisa = new()
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedPulse, deserialized.Pulse);
        Assert.Equal(expectedVisa, deserialized.Visa);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails
        {
            Category =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                StandInProcessingReason =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                TerminalEntryCapability =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails
        {
            Category =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa,
            Pulse = new(),
            Visa = new()
            {
                ElectronicCommerceIndicator =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
                PointOfServiceEntryMode =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
                StandInProcessingReason =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
                TerminalEntryCapability =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
            },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Pulse)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Visa)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory.Pulse)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsCategory
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsPulseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse
        { };
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse
        { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse
        { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse
        { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse
        { };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsPulse copied = new(
            model
        );

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
        > expectedPointOfServiceEntryMode =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
        > expectedStandInProcessingReason =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
        > expectedTerminalEntryCapability =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, model.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, model.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, model.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, model.TerminalEntryCapability);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
        > expectedElectronicCommerceIndicator =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
        > expectedPointOfServiceEntryMode =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
        > expectedStandInProcessingReason =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError;
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
        > expectedTerminalEntryCapability =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown;

        Assert.Equal(expectedElectronicCommerceIndicator, deserialized.ElectronicCommerceIndicator);
        Assert.Equal(expectedPointOfServiceEntryMode, deserialized.PointOfServiceEntryMode);
        Assert.Equal(expectedStandInProcessingReason, deserialized.StandInProcessingReason);
        Assert.Equal(expectedTerminalEntryCapability, deserialized.TerminalEntryCapability);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa
        {
            ElectronicCommerceIndicator =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder,
            PointOfServiceEntryMode =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown,
            StandInProcessingReason =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError,
            TerminalEntryCapability =
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown,
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisa copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicatorTest
    : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.MailPhoneOrder
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Recurring
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.Installment
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.UnknownMailPhoneOrder
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.SecureElectronicCommerce
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransactionAt3dsCapableMerchant
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonAuthenticatedSecurityTransaction
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator.NonSecureTransaction
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaElectronicCommerceIndicator
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryModeTest
    : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Unknown
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Manual
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripeNoCvv
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.OpticalCode
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCard
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.Contactless
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.CredentialOnFile
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.MagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.ContactlessMagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode.IntegratedCircuitCardNoCvv
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaPointOfServiceEntryMode
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReasonTest
    : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.IssuerError
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidPhysicalCard
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCryptogram
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InvalidCardholderAuthenticationVerificationValue
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.InternalVisaError
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.MerchantTransactionAdvisoryServiceAuthenticationRequired
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.PaymentFraudDisruptionAcquirerBlock
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason.Other
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaStandInProcessingReason
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapabilityTest
    : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Unknown
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.TerminalNotUsed
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.MagneticStripe
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.Barcode
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.OpticalCharacterRecognition
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ChipOrContactless
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.ContactlessOnly
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability.NoCapability
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkDetailsVisaTerminalEntryCapability
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryNetworkIdentifiersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(model.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, model.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, model.TraceNumber);
        Assert.Equal(expectedTransactionID, model.TransactionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedRetrievalReferenceNumber = "785867080153";
        string expectedTraceNumber = "487941";
        string expectedTransactionID = "627199945183184";

        Assert.Null(deserialized.AuthorizationIdentificationResponse);
        Assert.Equal(expectedRetrievalReferenceNumber, deserialized.RetrievalReferenceNumber);
        Assert.Equal(expectedTraceNumber, deserialized.TraceNumber);
        Assert.Equal(expectedTransactionID, deserialized.TransactionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers
        {
            AuthorizationIdentificationResponse = null,
            RetrievalReferenceNumber = "785867080153",
            TraceNumber = "487941",
            TransactionID = "627199945183184",
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryNetworkIdentifiers copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification
        {
            CardVerificationCode = new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            ),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode expectedCardVerificationCode =
            new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            );
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress expectedCardholderAddress =
            new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName expectedCardholderName =
            new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        Assert.Equal(expectedCardVerificationCode, model.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, model.CardholderAddress);
        Assert.Equal(expectedCardholderName, model.CardholderName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification
        {
            CardVerificationCode = new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            ),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification
        {
            CardVerificationCode = new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            ),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode expectedCardVerificationCode =
            new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            );
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress expectedCardholderAddress =
            new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName expectedCardholderName =
            new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        Assert.Equal(expectedCardVerificationCode, deserialized.CardVerificationCode);
        Assert.Equal(expectedCardholderAddress, deserialized.CardholderAddress);
        Assert.Equal(expectedCardholderName, deserialized.CardholderName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification
        {
            CardVerificationCode = new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            ),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification
        {
            CardVerificationCode = new(
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
            ),
            CardholderAddress = new()
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            },
            CardholderName = new()
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            },
        };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerification copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
            {
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            };

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked;

        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
            {
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
            {
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked;

        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
            {
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode
            {
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked,
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCode copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResultTest : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.Match
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NotChecked
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.Match
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult.NoMatch
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardVerificationCodeResult
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, model.ActualLine1);
        Assert.Equal(expectedActualPostalCode, model.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, model.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, model.ProvidedPostalCode);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedActualLine1 = "actual_line1";
        string expectedActualPostalCode = "actual_postal_code";
        string expectedProvidedLine1 = "provided_line1";
        string expectedProvidedPostalCode = "provided_postal_code";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked;

        Assert.Equal(expectedActualLine1, deserialized.ActualLine1);
        Assert.Equal(expectedActualPostalCode, deserialized.ActualPostalCode);
        Assert.Equal(expectedProvidedLine1, deserialized.ProvidedLine1);
        Assert.Equal(expectedProvidedPostalCode, deserialized.ProvidedPostalCode);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress
            {
                ActualLine1 = "actual_line1",
                ActualPostalCode = "actual_postal_code",
                ProvidedLine1 = "provided_line1",
                ProvidedPostalCode = "provided_postal_code",
                Result =
                    RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked,
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddress copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResultTest : TestBase
{
    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.Match
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NoMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked
    )]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NotChecked
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNoMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeNoMatchAddressMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.Match
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.NoMatch
    )]
    [InlineData(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult.PostalCodeMatchAddressNotChecked
    )]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderAddressResult
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionCardBalanceInquiryVerificationCardholderNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, model.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, model.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, model.ProvidedMiddleName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedProvidedFirstName = "provided_first_name";
        string expectedProvidedLastName = "provided_last_name";
        string expectedProvidedMiddleName = "provided_middle_name";

        Assert.Equal(expectedProvidedFirstName, deserialized.ProvidedFirstName);
        Assert.Equal(expectedProvidedLastName, deserialized.ProvidedLastName);
        Assert.Equal(expectedProvidedMiddleName, deserialized.ProvidedMiddleName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model =
            new RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName
            {
                ProvidedFirstName = "provided_first_name",
                ProvidedLastName = "provided_last_name",
                ProvidedMiddleName = "provided_middle_name",
            };

        RealTimeDecisions::RealTimeDecisionCardBalanceInquiryVerificationCardholderName copied =
            new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionCategoryTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardBalanceInquiryRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthenticationRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthenticationChallengeRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.DigitalWalletTokenRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.DigitalWalletAuthenticationRequested)]
    public void Validation_Works(RealTimeDecisions::RealTimeDecisionCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthorizationRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardBalanceInquiryRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthenticationRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.CardAuthenticationChallengeRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.DigitalWalletTokenRequested)]
    [InlineData(RealTimeDecisions::RealTimeDecisionCategory.DigitalWalletAuthenticationRequested)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::RealTimeDecisionCategory rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionCategory>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionDigitalWalletAuthenticationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication
        {
            CardID = "card_id",
            Channel = RealTimeDecisions::Channel.Sms,
            DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
            Email = "email",
            OneTimePasscode = "one_time_passcode",
            Phone = "phone",
            Result = RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
        };

        string expectedCardID = "card_id";
        ApiEnum<string, RealTimeDecisions::Channel> expectedChannel =
            RealTimeDecisions::Channel.Sms;
        ApiEnum<string, RealTimeDecisions::DigitalWallet> expectedDigitalWallet =
            RealTimeDecisions::DigitalWallet.ApplePay;
        string expectedEmail = "email";
        string expectedOneTimePasscode = "one_time_passcode";
        string expectedPhone = "phone";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success;

        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedDigitalWallet, model.DigitalWallet);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedOneTimePasscode, model.OneTimePasscode);
        Assert.Equal(expectedPhone, model.Phone);
        Assert.Equal(expectedResult, model.Result);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication
        {
            CardID = "card_id",
            Channel = RealTimeDecisions::Channel.Sms,
            DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
            Email = "email",
            OneTimePasscode = "one_time_passcode",
            Phone = "phone",
            Result = RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication
        {
            CardID = "card_id",
            Channel = RealTimeDecisions::Channel.Sms,
            DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
            Email = "email",
            OneTimePasscode = "one_time_passcode",
            Phone = "phone",
            Result = RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCardID = "card_id";
        ApiEnum<string, RealTimeDecisions::Channel> expectedChannel =
            RealTimeDecisions::Channel.Sms;
        ApiEnum<string, RealTimeDecisions::DigitalWallet> expectedDigitalWallet =
            RealTimeDecisions::DigitalWallet.ApplePay;
        string expectedEmail = "email";
        string expectedOneTimePasscode = "one_time_passcode";
        string expectedPhone = "phone";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult
        > expectedResult =
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success;

        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedDigitalWallet, deserialized.DigitalWallet);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedOneTimePasscode, deserialized.OneTimePasscode);
        Assert.Equal(expectedPhone, deserialized.Phone);
        Assert.Equal(expectedResult, deserialized.Result);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication
        {
            CardID = "card_id",
            Channel = RealTimeDecisions::Channel.Sms,
            DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
            Email = "email",
            OneTimePasscode = "one_time_passcode",
            Phone = "phone",
            Result = RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication
        {
            CardID = "card_id",
            Channel = RealTimeDecisions::Channel.Sms,
            DigitalWallet = RealTimeDecisions::DigitalWallet.ApplePay,
            Email = "email",
            OneTimePasscode = "one_time_passcode",
            Phone = "phone",
            Result = RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success,
        };

        RealTimeDecisions::RealTimeDecisionDigitalWalletAuthentication copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Channel.Sms)]
    [InlineData(RealTimeDecisions::Channel.Email)]
    public void Validation_Works(RealTimeDecisions::Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Channel.Sms)]
    [InlineData(RealTimeDecisions::Channel.Email)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DigitalWalletTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::DigitalWallet.ApplePay)]
    [InlineData(RealTimeDecisions::DigitalWallet.GooglePay)]
    [InlineData(RealTimeDecisions::DigitalWallet.SamsungPay)]
    [InlineData(RealTimeDecisions::DigitalWallet.Unknown)]
    public void Validation_Works(RealTimeDecisions::DigitalWallet rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::DigitalWallet> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::DigitalWallet>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::DigitalWallet.ApplePay)]
    [InlineData(RealTimeDecisions::DigitalWallet.GooglePay)]
    [InlineData(RealTimeDecisions::DigitalWallet.SamsungPay)]
    [InlineData(RealTimeDecisions::DigitalWallet.Unknown)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::DigitalWallet rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::DigitalWallet> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::DigitalWallet>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::DigitalWallet>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::DigitalWallet>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionDigitalWalletAuthenticationResultTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Failure)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Success)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult.Failure)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletAuthenticationResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class RealTimeDecisionDigitalWalletTokenTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletToken
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };

        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve;
        RealTimeDecisions::Device expectedDevice = new("identifier");
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet
        > expectedDigitalWallet =
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay;

        Assert.Equal(expectedCardID, model.CardID);
        Assert.Equal(expectedDecision, model.Decision);
        Assert.Equal(expectedDevice, model.Device);
        Assert.Equal(expectedDigitalWallet, model.DigitalWallet);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletToken
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionDigitalWalletToken>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletToken
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<RealTimeDecisions::RealTimeDecisionDigitalWalletToken>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedCardID = "card_id";
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision
        > expectedDecision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve;
        RealTimeDecisions::Device expectedDevice = new("identifier");
        ApiEnum<
            string,
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet
        > expectedDigitalWallet =
            RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay;

        Assert.Equal(expectedCardID, deserialized.CardID);
        Assert.Equal(expectedDecision, deserialized.Decision);
        Assert.Equal(expectedDevice, deserialized.Device);
        Assert.Equal(expectedDigitalWallet, deserialized.DigitalWallet);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletToken
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::RealTimeDecisionDigitalWalletToken
        {
            CardID = "card_id",
            Decision = RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve,
            Device = new("identifier"),
            DigitalWallet =
                RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay,
        };

        RealTimeDecisions::RealTimeDecisionDigitalWalletToken copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionDigitalWalletTokenDecisionTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Decline)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Approve)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision.Decline)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDecision>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DeviceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Device { Identifier = "identifier" };

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, model.Identifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RealTimeDecisions::Device { Identifier = "identifier" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Device>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RealTimeDecisions::Device { Identifier = "identifier" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RealTimeDecisions::Device>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedIdentifier = "identifier";

        Assert.Equal(expectedIdentifier, deserialized.Identifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RealTimeDecisions::Device { Identifier = "identifier" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RealTimeDecisions::Device { Identifier = "identifier" };

        RealTimeDecisions::Device copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RealTimeDecisionDigitalWalletTokenDigitalWalletTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.GooglePay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.SamsungPay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.Unknown)]
    public void Validation_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.ApplePay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.GooglePay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.SamsungPay)]
    [InlineData(RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet.Unknown)]
    public void SerializationRoundtrip_Works(
        RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, RealTimeDecisions::RealTimeDecisionDigitalWalletTokenDigitalWallet>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Status.Pending)]
    [InlineData(RealTimeDecisions::Status.Responded)]
    [InlineData(RealTimeDecisions::Status.TimedOut)]
    public void Validation_Works(RealTimeDecisions::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Status.Pending)]
    [InlineData(RealTimeDecisions::Status.Responded)]
    [InlineData(RealTimeDecisions::Status.TimedOut)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(RealTimeDecisions::Type.RealTimeDecision)]
    public void Validation_Works(RealTimeDecisions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RealTimeDecisions::Type.RealTimeDecision)]
    public void SerializationRoundtrip_Works(RealTimeDecisions::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RealTimeDecisions::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RealTimeDecisions::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
