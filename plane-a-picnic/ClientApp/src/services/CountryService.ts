import Base from './Base'
import BaseService from './Base';

export default class CountryService extends BaseService {
  getAllCountries() {
    return this.http.fetch('api/countries')
      .then(response => response.json());
  }
}
