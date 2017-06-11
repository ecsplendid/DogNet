import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

export interface Result {
  ProcessedCustomVision: boolean;
  ProcessedCognitiveServices: boolean;
  ProcessedAzureMachineLearning: boolean;
  Created: Date;
  Name?: any;
  Description?: any;
  Tags: string[];
  PredictedCaption: string;
  WaldoDetected: boolean;
  IllegalWatermark: boolean;
  Bytes?: any;
  id: string;
}

export interface Image {
  Result: Result;
  Id: number;
  Exception?: any;
  Status: number;
  IsCanceled: boolean;
  IsCompleted: boolean;
  CreationOptions: number;
  AsyncState?: any;
  IsFaulted: boolean;
}

@Component({
    selector: 'app-root',
    templateUrl: './gallery.component.html',
    styleUrls: ['./gallery.component.css']
})
export class DogGallery implements OnInit {
  constructor(private httpService: Http) { }
    apiValues: string[] = [];
    ngOnInit() {
      this.httpService.get('http://hsbc-api-app.azurewebsites.net/api/Image/GetImages').subscribe(values => {

        console.log(values.json());
        
        this.images = (values.json() as Image[]);
        
      });
    }
    images: Image[] = [];
  
}

