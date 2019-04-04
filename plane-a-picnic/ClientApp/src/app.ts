import { Aurelia, inject, TaskQueue } from 'aurelia-framework';
import { PLATFORM } from 'aurelia-pal';
import { RouterConfiguration, Router } from 'aurelia-router';
import 'semantic-ui';

@inject(TaskQueue)
export class App {
  taskQueue: TaskQueue;
  router: Router;
  public message: string = 'Hello Worlds!';
  constructor(TaskQueue) {
    this.taskQueue = TaskQueue;
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    this.router = router;
    config.title = 'Aurelia';
    config.map([
      { route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('components/home/home') },
    ]);
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.context.example .ui.sidebar')
        .sidebar({
          context: $('.context.example .bottom.segment')
        })
        .sidebar('attach events', '.context.example .menu .item')
        ;
  });
}
}

