import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../models/Airport';
import AirportService from '../../services/airportService';

@useView('./airports.html')
@autoinject
export class Airports {
  taskQueue: TaskQueue;
  public airports: Array<Airport>;
  private _airportService: AirportService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._airportService.getAllAirports()
        .then(airports => this.airports = airports as Array<Airport>);
    });
  }
}
