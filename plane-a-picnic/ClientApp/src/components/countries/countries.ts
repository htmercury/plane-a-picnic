import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Country from '../../models/Country';
import CountryService from '../../services/CountryService';

@useView('./countries.html')
@autoinject
export class Countries {
  taskQueue: TaskQueue;
  index: number;
  loading: boolean;
  public displayCountries: Array<Country>;
  public countries: Array<Country>;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._countryService = countryService;
    this.countries = [];
    this.loading = true;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .countries.item').addClass('active');
      
      this._countryService.getAllCountries()
        .then(countries => {
          this.countries = countries as Array<Country>;
          this.displayCountries = this.countries.slice(0, 25);
          this.loading = false;
        });
    });
  }
}
