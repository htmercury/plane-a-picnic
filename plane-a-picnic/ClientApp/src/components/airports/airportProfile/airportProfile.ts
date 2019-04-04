import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../../models/Airport';
import AirportService from '../../../services/AirportService';

@useView('./airportProfile.html')
@autoinject
export class AirportProfile {
  taskQueue: TaskQueue;
  id: number;
  public airport: Airport;
  private _airportService: AirportService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._airportService.getAirport(this.id)
        .then(airport => this.airport = airport as Airport);
    });
  }
}
