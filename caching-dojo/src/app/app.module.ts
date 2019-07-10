import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ChartComponentComponent } from './chart-component/chart-component.component';
import { ChartsModule } from 'ng2-charts';
import { CachingService } from './caching.service';

@NgModule({
  declarations: [
    AppComponent,
    ChartComponentComponent
  ],
  imports: [
    ChartsModule,
    BrowserModule,
    HttpClientModule,
  ],
  providers: [
    CachingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
