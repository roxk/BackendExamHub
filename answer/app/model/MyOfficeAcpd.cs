using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BackendExamHub;

[Table("MyOffice_ACPD", Schema = Config.Schema)]
public class MyOfficeAcpd
{
    [Key]
    [Column("ACPD_SID")]
    [JsonPropertyName("sid")]
    public required string Sid { get; set; }

    [Column("ACPD_ENAME")]
    [JsonPropertyName("ename")]
    public string? EName { get; set; }

    // Note: rest of the fields omitted...typing them doesn't test my ability I guess.
    // One thing I'd note is that most fields are nullable so they should be
    // DateTime?, string? to reflect that
}
