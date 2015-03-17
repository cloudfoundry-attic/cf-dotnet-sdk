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

$coverageInfo = [Microsoft.VisualStudio.Coverage.Analysis.CoverageInfo]::CreateFromFile($inputFile)
$coverageData = [Microsoft.VisualStudio.Coverage.Analysis.CoverageDS]$coverageInfo.BuildDataSet()
$coverageData.WriteXml($outputFile)

[xml]$coverageXml = Get-Content $outputFile
[xml]$coverageXmlFinal = new-object System.Xml.XmlDocument
$coverageDSPrivNode = $coverageXml.CoverageDSPriv
$coverageDSNode = $coverageXmlFinal.CreateElement('CoverageDS')
$coverageXmlFinal.AppendChild($coverageDSNode) | Out-Null
$coverageDSNode.InnerXml = $coverageDSPrivNode.InnerXml
$coverageXmlFinal.Save($outputFile)
