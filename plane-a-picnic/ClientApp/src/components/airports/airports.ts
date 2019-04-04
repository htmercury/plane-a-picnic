import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../models/Airport';
import AirportService from '../../services/AirportService';

@useView('./airports.html')
@autoinject
export class Airports {
  taskQueue: TaskQueue;
  page: number;
  public airports: Array<Airport>;
  private _airportService: AirportService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
  }

  activate(params) {
    this.page = params.page;
    if (params.page == null) {
      this.page = 1;
    }
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._airportService.getAllAirports(this.page)
        .then(airports => this.airports = airports as Array<Airport>);
    });
  }
}
