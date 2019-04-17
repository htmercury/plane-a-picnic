import { Countries } from './../countries/countries';
import { useView, inject, TaskQueue, autoinject } from 'aurelia-framework';
import Airport from '../../models/Airport';
import AirportService from '../../services/AirportService';
import Region from '../../models/Region';
import RegionService from '../../services/RegionService';
import Country from '../../models/Country';
import CountryService from '../../services/CountryService';

@useView('./home.html')
@autoinject()
export class Home {
  taskQueue: TaskQueue;
  categoryContent: Array<any>;
  selected: string;
  selectedDisplay: Object;
  private _airportService: AirportService;
  private _regionService: RegionService;
  private _countryService: CountryService;

  constructor(TaskQueue: TaskQueue, countryService: CountryService, regionService: RegionService, airportService: AirportService) {
    this.taskQueue = TaskQueue;
    this._airportService = airportService;
    this._regionService = regionService;
    this._countryService = countryService;
    this.categoryContent = [];
  }

  attached() {
    this.taskQueue.queueMicroTask(() => {
      $('.ui.search').hide();
      $('.countries.ui.search').show();

      var setSearch = this.setSearch;
      ($('.ui.filter') as any)
        .dropdown(
          {
            "set selected": "countries",
            'onChange': function () {
              this.selected = ($('.ui.filter') as any).dropdown('get value');
              $('.ui.search').removeClass("disabled");

              $('.ui.search').hide();
              $('.prompt').val('');

              $(`.${this.selected}.ui.search`).show();

              setSearch(this.selected);
            }
          });
    });
  }

  setSearch(title) {
    ($(`.${title}.ui.search`) as any)
      .search({
        type: 'category',
        minCharacters: 3,
        apiSettings: {
          onResponse: function (apiResponse) {
            var response = {
              results: {
                data: {
                  name: title,
                  results: []
                }
              }
            };

            var data = Object.values(apiResponse);

            if (data.length == 0) {
              return false;
            }

            // translate API response to work with search
            $.each(data, function (index, item: any) {
              var maxResults = 8;
              if (<number>index >= maxResults) {
                return false;
              }

              // process object
              var entry : any = {title: item.name};
              if (title == 'countries') {
                entry.description = `continent: ${item.continent}` || 'N/A';
                entry.url = `/${title}/${item.countryId}`
              }
              else if (title == 'regions') {
                entry.description = `continent: ${item.continent}; country: ${item.isoCountry}` || 'N/A';
                entry.url = `/${title}/${item.regionId}`
              }
              else {
                entry.description = `continent: ${item.continent}; country: ${item.isoCountry}; region: ${item.isoRegion}` || 'N/A';
                entry.url = `/${title}/${item.airportId}`
              }

              // add result to category
              response.results.data.results.push(entry);
            });
            return response;
          },
          url: `api/${title}?q={query}`
        }
      });
  }
}


