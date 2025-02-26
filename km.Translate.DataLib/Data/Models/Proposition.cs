﻿#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using km.Library.Repositories;
using Microsoft.EntityFrameworkCore;

// ReSharper disable PropertyCanBeMadeInitOnly.Global

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace km.Translate.DataLib.Data.Models;

[SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
[Index(nameof(TranslationHash), nameof(SentenceVoId), nameof(TranslationLangId), IsUnique = true)]
public sealed class Proposition : BaseEntity
{
  [JsonIgnore]
  [Required]
  public int SentenceVoId { get; set; }

  [JsonIgnore]
  [Required]
  public int TranslationLangId { get; set; }

  [JsonIgnore]
  public int? ApprovedById { get; set; }


  [Required]
  public string TranslatedText { get; set; } = string.Empty;

  [Required]
  public string TranslationHash { get; set; } = string.Empty;

  public DateTime? AcceptationDate { get; set; } = null;

  [Required]
  public DateTime TranslationDate { get; set; }

  public string TranslatedBy { get; set; } = "Anonyme";

  [ForeignKey("TranslationLangId")]
  public Language TranslationLang { get; set; }

  [ForeignKey("ApprovedById")]
  public User ApprovedBy { get; set; }

  public long Votes { get; set; } = 0;
}
