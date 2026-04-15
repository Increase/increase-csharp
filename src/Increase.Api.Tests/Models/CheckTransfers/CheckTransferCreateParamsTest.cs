using System;
using System.Collections.Generic;
using System.Text.Json;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using Increase.Api.Models.CheckTransfers;

namespace Increase.Api.Tests.Models.CheckTransfers;

public class CheckTransferCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            BalanceCheck = BalanceCheck.Full,
            CheckNumber = "x",
            PhysicalCheck = new()
            {
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    PostalCode = "10045",
                    State = "NY",
                    Line2 = "x",
                    Name = "Ian Crease",
                    Phone = "+16505046304",
                },
                Memo = "Check payment",
                RecipientName = "Ian Crease",
                AttachmentFileID = "attachment_file_id",
                CheckVoucherImageFileID = "check_voucher_image_file_id",
                Note = "x",
                Payer = [new("x")],
                ReturnAddress = new()
                {
                    City = "x",
                    Line1 = "x",
                    Name = "x",
                    PostalCode = "x",
                    State = "x",
                    Line2 = "x",
                    Phone = "x",
                },
                ShippingMethod = ShippingMethod.UspsFirstClass,
                Signature = new() { ImageFileID = "image_file_id", Text = "Ian Crease" },
            },
            RequireApproval = true,
            ThirdParty = new() { RecipientName = "x" },
            ValidUntilDate = "2025-12-31",
        };

        string expectedAccountID = "account_in71c4amph0vgo2qllky";
        long expectedAmount = 1000;
        ApiEnum<string, FulfillmentMethod> expectedFulfillmentMethod =
            FulfillmentMethod.PhysicalCheck;
        string expectedSourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2";
        ApiEnum<string, BalanceCheck> expectedBalanceCheck = BalanceCheck.Full;
        string expectedCheckNumber = "x";
        PhysicalCheck expectedPhysicalCheck = new()
        {
            MailingAddress = new()
            {
                City = "New York",
                Line1 = "33 Liberty Street",
                PostalCode = "10045",
                State = "NY",
                Line2 = "x",
                Name = "Ian Crease",
                Phone = "+16505046304",
            },
            Memo = "Check payment",
            RecipientName = "Ian Crease",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "Ian Crease" },
        };
        bool expectedRequireApproval = true;
        ThirdParty expectedThirdParty = new() { RecipientName = "x" };
        string expectedValidUntilDate = "2025-12-31";

        Assert.Equal(expectedAccountID, parameters.AccountID);
        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedFulfillmentMethod, parameters.FulfillmentMethod);
        Assert.Equal(expectedSourceAccountNumberID, parameters.SourceAccountNumberID);
        Assert.Equal(expectedBalanceCheck, parameters.BalanceCheck);
        Assert.Equal(expectedCheckNumber, parameters.CheckNumber);
        Assert.Equal(expectedPhysicalCheck, parameters.PhysicalCheck);
        Assert.Equal(expectedRequireApproval, parameters.RequireApproval);
        Assert.Equal(expectedThirdParty, parameters.ThirdParty);
        Assert.Equal(expectedValidUntilDate, parameters.ValidUntilDate);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CheckTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        Assert.Null(parameters.BalanceCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("balance_check"));
        Assert.Null(parameters.CheckNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("check_number"));
        Assert.Null(parameters.PhysicalCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_check"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.ThirdParty);
        Assert.False(parameters.RawBodyData.ContainsKey("third_party"));
        Assert.Null(parameters.ValidUntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("valid_until_date"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CheckTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",

            // Null should be interpreted as omitted for these properties
            BalanceCheck = null,
            CheckNumber = null,
            PhysicalCheck = null,
            RequireApproval = null,
            ThirdParty = null,
            ValidUntilDate = null,
        };

        Assert.Null(parameters.BalanceCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("balance_check"));
        Assert.Null(parameters.CheckNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("check_number"));
        Assert.Null(parameters.PhysicalCheck);
        Assert.False(parameters.RawBodyData.ContainsKey("physical_check"));
        Assert.Null(parameters.RequireApproval);
        Assert.False(parameters.RawBodyData.ContainsKey("require_approval"));
        Assert.Null(parameters.ThirdParty);
        Assert.False(parameters.RawBodyData.ContainsKey("third_party"));
        Assert.Null(parameters.ValidUntilDate);
        Assert.False(parameters.RawBodyData.ContainsKey("valid_until_date"));
    }

    [Fact]
    public void Url_Works()
    {
        CheckTransferCreateParams parameters = new()
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.increase.com/check_transfers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CheckTransferCreateParams
        {
            AccountID = "account_in71c4amph0vgo2qllky",
            Amount = 1000,
            FulfillmentMethod = FulfillmentMethod.PhysicalCheck,
            SourceAccountNumberID = "account_number_v18nkfqm6afpsrvy82b2",
            BalanceCheck = BalanceCheck.Full,
            CheckNumber = "x",
            PhysicalCheck = new()
            {
                MailingAddress = new()
                {
                    City = "New York",
                    Line1 = "33 Liberty Street",
                    PostalCode = "10045",
                    State = "NY",
                    Line2 = "x",
                    Name = "Ian Crease",
                    Phone = "+16505046304",
                },
                Memo = "Check payment",
                RecipientName = "Ian Crease",
                AttachmentFileID = "attachment_file_id",
                CheckVoucherImageFileID = "check_voucher_image_file_id",
                Note = "x",
                Payer = [new("x")],
                ReturnAddress = new()
                {
                    City = "x",
                    Line1 = "x",
                    Name = "x",
                    PostalCode = "x",
                    State = "x",
                    Line2 = "x",
                    Phone = "x",
                },
                ShippingMethod = ShippingMethod.UspsFirstClass,
                Signature = new() { ImageFileID = "image_file_id", Text = "Ian Crease" },
            },
            RequireApproval = true,
            ThirdParty = new() { RecipientName = "x" },
            ValidUntilDate = "2025-12-31",
        };

        CheckTransferCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class FulfillmentMethodTest : TestBase
{
    [Theory]
    [InlineData(FulfillmentMethod.PhysicalCheck)]
    [InlineData(FulfillmentMethod.ThirdParty)]
    public void Validation_Works(FulfillmentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FulfillmentMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FulfillmentMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FulfillmentMethod.PhysicalCheck)]
    [InlineData(FulfillmentMethod.ThirdParty)]
    public void SerializationRoundtrip_Works(FulfillmentMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FulfillmentMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FulfillmentMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FulfillmentMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FulfillmentMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BalanceCheckTest : TestBase
{
    [Theory]
    [InlineData(BalanceCheck.Full)]
    [InlineData(BalanceCheck.None)]
    public void Validation_Works(BalanceCheck rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceCheck> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceCheck>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BalanceCheck.Full)]
    [InlineData(BalanceCheck.None)]
    public void SerializationRoundtrip_Works(BalanceCheck rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BalanceCheck> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceCheck>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BalanceCheck>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BalanceCheck>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PhysicalCheckTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "x" },
        };

        MailingAddress expectedMailingAddress = new()
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };
        string expectedMemo = "x";
        string expectedRecipientName = "x";
        string expectedAttachmentFileID = "attachment_file_id";
        string expectedCheckVoucherImageFileID = "check_voucher_image_file_id";
        string expectedNote = "x";
        List<Payer> expectedPayer = [new("x")];
        ReturnAddress expectedReturnAddress = new()
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };
        ApiEnum<string, ShippingMethod> expectedShippingMethod = ShippingMethod.UspsFirstClass;
        Signature expectedSignature = new() { ImageFileID = "image_file_id", Text = "x" };

        Assert.Equal(expectedMailingAddress, model.MailingAddress);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedRecipientName, model.RecipientName);
        Assert.Equal(expectedAttachmentFileID, model.AttachmentFileID);
        Assert.Equal(expectedCheckVoucherImageFileID, model.CheckVoucherImageFileID);
        Assert.Equal(expectedNote, model.Note);
        Assert.NotNull(model.Payer);
        Assert.Equal(expectedPayer.Count, model.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], model.Payer[i]);
        }
        Assert.Equal(expectedReturnAddress, model.ReturnAddress);
        Assert.Equal(expectedShippingMethod, model.ShippingMethod);
        Assert.Equal(expectedSignature, model.Signature);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "x" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCheck>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "x" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhysicalCheck>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MailingAddress expectedMailingAddress = new()
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };
        string expectedMemo = "x";
        string expectedRecipientName = "x";
        string expectedAttachmentFileID = "attachment_file_id";
        string expectedCheckVoucherImageFileID = "check_voucher_image_file_id";
        string expectedNote = "x";
        List<Payer> expectedPayer = [new("x")];
        ReturnAddress expectedReturnAddress = new()
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };
        ApiEnum<string, ShippingMethod> expectedShippingMethod = ShippingMethod.UspsFirstClass;
        Signature expectedSignature = new() { ImageFileID = "image_file_id", Text = "x" };

        Assert.Equal(expectedMailingAddress, deserialized.MailingAddress);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
        Assert.Equal(expectedAttachmentFileID, deserialized.AttachmentFileID);
        Assert.Equal(expectedCheckVoucherImageFileID, deserialized.CheckVoucherImageFileID);
        Assert.Equal(expectedNote, deserialized.Note);
        Assert.NotNull(deserialized.Payer);
        Assert.Equal(expectedPayer.Count, deserialized.Payer.Count);
        for (int i = 0; i < expectedPayer.Count; i++)
        {
            Assert.Equal(expectedPayer[i], deserialized.Payer[i]);
        }
        Assert.Equal(expectedReturnAddress, deserialized.ReturnAddress);
        Assert.Equal(expectedShippingMethod, deserialized.ShippingMethod);
        Assert.Equal(expectedSignature, deserialized.Signature);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "x" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
        };

        Assert.Null(model.AttachmentFileID);
        Assert.False(model.RawData.ContainsKey("attachment_file_id"));
        Assert.Null(model.CheckVoucherImageFileID);
        Assert.False(model.RawData.ContainsKey("check_voucher_image_file_id"));
        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.ReturnAddress);
        Assert.False(model.RawData.ContainsKey("return_address"));
        Assert.Null(model.ShippingMethod);
        Assert.False(model.RawData.ContainsKey("shipping_method"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",

            // Null should be interpreted as omitted for these properties
            AttachmentFileID = null,
            CheckVoucherImageFileID = null,
            Note = null,
            Payer = null,
            ReturnAddress = null,
            ShippingMethod = null,
            Signature = null,
        };

        Assert.Null(model.AttachmentFileID);
        Assert.False(model.RawData.ContainsKey("attachment_file_id"));
        Assert.Null(model.CheckVoucherImageFileID);
        Assert.False(model.RawData.ContainsKey("check_voucher_image_file_id"));
        Assert.Null(model.Note);
        Assert.False(model.RawData.ContainsKey("note"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.ReturnAddress);
        Assert.False(model.RawData.ContainsKey("return_address"));
        Assert.Null(model.ShippingMethod);
        Assert.False(model.RawData.ContainsKey("shipping_method"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",

            // Null should be interpreted as omitted for these properties
            AttachmentFileID = null,
            CheckVoucherImageFileID = null,
            Note = null,
            Payer = null,
            ReturnAddress = null,
            ShippingMethod = null,
            Signature = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhysicalCheck
        {
            MailingAddress = new()
            {
                City = "x",
                Line1 = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Name = "x",
                Phone = "x",
            },
            Memo = "x",
            RecipientName = "x",
            AttachmentFileID = "attachment_file_id",
            CheckVoucherImageFileID = "check_voucher_image_file_id",
            Note = "x",
            Payer = [new("x")],
            ReturnAddress = new()
            {
                City = "x",
                Line1 = "x",
                Name = "x",
                PostalCode = "x",
                State = "x",
                Line2 = "x",
                Phone = "x",
            },
            ShippingMethod = ShippingMethod.UspsFirstClass,
            Signature = new() { ImageFileID = "image_file_id", Text = "x" },
        };

        PhysicalCheck copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class MailingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";
        string expectedName = "x";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MailingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MailingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";
        string expectedName = "x";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Name = null,
            Phone = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Name = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MailingAddress
        {
            City = "x",
            Line1 = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Name = "x",
            Phone = "x",
        };

        MailingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Payer { Contents = "x" };

        string expectedContents = "x";

        Assert.Equal(expectedContents, model.Contents);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Payer { Contents = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Payer { Contents = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Payer>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedContents = "x";

        Assert.Equal(expectedContents, deserialized.Contents);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Payer { Contents = "x" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Payer { Contents = "x" };

        Payer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReturnAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedName = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPhone, model.Phone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReturnAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "x";
        string expectedLine1 = "x";
        string expectedName = "x";
        string expectedPostalCode = "x";
        string expectedState = "x";
        string expectedLine2 = "x";
        string expectedPhone = "x";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPhone, deserialized.Phone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.Phone);
        Assert.False(model.RawData.ContainsKey("phone"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",

            // Null should be interpreted as omitted for these properties
            Line2 = null,
            Phone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReturnAddress
        {
            City = "x",
            Line1 = "x",
            Name = "x",
            PostalCode = "x",
            State = "x",
            Line2 = "x",
            Phone = "x",
        };

        ReturnAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ShippingMethodTest : TestBase
{
    [Theory]
    [InlineData(ShippingMethod.UspsFirstClass)]
    [InlineData(ShippingMethod.FedexOvernight)]
    public void Validation_Works(ShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShippingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<IncreaseInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ShippingMethod.UspsFirstClass)]
    [InlineData(ShippingMethod.FedexOvernight)]
    public void SerializationRoundtrip_Works(ShippingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ShippingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ShippingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SignatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Signature { ImageFileID = "image_file_id", Text = "x" };

        string expectedImageFileID = "image_file_id";
        string expectedText = "x";

        Assert.Equal(expectedImageFileID, model.ImageFileID);
        Assert.Equal(expectedText, model.Text);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Signature { ImageFileID = "image_file_id", Text = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Signature>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Signature { ImageFileID = "image_file_id", Text = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Signature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedImageFileID = "image_file_id";
        string expectedText = "x";

        Assert.Equal(expectedImageFileID, deserialized.ImageFileID);
        Assert.Equal(expectedText, deserialized.Text);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Signature { ImageFileID = "image_file_id", Text = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Signature { };

        Assert.Null(model.ImageFileID);
        Assert.False(model.RawData.ContainsKey("image_file_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Signature { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Signature
        {
            // Null should be interpreted as omitted for these properties
            ImageFileID = null,
            Text = null,
        };

        Assert.Null(model.ImageFileID);
        Assert.False(model.RawData.ContainsKey("image_file_id"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Signature
        {
            // Null should be interpreted as omitted for these properties
            ImageFileID = null,
            Text = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Signature { ImageFileID = "image_file_id", Text = "x" };

        Signature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ThirdPartyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ThirdParty { RecipientName = "x" };

        string expectedRecipientName = "x";

        Assert.Equal(expectedRecipientName, model.RecipientName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ThirdParty { RecipientName = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThirdParty>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ThirdParty { RecipientName = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ThirdParty>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRecipientName = "x";

        Assert.Equal(expectedRecipientName, deserialized.RecipientName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ThirdParty { RecipientName = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ThirdParty { };

        Assert.Null(model.RecipientName);
        Assert.False(model.RawData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ThirdParty { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ThirdParty
        {
            // Null should be interpreted as omitted for these properties
            RecipientName = null,
        };

        Assert.Null(model.RecipientName);
        Assert.False(model.RawData.ContainsKey("recipient_name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ThirdParty
        {
            // Null should be interpreted as omitted for these properties
            RecipientName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ThirdParty { RecipientName = "x" };

        ThirdParty copied = new(model);

        Assert.Equal(model, copied);
    }
}
