import { Component, OnInit, ViewChild } from '@angular/core';
import { BaseChartDirective } from 'ng2-charts';
import { CachingService } from '../caching.service';

@Component({
  selector: 'app-chart-component',
  templateUrl: './chart-component.component.html',
  styleUrls: ['./chart-component.component.css']
})
export class ChartComponentComponent implements OnInit {

  @ViewChild(BaseChartDirective)
  public chart: BaseChartDirective;

  constructor(private cachingService: CachingService) { }

  public lineChartLabels: Array<any> = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10'];
  public lineChartData: Array<any> =  [
   {data: null, label: 'Cached' , fill: false },
   {data: null, label: 'Uncached' , fill: false }
  ];
  public lineChartOptions: any = {
    responsive: true,
      scales: {
        yAxes: [{
          scaleLabel: {
            display: true,
            labelString: 'Seconds'
          }
        }],
        xAxes: [{
          scaleLabel: {
            display: true,
            labelString: 'attempts'
          }
        }]
    }

  };
  public lineChartColors: Array<any> = [
    { 
      backgroundColor: 'rgb(54, 162, 235)',
      borderColor: 'rgb(54, 162, 235)',
    },
    {
      backgroundColor: 'rgb(255,54,54)',
      borderColor: 'rgb(255,54,54)',
    }
  ];
  public lineChartLegend: boolean = true;
  public lineChartType: string = 'line';


  ngOnInit() {
  }

  public async onPopulateChart()
  {
    var chartWithCachingData = [];
    var chartWithoutCachingData = [];

    for(let i =0; i < 10; i++)
    {
      chartWithCachingData.push(await this.getWithApiCachingTime());

      chartWithoutCachingData.push(await this.getWithoutApiCachingTime());

      this.lineChartData =  [
        {data: chartWithCachingData, label: 'Cached' , fill: false },
        {data: chartWithoutCachingData, label: 'Uncached' , fill: false }
      ];

      //redraw chart
      this.chart.chart.update();
    }
  }

  public async getWithApiCachingTime()
  {
    let currentDate = Date.now();
    await this.cachingService.GetWithApiCaching().toPromise();

    //return seconds
    return (Date.now() - currentDate) / 1000;
  }

  public async getWithoutApiCachingTime()
  {
    let currentDate = Date.now();
    await this.cachingService.GetWithoutApiCaching().toPromise();

    //return seconds
    return (Date.now() - currentDate) / 1000;
  }
}
