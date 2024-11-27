param(
    [string]$header = "Running PowerShell Sample"
)

$buildConfiguration = "Release"
$runtime = "osx-arm64"
$outputDirectory = "${PSScriptRoot}/bin/${buildConfiguration}/net8.0/${runtime}/publish"
$dllPath = "${outputDirectory}/PowerShellSample.dll"
$moduleManifestPath = "${outputDirectory}/PowerShellSample.psd1"

Write-Host "Cleaning Project" -ForegroundColor Cyan
dotnet clean --configuration $buildConfiguration --runtime $runtime

Write-Host "Restoring Dependencies" -ForegroundColor Cyan
dotnet restore

Write-Host "Building Project" -ForegroundColor Cyan
dotnet publish --configuration $buildConfiguration --runtime $runtime --self-contained false

try {
    Import-Module -Name $moduleManifestPath -Verbose -Force

    [AppDomain]::CurrentDomain.GetAssemblies() | Where-Object { $_.FullName -match 'System.Text.Json' }
    Write-Report -h "This is a test" -Verbose
}
catch {
    Write-Error "Error. Exception: $_"
}
finally {
    Write-Host "Removing Module" -ForegroundColor Cyan
    Remove-Module -Name $moduleManifestPath -ErrorAction SilentlyContinue

    Write-Host "Releasing DLL" -ForegroundColor Cyan
    if (Test-Path $dllPath) {
        Remove-Item -Path $dllPath -Force
        Write-Host "DLL Released" -ForegroundColor Green
    }
    else {
        Write-Host "DLL not found" -ForegroundColor Yellow
    }
}

write-host "Script Complete" -ForegroundColor Green
