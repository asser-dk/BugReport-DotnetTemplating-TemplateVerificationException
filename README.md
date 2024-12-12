# Bug Report Reproduction Project

For: [dotnet/templating](https://github.com/dotnet/templating)

Bug Report repo for dotnet/templating showcasing that the TemplateVerificationException reports inconsistent error codes

## Bug/issue description
When using the `Microsoft.TemplateEngine.Authoring.TemplateVerifier` NuGet package to test a template the
`TemplateVerificationException` will report different error codes for the `TemplateVerificationErrorCode` property 
compared to the error codes mentioned in both the `Message` and console output.

The [`TemplateVerificationErrorCodes` enum summary](https://github.com/dotnet/templating/blob/main/tools/Microsoft.TemplateEngine.Authoring.TemplateVerifier/TemplateVerificationErrorCode.cs#L7-L10) mentions it should correspond to the [Error codes](https://github.com/dotnet/templating/blob/main/docs/Exit-Codes.md#106) from the `dotnet/templating` projects docs.

This repo contains 2 tests that demonstrate the issue/bug:
[![Run tests](https://github.com/asser-dk/BugReport-DotnetTemplating-TemplateVerificationException/actions/workflows/workflow.yml/badge.svg)](https://github.com/asser-dk/BugReport-DotnetTemplating-TemplateVerificationException/actions/workflows/workflow.yml)