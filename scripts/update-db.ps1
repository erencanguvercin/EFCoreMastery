<# .SYNOPSIS PostgreSQL veritabanýný günceller ve hedef migration'a çeker. #>

[CmdletBinding()]
param(

	[string]$TargetMigration

)

$projectPath = "../EFCoreMastery.Persistence"
$startupPath = "../EFCoreMastery.WebApp"
$contextName = "AppDbContext"

$efCommand = @("database","update")

if($TargetMigration){
	$efCommand += $TargetMigration
	Write-Host "Updating database to specified migration '$TargetMigration'..." -ForegroundColor Yellow
} else {
	Write-Host "Updating PostgreSQL database to latest migration..." -ForegroundColor Green
}

$efCommand += @(
	"--project",$projectPath,
	"--startup-project",$startupPath,
	"--context",$contextName
)

if($PSCmdlet.MyInvocation.BoundParameters['Verbose']){
	$efCommand += "--verbose"
}

& dotnet ef @efCommand

if($LASTEXITCODE -ne 0){
	Throw "Database update failed. ExitCode: ${LASTEXITCODE}"
}