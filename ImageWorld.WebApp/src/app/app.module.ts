import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AppComponent, galleryConfig } from './gallery/app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GalleryModule } from 'ng-gallery';
import { SimpleFileUploader } from './fileupload/fupload.component';


@NgModule({
  declarations: [
    AppComponent,
    SimpleFileUploader
  ],
  imports: [
    BrowserModule,
    HttpModule,
    BrowserAnimationsModule,
    GalleryModule.forRoot(galleryConfig),
    
  ],
  providers: [],
  bootstrap: [AppComponent, SimpleFileUploader]
})
export class AppModule { }
