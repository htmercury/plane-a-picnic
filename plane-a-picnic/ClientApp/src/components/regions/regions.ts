import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Region from '../../models/Region';
import RegionService from '../../services/RegionService';

@useView('./regions.html')
@autoinject
export class Regions {
  taskQueue: TaskQueue;
  public regions: Array<Region>;
  private _regionService: RegionService;

  constructor(TaskQueue: TaskQueue, regionService: RegionService) {
    this.taskQueue = TaskQueue;
    this._regionService = regionService;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._regionService.getAllRegions()
        .then(regions => this.regions = regions as Array<Region>);
    });
  }
}
