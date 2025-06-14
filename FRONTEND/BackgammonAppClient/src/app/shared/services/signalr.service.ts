import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { environment } from '../../../environments/environment.development';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  private hubConnection!: signalR.HubConnection;

  public messages: string[] = [];
  private isConnected: boolean = false;

  constructor(
    private authService: AuthService
  ) { }

  startConnection(){
    if (this.isConnected) {
      return;
    }

    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiBaseURL}/backgammonHub`, {
        accessTokenFactory: () => {
          const token = this.authService.getToken();
          return token ? token.trim() : '';
        }
      })
      .withAutomaticReconnect({
        nextRetryDelayInMilliseconds: retryContext => {
          if (retryContext.elapsedMilliseconds > 30000) {
            return null;
          }

          return Math.min(1000 * Math.pow(2, retryContext.previousRetryCount), 30000);
        }
      })
      .build();

    this.hubConnection
      .start()
      .then(() => {
        console.log('SignalR Connection started');
        this.isConnected = true;
        this.addMessageListener();
      })
      .catch(err => console.log('Error establishing SignalR connection: ' + err));

    this.hubConnection.onreconnecting(error => {
      console.warn('Reconnecting...', error);
    });

    this.hubConnection.onreconnected(connectionId => {
      console.log('Reconnected!', connectionId);
    });

    this.hubConnection.onclose(error => {
      if (error) {
        console.warn("Connection closed unexpectedly:", error.message);
      } else {
        console.log("Connection closed gracefully.");
      }
    });
  }

  stopConnection(){
    if (this.hubConnection) {
      this.hubConnection
        .stop()
        .then(() => {
          console.log('SignalR connection stopped');
          this.isConnected = false;
        })
        .catch(err => console.error('Error stopping SignalR connection: ', err));
    }
  }

  addMessageListener(){
    this.hubConnection.on('ReceiveMessage', (user: string, message: string) => {
      console.log(`User: ${user}, Message: ${message}`);
    });
  }

  sendMessage(user: string, message: string){
    this.hubConnection.invoke('SendMessage', user, message)
      .catch(err => console.log(err));
  }


}
