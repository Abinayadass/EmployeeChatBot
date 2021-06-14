import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class SignupService {

  constructor(private http: Http) { }

  public signup(data) {

    let UserRequestObject = {
      Name: data.name,
      Email: data.email,
      Password: data.password,
      UserType: 'user'
    }
    return this.http.post("/api/User/Register", UserRequestObject)
  }

}
