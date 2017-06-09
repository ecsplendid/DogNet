import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GalleryModule, GalleryConfig } from 'ng-gallery';

export const galleryConfig: GalleryConfig = {
  style: {
    background: "#121519",
    width: "900px",
    height: "600px"
  },
  animation: "fade",
  loader: {
    width: "50px",
    height: "50px",
    position: "center",
    icon: "oval"
  },
  description: {
    position: "bottom",
    overlay: true,
    text: true,
    counter: true,
    style: {}
  },
  navigation: true,
  bullets: {
    position: "bottom"
  },
  player: {
    autoplay: false,
    speed: 3000
  },
  thumbnails: {
    width: 100,
    height: 100,
    position: "bottom",
    space: 20
  }
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    BrowserAnimationsModule,
    GalleryModule.forRoot(galleryConfig)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
