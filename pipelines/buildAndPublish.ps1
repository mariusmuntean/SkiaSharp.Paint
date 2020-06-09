param (
    [string]$apiKey, 
    [string]$buildId
)
$ErrorActionPreference = "Stop"

$projectPath = [System.IO.Path]::GetFullPath('../src/SkiaSharp.Paint/SkiaSharp.Paint.csproj')

$xml = [Xml] (Get-Content $projectPath)
$title = [String]::Join("", $xml.Project.PropertyGroup.Title).Trim()
$version = [Version]::Parse($xml.Project.PropertyGroup.VersionPrefix)

Write-Host "Packaging $title in version $version"
$packageOutputDir = [System.IO.Path]::GetFullPath('Artifacts');
[System.IO.Directory]::CreateDirectory($packageOutputDir);

if ([string]::IsNullOrWhiteSpace($buildId)) {
    Invoke-Expression "dotnet pack --configuration Release --output $packageOutputDir $projectPath"
}
else {
    Invoke-Expression "dotnet pack --configuration Release --version-suffix $("build."+$buildId) --output $packageOutputDir $projectPath"
}

if ([string]::IsNullOrWhiteSpace($apiKey)) {
    Write-Error("The NuGet API key is null or empty. Package won't be published!");
}

$package = Get-ChildItem -path Artifacts -filter *.nupkg -file -erroraction silentlycontinue | Select-Object -Last 1
if (!$package) {
    Write-Error("Didn't find any *.nupkg file in $packageOutputDir")
}

Write-Host "Publishing " $package
Invoke-Expression "dotnet nuget push $($package.FullName) --api-key $apiKey --source https://api.nuget.org/v3/index.json"

Write-Host "Done"