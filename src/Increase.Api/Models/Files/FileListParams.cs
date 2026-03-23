using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Files;

/// <summary>
/// List Files
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileListParams : ParamsBase
{
    public CreatedAt? CreatedAt
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>("created_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Return the page of entries after this one.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    /// <summary>
    /// Filter records to the one with the specified `idempotency_key` you chose for
    /// that object. This value is unique across Increase and is used to ensure that
    /// a request is only processed once. Learn more about [idempotency](https://increase.com/documentation/idempotency-keys).
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("idempotency_key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("idempotency_key", value);
        }
    }

    /// <summary>
    /// Limit the size of the list that is returned. The default (and maximum) is
    /// 100 objects.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    public FileListParamsPurpose? Purpose
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<FileListParamsPurpose>("purpose");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("purpose", value);
        }
    }

    public FileListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListParams(FileListParams fileListParams)
        : base(fileListParams) { }
#pragma warning restore CS8618

    public FileListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FileListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/files")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// Return results after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? After
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// Return results before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? Before
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
        }
    }

    /// <summary>
    /// Return results on or after this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrAfter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_after");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_after", value);
        }
    }

    /// <summary>
    /// Return results on or before this [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) timestamp.
    /// </summary>
    public System::DateTimeOffset? OnOrBefore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("on_or_before");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("on_or_before", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.After;
        _ = this.Before;
        _ = this.OnOrAfter;
        _ = this.OnOrBefore;
    }

    public CreatedAt() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt(CreatedAt createdAt)
        : base(createdAt) { }
#pragma warning restore CS8618

    public CreatedAt(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CreatedAt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FileListParamsPurpose, FileListParamsPurposeFromRaw>))]
public sealed record class FileListParamsPurpose : JsonModel
{
    /// <summary>
    /// Filter Files for those with the specified purpose or purposes. For GET requests,
    /// this should be encoded as a comma-delimited string, such as `?in=one,two,three`.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, In>>? In
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, In>>>("in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, In>>?>(
                "in",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.In ?? [])
        {
            item.Validate();
        }
    }

    public FileListParamsPurpose() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListParamsPurpose(FileListParamsPurpose fileListParamsPurpose)
        : base(fileListParamsPurpose) { }
#pragma warning restore CS8618

    public FileListParamsPurpose(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListParamsPurpose(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListParamsPurposeFromRaw.FromRawUnchecked"/>
    public static FileListParamsPurpose FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileListParamsPurposeFromRaw : IFromRawJson<FileListParamsPurpose>
{
    /// <inheritdoc/>
    public FileListParamsPurpose FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileListParamsPurpose.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InConverter))]
public enum In
{
    /// <summary>
    /// A file to be attached to a Card Dispute.
    /// </summary>
    CardDisputeAttachment,

    /// <summary>
    /// An image of the front of a check, used for check deposits.
    /// </summary>
    CheckImageFront,

    /// <summary>
    /// An image of the back of a check, used for check deposits.
    /// </summary>
    CheckImageBack,

    /// <summary>
    /// An image of the front of a deposited check after processing by Increase and
    /// submission to the Federal Reserve.
    /// </summary>
    ProcessedCheckImageFront,

    /// <summary>
    /// An image of the back of a deposited check after processing by Increase and
    /// submission to the Federal Reserve.
    /// </summary>
    ProcessedCheckImageBack,

    /// <summary>
    /// An image of a check that was mailed to a recipient.
    /// </summary>
    MailedCheckImage,

    /// <summary>
    /// A document to be printed on an additional page and mailed with a check that
    /// you've requested Increase print. This must be a PDF whose pages are all US
    /// letter size and all have the same orientation.
    /// </summary>
    CheckAttachment,

    /// <summary>
    /// An image to be used as the check voucher image, which is printed in the middle
    /// of the trifold area of a check. This must be a 2550x1100 pixel PNG.
    /// </summary>
    CheckVoucherImage,

    /// <summary>
    /// A signature image to be printed on a check. This must be a 1320x120 pixel PNG.
    /// </summary>
    CheckSignature,

    /// <summary>
    /// A scanned mail item sent to Increase.
    /// </summary>
    InboundMailItem,

    /// <summary>
    /// IRS Form 1099-INT.
    /// </summary>
    Form1099Int,

    /// <summary>
    /// IRS Form 1099-MISC.
    /// </summary>
    Form1099Misc,

    /// <summary>
    /// IRS Form SS-4.
    /// </summary>
    FormSS4,

    /// <summary>
    /// An image of a government-issued ID.
    /// </summary>
    IdentityDocument,

    /// <summary>
    /// A statement generated by Increase.
    /// </summary>
    IncreaseStatement,

    /// <summary>
    /// A supplemental document for a Loan Application.
    /// </summary>
    LoanApplicationSupplementalDocument,

    /// <summary>
    /// A file purpose not covered by any of the other cases.
    /// </summary>
    Other,

    /// <summary>
    /// A legal document forming a trust.
    /// </summary>
    TrustFormationDocument,

    /// <summary>
    /// A card image to be rendered inside digital wallet apps. This must be a 1536x969
    /// pixel PNG.
    /// </summary>
    DigitalWalletArtwork,

    /// <summary>
    /// An icon for you app to be rendered inside digital wallet apps. This must
    /// be a 100x100 pixel PNG.
    /// </summary>
    DigitalWalletAppIcon,

    /// <summary>
    /// A card image to be printed on the front of a physical card. This must be
    /// a 2100x1344 pixel PNG with no other color but black.
    /// </summary>
    PhysicalCardFront,

