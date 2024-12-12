namespace TestProject;

using FluentAssertions;
using Microsoft.TemplateEngine.Authoring.TemplateVerifier;
using Xunit.Abstractions;
using Xunit.Extensions.Logging;

public class TemplateVerificationExceptionTests(ITestOutputHelper outputHelper)
{
    private readonly VerificationEngine engine = new(new XunitLogger(outputHelper, nameof(TemplateVerificationExceptionTests), (_, _) => true));

    [Fact]
    public async Task Should_Return_Error_Code_106_When_Template_Path_Is_Invalid()
    {
        var options = new TemplateVerifierOptions("my-template")
        {
            TemplatePath = CreateBadName(),
            DisableDiffTool = true,
        };

        var act = () => engine.Execute(options);

        var exception = await act.Should().ThrowAsync<TemplateVerificationException>();

        exception.Which.TemplateVerificationErrorCode.Should()
            .Be(TemplateVerificationErrorCode.InstallFailed, "because the path is invalid and error code reported in the exception message and ILogger are both '106'");
    }

    [Fact]
    public async Task Should_Return_Error_Code_103_When_Template_Name_Is_Invalid()
    {
        var options = new TemplateVerifierOptions(CreateBadName())
        {
            TemplatePath = "my-template",
            DisableDiffTool = true,
        };

        var act = () => engine.Execute(options);

        var exception = await act.Should().ThrowAsync<TemplateVerificationException>();

        exception
            .Which.TemplateVerificationErrorCode.Should()
            .Be(TemplateVerificationErrorCode.TemplateDoesNotExist, "because the template does not exist and the error code reported in the exception message and ILogger are both '103'");
    }

    private static string CreateBadName()
        => Guid.NewGuid().ToString();
}
