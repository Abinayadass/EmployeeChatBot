import { Component, OnInit, Input, AfterViewInit, ViewChild, ViewChildren, QueryList, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { Message } from '../models/message'
import { ChatService } from '../services/chat/chat.service'


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  user : any;
  public message : Message;
  public messages : Message[];

  // Code for Scrolling
  @ViewChild('chatlist', { read: ElementRef, static: true }) chatList: ElementRef;
  @ViewChildren(ChatComponent, { read: ElementRef }) chatItems: QueryList<ChatComponent>;

  constructor(
  	private chatService : ChatService,
    private router: Router
  	) { 
  	this.message = new Message('', 'assets/images/user.png', new Date());
  	this.messages = [
  	new Message('Welcome to chatbot universe', 'assets/images/bot.png', new Date())
  	];
  }

  ngOnInit() {
     this.user = localStorage.getItem("user");
     console.log(this.user, "logged in user")
     if(!this.user)
       this.router.navigateByUrl('');
  }

  ngAfterViewInit() {
    this.chatItems.changes.subscribe(elements => {
      this.scrollToBottom();
    });
  }

  logout() {
    localStorage.removeItem("user");
    localStorage.clear();
    this.router.navigateByUrl('');
  }

  sendMessage(){
    this.message["timestamp"] = new Date();
    this.messages.push(this.message);

    this.chatService.getResponse(this.message["content"]).subscribe(res => {
      var responsedata = JSON.parse(res["_body"]).chatQuestionsResponses.chartAnswers;
      responsedata = responsedata == undefined ? "" : responsedata;
      this.messages.push(
        new Message(responsedata, 'assets/images/bot.png', new Date())
      );
      this.scrollToBottom();
    });

    this.message = new Message('', 'assets/images/user.png', new Date);
  }

  private scrollToBottom(): void {
    try {
      this.chatList.nativeElement.scrollTop = this.chatList.nativeElement.scrollHeight;
    }
    catch (err) {
      console.log('Could not find the "chatList" element.');
    }
  }
}
