import { HttpClient } from 'aurelia-fetch-client';
import { autoinject } from 'aurelia-framework';

@autoinject
export default class BaseService {
  public http: HttpClient;
  constructor(private _http: HttpClient) {
    this.http = _http.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl('/');
    });
  }
}
