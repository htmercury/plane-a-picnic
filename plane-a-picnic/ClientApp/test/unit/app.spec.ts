import { TaskQueue } from 'aurelia-framework';
import {App} from '../../src/app';

describe('the app', () => {
  it('says hello', () => {
    expect(new App(TaskQueue).message).toBe('Hello World!');
  });
});

