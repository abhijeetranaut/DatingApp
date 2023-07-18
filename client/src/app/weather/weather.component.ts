// weather.component.ts

import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent {

  queryParameter = '';
  weatherData: any;
  hasSearched = false;

  constructor(private http: HttpClient) { }

  getWeatherData(): void {
    const apiUrl = 'https://localhost:5001/api/weather';

    const headers = new HttpHeaders({
      'X-RapidAPI-Key': 'b058d5e763msh7f90b2a34c987cfp1d69adjsn6243c98718cd',
      'X-RapidAPI-Host': 'weatherapi-com.p.rapidapi.com'
    });

    this.http.get(apiUrl, { headers, params: { queryParameter: this.queryParameter } }).subscribe({
      next: (data) => {
        this.weatherData = data;
        this.hasSearched = true;
      },
      error: (error) => {
        this.weatherData = null;
        this.hasSearched = true;
        console.error('Error fetching weather data:', error);
      }
    });
  }
}
