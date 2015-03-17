param (
 [Parameter(Mandatory=$true)]
 [string]$inputFile,
 
 [Parameter(Mandatory=$true)]
 [string]$outputFile
)

$ErrorActionPreference = "Stop"
$currentDir = Split-Path -parent $PSCommandPath
$vsPath = $env:VS120COMNTOOLS
$analysisDll = '..\IDE\PrivateAssemblies\Microsoft.VisualStudio.Coverage.Analysis.dll'
$assemblyPath = [System.IO.Path]::GetFullPath((Join-Path $vsPath $analysisDll))


Add-Type -Path $assemblyPath

$dlls = (Get-ChildItem (Join-Path $currentDir 'lib\CloudFoundry*.dll') | ForEach-Object { $_.FullName })

$coverageInfo = [Microsoft.VisualStudio.Coverage.Analysis.CoverageInfo]::CreateFromFile($inputFile)
$coverageData = $coverageInfo.BuildDataSet()
$coverageData.WriteXml($outputFile)

