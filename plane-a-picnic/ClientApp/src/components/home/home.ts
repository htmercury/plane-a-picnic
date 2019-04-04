import { useView, inject, TaskQueue } from 'aurelia-framework';

@useView('./home.html')
@inject(TaskQueue)
export class Home {
  taskQueue: TaskQueue;
  constructor(TaskQueue) {
    this.taskQueue = TaskQueue;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      var categoryContent = [
        { category: 'South America', title: 'Brazil' },
        { category: 'South America', title: 'Peru' },
        { category: 'North America', title: 'Canada' },
        { category: 'Asia', title: 'South Korea' },
        { category: 'Asia', title: 'Japan' },
        { category: 'Asia', title: 'China' },
        { category: 'Europe', title: 'Denmark' },
        { category: 'Europe', title: 'England' },
        { category: 'Europe', title: 'France' },
        { category: 'Europe', title: 'Germany' },
        { category: 'Africa', title: 'Ethiopia' },
        { category: 'Africa', title: 'Nigeria' },
        { category: 'Africa', title: 'Zimbabwe' },
      ];


      ($('.ui.search') as any)
        .search({
          type: 'category',
          source: categoryContent
        });

      ($('.ui.filter') as any)
        .dropdown();
    });
  }
}


