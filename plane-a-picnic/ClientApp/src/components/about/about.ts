import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import { MathJax } from 'mathjax';

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

      MathJax.Hub.Queue(["Typeset",MathJax.Hub]);
    });
  }
}
