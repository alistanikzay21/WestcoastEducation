using System;
using System.Text.Json.Serialization;

namespace Desktop.Models;

public class Course
{
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("courseNumber")]
    public string CourseNumber { get; set; } = "";

    [JsonPropertyName("title")]
    public string Title { get; set; } = "";

    [JsonPropertyName("length")]
    public string Length { get; set; } = "";

    [JsonPropertyName("lengthUnit")]
    public string LengthUnit { get; set; } = "";

    [JsonPropertyName("courseType")]
    public string CourseType { get; set; } = "";

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }
}
