Restart-Service -Force MSSQLSERVER

$dbName = "tailwind"

[reflection.assembly]::LoadWithPartialName("Microsoft.SqlServer.Smo")
$server = new-object ("Microsoft.SqlServer.Management.Smo.Server")
$db = New-Object -TypeName Microsoft.SqlServer.Management.Smo.Database -argumentlist $server, $dbName
$db.Create()