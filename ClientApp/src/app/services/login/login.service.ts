import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class LoginService {

  constructor(private http: Http) { }

  public login(data) {
    let loginRequestObject = {
      Email: data.username,
      Password: data.password,
    }
    return this.http.post("/api/User/login", loginRequestObject)
  }
}
