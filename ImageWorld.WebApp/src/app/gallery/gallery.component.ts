import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'

class Image {
  public src: string;
  public thumbnail: string;
  public text: string;
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

        this.images = (values.json() as string[])
          .map<Image>(v => { return {
             src: v, text: v, thumbnail: v
          } });
        
      });
    }
    images: Image[] = [];
  
}

