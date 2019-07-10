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
   {data: null, label: 'Series A' , fill: false },
  ];
  public lineChartOptions: any = {
    responsive: true
  };
  public lineChartColors: Array<any> = [
    { 
      backgroundColor: 'rgb(54, 162, 235)',
      borderColor: 'rgb(54, 162, 235)',
    }
  ];
  public lineChartLegend: boolean = false;
  public lineChartType: string = 'line';


  ngOnInit() {
  }

   public async onPopulateChartWithCaching()
  {
    var chartData = [];

    for(let i =0; i < 10; i++)
    {
      let currentDate = Date.now();

      var result = await this.cachingService.GetWithApiCaching().toPromise();

      //get seconds
      chartData.push((Date.now() - currentDate) / 1000);

      this.lineChartData =  [
      {data: chartData, label: 'Seconds' , fill: false },
      ];

      //redraw chart
      this.chart.chart.update();
    }
  }

  public async onPopulateChartWithoutCaching()
  {
    var chartData = [];

    for(let i =0; i < 10; i++)
    {
      let currentDate = Date.now();

      var result = await this.cachingService.GetWithoutApiCaching().toPromise();

      //get seconds
      chartData.push((Date.now() - currentDate) / 1000);

      this.lineChartData =  [
      {data: chartData, label: 'Seconds' , fill: false },
      ];

      //redraw chart
      this.chart.chart.update();
    }
  }
}
