using MySql.Data.MySqlClient;

namespace Server;

public record Ad 
{
    public int? Id { get; init; }
    public string? Headline { get; init; }
    public string? County { get; init; }
    public string? Dwelling { get; init; }
    public string? DwellingOther { get; init; }
    public string? Occupation { get; init; }
    public string? RelStatus { get; init; }
    public string? PartnerInfo { get; init; }
    public int? ChildrenNum { get; init; }
    public string? ChildrenHome { get; init; }
    public string? Pets { get; init; }
    public string? Dog { get; init; }
    public string? Cat { get; init; }
    public string? Bird { get; init; }
    public string? Horse { get; init; }
    public string? Other { get; init; }
    public string? City { get; init; }
    public string? CityAlternative { get; init; }
    public string? Forest { get; init; }
    public string? Sea { get; init; }
    public string? Culture { get; init; }
    public string? Shopping { get; init; }
    public bool? Car { get; init; }
    public string? CarInfo { get; init; }
    public string? Hobbies { get; init; }
    public string? Presentation { get; init; }
    public int? Age { get; init; }
    public string? Gender { get; init; }
    public bool? AdActive { get; init; }
    public DateTime? EndDate { get; init; }
    public int? UserId { get; init; }
    public int? EndTimestamp { get; init; }
    public string? Children { get; init; }
}