    /// <summary>
    /// The image to be printed on the back of a physical card.
    /// </summary>
    PhysicalCardBack,

    /// <summary>
    /// An image representing the entirety of the carrier used for a physical card.
    /// This must be a 2550x3300 pixel PNG with no other color but black.
    /// </summary>
    PhysicalCardCarrier,

    /// <summary>
    /// A document requested by Increase.
    /// </summary>
    DocumentRequest,

    /// <summary>
    /// A supplemental document associated an an Entity.
    /// </summary>
    EntitySupplementalDocument,

    /// <summary>
    /// The results of an Export you requested via the dashboard or API.
    /// </summary>
    Export,

    /// <summary>
    /// A fee statement.
    /// </summary>
    FeeStatement,

    /// <summary>
    /// An attachment to an Unusual Activity Report.
    /// </summary>
    UnusualActivityReportAttachment,

    /// <summary>
    /// A document granting another entity access to the funds into your account.
    /// </summary>
    DepositAccountControlAgreement,

    /// <summary>
    /// A file containing additional evidence for a Proof of Authorization Request Submission.
    /// </summary>
    ProofOfAuthorizationRequestSubmission,

    /// <summary>
    /// An account verification letter.
    /// </summary>
    AccountVerificationLetter,

    /// <summary>
    /// Funding instructions.
    /// </summary>
    FundingInstructions,

    /// <summary>
    /// A Hold Harmless Letter.
    /// </summary>
    HoldHarmlessLetter,
}

sealed class InConverter : JsonConverter<In>
{
    public override In Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_dispute_attachment" => In.CardDisputeAttachment,
            "check_image_front" => In.CheckImageFront,
            "check_image_back" => In.CheckImageBack,
            "processed_check_image_front" => In.ProcessedCheckImageFront,
            "processed_check_image_back" => In.ProcessedCheckImageBack,
            "mailed_check_image" => In.MailedCheckImage,
            "check_attachment" => In.CheckAttachment,
            "check_voucher_image" => In.CheckVoucherImage,
            "check_signature" => In.CheckSignature,
            "inbound_mail_item" => In.InboundMailItem,
            "form_1099_int" => In.Form1099Int,
            "form_1099_misc" => In.Form1099Misc,
            "form_ss_4" => In.FormSS4,
            "identity_document" => In.IdentityDocument,
            "increase_statement" => In.IncreaseStatement,
            "loan_application_supplemental_document" => In.LoanApplicationSupplementalDocument,
            "other" => In.Other,
            "trust_formation_document" => In.TrustFormationDocument,
            "digital_wallet_artwork" => In.DigitalWalletArtwork,
            "digital_wallet_app_icon" => In.DigitalWalletAppIcon,
            "physical_card_front" => In.PhysicalCardFront,
            "physical_card_back" => In.PhysicalCardBack,
            "physical_card_carrier" => In.PhysicalCardCarrier,
            "document_request" => In.DocumentRequest,
            "entity_supplemental_document" => In.EntitySupplementalDocument,
            "export" => In.Export,
            "fee_statement" => In.FeeStatement,
            "unusual_activity_report_attachment" => In.UnusualActivityReportAttachment,
            "deposit_account_control_agreement" => In.DepositAccountControlAgreement,
            "proof_of_authorization_request_submission" => In.ProofOfAuthorizationRequestSubmission,
            "account_verification_letter" => In.AccountVerificationLetter,
            "funding_instructions" => In.FundingInstructions,
            "hold_harmless_letter" => In.HoldHarmlessLetter,
            _ => (In)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, In value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                In.CardDisputeAttachment => "card_dispute_attachment",
                In.CheckImageFront => "check_image_front",
                In.CheckImageBack => "check_image_back",
                In.ProcessedCheckImageFront => "processed_check_image_front",
                In.ProcessedCheckImageBack => "processed_check_image_back",
                In.MailedCheckImage => "mailed_check_image",
                In.CheckAttachment => "check_attachment",
                In.CheckVoucherImage => "check_voucher_image",
                In.CheckSignature => "check_signature",
                In.InboundMailItem => "inbound_mail_item",
                In.Form1099Int => "form_1099_int",
                In.Form1099Misc => "form_1099_misc",
                In.FormSS4 => "form_ss_4",
                In.IdentityDocument => "identity_document",
                In.IncreaseStatement => "increase_statement",
                In.LoanApplicationSupplementalDocument => "loan_application_supplemental_document",
                In.Other => "other",
                In.TrustFormationDocument => "trust_formation_document",
                In.DigitalWalletArtwork => "digital_wallet_artwork",
                In.DigitalWalletAppIcon => "digital_wallet_app_icon",
                In.PhysicalCardFront => "physical_card_front",
                In.PhysicalCardBack => "physical_card_back",
                In.PhysicalCardCarrier => "physical_card_carrier",
                In.DocumentRequest => "document_request",
                In.EntitySupplementalDocument => "entity_supplemental_document",
                In.Export => "export",
                In.FeeStatement => "fee_statement",
                In.UnusualActivityReportAttachment => "unusual_activity_report_attachment",
                In.DepositAccountControlAgreement => "deposit_account_control_agreement",
                In.ProofOfAuthorizationRequestSubmission =>
                    "proof_of_authorization_request_submission",
                In.AccountVerificationLetter => "account_verification_letter",
                In.FundingInstructions => "funding_instructions",
                In.HoldHarmlessLetter => "hold_harmless_letter",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
