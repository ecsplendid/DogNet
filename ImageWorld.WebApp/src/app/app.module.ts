import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { DogGallery } from './gallery/gallery.component';
import { DogImage } from './gallery/image.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SimpleFileUploader } from './fileupload/fupload.component';


@NgModule({
  declarations: [
    DogGallery,
    DogImage,
    SimpleFileUploader
  ],
  imports: [
    BrowserModule,
    HttpModule,
    BrowserAnimationsModule
    
  ],
  providers: [],
  bootstrap: [DogGallery, SimpleFileUploader]
})
export class AppModule { }
