import { Component, OnDestroy, OnInit } from '@angular/core';
import { SignalRService } from '../../shared/services/signalr.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-signalr.backgammon',
  imports: [FormsModule, CommonModule],
  templateUrl: './signalr.backgammon.component.html',
  styles: ``
})
export class SignalRBackgammonComponent implements OnInit, OnDestroy {
  user = '';
  message = '';

  constructor(public signalRService: SignalRService){}
  
    ngOnInit(): void {
      this.signalRService.startConnection();
      //this.signalRService.addMessageListener();
    }

  ngOnDestroy(): void {
    this.signalRService.stopConnection();
  }

  sendMessage(){
    this.signalRService.sendMessage(this.user, this.message);
    this.message = '';
  }
}
