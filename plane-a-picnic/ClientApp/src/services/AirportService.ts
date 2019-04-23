import Base from './Base'
import BaseService from './Base';

export default class AirportService extends BaseService {
  getAllAirports() {
    return this.http.fetch(`api/airports`)
      .then(response => response.json());
  }
  getAirport(id) {
    return this.http.fetch(`api/airports/${id}`)
      .then(response => response.json());
  }
  getForecast(id) {
    return this.http.fetch(`api/airports/${id}/weather`)
      .then(response => response.json());
  }
  getPredictions(id) {
    return this.http.fetch(`api/airports/${id}/prediction`)
      .then(response => response.json());
  }
}
