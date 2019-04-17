import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Region from '../../../models/Region';
import RegionService from '../../../services/RegionService';
import CountryService from '../../../services/CountryService';

@useView('./regionProfile.html')
@autoinject
export class RegionProfile {
  taskQueue: TaskQueue;
  id: number;
  countryId: number;
  countryName: string;
  emptyAirport: Boolean;
  public region: Region;
  private _regionService: RegionService;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, regionService: RegionService, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._regionService = regionService;
    this._countryService = countryService;
    this.emptyAirport = false;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .regions.item').addClass('active');

      this._regionService.getRegion(this.id)
        .then(region => {
          this.region = region as Region;
          if (this.region.airports.length == 0) {
            this.emptyAirport = true;
          }

          this._countryService.getCountryByCode(this.region.isoCountry)
            .then(country => {
              this.countryId = country.countryId;
              this.countryName = country.name;
            });
        });
    });
  }
}
