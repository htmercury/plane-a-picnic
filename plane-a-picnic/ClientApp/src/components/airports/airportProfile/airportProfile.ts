import { useView, inject, TaskQueue, autoinject, Task } from 'aurelia-framework';
import Airport from '../../../models/Airport';
import Runway from '../../../models/Runway';
import AirportService from '../../../services/AirportService';
import CountryService from '../../../services/CountryService';
import RegionService from '../../../services/RegionService';

@useView('./airportProfile.html')
@autoinject
export class AirportProfile {
  taskQueue: TaskQueue;
  id: number;
  regionId: number;
  regionName: string;
  countryId: number;
  countryName: string;
  loading: boolean;
  predictions: Array<Runway>;
  emptyRunways: boolean;
  infoText: string;
  public airport: Airport;
  private _airportService: AirportService;
  private _regionService: RegionService;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, airportService: AirportService, regionService: RegionService, countryService: CountryService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
    this._regionService = regionService;
    this._countryService = countryService;
    this.emptyRunways = false;
    this.airport = this.initializeDefault();
    this.predictions = [];
    this.loading = true;
  }

  setLoading() {
    let self = this;
    setTimeout(function(){
        self.infoText = `
          <li><p style="color: black; font-size:1rem;">Continent: ${self.airport.continent}</p></li>
          <li><p style="color: black; font-size:1rem;">Country: <a href='/countries/${self.countryId}'>${self.countryName}</a></p></li>
          <li><p style="color: black; font-size:1rem;">Region: <a href='/regions/${self.regionId}'>${self.regionName}</a></p></li>
          <li><p style="color: black; font-size:1rem;">Wikipedia: <a href='${self.airport.wikipediaLink || 'javascript:void(0)'}'>${self.airport.wikipediaLink || 'N/A'}</a></p></li>
          <li><p style="color: black; font-size:1rem;">Number of runways: ${self.airport.runways.length}</p></li>
          <li><p style="color: black; font-size:1rem;">Keywords: ${self.airport.keywords || 'N/A'}</p></li>
        `;
        ($('.runways') as any).slick({
          dots: true,
          infinite: false,
          speed: 300,
          slidesToShow: 3,
          slidesToScroll: 3,
          responsive: [
            {
              breakpoint: 1080,
              settings: {
                slidesToShow: 2,
                slidesToScroll: 2,
                infinite: true,
                dots: true
              }
            },
            {
              breakpoint: 720,
              settings: {
                slidesToShow: 1,
                slidesToScroll: 1
              }
            }
          ]
        });
        ($('.ui.accordion') as any).accordion();
        self.loading = false;
    }, 2000);
  }

  initializeDefault() {
    let airport = new Airport();
    airport.continent = 'N/A';
    airport.wikipediaLink = 'N/A';
    airport.keywords = 'N/A';
    this.countryId = -1;
    this.regionId = -1;
    return airport;
  }

  activate(params) {
    this.id = params.id;
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.menu > .item').removeClass('active');
      $('.menu > .airports.item').addClass('active');

      this._airportService.getAirport(this.id)
        .then(airport => {
          this.airport = airport as Airport;

          this._regionService.getRegionByCode(this.airport.isoRegion)
            .then(region => {
              this.regionId = region.regionId;
              this.regionName = region.name;
            });
          
          this._countryService.getCountryByCode(this.airport.isoCountry)
            .then(country => {
              this.countryId = country.countryId;
              this.countryName = country.name;
            });
          
          });
          
          this._airportService.getPredictions(this.id)
          .then(res => {
            this.predictions = res;

            if (this.predictions.length == 0) {
              this.emptyRunways = true;
            }

            this.setLoading();
        });
      });
  }
}
