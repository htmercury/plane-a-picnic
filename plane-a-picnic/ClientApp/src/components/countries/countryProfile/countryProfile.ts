import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Country from '../../../models/Country';
import CountryService from '../../../services/CountryService';

@useView('./countryProfile.html')
@autoinject
export class CountryProfile {
  taskQueue: TaskQueue;
  id: number;
  public country: Country;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._countryService = countryService;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._countryService.getCountry(this.id)
        .then(country => this.country = country as Country);
    });
  }
}
