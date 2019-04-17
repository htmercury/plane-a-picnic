import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../models/Airport';
import AirportService from '../../services/AirportService';

@useView('./airports.html')
@autoinject
export class Airports {
  taskQueue: TaskQueue;
  index: number;
  loading: boolean;
  public airports: Array<Airport>;
  public displayAirports: Array<Airport>;
  private _airportService: AirportService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
    this.airports = [];
    this.displayAirports = [];
    this.index = 0;
    this.loading = true;
  }

  getMore(topIndex, isAtBottom, isAtTop) {
    if (isAtBottom) {
      for (let i = 0; i < 32; i++) {
        this.displayAirports.push(this.airports[this.index]);
        this.index++;
      }
    }
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .airports.item').addClass('active');

      this._airportService.getAllAirports()
        .then(airports => {
          this.airports = airports as Array<Airport>;
          this.displayAirports = this.airports.slice(0, 128);
          this.index = 128;
          this.loading = false;
        });
    });
  }
}
