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
  loading: Boolean;
  infoText: string;
  public region: Region;
  private _regionService: RegionService;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, regionService: RegionService, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._regionService = regionService;
    this._countryService = countryService;
    this.emptyAirport = false;
    this.region = this.initializeDefault();
    this.loading = true;
  }

  setLoading() {
    let self = this;
    setTimeout(function(){
        self.infoText = `
          <li><p style="color: black; font-size:1rem;">Continent: ${self.region.continent}</p></li>
          <li><p style="color: black; font-size:1rem;">Country: <a href='/countries/${self.countryId}'>${self.countryName}</a></p></li>
          <li><p style="color: black; font-size:1rem;">Wikipedia: <a href='${self.region.wikipediaLink || 'javascript:void(0)'}'>${self.region.wikipediaLink || 'N/A'}</a></p></li>
          <li><p style="color: black; font-size:1rem;">Keywords: ${self.region.keywords || 'N/A'}</p></li>
        `
        self.loading = false;
    }, 2000);
  }

  initializeDefault() {
    let region = new Region();
    region.continent = 'N/A';
    region.wikipediaLink = 'N/A';
    region.keywords = 'N/A';
    return region;
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
    this.setLoading();
  }
}
