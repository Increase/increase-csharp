using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Transactions = Increase.Api.Models.Transactions;

namespace Increase.Api.Tests.Models.Transactions;

public class TransactionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Transactions::TransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "transaction_uyrp7fld2ium70oa7oi",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = Transactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = Transactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = Transactions::SourceCategory.InboundAchTransfer,
                        AccountRevenuePayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        AccountTransferIntention = new()
                        {
                            Amount = 100,
                            Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                            Description = "INVOICE 2468",
                            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                            SourceAccountID = "account_in71c4amph0vgo2qllky",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            StatementDescriptor = "INVOICE 2468",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                        AchTransferReturn = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            RawReturnReasonCode = "R01",
                            ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                            TraceNumber = "111122223292834",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                        },
                        BlockchainOfframpTransferSettlement = new()
                        {
                            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                        },
                        BlockchainOnrampTransferIntention = new()
                        {
                            DestinationBlockchainAddress = "0xaabbccdd",
                            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                        },
                        CardDisputeAcceptance = new()
                        {
                            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardDisputeFinancial = new()
                        {
                            Amount = 1000,
                            Network = Transactions::Network.Visa,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Visa = new(Transactions::EventType.ChargebackSubmitted),
                        },
                        CardDisputeLoss = new()
                        {
                            Explanation = "The card dispute was lost.",
                            LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardFinancial = new()
                        {
                            ID = "card_financial_di5b98i72ppomo268zfk",
                            Actioner = Transactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = Transactions::CardFinancialCurrency.Usd,
                            DigitalWalletTokenID = null,
                            Direction = Transactions::Direction.Settlement,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkDetails = new()
                            {
                                Category = Transactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        Transactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        Transactions::TerminalEntryCapability.MagneticStripe,
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
                            PhysicalCardID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::SchemeFeeCurrency.Usd,
                                    FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TerminalID = "RCN5VNXS",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::Type.CardFinancial,
                            Verification = new()
                            {
                                CardVerificationCode = new(Transactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CardPushTransferAcceptance = new()
                        {
                            SettlementAmount = 100,
                            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                        },
                        CardRefund = new()
                        {
                            ID = "card_refund_imgc2xwplh6t4r3gn16e",
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardRefundCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::InterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::PurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category = Transactions::ServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::TravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::RestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::TicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode = Transactions::StopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardRefundType.CardRefund,
                        },
                        CardRevenuePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                            TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                        },
                        CardSettlement = new()
                        {
                            ID = "card_settlement_khv5kfeu0vndj291omg6",
                            Amount = 100,
                            CardAuthorization = null,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardSettlementCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            Network = Transactions::CardSettlementNetwork.Visa,
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PendingTransactionID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category =
                                                    Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode =
                                                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardSettlementType.CardSettlement,
                        },
                        CashbackPayment = new()
                        {
                            AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                            Amount = 100,
                            Currency = Transactions::CashbackPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        CheckDepositAcceptance = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 1000,
                            AuxiliaryOnUs = "101",
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                            RoutingNumber = "101050001",
                            SerialNumber = null,
                        },
                        CheckDepositReturn = new()
                        {
                            Amount = 100,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositReturnCurrency.Usd,
                            ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CheckTransferDeposit = new()
                        {
                            BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            BankOfFirstDepositRoutingNumber = null,
                            DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                        },
                        FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                        FeePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::FeePaymentCurrency.Usd,
                            FeePeriodStart = "2023-05-01",
                            ProgramID = "program_i2v2os4mwza1oetokh9i",
                        },
                        InboundAchTransfer = new()
                        {
                            Addenda = new()
                            {
                                Category = Transactions::AddendaCategory.Freeform,
                                Freeform = new([new("payment_related_information")]),
                            },
                            Amount = 100,
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyEntryDescription = "RESERVE",
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        },
                        InboundAchTransferReturnIntention = new(
                            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                        ),
                        InboundCheckAdjustment = new()
                        {
                            AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Amount = 1750,
                            Reason = Transactions::Reason.LateReturn,
                        },
                        InboundCheckDepositReturnIntention = new()
                        {
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        },
                        InboundFednowTransferConfirmation = new(
                            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                        ),
                        InboundRealTimePaymentsTransferConfirmation = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        InboundWireReversal = new()
                        {
                            Amount = 12345,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            DebtorRoutingNumber = "101050001",
                            Description = "Inbound wire reversal 2022021100335128",
                            InputCycleDate = "2022-02-11",
                            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                            InputSequenceNumber = "11023",
                            InputSource = "B6B7HU2R",
                            InstructionIdentification = null,
                            ReturnReasonAdditionalInformation = null,
                            ReturnReasonCode = null,
                            ReturnReasonCodeDescription = null,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                        InboundWireTransfer = new()
                        {
                            Amount = 100,
                            CreditorAddressLine1 = null,
                            CreditorAddressLine2 = null,
                            CreditorAddressLine3 = null,
                            CreditorName = null,
                            DebtorAddressLine1 = null,
                            DebtorAddressLine2 = null,
                            DebtorAddressLine3 = null,
                            DebtorName = null,
                            Description = "Inbound wire transfer",
                            EndToEndIdentification = null,
                            InputMessageAccountabilityData = null,
                            InstructingAgentRoutingNumber = null,
                            InstructionIdentification = null,
                            TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            UniqueEndToEndTransactionReference = null,
                            UnstructuredRemittanceInformation = null,
                        },
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
                        InterestPayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            Amount = 100,
                            Currency = Transactions::InterestPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        InternalSource = new()
                        {
                            Amount = 100,
                            Currency = Transactions::InternalSourceCurrency.Usd,
                            Reason = Transactions::InternalSourceReason.SampleFunds,
                        },
                        Other = new(),
                        RealTimePaymentsTransferAcknowledgement = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        SampleFunds = new("dashboard"),
                        SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                        SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                        WireTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            MessageToRecipient = "HELLO",
                            RoutingNumber = "101050001",
                            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                    },
                    Type = Transactions::TransactionType.Transaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        List<Transactions::Transaction> expectedData =
        [
            new()
            {
                ID = "transaction_uyrp7fld2ium70oa7oi",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = Transactions::Currency.Usd,
                Description = "INVOICE 2468",
                RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                RouteType = Transactions::RouteType.AccountNumber,
                Source = new()
                {
                    Category = Transactions::SourceCategory.InboundAchTransfer,
                    AccountRevenuePayment = new()
                    {
                        AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    AccountTransferIntention = new()
                    {
                        Amount = 100,
                        Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                        Description = "INVOICE 2468",
                        DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                        SourceAccountID = "account_in71c4amph0vgo2qllky",
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferIntention = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        RoutingNumber = "101050001",
                        StatementDescriptor = "INVOICE 2468",
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                    AchTransferReturn = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        RawReturnReasonCode = "R01",
                        ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                        TraceNumber = "111122223292834",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferSettlement = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferIntention = new()
                    {
                        DestinationBlockchainAddress = "0xaabbccdd",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardDisputeAcceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CardDisputeFinancial = new()
                    {
                        Amount = 1000,
                        Network = Transactions::Network.Visa,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Visa = new(Transactions::EventType.ChargebackSubmitted),
                    },
                    CardDisputeLoss = new()
                    {
                        Explanation = "The card dispute was lost.",
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CardFinancial = new()
                    {
                        ID = "card_financial_di5b98i72ppomo268zfk",
                        Actioner = Transactions::Actioner.Increase,
                        AdditionalAmounts = new()
                        {
                            Clinic = new() { Amount = 0, Currency = "currency" },
                            Dental = new() { Amount = 0, Currency = "currency" },
                            Original = new() { Amount = 0, Currency = "currency" },
                            Prescription = new() { Amount = 0, Currency = "currency" },
                            Surcharge = new() { Amount = 10, Currency = "USD" },
                            TotalCumulative = new() { Amount = 0, Currency = "currency" },
                            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                            Transit = new() { Amount = 0, Currency = "currency" },
                            Unknown = new() { Amount = 0, Currency = "currency" },
                            Vision = new() { Amount = 0, Currency = "currency" },
                        },
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = Transactions::CardFinancialCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = Transactions::Direction.Settlement,
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = Transactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    Transactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    Transactions::TerminalEntryCapability.MagneticStripe,
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
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::SchemeFeeCurrency.Usd,
                                FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        TerminalID = "RCN5VNXS",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::Type.CardFinancial,
                        Verification = new()
                        {
                            CardVerificationCode = new(Transactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferAcceptance = new()
                    {
                        SettlementAmount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CardRefund = new()
                    {
                        ID = "card_refund_imgc2xwplh6t4r3gn16e",
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Cashback = new()
                        {
                            Amount = "0.137465",
                            Currency = Transactions::CashbackCurrency.Usd,
                        },
                        Currency = Transactions::CardRefundCurrency.Usd,
                        Interchange = new()
                        {
                            Amount = "0.137465",
                            Code = "271",
                            Currency = Transactions::InterchangeCurrency.Usd,
                        },
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantName = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkIdentifiers = new()
                        {
                            AcquirerBusinessID = "69650702",
                            AcquirerReferenceNumber = "83163715445437604865089",
                            AuthorizationIdentificationResponse = "ABC123",
                            TransactionID = "627199945183184",
                        },
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        PurchaseDetails = new()
                        {
                            CarRental = new()
                            {
                                CarClassCode = "car_class_code",
                                CheckoutDate = "2019-12-27",
                                DailyRentalRateAmount = 0,
                                DailyRentalRateCurrency = "daily_rental_rate_currency",
                                DaysRented = 0,
                                ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                FuelChargesAmount = 0,
                                FuelChargesCurrency = "fuel_charges_currency",
                                InsuranceChargesAmount = 0,
                                InsuranceChargesCurrency = "insurance_charges_currency",
                                NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                OneWayDropOffChargesAmount = 0,
                                OneWayDropOffChargesCurrency = "one_way_drop_off_charges_currency",
                                RenterName = "renter_name",
                                WeeklyRentalRateAmount = 0,
                                WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                            },
                            CustomerReferenceIdentifier = "51201",
                            LocalTaxAmount = null,
                            LocalTaxCurrency = "usd",
                            Lodging = new()
                            {
                                CheckInDate = "2023-07-20",
                                DailyRoomRateAmount = 1000,
                                DailyRoomRateCurrency = "usd",
                                ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                FolioCashAdvancesAmount = 0,
                                FolioCashAdvancesCurrency = "usd",
                                FoodBeverageChargesAmount = 0,
                                FoodBeverageChargesCurrency = "usd",
                                NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                PrepaidExpensesAmount = 0,
                                PrepaidExpensesCurrency = "usd",
                                RoomNights = 1,
                                TotalRoomTaxAmount = 100,
                                TotalRoomTaxCurrency = "usd",
                                TotalTaxAmount = 100,
                                TotalTaxCurrency = "usd",
                            },
                            NationalTaxAmount = null,
                            NationalTaxCurrency = "usd",
                            PurchaseIdentifier = "10203",
                            PurchaseIdentifierFormat =
                                Transactions::PurchaseIdentifierFormat.OrderNumber,
                            Travel = new()
                            {
                                Ancillary = new()
                                {
                                    ConnectedTicketDocumentNumber =
                                        "connected_ticket_document_number",
                                    CreditReasonIndicator =
                                        Transactions::CreditReasonIndicator.NoCredit,
                                    PassengerNameOrDescription = "passenger_name_or_description",
                                    Services =
                                    [
                                        new()
                                        {
                                            Category = Transactions::ServiceCategory.None,
                                            SubCategory = "sub_category",
                                        },
                                    ],
                                    TicketDocumentNumber = "ticket_document_number",
                                },
                                ComputerizedReservationSystem = "computerized_reservation_system",
                                CreditReasonIndicator =
                                    Transactions::TravelCreditReasonIndicator.NoCredit,
                                DepartureDate = "2019-12-27",
                                OriginationCityAirportCode = "origination_city_airport_code",
                                PassengerName = "passenger_name",
                                RestrictedTicketIndicator =
                                    Transactions::RestrictedTicketIndicator.NoRestrictions,
                                TicketChangeIndicator = Transactions::TicketChangeIndicator.None,
                                TicketNumber = "ticket_number",
                                TravelAgencyCode = "travel_agency_code",
                                TravelAgencyName = "travel_agency_name",
                                TripLegs =
                                [
                                    new()
                                    {
                                        CarrierCode = "carrier_code",
                                        DestinationCityAirportCode =
                                            "destination_city_airport_code",
                                        FareBasisCode = "fare_basis_code",
                                        FlightNumber = "flight_number",
                                        ServiceClass = "service_class",
                                        StopOverCode = Transactions::StopOverCode.None,
                                    },
                                ],
                            },
                        },
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                FeeType =
                                    Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::CardRefundType.CardRefund,
                    },
                    CardRevenuePayment = new()
                    {
                        Amount = 100,
                        Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                    },
                    CardSettlement = new()
                    {
                        ID = "card_settlement_khv5kfeu0vndj291omg6",
                        Amount = 100,
                        CardAuthorization = null,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Cashback = new()
                        {
                            Amount = "0.137465",
                            Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                        },
                        Currency = Transactions::CardSettlementCurrency.Usd,
                        Interchange = new()
                        {
                            Amount = "0.137465",
                            Code = "271",
                            Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                        },
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantName = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        Network = Transactions::CardSettlementNetwork.Visa,
                        NetworkIdentifiers = new()
                        {
                            AcquirerBusinessID = "69650702",
                            AcquirerReferenceNumber = "83163715445437604865089",
                            AuthorizationIdentificationResponse = "ABC123",
                            TransactionID = "627199945183184",
                        },
                        PendingTransactionID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        PurchaseDetails = new()
                        {
                            CarRental = new()
                            {
                                CarClassCode = "car_class_code",
                                CheckoutDate = "2019-12-27",
                                DailyRentalRateAmount = 0,
                                DailyRentalRateCurrency = "daily_rental_rate_currency",
                                DaysRented = 0,
                                ExtraCharges =
                                    Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                FuelChargesAmount = 0,
                                FuelChargesCurrency = "fuel_charges_currency",
                                InsuranceChargesAmount = 0,
                                InsuranceChargesCurrency = "insurance_charges_currency",
                                NoShowIndicator =
                                    Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                OneWayDropOffChargesAmount = 0,
                                OneWayDropOffChargesCurrency = "one_way_drop_off_charges_currency",
                                RenterName = "renter_name",
                                WeeklyRentalRateAmount = 0,
                                WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                            },
                            CustomerReferenceIdentifier = "51201",
                            LocalTaxAmount = null,
                            LocalTaxCurrency = "usd",
                            Lodging = new()
                            {
                                CheckInDate = "2023-07-20",
                                DailyRoomRateAmount = 1000,
                                DailyRoomRateCurrency = "usd",
                                ExtraCharges =
                                    Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                FolioCashAdvancesAmount = 0,
                                FolioCashAdvancesCurrency = "usd",
                                FoodBeverageChargesAmount = 0,
                                FoodBeverageChargesCurrency = "usd",
                                NoShowIndicator =
                                    Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                PrepaidExpensesAmount = 0,
                                PrepaidExpensesCurrency = "usd",
                                RoomNights = 1,
                                TotalRoomTaxAmount = 100,
                                TotalRoomTaxCurrency = "usd",
                                TotalTaxAmount = 100,
                                TotalTaxCurrency = "usd",
                            },
                            NationalTaxAmount = null,
                            NationalTaxCurrency = "usd",
                            PurchaseIdentifier = "10203",
                            PurchaseIdentifierFormat =
                                Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                            Travel = new()
                            {
                                Ancillary = new()
                                {
                                    ConnectedTicketDocumentNumber =
                                        "connected_ticket_document_number",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                    PassengerNameOrDescription = "passenger_name_or_description",
                                    Services =
                                    [
                                        new()
                                        {
                                            Category =
                                                Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                            SubCategory = "sub_category",
                                        },
                                    ],
                                    TicketDocumentNumber = "ticket_document_number",
                                },
                                ComputerizedReservationSystem = "computerized_reservation_system",
                                CreditReasonIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                DepartureDate = "2019-12-27",
                                OriginationCityAirportCode = "origination_city_airport_code",
                                PassengerName = "passenger_name",
                                RestrictedTicketIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                TicketChangeIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                TicketNumber = "ticket_number",
                                TravelAgencyCode = "travel_agency_code",
                                TravelAgencyName = "travel_agency_name",
                                TripLegs =
                                [
                                    new()
                                    {
                                        CarrierCode = "carrier_code",
                                        DestinationCityAirportCode =
                                            "destination_city_airport_code",
                                        FareBasisCode = "fare_basis_code",
                                        FlightNumber = "flight_number",
                                        ServiceClass = "service_class",
                                        StopOverCode =
                                            Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                    },
                                ],
                            },
                        },
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                FeeType =
                                    Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::CardSettlementType.CardSettlement,
                    },
                    CashbackPayment = new()
                    {
                        AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                        Amount = 100,
                        Currency = Transactions::CashbackPaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    CheckDepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    CheckDepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = Transactions::CheckDepositReturnCurrency.Usd,
                        ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CheckTransferDeposit = new()
                    {
                        BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                        BankOfFirstDepositRoutingNumber = null,
                        DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                    },
                    FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    FeePayment = new()
                    {
                        Amount = 100,
                        Currency = Transactions::FeePaymentCurrency.Usd,
                        FeePeriodStart = "2023-05-01",
                        ProgramID = "program_i2v2os4mwza1oetokh9i",
                    },
                    InboundAchTransfer = new()
                    {
                        Addenda = new()
                        {
                            Category = Transactions::AddendaCategory.Freeform,
                            Freeform = new([new("payment_related_information")]),
                        },
                        Amount = 100,
                        OriginatorCompanyDescriptiveDate = null,
                        OriginatorCompanyDiscretionaryData = null,
                        OriginatorCompanyEntryDescription = "RESERVE",
                        OriginatorCompanyID = "0987654321",
                        OriginatorCompanyName = "BIG BANK",
                        ReceiverIDNumber = "12345678900",
                        ReceiverName = "IAN CREASE",
                        TraceNumber = "021000038461022",
                        TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    },
                    InboundAchTransferReturnIntention = new(
                        "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                    ),
                    InboundCheckAdjustment = new()
                    {
                        AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Amount = 1750,
                        Reason = Transactions::Reason.LateReturn,
                    },
                    InboundCheckDepositReturnIntention = new()
                    {
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    InboundFednowTransferConfirmation = new(
                        "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                    ),
                    InboundRealTimePaymentsTransferConfirmation = new()
                    {
                        Amount = 100,
                        CreditorName = "Ian Crease",
                        Currency =
                            Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    InboundWireReversal = new()
                    {
                        Amount = 12345,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        DebtorRoutingNumber = "101050001",
                        Description = "Inbound wire reversal 2022021100335128",
                        InputCycleDate = "2022-02-11",
                        InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                        InputSequenceNumber = "11023",
                        InputSource = "B6B7HU2R",
                        InstructionIdentification = null,
                        ReturnReasonAdditionalInformation = null,
                        ReturnReasonCode = null,
                        ReturnReasonCodeDescription = null,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                    InboundWireTransfer = new()
                    {
                        Amount = 100,
                        CreditorAddressLine1 = null,
                        CreditorAddressLine2 = null,
                        CreditorAddressLine3 = null,
                        CreditorName = null,
                        DebtorAddressLine1 = null,
                        DebtorAddressLine2 = null,
                        DebtorAddressLine3 = null,
                        DebtorName = null,
                        Description = "Inbound wire transfer",
                        EndToEndIdentification = null,
                        InputMessageAccountabilityData = null,
                        InstructingAgentRoutingNumber = null,
                        InstructionIdentification = null,
                        TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                        UniqueEndToEndTransactionReference = null,
                        UnstructuredRemittanceInformation = null,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    InterestPayment = new()
                    {
                        AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                        Amount = 100,
                        Currency = Transactions::InterestPaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    InternalSource = new()
                    {
                        Amount = 100,
                        Currency = Transactions::InternalSourceCurrency.Usd,
                        Reason = Transactions::InternalSourceReason.SampleFunds,
                    },
                    Other = new(),
                    RealTimePaymentsTransferAcknowledgement = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        RoutingNumber = "101050001",
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    SampleFunds = new("dashboard"),
                    SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                    SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                    WireTransferIntention = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Type = Transactions::TransactionType.Transaction,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Transactions::TransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "transaction_uyrp7fld2ium70oa7oi",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = Transactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = Transactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = Transactions::SourceCategory.InboundAchTransfer,
                        AccountRevenuePayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        AccountTransferIntention = new()
                        {
                            Amount = 100,
                            Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                            Description = "INVOICE 2468",
                            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                            SourceAccountID = "account_in71c4amph0vgo2qllky",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            StatementDescriptor = "INVOICE 2468",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                        AchTransferReturn = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            RawReturnReasonCode = "R01",
                            ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                            TraceNumber = "111122223292834",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                        },
                        BlockchainOfframpTransferSettlement = new()
                        {
                            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                        },
                        BlockchainOnrampTransferIntention = new()
                        {
                            DestinationBlockchainAddress = "0xaabbccdd",
                            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                        },
                        CardDisputeAcceptance = new()
                        {
                            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardDisputeFinancial = new()
                        {
                            Amount = 1000,
                            Network = Transactions::Network.Visa,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Visa = new(Transactions::EventType.ChargebackSubmitted),
                        },
                        CardDisputeLoss = new()
                        {
                            Explanation = "The card dispute was lost.",
                            LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardFinancial = new()
                        {
                            ID = "card_financial_di5b98i72ppomo268zfk",
                            Actioner = Transactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = Transactions::CardFinancialCurrency.Usd,
                            DigitalWalletTokenID = null,
                            Direction = Transactions::Direction.Settlement,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkDetails = new()
                            {
                                Category = Transactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        Transactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        Transactions::TerminalEntryCapability.MagneticStripe,
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
                            PhysicalCardID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::SchemeFeeCurrency.Usd,
                                    FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TerminalID = "RCN5VNXS",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::Type.CardFinancial,
                            Verification = new()
                            {
                                CardVerificationCode = new(Transactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CardPushTransferAcceptance = new()
                        {
                            SettlementAmount = 100,
                            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                        },
                        CardRefund = new()
                        {
                            ID = "card_refund_imgc2xwplh6t4r3gn16e",
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardRefundCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::InterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::PurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category = Transactions::ServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::TravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::RestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::TicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode = Transactions::StopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardRefundType.CardRefund,
                        },
                        CardRevenuePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                            TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                        },
                        CardSettlement = new()
                        {
                            ID = "card_settlement_khv5kfeu0vndj291omg6",
                            Amount = 100,
                            CardAuthorization = null,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardSettlementCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            Network = Transactions::CardSettlementNetwork.Visa,
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PendingTransactionID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category =
                                                    Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode =
                                                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardSettlementType.CardSettlement,
                        },
                        CashbackPayment = new()
                        {
                            AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                            Amount = 100,
                            Currency = Transactions::CashbackPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        CheckDepositAcceptance = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 1000,
                            AuxiliaryOnUs = "101",
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                            RoutingNumber = "101050001",
                            SerialNumber = null,
                        },
                        CheckDepositReturn = new()
                        {
                            Amount = 100,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositReturnCurrency.Usd,
                            ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CheckTransferDeposit = new()
                        {
                            BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            BankOfFirstDepositRoutingNumber = null,
                            DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                        },
                        FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                        FeePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::FeePaymentCurrency.Usd,
                            FeePeriodStart = "2023-05-01",
                            ProgramID = "program_i2v2os4mwza1oetokh9i",
                        },
                        InboundAchTransfer = new()
                        {
                            Addenda = new()
                            {
                                Category = Transactions::AddendaCategory.Freeform,
                                Freeform = new([new("payment_related_information")]),
                            },
                            Amount = 100,
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyEntryDescription = "RESERVE",
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        },
                        InboundAchTransferReturnIntention = new(
                            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                        ),
                        InboundCheckAdjustment = new()
                        {
                            AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Amount = 1750,
                            Reason = Transactions::Reason.LateReturn,
                        },
                        InboundCheckDepositReturnIntention = new()
                        {
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        },
                        InboundFednowTransferConfirmation = new(
                            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                        ),
                        InboundRealTimePaymentsTransferConfirmation = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        InboundWireReversal = new()
                        {
                            Amount = 12345,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            DebtorRoutingNumber = "101050001",
                            Description = "Inbound wire reversal 2022021100335128",
                            InputCycleDate = "2022-02-11",
                            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                            InputSequenceNumber = "11023",
                            InputSource = "B6B7HU2R",
                            InstructionIdentification = null,
                            ReturnReasonAdditionalInformation = null,
                            ReturnReasonCode = null,
                            ReturnReasonCodeDescription = null,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                        InboundWireTransfer = new()
                        {
                            Amount = 100,
                            CreditorAddressLine1 = null,
                            CreditorAddressLine2 = null,
                            CreditorAddressLine3 = null,
                            CreditorName = null,
                            DebtorAddressLine1 = null,
                            DebtorAddressLine2 = null,
                            DebtorAddressLine3 = null,
                            DebtorName = null,
                            Description = "Inbound wire transfer",
                            EndToEndIdentification = null,
                            InputMessageAccountabilityData = null,
                            InstructingAgentRoutingNumber = null,
                            InstructionIdentification = null,
                            TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            UniqueEndToEndTransactionReference = null,
                            UnstructuredRemittanceInformation = null,
                        },
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
                        InterestPayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            Amount = 100,
                            Currency = Transactions::InterestPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        InternalSource = new()
                        {
                            Amount = 100,
                            Currency = Transactions::InternalSourceCurrency.Usd,
                            Reason = Transactions::InternalSourceReason.SampleFunds,
                        },
                        Other = new(),
                        RealTimePaymentsTransferAcknowledgement = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        SampleFunds = new("dashboard"),
                        SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                        SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                        WireTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            MessageToRecipient = "HELLO",
                            RoutingNumber = "101050001",
                            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                    },
                    Type = Transactions::TransactionType.Transaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transactions::TransactionListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Transactions::TransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "transaction_uyrp7fld2ium70oa7oi",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = Transactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = Transactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = Transactions::SourceCategory.InboundAchTransfer,
                        AccountRevenuePayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        AccountTransferIntention = new()
                        {
                            Amount = 100,
                            Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                            Description = "INVOICE 2468",
                            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                            SourceAccountID = "account_in71c4amph0vgo2qllky",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            StatementDescriptor = "INVOICE 2468",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                        AchTransferReturn = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            RawReturnReasonCode = "R01",
                            ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                            TraceNumber = "111122223292834",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                        },
                        BlockchainOfframpTransferSettlement = new()
                        {
                            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                        },
                        BlockchainOnrampTransferIntention = new()
                        {
                            DestinationBlockchainAddress = "0xaabbccdd",
                            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                        },
                        CardDisputeAcceptance = new()
                        {
                            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardDisputeFinancial = new()
                        {
                            Amount = 1000,
                            Network = Transactions::Network.Visa,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Visa = new(Transactions::EventType.ChargebackSubmitted),
                        },
                        CardDisputeLoss = new()
                        {
                            Explanation = "The card dispute was lost.",
                            LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardFinancial = new()
                        {
                            ID = "card_financial_di5b98i72ppomo268zfk",
                            Actioner = Transactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = Transactions::CardFinancialCurrency.Usd,
                            DigitalWalletTokenID = null,
                            Direction = Transactions::Direction.Settlement,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkDetails = new()
                            {
                                Category = Transactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        Transactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        Transactions::TerminalEntryCapability.MagneticStripe,
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
                            PhysicalCardID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::SchemeFeeCurrency.Usd,
                                    FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TerminalID = "RCN5VNXS",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::Type.CardFinancial,
                            Verification = new()
                            {
                                CardVerificationCode = new(Transactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CardPushTransferAcceptance = new()
                        {
                            SettlementAmount = 100,
                            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                        },
                        CardRefund = new()
                        {
                            ID = "card_refund_imgc2xwplh6t4r3gn16e",
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardRefundCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::InterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::PurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category = Transactions::ServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::TravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::RestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::TicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode = Transactions::StopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardRefundType.CardRefund,
                        },
                        CardRevenuePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                            TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                        },
                        CardSettlement = new()
                        {
                            ID = "card_settlement_khv5kfeu0vndj291omg6",
                            Amount = 100,
                            CardAuthorization = null,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardSettlementCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            Network = Transactions::CardSettlementNetwork.Visa,
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PendingTransactionID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category =
                                                    Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode =
                                                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardSettlementType.CardSettlement,
                        },
                        CashbackPayment = new()
                        {
                            AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                            Amount = 100,
                            Currency = Transactions::CashbackPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        CheckDepositAcceptance = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 1000,
                            AuxiliaryOnUs = "101",
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                            RoutingNumber = "101050001",
                            SerialNumber = null,
                        },
                        CheckDepositReturn = new()
                        {
                            Amount = 100,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositReturnCurrency.Usd,
                            ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CheckTransferDeposit = new()
                        {
                            BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            BankOfFirstDepositRoutingNumber = null,
                            DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                        },
                        FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                        FeePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::FeePaymentCurrency.Usd,
                            FeePeriodStart = "2023-05-01",
                            ProgramID = "program_i2v2os4mwza1oetokh9i",
                        },
                        InboundAchTransfer = new()
                        {
                            Addenda = new()
                            {
                                Category = Transactions::AddendaCategory.Freeform,
                                Freeform = new([new("payment_related_information")]),
                            },
                            Amount = 100,
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyEntryDescription = "RESERVE",
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        },
                        InboundAchTransferReturnIntention = new(
                            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                        ),
                        InboundCheckAdjustment = new()
                        {
                            AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Amount = 1750,
                            Reason = Transactions::Reason.LateReturn,
                        },
                        InboundCheckDepositReturnIntention = new()
                        {
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        },
                        InboundFednowTransferConfirmation = new(
                            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                        ),
                        InboundRealTimePaymentsTransferConfirmation = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        InboundWireReversal = new()
                        {
                            Amount = 12345,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            DebtorRoutingNumber = "101050001",
                            Description = "Inbound wire reversal 2022021100335128",
                            InputCycleDate = "2022-02-11",
                            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                            InputSequenceNumber = "11023",
                            InputSource = "B6B7HU2R",
                            InstructionIdentification = null,
                            ReturnReasonAdditionalInformation = null,
                            ReturnReasonCode = null,
                            ReturnReasonCodeDescription = null,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                        InboundWireTransfer = new()
                        {
                            Amount = 100,
                            CreditorAddressLine1 = null,
                            CreditorAddressLine2 = null,
                            CreditorAddressLine3 = null,
                            CreditorName = null,
                            DebtorAddressLine1 = null,
                            DebtorAddressLine2 = null,
                            DebtorAddressLine3 = null,
                            DebtorName = null,
                            Description = "Inbound wire transfer",
                            EndToEndIdentification = null,
                            InputMessageAccountabilityData = null,
                            InstructingAgentRoutingNumber = null,
                            InstructionIdentification = null,
                            TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            UniqueEndToEndTransactionReference = null,
                            UnstructuredRemittanceInformation = null,
                        },
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
                        InterestPayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            Amount = 100,
                            Currency = Transactions::InterestPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        InternalSource = new()
                        {
                            Amount = 100,
                            Currency = Transactions::InternalSourceCurrency.Usd,
                            Reason = Transactions::InternalSourceReason.SampleFunds,
                        },
                        Other = new(),
                        RealTimePaymentsTransferAcknowledgement = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        SampleFunds = new("dashboard"),
                        SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                        SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                        WireTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            MessageToRecipient = "HELLO",
                            RoutingNumber = "101050001",
                            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                    },
                    Type = Transactions::TransactionType.Transaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Transactions::TransactionListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Transactions::Transaction> expectedData =
        [
            new()
            {
                ID = "transaction_uyrp7fld2ium70oa7oi",
                AccountID = "account_in71c4amph0vgo2qllky",
                Amount = 100,
                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                Currency = Transactions::Currency.Usd,
                Description = "INVOICE 2468",
                RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                RouteType = Transactions::RouteType.AccountNumber,
                Source = new()
                {
                    Category = Transactions::SourceCategory.InboundAchTransfer,
                    AccountRevenuePayment = new()
                    {
                        AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    AccountTransferIntention = new()
                    {
                        Amount = 100,
                        Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                        Description = "INVOICE 2468",
                        DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                        SourceAccountID = "account_in71c4amph0vgo2qllky",
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferIntention = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        RoutingNumber = "101050001",
                        StatementDescriptor = "INVOICE 2468",
                        TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                    },
                    AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                    AchTransferReturn = new()
                    {
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        RawReturnReasonCode = "R01",
                        ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                        TraceNumber = "111122223292834",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                    },
                    BlockchainOfframpTransferSettlement = new()
                    {
                        SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                        TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                    },
                    BlockchainOnrampTransferIntention = new()
                    {
                        DestinationBlockchainAddress = "0xaabbccdd",
                        TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                    },
                    CardDisputeAcceptance = new()
                    {
                        AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CardDisputeFinancial = new()
                    {
                        Amount = 1000,
                        Network = Transactions::Network.Visa,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Visa = new(Transactions::EventType.ChargebackSubmitted),
                    },
                    CardDisputeLoss = new()
                    {
                        Explanation = "The card dispute was lost.",
                        LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CardFinancial = new()
                    {
                        ID = "card_financial_di5b98i72ppomo268zfk",
                        Actioner = Transactions::Actioner.Increase,
                        AdditionalAmounts = new()
                        {
                            Clinic = new() { Amount = 0, Currency = "currency" },
                            Dental = new() { Amount = 0, Currency = "currency" },
                            Original = new() { Amount = 0, Currency = "currency" },
                            Prescription = new() { Amount = 0, Currency = "currency" },
                            Surcharge = new() { Amount = 10, Currency = "USD" },
                            TotalCumulative = new() { Amount = 0, Currency = "currency" },
                            TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                            Transit = new() { Amount = 0, Currency = "currency" },
                            Unknown = new() { Amount = 0, Currency = "currency" },
                            Vision = new() { Amount = 0, Currency = "currency" },
                        },
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Currency = Transactions::CardFinancialCurrency.Usd,
                        DigitalWalletTokenID = null,
                        Direction = Transactions::Direction.Settlement,
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantDescriptor = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkDetails = new()
                        {
                            Category = Transactions::NetworkDetailsCategory.Visa,
                            Pulse = new(),
                            Visa = new()
                            {
                                ElectronicCommerceIndicator =
                                    Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                PointOfServiceEntryMode =
                                    Transactions::PointOfServiceEntryMode.Manual,
                                StandInProcessingReason = null,
                                TerminalEntryCapability =
                                    Transactions::TerminalEntryCapability.MagneticStripe,
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
                        PhysicalCardID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                        RealTimeDecisionID = null,
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::SchemeFeeCurrency.Usd,
                                FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        TerminalID = "RCN5VNXS",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::Type.CardFinancial,
                        Verification = new()
                        {
                            CardVerificationCode = new(Transactions::Result.Match),
                            CardholderAddress = new()
                            {
                                ActualLine1 = "33 Liberty Street",
                                ActualPostalCode = "94131",
                                ProvidedLine1 = "33 Liberty Street",
                                ProvidedPostalCode = "94132",
                                Result =
                                    Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                            },
                            CardholderName = new()
                            {
                                ProvidedFirstName = "provided_first_name",
                                ProvidedLastName = "provided_last_name",
                                ProvidedMiddleName = "provided_middle_name",
                            },
                        },
                    },
                    CardPushTransferAcceptance = new()
                    {
                        SettlementAmount = 100,
                        TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                    },
                    CardRefund = new()
                    {
                        ID = "card_refund_imgc2xwplh6t4r3gn16e",
                        Amount = 100,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Cashback = new()
                        {
                            Amount = "0.137465",
                            Currency = Transactions::CashbackCurrency.Usd,
                        },
                        Currency = Transactions::CardRefundCurrency.Usd,
                        Interchange = new()
                        {
                            Amount = "0.137465",
                            Code = "271",
                            Currency = Transactions::InterchangeCurrency.Usd,
                        },
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantName = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        NetworkIdentifiers = new()
                        {
                            AcquirerBusinessID = "69650702",
                            AcquirerReferenceNumber = "83163715445437604865089",
                            AuthorizationIdentificationResponse = "ABC123",
                            TransactionID = "627199945183184",
                        },
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        PurchaseDetails = new()
                        {
                            CarRental = new()
                            {
                                CarClassCode = "car_class_code",
                                CheckoutDate = "2019-12-27",
                                DailyRentalRateAmount = 0,
                                DailyRentalRateCurrency = "daily_rental_rate_currency",
                                DaysRented = 0,
                                ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                FuelChargesAmount = 0,
                                FuelChargesCurrency = "fuel_charges_currency",
                                InsuranceChargesAmount = 0,
                                InsuranceChargesCurrency = "insurance_charges_currency",
                                NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                OneWayDropOffChargesAmount = 0,
                                OneWayDropOffChargesCurrency = "one_way_drop_off_charges_currency",
                                RenterName = "renter_name",
                                WeeklyRentalRateAmount = 0,
                                WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                            },
                            CustomerReferenceIdentifier = "51201",
                            LocalTaxAmount = null,
                            LocalTaxCurrency = "usd",
                            Lodging = new()
                            {
                                CheckInDate = "2023-07-20",
                                DailyRoomRateAmount = 1000,
                                DailyRoomRateCurrency = "usd",
                                ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                FolioCashAdvancesAmount = 0,
                                FolioCashAdvancesCurrency = "usd",
                                FoodBeverageChargesAmount = 0,
                                FoodBeverageChargesCurrency = "usd",
                                NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                PrepaidExpensesAmount = 0,
                                PrepaidExpensesCurrency = "usd",
                                RoomNights = 1,
                                TotalRoomTaxAmount = 100,
                                TotalRoomTaxCurrency = "usd",
                                TotalTaxAmount = 100,
                                TotalTaxCurrency = "usd",
                            },
                            NationalTaxAmount = null,
                            NationalTaxCurrency = "usd",
                            PurchaseIdentifier = "10203",
                            PurchaseIdentifierFormat =
                                Transactions::PurchaseIdentifierFormat.OrderNumber,
                            Travel = new()
                            {
                                Ancillary = new()
                                {
                                    ConnectedTicketDocumentNumber =
                                        "connected_ticket_document_number",
                                    CreditReasonIndicator =
                                        Transactions::CreditReasonIndicator.NoCredit,
                                    PassengerNameOrDescription = "passenger_name_or_description",
                                    Services =
                                    [
                                        new()
                                        {
                                            Category = Transactions::ServiceCategory.None,
                                            SubCategory = "sub_category",
                                        },
                                    ],
                                    TicketDocumentNumber = "ticket_document_number",
                                },
                                ComputerizedReservationSystem = "computerized_reservation_system",
                                CreditReasonIndicator =
                                    Transactions::TravelCreditReasonIndicator.NoCredit,
                                DepartureDate = "2019-12-27",
                                OriginationCityAirportCode = "origination_city_airport_code",
                                PassengerName = "passenger_name",
                                RestrictedTicketIndicator =
                                    Transactions::RestrictedTicketIndicator.NoRestrictions,
                                TicketChangeIndicator = Transactions::TicketChangeIndicator.None,
                                TicketNumber = "ticket_number",
                                TravelAgencyCode = "travel_agency_code",
                                TravelAgencyName = "travel_agency_name",
                                TripLegs =
                                [
                                    new()
                                    {
                                        CarrierCode = "carrier_code",
                                        DestinationCityAirportCode =
                                            "destination_city_airport_code",
                                        FareBasisCode = "fare_basis_code",
                                        FlightNumber = "flight_number",
                                        ServiceClass = "service_class",
                                        StopOverCode = Transactions::StopOverCode.None,
                                    },
                                ],
                            },
                        },
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                FeeType =
                                    Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::CardRefundType.CardRefund,
                    },
                    CardRevenuePayment = new()
                    {
                        Amount = 100,
                        Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                    },
                    CardSettlement = new()
                    {
                        ID = "card_settlement_khv5kfeu0vndj291omg6",
                        Amount = 100,
                        CardAuthorization = null,
                        CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                        Cashback = new()
                        {
                            Amount = "0.137465",
                            Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                        },
                        Currency = Transactions::CardSettlementCurrency.Usd,
                        Interchange = new()
                        {
                            Amount = "0.137465",
                            Code = "271",
                            Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                        },
                        MerchantAcceptorID = "5665270011000168",
                        MerchantCategoryCode = "5734",
                        MerchantCity = "New York",
                        MerchantCountry = "US",
                        MerchantName = "AMAZON.COM",
                        MerchantPostalCode = "10045",
                        MerchantState = "NY",
                        Network = Transactions::CardSettlementNetwork.Visa,
                        NetworkIdentifiers = new()
                        {
                            AcquirerBusinessID = "69650702",
                            AcquirerReferenceNumber = "83163715445437604865089",
                            AuthorizationIdentificationResponse = "ABC123",
                            TransactionID = "627199945183184",
                        },
                        PendingTransactionID = null,
                        PresentmentAmount = 100,
                        PresentmentCurrency = "USD",
                        PurchaseDetails = new()
                        {
                            CarRental = new()
                            {
                                CarClassCode = "car_class_code",
                                CheckoutDate = "2019-12-27",
                                DailyRentalRateAmount = 0,
                                DailyRentalRateCurrency = "daily_rental_rate_currency",
                                DaysRented = 0,
                                ExtraCharges =
                                    Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                FuelChargesAmount = 0,
                                FuelChargesCurrency = "fuel_charges_currency",
                                InsuranceChargesAmount = 0,
                                InsuranceChargesCurrency = "insurance_charges_currency",
                                NoShowIndicator =
                                    Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                OneWayDropOffChargesAmount = 0,
                                OneWayDropOffChargesCurrency = "one_way_drop_off_charges_currency",
                                RenterName = "renter_name",
                                WeeklyRentalRateAmount = 0,
                                WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                            },
                            CustomerReferenceIdentifier = "51201",
                            LocalTaxAmount = null,
                            LocalTaxCurrency = "usd",
                            Lodging = new()
                            {
                                CheckInDate = "2023-07-20",
                                DailyRoomRateAmount = 1000,
                                DailyRoomRateCurrency = "usd",
                                ExtraCharges =
                                    Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                FolioCashAdvancesAmount = 0,
                                FolioCashAdvancesCurrency = "usd",
                                FoodBeverageChargesAmount = 0,
                                FoodBeverageChargesCurrency = "usd",
                                NoShowIndicator =
                                    Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                PrepaidExpensesAmount = 0,
                                PrepaidExpensesCurrency = "usd",
                                RoomNights = 1,
                                TotalRoomTaxAmount = 100,
                                TotalRoomTaxCurrency = "usd",
                                TotalTaxAmount = 100,
                                TotalTaxCurrency = "usd",
                            },
                            NationalTaxAmount = null,
                            NationalTaxCurrency = "usd",
                            PurchaseIdentifier = "10203",
                            PurchaseIdentifierFormat =
                                Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                            Travel = new()
                            {
                                Ancillary = new()
                                {
                                    ConnectedTicketDocumentNumber =
                                        "connected_ticket_document_number",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                    PassengerNameOrDescription = "passenger_name_or_description",
                                    Services =
                                    [
                                        new()
                                        {
                                            Category =
                                                Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                            SubCategory = "sub_category",
                                        },
                                    ],
                                    TicketDocumentNumber = "ticket_document_number",
                                },
                                ComputerizedReservationSystem = "computerized_reservation_system",
                                CreditReasonIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                DepartureDate = "2019-12-27",
                                OriginationCityAirportCode = "origination_city_airport_code",
                                PassengerName = "passenger_name",
                                RestrictedTicketIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                TicketChangeIndicator =
                                    Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                TicketNumber = "ticket_number",
                                TravelAgencyCode = "travel_agency_code",
                                TravelAgencyName = "travel_agency_name",
                                TripLegs =
                                [
                                    new()
                                    {
                                        CarrierCode = "carrier_code",
                                        DestinationCityAirportCode =
                                            "destination_city_airport_code",
                                        FareBasisCode = "fare_basis_code",
                                        FlightNumber = "flight_number",
                                        ServiceClass = "service_class",
                                        StopOverCode =
                                            Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                    },
                                ],
                            },
                        },
                        SchemeFees =
                        [
                            new()
                            {
                                Amount = "0.137465",
                                CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                FeeType =
                                    Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                FixedComponent = null,
                                VariableRate = "0.0002",
                            },
                        ],
                        Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Type = Transactions::CardSettlementType.CardSettlement,
                    },
                    CashbackPayment = new()
                    {
                        AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                        Amount = 100,
                        Currency = Transactions::CashbackPaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    CheckDepositAcceptance = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 1000,
                        AuxiliaryOnUs = "101",
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                        RoutingNumber = "101050001",
                        SerialNumber = null,
                    },
                    CheckDepositReturn = new()
                    {
                        Amount = 100,
                        CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                        Currency = Transactions::CheckDepositReturnCurrency.Usd,
                        ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                        ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                    },
                    CheckTransferDeposit = new()
                    {
                        BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                        BankOfFirstDepositRoutingNumber = null,
                        DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                    },
                    FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                    FeePayment = new()
                    {
                        Amount = 100,
                        Currency = Transactions::FeePaymentCurrency.Usd,
                        FeePeriodStart = "2023-05-01",
                        ProgramID = "program_i2v2os4mwza1oetokh9i",
                    },
                    InboundAchTransfer = new()
                    {
                        Addenda = new()
                        {
                            Category = Transactions::AddendaCategory.Freeform,
                            Freeform = new([new("payment_related_information")]),
                        },
                        Amount = 100,
                        OriginatorCompanyDescriptiveDate = null,
                        OriginatorCompanyDiscretionaryData = null,
                        OriginatorCompanyEntryDescription = "RESERVE",
                        OriginatorCompanyID = "0987654321",
                        OriginatorCompanyName = "BIG BANK",
                        ReceiverIDNumber = "12345678900",
                        ReceiverName = "IAN CREASE",
                        TraceNumber = "021000038461022",
                        TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                    },
                    InboundAchTransferReturnIntention = new(
                        "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                    ),
                    InboundCheckAdjustment = new()
                    {
                        AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        Amount = 1750,
                        Reason = Transactions::Reason.LateReturn,
                    },
                    InboundCheckDepositReturnIntention = new()
                    {
                        InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                        TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                    },
                    InboundFednowTransferConfirmation = new(
                        "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                    ),
                    InboundRealTimePaymentsTransferConfirmation = new()
                    {
                        Amount = 100,
                        CreditorName = "Ian Crease",
                        Currency =
                            Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                        DebtorAccountNumber = "987654321",
                        DebtorName = "National Phonograph Company",
                        DebtorRoutingNumber = "101050001",
                        TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                        TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    InboundWireReversal = new()
                    {
                        Amount = 12345,
                        CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                        DebtorRoutingNumber = "101050001",
                        Description = "Inbound wire reversal 2022021100335128",
                        InputCycleDate = "2022-02-11",
                        InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                        InputSequenceNumber = "11023",
                        InputSource = "B6B7HU2R",
                        InstructionIdentification = null,
                        ReturnReasonAdditionalInformation = null,
                        ReturnReasonCode = null,
                        ReturnReasonCodeDescription = null,
                        TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                    InboundWireTransfer = new()
                    {
                        Amount = 100,
                        CreditorAddressLine1 = null,
                        CreditorAddressLine2 = null,
                        CreditorAddressLine3 = null,
                        CreditorName = null,
                        DebtorAddressLine1 = null,
                        DebtorAddressLine2 = null,
                        DebtorAddressLine3 = null,
                        DebtorName = null,
                        Description = "Inbound wire transfer",
                        EndToEndIdentification = null,
                        InputMessageAccountabilityData = null,
                        InstructingAgentRoutingNumber = null,
                        InstructionIdentification = null,
                        TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                        UniqueEndToEndTransactionReference = null,
                        UnstructuredRemittanceInformation = null,
                    },
                    InboundWireTransferReversal = new("inbound_wire_transfer_f228m6bmhtcxjco9pwp0"),
                    InterestPayment = new()
                    {
                        AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                        Amount = 100,
                        Currency = Transactions::InterestPaymentCurrency.Usd,
                        PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                        PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                    },
                    InternalSource = new()
                    {
                        Amount = 100,
                        Currency = Transactions::InternalSourceCurrency.Usd,
                        Reason = Transactions::InternalSourceReason.SampleFunds,
                    },
                    Other = new(),
                    RealTimePaymentsTransferAcknowledgement = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        RoutingNumber = "101050001",
                        TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                        UnstructuredRemittanceInformation = "Invoice 29582",
                    },
                    SampleFunds = new("dashboard"),
                    SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                    SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                    WireTransferIntention = new()
                    {
                        AccountNumber = "987654321",
                        Amount = 100,
                        MessageToRecipient = "HELLO",
                        RoutingNumber = "101050001",
                        TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                    },
                },
                Type = Transactions::TransactionType.Transaction,
            },
        ];
        string expectedNextCursor = "v57w5d";

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Transactions::TransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "transaction_uyrp7fld2ium70oa7oi",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = Transactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = Transactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = Transactions::SourceCategory.InboundAchTransfer,
                        AccountRevenuePayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        AccountTransferIntention = new()
                        {
                            Amount = 100,
                            Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                            Description = "INVOICE 2468",
                            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                            SourceAccountID = "account_in71c4amph0vgo2qllky",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            StatementDescriptor = "INVOICE 2468",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                        AchTransferReturn = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            RawReturnReasonCode = "R01",
                            ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                            TraceNumber = "111122223292834",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                        },
                        BlockchainOfframpTransferSettlement = new()
                        {
                            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                        },
                        BlockchainOnrampTransferIntention = new()
                        {
                            DestinationBlockchainAddress = "0xaabbccdd",
                            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                        },
                        CardDisputeAcceptance = new()
                        {
                            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardDisputeFinancial = new()
                        {
                            Amount = 1000,
                            Network = Transactions::Network.Visa,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Visa = new(Transactions::EventType.ChargebackSubmitted),
                        },
                        CardDisputeLoss = new()
                        {
                            Explanation = "The card dispute was lost.",
                            LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardFinancial = new()
                        {
                            ID = "card_financial_di5b98i72ppomo268zfk",
                            Actioner = Transactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = Transactions::CardFinancialCurrency.Usd,
                            DigitalWalletTokenID = null,
                            Direction = Transactions::Direction.Settlement,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkDetails = new()
                            {
                                Category = Transactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        Transactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        Transactions::TerminalEntryCapability.MagneticStripe,
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
                            PhysicalCardID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::SchemeFeeCurrency.Usd,
                                    FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TerminalID = "RCN5VNXS",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::Type.CardFinancial,
                            Verification = new()
                            {
                                CardVerificationCode = new(Transactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CardPushTransferAcceptance = new()
                        {
                            SettlementAmount = 100,
                            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                        },
                        CardRefund = new()
                        {
                            ID = "card_refund_imgc2xwplh6t4r3gn16e",
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardRefundCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::InterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::PurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category = Transactions::ServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::TravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::RestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::TicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode = Transactions::StopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardRefundType.CardRefund,
                        },
                        CardRevenuePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                            TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                        },
                        CardSettlement = new()
                        {
                            ID = "card_settlement_khv5kfeu0vndj291omg6",
                            Amount = 100,
                            CardAuthorization = null,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardSettlementCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            Network = Transactions::CardSettlementNetwork.Visa,
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PendingTransactionID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category =
                                                    Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode =
                                                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardSettlementType.CardSettlement,
                        },
                        CashbackPayment = new()
                        {
                            AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                            Amount = 100,
                            Currency = Transactions::CashbackPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        CheckDepositAcceptance = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 1000,
                            AuxiliaryOnUs = "101",
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                            RoutingNumber = "101050001",
                            SerialNumber = null,
                        },
                        CheckDepositReturn = new()
                        {
                            Amount = 100,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositReturnCurrency.Usd,
                            ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CheckTransferDeposit = new()
                        {
                            BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            BankOfFirstDepositRoutingNumber = null,
                            DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                        },
                        FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                        FeePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::FeePaymentCurrency.Usd,
                            FeePeriodStart = "2023-05-01",
                            ProgramID = "program_i2v2os4mwza1oetokh9i",
                        },
                        InboundAchTransfer = new()
                        {
                            Addenda = new()
                            {
                                Category = Transactions::AddendaCategory.Freeform,
                                Freeform = new([new("payment_related_information")]),
                            },
                            Amount = 100,
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyEntryDescription = "RESERVE",
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        },
                        InboundAchTransferReturnIntention = new(
                            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                        ),
                        InboundCheckAdjustment = new()
                        {
                            AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Amount = 1750,
                            Reason = Transactions::Reason.LateReturn,
                        },
                        InboundCheckDepositReturnIntention = new()
                        {
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        },
                        InboundFednowTransferConfirmation = new(
                            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                        ),
                        InboundRealTimePaymentsTransferConfirmation = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        InboundWireReversal = new()
                        {
                            Amount = 12345,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            DebtorRoutingNumber = "101050001",
                            Description = "Inbound wire reversal 2022021100335128",
                            InputCycleDate = "2022-02-11",
                            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                            InputSequenceNumber = "11023",
                            InputSource = "B6B7HU2R",
                            InstructionIdentification = null,
                            ReturnReasonAdditionalInformation = null,
                            ReturnReasonCode = null,
                            ReturnReasonCodeDescription = null,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                        InboundWireTransfer = new()
                        {
                            Amount = 100,
                            CreditorAddressLine1 = null,
                            CreditorAddressLine2 = null,
                            CreditorAddressLine3 = null,
                            CreditorName = null,
                            DebtorAddressLine1 = null,
                            DebtorAddressLine2 = null,
                            DebtorAddressLine3 = null,
                            DebtorName = null,
                            Description = "Inbound wire transfer",
                            EndToEndIdentification = null,
                            InputMessageAccountabilityData = null,
                            InstructingAgentRoutingNumber = null,
                            InstructionIdentification = null,
                            TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            UniqueEndToEndTransactionReference = null,
                            UnstructuredRemittanceInformation = null,
                        },
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
                        InterestPayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            Amount = 100,
                            Currency = Transactions::InterestPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        InternalSource = new()
                        {
                            Amount = 100,
                            Currency = Transactions::InternalSourceCurrency.Usd,
                            Reason = Transactions::InternalSourceReason.SampleFunds,
                        },
                        Other = new(),
                        RealTimePaymentsTransferAcknowledgement = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        SampleFunds = new("dashboard"),
                        SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                        SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                        WireTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            MessageToRecipient = "HELLO",
                            RoutingNumber = "101050001",
                            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                    },
                    Type = Transactions::TransactionType.Transaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Transactions::TransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "transaction_uyrp7fld2ium70oa7oi",
                    AccountID = "account_in71c4amph0vgo2qllky",
                    Amount = 100,
                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                    Currency = Transactions::Currency.Usd,
                    Description = "INVOICE 2468",
                    RouteID = "account_number_v18nkfqm6afpsrvy82b2",
                    RouteType = Transactions::RouteType.AccountNumber,
                    Source = new()
                    {
                        Category = Transactions::SourceCategory.InboundAchTransfer,
                        AccountRevenuePayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        AccountTransferIntention = new()
                        {
                            Amount = 100,
                            Currency = Transactions::AccountTransferIntentionCurrency.Usd,
                            Description = "INVOICE 2468",
                            DestinationAccountID = "account_uf16sut2ct5bevmq3eh",
                            SourceAccountID = "account_in71c4amph0vgo2qllky",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            StatementDescriptor = "INVOICE 2468",
                            TransferID = "account_transfer_7k9qe1ysdgqztnt63l7n",
                        },
                        AchTransferRejection = new("account_transfer_7k9qe1ysdgqztnt63l7n"),
                        AchTransferReturn = new()
                        {
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            RawReturnReasonCode = "R01",
                            ReturnReasonCode = Transactions::ReturnReasonCode.InsufficientFund,
                            TraceNumber = "111122223292834",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "ach_transfer_uoxatyh3lt5evrsdvo7q",
                        },
                        BlockchainOfframpTransferSettlement = new()
                        {
                            SourceBlockchainAddressID = "blockchain_address_tijjpqp9t5d358ehydqi",
                            TransferID = "blockchain_offramp_transfer_sqd2x3ti6u2sy91v696m",
                        },
                        BlockchainOnrampTransferIntention = new()
                        {
                            DestinationBlockchainAddress = "0xaabbccdd",
                            TransferID = "blockchain_onramp_transfer_sg8nzy569rk0dnfk28bv",
                        },
                        CardDisputeAcceptance = new()
                        {
                            AcceptedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardDisputeFinancial = new()
                        {
                            Amount = 1000,
                            Network = Transactions::Network.Visa,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Visa = new(Transactions::EventType.ChargebackSubmitted),
                        },
                        CardDisputeLoss = new()
                        {
                            Explanation = "The card dispute was lost.",
                            LostAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CardFinancial = new()
                        {
                            ID = "card_financial_di5b98i72ppomo268zfk",
                            Actioner = Transactions::Actioner.Increase,
                            AdditionalAmounts = new()
                            {
                                Clinic = new() { Amount = 0, Currency = "currency" },
                                Dental = new() { Amount = 0, Currency = "currency" },
                                Original = new() { Amount = 0, Currency = "currency" },
                                Prescription = new() { Amount = 0, Currency = "currency" },
                                Surcharge = new() { Amount = 10, Currency = "USD" },
                                TotalCumulative = new() { Amount = 0, Currency = "currency" },
                                TotalHealthcare = new() { Amount = 0, Currency = "currency" },
                                Transit = new() { Amount = 0, Currency = "currency" },
                                Unknown = new() { Amount = 0, Currency = "currency" },
                                Vision = new() { Amount = 0, Currency = "currency" },
                            },
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Currency = Transactions::CardFinancialCurrency.Usd,
                            DigitalWalletTokenID = null,
                            Direction = Transactions::Direction.Settlement,
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantDescriptor = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkDetails = new()
                            {
                                Category = Transactions::NetworkDetailsCategory.Visa,
                                Pulse = new(),
                                Visa = new()
                                {
                                    ElectronicCommerceIndicator =
                                        Transactions::ElectronicCommerceIndicator.SecureElectronicCommerce,
                                    PointOfServiceEntryMode =
                                        Transactions::PointOfServiceEntryMode.Manual,
                                    StandInProcessingReason = null,
                                    TerminalEntryCapability =
                                        Transactions::TerminalEntryCapability.MagneticStripe,
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
                            PhysicalCardID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            ProcessingCategory = Transactions::ProcessingCategory.Purchase,
                            RealTimeDecisionID = null,
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::SchemeFeeCurrency.Usd,
                                    FeeType = Transactions::FeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TerminalID = "RCN5VNXS",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::Type.CardFinancial,
                            Verification = new()
                            {
                                CardVerificationCode = new(Transactions::Result.Match),
                                CardholderAddress = new()
                                {
                                    ActualLine1 = "33 Liberty Street",
                                    ActualPostalCode = "94131",
                                    ProvidedLine1 = "33 Liberty Street",
                                    ProvidedPostalCode = "94132",
                                    Result =
                                        Transactions::CardholderAddressResult.PostalCodeNoMatchAddressMatch,
                                },
                                CardholderName = new()
                                {
                                    ProvidedFirstName = "provided_first_name",
                                    ProvidedLastName = "provided_last_name",
                                    ProvidedMiddleName = "provided_middle_name",
                                },
                            },
                        },
                        CardPushTransferAcceptance = new()
                        {
                            SettlementAmount = 100,
                            TransferID = "outbound_card_push_transfer_e0z9rdpamraczh4tvwye",
                        },
                        CardRefund = new()
                        {
                            ID = "card_refund_imgc2xwplh6t4r3gn16e",
                            Amount = 100,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardRefundCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::InterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges = Transactions::ExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator = Transactions::NoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges = Transactions::LodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator = Transactions::LodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::PurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category = Transactions::ServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::TravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::RestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::TicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode = Transactions::StopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardRefundSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardRefundSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardRefundType.CardRefund,
                        },
                        CardRevenuePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::CardRevenuePaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                            TransactedOnAccountID = "account_in71c4amph0vgo2qllky",
                        },
                        CardSettlement = new()
                        {
                            ID = "card_settlement_khv5kfeu0vndj291omg6",
                            Amount = 100,
                            CardAuthorization = null,
                            CardPaymentID = "card_payment_nd3k2kacrqjli8482ave",
                            Cashback = new()
                            {
                                Amount = "0.137465",
                                Currency = Transactions::CardSettlementCashbackCurrency.Usd,
                            },
                            Currency = Transactions::CardSettlementCurrency.Usd,
                            Interchange = new()
                            {
                                Amount = "0.137465",
                                Code = "271",
                                Currency = Transactions::CardSettlementInterchangeCurrency.Usd,
                            },
                            MerchantAcceptorID = "5665270011000168",
                            MerchantCategoryCode = "5734",
                            MerchantCity = "New York",
                            MerchantCountry = "US",
                            MerchantName = "AMAZON.COM",
                            MerchantPostalCode = "10045",
                            MerchantState = "NY",
                            Network = Transactions::CardSettlementNetwork.Visa,
                            NetworkIdentifiers = new()
                            {
                                AcquirerBusinessID = "69650702",
                                AcquirerReferenceNumber = "83163715445437604865089",
                                AuthorizationIdentificationResponse = "ABC123",
                                TransactionID = "627199945183184",
                            },
                            PendingTransactionID = null,
                            PresentmentAmount = 100,
                            PresentmentCurrency = "USD",
                            PurchaseDetails = new()
                            {
                                CarRental = new()
                                {
                                    CarClassCode = "car_class_code",
                                    CheckoutDate = "2019-12-27",
                                    DailyRentalRateAmount = 0,
                                    DailyRentalRateCurrency = "daily_rental_rate_currency",
                                    DaysRented = 0,
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalExtraCharges.NoExtraCharge,
                                    FuelChargesAmount = 0,
                                    FuelChargesCurrency = "fuel_charges_currency",
                                    InsuranceChargesAmount = 0,
                                    InsuranceChargesCurrency = "insurance_charges_currency",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsCarRentalNoShowIndicator.NotApplicable,
                                    OneWayDropOffChargesAmount = 0,
                                    OneWayDropOffChargesCurrency =
                                        "one_way_drop_off_charges_currency",
                                    RenterName = "renter_name",
                                    WeeklyRentalRateAmount = 0,
                                    WeeklyRentalRateCurrency = "weekly_rental_rate_currency",
                                },
                                CustomerReferenceIdentifier = "51201",
                                LocalTaxAmount = null,
                                LocalTaxCurrency = "usd",
                                Lodging = new()
                                {
                                    CheckInDate = "2023-07-20",
                                    DailyRoomRateAmount = 1000,
                                    DailyRoomRateCurrency = "usd",
                                    ExtraCharges =
                                        Transactions::CardSettlementPurchaseDetailsLodgingExtraCharges.Restaurant,
                                    FolioCashAdvancesAmount = 0,
                                    FolioCashAdvancesCurrency = "usd",
                                    FoodBeverageChargesAmount = 0,
                                    FoodBeverageChargesCurrency = "usd",
                                    NoShowIndicator =
                                        Transactions::CardSettlementPurchaseDetailsLodgingNoShowIndicator.NoShow,
                                    PrepaidExpensesAmount = 0,
                                    PrepaidExpensesCurrency = "usd",
                                    RoomNights = 1,
                                    TotalRoomTaxAmount = 100,
                                    TotalRoomTaxCurrency = "usd",
                                    TotalTaxAmount = 100,
                                    TotalTaxCurrency = "usd",
                                },
                                NationalTaxAmount = null,
                                NationalTaxCurrency = "usd",
                                PurchaseIdentifier = "10203",
                                PurchaseIdentifierFormat =
                                    Transactions::CardSettlementPurchaseDetailsPurchaseIdentifierFormat.OrderNumber,
                                Travel = new()
                                {
                                    Ancillary = new()
                                    {
                                        ConnectedTicketDocumentNumber =
                                            "connected_ticket_document_number",
                                        CreditReasonIndicator =
                                            Transactions::CardSettlementPurchaseDetailsTravelAncillaryCreditReasonIndicator.NoCredit,
                                        PassengerNameOrDescription =
                                            "passenger_name_or_description",
                                        Services =
                                        [
                                            new()
                                            {
                                                Category =
                                                    Transactions::CardSettlementPurchaseDetailsTravelAncillaryServiceCategory.None,
                                                SubCategory = "sub_category",
                                            },
                                        ],
                                        TicketDocumentNumber = "ticket_document_number",
                                    },
                                    ComputerizedReservationSystem =
                                        "computerized_reservation_system",
                                    CreditReasonIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelCreditReasonIndicator.NoCredit,
                                    DepartureDate = "2019-12-27",
                                    OriginationCityAirportCode = "origination_city_airport_code",
                                    PassengerName = "passenger_name",
                                    RestrictedTicketIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelRestrictedTicketIndicator.NoRestrictions,
                                    TicketChangeIndicator =
                                        Transactions::CardSettlementPurchaseDetailsTravelTicketChangeIndicator.None,
                                    TicketNumber = "ticket_number",
                                    TravelAgencyCode = "travel_agency_code",
                                    TravelAgencyName = "travel_agency_name",
                                    TripLegs =
                                    [
                                        new()
                                        {
                                            CarrierCode = "carrier_code",
                                            DestinationCityAirportCode =
                                                "destination_city_airport_code",
                                            FareBasisCode = "fare_basis_code",
                                            FlightNumber = "flight_number",
                                            ServiceClass = "service_class",
                                            StopOverCode =
                                                Transactions::CardSettlementPurchaseDetailsTravelTripLegStopOverCode.None,
                                        },
                                    ],
                                },
                            },
                            SchemeFees =
                            [
                                new()
                                {
                                    Amount = "0.137465",
                                    CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                                    Currency = Transactions::CardSettlementSchemeFeeCurrency.Usd,
                                    FeeType =
                                        Transactions::CardSettlementSchemeFeeFeeType.VisaCorporateAcceptanceFee,
                                    FixedComponent = null,
                                    VariableRate = "0.0002",
                                },
                            ],
                            Surcharge = new() { Amount = 0, PresentmentAmount = 0 },
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Type = Transactions::CardSettlementType.CardSettlement,
                        },
                        CashbackPayment = new()
                        {
                            AccruedOnCardID = "card_oubs0hwk5rn6knuecxg2",
                            Amount = 100,
                            Currency = Transactions::CashbackPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        CheckDepositAcceptance = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 1000,
                            AuxiliaryOnUs = "101",
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositAcceptanceCurrency.Usd,
                            RoutingNumber = "101050001",
                            SerialNumber = null,
                        },
                        CheckDepositReturn = new()
                        {
                            Amount = 100,
                            CheckDepositID = "check_deposit_f06n9gpg7sxn8t19lfc1",
                            Currency = Transactions::CheckDepositReturnCurrency.Usd,
                            ReturnReason = Transactions::ReturnReason.InsufficientFunds,
                            ReturnedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                        },
                        CheckTransferDeposit = new()
                        {
                            BackImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            BankOfFirstDepositRoutingNumber = null,
                            DepositedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            FrontImageFileID = "file_makxrc67oh9l6sg7w9yc",
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                            Type = Transactions::CheckTransferDepositType.CheckTransferDeposit,
                        },
                        FednowTransferAcknowledgement = new("fednow_transfer_4i0mptrdu1mueg1196bg"),
                        FeePayment = new()
                        {
                            Amount = 100,
                            Currency = Transactions::FeePaymentCurrency.Usd,
                            FeePeriodStart = "2023-05-01",
                            ProgramID = "program_i2v2os4mwza1oetokh9i",
                        },
                        InboundAchTransfer = new()
                        {
                            Addenda = new()
                            {
                                Category = Transactions::AddendaCategory.Freeform,
                                Freeform = new([new("payment_related_information")]),
                            },
                            Amount = 100,
                            OriginatorCompanyDescriptiveDate = null,
                            OriginatorCompanyDiscretionaryData = null,
                            OriginatorCompanyEntryDescription = "RESERVE",
                            OriginatorCompanyID = "0987654321",
                            OriginatorCompanyName = "BIG BANK",
                            ReceiverIDNumber = "12345678900",
                            ReceiverName = "IAN CREASE",
                            TraceNumber = "021000038461022",
                            TransferID = "inbound_ach_transfer_tdrwqr3fq9gnnq49odev",
                        },
                        InboundAchTransferReturnIntention = new(
                            "inbound_ach_transfer_tdrwqr3fq9gnnq49odev"
                        ),
                        InboundCheckAdjustment = new()
                        {
                            AdjustedTransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            Amount = 1750,
                            Reason = Transactions::Reason.LateReturn,
                        },
                        InboundCheckDepositReturnIntention = new()
                        {
                            InboundCheckDepositID = "inbound_check_deposit_zoshvqybq0cjjm31mra",
                            TransferID = "check_transfer_30b43acfu9vw8fyc4f5",
                        },
                        InboundFednowTransferConfirmation = new(
                            "inbound_fednow_transfer_ctxxbc07oh5ke5w1hk20"
                        ),
                        InboundRealTimePaymentsTransferConfirmation = new()
                        {
                            Amount = 100,
                            CreditorName = "Ian Crease",
                            Currency =
                                Transactions::InboundRealTimePaymentsTransferConfirmationCurrency.Usd,
                            DebtorAccountNumber = "987654321",
                            DebtorName = "National Phonograph Company",
                            DebtorRoutingNumber = "101050001",
                            TransactionIdentification = "20220501234567891T1BSLZO01745013025",
                            TransferID = "inbound_real_time_payments_transfer_63hlz498vcxg644hcrzr",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        InboundWireReversal = new()
                        {
                            Amount = 12345,
                            CreatedAt = DateTimeOffset.Parse("2020-01-31T23:59:59Z"),
                            DebtorRoutingNumber = "101050001",
                            Description = "Inbound wire reversal 2022021100335128",
                            InputCycleDate = "2022-02-11",
                            InputMessageAccountabilityData = "20220211B6B7HU2R011023",
                            InputSequenceNumber = "11023",
                            InputSource = "B6B7HU2R",
                            InstructionIdentification = null,
                            ReturnReasonAdditionalInformation = null,
                            ReturnReasonCode = null,
                            ReturnReasonCodeDescription = null,
                            TransactionID = "transaction_uyrp7fld2ium70oa7oi",
                            WireTransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                        InboundWireTransfer = new()
                        {
                            Amount = 100,
                            CreditorAddressLine1 = null,
                            CreditorAddressLine2 = null,
                            CreditorAddressLine3 = null,
                            CreditorName = null,
                            DebtorAddressLine1 = null,
                            DebtorAddressLine2 = null,
                            DebtorAddressLine3 = null,
                            DebtorName = null,
                            Description = "Inbound wire transfer",
                            EndToEndIdentification = null,
                            InputMessageAccountabilityData = null,
                            InstructingAgentRoutingNumber = null,
                            InstructionIdentification = null,
                            TransferID = "inbound_wire_transfer_f228m6bmhtcxjco9pwp0",
                            UniqueEndToEndTransactionReference = null,
                            UnstructuredRemittanceInformation = null,
                        },
                        InboundWireTransferReversal = new(
                            "inbound_wire_transfer_f228m6bmhtcxjco9pwp0"
                        ),
                        InterestPayment = new()
                        {
                            AccruedOnAccountID = "account_in71c4amph0vgo2qllky",
                            Amount = 100,
                            Currency = Transactions::InterestPaymentCurrency.Usd,
                            PeriodEnd = DateTimeOffset.Parse("2025-06-30T23:59:59+00:00"),
                            PeriodStart = DateTimeOffset.Parse("2025-06-01T00:00:00+00:00"),
                        },
                        InternalSource = new()
                        {
                            Amount = 100,
                            Currency = Transactions::InternalSourceCurrency.Usd,
                            Reason = Transactions::InternalSourceReason.SampleFunds,
                        },
                        Other = new(),
                        RealTimePaymentsTransferAcknowledgement = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            RoutingNumber = "101050001",
                            TransferID = "real_time_payments_transfer_iyuhl5kdn7ssmup83mvq",
                            UnstructuredRemittanceInformation = "Invoice 29582",
                        },
                        SampleFunds = new("dashboard"),
                        SwiftTransferIntention = new("swift_transfer_29h21xkng03788zwd3fh"),
                        SwiftTransferReturn = new("swift_transfer_29h21xkng03788zwd3fh"),
                        WireTransferIntention = new()
                        {
                            AccountNumber = "987654321",
                            Amount = 100,
                            MessageToRecipient = "HELLO",
                            RoutingNumber = "101050001",
                            TransferID = "wire_transfer_5akynk7dqsq25qwk9q2u",
                        },
                    },
                    Type = Transactions::TransactionType.Transaction,
                },
            ],
            NextCursor = "v57w5d",
        };

        Transactions::TransactionListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
