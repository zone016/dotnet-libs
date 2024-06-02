// Copyright (c) Zone016 Hackerspace. All Rights Reserved. Licensed under the MIT license.

using System.Text;
using System.Text.Encodings.Web;

namespace Zone016.Paw.Models.Contexts;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(Settings))]
[JsonSerializable(typeof(SettingsAction))]
internal partial class SettingsContext : JsonSerializerContext;
