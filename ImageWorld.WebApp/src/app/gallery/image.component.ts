import { Component, OnInit, Input  } from '@angular/core';
import { Http } from '@angular/http'

class Image {
  public src: string;
  public thumbnail: string;
  public text: string;
}

@Component({
    selector: 'dog-image',
    templateUrl: './image.component.html',
    styleUrls: ['./image.component.css']
})
export class DogImage implements OnInit {
  @Input() image;
  constructor() { }
    apiValues: string[] = [];
    ngOnInit() {
      
    }
}

