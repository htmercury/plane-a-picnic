import Region from "./Region";

export default class Country {
  countryId : number;
  name: string;
  continent: string;
  wikipediaLink: string;
  keywords: string;
  regions: Array<Region>
}
