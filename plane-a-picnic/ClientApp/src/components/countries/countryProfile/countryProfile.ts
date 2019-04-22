import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Country from '../../../models/Country';
import CountryService from '../../../services/CountryService';

@useView('./countryProfile.html')
@autoinject
export class CountryProfile {
  taskQueue: TaskQueue;
  id: number;
  emptyRegion: Boolean;
  loading: boolean;
  public country: Country;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._countryService = countryService;
    this.emptyRegion = false;
    this.country = this.initializeDefault();
    this.loading = true;
  }

  setLoading() {
    let self = this;
    setTimeout(function(){
        self.loading = false;
    }, 1500);
  }

  initializeDefault() {
    let country = new Country();
    country.continent = 'N/A';
    country.wikipediaLink = 'N/A';
    country.keywords = 'N/A';
    return country;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .countries.item').addClass('active');

      this._countryService.getCountry(this.id)
        .then(country => {
          this.country = country as Country;
          if (this.country.regions.length == 0) {
            this.emptyRegion = true;
          }
        });
    });

    this.setLoading();
  }
}
