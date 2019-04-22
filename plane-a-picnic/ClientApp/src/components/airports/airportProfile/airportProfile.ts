import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../../models/Airport';
import AirportService from '../../../services/AirportService';
import CountryService from '../../../services/CountryService';
import RegionService from '../../../services/RegionService';

@useView('./airportProfile.html')
@autoinject
export class AirportProfile {
  taskQueue: TaskQueue;
  id: number;
  regionId: number;
  regionName: string;
  countryId: number;
  countryName: string;
  loading: boolean;
  public airport: Airport;
  private _airportService: AirportService;
  private _regionService: RegionService;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService, regionService: RegionService, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
    this._regionService = regionService;
    this._countryService = countryService;
    this.airport = this.initializeDefault();
    this.loading = true;
  }

  setLoading() {
    let self = this;
    setTimeout(function(){
        self.loading = false;
    }, 2000);
  }

  initializeDefault() {
    let airport = new Airport();
    airport.continent = 'N/A';
    airport.wikipediaLink = 'N/A';
    airport.keywords = 'N/A';
    this.countryId = -1;
    this.regionId = -1;
    return airport;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .airports.item').addClass('active');

      this._airportService.getAirport(this.id)
        .then(airport => {
          this.airport = airport as Airport;

          this._regionService.getRegionByCode(this.airport.isoRegion)
            .then(region => {
              this.regionId = region.regionId;
              this.regionName = region.name;
            });
          
          this._countryService.getCountryByCode(this.airport.isoCountry)
            .then(country => {
              this.countryId = country.countryId;
              this.countryName = country.name;
            });
          
          this.setLoading();
        });
    });
  }
}
