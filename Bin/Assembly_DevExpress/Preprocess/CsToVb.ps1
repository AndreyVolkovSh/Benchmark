$projectPath=$args[0]
$newProjectPath=$projectPath -replace  ".csproj", "VB.csproj"
$content=(Get-Content $projectPath) -join "`n"

$content = $content -replace "<AssemblyName>DevExpress.Xpf.Core.Design.Wizards.Tests</AssemblyName>", "<AssemblyName>DevExpress.Xpf.Core.Design.Wizards.TestsVB</AssemblyName>"
$content = $content -replace "MvvmWizardsGeneratedFiles", "MvvmWizardsGeneratedFilesVB"
$content = $content -replace "<SccProjectName>SAK</SccProjectName>", ""
$content = $content -replace "<SccLocalPath>SAK</SccLocalPath>",""
$content = $content -replace "<SccAuxPath>SAK</SccAuxPath>",""
$content = $content -replace "<SccProvider>SAK</SccProvider>",""
$content =[string]$content.Replace('"powershell.exe" -ExecutionPolicy "Unrestricted" -file "$(TargetDir)Preprocess\CsToVb.ps1" "$(ProjectPath)"', "")
Set-Content $newProjectPath $content