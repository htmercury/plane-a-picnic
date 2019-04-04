import { Aurelia, inject, TaskQueue } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import { RouterConfiguration, Router } from 'aurelia-router';

@inject(TaskQueue)
export class App {
  taskQueue: TaskQueue;
  router: Router;
  public message: string = 'Hello Worlds!';
  constructor(TaskQueue) {
    this.taskQueue = TaskQueue;
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = 'Aurelia';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: ['', 'home'], name: 'home', nav: true, moduleId: PLATFORM.moduleName('./components/home/home'), title: 'home' },
      { route: '/countries', name: 'countries', nav: true, moduleId: PLATFORM.moduleName('./components/countries/countries'), title: 'countries' },
      { route: '/regions', name: 'regions', nav: true, moduleId: PLATFORM.moduleName('./components/regions/regions'), title: 'regions' },
      { route: '/airports', name: 'airports', nav: true, moduleId: PLATFORM.moduleName('./components/airports/airports'), title: 'airports' }
    ]);
    
    config.mapUnknownRoutes('not-found');
    this.router = router;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      ($('.ui.dropdown') as any)
        .dropdown();
    });
  }
}

