namespace Zone016.Project.Tests;

[TestClass]
public class UnitTestOfProjectExplorer
{
    private const string ProjectPath = "../../../Zone016.Project.Tests.csproj";
    
    [TestMethod]
    public void TestGetDotNetInstallations()
    {
        var installations = ProjectExplorer.GetDotNetInstallations().ToArray();
        Assert.IsTrue(installations.Length >= 2);
        
        var runtimeInstallations = installations
            .Count(installation => installation.Kind == DotNetInstallationKind.Runtime);
        Assert.IsTrue(runtimeInstallations >= 1);
        
        var sdkInstallations = installations
            .Count(installation => installation.Kind == DotNetInstallationKind.Sdk);
        Assert.IsTrue(sdkInstallations >= 1);
    }
    
    [TestMethod]
    public void TestOpen()
    {
        var explorer = ProjectExplorer.Open(ProjectPath);
        Assert.IsNotNull(explorer);
    }
}
