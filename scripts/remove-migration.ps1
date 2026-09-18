<# .SYNOPSIS Henüz Db'ye uygulanmamýþ son migration'ý projeden kaldýrýr. #>

[CmdletBinding()]

param()

$projectPath = "../EFCoreMastery.Persistence"
$startupPath = "../EFCoreMastery.WebApp"
$contextName = "AppDbContext"

Write-Host "Removing unapplied PostgreSQL migration..." -ForegroundColor Red

$efCommand = @(

	"migrations","remove",
	"--project", $projectPath,
	"--startup-project", $startupPath,
	"--context", $contextName

)

& dotnet ef @efCommand

if($LASTEXITCODE -ne 0){
	Throw "Remove migration failed. ExitCode: ${LASTEXITCODE}"
}
else{
	Write-Host "Unapplied PostgreSQL migration was succesfully removed..." -ForegroundColor Green
}