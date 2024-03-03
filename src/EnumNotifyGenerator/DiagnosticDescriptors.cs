using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

#pragma warning disable RS1032
#pragma warning disable RS2008

namespace EnumNotifyGenerator;
internal static class DiagnosticDescriptors
{
	public static readonly DiagnosticDescriptor MissingPartialDefinitionError = new DiagnosticDescriptor(
		id: "ENG0001",
		defaultSeverity: DiagnosticSeverity.Error,
		category: "Class",
		title: $"Missing partial definition",
		description: $"Partial is not defined in the class.",
		messageFormat: $"Partial is not defined in the class. {{0}}",
		isEnabledByDefault: true,
		helpLinkUri: "");

	public static readonly DiagnosticDescriptor InvalidEnumTypeClassError = new DiagnosticDescriptor(
		id: "ENG0002",
		defaultSeverity: DiagnosticSeverity.Error,
		category: "Class",
		title: $"Invalid enum type",
		description: $"Type is not an Enum.",
		messageFormat: $"Type is not an Enum. {{0}}",
		isEnabledByDefault: true,
		helpLinkUri: "");


	public static readonly DiagnosticDescriptor InvalidEnumTypeFieldError = new DiagnosticDescriptor(
		id: "ENG0003",
		defaultSeverity: DiagnosticSeverity.Error,
		category: "Field",
		title: $"Invalid enum type",
		description: $"Type is not an Enum.",
		messageFormat: $"Type is not an Enum. {{0}}",
		isEnabledByDefault: true,
		helpLinkUri: "");

	public static readonly DiagnosticDescriptor DifferentTypeWarning = new DiagnosticDescriptor(
		id: "ENG0004",
		defaultSeverity: DiagnosticSeverity.Warning,
		category: "Field",
		title: $"Different field type and attribute type",
		description: $"Do not match field type.",
		messageFormat: $"Do not match field type. {{0}}",
		isEnabledByDefault: true,
		helpLinkUri: "");

	public static readonly DiagnosticDescriptor SameEnumValueError = new DiagnosticDescriptor(
		id: "ENG0005",
		defaultSeverity: DiagnosticSeverity.Error,
		category: "Field",
		title: $"Same enum value",
		description: $"Same value already exists.",
		messageFormat: $"Same value already exists. {{0}}",
		isEnabledByDefault: true,
		helpLinkUri: "");
}