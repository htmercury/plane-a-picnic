Import-Module "sqlps" -DisableNameChecking

$content = Get-Content './appsettings.json' -Raw
$json = $content | Convertfrom-Json
$user = $json.User
$password = $json.Password
$server = $json.Server

$query = "DROP TABLE runways;
DROP TABLE airports;
DROP TABLE regions;
DROP TABLE countries;
DROP TABLE __efmigrationshistory;"

$params = @{
    'Database' = 'runwayDb'
    'ServerInstance' = $server
    'Username' = $user
    'Password' = $password
    'Query' = $query
}
Invoke-Sqlcmd @params

Invoke-Expression "dotnet ef database update"

Invoke-Expression -Command ./importData.ps1