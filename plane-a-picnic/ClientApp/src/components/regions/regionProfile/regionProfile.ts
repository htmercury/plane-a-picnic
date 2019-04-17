import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Region from '../../../models/Region';
import RegionService from '../../../services/RegionService';

@useView('./regionProfile.html')
@autoinject
export class RegionProfile {
  taskQueue: TaskQueue;
  id: number;
  public region: Region;
  private _regionService: RegionService;

  constructor(TaskQueue: TaskQueue, regionService: RegionService) {
    this.taskQueue = TaskQueue;
    this._regionService = regionService;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .regions.item').addClass('active');

      this._regionService.getRegion(this.id)
        .then(region => this.region = region as Region);
    });
  }
}
