using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Increase.Api.Core;
using Increase.Api.Exceptions;
using System = System;

namespace Increase.Api.Models.Files;

/// <summary>
/// To upload a file to Increase, you'll need to send a request of Content-Type `multipart/form-data`.
/// The request should contain the file you would like to upload, as well as the
/// parameters for creating a file.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FileCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The file contents. This should follow the specifications of [RFC 7578](https://datatracker.ietf.org/doc/html/rfc7578)
    /// which defines file transfers for the multipart/form-data protocol.
    /// </summary>
    public required BinaryContent File
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BinaryContent>("file");
        }
        init { this._rawBodyData.Set("file", value); }
    }

    /// <summary>
    /// What the File will be used for in Increase's systems.
    /// </summary>
    public required ApiEnum<string, Purpose> Purpose
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Purpose>>("purpose");
        }
        init { this._rawBodyData.Set("purpose", value); }
    }

    /// <summary>
    /// The description you choose to give the File.
    /// </summary>
    public string? Description
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    public FileCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileCreateParams(FileCreateParams fileCreateParams)
        : base(fileCreateParams)
    {
        this._rawBodyData = new(fileCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public FileCreateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileCreateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FileCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, MultipartJsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(FileCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/files")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return MultipartJsonSerializer.Serialize(RawBodyData);
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

/// <summary>
/// What the File will be used for in Increase's systems.
/// </summary>
[JsonConverter(typeof(PurposeConverter))]
public enum Purpose
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
    /// IRS Form SS-4.
    /// </summary>
    FormSS4,

    /// <summary>
    /// An image of a government-issued ID.
    /// </summary>
    IdentityDocument,

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
    /// An attachment to an Unusual Activity Report.
    /// </summary>
    UnusualActivityReportAttachment,

    /// <summary>
    /// A file containing additional evidence for a Proof of Authorization Request Submission.
    /// </summary>
    ProofOfAuthorizationRequestSubmission,
}

sealed class PurposeConverter : JsonConverter<Purpose>
{
    public override Purpose Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "card_dispute_attachment" => Purpose.CardDisputeAttachment,
            "check_image_front" => Purpose.CheckImageFront,
            "check_image_back" => Purpose.CheckImageBack,
            "mailed_check_image" => Purpose.MailedCheckImage,
            "check_attachment" => Purpose.CheckAttachment,
            "check_voucher_image" => Purpose.CheckVoucherImage,
            "check_signature" => Purpose.CheckSignature,
            "form_ss_4" => Purpose.FormSS4,
            "identity_document" => Purpose.IdentityDocument,
            "loan_application_supplemental_document" => Purpose.LoanApplicationSupplementalDocument,
            "other" => Purpose.Other,
            "trust_formation_document" => Purpose.TrustFormationDocument,
            "digital_wallet_artwork" => Purpose.DigitalWalletArtwork,
            "digital_wallet_app_icon" => Purpose.DigitalWalletAppIcon,
            "physical_card_front" => Purpose.PhysicalCardFront,
            "physical_card_carrier" => Purpose.PhysicalCardCarrier,
            "document_request" => Purpose.DocumentRequest,
            "entity_supplemental_document" => Purpose.EntitySupplementalDocument,
            "unusual_activity_report_attachment" => Purpose.UnusualActivityReportAttachment,
            "proof_of_authorization_request_submission" =>
                Purpose.ProofOfAuthorizationRequestSubmission,
            _ => (Purpose)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Purpose value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Purpose.CardDisputeAttachment => "card_dispute_attachment",
                Purpose.CheckImageFront => "check_image_front",
                Purpose.CheckImageBack => "check_image_back",
                Purpose.MailedCheckImage => "mailed_check_image",
                Purpose.CheckAttachment => "check_attachment",
                Purpose.CheckVoucherImage => "check_voucher_image",
                Purpose.CheckSignature => "check_signature",
                Purpose.FormSS4 => "form_ss_4",
                Purpose.IdentityDocument => "identity_document",
                Purpose.LoanApplicationSupplementalDocument =>
                    "loan_application_supplemental_document",
                Purpose.Other => "other",
                Purpose.TrustFormationDocument => "trust_formation_document",
                Purpose.DigitalWalletArtwork => "digital_wallet_artwork",
                Purpose.DigitalWalletAppIcon => "digital_wallet_app_icon",
                Purpose.PhysicalCardFront => "physical_card_front",
                Purpose.PhysicalCardCarrier => "physical_card_carrier",
                Purpose.DocumentRequest => "document_request",
                Purpose.EntitySupplementalDocument => "entity_supplemental_document",
                Purpose.UnusualActivityReportAttachment => "unusual_activity_report_attachment",
                Purpose.ProofOfAuthorizationRequestSubmission =>
                    "proof_of_authorization_request_submission",
                _ => throw new IncreaseInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
