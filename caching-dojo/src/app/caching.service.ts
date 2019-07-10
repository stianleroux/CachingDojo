import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { Cacheable } from 'ngx-cacheable';

@Injectable({
  providedIn: 'root'
})
export class CachingService {

  //private apiPath = 'https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22';
  private apiPath = 'https://localhost:44332/api/airports/';

  constructor(private httpClient: HttpClient) { }

  public GetWithoutApiCaching(): Observable<any>
  {
    return this.httpClient.get(this.apiPath +  '?caching=false');
  }

  public GetWithApiCaching(): Observable<any>
  {
    return this.httpClient.get(this.apiPath +  '?caching=true');
  }

  @Cacheable()
  public GetWithClientCachingAndWithoutApiCaching(): Observable<any>
  {
    return this.httpClient.get(this.apiPath +  '?caching=false');
  }

  @Cacheable()
  public GetWithClientCachingAndWithApiCaching(): Observable<any>
  {
    return this.httpClient.get(this.apiPath + '?caching=true');
  }
}
