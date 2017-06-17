import { Component, OnInit } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http'

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

      let headers = new Headers({
          'Ocp-Apim-Subscription-Key': 
          'b8c6a53f26a54643b2359cbe91133f92'});

      let options = new RequestOptions({ headers: headers });

      this
        .httpService
        .get('http://hsbcimageapi.azure-api.net/api/Image/GetImages', options)
        .subscribe(values => {

        console.log(values.json());
        
        this.images = (values.json() as Image[]);
        
      });
  }

  images: Image[] = [];
  
}

