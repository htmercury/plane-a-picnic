Write-Host "Formatting countries..."
## Countries
$reader = [System.IO.File]::OpenText('./Data/countries.csv')
$writer = New-Object System.IO.StreamWriter './Data/countries_out.csv'
$countries = @{}
$line = $reader.ReadLine() ## skip first line
for(;;) {
    $line = $reader.ReadLine()
    if ($null -eq $line) {
        break
    }

    $data = $line.Replace("`"","")
    $data = $data.Split(",")

    $countries.Add($data[1], $data[0])

    $writer.WriteLine('{0}|{1}|{2}|{3}|{4}|{5}', $data[0], $data[1], $data[2]
        , $data[3], $data[4], $data[5])
}
$reader.Close()
$writer.Close()

Write-Host "Formatting regions..."
## Regions
$reader = [System.IO.File]::OpenText('./Data/regions.csv')
$writer = New-Object System.IO.StreamWriter './Data/regions_out.csv'
$regions = @{}
$line = $reader.ReadLine() ## skip first line
for(;;) {
    $line = $reader.ReadLine()
    if ($null -eq $line) {
        break
    }
    $data = $line.Replace("`"","")
    $data = $data.Split(",")
    $data[4] = $data[4].Trim()

    $regions.Add($data[1], $data[0])

    $writer.WriteLine('{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}', $data[0], $data[1]
        , $data[2], $data[3], $data[4], $data[5], $countries[$data[5]], $data[6]
        , $data[7])
}
$reader.Close()
$writer.Close()

Write-Host "Formatting airports..."
## Airports
$reader = [System.IO.File]::OpenText('./Data/airports.csv')
$writer = New-Object System.IO.StreamWriter './Data/airports_out.csv'
$line = $reader.ReadLine() ## skip first line
for(;;) {
    $line = $reader.ReadLine()
    if ($null -eq $line) {
        break
    }
    #$data = $line.Replace("`"","")
    $data = $line -split ',(?=(?:[^"]|"[^"]*")*$)'
    $name = $data[3]
    if ($name.ToLower().Contains("duplicate") -or $name.Contains("+") -or $name.ToLower().Contains("`(old`)") -or $name.ToLower().Contains("delete"))
    {
        continue;
    }
    $data[1] = $data[1].Replace("`"","")
    $data[2] = $data[2].Replace("`"","")
    $data[3] = $data[3].Replace("`"","")
    for ($i = 7; $i -lt 18; $i++) {
        $data[$i] = $data[$i].Replace("`"","")
    }
    $data[16] = $data[16].Trim()
    $data[17] = $data[17].Trim()
    
    if ("no" -eq $data[11]) {
        $data[11] = 0
    }
    else {
        $data[11] = 1
    }

    $writer.WriteLine('{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|'`
        + '{14}|{15}|{16}|{17}|{18}', $data[0], $data[1], $data[2], $data[3], $data[4]
        , $data[5], $data[6], $data[7], $data[8], $data[9], $regions[$data[9]], $data[10]
        , $data[11], $data[12], $data[13], $data[14], $data[15], $data[16], $data[17])
}
$reader.Close()
$writer.Close()

Write-Host "Formatting runways..."
## Runways
$reader = [System.IO.File]::OpenText('./Data/runways.csv')
$writer = New-Object System.IO.StreamWriter './Data/runways_out.csv'
$line = $reader.ReadLine() ## skip first line
for(;;) {
    $line = $reader.ReadLine()
    if ($null -eq $line) {
        break
    }
    $data = $line -split ',(?=(?:[^"]|"[^"]*")*$)'
    $data[2] = $data[2].Replace("`"","")
    $data[5] = $data[5].Replace("`"","")
    $data[8] = $data[8].Replace("`"","")
    $data[14] = $data[14].Replace("`"","")

    $writer.WriteLine('{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|'`
        + '{14}|{15}|{16}|{17}|{18}|{19}', $data[0], $data[1], $data[2], $data[3], $data[4]
        , $data[5], $data[6], $data[7], $data[8], $data[9], $data[10], $data[11], $data[12]
        , $data[13], $data[14], $data[15], $data[16], $data[17], $data[18], $data[19])
}
$reader.Close()
$writer.Close()

$content = Get-Content './appsettings.json' -Raw
$json = $content | Convertfrom-Json
$user = $json.User
$password = $json.Password
$server = $json.Server
$command = "bcp"
[string[]] $countriesArgs = @('Countries', 'in', './Data/countries_out.csv', '-S', $server
    , '-d', 'runwayDb', '-U', $user, '-P', $password, '-c', '-t\"|"', '-E')
[string[]] $regionsArgs = @('Regions', 'in', './Data/regions_out.csv', '-S', $server
    , '-d', 'runwayDb', '-U', $user, '-P', $password, '-c', '-t\"|"', '-E')
[string[]] $airportsArgs = @('Airports', 'in', './Data/airports_out.csv', '-S', $server
    , '-d', 'runwayDb', '-U', $user, '-P', $password, '-c', '-t\"|"', '-E')
[string[]] $runwaysArgs = @('Runways', 'in', './Data/runways_out.csv', '-S', $server
    , '-d', 'runwayDb', '-U', $user, '-P', $password, '-c', '-t\"|"', '-E')
    
Invoke-Expression "$command $countriesArgs"
Invoke-Expression "$command $regionsArgs"
Invoke-Expression "$command $airportsArgs"
Invoke-Expression "$command $runwaysArgs"
