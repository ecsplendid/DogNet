import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Headers, RequestOptions, Request, RequestMethod } from '@angular/http';
import 'rxjs/Rx';

@Component({
  selector: 'file-uploader',
  templateUrl: './fupload.component.html'
})
export class SimpleFileUploader {

  constructor(private httpService: Http) { }

  apiEndPoint: string = "http://localhost:60133/api/Image/upload";

  public uploading: boolean;
  public completed: boolean;
  public failed: boolean;

  fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      let file: File = fileList[0];
      let headers = new Headers();
      headers.append('Content-Type', 'multipart/form-data');
      headers.append('Accept', 'application/json');
      let options = new RequestOptions();
      options.headers = headers;
      this.uploading = true;
      this.httpService.post(`${this.apiEndPoint}`, file, options)
        .map(res => res.json())
        .catch(error => Observable.throw(error))
        .subscribe(
          data => {
            console.log('success');
            this.completed = true;
            this.uploading = false;
          },
          error => {
            console.log(error);
            this.failed = true;
            this.uploading = false;
          
          }
        )
    }
  }
}
