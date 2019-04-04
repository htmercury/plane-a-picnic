import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Country from '../../models/Country';
import CountryService from '../../services/CountryService';

@useView('./countries.html')
@autoinject
export class Countries {
  taskQueue: TaskQueue;
  public countries: Array<Country>;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._countryService = countryService;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._countryService.getAllCountries()
        .then(countries => this.countries = countries as Array<Country>);
    });
  }
}
