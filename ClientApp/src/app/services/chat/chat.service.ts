import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class ChatService {

  constructor(private http: Http){}

  public getResponse(query: string) {
    return this.http.get("/api/ChatQuestions/GetChatAnswersbyQuestions?questionchar="+ query)
  }

}
