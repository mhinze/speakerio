function global:Create-AppSettings()
{
	$template = Join-Path $solutionScriptsContainer "appSettings.config.template"
	$unresolvedTarget = Join-Path $solutionScriptsContainer "..\SpeakerIO.Web\"
	$target = Resolve-Path $unresolvedTarget
	$target = Join-Path $target "appSettings.config"
	Copy-Item $template $target
	$DTE.ItemOperations.OpenFile($target) 
}