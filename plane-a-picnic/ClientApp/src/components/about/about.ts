import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';

declare var MathJax: any;

@useView('./about.html')
@autoinject
export class About {
  taskQueue: TaskQueue;

  constructor(TaskQueue: TaskQueue) {
    this.taskQueue = TaskQueue;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .about.item').addClass('active');

      setTimeout(function() {
        MathJax.Hub.Queue(["Typeset",MathJax.Hub]);
      }, 1000);
    });
  }
}
