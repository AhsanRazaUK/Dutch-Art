import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs';

@Injectable()

export class DutchArtService {
  private apiUrl: string = "../../../assets/DutchArt.json";

  constructor(private http: HttpClient) {
  }

  getData(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
