import Airport from "./Airport";

export default class Region {
  regionId : number;
  name: string;
  continent: string;
  isoCountry: string;
  countryId: number;
  wikipediaLink: string;
  airports: Array<Airport>
  keywords: string;
}
