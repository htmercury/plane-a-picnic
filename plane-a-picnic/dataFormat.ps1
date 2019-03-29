## Countries
$reader = [System.IO.File]::OpenText('./Data/countries.csv')
$writer = New-Object System.IO.StreamWriter './Data/countries_out.txt'
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

    $writer.WriteLine('{0};{1};{2};{3};{4};{5}', $data[0], $data[1], $data[2]
        , $data[3], $data[4], $data[5])
}
$reader.Close()
$writer.Close()

## Regions
$reader = [System.IO.File]::OpenText('./Data/regions.csv')
$writer = New-Object System.IO.StreamWriter './Data/regions_out.csv'
$regions = @{}
for(;;) {
    $line = $reader.ReadLine()
    if ($null -eq $line) {
        break
    }
    $data = $line.Split(";")
    $writer.WriteLine('{0};{1};{2}', $data[0], $data[2], $data[1])
}
$reader.Close()
$writer.Close()

# ## Airports
# $reader = [System.IO.File]::OpenText('./Data/airports.csv')
# $writer = New-Object System.IO.StreamWriter './Data/airports_out.csv'
# $line = $reader.ReadLine() ## skip first line
# $writer.WriteLine('{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},'`
#     + '{14},{15},{16},{17},{18}', "AirportId", "Ident", "Type", "Name", "LatitudeDeg"
#     , "LongitudeDeg", "ElevationFt", "Continent", "IsoCountry", "IsoRegion", "RegionId"
#     , "Municipality", "ScheduledService", "GpsCode", "IataCode", "LocalCode"
#     , "HomeLink", "WikipediaLink", "Keywords")
# for(;;) {
#     $line = $reader.ReadLine()
#     if ($null -eq $line) {
#         break
#     }
#     $data = $line.Split(",")
#     $writer.WriteLine('{0};{1};{2}', $data[0], $data[2], $data[1])
# }
# $reader.Close()
# $writer.Close()

# ## Runways
# $reader = [System.IO.File]::OpenText('runways.csv')
# $writer = New-Object System.IO.StreamWriter 'runways_out.csv'
# for(;;) {
#     $line = $reader.ReadLine()
#     if ($null -eq $line) {
#         break
#     }
#     $data = $line.Split(";")
#     $writer.WriteLine('{0};{1};{2}', $data[0], $data[2], $data[1])
# }
# $reader.Close()
# $writer.Close()