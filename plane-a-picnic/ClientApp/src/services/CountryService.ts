import Base from './Base'
import BaseService from './Base';

export default class CountryService extends BaseService {
  getAllCountries() {
    return this.http.fetch('api/countries')
      .then(response => response.json());
  }
  getCountry(id) {
    return this.http.fetch(`api/countries/${id}`)
      .then(response => response.json());
  }
  getCountryByCode(code) {
    return this.http.fetch(`api/countries/iso/${code}`)
      .then(response => response.json());
  }
}
