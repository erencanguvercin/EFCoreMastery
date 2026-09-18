<# .SYNOPSIS Veritabanýnda uygulanan son migration'ý bir önceki seviyeye geri çeker (rollback) ve ardýndan hatalý migration dosyasýný Persistence projesinden tamamen siler. #>

[CmdletBinding()]
param()

$projectPath = "../EFCoreMastery.Persistence"
$startupPath = "../EFCoreMastery.WebApp"
$contextName = "AppDbContext"

Write-Host "1. Veritabaný geçmiþindeki migration'lar taranýyor..." -ForegroundColor Yellow

# EF Core CLI ile uygulanmýþ migration listesini alýyoruz.

$appliedMigrations = & dotnet ef migrations list --project $projectPath --startup-project $startupPath --context $contextName --no-build

if($LASTEXITCODE -ne 0){
	Throw "Migration listesi alýnamadý."
}

#Sadece uygulanmýþ olanlarý filtreleyebiliriz.
$migrationList = $appliedMigrations | Where-Object { $_ -notmatch "Build Failure" -and "Build Started" -and $_.Trim() -ne ""}

if($migrationList.Count -lt 1){
	Write-Host "Daha önce uygulanmýþ geri alýnacak bir migration bulunmadý!" -ForegroundColor Red
	return
}

# En son uygulanan migration ve bir önceki hedef migration tespit edilir.

$lastMigration = $migrationList[-1].Replace("(Pending)","").Trim()

if($migrationList.Count -eq 1){
	#Eðer sadece bir migration varsa (örn:InitialCreate), DB sýfýrlanýr ("0")
	$targetMigration = "0"
	Write-Host "Tek bir migration var ($lastMigration). Veritabaný baþlangýç konumuna ('0') çekilecek." -ForegroundColor Cyan
} else {
	$targetMigration = $migrationList[-2].Replace("(Pending)","").Trim()
	Write-Host "Son Uygulanan: '$lastMigration' -> Dönülecek Hedef: '$targetMigration'" -ForegroundColor Cyan
}

# ADIM 1: Veritabanýný Hedef Migration'a Çek (Rollback)

Write-Host "2. Veritabaný '$targetMigration' seviyesine geri çekiliyor..." -ForegroundColor Yellow
$updateCommand = @(

	"database","update", $targetMigration,
	"--project", $projectPath,
	"--startup-project", $startupPath,
	"--context", $contextName
)

& dotnet ef @updateCommand

if($LASTEXITCODE -ne 0){
	Throw "Veritabaný geri çekme (rollback) iþlemi baþarýsýz oldu!"
}

# ADIM 2: Hatalý Migration Dosyasýný Projeden Sil (Remove)
Write-Host "3. Veritabanýndan düþürülen '$lastMigration' migration dosyasý projeden siliniyor..." -ForegroundColor Yellow

$removeCommand = @(

	"migrations","remove",
	"--project",$projectPath,
	"--startup-project", $startupPath,
	"--context",$contextName
)

& dotnet ef @removeCommand

if($LASTEXITCODE -ne 0){
	Throw "Migration dosyasý projeden silinirken hata oluþtu!"
}

Write-Host "Ýþlem baþarýyla tamamlandý! Veritabaný ve kodlar bir önceki stabil migration haline getirildi." -ForegroundColor Green