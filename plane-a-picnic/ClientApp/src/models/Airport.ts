import Runway from './Runway';

export default class Airport {
  airportId : number;
  type: string;
  name: string;
  latitudeDeg: number;
  longitudeDeg: number;
  elevationFt: number;
  continent: string;
  isoCountry: string;
  isoRegion: string;
  scheduledService: boolean;
  gpsCode: string;
  iataCode: string;
  runways: Array<Runway>;
  wikipediaLink: string;
  keywords: string;
}
