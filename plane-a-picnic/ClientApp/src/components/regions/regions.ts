import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Region from '../../models/Region';
import RegionService from '../../services/RegionService';

@useView('./regions.html')
@autoinject
export class Regions {
  taskQueue: TaskQueue;
  index: number;
  loading: boolean;
  public displayRegions: Array<Region>;
  public regions: Array<Region>;
  private _regionService: RegionService;

  constructor(TaskQueue: TaskQueue, regionService: RegionService) {
    this.taskQueue = TaskQueue;
    this._regionService = regionService;
    this.regions = [];
    this.displayRegions = [];
    this.index = 0;
    this.loading = true;
  }

  getMore(topIndex, isAtBottom, isAtTop) {
    if (isAtBottom && this.index != 3751) {
      for (let i = 0; i < 32; i++) {
        if (this.index == 3751) {
          break;
        }
        this.displayRegions.push(this.regions[this.index]);
        this.index++;
      }
    }
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      this._regionService.getAllRegions()
        .then(regions => {
          this.regions = regions as Array<Region>;
          this.displayRegions = this.regions.slice(0, 128);
          this.index = 128;
          this.loading = false;
        });
    });
  }
}
