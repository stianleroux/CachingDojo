import { Component } from '@angular/core';
import { CachingService } from './caching.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'caching-dojo';

  public isLoading: boolean;
  public timeResult: string;

  constructor(private cachingService: CachingService) {
    this.isLoading = false;
  }

  public onGetWithoutCachingAndNoClientCaching()
  {
    this.isLoading = true;
    var currentDate = Date.now()
    this.timeResult = "";

    this.cachingService.GetWithoutApiCaching().subscribe((response) => {
      this.isLoading = false;
      this.timeResult = (Date.now() - currentDate) / 1000 + ' seconds';  
    }, (error) => {
      this.isLoading = false;
      this.timeResult = "Error :-(";
      console.error('error', error);
    });
  }

  public onGetWithoutCachingAndWithClientCaching()
  {
    this.isLoading = true;
    var currentDate = Date.now()
    this.timeResult = "";

    this.cachingService.GetWithClientCachingAndWithoutApiCaching().subscribe((response) => {
      this.isLoading = false;
      this.timeResult = (Date.now() - currentDate) / 1000 + ' seconds';  
    }, (error) => {
      this.isLoading = false;
      this.timeResult = "Error :-(";
      console.error('error', error);
    });
  }

  public onGetWithCachingAndNoClientCaching()
  {
    this.isLoading = true;
    var currentDate = Date.now()
    this.timeResult = "";

    this.cachingService.GetWithApiCaching().subscribe((response) => {
      this.isLoading = false;
      this.timeResult = (Date.now() - currentDate) / 1000 + ' seconds';  
    }, (error) => {
      this.isLoading = false;
      this.timeResult = "Error :-(";
      console.error('error', error);
    });
  }

  public onGetWithCachingAndWithClientCaching()
  {
    this.isLoading = true;
    var currentDate = Date.now()
    this.timeResult = "";

    this.cachingService.GetWithClientCachingAndWithApiCaching().subscribe((response) => {
      this.isLoading = false;
      this.timeResult = (Date.now() - currentDate) / 1000 + ' seconds';  
    }, (error) => {
      this.isLoading = false;
      this.timeResult = "Error :-(";
      console.error('error', error);
    });
  }

}
