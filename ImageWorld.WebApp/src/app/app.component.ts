import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { GalleryService } from 'ng-gallery';

class Image {
  public src: string;
  public thumbnail: string;
  public text: string;
}

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private httpService: Http, public gallery: GalleryService) { }
    apiValues: string[] = [];
    ngOnInit() {
      this.httpService.get('http://hsbc-api-app.azurewebsites.net/api/Image/GetImages').subscribe(values => {

        console.log(values.json());

        this.images = (values.json() as string[])
          .map<Image>(v => { return { src: v, text: v, thumbnail: v } });

        this.gallery.load(this.images);
      });
    }

   

    images: Image[] = [];
  
}


