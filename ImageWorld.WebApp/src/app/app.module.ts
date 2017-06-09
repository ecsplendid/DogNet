import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent, galleryConfig } from './gallery/app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GalleryModule } from 'ng-gallery';


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
