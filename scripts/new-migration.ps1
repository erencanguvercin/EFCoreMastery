<# .SYNOPSIS EFCoreMastery PostgreSQL için yeni migration oluþturur. #>

[CmdletBinding()]
param(
	
	[Parameter(Mandatory=$true)]
	[string]$MigrationName

)

$projectPath = "../EFCoreMastery.Persistence"
$startupPath = "../EFCoreMastery.WebApp"
$contextName = "AppDbContext"
$migrationsDir = "Migrations"

Write-Host "Creating PostgreSQL migration '$MigrationName'..." -ForegroundColor Green

$efCommand = @(
	"migrations","add", $MigrationName,
	"--project", $projectPath,
	"--startup-project", $startupPath,
	"--context", $contextName,
	"--output-dir", $migrationsDir
)

if ($PSCmdlet.MyInvocation.BoundParameters['Verbose']){
	$efCommand += "--verbose"
}

& dotnet ef @efCommand

if ($LASTEXITCODE -ne 0){
	Throw "Migration failed. ExitCode: ${LASTEXITCODE}"
}