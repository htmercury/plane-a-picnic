import Base from './Base'
import BaseService from './Base';

export default class RegionService extends BaseService {
  getAllRegions() {
    return this.http.fetch('api/regions')
      .then(response => response.json());
  }
}
